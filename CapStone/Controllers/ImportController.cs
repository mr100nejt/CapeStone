
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
          for(int i =0; i < row.ItemArray.Length; i++)
            {
                if(row.ItemArray[i] == DBNull.Value)
                {
                    row.ItemArray[i] = -1; 
                }
            }
            var memberId = Convert.ToInt32(row[0]);
            var memberLastName = row[1].ToString();
            var memberFirstName = row[2].ToString();
            var memberMiddleInitial = row[3].ToString();
            var dateofBirth = Convert.ToInt32(row[4]);
            var gender = row[5].ToString();
            var fillDate = Convert.ToInt32(row[6]);
            var claimStatus = row[7].ToString();
            var claimNumber = row[8].ToString();
            var originalClaimNumber =  Convert.ToInt32(row[9]);
            var perscriptionNumber = Convert.ToInt32(row[10]);
            var ndcCode = Convert.ToInt32(row[11]);
            var drugName = row[12].ToString();
            var oTCIndicator = row[13].ToString();
            var multisource = Convert.ToInt32(row[14]);
            var dEASchedule = Convert.ToInt32(row[15]);
            var diagnosisCode = row[16].ToString();
            var dWAIndecator = Convert.ToInt32(row[17]);
            var daysSupply = Convert.ToInt32(row[18]);
            var billedAmount = Convert.ToInt32(row[19]);
            var pharmacyProviderID = Convert.ToInt32(row[20]);
            var prescribingProviderID = Convert.ToInt32(row[21]);
            var refillCode = Convert.ToInt32(row[22]);
            var nCPDPrejectcodes = Convert.ToInt32(row[23]);
            var nPI = Convert.ToInt32(row[24]);
            var last_Name = row[25].ToString();
            var first_Name = row[26].ToString();
            var address = row[27].ToString();
            var city = row[28].ToString();
            var state = Convert.ToInt32(row[29]);
            var zip_Code = Convert.ToInt32(row[30]);
            
           
            return new Pharmacy
            {
                MemberId = memberId,
                MemberLastName = memberLastName,
                MemberFirstName = memberFirstName,
                MemberMiddleInitial = memberMiddleInitial,
                DateofBirth = dateofBirth,
                Gender = gender,
                FillDate = fillDate,
                ClaimStatus = claimStatus,
                ClaimNumber = claimNumber,
                OriginalClaimNumber = originalClaimNumber,
                PerscriptionNumber = perscriptionNumber,
                NDCCode = ndcCode,
                DrugName = drugName,
                OTCIndicator = oTCIndicator,
                Multisource = multisource,
                DEASchedule = dEASchedule,
                DiagnosisCode = diagnosisCode,
                DWAIndecator = dWAIndecator,
                DaysSupply = daysSupply,
                BilledAmount = billedAmount,
                PharmacyProviderID = pharmacyProviderID,
                PrescribingProviderID = prescribingProviderID,
                RefillCode = refillCode,
                NCPDPrejectcodes = nCPDPrejectcodes,
                NPI = nPI,
                Last_Name = last_Name,
                First_Name = first_Name,
                Address = address,
                City = city,
                State = state,
                Zip_Code = zip_Code,
            };
            
        }
    }
}