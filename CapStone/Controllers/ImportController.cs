
using CapStone.Models;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace AspDotNetMVCDemo.Controllers
{
    public class ImportController : Controller
    {
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
            ApplicationDbContext db = new ApplicationDbContext(); 
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
                        foreach (DataRow row in dt.Rows)
                        {
                        


                        
                     
                            db.Pharmacy.Add(GetEmployeeFromExcelRow(row));
                        }
                        db.SaveChanges();
                    
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

        //Convert each datarow into employee object
        private Pharmacy GetEmployeeFromExcelRow(DataRow row)
        {
            for (int i = 0; i < 0; i++)
            {
                if (row[i].GetType() != typeof(string))//need it to hit this if statement first
                {
                    if (row[i].GetType() != typeof(int))
                    {
                        row[i] = null;
                    }

                }
            }
            return new Pharmacy
            {
                MemberId = Convert.ToInt32(row[0]),
                MemberLastName = row[1].ToString(),
                MemberFirstName = row[2].ToString(),
                MemberMiddleInitial = row[3].ToString(),
                DateofBirth = Convert.ToInt32(row[4]),
                Gender = row[5].ToString(),
                FillDate = Convert.ToInt32(row[6]),
                ClaimStatus = row[7].ToString(),
                ClaimNumber = row[8].ToString(),
                OriginalClaimNumber = Convert.ToInt32(row[9]),
                PerscriptionNumber = Convert.ToInt32(row[10]),
                NDCCode = Convert.ToInt32(row[11]),
                DrugName = row[12].ToString(),
                OTCIndicator = row[13].ToString(),
                Multisource = Convert.ToInt32(row[14]),
                DEASchedule = Convert.ToInt32(row[15]),
                DiagnosisCode = row[16].ToString(),
                DWAIndecator = Convert.ToInt32(row[17]),
                DaysSupply = Convert.ToInt32(row[18]),
                BilledAmount = Convert.ToInt32(row[19]),
                PharmacyProviderID = Convert.ToInt32(row[20]),
                PrescribingProviderID = Convert.ToInt32(row[21]),
                RefillCode = Convert.ToInt32(row[22]),
                NCPDPrejectcodes = Convert.ToInt32(row[23]),
                NPI = Convert.ToInt32(row[24]),
                Last_Name = row[25].ToString(),
                First_Name = row[26].ToString(),
                Address = row[27].ToString(),
                City = row[28].ToString(),
                State = Convert.ToInt32(row[29]),
                Zip_Code = Convert.ToInt32(row[30]),
            };
            
        }
    }
}