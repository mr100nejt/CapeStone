using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using Syncfusion.XlsIO;

namespace CapStone.Models
{
    public class BlankWorkSheet
    {
        ExcelEngine excelEngine = new ExcelEngine();
       public void MakeDoc()
        {
            String strExcelConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";

           

            OleDbConnection connExcel = new OleDbConnection(strExcelConn);

            OleDbCommand cmdExcel = new OleDbCommand();

            cmdExcel.Connection = connExcel;
            connExcel.Open();

            DataTable dtExcelSchema;

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            connExcel.Close();
        }
        
    }
}