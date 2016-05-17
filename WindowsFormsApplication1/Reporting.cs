using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
//using MySql.Data.MySqlClient;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;



namespace WindowsFormsApplication1
{
    public partial class Reporting : Form
    {
        public Reporting()
        {
            
            InitializeComponent();
        }

        BindingSource bs = new BindingSource();
        public DataTable GetDataTable(
         ref System.Data.SqlClient.SqlConnection _nSqlConnection, string _nSQL)
        {

            // New SQL connection to a command object
            SqlCommand _nSqlCommand = new SqlCommand(_nSQL, _nSqlConnection);
            SqlDataAdapter _nSqlDataAdapter = new SqlDataAdapter();
            _nSqlDataAdapter.SelectCommand = _nSqlCommand;

            DataTable _DataTable = new DataTable();
            _DataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            DataSet ovrRpt = new DataSet();
            ovrRpt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            // Pass the connection to a command object
            //MySql.Data.MySqlClient.MySqlCommand _SqlCommand =
            //                new MySql.Data.MySqlClient.MySqlCommand(_SQL, _SqlConnection);
            //MySql.Data.MySqlClient.MySqlDataAdapter _SqlDataAdapter
            //                = new MySql.Data.MySqlClient.MySqlDataAdapter();
            //_SqlDataAdapter.SelectCommand = _SqlCommand;

            //DataTable _DataTable = new DataTable();
            //_DataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            //DataSet ovrRpt = new DataSet();
            //ovrRpt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            // Adds or refreshes rows in the DataSet to match those in the data source
            try
            {
                _nSqlDataAdapter.Fill(_DataTable);
                _nSqlDataAdapter.Fill(ovrRpt);
            }
            catch (Exception _Exception)
            {
                // Error occurred while trying to execute reader
                // send error message to console (change below line to customize error handling)
                // Console.WriteLine(_Exception.Message);
                //MessageBox(_Exception);
                return null;
            }

            return _DataTable;
            
        }

        //new DataSet code
        public DataSet GetDataSet(
        ref System.Data.SqlClient.SqlConnection _nSqlConnection, string _nSQL)
        {

            SqlCommand _nSqlCommand = new SqlCommand(_nSQL, _nSqlConnection);
            SqlDataAdapter _nSqlDataAdapter = new SqlDataAdapter();
            _nSqlDataAdapter.SelectCommand = _nSqlCommand;
            DataTable _nDataTable = new DataTable();
            _nDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            // Pass the connection to a command object
            //MySql.Data.MySqlClient.MySqlCommand _SqlCommand =
            //                new MySql.Data.MySqlClient.MySqlCommand(_SQL, _SqlConnection);
            //MySql.Data.MySqlClient.MySqlDataAdapter _SqlDataAdapter
            //                = new MySql.Data.MySqlClient.MySqlDataAdapter();
            //_SqlDataAdapter.SelectCommand = _SqlCommand;

            //DataTable _DataTable = new DataTable();
            //_DataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
            DataSet ovrRpt = new DataSet();
            ovrRpt.Locale = System.Globalization.CultureInfo.InvariantCulture;
            // Adds or refreshes rows in the DataSet to match those in the data source
            try
            {
                //_SqlDataAdapter.Fill(_DataTable);
                _nSqlDataAdapter.Fill(ovrRpt);
            }
            catch (Exception _Exception)
            {
                // Error occurred while trying to execute reader
                // send error message to console (change below line to customize error handling)
                // Console.WriteLine(_Exception.Message);
                //MessageBox(_Exception);
                return null;
            }

            return ovrRpt;

        }

        //End Dataser Code
        

