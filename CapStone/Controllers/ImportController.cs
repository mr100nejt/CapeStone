using CapStone.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace AspDotNetMVCDemo.Controllers
{

    public class ImportController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        int specialId = 1;
        // GET: Import
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Post method for importing users 
        /// </summary>
        /// <param name="postedFile"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
           
            if (postedFile != null)
            {
                try
                {
                    string fileExtension = Path.GetExtension(postedFile.FileName);

                    //Validate uploaded file and return error.
                    if (fileExtension != ".xls" && fileExtension != ".xlsx")
                    {
                        ViewBag.Message = "Please select the excel file with .xls or .xlsx extension";
                        return View();
                    }

                    string folderPath = Server.MapPath("~/UploadedFiles/");
                    //Check Directory exists else create one
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    //Save file to folder
                    var filePath = folderPath + Path.GetFileName(postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    //Get file extension

                    string excelConString = "";

                    //Get connection string using extension 
                    switch (fileExtension)
                    {
                        //If uploaded file is Excel 1997-2007.
                        case ".xls":
                            excelConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";
                            break;
                        //If uploaded file is Excel 2007 and above
                        case ".xlsx":
                            excelConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";
                            break;
                    }

                    //Read data from first sheet of excel into datatable
                    DataTable dt = new DataTable();
                    excelConString = string.Format(excelConString, filePath);

                    using (OleDbConnection excelOledbConnection = new OleDbConnection(excelConString))
                    {
                        using (OleDbCommand excelDbCommand = new OleDbCommand())
                        {
                            using (OleDbDataAdapter excelDataAdapter = new OleDbDataAdapter())
                            {
                                excelDbCommand.Connection = excelOledbConnection;

                                excelOledbConnection.Open();
                                //Get schema from excel sheet
                                DataTable excelSchema = GetSchemaFromExcel(excelOledbConnection);
                                //Get sheet name
                                string sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();
                                excelOledbConnection.Close();

                                //Read Data from First Sheet.
                                excelOledbConnection.Open();
                                excelDbCommand.CommandText = "SELECT * From [" + sheetName + "]";
                                excelDataAdapter.SelectCommand = excelDbCommand;
                                //Fill datatable from adapter
                                excelDataAdapter.Fill(dt);
                                excelOledbConnection.Close();
                            }
                        }
                    }

                    //Insert records to Employee table.

                 
                    //Loop through datatable and add employee data to employee table. 
                    specialId = specialId++;
                    foreach (DataRow row in dt.Rows)
                    {
                        db.Pharmacy.Add(GetInfoFromExcelRow(row));
                    }

                    db.SaveChanges();
                    AddToFinalTable();
                    ViewBag.Message = "Data Imported Successfully.";

                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                }
            }
            else
            {
                ViewBag.Message = "Please select the file first to upload.";
            }
            return View();
        }

        private static DataTable GetSchemaFromExcel(OleDbConnection excelOledbConnection)
        {
            return excelOledbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        }

        //Convert each datarow into Pharmacy object
        //Which is then passed into the database 
        private Pharmacy GetInfoFromExcelRow(DataRow row)
        {


            return new Pharmacy
            {

                MemberId = row.ItemArray[0] == DBNull.Value ? -1 : Convert.ToDouble(row.ItemArray[0]),
                MemberLastName = row[1].ToString(),
                MemberFirstName = row[2].ToString(),
                MemberMiddleInitial = row[3].ToString(),
                DateofBirth = row.ItemArray[4] == DBNull.Value ? -1 : Convert.ToDouble(row.ItemArray[4]),
                Gender = row[5].ToString(),
                FillDate = row.ItemArray[6] == DBNull.Value ? -1 : Convert.ToDouble(row.ItemArray[6]),
                ClaimStatus = row[7].ToString(),
                ClaimNumber = row[8].ToString(),
                OriginalClaimNumber = row[9].ToString(),
                PerscriptionNumber = row.ItemArray[10] == DBNull.Value ? -1 : Convert.ToDouble(row.ItemArray[10]),
                NDCCode = row.ItemArray[11] == DBNull.Value ? -1 : Convert.ToDouble(row.ItemArray[11]),
                DrugName = row[12].ToString(),
                OTCIndicator = row[13].ToString(),
                Multisource = row.ItemArray[14] == DBNull.Value ? -1 : Convert.ToDouble(row.ItemArray[14]),
                DEASchedule = row.ItemArray[15] == DBNull.Value ? -1 : Convert.ToDouble(row.ItemArray[15]),
                DiagnosisCode = row[16].ToString(),
                DWAIndecator = row.ItemArray[17] == DBNull.Value ? -1 : Convert.ToDouble(row.ItemArray[17]),
                DaysSupply = row.ItemArray[18] == DBNull.Value ? -1 : Convert.ToDouble(row.ItemArray[18]),
                BilledAmount = row.ItemArray[19] == DBNull.Value ? -1 : Convert.ToDouble(row.ItemArray[19]),
                PharmacyProviderID = row[20].ToString(),
                PrescribingProviderID = row.ItemArray[21] == DBNull.Value ? -1 : Convert.ToDouble(row.ItemArray[21]),
                RefillCode = row.ItemArray[22] == DBNull.Value ? -1 : Convert.ToDouble(row.ItemArray[22]),
                blankSpace = row.ItemArray[23] == DBNull.Value ? -1 : Convert.ToDouble(row.ItemArray[23]),
                NCPDPrejectcodes = row[24].ToString(),
                NPI = row.ItemArray[25] == DBNull.Value ? -1 : Convert.ToDouble(row.ItemArray[25]),
                Last_Name = row[26].ToString(),
                First_Name = row[27].ToString(),
                Address = row[28].ToString(),
                City = row[29].ToString(),
                State = row[30].ToString(),
                Zip_Code = row[31].ToString(),
                DateAdded = specialId.ToString(),
            };

        }
        public ActionResult Edit()
        {
            return View(); 
        }
        public void AddToFinalTable()
        {
            var today = DateTime.Now.ToString();
            var currentUser = User.Identity.GetUserId();
            db.PharmacyDbs.Add(new PharmacyDb
            {
                DateEntered = today,
                ApplicationId = currentUser
            });
            db.SaveChanges();
            RedirectToAction("index");
        }
           
    }
}