        private void Reporting_Load(object sender, EventArgs e)
        {
            List<DataRow> pjstaffRowsRemove = new List<DataRow>();
            List<DataColumn> pjstaffColRemove = new List<DataColumn>();
            List<DataRow> jnameRowsRemove = new List<DataRow>();
            List<DataRow> compRowsRemove = new List<DataRow>();
            //List<DataRow> extraRowsRemove = new List<DataRow>();
                        
            List<Object> objRemove = new List<object>();
           
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            SqlConnection MySqlConn = new SqlConnection(connectionString);

            try
            {


                //**************************************THis command populates projectstaff combo box with estimators 
                string commandString102 = ("SELECT ALL psname FROM projectstaff");
                //estimator, salesperson, projectmgr, projectasst
                SqlCommand mysqlcommand102 = new SqlCommand(commandString102, MySqlConn);

                DataTable table102 = GetDataTable(
                    // Pass open database connection to function
            ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
            commandString102);
                


                foreach (DataRow row in table102.Rows)
                {
                    if (row["psname"].ToString() == " " || row["psname"].ToString() == "None" || row["psname"].ToString() == "" || row["psname"].ToString() == "UnAssigned")
                    {
                        pjstaffRowsRemove.Add(row);
                    }
                    else
                    {
                        String item = (row["psname"].ToString());
                        cboindcomm.Items.Add(item);                       
                        row.Delete();

                    }
                }


                String commandString222 = ("SELECT ALL company_name FROM company");
                SqlCommand mysqlcommand222 = new SqlCommand(commandString222, MySqlConn);

                DataTable table222 = GetDataTable(
                    // Pass open database connection to function
            ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
            commandString222);

                foreach (DataRow row2 in table222.Rows)
                {
                    if (row2["company_name"].ToString() == " ")
                    {
                        compRowsRemove.Add(row2);
                    }
                    else
                    {
                        String item = (row2["company_name"].ToString());
                        cboJRCBut.Items.Add(item);
                        row2.Delete();    

                    }
                }



            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        

        //Overall Commission Report
        private void ovalcomrsubmt_Click(object sender, EventArgs e)
        {
            //Test1 Rpt;
            //MySqlDataAdapter adap;
            //DataSet ovrRpt;
           
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            SqlConnection MySqlConn = new SqlConnection(connectionString);
            MySqlConn.Open();
            
            //Start Conversion
            String Startdate = ovalcomrStartDt.Text.Trim();
            DateTime newStartDate = DateTime.Parse(Startdate);
            ovalcomrStartDt.Text = newStartDate.ToString("MM/dd/yyyy");

            String Startdate2 = ovalcomrStartDt.Text.Trim();
            DateTime EndStartDate = DateTime.ParseExact(Startdate2, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
            ovalcomrStartDt.Text = EndStartDate.ToString("yyyy-MM-dd");


            //End Date Conversion
            String EndDate = ovalcomrEndDt.Text.Trim();
            DateTime newEndDate = DateTime.Parse(EndDate);
            ovalcomrEndDt.Text = newEndDate.ToString("MM/dd/yyyy");

            String EndDate2 = ovalcomrEndDt.Text.Trim();
            DateTime NewEndDate2 = DateTime.ParseExact(EndDate2, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
            ovalcomrEndDt.Text = NewEndDate2.ToString("yyyy-MM-dd");



            //I removed billing.est_gp, billing.payact_gp, because I was not sure which one to use. Currently using billing.payest_gp
            //Darren check on mapping of company name when testing a real run
           // string commandString100 = ("SELECT billing.paid_date, billing.paid_amt, billing.billing_date, billing.billing_amt, billing.cid, billing.jid, billing.pid, billing.chkd_actcost, billing.payest_gp, billing.payact_gp, billing.estimator, billing.estimator_percent, billing.estimator_comm, billing.salesperson, billing.salesperson_percent, billing.salesperson_comm, billing.projectmgr, billing.projectmgr_percent, billing.projectmgr_comm, billing.projectasst, billing.projectasst_percent, billing.projectasst_comm, company.company_name, job.job_name, projects.project_number, projects.project_name FROM (billing LEFT JOIN company on billing.cid = company.cid) LEFT JOIN job ON billing.jid = job.jid LEFT JOIN projects ON billing.pid = projects.pid WHERE billing.paid_date >= '" + ovalcomrStartDt.Text.Trim() + "' AND billing.paid_date <= '" + ovalcomrEndDt.Text.Trim() + "'");            
        //    MySqlCommand mysqlcommand100 = new MySqlCommand(commandString100, MySqlConn);


        //    DataTable table100 = GetDataTable(
        //        // Pass open database connection to function
        //ref MySqlConn,
        //        // Pass SQL statement to create SqlDataReader
        //commandString100);


            
            SqlDataAdapter adap = new SqlDataAdapter("SELECT billing.paid_date, billing.paid_amt, billing.billing_date, billing.billing_amt, billing.cid, billing.jid, billing.pid, billing.chkd_actcost, billing.payest_gp, billing.payact_gp, billing.estimator, billing.estimator_percent, billing.estimator_comm, billing.salesperson, billing.salesperson_percent, billing.salesperson_comm, billing.projectmgr, billing.projectmgr_percent, billing.projectmgr_comm, billing.projectasst, billing.projectasst_percent, billing.projectasst_comm, company.company_name, job.job_name, projects.project_number, projects.project_name FROM (billing LEFT JOIN company on billing.cid = company.cid) LEFT JOIN job ON billing.jid = job.jid LEFT JOIN projects ON billing.pid = projects.pid WHERE billing.paid_date >= '" + ovalcomrStartDt.Text.Trim() + "' AND billing.paid_date <= '" + ovalcomrEndDt.Text.Trim() + "'", MySqlConn);
            DataSet dsOvrRpt = new DataSet("DataTable1");
            adap.Fill(dsOvrRpt, "DataTable1");
            MySqlConn.Close();

            //foreach (DataRow datarow in dsOvrRpt.Tables)
            //{

            //    datarow[0] = dsOvrRpt.Tables[0];//(datarow[1].ToString());
            //    datarow[1] = dsOvrRpt.Tables[1];
            //    datarow[2] = dsOvrRpt.Tables[2];
            //    datarow[3] = dsOvrRpt.Tables[3];

            //}


            //ReportDocument report = new ReportDocument();
            var path = ("C:\\Users\\Darren\\Documents\\Visual Studio 2010\\Projects\\CommissionDBApplication\\WindowsFormsApplication1\\Test1.rpt");
           // report.Load(path);
            //ReportDocument Rpt = new ReportDocument();
            Test1 Rpt = new Test1();
            Rpt.Load(path);
           
            Rpt.SetDataSource(dsOvrRpt.Tables[0]);
            //DataRow r;
            //int i = 0;

            //for (i = 0; i <= 100; i++)
            //{
            //    //r = dsOvrRpt.
            //  Rpt.FieldMapping  ["paid_date"] = dsOvrRpt.Tables[0];
            //}
            
            crystalReportViewer1.ReportSource = Rpt;


            String dte = DateTime.Now.ToString();
            String r = dte.Replace("/", "_");
            String u = r.Remove(9);
           
            String date = u.ToString();
            String month = date;
            //Export SEction
            ExportOptions RepExportOptions;
            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
            if (month[0].ToString() == "1")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\January\\OverallReport '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "2")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\February\\OverallReport '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "3")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\March\\OverallReport '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "4")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\April\\OverallReport '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "5")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\May\\OverallReport '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "6")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\June\\OverallReport '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "7")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\July\\OverallReport '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "8")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\August\\OverallReport '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "9")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\September\\OverallReport '" + date + "'.pdf";
            }
            else if (month[1].ToString() == "0")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\October\\OverallReport '" + date + "'.pdf";
            }
            else if (month[1].ToString() == "1")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\November\\OverallReport '" + date + "'.pdf";
            }
            else if (month[1].ToString() == "2")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\December\\OverallReport '" + date + "'.pdf";
            }
            //CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\OverallReport '" + date + "'.pdf";// + DateTime.Now; //"c:\\csharp.net-informations.pdf";
            RepExportOptions = Rpt.ExportOptions;
            RepExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            RepExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            RepExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
            RepExportOptions.FormatOptions = CrFormatTypeOptions;
            Rpt.Export();
            // Rpt.Load();
            //'" + txtcname.Text.Trim() + "'
            //CrystalDecisions.ReportSource. = Rpt;
                
                
                
                
            //adap.SelectCommand = mysqlcommand100;
            
            //MySqlConn.Open();
            //MySqlConn.Close();
            //adap.Fill(ovrRpt);
            //DataSet ovrRpt = GetDataSet(ref MySqlConn, commandString100);

            //adap = new MySqlDataAdapter(mysqlcommand100);
            //DataSet ovrRpt = new DataSet();
            //adap.Fill(ovrRpt);

        //    DataTable table100 = GetDataTable(
        //        // Pass open database connection to function
        //ref MySqlConn,
        //        // Pass SQL statement to create SqlDataReader
        //commandString100);

            

            //Darren loop over DataRow!!!!!


            //foreach (DataRow row2 in table100.Rows)
            //{
            //    string z = row2["paid_date"].ToString();
            //    z = z.Replace("12:00:00 AM", "");
           // }

            


            //Converts startdate back to user format
            String sdate = ovalcomrStartDt.Text;
            DateTime sd = DateTime.Parse(sdate);
            ovalcomrStartDt.Text = sd.ToString("MM/dd/yyyy");

            //Converts enddate back to user format
            String edate = ovalcomrEndDt.Text;
            DateTime ed = DateTime.Parse(edate);
            ovalcomrEndDt.Text = ed.ToString("MM/dd/yyyy");
      

            //adap = new MySqlDataAdapter(commandString100, connectionString);
            
            //adap.SelectCommand = mysqlcommand100;
           // DataSet ovrRpt = new DataSet();
             
            ////ovrRpt.Clear();
            //adap.Fill(ovrRpt);
            
            //Test1 Rpt = new Test1();
            //Rpt.SetDataSource(ovrRpt);
            
            //Rpt.Refresh();
            



            //Excel code Start here***************************************************************************************************

        //    Excel.Application x1APP;
        //    Excel.Workbook x1Workbook;
        //    Excel.Worksheet x1Worksheet;
        //    object misValue = System.Reflection.Missing.Value;
        //    Excel.Range chartRange;
        //    int previousRow = 0;
        //    //Excel.Range chartRange2 = x1Worksheet.Cells["C9: C17"];
        //    x1APP = new Excel.Application();
        //    x1APP.Visible = true;
        //    x1Workbook = x1APP.Workbooks.Add(misValue);

        //    x1Worksheet = (Excel.Worksheet)x1Workbook.Worksheets.get_Item(1);
        //    //this is the new code to make the report fit to one page
        //    x1Worksheet.PageSetup.Zoom = false;
        //    x1Worksheet.PageSetup.TopMargin = 0.75;
        //    x1Worksheet.PageSetup.LeftMargin = 0.15;
        //    x1Worksheet.PageSetup.HeaderMargin = 0.3;
        //    x1Worksheet.PageSetup.BottomMargin = 0.75;
        //    x1Worksheet.PageSetup.RightMargin = 0.15;
        //    x1Worksheet.PageSetup.FooterMargin = 0.3;
        //    chartRange = x1APP.get_Range("B9:W200");
        //    chartRange.Font.Size = 12;
        //    //x1Worksheet.PageSetup.FitToPagesWide = 1;
        //    //x1Worksheet.PageSetup.FitToPagesTall = 1;
        //    //x1Worksheet.PageSetup.
        //    //x1Worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
        //    //x1Worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;

            

        //    int b = 9;
             
        //    foreach (DataRow row in table100.Rows)
        //    {
        //        String u = (row[0].ToString());
        //        String xc = u.Replace("12:00:00 AM", "");
        //        x1Worksheet.Cells[b, 2] = xc;//(row[0].ToString());                
        //        x1Worksheet.Cells[b, 3] = (row[1].ToString());
        //        String re = (row[2].ToString());
        //        String xd = re.Replace("12:00:00 AM", "");
        //        x1Worksheet.Cells[b, 4] = xd;//(row[2].ToString());
        //        x1Worksheet.Cells[b, 5] = (row[3].ToString());
        //        x1Worksheet.Cells[b, 6] = (row[4].ToString());
        //        x1Worksheet.Cells[b, 7] = (row[23].ToString());
        //        x1Worksheet.Cells[b, 8] = (row[25].ToString());
        //        x1Worksheet.Cells[b, 9] = (row[24].ToString());
        //        string diff = (row[7].ToString());
        //        if (diff == "T")
        //        {
        //            x1Worksheet.Cells[b, 10] = "Actual Cost";
        //            x1Worksheet.Cells[b, 11] = (row[9].ToString());
        //        }
        //        else
        //        {
        //            x1Worksheet.Cells[b, 10] = "Estimated Cost";
        //            x1Worksheet.Cells[b, 11] = (row[8].ToString());
        //        }
        //        //x1Worksheet.Cells[b, 10] = (row[8].ToString());
        //        x1Worksheet.Cells[b, 12] = (row[10].ToString());
        //        x1Worksheet.Cells[b, 13] = (row[11].ToString() + "%");
        //        x1Worksheet.Cells[b, 14] = (row[12].ToString());
        //        x1Worksheet.Cells[b, 15] = (row[13].ToString());
        //        x1Worksheet.Cells[b, 16] = (row[14].ToString() + "%");
        //        x1Worksheet.Cells[b, 17] = (row[15].ToString());
        //        x1Worksheet.Cells[b, 18] = (row[16].ToString());
        //        x1Worksheet.Cells[b, 19] = (row[17].ToString() + "%");
        //        x1Worksheet.Cells[b, 20] = (row[18].ToString());
        //        x1Worksheet.Cells[b, 21] = (row[19].ToString());
        //        x1Worksheet.Cells[b, 22] = (row[20].ToString() + "%");
        //        x1Worksheet.Cells[b, 23] = (row[21].ToString());
        //        b++;

        //    }



        //    chartRange = x1Worksheet.Cells[2, 7];
        //    //chartRange.EntireColumn.WrapText = true;
        //    chartRange.Font.Bold = true;
        //    x1Worksheet.Cells[2, 7] = " Total Payments: ";            
        //    x1Worksheet.Cells[2, 8] = "=sum(C9:C200)";
        //    chartRange = x1Worksheet.Cells[3, 7];
        //    //chartRange.EntireColumn.WrapText = true;
        //    chartRange.Font.Bold = true;
        //    x1Worksheet.Cells[3, 7] = "Total Gross Profit: ";            
        //    x1Worksheet.Cells[3, 8] = "=sum(K9:K200)";
        //    chartRange = x1Worksheet.Cells[4, 7];
        //    //chartRange.EntireColumn.WrapText = true;
        //    chartRange.Font.Bold = true;
        //    x1Worksheet.Cells[4, 7] = "Average Commission Percentage: ";            
        //    x1Worksheet.Cells[4, 8] = "=average(M9:M200)";
        //    chartRange = x1Worksheet.Cells[2, 9];
        //    //chartRange.EntireColumn.WrapText = true;
        //    chartRange.Font.Bold = true;
        //    x1Worksheet.Cells[2, 9] = "Total Estimator Commission: ";            
        //    x1Worksheet.Cells[2, 10] = "=sum(N9:N200)";
        //    chartRange = x1Worksheet.Cells[3, 9];
        //    chartRange.Font.Bold = true;
        //    x1Worksheet.Cells[3, 9] = "Average Commission Percentage: ";            
        //    x1Worksheet.Cells[3, 10] = "=average(P9:P200)";
        //    chartRange = x1Worksheet.Cells[4, 9];
        //    //chartRange.EntireColumn.WrapText = true;
        //    chartRange.Font.Bold = true;
        //    x1Worksheet.Cells[4, 9] = "Total Sales Commission: ";            
        //    x1Worksheet.Cells[4, 10] = "=sum(Q9:Q200)";
        //    chartRange = x1Worksheet.Cells[2, 11];
        //    //chartRange.EntireColumn.WrapText = true;
        //    chartRange.Font.Bold = true;
        //    x1Worksheet.Cells[2, 11] = "Average Commission Percentage: ";            
        //    x1Worksheet.Cells[2, 12] = "=average(S9:S200)";
        //    chartRange = x1Worksheet.Cells[3, 11];
        //    //chartRange.EntireColumn.WrapText = true;
        //    chartRange.Font.Bold = true;
        //    x1Worksheet.Cells[3, 11] = "Total PM Commission: ";
        //    x1Worksheet.Cells[3, 12] = "=sum(T9:T200)";
        //    chartRange = x1Worksheet.Cells[4, 11];
        //    //chartRange.EntireColumn.WrapText = true;
        //    chartRange.Font.Bold = true;
        //    x1Worksheet.Cells[4, 11] = "Average Commission Percentage: ";
        //    x1Worksheet.Cells[4, 12] = "=average(V9:V200)";
        //    chartRange = x1Worksheet.Cells[2, 13];
        //    //chartRange.EntireColumn.WrapText = true;
        //    chartRange.Font.Bold = true;
        //    x1Worksheet.Cells[2, 13] = "Total PA Commission : ";
        //    x1Worksheet.Cells[2, 14] = "=sum(W9:W100)";





            



        //    //x1Worksheet.Cells[d, 3].Formula = "=sum(C9:C)"; //1 Total Payments

        //    //x1Worksheet.Cells[d, 11].Formula = "=sum(K:K)"; //2 Total Gorss Profit
        //    //x1Worksheet.Cells[d, 13].Formula = "=average(M:M)"; //3 Average Commission Percentage
        //    //x1Worksheet.Cells[d, 14].Formula = "=sum(N:N)"; //4 Total Estimator Commission 
        //    //x1Worksheet.Cells[d, 16].Formula = "=average(P:P)"; //5 Average Commission Percentage
        //    //x1Worksheet.Cells[d, 17].Formula = "=sum(Q:Q)"; //6 Total Sales Commission
        //    //x1Worksheet.Cells[d, 19].Formula = "=average(S:S)"; //7 Average Commission Percentage
        //    //x1Worksheet.Cells[d, 20].Formula = "=sum(T:T)"; //8 Total PM Commission
        //    //x1Worksheet.Cells[d, 22].Formula = "=average(V:V)"; //9 Average Commission Percentage

        //    //x1Worksheet.Cells[d, 23].Formula = "=sum(W:W)"; //10 Total PA Commission


        //    x1Worksheet.Cells[4, 2] = " Date Generated: ";
        //    x1Worksheet.Cells[4, 3] = DateTime.Now;

        //    x1Worksheet.Cells[5, 2] = " Dates Covered:  ";
        //    x1Worksheet.Cells[5, 3] = ovalcomrStartDt.Text.Trim() + "-" + ovalcomrEndDt.Text.Trim();

        //    x1Worksheet.Cells[8, 2] = " Payment Date    ";
        //    //Payment Date
        //    chartRange = x1Worksheet.get_Range("b8", "b8");
        //    //chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Size = 10;
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 3] = " Payment Amount  ";
        //    //Payment Amount
        //    chartRange = x1Worksheet.get_Range("c8", "c8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Size = 10;
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 4] = " Invoice Date    ";
        //    //Billing Date
        //    chartRange = x1Worksheet.get_Range("d8", "d8");
        //    chartRange.Font.FontStyle = "m/dd/yyyy";
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Size = 10;
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 5] = " Invoice Amount  ";
        //    //Billling Amount
        //    chartRange = x1Worksheet.get_Range("e8", "e8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Size = 10;
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 6] = " Company Name  ";
        //    //Company Name
        //    chartRange = x1Worksheet.get_Range("f8", "f8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Size = 10;
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 7] = " Job Name        ";
        //    //Job Name
        //    chartRange = x1Worksheet.get_Range("g8", "g8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Size = 10;
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 8] = " Project Name        ";
        //    //Project Name
        //    chartRange = x1Worksheet.get_Range("h8", "h8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Size = 10;
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 9] = " Project NUmber         ";
        //    //Project Number
        //    chartRange = x1Worksheet.get_Range("i8", "i8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Size = 10;
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 10] = " Estimated or Actual      ";
        //    //Estimated Or Actual
        //    chartRange = x1Worksheet.get_Range("j8", "j8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 11] = " Gross Profit    ";
        //    //Gross Profit if on actual actual gp is used if on estimated estimated gp is used
        //    chartRange = x1Worksheet.get_Range("k8", "k8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 12] = " Estimator       ";
        //    //Estimator
        //    chartRange = x1Worksheet.get_Range("l8", "l8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 13] = " Estimator Commission Percentage   ";
        //    //Estimator Percent
        //    chartRange = x1Worksheet.get_Range("m8", "m8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 14] = " Estimator Commission    ";
        //    //Estimator Commission 
        //    chartRange = x1Worksheet.get_Range("n8", "n8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 15] = " Salesperson     ";
        //    //Salesperson
        //    chartRange = x1Worksheet.get_Range("o8", "o8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 16] = " Salesperson Commission Percentage ";
        //    //Salesperson Percent
        //    chartRange = x1Worksheet.get_Range("p8", "p8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 17] = " Salesperson Commission  ";
        //    //Salesperson Commission
        //    chartRange = x1Worksheet.get_Range("q8", "q8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 18] = " Project Manager ";
        //    //Project Manager
        //    chartRange = x1Worksheet.get_Range("r8", "r8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 19] = " PM Commission Percentage          ";
        //    //PM Percent
        //    chartRange = x1Worksheet.get_Range("s8", "s8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 20] = " PM Commission   ";
        //    //PM Commission
        //    chartRange = x1Worksheet.get_Range("t8", "t8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 21] = " Project Assistant        ";
        //    //Project Assistant
        //    chartRange = x1Worksheet.get_Range("u8", "u8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 22] = " PA Commission Percentage          ";
        //    //PA Percent
        //    chartRange = x1Worksheet.get_Range("v8", "v8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    x1Worksheet.Cells[8, 23] = " PA Commission   ";
        //    //PA Commission
        //    chartRange = x1Worksheet.get_Range("w8", "w8");
        //    chartRange.EntireColumn.WrapText = true;
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;


           

            

        //    //This sets the layout and font for COLUMN HEADERS******************************************************************************

        //    //Report Header%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        //    x1Worksheet.get_Range("b2", "e3").Merge(false);

        //    chartRange = x1Worksheet.get_Range("b2", "e3");
        //    chartRange.FormulaR1C1 = "COMMISSION REPORT OVERALL";
        //    chartRange.Font.Bold = true;
        //    chartRange.Interior.Color = System.Drawing.Color.LightGray; 
        //    //chartRa = System.Drawing.Color.LightGray;            
        //    chartRange.HorizontalAlignment = 6;
        //    chartRange.VerticalAlignment = 3;            
        //    //Dates Generated 
        //    chartRange = x1Worksheet.get_Range("b4", "b4");
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;
        //    //Dates Covered
        //    chartRange = x1Worksheet.get_Range("b5", "b5");
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

            
        //    //chartRange = x1Worksheet.get_Range("b9", "w200");
            
            
        //    //foreach (Excel.Range row in chartRange.Rows)
        //    //{

        //    //    chartRange = x1Worksheet.Rows;
        //    //    int rt = row[9];
        //    //    chartRange.Interior.Color = System.Drawing.Color.LightGray;
        //    //    rt++;
        //    //    rt++;

        //    //}
        //    //chartRange = "=mod(row(),2)=1";
        //   // chartRange.Interior.Color = System.Drawing.Color.LightGray; 
        //   // chartRange = "=mod(row(),2)=0";
           
        //    //chartRange = x1Worksheet.get_Range("b2", "x35");
        //    //chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            
        //    //PageSetup.Zoom = false;
        //    //PageSetup.FitToPagesWide = 1;
        //    //PageSetup.FitToPagesTall = 1;
        //    //PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlLandscape;
        //    //PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
        //    releaseObject(x1Worksheet);
        //    releaseObject(x1Workbook);
        //    releaseObject(x1APP);

        //    MessageBox.Show("Excel file created , you can find the file !");




        }


        //invoice report
        private void invrBut_Click(object sender, EventArgs e)
        {




            object[] myArray2 = new object[15];
            DataTable table110 = new DataTable();
            table110.Columns.Add(new DataColumn("billing_date"));
            table110.Columns.Add(new DataColumn("billing_amt"));
            table110.Columns.Add(new DataColumn("cid"));
            table110.Columns.Add(new DataColumn("jid"));
            table110.Columns.Add(new DataColumn("project_name"));
            table110.Columns.Add(new DataColumn("project_number"));
            table110.Columns.Add(new DataColumn("estimator"));
            table110.Columns.Add(new DataColumn("salesperson"));
            table110.Columns.Add(new DataColumn("projectmgr"));
            table110.Columns.Add(new DataColumn("projectasst"));
            table110.Columns.Add(new DataColumn("company_name"));
            table110.Columns.Add(new DataColumn("job_name"));
            table110.Columns.Add(new DataColumn("stdate"));
            table110.Columns.Add(new DataColumn("enddate"));
            table110.Columns.Add(new DataColumn("dategen"));
            
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            SqlConnection MySqlConn = new SqlConnection(connectionString);
            MySqlConn.Open();
            

            //Date Gen
            String dateGen;
            DateTime dateNow = DateTime.Now;
            dateGen = dateNow.ToString("MM/dd/yyyy");

            //Start Conversion
            String Startdate = invrStDt.Text.Trim();
            DateTime newStartDate = DateTime.Parse(Startdate);
            invrStDt.Text = newStartDate.ToString("MM/dd/yyyy");

            
            String Startdate2 = invrStDt.Text.Trim();
            DateTime EndStartDate = DateTime.ParseExact(Startdate2, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
            invrStDt.Text = EndStartDate.ToString("yyyy-MM-dd");
            

            //End Date Conversion
            String EndDate = invrEdDt.Text.Trim();
            DateTime newEndDate = DateTime.Parse(EndDate);
            invrEdDt.Text = newEndDate.ToString("MM/dd/yyyy");

            String EndDate2 = invrEdDt.Text.Trim();
            DateTime NewEndDate2 = DateTime.ParseExact(EndDate2, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
            invrEdDt.Text = NewEndDate2.ToString("yyyy-MM-dd");


            SqlDataAdapter adap2 = new SqlDataAdapter("SELECT billing.billing_date, billing.billing_amt, billing.cid, billing.jid, billing.project_name, billing.project_number, billing.estimator, billing.salesperson, billing.projectmgr, billing.projectasst, company.company_name, job.job_name FROM (billing LEFT JOIN company on billing.cid = company.cid) LEFT JOIN job ON billing.jid = job.jid WHERE billing.billing_date >= '" + invrStDt.Text.Trim() + "' AND billing.billing_date <= '" + invrEdDt.Text.Trim() + "'", MySqlConn);
            DataSet dsInvRpt = new DataSet("DataTable2");
            adap2.Fill(dsInvRpt, "DataTable2");
            MySqlConn.Close();
            DataSet invcFill = new DataSet("DataTable2");

            foreach (DataRow nv in dsInvRpt.Tables[0].Rows)
            {
                myArray2[0] = nv.ItemArray[0];
                myArray2[1] = nv.ItemArray[1];
                myArray2[2] = nv.ItemArray[2];
                myArray2[3] = nv.ItemArray[3];
                myArray2[4] = nv.ItemArray[4];
                myArray2[5] = nv.ItemArray[5];
                myArray2[6] = nv.ItemArray[6];
                myArray2[7] = nv.ItemArray[7];
                myArray2[8] = nv.ItemArray[8];
                myArray2[9] = nv.ItemArray[9];
                myArray2[10] = nv.ItemArray[10];
                myArray2[11] = nv.ItemArray[11];
                myArray2[12] = invrStDt.Text.Trim();
                myArray2[13] = invrEdDt.Text.Trim();
                myArray2[14] = dateGen.ToString();

                DataRow bc;
                bc = table110.NewRow();
                bc.ItemArray = myArray2;
                table110.Rows.Add(bc);
                table110.AcceptChanges();
            }


            invcFill.Tables.Add(table110);
            var path2 = ("C:\\Users\\Darren\\Documents\\Visual Studio 2010\\Projects\\CommissionDBApplication\\WindowsFormsApplication1\\invoiceR.rpt");
            invoiceR Rpt2 = new invoiceR();
            Rpt2.Load(path2);

            Rpt2.SetDataSource(invcFill.Tables[0]);
            crystalReportViewer1.ReportSource = Rpt2;

            //string commandString101 = ("SELECT billing.paid_date, billing.paid_amt, billing.billing_date, billing.billing_amt, billing.cid, billing.jid, billing.pid, billing.chkd_actcost, billing.payest_gp, billing.payact_gp, billing.estimator, billing.estimator_percent, billing.estimator_comm, billing.salesperson, billing.salesperson_percent, billing.salesperson_comm, billing.projectmgr, billing.projectmgr_percent, billing.projectmgr_comm, billing.projectasst, billing.projectasst_percent, billing.projectasst_comm, company.company_name, job.job_name, projects.project_number, projects.project_name FROM (billing LEFT JOIN company on billing.cid = company.cid) LEFT JOIN job ON billing.jid = job.jid LEFT JOIN projects ON billing.pid = projects.pid WHERE billing.paid_date > '" + ovalcomrStartDt.Text.Trim() + "' AND billing.paid_date < '" + ovalcomrEndDt.Text.Trim() + "'");
        //    string commandString101 = ("SELECT billing.billing_date, billing.billing_amt, billing.cid, billing.jid, billing.project_name, billing.project_number, billing.estimator, billing.salesperson, billing.projectmgr, billing.projectasst, company.company_name, job.job_name FROM (billing LEFT JOIN company on billing.cid = company.cid) LEFT JOIN job ON billing.jid = job.jid WHERE billing.billing_date >= '" + invrStDt.Text.Trim() + "' AND billing.billing_date <= '" + invrEdDt.Text.Trim() + "'");
        //    MySqlCommand mysqlcommand101 = new MySqlCommand(commandString101, MySqlConn);

        //    DataTable table101 = GetDataTable(
        //        // Pass open database connection to function
        //ref MySqlConn,
        //        // Pass SQL statement to create SqlDataReader
        //commandString101);

            //Pdf export code
            String dte = DateTime.Now.ToString();
            String r = dte.Replace("/", "_");
            String u = r.Remove(9);

            String date = u.ToString();
            String month = date;
            ExportOptions RepExportOptions;
            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
            if (month[0].ToString() == "1")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\January\\InvoiceReport '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "2")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\February\\InvoiceReport '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "3")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\March\\InvoiceReport '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "4")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\April\\InvoiceReport '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "5")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\May\\InvoiceReport '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "6")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\June\\InvoiceReport '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "7")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\July\\InvoiceReport '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "8")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\August\\InvoiceReport '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "9")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\September\\InvoiceReport '" + date + "'.pdf";
            }
            else if (month[1].ToString() == "0")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\October\\InvoiceReport '" + date + "'.pdf";
            }
            else if (month[1].ToString() == "1")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\November\\InvoiceReport '" + date + "'.pdf";
            }
            else if (month[1].ToString() == "2")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\December\\InvoiceReport '" + date + "'.pdf";
            }
            //CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\InvoiceReport '" + date + "'.pdf";// + DateTime.Now; //"c:\\csharp.net-informations.pdf";
            RepExportOptions = Rpt2.ExportOptions;
            RepExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            RepExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            RepExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
            RepExportOptions.FormatOptions = CrFormatTypeOptions;
            Rpt2.Export();


            String sdate = invrStDt.Text;
            DateTime sd = DateTime.Parse(sdate);
            invrStDt.Text = sd.ToString("MM/dd/yyyy");

            //Converts enddate back to user format
            String edate = invrEdDt.Text;
            DateTime ed = DateTime.Parse(edate);
            invrEdDt.Text = ed.ToString("MM/dd/yyyy");



            //Excel code Start here***************************************************************************************************

        //    Excel.Application x1APP;
        //    Excel.Workbook x1Workbook;
        //    Excel.Worksheet x1Worksheet;
        //    object misValue = System.Reflection.Missing.Value;
        //    Excel.Range chartRange;

        //    x1APP = new Excel.Application();
        //    x1APP.Visible = true;
        //    x1Workbook = x1APP.Workbooks.Add(misValue);

        //    x1Worksheet = (Excel.Worksheet)x1Workbook.Worksheets.get_Item(1);





        //    int b = 9;

        //    foreach (DataRow row in table101.Rows)
        //    {

        //        x1Worksheet.Cells[b, 2] = (row[0].ToString());                
        //        x1Worksheet.Cells[b, 3] = (row[1].ToString());
        //        x1Worksheet.Cells[b, 4] = (row[10].ToString());
        //        x1Worksheet.Cells[b, 5] = (row[11].ToString());
        //        x1Worksheet.Cells[b, 6] = (row[4].ToString());
        //        x1Worksheet.Cells[b, 7] = (row[5].ToString());
        //        x1Worksheet.Cells[b, 8] = (row[6].ToString());
        //        x1Worksheet.Cells[b, 9] = (row[7].ToString());
        //        x1Worksheet.Cells[b, 10] = (row[8].ToString());
        //        x1Worksheet.Cells[b, 11] = (row[9].ToString());
        //        b++;

        //    }









        //    //Date Generated and Date Range
        //    x1Worksheet.Cells[4, 2] = " Date Generated: ";
        //    x1Worksheet.Cells[4, 3] = DateTime.Now;

        //    x1Worksheet.Cells[5, 2] = " Dates Covered:  ";
        //    x1Worksheet.Cells[5, 3] = invrStDt.Text.Trim() + "-" + invrEdDt.Text.Trim();

        //    //Column Headers
        //    x1Worksheet.Cells[8, 2] = " Invoice Date    ";
        //    x1Worksheet.Cells[8, 3] = " Invoice Amount  ";
        //    x1Worksheet.Cells[8, 4] = " Customer Name    ";
        //    x1Worksheet.Cells[8, 5] = " Job Name  ";
        //    x1Worksheet.Cells[8, 6] = " Project Name  ";
        //    x1Worksheet.Cells[8, 7] = " Project Number        ";
        //    x1Worksheet.Cells[8, 8] = " Estimator        ";
        //    x1Worksheet.Cells[8, 9] = " Salesperson         ";
        //    x1Worksheet.Cells[8, 10] = " Project Manager      ";
        //    x1Worksheet.Cells[8, 11] = " Project Assistant    ";



        //    x1Worksheet.get_Range("b2", "e3").Merge(false);

        //    chartRange = x1Worksheet.get_Range("b2", "e3");
        //    chartRange.FormulaR1C1 = "INVOICING REPORT";
        //    chartRange.Font.Bold = true;
        //    chartRange.Interior.Color = System.Drawing.Color.LightGray;                       
        //    chartRange.HorizontalAlignment = 6;
        //    chartRange.VerticalAlignment = 3;
        //    //Dates Generated 
        //    chartRange = x1Worksheet.get_Range("b4", "b4");
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;
        //    //Dates Covered
        //    chartRange = x1Worksheet.get_Range("b5", "b5");
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    //Display REport


           
        //    //Invoice Date
        //    chartRange = x1Worksheet.get_Range("b8", "b8");
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    //Invoice Amount
        //    chartRange = x1Worksheet.get_Range("c8", "c8");
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    //Customer Name
        //    chartRange = x1Worksheet.get_Range("d8", "d8");
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    //Job Name
        //    chartRange = x1Worksheet.get_Range("e8", "e8");
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    //Project Name 
        //    chartRange = x1Worksheet.get_Range("f8", "f8");
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    //Project Number 
        //    chartRange = x1Worksheet.get_Range("g8", "g8");
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    //Estimator 
        //    chartRange = x1Worksheet.get_Range("h8", "h8");
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    //Salesperson
        //    chartRange = x1Worksheet.get_Range("i8", "i8");
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    //Project Manager
        //    chartRange = x1Worksheet.get_Range("j8", "j8");
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;

        //    //Project Assistant
        //    chartRange = x1Worksheet.get_Range("k8", "k8");
        //    chartRange.EntireColumn.AutoFit();
        //    chartRange.Font.Bold = true;



        //    chartRange = x1Worksheet.get_Range("b2", "l21");
        //    chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

        //    releaseObject(x1Worksheet);
        //    releaseObject(x1Workbook);
        //    releaseObject(x1APP);

        //    MessageBox.Show("Excel file created , you can find the file !");
        }

        //indvidual commission report
        private void indcommbut_Click(object sender, EventArgs e)
        {
            List<DataRow> extraRowsRemove = new List<DataRow>();
            object[] myArray = new object[35];
            DataTable table108 = new DataTable();
            table108.Columns.Add(new DataColumn("paid_date"));
            table108.Columns.Add(new DataColumn("paid_amt"));
            table108.Columns.Add(new DataColumn("billing_date"));
            table108.Columns.Add(new DataColumn("billing_amt"));
            table108.Columns.Add(new DataColumn("project_name"));
            table108.Columns.Add(new DataColumn("project_number"));
            table108.Columns.Add(new DataColumn("cid"));
            table108.Columns.Add(new DataColumn("jid"));
            table108.Columns.Add(new DataColumn("chkd_actcost"));
            table108.Columns.Add(new DataColumn("estimator_percent"));
            table108.Columns.Add(new DataColumn("estimator_comm"));
            table108.Columns.Add(new DataColumn("salesperson_percent"));
            table108.Columns.Add(new DataColumn("salesperson_comm"));
            table108.Columns.Add(new DataColumn("projectmgr_percent"));
            table108.Columns.Add(new DataColumn("projectmgr_comm"));
            table108.Columns.Add(new DataColumn("projectasst_percent"));
            table108.Columns.Add(new DataColumn("projectasst_comm"));
            table108.Columns.Add(new DataColumn("payest_gp"));
            table108.Columns.Add(new DataColumn("payact_gp"));
            table108.Columns.Add(new DataColumn("compnay_name"));
            table108.Columns.Add(new DataColumn("job_name"));
            table108.Columns.Add(new DataColumn("bid"));
            table108.Columns.Add(new DataColumn("project_number1"));
            table108.Columns.Add(new DataColumn("project_name1"));
            table108.Columns.Add(new DataColumn("name_1"));
            table108.Columns.Add(new DataColumn("jtype_1"));
            table108.Columns.Add(new DataColumn("name_2"));
            table108.Columns.Add(new DataColumn("jtype_2"));
            table108.Columns.Add(new DataColumn("name_3"));
            table108.Columns.Add(new DataColumn("jtype_3"));
            table108.Columns.Add(new DataColumn("name_4"));
            table108.Columns.Add(new DataColumn("jtype_4"));
            table108.Columns.Add(new DataColumn("stDate"));
            table108.Columns.Add(new DataColumn("endDate"));
            table108.Columns.Add(new DataColumn("empName"));

            //object[] tr  = new object[32];;
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            SqlConnection MySqlConn = new SqlConnection(connectionString);
            MySqlConn.Open();

            //Start Conversion
            String Startdate = indvStDt.Text.Trim();
            DateTime newStartDate = DateTime.Parse(Startdate);
            indvStDt.Text = newStartDate.ToString("MM/dd/yyyy");

            String Startdate2 = indvStDt.Text.Trim();
            DateTime EndStartDate = DateTime.ParseExact(Startdate2, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
            indvStDt.Text = EndStartDate.ToString("yyyy-MM-dd");


            //End Date Conversion
            String EndDate = indvEnDt.Text.Trim();
            DateTime newEndDate = DateTime.Parse(EndDate);
            indvEnDt.Text = newEndDate.ToString("MM/dd/yyyy");

            String EndDate2 = indvEnDt.Text.Trim();
            DateTime NewEndDate2 = DateTime.ParseExact(EndDate2, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
            indvEnDt.Text = NewEndDate2.ToString("yyyy-MM-dd");


            String indvName = cboindcomm.Text.Trim();


            SqlDataAdapter adap3 = new SqlDataAdapter("SELECT ALL billing.paid_date, billing.paid_amt, billing.billing_date, billing.billing_amt, billing.project_name, billing.project_number, billing.cid, billing.jid, billing.chkd_actcost, billing.estimator_percent, CAST(billing.estimator_comm as decimal(10,2)) estimator_comm, billing.salesperson_percent, CAST(billing.salesperson_comm as decimal(10,2)) salesperson_comm, billing.projectmgr_percent, CAST(billing.projectmgr_comm as decimal(10,2)) projectmgr_comm, billing.projectasst_percent, CAST(billing.projectasst_comm as decimal(10,2)) projectasst_comm, billing.payest_gp, billing.payact_gp, CAST(company.company_name as text) company_name, job.job_name, comm_job_type.bid, comm_job_type.project_number, comm_job_type.project_name, comm_job_type.name_1, comm_job_type.jtype_1, comm_job_type.name_2, comm_job_type.jtype_2, comm_job_type.name_3, comm_job_type.jtype_3, comm_job_type.name_4, comm_job_type.jtype_4 FROM (billing LEFT JOIN company on billing.cid = company.cid) LEFT JOIN job ON billing.jid = job.jid LEFT JOIN comm_job_type ON billing.project_number = comm_job_type.project_number WHERE billing.paid_date >= '" + indvStDt.Text.Trim() + "' AND billing.paid_date <= '" + indvEnDt.Text.Trim() + "'", MySqlConn);
            
            
            DataSet dsOvrRpt2 = new DataSet("DataTable3");
            adap3.Fill(dsOvrRpt2, "DataTable3");
            MySqlConn.Close();
            DataSet indvFill = new DataSet("DataTable3");

            foreach (DataRow ge in dsOvrRpt2.Tables[0].Rows)
            {                  
                if (ge[24].ToString() == indvName.ToString())
                {
                    DataRow dr;
                    for (int i = 0; i < 1000; i++)
                    {
                        myArray[0] = ge.ItemArray[0];
                        myArray[1] = ge.ItemArray[1];
                        myArray[2] = ge.ItemArray[2];
                        myArray[3] = ge.ItemArray[3];
                        myArray[4] = ge.ItemArray[4];
                        myArray[5] = ge.ItemArray[5];
                        myArray[6] = ge.ItemArray[6];
                        myArray[7] = ge.ItemArray[7];
                        string diff = ge.ItemArray[8].ToString();
                        if (diff == "T")
                        {
                            myArray[8] = "Acutal Cost";
                            myArray[17] = " ";
                            myArray[18] = ge.ItemArray[18];
                        }
                        else
                        {
                            myArray[8] = "Estimated Cost";
                            myArray[17] = ge.ItemArray[17];
                            myArray[18] = " ";
                        }
                        myArray[9] = ge.ItemArray[9];
                        myArray[10] = ge.ItemArray[10];
                        //myArray[11] = ge.ItemArray[11];
                        //myArray[12] = ge.ItemArray[12];
                        //myArray[13] = ge.ItemArray[13];
                        //myArray[14] = ge.ItemArray[14];
                        //myArray[15] = ge.ItemArray[15];
                        //myArray[16] = ge.ItemArray[16];
                       // myArray[17] = ge.ItemArray[17];
                        //myArray[18] = ge.ItemArray[18];
                        myArray[19] = ge.ItemArray[19];
                        myArray[20] = ge.ItemArray[20];
                        myArray[21] = ge.ItemArray[21];
                        myArray[22] = ge.ItemArray[22];
                        myArray[23] = ge.ItemArray[23];
                        myArray[24] = " ";
                        myArray[25] = ge.ItemArray[25];
                        if (ge[26].ToString() == cboindcomm.Text.Trim())
                        {
                            myArray[27] = ge.ItemArray[27];
                            myArray[11] = ge.ItemArray[11];
                            myArray[12] = ge.ItemArray[12];
                        }
                        else
                        {
                            myArray[26] = " ";
                            myArray[27] = " ";
                            myArray[11] = " ";
                            myArray[12] = " ";
                        }
                        //if (ge.ItemArray[27] != indvName.ToString())
                        //{
                        //    myArray[27] = " ";
                        //}
                        if (ge[28].ToString() == cboindcomm.Text.Trim())
                        {
                            myArray[29] = ge.ItemArray[29];
                            myArray[13] = ge.ItemArray[13];
                            myArray[14] = ge.ItemArray[14];
                        }
                        else
                        {
                            myArray[28] = " ";
                            myArray[29] = " ";
                            myArray[13] = " ";
                            myArray[14] = " ";
                        }
                        //if(ge.ItemArray[29] != indvName.ToString())
                        //{
                        //    myArray[29] = " ";
                        //}
                        if (ge[30].ToString() == cboindcomm.Text.Trim())
                        {
                            myArray[31] = ge.ItemArray[31];
                            myArray[15] = ge.ItemArray[15];
                            myArray[16] = ge.ItemArray[16];

                        }
                        else
                        {
                            myArray[30] = " ";
                            myArray[31] = " ";
                            myArray[15] = " ";
                            myArray[16] = " ";
                        }
                        //if(ge.ItemArray[31] != indvName.ToString())
                        //{
                        //    myArray[31] = " ";
                        //}
                        myArray[32] = indvStDt.Text.Trim();
                        myArray[33] = indvEnDt.Text.Trim();
                        myArray[34] = indvName.ToString();
                        //myArray[26] = ge.ItemArray[26];                        
                        //myArray[27] = ge.ItemArray[27];
                        //myArray[28] = ge.ItemArray[28];
                        //myArray[29] = ge.ItemArray[29];
                        //myArray[30] = ge.ItemArray[30];
                        //myArray[31] = ge.ItemArray[31];                       


                        dr = table108.NewRow();
                        dr.ItemArray = myArray;
                        table108.Rows.Add(dr);
                        table108.AcceptChanges();
                        break;
                        //indvFill.Tables.Add(table108);
                        
                    }

                }
                else if (ge[26].ToString() == indvName.ToString())
                {
                    DataRow dm;
                    for (int i = 0; i < 1000; i++)
                    {
                        myArray[0] = ge.ItemArray[0];
                        myArray[1] = ge.ItemArray[1];
                        myArray[2] = ge.ItemArray[2];
                        myArray[3] = ge.ItemArray[3];
                        myArray[4] = ge.ItemArray[4];
                        myArray[5] = ge.ItemArray[5];
                        myArray[6] = ge.ItemArray[6];
                        myArray[7] = ge.ItemArray[7];
                        string diff = ge.ItemArray[8].ToString();
                        if (diff == "T")
                        {
                            myArray[8] = "Acutal Cost";
                            myArray[17] = " ";
                            myArray[18] = ge.ItemArray[18];
                        }
                        else
                        {
                            myArray[8] = "Estimated Cost";
                            myArray[17] = ge.ItemArray[17];
                            myArray[18] = " ";
                        }
                        myArray[9] = " ";
                        myArray[10] = " ";
                        myArray[11] = ge.ItemArray[11];
                        myArray[12] = ge.ItemArray[12];
                        //myArray[13] = " ";
                        //myArray[14] = " ";
                        //myArray[15] = " ";
                        //myArray[16] = " ";
                        //myArray[17] = ge.ItemArray[17];
                        //myArray[18] = ge.ItemArray[18];
                        myArray[19] = ge.ItemArray[19];
                        myArray[20] = ge.ItemArray[20];
                        myArray[21] = ge.ItemArray[21];
                        myArray[22] = ge.ItemArray[22];
                        myArray[23] = ge.ItemArray[23];
                        if (ge[24].ToString() == cboindcomm.Text.Trim())
                        {

                            myArray[25] = ge.ItemArray[25];
                            myArray[9] = ge.ItemArray[9];
                            myArray[10] = ge.ItemArray[10];
                        }
                        else
                        {
                            myArray[24] = " ";
                            myArray[25] = " ";
                            myArray[9] = " ";
                            myArray[10] = " ";
                        }
                        
                        //if (ge[25] != indvName.ToString())
                        //{
                        //    myArray[25] = " ";
                        //}

                            //myArray[24] = ge.ItemArray[24];
                            //myArray[25] = ge.ItemArray[25];
                            myArray[26] = " ";
                        myArray[27] = ge.ItemArray[27];
                        if (ge[28].ToString() == cboindcomm.Text.Trim())
                        {
                            myArray[29] = ge.ItemArray[29];
                            myArray[13] = ge.ItemArray[13];
                            myArray[14] = ge.ItemArray[14];

                        }
                        else
                        {
                            myArray[13] = " ";
                            myArray[14] = " ";
                            myArray[29] = " ";

                        }
                        //if (ge[29] != indvName.ToString())
                        //{
                        //    myArray[29] = " ";
                        //}
                        if (ge[30].ToString() == cboindcomm.Text.Trim())
                        {
                            myArray[31] = ge.ItemArray[31];
                            myArray[15] = ge.ItemArray[15];
                            myArray[16] = ge.ItemArray[16];

                        }
                        else
                        {
                            myArray[30] = " ";
                            myArray[31] = " ";
                            myArray[15] = " ";
                            myArray[16] = " ";
                        }
                        //if (ge[31] != indvName.ToString())
                        //{
                        //    myArray[31] = " ";
                        //}
                        myArray[32] = indvStDt.Text.Trim();
                        myArray[33] = indvEnDt.Text.Trim();
                        myArray[34] = indvName.ToString();
                        //else
                        //myArray[28] = ge.ItemArray[28];
                        //myArray[29] = ge.ItemArray[29];
                        //myArray[30] = ge.ItemArray[30];
                        //myArray[31] = ge.ItemArray[31];


                        dm = table108.NewRow();
                        dm.ItemArray = myArray;
                        table108.Rows.Add(dm);
                        table108.AcceptChanges();
                        break;
                        //indvFill.Tables.Add(table108);
                    }
                }
                else if (ge[28].ToString() == indvName.ToString())
                {
                    DataRow dz;
                    for (int i = 0; i < 1000; i++)
                    {
                        myArray[0] = ge.ItemArray[0];
                        myArray[1] = ge.ItemArray[1];
                        myArray[2] = ge.ItemArray[2];
                        myArray[3] = ge.ItemArray[3];
                        myArray[4] = ge.ItemArray[4];
                        myArray[5] = ge.ItemArray[5];
                        myArray[6] = ge.ItemArray[6];
                        myArray[7] = ge.ItemArray[7];
                        string diff = ge.ItemArray[8].ToString();
                        if (diff == "T")
                        {
                            myArray[8] = "Acutal Cost";
                            myArray[17] = " ";
                            myArray[18] = ge.ItemArray[18];
                        }
                        else
                        {
                            myArray[8] = "Estimated Cost";
                            myArray[17] = ge.ItemArray[17];
                            myArray[18] = " ";
                        } 
                        //myArray[9] = " ";
                        //myArray[10] = " ";
                        //myArray[11] = " ";
                        //myArray[12] = " ";
                        myArray[13] = ge.ItemArray[13];
                        myArray[14] = ge.ItemArray[14];
                        //myArray[15] = " ";
                        //myArray[16] = " ";
                        //myArray[17] = ge.ItemArray[17];
                        //myArray[18] = ge.ItemArray[18];
                        myArray[19] = ge.ItemArray[19];
                        myArray[20] = ge.ItemArray[20];
                        myArray[21] = ge.ItemArray[21];
                        myArray[22] = ge.ItemArray[22];
                        myArray[23] = ge.ItemArray[23];
                        if (ge[24].ToString() == cboindcomm.Text.Trim())
                        {
                            myArray[25] = ge.ItemArray[25];
                            myArray[9] = ge.ItemArray[9];
                            myArray[10] = ge.ItemArray[10];
                        }
                        else
                        {
                            myArray[24] = " ";
                            myArray[25] = " ";
                            myArray[9] = " ";
                            myArray[10] = " ";
                        }
                        //if(ge.ItemArray[25] != indvName.ToString())
                        //{
                        //    myArray[25] = " ";
                        //}
                        if (ge[26].ToString() == cboindcomm.Text.Trim())
                        {
                            myArray[27] = ge.ItemArray[27];
                            myArray[11] = ge.ItemArray[11];
                            myArray[12] = ge.ItemArray[12];
                        }
                        else
                        {
                            myArray[26] = " ";
                            myArray[27] = " ";
                            myArray[11] = " ";
                            myArray[12] = " ";
                        }
                        //if (ge.ItemArray[27] != indvName.ToString())
                        //{
                        //    myArray[27] = " ";
                        //}
                        //myArray[24] = ge.ItemArray[24];
                        //myArray[25] = ge.ItemArray[25];
                        //myArray[26] = ge.ItemArray[26];
                        //myArray[27] = ge.ItemArray[27];
                        myArray[28] = " ";
                        myArray[29] = ge.ItemArray[29];
                        if (ge[30].ToString() == cboindcomm.Text.Trim())
                        {
                            myArray[31] = ge.ItemArray[31];
                            myArray[15] = ge.ItemArray[15];
                            myArray[16] = ge.ItemArray[16];
                        }
                        else
                        {
                            myArray[30] = " ";
                            myArray[31] = " ";
                            myArray[15] = " ";
                            myArray[16] = " ";
                        }
                        //if (ge.ItemArray[31] != indvName.ToString())
                        //{
                        //    myArray[31] = " ";
                        //}
                        //myArray[30] = ge.ItemArray[30];
                        //myArray[31] = ge.ItemArray[31];
                        myArray[32] = indvStDt.Text.Trim();
                        myArray[33] = indvEnDt.Text.Trim();
                        myArray[34] = indvName.ToString();

                        dz = table108.NewRow();
                        dz.ItemArray = myArray;
                        table108.Rows.Add(dz);
                        table108.AcceptChanges();
                        break;
                        //indvFill.Tables.Add(table108);
                    }
                }
                else if (ge[30].ToString() == indvName.ToString())
                {
                    DataRow da;
                    for (int i = 0; i < 1000; i++)
                    {
                        myArray[0] = ge.ItemArray[0];
                        myArray[1] = ge.ItemArray[1];
                        myArray[2] = ge.ItemArray[2];
                        myArray[3] = ge.ItemArray[3];
                        myArray[4] = ge.ItemArray[4];
                        myArray[5] = ge.ItemArray[5];
                        myArray[6] = ge.ItemArray[6];
                        myArray[7] = ge.ItemArray[7];
                        string diff = ge.ItemArray[8].ToString();
                        if (diff == "T")
                        {
                            myArray[8] = "Acutal Cost";
                            myArray[17] = " ";
                            myArray[18] = ge.ItemArray[18];
                        }
                        else
                        {
                            myArray[8] = "Estimated Cost";
                            myArray[17] = ge.ItemArray[17];
                            myArray[18] = " ";
                        }                        
                        //myArray[9] = " ";
                        //myArray[10] = " ";
                        //myArray[11] = " ";
                        //myArray[12] = " ";
                        //myArray[13] = " ";
                        //myArray[14] = " ";
                        myArray[15] = ge.ItemArray[15];
                        myArray[16] = ge.ItemArray[16];
                        //myArray[17] = ge.ItemArray[17];
                        //myArray[18] = ge.ItemArray[18];
                        myArray[19] = ge.ItemArray[19];
                        myArray[20] = ge.ItemArray[20];
                        myArray[21] = ge.ItemArray[21];
                        myArray[22] = ge.ItemArray[22];
                        myArray[23] = ge.ItemArray[23];
                        if (ge[24].ToString() == cboindcomm.Text.Trim())
                        {
                            myArray[25] = ge.ItemArray[25];
                            myArray[9] = ge.ItemArray[9];
                            myArray[10] = ge.ItemArray[10];
                        }
                        else
                        {
                            myArray[24] = " ";
                            myArray[25] = " ";
                            myArray[9] = " ";
                            myArray[10] = " ";
                        }
                        //if (ge.ItemArray[25] != indvName.ToString())
                        //{
                        //    myArray[25] = " ";
                        //}
                        if (ge[26].ToString() == cboindcomm.Text.Trim())
                        {
                            myArray[27] = ge.ItemArray[27];
                            myArray[11] = ge.ItemArray[11];
                            myArray[12] = ge.ItemArray[12];
                        }
                        else
                        {
                            myArray[26] = " ";
                            myArray[27] = " ";
                            myArray[11] = " ";
                            myArray[12] = " ";
                        }
                        //if (ge.ItemArray[27] == indvName.ToString())
                        //{
                        //    myArray[27] = " ";
                        //}
                        if (ge[28].ToString() == cboindcomm.Text.Trim())
                        {
                            myArray[29] = ge.ItemArray[29];
                            myArray[13] = ge.ItemArray[13];
                            myArray[14] = ge.ItemArray[14];
                        }
                        else
                        {
                            myArray[28] = " ";
                            myArray[29] = " ";
                            myArray[13] = " ";
                            myArray[14] = " ";
                        }
                        //if (ge.ItemArray[29] != indvName.ToString())
                        //{
                        //    myArray[29] = " ";
                        //}
                        //myArray[24] = ge.ItemArray[24];
                        //myArray[25] = ge.ItemArray[25];
                        //myArray[26] = ge.ItemArray[26];
                        //myArray[27] = ge.ItemArray[27];
                        //myArray[28] = ge.ItemArray[28];
                        //myArray[29] = ge.ItemArray[29];
                        myArray[30] = " ";
                        myArray[31] = ge.ItemArray[31];
                        myArray[32] = indvStDt.Text.Trim();
                        myArray[33] = indvEnDt.Text.Trim();
                        myArray[34] = indvName.ToString();

                        da = table108.NewRow();
                        da.ItemArray = myArray;
                        table108.Rows.Add(da);
                        table108.AcceptChanges();
                        break;
                        //indvFill.Tables.Add(table108);
                    }
                }
               
            }
            //Add the appropriate tables to the dataset for the report
            indvFill.Tables.Add(table108);
            //adap3.Fill(indvFill, "DataTable2");
            var path = ("C:\\Users\\Darren\\Documents\\Visual Studio 2010\\Projects\\CommissionDBApplication\\WindowsFormsApplication1\\indvComm.rpt");
            indvComm Rpt3 = new indvComm();
            Rpt3.Load(path);
            Rpt3.SetDataSource(indvFill.Tables[0]);
            crystalReportViewer1.ReportSource = Rpt3;

        //    string commandString107 = ("SELECT ALL billing.paid_date, billing.paid_amt, billing.billing_date, billing.billing_amt, billing.project_name, billing.project_number, billing.cid, billing.jid, billing.chkd_actcost, billing.estimator_percent, billing.estimator_comm, billing.salesperson_percent, billing.salesperson_comm, billing.projectmgr_percent, billing.projectmgr_comm, billing.projectasst_percent, billing.projectasst_comm, billing.payest_gp, billing.payact_gp, company.company_name, job.job_name, comm_job_type.bid, comm_job_type.project_number, comm_job_type.project_name, comm_job_type.name_1, comm_job_type.jtype_1, comm_job_type.name_2, comm_job_type.jtype_2, comm_job_type.name_3, comm_job_type.jtype_3, comm_job_type.name_4, comm_job_type.jtype_4 FROM (billing LEFT JOIN company on billing.cid = company.cid) LEFT JOIN job ON billing.jid = job.jid LEFT JOIN comm_job_type ON billing.project_number = comm_job_type.project_number WHERE billing.paid_date >= '" + indvStDt.Text.Trim() + "' AND billing.paid_date <= '" + indvEnDt.Text.Trim() + "'");            
        //    //string commandString107 = ("SELECT ALL billing.paid_date, billing.paid_amt, billing.billing_date, billing.billing_amt, billing.project_name, billing.project_number, billing.cid, billing.jid, billing.chkd_actcost, billing.estimator, billing.estimator_percent, billing.estimator_comm, billing.salesperson, billing.salesperson_percent, billing.salesperson_comm, billing.projectmgr, billing.projectmgr_percent, billing.projectmgr_comm, billing.projectasst, billing.projectasst_percent, billing.projectasst_comm, billing.payest_gp, billing.payact_gp, company.company_name, job.job_name, comm_job_type.bid, comm_job_type.project_number, comm_job_type.project_name, comm_job_type.name_1, comm_job_type.jtype_1, comm_job_type.name_2, comm_job_type.jtype_2, comm_job_type.name_3, comm_job_type.jtype_3, comm_job_type.name_4, comm_job_type.jtype_4 FROM (billing LEFT JOIN company on billing.cid = company.cid) LEFT JOIN job ON billing.jid = job.jid LEFT JOIN comm_job_type ON billing.estimator = comm_job_type.comm_job_type.name_1 AND billing.salesperson = comm_job_type.name_2 AND billing.projectmgr = comm_job_type.name_3 AND billing.projectasst = comm_job_type.name_4 WHERE billing.paid_date >= '" + indvStDt.Text.Trim() + "' AND billing.paid_date <= '" + indvEnDt.Text.Trim() + "'");
        //    MySqlCommand mysqlcommand107 = new MySqlCommand(commandString107, MySqlConn);

        //    DataTable table107 = GetDataTable(
        //        // Pass open database connection to function
        //ref MySqlConn,
        //        // Pass SQL statement to create SqlDataReader
        //commandString107);

            //Export to PDF code
            String dte = DateTime.Now.ToString();
            String r = dte.Replace("/", "_");
            String u = r.Remove(9);
            String date = u.ToString();
            String month = date;

            ExportOptions RepExportOptions;
            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
            if (month[0].ToString() == "1")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\January\\IndividualCommReport '" + cboindcomm.Text.Trim() + "' '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "2")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\February\\IndividualCommReport '" + cboindcomm.Text.Trim() + "' '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "3")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\March\\IndividualCommReport '" + cboindcomm.Text.Trim() + "' '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "4")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\April\\IndividualCommReport '" + cboindcomm.Text.Trim() + "' '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "5")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\May\\IndividualCommReport '" + cboindcomm.Text.Trim() + "' '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "6")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\June\\IndividualCommReport '" + cboindcomm.Text.Trim() + "' '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "7")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\July\\IndividualCommReport '" + cboindcomm.Text.Trim() + "' '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "8")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\August\\IndividualCommReport '" + cboindcomm.Text.Trim() + "' '" + date + "'.pdf";
            }
            else if (month[0].ToString() == "9")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\September\\IndividualCommReport '" + cboindcomm.Text.Trim() + "' '" + date + "'.pdf";
            }
            else if (month[1].ToString() == "0")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\October\\IndividualCommReport '" + cboindcomm.Text.Trim() + "' '" + date + "'.pdf";
            }
            else if (month[1].ToString() == "1")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\November\\IndividualCommReport '" + cboindcomm.Text.Trim() + "' '" + date + "'.pdf";
            }
            else if (month[1].ToString() == "2")
            {
                CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\December\\IndividualCommReport '" + cboindcomm.Text.Trim() + "' '" + date + "'.pdf";
            }
            //CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\IndividualCommReport '" + cboindcomm.Text.Trim() + "' '" + date + "'.pdf";
            RepExportOptions = Rpt3.ExportOptions;
            RepExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            RepExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            RepExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
            RepExportOptions.FormatOptions = CrFormatTypeOptions;
            Rpt3.Export();

            //Converts startdate back to user format
            String sdate = indvStDt.Text;
            DateTime sd = DateTime.Parse(sdate);
            indvStDt.Text = sd.ToString("MM/dd/yyyy");

            //Converts enddate back to user format
            String edate = indvEnDt.Text;
            DateTime ed = DateTime.Parse(edate);
            indvEnDt.Text = ed.ToString("MM/dd/yyyy");


            //Excel code Start here***************************************************************************************************

            //Excel.Application x1APP;
            //Excel.Workbook x1Workbook;
            //Excel.Worksheet x1Worksheet;
            //object misValue = System.Reflection.Missing.Value;
            //Excel.Range chartRange;
            

            //x1APP = new Excel.Application();
            //x1APP.Visible = true;
            //x1Workbook = x1APP.Workbooks.Add(misValue);

            //x1Worksheet = (Excel.Worksheet)x1Workbook.Worksheets.get_Item(1);

            //foreach (DataRow row1 in table107.Rows)
            //{
            //    if (row1[24].ToString() != cboindcomm.Text.Trim());
            //    {
            //        extraRowsRemove.Add(row1);
            //    }
            //    else if (row1[26].ToString() != cboindcomm.Text.Trim())
            //    {
            //        extraRowsRemove.Add(row1);
            //    }
            //    else if (row1[28].ToString() != cboindcomm.Text.Trim())
            //    {
            //        extraRowsRemove.Add(row1);
            //    }
            //    else if (row1[30].ToString() != cboindcomm.Text.Trim())
            //    {
            //        extraRowsRemove.Add(row1);
            //    }
            //}

            //foreach (DataRow row4 in table107.Rows)
            //{
                                      
            //        if (row4[24].ToString() == indvName.ToString())
            //        {
            //            DataRow dr;
            //        // Declare the array variable.
                         
            //        // Create 10 new rows and add to DataRowCollection.
            //            for (int i = 0; i < 1000; i++)
            //            {
                            
            //                myArray[0] = row4.ItemArray[0];
            //                myArray[1] = row4.ItemArray[1];
            //                myArray[2] = row4.ItemArray[2];
            //                myArray[3] = row4.ItemArray[3]; 
            //                myArray[4] = row4.ItemArray[4]; 
            //                myArray[5] = row4.ItemArray[5]; 
            //                myArray[6] = row4.ItemArray[6]; 
            //                myArray[7] = row4.ItemArray[7]; 
            //                myArray[8] = row4.ItemArray[8]; 
            //                myArray[9] = row4.ItemArray[9]; 
            //                myArray[10] = row4.ItemArray[10];
            //                myArray[11] = row4.ItemArray[11];
            //                myArray[12] = row4.ItemArray[12];
            //                myArray[13] = row4.ItemArray[13];
            //                myArray[14] = row4.ItemArray[14];
            //                myArray[15] = row4.ItemArray[15];
            //                myArray[16] = row4.ItemArray[16];
            //                myArray[17] = row4.ItemArray[17];
            //                myArray[18] = row4.ItemArray[18];
            //                myArray[19] = row4.ItemArray[19];
            //                myArray[20] = row4.ItemArray[20];
            //                myArray[21] = row4.ItemArray[21];
            //                myArray[22] = row4.ItemArray[22];
            //                myArray[23] = row4.ItemArray[23];
            //                myArray[24] = row4.ItemArray[24];
            //                myArray[25] = row4.ItemArray[25];
            //                myArray[26] = row4.ItemArray[26];
            //                myArray[27] = row4.ItemArray[27];
            //                myArray[28] = row4.ItemArray[28];
            //                myArray[29] = row4.ItemArray[29];
            //                myArray[30] = row4.ItemArray[30];
            //                myArray[31] = row4.ItemArray[31];

            //                dr = table108.NewRow();
            //                dr.ItemArray = myArray;
            //                table108.Rows.Add(dr);
            //                table108.AcceptChanges();
            //                break;
            //            }
                        
            //        }
            //        else if (row4[26].ToString() == indvName.ToString())
            //        {
            //            DataRow dm;
            //            // Declare the array variable.

            //            // Create 10 new rows and add to DataRowCollection.
            //            for (int i = 0; i < 1000; i++)
            //            {

            //                myArray[0] = row4.ItemArray[0];
            //                myArray[1] = row4.ItemArray[1];
            //                myArray[2] = row4.ItemArray[2];
            //                myArray[3] = row4.ItemArray[3];
            //                myArray[4] = row4.ItemArray[4];
            //                myArray[5] = row4.ItemArray[5];
            //                myArray[6] = row4.ItemArray[6];
            //                myArray[7] = row4.ItemArray[7];
            //                myArray[8] = row4.ItemArray[8];
            //                myArray[9] = row4.ItemArray[9];
            //                myArray[10] = row4.ItemArray[10];
            //                myArray[11] = row4.ItemArray[11];
            //                myArray[12] = row4.ItemArray[12];
            //                myArray[13] = row4.ItemArray[13];
            //                myArray[14] = row4.ItemArray[14];
            //                myArray[15] = row4.ItemArray[15];
            //                myArray[16] = row4.ItemArray[16];
            //                myArray[17] = row4.ItemArray[17];
            //                myArray[18] = row4.ItemArray[18];
            //                myArray[19] = row4.ItemArray[19];
            //                myArray[20] = row4.ItemArray[20];
            //                myArray[21] = row4.ItemArray[21];
            //                myArray[22] = row4.ItemArray[22];
            //                myArray[23] = row4.ItemArray[23];
            //                myArray[24] = row4.ItemArray[24];
            //                myArray[25] = row4.ItemArray[25];
            //                myArray[26] = row4.ItemArray[26];
            //                myArray[27] = row4.ItemArray[27];
            //                myArray[28] = row4.ItemArray[28];
            //                myArray[29] = row4.ItemArray[29];
            //                myArray[30] = row4.ItemArray[30];
            //                myArray[31] = row4.ItemArray[31];

            //                dm = table108.NewRow();
            //                dm.ItemArray = myArray;
            //                table108.Rows.Add(dm);
            //                table108.AcceptChanges();
            //                break;
            //            }
            //        }
            //        else if (row4[28].ToString() == indvName.ToString())
            //        {
            //            DataRow dz;
            //            // Declare the array variable.

            //            // Create 10 new rows and add to DataRowCollection.
            //            for (int i = 0; i < 1000; i++)
            //            {

            //                myArray[0] = row4.ItemArray[0];
            //                myArray[1] = row4.ItemArray[1];
            //                myArray[2] = row4.ItemArray[2];
            //                myArray[3] = row4.ItemArray[3];
            //                myArray[4] = row4.ItemArray[4];
            //                myArray[5] = row4.ItemArray[5];
            //                myArray[6] = row4.ItemArray[6];
            //                myArray[7] = row4.ItemArray[7];
            //                myArray[8] = row4.ItemArray[8];
            //                myArray[9] = row4.ItemArray[9];
            //                myArray[10] = row4.ItemArray[10];
            //                myArray[11] = row4.ItemArray[11];
            //                myArray[12] = row4.ItemArray[12];
            //                myArray[13] = row4.ItemArray[13];
            //                myArray[14] = row4.ItemArray[14];
            //                myArray[15] = row4.ItemArray[15];
            //                myArray[16] = row4.ItemArray[16];
            //                myArray[17] = row4.ItemArray[17];
            //                myArray[18] = row4.ItemArray[18];
            //                myArray[19] = row4.ItemArray[19];
            //                myArray[20] = row4.ItemArray[20];
            //                myArray[21] = row4.ItemArray[21];
            //                myArray[22] = row4.ItemArray[22];
            //                myArray[23] = row4.ItemArray[23];
            //                myArray[24] = row4.ItemArray[24];
            //                myArray[25] = row4.ItemArray[25];
            //                myArray[26] = row4.ItemArray[26];
            //                myArray[27] = row4.ItemArray[27];
            //                myArray[28] = row4.ItemArray[28];
            //                myArray[29] = row4.ItemArray[29];
            //                myArray[30] = row4.ItemArray[30];
            //                myArray[31] = row4.ItemArray[31];

            //                dz = table108.NewRow();
            //                dz.ItemArray = myArray;
            //                table108.Rows.Add(dz);
            //                table108.AcceptChanges();
            //                break;
            //            }
            //        }
            //        else if (row4[30].ToString() == indvName.ToString())
            //        {
            //            DataRow da;
            //            // Declare the array variable.

            //            // Create 10 new rows and add to DataRowCollection.
            //            for (int i = 0; i < 1000; i++)
            //            {

            //                myArray[0] = row4.ItemArray[0];
            //                myArray[1] = row4.ItemArray[1];
            //                myArray[2] = row4.ItemArray[2];
            //                myArray[3] = row4.ItemArray[3];
            //                myArray[4] = row4.ItemArray[4];
            //                myArray[5] = row4.ItemArray[5];
            //                myArray[6] = row4.ItemArray[6];
            //                myArray[7] = row4.ItemArray[7];
            //                myArray[8] = row4.ItemArray[8];
            //                myArray[9] = row4.ItemArray[9];
            //                myArray[10] = row4.ItemArray[10];
            //                myArray[11] = row4.ItemArray[11];
            //                myArray[12] = row4.ItemArray[12];
            //                myArray[13] = row4.ItemArray[13];
            //                myArray[14] = row4.ItemArray[14];
            //                myArray[15] = row4.ItemArray[15];
            //                myArray[16] = row4.ItemArray[16];
            //                myArray[17] = row4.ItemArray[17];
            //                myArray[18] = row4.ItemArray[18];
            //                myArray[19] = row4.ItemArray[19];
            //                myArray[20] = row4.ItemArray[20];
            //                myArray[21] = row4.ItemArray[21];
            //                myArray[22] = row4.ItemArray[22];
            //                myArray[23] = row4.ItemArray[23];
            //                myArray[24] = row4.ItemArray[24];
            //                myArray[25] = row4.ItemArray[25];
            //                myArray[26] = row4.ItemArray[26];
            //                myArray[27] = row4.ItemArray[27];
            //                myArray[28] = row4.ItemArray[28];
            //                myArray[29] = row4.ItemArray[29];
            //                myArray[30] = row4.ItemArray[30];
            //                myArray[31] = row4.ItemArray[31];

            //                da = table108.NewRow();
            //                da.ItemArray = myArray;
            //                table108.Rows.Add(da);
            //                table108.AcceptChanges();
            //                break;
            //            }
            //        }
            //        else
            //        {
            //            row4.Delete();
            //        }
                
            //}
            
            //int k = 10;
            
            //foreach (DataRow row in table108.Rows)
            //{
            //    x1Worksheet.Cells[k, 2] = (row[0].ToString());
            //    x1Worksheet.Cells[k, 3] = (row[1].ToString());
            //    x1Worksheet.Cells[k, 4] = (row[2].ToString());
            //    x1Worksheet.Cells[k, 5] = (row[3].ToString());
            //    x1Worksheet.Cells[k, 6] = (row[19].ToString());
            //    x1Worksheet.Cells[k, 7] = (row[20].ToString());
            //    x1Worksheet.Cells[k, 8] = (row[22].ToString());
            //    x1Worksheet.Cells[k, 9] = (row[23].ToString());
            //    string diff = (row[8].ToString());
            //    if (diff == "T")
            //    {
            //        x1Worksheet.Cells[k, 8] = (row[5].ToString());
            //        x1Worksheet.Cells[k, 9] = (row[4].ToString());
            //        x1Worksheet.Cells[k, 10] = "Actual Cost";
            //        x1Worksheet.Cells[k, 11] = (row[18].ToString());
            //    }
            //    else
            //    {
            //        x1Worksheet.Cells[k, 10] = "Estimated Cost";
            //        x1Worksheet.Cells[k, 11] = (row[17].ToString());
            //    }
            //        if (row[24].ToString() == indvName.ToString())
            //        {
            //            int a = k;
            //            x1Worksheet.Cells[a, 12] = (row[25].ToString());
            //            x1Worksheet.Cells[a, 13] = (row[9].ToString());
            //            x1Worksheet.Cells[a, 14] = (row[10].ToString());
            //            a++;
            //            k++;

            //        }
                
            //        if (row[26].ToString() == indvName.ToString())
            //        {
            //            int c = k;
            //            x1Worksheet.Cells[c, 12] = (row[27].ToString());
            //            x1Worksheet.Cells[c, 13] = (row[11].ToString());
            //            x1Worksheet.Cells[c, 14] = (row[12].ToString());
            //            c++;
            //            k++;
                    
            //        }
                
            //        if (row[28].ToString() == indvName.ToString())
            //        {
            //            int d = k;
            //            x1Worksheet.Cells[d, 12] = (row[29].ToString());
            //            x1Worksheet.Cells[d, 13] = (row[13].ToString());
            //            x1Worksheet.Cells[d, 14] = (row[14].ToString());
            //            d++;
            //            k++;

            //        }
                
            //        if (row[30].ToString() == indvName.ToString())
            //        {
            //            int f = k;
            //            x1Worksheet.Cells[f, 12] = (row[31].ToString());
            //            x1Worksheet.Cells[f, 13] = (row[15].ToString());
            //            x1Worksheet.Cells[f, 14] = (row[16].ToString());
            //            f++;
            //            k++;
                        

            //        }
                
            //        k++;

            //}

            //int v = k;
            //v++;  
            ////Totals           
            ////x1Worksheet.Cells[62, 3] = "=sum(C9:C60)";
            ////x1Worksheet.Cells[62, 11] = "=sum(K9:K60)";
            ////x1Worksheet.Cells[62, 14] = "=sum(N9:N60)";


            //x1Worksheet.Cells[4, 2] = " Date Generated: ";
            //x1Worksheet.Cells[4, 3] = DateTime.Now;
            //x1Worksheet.Cells[4, 5] = " Total Payments: ";
            //chartRange = x1Worksheet.Cells[4, 5];
            //chartRange.Font.Bold = true;
            //x1Worksheet.Cells[4, 6] = "=sum(C9:C300)";

            //x1Worksheet.Cells[5, 2] = " Dates Covered:  ";
            //x1Worksheet.Cells[5, 3] = indvStDt.Text.Trim() + "-" + indvEnDt.Text.Trim();
            //x1Worksheet.Cells[5, 5] = " Total Gross Profits: ";
            //chartRange = x1Worksheet.Cells[5, 5];
            //chartRange.Font.Bold = true;
            //x1Worksheet.Cells[5, 6] = "=sum(K9:K300)";

            //x1Worksheet.Cells[6, 2] = " Individual Report: ";
            //x1Worksheet.Cells[6, 3] = cboindcomm.Text.Trim();
            //x1Worksheet.Cells[6, 5] = " Total Commissions: ";
            //chartRange = x1Worksheet.Cells[6, 5];
            //chartRange.Font.Bold = true;
            //x1Worksheet.Cells[6, 6] = "=sum(N9:N300)";

            ////Column HEaders
            //x1Worksheet.Cells[9, 2] = " Payment Date    ";
            //x1Worksheet.Cells[9, 3] = " Payment Amount  ";
            //x1Worksheet.Cells[9, 4] = " Invoice Date    ";
            //x1Worksheet.Cells[9, 5] = " Invoice Amount  ";
            //x1Worksheet.Cells[9, 6] = " Customer Name  ";
            //x1Worksheet.Cells[9, 7] = " Job Name        ";
            //x1Worksheet.Cells[9, 8] = " Project Number        ";
            //x1Worksheet.Cells[9, 9] = " Project Name         ";
            //x1Worksheet.Cells[9, 10] = " Estimated or Actual      ";
            //x1Worksheet.Cells[9, 11] = " Gross Profit    ";
            //x1Worksheet.Cells[9, 12] = " Commission Type       ";
            //x1Worksheet.Cells[9, 13] = " Commission Percentage   ";
            //x1Worksheet.Cells[9, 14] = " Commission    ";


            ////REport Footer
            ////v--;
            ////v--;
            ////x1Worksheet.Cells[v, 2] = " Totals:   ";
            ////chartRange = x1Worksheet.Cells[v, 2];
            ////chartRange.Font.Bold = true;
            ////x1Worksheet.Cells[v, 3] = " Total Payments   ";
            ////chartRange = x1Worksheet.Cells[v, 3];
            ////chartRange.Font.Bold = true;
            ////x1Worksheet.Cells[v, 11] = " Total Gross Profits   ";
            ////chartRange = x1Worksheet.Cells[v, 11];
            ////chartRange.Font.Bold = true;
            ////x1Worksheet.Cells[v, 14] = " Total Commissions   ";
            ////chartRange = x1Worksheet.Cells[v, 14];
            ////chartRange.Font.Bold = true;
            ////v++;
            ////x1Worksheet.Cells[v, 3] = "=sum(C9:C60)";
            ////x1Worksheet.Cells[v, 11] = "=sum(K9:K60)";
            ////x1Worksheet.Cells[v, 14] = "=sum(N9:N60)";

            ////x1Worksheet.Cells[61, 2] = " Totals:   ";
            ////x1Worksheet.Cells[61, 3] = " Total Payments   ";
            ////x1Worksheet.Cells[61, 11] = " Total Gross Profits   ";
            ////x1Worksheet.Cells[61, 14] = " Total Commissions   ";
            ////End Report Footer


            ////Report Header%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

            //x1Worksheet.get_Range("b2", "e3").Merge(false);

            //chartRange = x1Worksheet.get_Range("b2", "e3");
            //chartRange.FormulaR1C1 = "COMMISSION REPORT INDIVIDUAL";
            //chartRange.Font.Bold = true;
            //chartRange.Interior.Color = System.Drawing.Color.LightGray;
            ////chartRa = System.Drawing.Color.LightGray;            
            //chartRange.HorizontalAlignment = 6;
            //chartRange.VerticalAlignment = 3;
            ////Dates Generated 
            //chartRange = x1Worksheet.get_Range("b4", "b4");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;
            ////Dates Covered
            //chartRange = x1Worksheet.get_Range("b5", "b5");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;
            ////Individual Person Name
            //chartRange = x1Worksheet.get_Range("b6", "b6");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;


            ////Column Header Formatting
            ////Payment Date
            //chartRange = x1Worksheet.get_Range("b9", "b9");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;

            ////Payment Amount
            //chartRange = x1Worksheet.get_Range("c9", "c9");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;
            
            ////Invoice Date
            //chartRange = x1Worksheet.get_Range("d9", "d9");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;

            ////Invoice Amount
            //chartRange = x1Worksheet.get_Range("e9", "e9");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;

            ////Customer Name
            //chartRange = x1Worksheet.get_Range("f9", "f9");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;

            ////Job Name
            //chartRange = x1Worksheet.get_Range("g9", "g9");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;

            ////Project Number
            //chartRange = x1Worksheet.get_Range("h9", "h9");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;

            ////Project Name
            //chartRange = x1Worksheet.get_Range("i9", "i9");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;

            ////Estimated Or Actual
            //chartRange = x1Worksheet.get_Range("j9", "j9");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;

            ////Gross Profit
            //chartRange = x1Worksheet.get_Range("k9", "k9");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;

            ////Commission Type
            //chartRange = x1Worksheet.get_Range("l9", "l9");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;

            ////Commission Percentage
            //chartRange = x1Worksheet.get_Range("m9", "m9");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;

            ////Commissions
            //chartRange = x1Worksheet.get_Range("n9", "n9");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;

            ////Report Footer Formatting

            ////Totals
            //chartRange = x1Worksheet.get_Range("b25", "b25");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;

            ////Total Payments
            //chartRange = x1Worksheet.get_Range("c61", "c61");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;


            ////Total Gross Profit
            //chartRange = x1Worksheet.get_Range("k61", "k61");
            //chartRange.EntireColumn.AutoFit();            
            //chartRange.Font.Bold = true;

            ////Total Commissions
            //chartRange = x1Worksheet.get_Range("n61", "n61");
            //chartRange.EntireColumn.AutoFit();
            //chartRange.Font.Bold = true;


          



            ////chartRange = x1Worksheet.get_Range("b2", "nv"); //was n65
            ////chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            
            //releaseObject(x1Worksheet);
            //releaseObject(x1Workbook);
            //releaseObject(x1APP);

            //MessageBox.Show("Excel file created , you can find the file !");


        }

        




        private void cboJRCBut_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<DataRow> jnameRowsRemove = new List<DataRow>();
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            SqlConnection MySqlConn = new SqlConnection(connectionString);

            try
            {

                string commandString108 = ("SELECT cid FROM company WHERE company_name = '" + cboJRCBut.Text.ToString() + "'");
                SqlCommand mysqlcommand108 = new SqlCommand(commandString108, MySqlConn);

                        DataTable table108 = GetDataTable(
                            // Pass open database connection to function
               ref MySqlConn,
                            // Pass SQL statement to create SqlDataReader
               commandString108);
                
                txtrcid.DataBindings.Clear();
                txtrcid.DataBindings.Add(new Binding("Text", table108, "cid", true));


                cboJN.Items.Clear();


                string commandString109 = ("SELECT ALL job_name FROM job WHERE cid = '" + txtrcid.Text.Trim() + "'");
                SqlCommand mysqlcommand109 = new SqlCommand(commandString108, MySqlConn);

                DataTable table109 = GetDataTable(
                    // Pass open database connection to function
       ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
       commandString109);


                foreach (DataRow row3 in table109.Rows)
                {
                    if (row3["job_name"].ToString() == " ")
                    {
                        jnameRowsRemove.Add(row3);
                    }
                    else
                    {
                        String item = (row3["job_name"].ToString());                        
                        cboJN.Items.Add(item);
                        row3.Delete();

                    }
                }


       //         string commandString110 = ("SELECT jid FROM job WHERE job_name = '" + cboJN.Text.ToString() + "'");
       //         MySqlCommand mysqlcommand110 = new MySqlCommand(commandString110, MySqlConn);

       //         DataTable table110 = GetDataTable(
       //             // Pass open database connection to function
       //ref MySqlConn,
       //             // Pass SQL statement to create SqlDataReader
       //commandString110);

                
       //         txtrjid.DataBindings.Clear();
       //         txtrjid.DataBindings.Add(new Binding("Text", table110, "jid", true)); 


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }



        }


        private void cboJN_SelectedIndexChanged(object sender, EventArgs e)
        {


            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            SqlConnection MySqlConn = new SqlConnection(connectionString);

            try
            {

                string commandString110 = ("SELECT jid FROM job WHERE job_name = '" + cboJN.Text.ToString() + "'");
                SqlCommand mysqlcommand110 = new SqlCommand(commandString110, MySqlConn);

                DataTable table110 = GetDataTable(
                    // Pass open database connection to function
       ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
       commandString110);


                txtrjid.DataBindings.Clear();
                txtrjid.DataBindings.Add(new Binding("Text", table110, "jid", true));


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }





        }



        //job Report Button
        private void jRepBut_Click(object sender, EventArgs e)
        {
                       
            object[] myArray4 = new object[23];
            DataTable table104 = new DataTable();
            table104.Columns.Add(new DataColumn("project_number"));
            table104.Columns.Add(new DataColumn("project_name"));
            table104.Columns.Add(new DataColumn("billing_amt"));
            table104.Columns.Add(new DataColumn("paid_amt"));
            table104.Columns.Add(new DataColumn("chkd_actcost"));
            table104.Columns.Add(new DataColumn("project_actcost"));
            table104.Columns.Add(new DataColumn("est_gp"));
            table104.Columns.Add(new DataColumn("payact_gp"));           
            table104.Columns.Add(new DataColumn("estimator"));
            table104.Columns.Add(new DataColumn("estimator_percent"));
            table104.Columns.Add(new DataColumn("estimator_comm"));
            table104.Columns.Add(new DataColumn("salesperson"));
            table104.Columns.Add(new DataColumn("salesperson_percent"));
            table104.Columns.Add(new DataColumn("salesperson_comm"));
            table104.Columns.Add(new DataColumn("projectmgr"));
            table104.Columns.Add(new DataColumn("projectmgr_percent"));
            table104.Columns.Add(new DataColumn("projectmgr_comm"));
            table104.Columns.Add(new DataColumn("projectasst"));
            table104.Columns.Add(new DataColumn("projectasst_precent"));
            table104.Columns.Add(new DataColumn("projectasst_comm"));
            table104.Columns.Add(new DataColumn("dtgen"));
            table104.Columns.Add(new DataColumn("customer_name"));
            table104.Columns.Add(new DataColumn("job_name"));
            table104.Columns.Add(new DataColumn("total_paidAmt"));

            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            SqlConnection MySqlConn = new SqlConnection(connectionString);
            MySqlConn.Open();

            //Date Gen
            String dateGen;
            DateTime dateNow = DateTime.Now;
            dateGen = dateNow.ToString("MM/dd/yyyy");

            try
            {
       //         //this gets the paid total
       //         string commandString111 = ("SELECT SUM(paid_amt) FROM billing WHERE jid = '" + txtrjid.Text.Trim() + "'");
       //         MySqlCommand mysqlcommand111 = new MySqlCommand(commandString111, MySqlConn);
       //         DataTable table111 = GetDataTable(
       //             // Pass open database connection to function
       //ref MySqlConn,
       //             // Pass SQL statement to create SqlDataReader
       //commandString111);


       //         foreach (DataRow row in table111.Rows)
       //         {
       //             xy = (row["SUM(paid_amt)"].ToString());
       //         }
                 

                /////////////////////////////////
                //This is for the crystal report

                SqlDataAdapter adap4 = new SqlDataAdapter("SELECT project_number, project_name, billing_amt, paid_amt, chkd_actcost, project_actcost, est_gp, payact_gp, estimator, estimator_percent, estimator_comm, salesperson, salesperson_percent, salesperson_comm, projectmgr, projectmgr_percent, projectmgr_comm, projectasst, projectasst_percent, projectasst_comm FROM billing WHERE jid = '" + txtrjid.Text + "'", MySqlConn);
                DataSet dsJobRpt = new DataSet("DataTable4");
                adap4.Fill(dsJobRpt, "DataTable4");
                MySqlConn.Close();
                DataSet jobFill = new DataSet("DataTable4");

       //         string commandString111 = ("SELECT ALL project_number, project_name, SUM(billing_amt), SUM(paid_amt), chkd_actcost, project_actcost, est_gp, payact_gp, estimator, estimator_percent, estimator_comm, salesperson, salesperson_percent, salesperson_comm, projectmgr, projectmgr_percent, projectmgr_comm, projectasst, projectasst_percent, projectasst_comm FROM billing WHERE jid = '" + txtrjid.Text.Trim() + "'");
       //         MySqlCommand mysqlcommand111 = new MySqlCommand(commandString111, MySqlConn);

       //         DataTable table111 = GetDataTable(
       //             // Pass open database connection to function
       //ref MySqlConn,
       //             // Pass SQL statement to create SqlDataReader
       //commandString111);

                foreach (DataRow jb in dsJobRpt.Tables[0].Rows)
                {
                    myArray4[0] = jb.ItemArray[0];
                    myArray4[1] = jb.ItemArray[1];
                    myArray4[2] = jb.ItemArray[2];
                    myArray4[3] = jb.ItemArray[3];
                    String diff = jb.ItemArray[4].ToString();
                    if (diff == "T")
                    {
                        myArray4[4] = "Actual Cost";
                        myArray4[5] = jb.ItemArray[5];
                        myArray4[6] = " ";
                        myArray4[7] = jb.ItemArray[7];
                    }
                    else
                    {
                        myArray4[4] = "Estimated Cost";
                        myArray4[5] = " ";
                        myArray4[6] = jb.ItemArray[6];
                        myArray4[7] = " ";
                    }
                    myArray4[8] = jb.ItemArray[8];
                    myArray4[9] = jb.ItemArray[9];
                    myArray4[10] = jb.ItemArray[10];
                    myArray4[11] = jb.ItemArray[11];
                    myArray4[12] = jb.ItemArray[12];
                    myArray4[13] = jb.ItemArray[13];
                    myArray4[14] = jb.ItemArray[14];
                    myArray4[15] = jb.ItemArray[15];
                    myArray4[16] = jb.ItemArray[16];
                    myArray4[17] = jb.ItemArray[17];
                    myArray4[18] = jb.ItemArray[18];
                    myArray4[19] = jb.ItemArray[19];
                    myArray4[20] = dateGen.ToString();
                    myArray4[21] = cboJRCBut.Text.ToString();
                    myArray4[22] = cboJN.Text.ToString();
                    
                    DataRow jr;
                    jr = table104.NewRow();
                    jr.ItemArray = myArray4;
                    table104.Rows.Add(jr);
                    table104.AcceptChanges();

                }

                jobFill.Tables.Add(table104);
                var path4 = ("C:\\Users\\Darren\\Documents\\Visual Studio 2010\\Projects\\CommissionDBApplication\\WindowsFormsApplication1\\jobRep.rpt");                
                jobRep Rpt4 = new jobRep();
                Rpt4.Load(path4);

                Rpt4.SetDataSource(jobFill.Tables[0]);
                crystalReportViewer1.ReportSource = Rpt4;


                //Export to PDF code
                String dte = DateTime.Now.ToString();
                String r = dte.Replace("/", "_");
                String u = r.Remove(9);
                String date = u.ToString();
                String month = date;

                ExportOptions RepExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                if (month[0].ToString() == "1")
                {
                    CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\January\\JobReport '" + cboJRCBut.Text.ToString() + "'' _ ''" + cboJN.Text.ToString() + "' '" + date + "' .pdf";
                }
                else if (month[0].ToString() == "2")
                {
                    CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\February\\JobReport '" + cboJRCBut.Text.ToString() + "'' _ ''" + cboJN.Text.ToString() + "' '" + date + "' .pdf";
                }
                else if (month[0].ToString() == "3")
                {
                    CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\March\\JobReport '" + cboJRCBut.Text.ToString() + "'' _ ''" + cboJN.Text.ToString() + "' '" + date + "' .pdf";
                }
                else if (month[0].ToString() == "4")
                {
                    CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\April\\JobReport '" + cboJRCBut.Text.ToString() + "'' _ ''" + cboJN.Text.ToString() + "' '" + date + "' .pdf";
                }
                else if (month[0].ToString() == "5")
                {
                    CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\May\\JobReport '" + cboJRCBut.Text.ToString() + "'' _ ''" + cboJN.Text.ToString() + "' '" + date + "' .pdf";
                }
                else if (month[0].ToString() == "6")
                {
                    CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\June\\JobReport '" + cboJRCBut.Text.ToString() + "'' _ ''" + cboJN.Text.ToString() + "' '" + date + "' .pdf";
                }
                else if (month[0].ToString() == "7")
                {
                    CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\July\\JobReport '" + cboJRCBut.Text.ToString() + "'' _ ''" + cboJN.Text.ToString() + "' '" + date + "' .pdf";
                }
                else if (month[0].ToString() == "8")
                {
                    CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\August\\JobReport '" + cboJRCBut.Text.ToString() + "'' _ ''" + cboJN.Text.ToString() + "' '" + date + "' .pdf";
                }
                else if (month[0].ToString() == "9")
                {
                    CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\September\\JobReport '" + cboJRCBut.Text.ToString() + "'' _ ''" + cboJN.Text.ToString() + "' '" + date + "' .pdf";
                }
                else if (month[1].ToString() == "0")
                {
                    CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\October\\JobReport '" + cboJRCBut.Text.ToString() + "'' _ ''" + cboJN.Text.ToString() + "' '" + date + "' .pdf";
                }
                else if (month[1].ToString() == "1")
                {
                    CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\November\\JobReport '" + cboJRCBut.Text.ToString() + "'' _ ''" + cboJN.Text.ToString() + "' '" + date + "' .pdf";
                }
                else if (month[1].ToString() == "2")
                {
                    CrDiskFileDestinationOptions.DiskFileName = "C:\\Reports\\December\\JobReport '" + cboJRCBut.Text.ToString() + "'' _ ''" + cboJN.Text.ToString() + "' '" + date + "' .pdf";
                }
                //CrDiskFileDestinationOptions.DiskFileName = "C:\\Users\\Darren\\Desktop\\360 TEST XLS EXPORT\\JobReport '" + cboJRCBut.Text.ToString() + "'' _ ''" + cboJN.Text.ToString() + "' '" + date + "' .pdf";//"//"C:\\Reports\\JobReport '" + cboJRCBut.Text.ToString() + "'' _ ''" + cboJN.Text.ToString() + "' '" + date + "' .pdf";
                RepExportOptions = Rpt4.ExportOptions;
                RepExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                RepExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                RepExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                RepExportOptions.FormatOptions = CrFormatTypeOptions;
                Rpt4.Export();

                //Excel code Start here***************************************************************************************************

                //Excel.Application x1APP;
                //Excel.Workbook x1Workbook;
                //Excel.Worksheet x1Worksheet;
                //object misValue = System.Reflection.Missing.Value;
                //Excel.Range chartRange;

                //x1APP = new Excel.Application();
                //x1APP.Visible = true;
                //x1Workbook = x1APP.Workbooks.Add(misValue);

                //x1Worksheet = (Excel.Worksheet)x1Workbook.Worksheets.get_Item(1);

                //foreach (DataRow row in table111.Rows)
                //{

                //    int b = 10;
                //    x1Worksheet.Cells[b, 2] = (row[0].ToString());
                //    x1Worksheet.Cells[b, 3] = (row[1].ToString());
                //    x1Worksheet.Cells[b, 4] = (row[2].ToString());
                //    x1Worksheet.Cells[b, 5] = (row[3].ToString());
                //    string diff = (row[4].ToString());
                //    if (diff == "T")
                //    {
                //        x1Worksheet.Cells[b, 6] = "Actual Cost";
                //        x1Worksheet.Cells[b, 7] = (row[3].ToString());
                //        x1Worksheet.Cells[b, 8] = (row[7].ToString());
                //    }
                //    else
                //    {
                //        x1Worksheet.Cells[b, 6] = "Estimated Cost";
                //        x1Worksheet.Cells[b, 7] = "NA";
                //        x1Worksheet.Cells[b, 8] = (row[6].ToString());

                //    }
                    
                    
                    
                    
                //    x1Worksheet.Cells[b, 9] = (row[8].ToString());
                //    x1Worksheet.Cells[b, 10] = (row[9].ToString());
                //    x1Worksheet.Cells[b, 11] = (row[10].ToString()); 
                //    x1Worksheet.Cells[b, 12] = (row[11].ToString());
                //    x1Worksheet.Cells[b, 13] = (row[12].ToString());
                //    x1Worksheet.Cells[b, 14] = (row[13].ToString());
                //    x1Worksheet.Cells[b, 15] = (row[14].ToString());
                //    x1Worksheet.Cells[b, 16] = (row[15].ToString());
                //    x1Worksheet.Cells[b, 17] = (row[16].ToString());
                //    x1Worksheet.Cells[b, 18] = (row[17].ToString());
                //    x1Worksheet.Cells[b, 19] = (row[18].ToString());
                //    x1Worksheet.Cells[b, 20] = (row[19].ToString());

                //}




                ////Report Header%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

                //x1Worksheet.get_Range("b2", "e3").Merge(false);

                //chartRange = x1Worksheet.get_Range("b2", "e3");
                //chartRange.FormulaR1C1 = "COMMISSION REPORT INDIVIDUAL";
                //chartRange.Font.Bold = true;
                //chartRange.Interior.Color = System.Drawing.Color.LightGray;
                ////chartRa = System.Drawing.Color.LightGray;            
                //chartRange.HorizontalAlignment = 6;
                //chartRange.VerticalAlignment = 3;
                ////Dates Generated 
                //chartRange = x1Worksheet.get_Range("b4", "b4");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;
                ////Customer Name
                //chartRange = x1Worksheet.get_Range("b5", "b5");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;
                ////Job Name
                //chartRange = x1Worksheet.get_Range("b6", "b6");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;


                //x1Worksheet.Cells[4, 2] = " Date Generated: ";
                //x1Worksheet.Cells[4, 3] = DateTime.Now;
                //x1Worksheet.Cells[5, 2] = " Customer  ";
                //x1Worksheet.Cells[5, 3] = cboJRCBut.Text.ToString();
                //x1Worksheet.Cells[6, 2] = " Job Name ";
                //x1Worksheet.Cells[6, 3] = cboJN.Text.ToString();

                ////Column HEaders
                //x1Worksheet.Cells[9, 2] = " Project #    ";
                //x1Worksheet.Cells[9, 3] = " Project Name  ";
                //x1Worksheet.Cells[9, 4] = " Total Billing    ";
                //x1Worksheet.Cells[9, 5] = " Total Payment  ";
                //x1Worksheet.Cells[9, 6] = " Estimated or Actual  ";
                //x1Worksheet.Cells[9, 7] = " Total Cost        ";
                //x1Worksheet.Cells[9, 8] = " Total GP        ";
                //x1Worksheet.Cells[9, 9] = " Estimator       ";
                //x1Worksheet.Cells[9, 10] = " Estimator Commission Percentage   ";
                //x1Worksheet.Cells[9, 11] = " Estimator Commission    ";
                //x1Worksheet.Cells[9, 12] = " Salesperson     ";
                //x1Worksheet.Cells[9, 13] = " Salesperson Commission Percentage ";
                //x1Worksheet.Cells[9, 14] = " Salesperson Commission  ";
                //x1Worksheet.Cells[9, 15] = " Project Manager ";
                //x1Worksheet.Cells[9, 16] = " PM Commission Percentage          ";
                //x1Worksheet.Cells[9, 17] = " PM Commission   ";
                //x1Worksheet.Cells[9, 18] = " Project Assistant        ";
                //x1Worksheet.Cells[9, 19] = " PA Commission Percentage          ";
                //x1Worksheet.Cells[9, 20] = " PA Commission   ";




                ////Column Header Formatting
                ////Project Number
                //chartRange = x1Worksheet.get_Range("b9", "b9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;

                ////Project Name
                //chartRange = x1Worksheet.get_Range("c9", "c9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;

                ////Total Billing
                //chartRange = x1Worksheet.get_Range("d9", "d9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;

                ////Total Payment
                //chartRange = x1Worksheet.get_Range("e9", "e9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;

                ////Estimated or Actual
                //chartRange = x1Worksheet.get_Range("f9", "f9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;

                ////Total Cost
                //chartRange = x1Worksheet.get_Range("g9", "g9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;

                ////Total GP
                //chartRange = x1Worksheet.get_Range("h9", "h9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;

                ////Estimator
                //chartRange = x1Worksheet.get_Range("i9", "i9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;

                ////Estimator Percent
                //chartRange = x1Worksheet.get_Range("j9", "j9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;

                ////Estimator Comm
                //chartRange = x1Worksheet.get_Range("k9", "k9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;

                ////SP
                //chartRange = x1Worksheet.get_Range("l9", "l9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;

                ////SP Percent
                //chartRange = x1Worksheet.get_Range("m9", "m9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;


                ////SP Commission 
                //chartRange = x1Worksheet.get_Range("n9", "n9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;

                ////PM
                //chartRange = x1Worksheet.get_Range("o9", "o9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;

                ////PM Percent
                //chartRange = x1Worksheet.get_Range("p9", "p9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;

                ////PM Commission
                //chartRange = x1Worksheet.get_Range("q9", "q9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;

                ////PA
                //chartRange = x1Worksheet.get_Range("r9", "r9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;

                ////PA Percent
                //chartRange = x1Worksheet.get_Range("s9", "s9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;

                ////PA Commission
                //chartRange = x1Worksheet.get_Range("t9", "t9");
                //chartRange.EntireColumn.AutoFit();
                //chartRange.Font.Bold = true;



                //chartRange = x1Worksheet.get_Range("b2", "u21");
                //chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);

                //releaseObject(x1Worksheet);
                //releaseObject(x1Workbook);
                //releaseObject(x1APP);

                //MessageBox.Show("Excel file created , you can find the file !");



            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }





        //Release object for reports
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        

        

        

        

        

        



    }
}
