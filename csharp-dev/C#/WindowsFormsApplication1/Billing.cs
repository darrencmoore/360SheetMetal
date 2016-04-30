using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel =  Microsoft.Office.Interop.Excel;
using System.Configuration;
using System.Globalization;






namespace WindowsFormsApplication1
{
    public partial class Billing : Form
    {
        public static string token24;
        public static string token25;
        public static string token26;
        public static string token27;
        public static string token28;
        public static string token29;
        public static string token30;
        public static string t;
        public static string holder;


        public Billing()
        {
            InitializeComponent();            
            txtbpid.Text = Projects.token3;
            txtbpjtnum.Text = Projects.token4;
            txtbestcomm.Text = Projects.token5;
            txtbspcomm.Text = Projects.token6;
            txtbpgtmgrcomm.Text = Projects.token7;
            txtbpjtpacomm.Text = Projects.token8;
            txtbjid.Text = Projects.token9;
            cbobestperson.Text = Projects.token10;
            //txtbestname.Text = Projects.token10;
            cbobsperson.Text = Projects.token11;
            //txtbsperson.Text = Projects.token11;
            cbobpm.Text = Projects.token12;
            //txtbprgmgr.Text = Projects.token12;
            cbobpa.Text = Projects.token13;
            //txtbpa.Text = Projects.token13;
            txtBPrjDesc.Text = Projects.token16;
            txtbcid.Text = Projects.token23;
            txtbpjtname.Text = Projects.token30;
             
            
        }

        BindingSource bs = new BindingSource();
        public DataTable GetDataTable(
        ref MySql.Data.MySqlClient.MySqlConnection _SqlConnection,
        string _SQL)
        {
            // Pass the connection to a command object
            MySql.Data.MySqlClient.MySqlCommand _SqlCommand =
                            new MySql.Data.MySqlClient.MySqlCommand(_SQL, _SqlConnection);
            MySql.Data.MySqlClient.MySqlDataAdapter _SqlDataAdapter
                            = new MySql.Data.MySqlClient.MySqlDataAdapter();
            _SqlDataAdapter.SelectCommand = _SqlCommand;

            DataTable _DataTable = new DataTable();
            _DataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;

            // Adds or refreshes rows in the DataSet to match those in the data source
            try
            {
                _SqlDataAdapter.Fill(_DataTable);
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


        //Form load for the billing section
        private void Billing_Load(object sender, EventArgs e)
        {
            List<DataRow> estRowsRemove = new List<DataRow>();
            List<DataRow> spRowsRemove = new List<DataRow>();
            List<DataRow> pmRowsRemove = new List<DataRow>();
            List<DataRow> paRowsRemove = new List<DataRow>();
            List<DataRow> billingNumsRemove = new List<DataRow>();
            //List<DataRow> unPaidBill = new List<DataRow>();
            

            txtbpjtnum.Enabled = false;
            txtbpjtname.Enabled = false;
            cbobillingnum.Enabled = false;
            txtbillingamt.Enabled = false;
            mskdtxtbillingDate.Enabled = false;
            txtPaidAmt.Enabled = false;
            mskdtxtpaidDate.Enabled = false;
            cbobestperson.Enabled = false;
            //txtbestname.Enabled = false;
            txtbestcomm.Enabled = false;
            txtbestpaidcomm.Enabled = false;
            cbobsperson.Enabled = false;
            //txtbsperson.Enabled = false;
            txtbspcomm.Enabled = false;
            txtbspcommpaid.Enabled = false;
            cbobpm.Enabled = false;
            //txtbprgmgr.Enabled = false;
            txtbpgtmgrcomm.Enabled = false;
            txtbpmcommpaid.Enabled = false;
            cbobpa.Enabled = false;
            //txtbpa.Enabled = false;
            txtbpjtpacomm.Enabled = false;
            txtbpacommpaid.Enabled = false;


            //populates the datagridview with billing statements
            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(connectionString);


            try
            {



                //**************************************THis command populates the estimator drop down
                string commandString31 = ("SELECT ALL psname FROM projectstaff");
                MySqlCommand mysqlcommand = new MySqlCommand(commandString31, MySqlConn);

                DataTable table = GetDataTable(
                    // Pass open database connection to function
            ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
            commandString31);
                // TODO: This line of code loads data into the 'commissionrepoDataSet1.company' table. You can move, or remove it, as needed.
                //this.companyTableAdapter3.Fill(this.commissionrepoDataSet1.company);



                foreach (DataRow row in table.Rows)
                {
                    if (row["psname"].ToString() == " ")
                    {
                        estRowsRemove.Add(row);
                    }
                    else
                    {
                        String item = (row["psname"].ToString());
                        cbobestperson.Items.Add(item);
                        //cbopjsestr.Items.Add(item);
                        row.Delete();

                    }
                }


            //    //*******************************************************This command populates the salesperson drop down box
                string commandString32 = ("SELECT ALL psname FROM projectstaff");
                MySqlCommand mysqlcommand32 = new MySqlCommand(commandString32, MySqlConn);

                DataTable table32 = GetDataTable(
                    // Pass open database connection to function
            ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
            commandString32);
                // TODO: This line of code loads data into the 'commissionrepoDataSet1.company' table. You can move, or remove it, as needed.
                //this.companyTableAdapter3.Fill(this.commissionrepoDataSet1.company);

                foreach (DataRow row in table32.Rows)
                {
                    if (row["psname"].ToString() == " ")
                    {
                        spRowsRemove.Add(row);
                    }
                    else
                    {
                        String item = (row["psname"].ToString());
                        cbobsperson.Items.Add(item);
                        //cbopjssp.Items.Add(item);
                        row.Delete();

                    }
                }


            //    //***********************************************************This command populates the project manager drop down box
                string commandString33 = ("SELECT ALL psname FROM projectstaff");
                MySqlCommand mysqlcommand33 = new MySqlCommand(commandString33, MySqlConn);

                DataTable table33 = GetDataTable(
                    // Pass open database connection to function
            ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
            commandString33);
                // TODO: This line of code loads data into the 'commissionrepoDataSet1.company' table. You can move, or remove it, as needed.
                //this.companyTableAdapter3.Fill(this.commissionrepoDataSet1.company);

                foreach (DataRow row in table33.Rows)
                {
                    if (row["psname"].ToString() == " ")
                    {
                        pmRowsRemove.Add(row);
                    }
                    else
                    {
                        String item = (row["psname"].ToString());
                        cbobpm.Items.Add(item);
                        //cboprjpm.Items.Add(item);
                        row.Delete();

                    }
                }


            //    //***************************************************This command populates the project assistant screen
                string commandString34 = ("SELECT ALL psname FROM projectstaff");
                MySqlCommand mysqlcommand34 = new MySqlCommand(commandString34, MySqlConn);

                DataTable table34 = GetDataTable(
                    // Pass open database connection to function
            ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
            commandString34);
                // TODO: This line of code loads data into the 'commissionrepoDataSet1.company' table. You can move, or remove it, as needed.
                //this.companyTableAdapter3.Fill(this.commissionrepoDataSet1.company);

                foreach (DataRow row in table34.Rows)
                {
                    if (row["psname"].ToString() == " ")
                    {
                        paRowsRemove.Add(row);
                    }
                    else
                    {
                        String item = (row["psname"].ToString());
                        cbobpa.Items.Add(item);
                        //cbopjpa.Items.Add(item);
                        row.Delete();

                    }
                }


                //This is the statement to check if actual cost is being used
                //********************************************************************************************************************************************
                string commandString77 = ("SELECT chkd_actcost FROM projects WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");
                MySqlCommand mysqlcommand77 = new MySqlCommand(commandString77, MySqlConn);

                DataTable table77 = GetDataTable(
                    // Pass open database connection to function
       ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
       commandString77);


                foreach (DataRow dz in table77.Rows)
                {
                    if (dz["chkd_actcost"].ToString() == "T")
                    {
                       

                       string commandString87 = ("SELECT assigned_estimator, estimator_percentage, estr_tl_paid, assigned_salesperson, salesperson_percentage, sp_tl_paid, assigned_pm, pm_percentage, pm_tl_paid, assigned_pa, pa_percentage, pa_tl_paid, prj_actcost, payact_gp, prj_saleamt FROM assignedps WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");// ORDER by act_tl_paiddate desc LIMIT 1");
                       MySqlCommand mysqlcommand87 = new MySqlCommand(commandString87, MySqlConn);

                       DataTable table87 = GetDataTable(
                           // Pass open database connection to function
              ref MySqlConn,
                           // Pass SQL statement to create SqlDataReader
              commandString87);




                       cbobestperson.DataBindings.Clear();
                       cbobestperson.DataBindings.Add(new Binding("Text", table87, "assigned_estimator", true));
                       txtbestcomm.DataBindings.Clear();
                       txtbestcomm.DataBindings.Add(new Binding("Text", table87, "estimator_percentage", true));
                       txtbestpaidcomm.DataBindings.Clear();
                       txtbestpaidcomm.DataBindings.Add(new Binding("Text", table87, "estr_tl_paid", true));
                       cbobsperson.DataBindings.Clear();
                       cbobsperson.DataBindings.Add(new Binding("Text", table87, "assigned_salesperson", true));
                       txtbspcomm.DataBindings.Clear();
                       txtbspcomm.DataBindings.Add(new Binding("Text", table87, "salesperson_percentage", true));
                       txtbspcommpaid.DataBindings.Clear();
                       txtbspcommpaid.DataBindings.Add(new Binding("Text", table87, "sp_tl_paid", true));
                       cbobpm.DataBindings.Clear();
                       cbobpm.DataBindings.Add(new Binding("Text", table87, "assigned_pm", true));
                       txtbpgtmgrcomm.DataBindings.Clear();
                       txtbpgtmgrcomm.DataBindings.Add(new Binding("Text", table87, "pm_percentage", true));
                       txtbpmcommpaid.DataBindings.Clear();
                       txtbpmcommpaid.DataBindings.Add(new Binding("Text", table87, "pm_tl_paid", true));
                       cbobpa.DataBindings.Clear();
                       cbobpa.DataBindings.Add(new Binding("Text", table87, "assigned_pa", true));
                       txtbpjtpacomm.DataBindings.Clear();
                       txtbpjtpacomm.DataBindings.Add(new Binding("Text", table87, "pa_percentage", true));
                       txtbpacommpaid.DataBindings.Clear();
                       txtbpacommpaid.DataBindings.Add(new Binding("Text", table87, "pa_tl_paid", true));
                       txtbpactcost.DataBindings.Clear();
                       txtbpactcost.DataBindings.Add(new Binding("Text", table87, "prj_actcost", true));
                       txtActGP.DataBindings.Clear();
                       txtActGP.DataBindings.Add(new Binding("Text", table87, "payact_gp", true));
                       txtbpsaleamt.DataBindings.Clear();
                       txtbpsaleamt.DataBindings.Add(new Binding("Text", table87, "prj_saleamt", true));
                       



                        string commandString88 = ("SELECT bid, project_number, project_name, billing_num, billing_amt, billing_date, paid_amt, paid_date, estimator, estimator_percent, estimator_comm, salesperson, salesperson_percent, salesperson_comm, projectmgr, projectmgr_percent, projectmgr_comm, projectasst, projectasst_percent, projectasst_comm, project_saleamt, project_estcost, project_description, project_actcost, payest_gp, payest_cost, est_gp, payact_gp, act_estrtl_paid, act_sptl_paid, act_pmtl_paid, act_patl_paid, chkd_actcost, chkd_calc FROM billing WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");//, AND jid = '" + txtbjid.Text + "'");
                        MySqlCommand mysqlcommand88 = new MySqlCommand(commandString88, MySqlConn);

                        DataTable table88 = GetDataTable(
                            // Pass open database connection to function
               ref MySqlConn,
                            // Pass SQL statement to create SqlDataReader
               commandString88);

                       
                        dataGridView1.DataSource = table88;
                        dataGridView1.Refresh();

                        foreach (DataRow jm in table88.Rows)
                        {

                            if (jm["chkd_calc"].ToString() == "Y")
                            {
                                jm.EndEdit();
                                //MessageBox.Show("WEre are here!");

                            }
                        }

                        chbkestcost.Enabled = false;
                        txtbpestcost.Enabled = false;
                        txtPayEstCost.Enabled = false;
                        chbkactualcost.Checked = true;
                        chbkactualcost.Enabled = false;
                        txtbpjtnum.Enabled = true;
                        txtbpjtname.Enabled = true;
                        cbobillingnum.Enabled = true;
                        cbobestperson.Enabled = true;
                        txtbestcomm.Enabled = true;
                        txtbestpaidcomm.Enabled = true;
                        cbobsperson.Enabled = true;
                        txtbspcomm.Enabled = true;
                        txtbspcommpaid.Enabled = true;
                        cbobpm.Enabled = true;
                        txtbpgtmgrcomm.Enabled = true;
                        txtbpmcommpaid.Enabled = true;
                        cbobpa.Enabled = true;
                        txtbpjtpacomm.Enabled = true;
                        txtbpacommpaid.Enabled = true;
                        txtbpactcost.Enabled = true;
                        txtActGP.Enabled = true;
                        txtbpsaleamt.Enabled = true;
                        txtbillingamt.Enabled = true;
                        mskdtxtbillingDate.Enabled = true;
                        txtPaidAmt.Enabled = true;
                        mskdtxtpaidDate.Enabled = true;
                        break;


                    }
                    else
                    {

                        string commandString2 = ("SELECT bid, project_name, project_number, billing_num, billing_amt, billing_date, paid_amt, paid_date, estimator, estimator_percent, estimator_comm, salesperson, salesperson_percent, salesperson_comm, projectmgr, projectmgr_percent, projectmgr_comm, projectasst, projectasst_percent, projectasst_comm, project_saleamt, project_estcost, project_description, project_actcost, payest_gp, payest_cost, est_gp, payact_gp, chkd_actcost, paid_stmt, chkd_calc FROM billing WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");//, AND jid = '" + txtbjid.Text + "'");
                        MySqlCommand mysqlcommand2 = new MySqlCommand(commandString2, MySqlConn);

                        DataTable table2 = GetDataTable(
                            // Pass open database connection to function
               ref MySqlConn,
                            // Pass SQL statement to create SqlDataReader
               commandString2);

                        foreach (DataRow jm in table2.Rows)
                        {

                            if (jm["chkd_calc"].ToString() == "Y")
                            {
                                jm.EndEdit();
                                

                            }
                        }

                        //foreach (DataRow az in table77.Rows)
                        //{
                        //    if (az["chkd_actcost"].ToString() == "T")
                        //    {
                        //        chbkestcost.Enabled = false;
                        //        txtbpestcost.Enabled = false;
                        //        txtPayEstCost.Enabled = false;
                        //        chbkactualcost.Checked = true;
                        //        chbkactualcost.Enabled = false;
                        //        break;
                        //    }
                        //}

                        txtbpsaleamt.DataBindings.Clear();
                        txtbpsaleamt.DataBindings.Add(new Binding("Text", table2, "project_saleamt", true));
                        txtbpestcost.DataBindings.Clear();
                        txtbpestcost.DataBindings.Add(new Binding("Text", table2, "project_estcost", true));
                        txtbpactcost.DataBindings.Clear();
                        txtbpactcost.DataBindings.Add(new Binding("Text", table2, "project_actcost", true));
                        dataGridView1.DataSource = table2;
                        dataGridView1.Refresh();


                        //this clears the screen on entry
                        //txtbestcomm.Text = " ";
                        //txtbspcomm.Text = " ";
                        //txtbpgtmgrcomm.Text = " ";
                        //txtbpjtpacomm.Text = " ";
                        //cbobestperson.Text = " ";
                        //txtPaidAmt.Text = " ";
                        //txtbestname.Text = " ";
                        //cbobsperson.Text = " ";
                        //txtbsperson.Text = " ";
                        //cbobpm.Text = " ";
                        //txtbprgmgr.Text = " ";
                        // cbobpa.Text = " ";
                        //txtbpa.Text = " ";

                        txtbpjtnum.Enabled = true;
                        txtbpjtname.Enabled = true;
                        cbobillingnum.Enabled = true;
                        txtbillingamt.Enabled = true;
                        mskdtxtbillingDate.Enabled = true;
                        txtPaidAmt.Enabled = true;
                        mskdtxtpaidDate.Enabled = true;
                        cbobestperson.Enabled = true;
                        //txtbestname.Enabled = true;
                        txtbestcomm.Enabled = true;
                        txtbestpaidcomm.Enabled = true;
                        cbobsperson.Enabled = true;
                        //txtbsperson.Enabled = true;
                        txtbspcomm.Enabled = true;
                        txtbspcommpaid.Enabled = true;
                        cbobpm.Enabled = true;
                        //txtbprgmgr.Enabled = true;
                        txtbpgtmgrcomm.Enabled = true;
                        txtbpmcommpaid.Enabled = true;
                        cbobpa.Enabled = true;
                        //txtbpa.Enabled = true;
                        txtbpjtpacomm.Enabled = true;
                        txtbpacommpaid.Enabled = true;
                    }
                }



                //This updates the combo box with billing statements
                string commandString21 = ("SELECT billing_num FROM billing WHERE pid = '" + txtbpid.Text.Trim() + "'");
                MySqlCommand mysqlcommand21 = new MySqlCommand(commandString21, MySqlConn);

                DataTable table21 = GetDataTable(
                    // Pass open database connection to function
       ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
       commandString21);

                cbounpbill.Items.Clear();

                foreach (DataRow row in table21.Rows)
                {
                    if (row["billing_num"].ToString() == " ")
                    {
                        billingNumsRemove.Add(row);
                    }
                    else
                    {
                        String item = (row["billing_num"].ToString());
                        cbounpbill.Items.Add(item);
                        row.Delete();
                    }

                }




                //foreach (DataGridViewRow row in dataGridView1.Rows)
                //{
                //    if (row.Cells["paid_stmt"].Value.ToString() == "N")
                //    {
                //        row.DefaultCellStyle.BackColor = Color.Yellow;
                //    }
                //    //if(row.Cells[5].Value - DateTime.Today > '30'
                //}


                


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (chbkactualcost.Checked == true)
            {
                txtbid.Text = (String)dataGridView1["bid", e.RowIndex].Value.ToString();
                cbobillingnum.Text = (String)dataGridView1["billing_num", e.RowIndex].Value.ToString();
                txtbillingamt.Text = (String)dataGridView1["billing_amt", e.RowIndex].Value.ToString();
                mskdtxtbillingDate.Text = (String)dataGridView1["billing_date", e.RowIndex].Value.ToString();
                txtPaidAmt.Text = (String)dataGridView1["paid_amt", e.RowIndex].Value.ToString();
                mskdtxtpaidDate.Text = (String)dataGridView1["paid_date", e.RowIndex].Value.ToString();
                //MessageBox.Show("Text Fields cannot be edited when on actual cost!");
                //return;
            }
            else
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                txtbid.Text = (String)dataGridView1["bid", e.RowIndex].Value.ToString();
                txtbpjtnum.Text = (String)dataGridView1["project_number", e.RowIndex].Value.ToString();
                txtbpjtname.Text = (String)dataGridView1["project_name", e.RowIndex].Value.ToString();
                cbobillingnum.Text = (String)dataGridView1["billing_num", e.RowIndex].Value.ToString();
                txtbillingamt.Text = (String)dataGridView1["billing_amt", e.RowIndex].Value.ToString();
                mskdtxtbillingDate.Text = (String)dataGridView1["billing_date", e.RowIndex].Value.ToString();
                txtPaidAmt.Text = (String)dataGridView1["paid_amt", e.RowIndex].Value.ToString();
                mskdtxtpaidDate.Text = (String)dataGridView1["paid_date", e.RowIndex].Value.ToString();
                cbobestperson.Text = (String)dataGridView1["estimator", e.RowIndex].Value.ToString();
                //txtbestname.Text = (String)dataGridView1["estimator", e.RowIndex].Value.ToString();
                txtbestcomm.Text = (String)dataGridView1["estimator_percent", e.RowIndex].Value.ToString();
                txtbestpaidcomm.Text = (String)dataGridView1["estimator_comm", e.RowIndex].Value.ToString();
                cbobsperson.Text = (String)dataGridView1["salesperson", e.RowIndex].Value.ToString();
                //txtbsperson.Text = (String)dataGridView1["salesperson", e.RowIndex].Value.ToString();
                txtbspcomm.Text = (String)dataGridView1["salesperson_percent", e.RowIndex].Value.ToString();
                txtbspcommpaid.Text = (String)dataGridView1["salesperson_comm", e.RowIndex].Value.ToString();
                cbobpm.Text = (String)dataGridView1["projectmgr", e.RowIndex].Value.ToString();
                //txtbprgmgr.Text = (String)dataGridView1["projectmgr", e.RowIndex].Value.ToString();
                txtbpgtmgrcomm.Text = (String)dataGridView1["projectmgr_percent", e.RowIndex].Value.ToString();
                txtbpmcommpaid.Text = (String)dataGridView1["projectmgr_comm", e.RowIndex].Value.ToString();
                cbobpa.Text = (String)dataGridView1["projectasst", e.RowIndex].Value.ToString();
                //txtbpa.Text = (String)dataGridView1["projectasst", e.RowIndex].Value.ToString();
                txtbpjtpacomm.Text = (String)dataGridView1["projectasst_percent", e.RowIndex].Value.ToString();
                txtbpacommpaid.Text = (String)dataGridView1["projectasst_comm", e.RowIndex].Value.ToString();
                //chbkestcost.Text = (String)dataGridView1["estimated_cost", e.RowIndex].Value.ToString();
                txtbpsaleamt.Text = (String)dataGridView1["project_saleamt", e.RowIndex].Value.ToString();
                txtbpestcost.Text = (String)dataGridView1["project_estcost", e.RowIndex].Value.ToString();
                txtbpactcost.Text = (String)dataGridView1["project_actcost", e.RowIndex].Value.ToString();
                txtBPrjDesc.Text = (String)dataGridView1["project_description", e.RowIndex].Value.ToString();
                txtPayEstGP.Text = (String)dataGridView1["payest_gp", e.RowIndex].Value.ToString();
                txtPayEstCost.Text = (String)dataGridView1["payest_cost", e.RowIndex].Value.ToString();
                txtbestgp.Text = (String)dataGridView1["est_gp", e.RowIndex].Value.ToString();
                txtActGP.Text = (String)dataGridView1["payact_gp", e.RowIndex].Value.ToString();

                //this converts the billing date from mysql date to normal date
                //comes in as '10/25/2011THH:mm:ss tt' month day year
                //needs to be 'MM/DD/yyyy' month-day-year
                if (mskdtxtbillingDate.Text != string.Empty)
                {
                    String bdate = mskdtxtbillingDate.Text;
                    DateTime dt = DateTime.Parse(bdate);
                    mskdtxtbillingDate.Text = dt.ToString("MM/dd/yyyy");
                }

                //this converts the paid date from mysql date to normal date
                //comes in as '10/25/2011THH:mm:ss tt' month day year
                //needs to be 'MM/DD/yyyy' month-day-year
                if (mskdtxtpaidDate.Text != string.Empty)
                {
                    
                    String zdate = mskdtxtpaidDate.Text;
                    DateTime at = DateTime.Parse(zdate);
                    mskdtxtpaidDate.Text = at.ToString("MM/dd/yyyy");
                    if (mskdtxtpaidDate.Text == "01/01/0001")
                    {
                        mskdtxtpaidDate.Clear();
                    }
                }


            }
           


        }



        //Clears all text boxes except the estr, sp, pm, pa and there comm %
        private void insrtbillingbut_Click(object sender, EventArgs e)
        {

            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(connectionString);


             try
             {

                 string commandString22 = ("SELECT assigned_estimator, estimator_percentage, assigned_salesperson, salesperson_percentage, assigned_pm, pm_percentage, assigned_pa, pa_percentage FROM assignedps WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");
                 MySqlCommand mysqlcommand22 = new MySqlCommand(commandString22, MySqlConn);

                 DataTable table22 = GetDataTable(
                     // Pass open database connection to function
             ref MySqlConn,
                     // Pass SQL statement to create SqlDataReader
             commandString22);

                 cbobestperson.DataBindings.Clear();
                 cbobestperson.DataBindings.Add(new Binding("Text", table22, "assigned_estimator", true));
                 txtbestcomm.DataBindings.Clear();
                 txtbestcomm.DataBindings.Add(new Binding("Text", table22, "estimator_percentage", true));
                 cbobsperson.DataBindings.Clear();
                 cbobsperson.DataBindings.Add(new Binding("Text", table22, "assigned_salesperson", true));
                 txtbspcomm.DataBindings.Clear();
                 txtbspcomm.DataBindings.Add(new Binding("Text", table22, "salesperson_percentage", true));
                 cbobpm.DataBindings.Clear();
                 cbobpm.DataBindings.Add(new Binding("Text", table22, "assigned_pm", true));
                 txtbpgtmgrcomm.DataBindings.Clear();
                 txtbpgtmgrcomm.DataBindings.Add(new Binding("Text", table22, "pm_percentage", true));
                 cbobpa.DataBindings.Clear();
                 cbobpa.DataBindings.Add(new Binding("Text", table22, "assigned_pa", true));
                 txtbpjtpacomm.DataBindings.Clear();
                 txtbpjtpacomm.DataBindings.Add(new Binding("Text", table22, "pa_percentage", true));




                 chbkestcost.Checked = false;
                 cbobillingnum.Text = " ";
                 txtbillingamt.Text = " ";
                 mskdtxtbillingDate.Text = " ";
                 txtPaidAmt.Text = " ";
                 mskdtxtpaidDate.Clear();
                 //cbobestperson.Text = " ";
                 //txtbestname.Text = " ";
                 //txtbestcomm.Text = " ";
                 txtbestpaidcomm.Text = " ";
                 //cbobsperson.Text = " ";
                 //txtbsperson.Text = " ";
                 //txtbspcomm.Text = " ";
                 txtbspcommpaid.Text = " ";
                 //cbobpm.Text = " ";
                 //txtbprgmgr.Text = " ";
                 //txtbpgtmgrcomm.Text = " ";
                 txtbpmcommpaid.Text = " ";
                 //cbobpa.Text = " ";
                 //txtbpa.Text = " ";
                 //txtbpjtpacomm.Text = " ";
                 txtbpacommpaid.Text = " ";
                 txtPayEstCost.Text = " ";
                 txtbestgp.Text = " ";
                 txtPayEstGP.Text = " ";
                 //txtBPrjDesc.Text = " ";



             }
             catch (MySqlException ex)
             {
                 MessageBox.Show(ex.Message);
             }   

        }


        //Updates the DB
        private void savebillingbut_Click(object sender, EventArgs e)
        {
            
            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(connectionString);

            List<DataRow> billingNums2Remove = new List<DataRow>();

            try
            {
                string commandString100 = ("SELECT chkd_calc FROM billing WHERE bid = '" + txtbid.Text.Trim() + "'");
                MySqlCommand mysqlcommand100 = new MySqlCommand(commandString100, MySqlConn);
                DataTable table100 = GetDataTable(
                    // Pass open database connection to function
       ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
       commandString100);


                //Darren add a second button for this function

                //**********************************
                //foreach (DataRow jm in table100.Rows)
                //{

                //    if (jm["chkd_calc"].ToString() == "Y")
                //    {

                //        MessageBox.Show("Edits cannot be made on a calculated ROW!!");
                //        return;
                //    }
                    
                //}




                if (chbkactualcost.Checked == true)
                {
                    DialogResult dr = MessageBox.Show("This is permanent, do you wish to continue?", "Important Question", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No)
                    {

                        return;

                    }
                    else
                    {
                            string commandString44 = ("UPDATE projects set chkd_actcost = 'T' WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");
                            MySqlCommand mysqlcommand44 = new MySqlCommand(commandString44, MySqlConn);

                            DataTable table44 = GetDataTable(
                                // Pass open database connection to function
                        ref MySqlConn,
                                // Pass SQL statement to create SqlDataReader
                        commandString44);

                    }
                }

                //first time in want to just set the billing_amt and billing_date
                if (txtbillingamt.Text != String.Empty )
                {
                    if (txtPaidAmt.Text == String.Empty)
                    {

                        

                        String b = txtbillingamt.Text.Trim();
                        txtbillingamt.Text = b.Replace(",", "");

                        //this converts the date into mysql date
                        //comes in as '10/25/2011' month day year
                        //needs to be '2011-10-25' Year-month-day
                        String fdate = mskdtxtbillingDate.Text;
                        DateTime re = DateTime.Parse(fdate);
                        mskdtxtbillingDate.Text = re.ToString("MM/dd/yyyy");

                        String date = mskdtxtbillingDate.Text;
                        DateTime dt = DateTime.ParseExact(date, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                        mskdtxtbillingDate.Text = dt.ToString("yyyy-MM-dd");
                        
                        
                        if (mskdtxtpaidDate.Text == string.Empty)
                        {
                            string zz = "01/01/0001";
                            mskdtxtpaidDate.Text = zz;
                            String zzdate = mskdtxtpaidDate.Text.Trim();
                            DateTime sw = DateTime.ParseExact(zzdate, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                            mskdtxtpaidDate.Text = sw.ToString("yyyy-MM-dd");
                        }
                        


                        
                        
                        //txtPaidAmt.Text = " ";
                        //mskdtxtpaidDate.Text = " ";
                        //inserts into billing receives
                        //string commandString1 = ("UPDATE billing_received SET psale_amt = '" + txtbpsaleamt.Text.Trim() + "', pest_cost = '" + txtbpestcost.Text.Trim() + "', pact_cost = '" + txtbpactcost.Text.Trim() + "', payest_gp = '" + txtPayEstGP.Text.Trim() + "', payest_cost = '" + txtPayEstCost.Text.Trim() + "', est_gp = '" + txtbestgp.Text.Trim() + "', payact_gp = '" + txtActGP.Text.Trim() + "', pbilling_cycle = '" + cbobillingnum.SelectedItem.ToString() + "', pbilling_amt = '" + txtbillingamt.Text.Trim() + "', pbilling_date = '" + mskdtxtbillingDate.Text.Trim() + "' ppaid_amt = '" + txtPaidAmt.Text.Trim() + "', ppaid_date = '" + mskdtxtpaidDate.Text.Trim() + "'");
                        string commandString1 = ("INSERT into billing_received SET bid = '" + txtbid.Text.Trim() + "', jid = '" + txtbjid.Text.Trim() + "', pid = '" + txtbpid.Text.Trim() + "', project_number = '" + txtbpjtnum.Text.Trim() + "', psale_amt = '" + txtbpsaleamt.Text.Trim() + "', pest_cost = '" + txtbpestcost.Text.Trim() + "', pact_cost = '" + txtbpactcost.Text.Trim() + "', payest_gp = '" + txtPayEstGP.Text.Trim() + "', payest_cost = '" + txtPayEstCost.Text.Trim() + "', est_gp = '" + txtbestgp.Text.Trim() + "', payact_gp = '" + txtActGP.Text.Trim() + "', pbilling_cycle = '" + cbobillingnum.SelectedItem.ToString() + "', pbilling_amt = '" + txtbillingamt.Text.Trim() + "', pbilling_date = '" + mskdtxtbillingDate.Text.Trim() + "', ppaid_amt = '" + txtPaidAmt.Text.Trim() + "', ppaid_date = '" + mskdtxtpaidDate.Text.Trim() + "'");
                        MySqlCommand mysqlcommand = new MySqlCommand(commandString1, MySqlConn);

                        DataTable table = GetDataTable(
                            // Pass open database connection to function
                    ref MySqlConn,
                            // Pass SQL statement to create SqlDataReader
                    commandString1);

                        //string commandString5 = ("UPDATE billing SET pid = '" + txtbpid.Text.Trim() + "', billing_num = '" + cbobillingnum.SelectedItem.ToString() + "', billing_amt = '" + txtbillingamt.Text.Trim() + "', billing_date = '" + mskdtxtbillingDate.Text.Trim() + "' WHERE bid = '" + txtbid.Text.Trim() + "'");

                        string commandString5 = ("UPDATE billing SET billing_num = '" + cbobillingnum.SelectedItem.ToString() + "', billing_amt = '" + txtbillingamt.Text.Trim() + "', billing_date = '" + mskdtxtbillingDate.Text.Trim() + "', paid_amt = '" + txtPaidAmt.Text.Trim() + "', paid_date = '" + mskdtxtpaidDate.Text.ToString() + "', estimator = '" + cbobestperson.Text.Trim() + "', estimator_percent = '" + txtbestcomm.Text.Trim() + "', estimator_comm = '" + txtbestpaidcomm.Text.Trim() + "', salesperson = '" + cbobsperson.Text.Trim() + "', salesperson_percent = '" + txtbspcomm.Text.Trim() + "', salesperson_comm = '" + txtbspcommpaid.Text.Trim() + "', projectmgr = '" + cbobpm.Text.Trim() + "', projectmgr_percent = '" + txtbpgtmgrcomm.Text.Trim() + "', projectmgr_comm = '" + txtbpmcommpaid.Text.Trim() + "', projectasst = '" + cbobpa.Text.Trim() + "', projectasst_percent = '" + txtbpjtpacomm.Text.Trim() + "', projectasst_comm = '" + txtbpacommpaid.Text.Trim() + "', project_saleamt = '" + txtbpsaleamt.Text.Trim() + "', project_estcost = '" + txtbpestcost.Text.Trim() + "', project_description = '" + txtBPrjDesc.Text.Trim() + "', project_actcost = '" + txtbpactcost.Text.Trim() + "', payest_gp = '" + txtPayEstGP.Text.Trim() + "', payest_cost = '" + txtPayEstCost.Text.Trim() + "', est_gp = '" + txtbestgp.Text.Trim() + "', payact_gp = '" + txtActGP.Text.Trim() + "' WHERE bid = '" + txtbid.Text.Trim() + "'");
                        MySqlCommand mysqlcommand2 = new MySqlCommand(commandString5, MySqlConn);

                        DataTable table2 = GetDataTable(
                            // Pass open database connection to function
                    ref MySqlConn,
                            // Pass SQL statement to create SqlDataReader
                    commandString5);

                        mskdtxtpaidDate.Clear();

                    }
                    //txtPaidAmt.Text = String.Empty;
                    
                }


                //second time in update the paid_amt and paid_date
                if (txtbillingamt.Text != String.Empty)
                {
                    if (txtPaidAmt.Text != String.Empty)
                    {


                        String p = txtbillingamt.Text.Trim();
                        txtbillingamt.Text = p.Replace(",", "");

                        String a = txtPaidAmt.Text.Trim();
                        txtPaidAmt.Text = a.Replace(",", "");

                        //this converts the billing date into mysql date
                        //comes in as '10/25/2011' month day year
                        //needs to be '2011-10-25' Year-month-day
                        String sdate = mskdtxtbillingDate.Text;
                        DateTime ue = DateTime.Parse(sdate);
                        mskdtxtbillingDate.Text = ue.ToString("MM/dd/yyyy");


                        String date = mskdtxtbillingDate.Text.Trim();
                        DateTime az = DateTime.ParseExact(date, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                        mskdtxtbillingDate.Text = az.ToString("yyyy-MM-dd");


                        //this converts the paid date into mysql date
                        //comes in as '10/25/2011' month day year
                        //needs to be '2011-10-25' Year-month-day
                        String tdate = mskdtxtpaidDate.Text;
                        DateTime we = DateTime.Parse(tdate);
                        mskdtxtpaidDate.Text = we.ToString("MM/dd/yyyy");


                        String pdate = mskdtxtpaidDate.Text.Trim();
                        DateTime bv = DateTime.ParseExact(pdate, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                        mskdtxtpaidDate.Text = bv.ToString("yyyy-MM-dd");

                        
                        string commandString4 = ("UPDATE billing_received SET psale_amt = '" + txtbpsaleamt.Text.Trim() + "', pest_cost = '" + txtbpestcost.Text.Trim() + "', pact_cost = '" + txtbpactcost.Text.Trim() + "', payest_gp = '" + txtPayEstGP.Text.Trim() + "', payest_cost = '" + txtPayEstCost.Text.Trim() + "', est_gp = '" + txtbestgp.Text.Trim() + "', payact_gp = '" + txtActGP.Text.Trim() + "', pbilling_cycle = '" + cbobillingnum.SelectedItem.ToString() + "', pbilling_amt = '" + txtbillingamt.Text.Trim() + "', pbilling_date = '" + mskdtxtbillingDate.Text.Trim() + "', ppaid_amt = '" + txtPaidAmt.Text.Trim() + "', ppaid_date = '" + mskdtxtpaidDate.Text.Trim() + "' WHERE bid = '" + txtbid.Text.Trim() + "'");
                        MySqlCommand mysqlcommand = new MySqlCommand(commandString4, MySqlConn);

                        DataTable table4 = GetDataTable(
                            // Pass open database connection to function
                    ref MySqlConn,
                            // Pass SQL statement to create SqlDataReader
                    commandString4);



                        string commandString6 = ("UPDATE billing SET billing_num = '" + cbobillingnum.SelectedItem.ToString() + "', billing_amt = '" + txtbillingamt.Text.Trim() + "', billing_date = '" + mskdtxtbillingDate.Text.Trim() + "', paid_amt = '" + txtPaidAmt.Text.Trim() + "', paid_date = '" + mskdtxtpaidDate.Text.Trim() + "', estimator = '" + cbobestperson.Text.Trim() + "', estimator_percent = '" + txtbestcomm.Text.Trim() + "', estimator_comm = '" + txtbestpaidcomm.Text.Trim() + "', salesperson = '" + cbobsperson.Text.Trim() + "', salesperson_percent = '" + txtbspcomm.Text.Trim() + "', salesperson_comm = '" + txtbspcommpaid.Text.Trim() + "', projectmgr = '" + cbobpm.Text.Trim() + "', projectmgr_percent = '" + txtbpgtmgrcomm.Text.Trim() + "', projectmgr_comm = '" + txtbpmcommpaid.Text.Trim() + "', projectasst = '" + cbobpa.Text.Trim() + "', projectasst_percent = '" + txtbpjtpacomm.Text.Trim() + "', projectasst_comm = '" + txtbpacommpaid.Text.Trim() + "', project_saleamt = '" + txtbpsaleamt.Text.Trim() + "', project_estcost = '" + txtbpestcost.Text.Trim() + "', project_description = '" + txtBPrjDesc.Text.Trim() + "', project_actcost = '" + txtbpactcost.Text.Trim() + "', paid_stmt = 'Y' WHERE bid = '" + txtbid.Text.Trim() + "'");

                        MySqlCommand mysqlcommand6 = new MySqlCommand(commandString6, MySqlConn);

                        DataTable table6 = GetDataTable(
                            // Pass open database connection to function
                    ref MySqlConn,
                            // Pass SQL statement to create SqlDataReader
                    commandString6);
                    }

                }



                //Darren this updates data for comm job type
                string commandString366 = ("UPDATE comm_job_type SET cid = '" + txtbcid.Text.Trim() + "', jid = '" + txtbjid.Text.Trim() + "', pid = '" + txtbpid.Text.Trim() + "', name_1 = '" + cbobestperson.Text.Trim() + "', jtype_1 = 'Estimator', name_2 = '" + cbobsperson.Text.Trim() + "', jtype_2 = 'Salesperson', name_3 = '" + cbobpm.Text.Trim() + "', jtype_3 = 'ProjectManager', name_4 = '" + cbobpa.Text.Trim() + "', jtype_4 = 'ProjectAssistant' WHERE bid = '" + txtbid.Text.Trim() + "'");
                MySqlCommand mysqlcommand366 = new MySqlCommand(commandString366, MySqlConn);
                DataTable table366 = GetDataTable(
                    // Pass open database connection to function
       ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
       commandString366);



                //updates the datagrid view                
                string commandString3 = ("SELECT bid, project_name, project_number, billing_num, billing_amt, billing_date, paid_amt, paid_date, estimator, estimator_percent, estimator_comm, salesperson, salesperson_percent, salesperson_comm, projectmgr, projectmgr_percent, projectmgr_comm, projectasst, projectasst_percent, projectasst_comm, project_saleamt, project_estcost, project_description, project_actcost, payest_gp, payest_cost, est_gp, payact_gp, paid_stmt FROM billing WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");

                MySqlCommand mysqlcommand3 = new MySqlCommand(commandString3, MySqlConn);

                DataTable table3 = GetDataTable(
                    // Pass open database connection to function
            ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
            commandString3);

                dataGridView1.DataSource = table3;
                dataGridView1.Refresh();
               
               
                //THis is the one i'm working on
                foreach (DataGridViewRow xy in dataGridView1.Rows)
                {
                    if (xy.Cells["paid_amt"].Value == "")
                    {
                        xy.DefaultCellStyle.BackColor = Color.Yellow;

                        if (xy.Cells["paid_amt"].Value == DBNull.Value)
                        {
                            xy.DefaultCellStyle.BackColor = Color.Yellow;

                            if (xy.Cells["paid_amt"].Value.ToString() == string.Empty)
                            {
                                xy.DefaultCellStyle.BackColor = Color.Yellow;

                                if (xy.Cells["paid_amt"].Value == null)
                                {
                                    xy.DefaultCellStyle.BackColor = Color.Yellow;
                                }
                            }
                        }
                    }

                    
                    
                    //if (row.Cells["paid_stmt"].Value.ToString() == "N")
                    //{
                    //    row.DefaultCellStyle.BackColor = Color.Yellow;
                    //}
                    //else if (xy.Cells["paid_amt"].Value == DBNull.Value)
                    //{
                    //    xy.DefaultCellStyle.BackColor = Color.Yellow;
                    //}                   
                    //else if (xy.Cells["paid_amt"].Value == null)
                    //{
                    //    xy.DefaultCellStyle.BackColor = Color.Yellow;
                    //}
                    //else
                    //{

                    //}
                    //if (xy.Cells["paid_amt"].Value == "")
                    //{
                    //    xy.DefaultCellStyle.BackColor = Color.Yellow;

                    //    if (xy.Cells["paid_amt"].Value == DBNull.Value)
                    //    {
                    //        xy.DefaultCellStyle.BackColor = Color.Yellow;

                    //        if (xy.Cells["paid_amt"].Value.ToString() == string.Empty)
                    //        {
                    //            xy.DefaultCellStyle.BackColor = Color.Yellow;

                    //            if (xy.Cells["paid_amt"].Value == null)
                    //            {
                    //                xy.DefaultCellStyle.BackColor = Color.Yellow;
                    //            }
                    //        }
                    //    }
                    //}
                    //txtPaidAmt.Text = " ";
                }

                //Clears the text fields               
                cbobillingnum.Text = " ";
                txtbillingamt.Text = " ";
                mskdtxtbillingDate.Text = " ";
                txtPaidAmt.Text = " ";
                mskdtxtpaidDate.Text = " ";
                txtBPrjDesc.Text = " ";
                cbobestperson.Text = " ";
                txtbestcomm.Text = " ";
                txtbestpaidcomm.Text = " ";
                cbobsperson.Text = " ";
                txtbspcomm.Text = " ";
                txtbspcommpaid.Text = " ";
                cbobpm.Text = " ";
                txtbpgtmgrcomm.Text = " ";
                txtbpmcommpaid.Text = " ";
                cbobpa.Text = " ";
                txtbpjtpacomm.Text = " ";
                txtbpacommpaid.Text = " ";

                //String x = "";
                //This updates the combo box with billing statements
                string commandString22 = ("SELECT billing_num FROM billing WHERE pid = '" + txtbpid.Text.Trim() + "'");
                MySqlCommand mysqlcommand22 = new MySqlCommand(commandString22, MySqlConn);

                DataTable table22 = GetDataTable(
                    // Pass open database connection to function
       ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
       commandString22);

                cbounpbill.Items.Clear();

                foreach (DataRow row in table22.Rows)
                {
                    if (row["billing_num"].ToString() == " ")
                    {
                        billingNums2Remove.Add(row);
                    }
                    else
                    {
                        String item = (row["billing_num"].ToString());
                        cbounpbill.Items.Add(item);
                        row.Delete();
                    }

                }
                
            


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //THis inserts a new billing statement
        private void newprjbut_Click(object sender, EventArgs e)
        {
            //int i = 0;
            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(connectionString);

            List<DataRow> billingNums3Remove = new List<DataRow>();

            if (txtbpjtnum.Text == string.Empty)
            {
                errorProvider3.SetError(txtbpjtnum, "Please Enter a Project Number");
            }
            if (txtbpjtname.Text == string.Empty)
            {
                errorProvider3.SetError(txtbpjtname, "Please Enter a Project Name");
            }
            else
            {
                try
                {

                    //Darren you are here
                    //**********************************this is for actual cost********************************************
                    if (chbkactualcost.Checked == true)
                    {
                        //This removes commas from the billing amt
                        String z = txtbillingamt.Text.Trim();
                        txtbillingamt.Text = z.Replace(",", "");

                        //This removes commas from the paid amt
                        String a = txtPaidAmt.Text.Trim();
                        txtPaidAmt.Text = a.Replace(",", "");

                        //This removes commas from the actual cost
                        String c = txtbpactcost.Text.Trim();
                        txtbpactcost.Text = c.Replace(",", "");

                        //this converts the billing date into mysql date
                        //comes in as '10/25/2011' month day year
                        //needs to be '2011-10-25' Year-month-day
                        String cdate = mskdtxtbillingDate.Text;
                        DateTime fe = DateTime.Parse(cdate);
                        mskdtxtbillingDate.Text = fe.ToString("MM/dd/yyyy");

                        String date = mskdtxtbillingDate.Text.Trim();
                        DateTime cz = DateTime.ParseExact(date, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                        mskdtxtbillingDate.Text = cz.ToString("yyyy-MM-dd");


                        //this converts the paid date into mysql date
                        //comes in as '10/25/2011' month day year
                        //needs to be '2011-10-25' Year-month-day

                        if (mskdtxtpaidDate.Text == string.Empty)
                        {
                            string aa = "01/01/0001";
                            mskdtxtpaidDate.Text = aa;
                            String zzdate = mskdtxtpaidDate.Text.Trim();
                            DateTime se = DateTime.ParseExact(zzdate, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                            mskdtxtpaidDate.Text = se.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            String vdate = mskdtxtpaidDate.Text;
                            DateTime qe = DateTime.Parse(vdate);
                            mskdtxtpaidDate.Text = qe.ToString("MM/dd/yyyy");

                            String pdate = mskdtxtpaidDate.Text.Trim();
                            DateTime qv = DateTime.ParseExact(pdate, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                            mskdtxtpaidDate.Text = qv.ToString("yyyy-MM-dd");
                        }


                        string commandString7 = ("UPDATE projects SET chkd_actcost = 'T' WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");
                        MySqlCommand mysqlcommand7 = new MySqlCommand(commandString7, MySqlConn);

                        DataTable table7 = GetDataTable(
                            // Pass open database connection to function
                    ref MySqlConn,
                            // Pass SQL statement to create SqlDataReader
                    commandString7);


                        //inserts a new row into billing table
                        //******************************************************************************
                        string commandString5 = ("INSERT into billing SET cid = '" + txtbcid.Text.Trim() + "', pid = '" + txtbpid.Text.Trim() + "', jid = '" + txtbjid.Text.Trim() + "', project_name = '" + txtbpjtname.Text.Trim() + "', project_number = '" + txtbpjtnum.Text.Trim() + "', billing_num = '" + cbobillingnum.SelectedItem.ToString() + "', billing_amt = '" + txtbillingamt.Text.Trim() + "', billing_date = '" + mskdtxtbillingDate.Text.Trim() + "', estimator = '" + cbobestperson.Text.Trim() + "', estimator_percent = '" + txtbestcomm.Text.Trim() + "', estimator_comm = '" + txtbestpaidcomm.Text.Trim() + "', salesperson = '" + cbobsperson.Text.Trim() + "', salesperson_percent = '" + txtbspcomm.Text.Trim() + "', salesperson_comm = '" + txtbspcommpaid.Text.Trim() + "', projectmgr = '" + cbobpm.Text.Trim() + "', projectmgr_percent = '" + txtbpgtmgrcomm.Text.Trim() + "', projectmgr_comm = '" + txtbpmcommpaid.Text.Trim() + "', projectasst = '" + cbobpa.Text.Trim() + "', projectasst_percent = '" + txtbpjtpacomm.Text.Trim() + "', projectasst_comm = '" + txtbpacommpaid.Text.Trim() + "', project_saleamt = '" + txtbpsaleamt.Text.Trim() + "', project_estcost = '" + txtbpestcost.Text.Trim() + "', project_description = '" + txtBPrjDesc.Text.Trim() + "', project_actcost = '" + txtbpactcost.Text.Trim() + "', payest_gp = '" + txtPayEstGP.Text.Trim() + "', payest_cost = '" + txtPayEstCost.Text.Trim() + "', est_gp = '" + txtbestgp.Text.Trim() + "', payact_gp = '" + txtActGP.Text.Trim() + "'");//, chkd_actcost = 'T'");
                        MySqlCommand mysqlcommand5 = new MySqlCommand(commandString5, MySqlConn);

                        DataTable table5 = GetDataTable(
                            // Pass open database connection to function
                    ref MySqlConn,
                            // Pass SQL statement to create SqlDataReader
                    commandString5);
                        

                        string commandString6 = ("INSERT into billing_received SET jid = '" + txtbjid.Text.Trim() + "', pid = '" + txtbpid.Text.Trim() + "', project_number = '" + txtbpjtnum.Text.Trim() + "', psale_amt = '" + txtbpsaleamt.Text.Trim() + "', pest_cost = '" + txtbpestcost.Text.Trim() + "', pact_cost = '" + txtbpactcost.Text.Trim() + "', payest_gp = '" + txtPayEstGP.Text.Trim() + "', payest_cost = '" + txtPayEstCost.Text.Trim() + "', est_gp = '" + txtbestgp.Text.Trim() + "', payact_gp = '" + txtActGP.Text.Trim() + "', pbilling_cycle = '" + cbobillingnum.SelectedItem.ToString() + "', pbilling_amt = '" + txtbillingamt.Text.Trim() + "', pbilling_date = '" + mskdtxtbillingDate.Text.Trim() + "', ppaid_amt = '" + txtPaidAmt.Text.Trim() + "', ppaid_date = '" + mskdtxtpaidDate.Text.Trim() + "', chkd_actcost = 'T', bid = LAST_INSERT_ID()");

                        MySqlCommand mysqlcommand6 = new MySqlCommand(commandString6, MySqlConn);

                        DataTable table6 = GetDataTable(
                            // Pass open database connection to function
                    ref MySqlConn,
                            // Pass SQL statement to create SqlDataReader
                    commandString6);



                        string commandString364 = ("SELECT bid FROM billing_received ORDER BY bid DESC LIMIT 1");
                        MySqlCommand mysqlcommand364 = new MySqlCommand(commandString364, MySqlConn);
                        DataTable table364 = GetDataTable(
                            // Pass open database connection to function
                    ref MySqlConn,
                            // Pass SQL statement to create SqlDataReader
                    commandString364);

                        foreach (DataRow row in table364.Rows)
                        {

                            t = " ";
                            t = (row[0].ToString());
                            holder = " ";
                            holder = t;
                        }


                    }
                    else
                    {
                        //Thsis removes commas from the billing amt
                        String d = txtbillingamt.Text.Trim();
                        txtbillingamt.Text = d.Replace(",", "");

                        //This removes commas from the paid amt
                        String p = txtPaidAmt.Text.Trim();
                        txtPaidAmt.Text = p.Replace(",", "");

                        //this converts the billing date into mysql date
                        //comes in as '10/25/2011' month day year
                        //needs to be '2011-10-25' Year-month-day
                        String xdate = mskdtxtbillingDate.Text;
                        DateTime xe = DateTime.Parse(xdate);
                        mskdtxtbillingDate.Text = xe.ToString("MM/dd/yyyy");

                        String date = mskdtxtbillingDate.Text.Trim();
                        DateTime rz = DateTime.ParseExact(date, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                        mskdtxtbillingDate.Text = rz.ToString("yyyy-MM-dd");


                        //this converts the paid date into mysql date
                        //comes in as '10/25/2011' month day year
                        //needs to be '2011-10-25' Year-month-day
                        if (mskdtxtpaidDate.Text == string.Empty)
                        {
                            string ff = "01/01/0001";
                            mskdtxtpaidDate.Text = ff;
                            String zzdate = mskdtxtpaidDate.Text.Trim();
                            DateTime sw = DateTime.ParseExact(zzdate, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                            mskdtxtpaidDate.Text = sw.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            String bdate = mskdtxtpaidDate.Text;
                            DateTime be = DateTime.Parse(bdate);
                            mskdtxtpaidDate.Text = be.ToString("MM/dd/yyyy");

                            String pdate = mskdtxtpaidDate.Text.Trim();
                            DateTime tv = DateTime.ParseExact(pdate, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                            mskdtxtpaidDate.Text = tv.ToString("yyyy-MM-dd");
                        }








                        //inserts a new row into billing table
                        //*************************************************** this is for estimated cost**********************
                        string commandString2 = ("INSERT into billing SET cid = '" + txtbcid.Text.Trim() + "', pid = '" + txtbpid.Text.Trim() + "', jid = '" + txtbjid.Text.Trim() + "', project_name = '" + txtbpjtname.Text.Trim() + "', project_number = '" + txtbpjtnum.Text.Trim() + "', billing_num = '" + cbobillingnum.SelectedItem.ToString() + "', billing_amt = '" + txtbillingamt.Text.Trim() + "', billing_date = '" + mskdtxtbillingDate.Text.Trim() + "', estimator = '" + cbobestperson.Text.Trim() + "', estimator_percent = '" + txtbestcomm.Text.Trim() + "', estimator_comm = '" + txtbestpaidcomm.Text.Trim() + "', salesperson = '" + cbobsperson.Text.Trim() + "', salesperson_percent = '" + txtbspcomm.Text.Trim() + "', salesperson_comm = '" + txtbspcommpaid.Text.Trim() + "', projectmgr = '" + cbobpm.Text.Trim() + "', projectmgr_percent = '" + txtbpgtmgrcomm.Text.Trim() + "', projectmgr_comm = '" + txtbpmcommpaid.Text.Trim() + "', projectasst = '" + cbobpa.Text.Trim() + "', projectasst_percent = '" + txtbpjtpacomm.Text.Trim() + "', projectasst_comm = '" + txtbpacommpaid.Text.Trim() + "', project_saleamt = '" + txtbpsaleamt.Text.Trim() + "', project_estcost = '" + txtbpestcost.Text.Trim() + "', project_description = '" + txtBPrjDesc.Text.Trim() + "', project_actcost = '" + txtbpactcost.Text.Trim() + "', payest_gp = '" + txtPayEstGP.Text.Trim() + "', payest_cost = '" + txtPayEstCost.Text.Trim() + "', est_gp = '" + txtbestgp.Text.Trim() + "', payact_gp = '" + txtActGP.Text.Trim() + "', paid_stmt = 'N'");
                        MySqlCommand mysqlcommand2 = new MySqlCommand(commandString2, MySqlConn);

                        DataTable table2 = GetDataTable(
                            // Pass open database connection to function
                    ref MySqlConn,
                            // Pass SQL statement to create SqlDataReader
                    commandString2);





                        //inserts a new row in the billing recevied table 
                        //**********************************************************************                        
                        string commandString1 = ("INSERT into billing_received SET jid = '" + txtbjid.Text.Trim() + "', pid = '" + txtbpid.Text.Trim() + "', project_number = '" + txtbpjtnum.Text.Trim() + "', psale_amt = '" + txtbpsaleamt.Text.Trim() + "', pest_cost = '" + txtbpestcost.Text.Trim() + "', pact_cost = '" + txtbpactcost.Text.Trim() + "', payest_gp = '" + txtPayEstGP.Text.Trim() + "', payest_cost = '" + txtPayEstCost.Text.Trim() + "', est_gp = '" + txtbestgp.Text.Trim() + "', payact_gp = '" + txtActGP.Text.Trim() + "', pbilling_cycle = '" + cbobillingnum.SelectedItem.ToString() + "', pbilling_amt = '" + txtbillingamt.Text.Trim() + "', pbilling_date = '" + mskdtxtbillingDate.Text.Trim() + "', ppaid_amt = '" + txtPaidAmt.Text.Trim() + "', ppaid_date = '" + mskdtxtpaidDate.Text.Trim() + "', bid = LAST_INSERT_ID()");

                        MySqlCommand mysqlcommand1 = new MySqlCommand(commandString1, MySqlConn);

                        //string t = (string)View[15]["bid"];
                       // int t = commandString1.bid;
                        ////t = int.Parse(table1.Rows[15].ToString());
                        //t = int.Parse(commandString1.);
                        //String holder2;
                        //holder2 = t.ToString();
                        ////token29 = " ";
                        ////token29 = holder2;
                        
                        DataTable table1 = GetDataTable(
                            // Pass open database connection to function
                    ref MySqlConn,
                            // Pass SQL statement to create SqlDataReader
                    commandString1);

                    //    string commandString365 = ("SELECT bid FROM billing_received ORDER BY bid DESC LIMIT 1");
                    //    MySqlCommand mysqlcommand365 = new MySqlCommand(commandString365, MySqlConn);
                    //    DataTable table365 = GetDataTable(
                    //        // Pass open database connection to function
                    //ref MySqlConn,
                    //        // Pass SQL statement to create SqlDataReader
                    //commandString365);

                    //    foreach (DataRow row in table365.Rows)
                    //    {

                    //        t = " ";
                    //        t = (row[0].ToString());
                    //        holder = " ";
                    //        holder = t;
                    //    }

                    }

                    String ydate = mskdtxtbillingDate.Text;
                    DateTime ye = DateTime.Parse(ydate);
                    mskdtxtbillingDate.Text = ye.ToString("MM/dd/yyyy");


                    if (mskdtxtpaidDate.Text == "0001-01-01")
                    {
                        mskdtxtpaidDate.Clear();
                    }
                    else
                    {
                        String kdate = mskdtxtpaidDate.Text;
                        DateTime ke = DateTime.Parse(kdate);
                        mskdtxtpaidDate.Text = ke.ToString("MM/dd/yyyy");

                        String pdate = mskdtxtpaidDate.Text.Trim();
                        DateTime dv = DateTime.ParseExact(pdate, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                        mskdtxtpaidDate.Text = dv.ToString("yyyy-MM-dd");
                    }

                    //Darren this inserts a new row in to the comm_job_type table
           //         string commandString366 = ("INSERT into comm_job_type SET cid = '" + txtbcid.Text.Trim() + "', jid = '" + txtbjid.Text.Trim() + "', pid = '" + txtbpid.Text.Trim() + "', bid = '" + holder.ToString() + "', project_number = '" + txtbpjtnum.Text.Trim() + "', project_name = '" + txtbpjtname.Text.Trim() + "', name_1 = '" + cbobestperson.Text.Trim() + "', jtype_1 = 'Estimator', name_2 = '" + cbobsperson.Text.Trim() + "', jtype_2 = 'Salesperson', name_3 = '" + cbobpm.Text.Trim() + "', jtype_3 = 'ProjectManager', name_4 = '" + cbobpa.Text.Trim() + "', jtype_4 = 'ProjectAssistant'");
           //         MySqlCommand mysqlcommand366 = new MySqlCommand(commandString366, MySqlConn);
           //         DataTable table366 = GetDataTable(
           //             // Pass open database connection to function
           //ref MySqlConn,
           //             // Pass SQL statement to create SqlDataReader
           //commandString366);


                    //This updates the combo box with billing statements
                    string commandString22 = ("SELECT billing_num FROM billing WHERE pid = '" + txtbpid.Text.Trim() + "'");
                    MySqlCommand mysqlcommand22 = new MySqlCommand(commandString22, MySqlConn);

                    DataTable table22 = GetDataTable(
                        // Pass open database connection to function
           ref MySqlConn,
                        // Pass SQL statement to create SqlDataReader
           commandString22);

                    cbounpbill.Items.Clear();

                    foreach (DataRow row in table22.Rows)
                    {
                        if (row["billing_num"].ToString() == " ")
                        {
                            billingNums3Remove.Add(row);
                        }
                        else
                        {
                            String item2 = (row["billing_num"].ToString());
                            cbounpbill.Items.Add(item2);
                            row.Delete();
                        }

                    }


                    
                    




                    //updates the datagrid view
                    //*****************************************************************************
                    string commandString3 = ("SELECT bid, project_name, project_number, billing_num, billing_amt, billing_date, paid_amt, paid_date, estimator, estimator_percent, estimator_comm, salesperson, salesperson_percent, salesperson_comm, projectmgr, projectmgr_percent, projectmgr_comm, projectasst, projectasst_percent, projectasst_comm, project_saleamt, project_estcost, project_description, project_actcost, payest_gp, payest_cost, est_gp, payact_gp, paid_stmt FROM billing WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");

                    MySqlCommand mysqlcommand3 = new MySqlCommand(commandString3, MySqlConn);

                    DataTable table3 = GetDataTable(
                        // Pass open database connection to function
                ref MySqlConn,
                        // Pass SQL statement to create SqlDataReader
                commandString3);

                    dataGridView1.DataSource = table3;
                    dataGridView1.Refresh();

                    //Darren this still isn't working all rows aren't changing colors
                    foreach (DataGridViewRow xy in dataGridView1.Rows)
                    {
                        if (xy.Cells["paid_amt"].Value == "")
                        {
                            xy.DefaultCellStyle.BackColor = Color.Yellow;

                            if (xy.Cells["paid_amt"].Value == DBNull.Value)
                            {
                                xy.DefaultCellStyle.BackColor = Color.Yellow;

                                if (xy.Cells["paid_amt"].Value.ToString() == string.Empty)
                                {
                                    xy.DefaultCellStyle.BackColor = Color.Yellow;

                                    if (xy.Cells["paid_amt"].Value == null)
                                    {
                                        xy.DefaultCellStyle.BackColor = Color.Yellow;

                                        if (xy.Cells["paid_stmt"].Value.ToString() == "N")
                                        {
                                            xy.DefaultCellStyle.BackColor = Color.Yellow;
                                        }
                                    }
                                }
                            }
                        }

                    }


                }

               // }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }






        private void calcbillbut_Click(object sender, EventArgs e)
        {

            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(connectionString);


            int y = 0;
            //Darren this is the check to see if the row was already calculated if so text box shows .. 
            //if not then the row is calculated
            string commandString100 = ("SELECT chkd_calc FROM billing WHERE bid = '" + txtbid.Text.Trim() + "'");
            MySqlCommand mysqlcommand100 = new MySqlCommand(commandString100, MySqlConn);
            DataTable table100 = GetDataTable(
                // Pass open database connection to function
   ref MySqlConn,
                // Pass SQL statement to create SqlDataReader
   commandString100);

            //foreach (DataRow jm in table100.Rows)
            //{

            //    if (jm["chkd_calc"].ToString() == "Y")
            //    {

            //        MessageBox.Show("Edits cannot be made on a calculated ROW!!");
            //        return;
            //    }

            //}

            //Darren put check for estimataed cost or actual cost check box is checked
            if (chbkestcost.Checked == false & chbkactualcost.Checked == false)
            {
                MessageBox.Show("Please check Estimated Cost or Actual Cost");
            }
            else if(chbkactualcost.Checked == true)
            {
                DialogResult dr = MessageBox.Show("This is permanent, do you wish to continue?", "Important Question", MessageBoxButtons.YesNo);
                //Darren make sure hte user knows this is a permanent change

                if (dr == DialogResult.No)
                {

                    return;

                }
                else
                {
                    
                    if (txtbpactcost.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter a actual cost value!");
                        return;
                    }
                    //else if (txtbpactcost.Text == "0.00")
                    //{
                    //    DialogResult dt = MessageBox.Show("Actual Cost is $0.00 are you sure about this?", "Important Question", MessageBoxButtons.YesNo);
                    //    if (dt == DialogResult.No)
                    //    {
                    //        return;
                    //    }
                        
                    //}
                    else if (cbobillingnum.Text == string.Empty)
                    {
                        MessageBox.Show("Please select a billing cycle!");
                        return;
                    }
                    
                    else
                    {

                        //DArren this is for the second time through for actual cost
                        //check on billing date and paid date
                        String tdate = mskdtxtbillingDate.Text;
                        DateTime te = DateTime.Parse(tdate);
                        mskdtxtbillingDate.Text = te.ToString("MM/dd/yyyy");

                        String rdate = mskdtxtbillingDate.Text.Trim();
                        DateTime rrz = DateTime.ParseExact(rdate, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                        mskdtxtbillingDate.Text = rrz.ToString("yyyy-MM-dd");


                        //this converts the paid date into mysql date
                        //comes in as '10/25/2011' month day year
                        //needs to be '2011-10-25' Year-month-day
                        if (mskdtxtpaidDate.Text == string.Empty)
                        {
                            string ff = "01/01/0001";
                            mskdtxtpaidDate.Text = ff;
                            String azzdate = mskdtxtpaidDate.Text.Trim();
                            DateTime esw = DateTime.ParseExact(azzdate, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                            mskdtxtpaidDate.Text = esw.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            String wbdate = mskdtxtpaidDate.Text;
                            DateTime wbe = DateTime.Parse(wbdate);
                            mskdtxtpaidDate.Text = wbe.ToString("MM/dd/yyyy");

                            String wpdate = mskdtxtpaidDate.Text.Trim();
                            DateTime wtv = DateTime.ParseExact(wpdate, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                            mskdtxtpaidDate.Text = wtv.ToString("yyyy-MM-dd");
                        }


                        string commandString90 = ("SELECT chkd_actcost FROM billing WHERE bid = '" + txtbid.Text.Trim() + "'"); //+ txtbpjtnum.Text.Trim() + "'");
                        MySqlCommand mysqlcommand90 = new MySqlCommand(commandString90, MySqlConn);

                        DataTable table90 = GetDataTable(
                            // Pass open database connection to function
                    ref MySqlConn,
                            // Pass SQL statement to create SqlDataReader
                    commandString90);


                        foreach (DataRow dz in table90.Rows)
                        {

                            if (dz["chkd_actcost"].ToString() == "T")
                            {
                                decimal act2PaidAmt;
                                decimal act2GpAnswer;
                                decimal act2Cost;
                                decimal act2EstCommPrct;
                                decimal act2EstrPaidAnswer;
                                decimal act2EstrPaidComm;
                                decimal act2SpCommPrct;
                                decimal act2SpPaidAnswer;
                                decimal act2SpPaidComm;
                                decimal act2PmCommPrct;
                                decimal act2PmPaidAnswer;
                                decimal act2PmPaidComm;
                                decimal act2PaCommPrct;
                                decimal act2PaPaidAnswer;
                                decimal act2PaPaidComm;

                                act2EstCommPrct = decimal.Parse(txtbestcomm.Text);
                                act2SpCommPrct = decimal.Parse(txtbspcomm.Text);
                                act2PmCommPrct = decimal.Parse(txtbpgtmgrcomm.Text);
                                act2PaCommPrct = decimal.Parse(txtbpjtpacomm.Text);

                                if (txtPaidAmt.Text == string.Empty)
                                {
                                    MessageBox.Show("Please enter a paid amount!");
                                    return;

                                //    string commandString87 = ("UPDATE billing SET paid_amt = '" + txtPaidAmt.Text.Trim() + "' WHERE bid = '" + txtbid.Text.Trim() + "'");
                                //    MySqlCommand mysqlcommand87 = new MySqlCommand(commandString87, MySqlConn);

                                //    DataTable table87 = GetDataTable(
                                //        // Pass open database connection to function
                                //ref MySqlConn,
                                //        // Pass SQL statement to create SqlDataReader
                                //commandString87);

                                }

                                String t = txtPaidAmt.Text.Trim();
                                txtPaidAmt.Text = t.Replace(",", "");
                                String tl2 = txtPaidAmt.Text.Trim();

                                string commandString76 = ("SELECT SUM(paid_amt) FROM billing WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");

                                MySqlCommand mysqlcommand76 = new MySqlCommand(commandString76, MySqlConn);

                                DataTable table76 = GetDataTable(
                                    // Pass open database connection to function
                            ref MySqlConn,
                                    // Pass SQL statement to create SqlDataReader
                            commandString76);


                                txttlpdAmt.DataBindings.Clear();
                                txttlpdAmt.DataBindings.Add(new Binding("Text", table76, "SUM(paid_amt)", true));                                
                                decimal pd2Amt;
                                decimal newpd2Amt;
                                decimal finalTl2Ansr;

                                if (txttlpdAmt.Text.Trim() == "" || txttlpdAmt.Text.Trim() == string.Empty)
                                {

                                    pd2Amt = decimal.Parse(txtPaidAmt.Text);
                                    finalTl2Ansr = pd2Amt;
                                    txttlpdAmt.Text = finalTl2Ansr.ToString("#####0.00");

                                }
                                else
                                {
                                    pd2Amt = decimal.Parse(txttlpdAmt.Text);
                                    newpd2Amt = decimal.Parse(tl2);
                                    finalTl2Ansr = pd2Amt + newpd2Amt;
                                    txttlpdAmt.Text = finalTl2Ansr.ToString("#####0.00");
                                }

                                pd2Amt = decimal.Parse(txttlpdAmt.Text);
                                newpd2Amt = decimal.Parse(tl2);
                                finalTl2Ansr = pd2Amt + newpd2Amt;
                                txttlpdAmt.Text = finalTl2Ansr.ToString("#####0.00");
                                String r = txtbpactcost.Text.Trim();
                                txtbpactcost.Text = r.Replace(",", "");
                                act2Cost = decimal.Parse(txtbpactcost.Text);
                                act2PaidAmt = decimal.Parse(txttlpdAmt.Text);

                                act2GpAnswer = act2PaidAmt - act2Cost;
                                txtActGP.Text = decimal.Round(act2GpAnswer, 2).ToString();


                            //    string commandString91 = ("SELECT estr_tl_paid, sp_tl_paid, pm_tl_paid, pa_tl_paid FROM assignedps WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");
                            //    MySqlCommand mysqlcommand5 = new MySqlCommand(commandString91, MySqlConn);

                            //    DataTable table91 = GetDataTable(
                            //        // Pass open database connection to function
                            //ref MySqlConn,
                            //        // Pass SQL statement to create SqlDataReader
                            //commandString91);

                                string commandString91 = ("SELECT SUM(estimator_comm), SUM(salesperson_comm), SUM(projectmgr_comm), SUM(projectasst_comm) FROM billing WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");
                                MySqlCommand mysqlcommand5 = new MySqlCommand(commandString91, MySqlConn);

                                DataTable table91 = GetDataTable(
                                    // Pass open database connection to function
                            ref MySqlConn,
                                    // Pass SQL statement to create SqlDataReader
                            commandString91);


                                txtbestpaidcomm.DataBindings.Clear();
                                txtbestpaidcomm.DataBindings.Add(new Binding("Text", table91, "SUM(estimator_comm)", true));
                                decimal bestpaid2;
                                bestpaid2 = decimal.Parse(txtbestpaidcomm.Text);
                                txtbestpaidcomm.Text = bestpaid2.ToString("#####0.00");
                                act2EstrPaidComm = decimal.Parse(txtbestpaidcomm.Text);

                                txtbspcommpaid.DataBindings.Clear();
                                txtbspcommpaid.DataBindings.Add(new Binding("Text", table91, "SUM(salesperson_comm)", true));
                                decimal bsppaid2;
                                bsppaid2 = decimal.Parse(txtbspcommpaid.Text);
                                txtbspcommpaid.Text = bsppaid2.ToString("#####0.00");
                                act2SpPaidComm = decimal.Parse(txtbspcommpaid.Text);

                                txtbpmcommpaid.DataBindings.Clear();
                                txtbpmcommpaid.DataBindings.Add(new Binding("Text", table91, "SUM(projectmgr_comm)", true));
                                decimal bpmpaid2;
                                bpmpaid2 = decimal.Parse(txtbpmcommpaid.Text);
                                txtbpmcommpaid.Text = bpmpaid2.ToString("#####0.00");
                                act2PmPaidComm = decimal.Parse(txtbpmcommpaid.Text);

                                txtbpacommpaid.DataBindings.Clear();
                                txtbpacommpaid.DataBindings.Add(new Binding("Text", table91, "SUM(projectasst_comm)", true));
                                decimal bpapaid2;
                                bpapaid2 = decimal.Parse(txtbpacommpaid.Text);
                                txtbpacommpaid.Text = bpapaid2.ToString("#####0.00");
                                act2PaPaidComm = decimal.Parse(txtbpacommpaid.Text);


                                act2EstrPaidAnswer = act2GpAnswer * act2EstCommPrct - act2EstrPaidComm;
                                txtbestpaidcomm.Text = act2EstrPaidAnswer.ToString("#####0.00");

                                act2SpPaidAnswer = act2GpAnswer * act2SpCommPrct - act2SpPaidComm;
                                txtbspcommpaid.Text = act2SpPaidAnswer.ToString("#####0.00");

                                act2PmPaidAnswer = act2GpAnswer * act2PmCommPrct - act2PmPaidComm;
                                txtbpmcommpaid.Text = act2PmPaidAnswer.ToString("#####0.00");

                                act2PaPaidAnswer = act2GpAnswer * act2PaCommPrct - act2PaPaidComm;
                                txtbpacommpaid.Text = act2PaPaidAnswer.ToString("#####0.00");

                                //This is the insert statement for the billing table for actual cost second time in and the rest of the time in
                                //Darren you made chanve 10/16
                                //string commandString92 = ("INSERT into billing SET pid = '" + txtbpid.Text.Trim() + "', jid = '" + txtbjid.Text.Trim() + "', project_number = '" + txtbpjtnum.Text.Trim() + "', billing_num = '" + cbobillingnum.SelectedItem.ToString() + "', billing_amt = '" + txtbillingamt.Text.Trim() + "', billing_date = '" + mskdtxtbillingDate.Text.Trim() + "', paid_amt = '" + txtPaidAmt.Text.Trim() + "', paid_date = '" + mskdtxtpaidDate.Text.Trim() + "', estimator = '" + cbobestperson.Text.Trim() + "', estimator_percent = '" + txtbestcomm.Text.Trim() + "', estimator_comm = '" + txtbestpaidcomm.Text.Trim() + "', salesperson = '" + cbobsperson.Text.Trim() + "', salesperson_percent = '" + txtbspcomm.Text.Trim() + "', salesperson_comm = '" + txtbspcommpaid.Text.Trim() + "', projectmgr = '" + cbobpm.Text.Trim() + "', projectmgr_percent = '" + txtbpgtmgrcomm.Text.Trim() + "', projectmgr_comm = '" + txtbpmcommpaid.Text.Trim() + "', projectasst = '" + cbobpa.Text.Trim() + "', projectasst_percent = '" + txtbpjtpacomm.Text.Trim() + "', projectasst_comm = '" + txtbpacommpaid.Text.Trim() + "', project_saleamt = '" + txtbpsaleamt.Text.Trim() + "', project_estcost = '" + txtbpestcost.Text.Trim() + "', project_description = '" + txtBPrjDesc.Text.Trim() + "', project_actcost = '" + txtbpactcost.Text.Trim() + "', payest_gp = '" + txtPayEstGP.Text.Trim() + "', payest_cost = '" + txtPayEstCost.Text.Trim() + "', est_gp = '" + txtbestgp.Text.Trim() + "', payact_gp = '" + txtActGP.Text.Trim() + "', chkd_actcost = 'T' ");
                                string commandString92 = ("UPDATE into billing SET pid = '" + txtbpid.Text.Trim() + "', jid = '" + txtbjid.Text.Trim() + "', project_number = '" + txtbpjtnum.Text.Trim() + "', billing_num = '" + cbobillingnum.SelectedItem.ToString() + "', billing_amt = '" + txtbillingamt.Text.Trim() + "', billing_date = '" + mskdtxtbillingDate.Text.Trim() + "', paid_amt = '" + txtPaidAmt.Text.Trim() + "', paid_date = '" + mskdtxtpaidDate.Text.Trim() + "', estimator = '" + cbobestperson.Text.Trim() + "', estimator_percent = '" + txtbestcomm.Text.Trim() + "', estimator_comm = '" + txtbestpaidcomm.Text.Trim() + "', salesperson = '" + cbobsperson.Text.Trim() + "', salesperson_percent = '" + txtbspcomm.Text.Trim() + "', salesperson_comm = '" + txtbspcommpaid.Text.Trim() + "', projectmgr = '" + cbobpm.Text.Trim() + "', projectmgr_percent = '" + txtbpgtmgrcomm.Text.Trim() + "', projectmgr_comm = '" + txtbpmcommpaid.Text.Trim() + "', projectasst = '" + cbobpa.Text.Trim() + "', projectasst_percent = '" + txtbpjtpacomm.Text.Trim() + "', projectasst_comm = '" + txtbpacommpaid.Text.Trim() + "', project_saleamt = '" + txtbpsaleamt.Text.Trim() + "', project_estcost = '" + txtbpestcost.Text.Trim() + "', project_description = '" + txtBPrjDesc.Text.Trim() + "', project_actcost = '" + txtbpactcost.Text.Trim() + "', payest_gp = '" + txtPayEstGP.Text.Trim() + "', payest_cost = '" + txtPayEstCost.Text.Trim() + "', est_gp = '" + txtbestgp.Text.Trim() + "', payact_gp = '" + txtActGP.Text.Trim() + "', chkd_calc = 'Y'"); //WHERE bid = '" + txtbid.Text.Trim() + "'");
                                MySqlCommand mysqlcommand92 = new MySqlCommand(commandString92, MySqlConn);

                                DataTable table92 = GetDataTable(
                                    // Pass open database connection to function
                            ref MySqlConn,
                                    // Pass SQL statement to create SqlDataReader
                            commandString92);


                                string commandString221 = ("UPDATE billing_received SET psale_amt = '" + txtbpsaleamt.Text.Trim() + "', pact_cost = '" + txtbpactcost.Text.Trim() + "', payact_gp = '" + txtActGP.Text.Trim() + "', ppaid_amt = '" + txtPaidAmt.Text.Trim() + "', ppaid_date = '" + mskdtxtpaidDate.Text.Trim() + "', chkd_actcost = 'T' WHERE bid = '" + txtbid.Text.Trim() + "'");

                                MySqlCommand mysqlcommand221 = new MySqlCommand(commandString221, MySqlConn);

                                DataTable table221 = GetDataTable(
                                    // Pass open database connection to function
                            ref MySqlConn,
                                    // Pass SQL statement to create SqlDataReader
                            commandString221);

                            //    string commandString93 = ("UPDATE assignedps SET estr_tl_paid = ('" + txtbestpaidcomm.Text.Trim() + "' + estr_tl_paid), sp_tl_paid = ('" + txtbspcommpaid.Text.Trim() + "' + sp_tl_paid), pm_tl_paid = ('" + txtbpmcommpaid.Text.Trim() + "' + pm_tl_paid), pa_tl_paid = ('" + txtbpacommpaid.Text.Trim() + "' + pa_tl_paid), payact_gp = '" + txtActGP.Text.Trim() + "', prj_actcost = '" + txtbpactcost.Text.Trim() + "', chkd_actcost = 'T', apbid = LAST_INSERT_ID() WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");
                            //    MySqlCommand mysqlcommand93 = new MySqlCommand(commandString93, MySqlConn);

                            //    DataTable table93 = GetDataTable(
                            //        // Pass open database connection to function
                            //ref MySqlConn,
                            //        // Pass SQL statement to create SqlDataReader
                            //commandString93);

                                //set billing date to user format
                                String idate = mskdtxtbillingDate.Text;
                                DateTime ie = DateTime.Parse(idate);
                                mskdtxtbillingDate.Text = ie.ToString("MM/dd/yyyy");

                                //set piad date to user format
                                String ubdate = mskdtxtpaidDate.Text;
                                DateTime ube = DateTime.Parse(ubdate);
                                mskdtxtpaidDate.Text = ube.ToString("MM/dd/yyyy");

                       



                                //THe end of second time through actual cost
                                //***********************************************************************
                            }//end if add else after
                            else
                            {

                                //first time through for actual cost
                                //*********************************************************************************************************


                                string commandString7 = ("UPDATE billing SET chkd_actcost = 'T' WHERE bid = '" + txtbid.Text.Trim() + "'"); //+ txtbpjtnum.Text.Trim() + "'");

                                //UPDATE projects SET chkd_actcost = 'T' WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");
                                MySqlCommand mysqlcommand7 = new MySqlCommand(commandString7, MySqlConn);

                                DataTable table7 = GetDataTable(
                                    // Pass open database connection to function
                            ref MySqlConn,
                                    // Pass SQL statement to create SqlDataReader
                            commandString7);


                               

                                ////actual calculations
                                decimal actPaidAmt;
                                decimal actGpAnswer;
                                decimal actCost;
                                decimal actEstCommPrct;
                                decimal actEstrPaidAnswer;
                                decimal actEstrPaidComm;
                                decimal actSpCommPrct;
                                decimal actSpPaidAnswer;
                                decimal actSpPaidComm;
                                decimal actPmCommPrct;
                                decimal actPmPaidAnswer;
                                decimal actPmPaidComm;
                                decimal actPaCommPrct;
                                decimal actPaPaidAnswer;
                                decimal actPaPaidComm;



                                actEstCommPrct = decimal.Parse(txtbestcomm.Text);
                                actSpCommPrct = decimal.Parse(txtbspcomm.Text);
                                actPmCommPrct = decimal.Parse(txtbpgtmgrcomm.Text);
                                actPaCommPrct = decimal.Parse(txtbpjtpacomm.Text);

                               

                                //Darren add to the billing table the column chkd_actcost then update chkd_actcost = T 

                                if (txtPaidAmt.Text == string.Empty)
                                {
                                    MessageBox.Show("Please enter a paid amount!");
                                    return;                              

                                }

                                string u = txtbillingamt.Text.Trim();
                                txtbillingamt.Text = u.Replace(",", "");


                                String j = txtPaidAmt.Text.Trim();
                                txtPaidAmt.Text = j.Replace(",", "");
                                String tl = txtPaidAmt.Text.Trim();

                                //This adds the total paid amount for the project
                                string commandString4 = ("SELECT SUM(paid_amt) FROM billing WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");

                                MySqlCommand mysqlcommand4 = new MySqlCommand(commandString4, MySqlConn);

                                DataTable table4 = GetDataTable(
                                    // Pass open database connection to function
                            ref MySqlConn,
                                    // Pass SQL statement to create SqlDataReader
                            commandString4);



                                //totalBillingPaid = table4.Rows[t];
                                txttlpdAmt.DataBindings.Clear();
                                txttlpdAmt.DataBindings.Add(new Binding("Text", table4, "SUM(paid_amt)", true)); 
                                //adding new paid amount to the total paid amount
                                
                                decimal pdAmt;
                                decimal newpdAmt;
                                decimal finalTlAnsr;
                                 
                                
                                if (txttlpdAmt.Text.Trim() == "" || txttlpdAmt.Text.Trim() == string.Empty)
                                {

                                    pdAmt = decimal.Parse(txtPaidAmt.Text);
                                    finalTlAnsr = pdAmt;
                                    txttlpdAmt.Text = finalTlAnsr.ToString("#####0.00");

                                }
                                else
                                {
                                    pdAmt = decimal.Parse(txttlpdAmt.Text);
                                    newpdAmt = decimal.Parse(tl);
                                    finalTlAnsr = pdAmt + newpdAmt;
                                    txttlpdAmt.Text = finalTlAnsr.ToString("#####0.00");
                                }
                                    //txttlpdAmt.Text = pdAmt.ToString("#####0.00");
                                String f = txtbpactcost.Text.Trim();
                                txtbpactcost.Text = f.Replace(",", "");
                                actCost = decimal.Parse(txtbpactcost.Text);
                                actPaidAmt = decimal.Parse(txttlpdAmt.Text);


                                actGpAnswer = actPaidAmt - actCost;
                                txtActGP.Text = decimal.Round(actGpAnswer, 2).ToString();






                                //Putting the newly added totals in the text fields
                                //Darren change this to the correct table with the newly added actcost calculation,  
                            //    string commandString5 = ("SELECT estr_tl_paid, sp_tl_paid, pm_tl_paid, pa_tl_paid FROM assignedps WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");
                            //    MySqlCommand mysqlcommand5 = new MySqlCommand(commandString5, MySqlConn);

                            //    DataTable table5 = GetDataTable(
                            //        // Pass open database connection to function
                            //ref MySqlConn,
                            //        // Pass SQL statement to create SqlDataReader
                            //commandString5);


                                string commandString5 = ("SELECT SUM(estimator_comm), SUM(salesperson_comm), SUM(projectmgr_comm), SUM(projectasst_comm) FROM billing WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");
                                MySqlCommand mysqlcommand6 = new MySqlCommand(commandString5, MySqlConn);

                                DataTable table5 = GetDataTable(
                                    // Pass open database connection to function
                            ref MySqlConn,
                                    // Pass SQL statement to create SqlDataReader
                            commandString5);

                                txtbestpaidcomm.DataBindings.Clear();
                                txtbestpaidcomm.DataBindings.Add(new Binding("Text", table5, "SUM(estimator_comm)", true));
                                decimal bestpaid;
                                bestpaid = decimal.Parse(txtbestpaidcomm.Text);
                                txtbestpaidcomm.Text = bestpaid.ToString("#####0.00");
                                actEstrPaidComm = decimal.Parse(txtbestpaidcomm.Text);

                                txtbspcommpaid.DataBindings.Clear();
                                txtbspcommpaid.DataBindings.Add(new Binding("Text", table5, "SUM(salesperson_comm)", true));
                                decimal bsppaid;
                                bsppaid = decimal.Parse(txtbspcommpaid.Text);
                                txtbspcommpaid.Text = bsppaid.ToString("#####0.00");
                                actSpPaidComm = decimal.Parse(txtbspcommpaid.Text);

                                txtbpmcommpaid.DataBindings.Clear();
                                txtbpmcommpaid.DataBindings.Add(new Binding("Text", table5, "SUM(projectmgr_comm)", true));
                                decimal bpmpaid;
                                bpmpaid = decimal.Parse(txtbpmcommpaid.Text);
                                txtbpmcommpaid.Text = bpmpaid.ToString("#####0.00");
                                actPmPaidComm = decimal.Parse(txtbpmcommpaid.Text);

                                txtbpacommpaid.DataBindings.Clear();
                                txtbpacommpaid.DataBindings.Add(new Binding("Text", table5, "SUM(projectasst_comm)", true));
                                decimal bpapaid;
                                bpapaid = decimal.Parse(txtbpacommpaid.Text);
                                txtbpacommpaid.Text = bpapaid.ToString("#####0.00");
                                actPaPaidComm = decimal.Parse(txtbpacommpaid.Text);



                                //Actual calculations here
                                actEstrPaidAnswer = actGpAnswer * actEstCommPrct - actEstrPaidComm;
                                txtbestpaidcomm.Text = actEstrPaidAnswer.ToString("#####0.00");

                                actSpPaidAnswer = actGpAnswer * actSpCommPrct - actSpPaidComm;
                                txtbspcommpaid.Text = actSpPaidAnswer.ToString("#####0.00");

                                actPmPaidAnswer = actGpAnswer * actPmCommPrct - actPmPaidComm;
                                txtbpmcommpaid.Text = actPmPaidAnswer.ToString("#####0.00");

                                actPaPaidAnswer = actGpAnswer * actPaCommPrct - actPaPaidComm;
                                txtbpacommpaid.Text = actPaPaidAnswer.ToString("#####0.00");

                                //Darren add insert statement here 

                                //This is the insert statement for the billing table for actual cost first time in
                                //string commandString50 = ("INSERT into billing SET pid = '" + txtbpid.Text.Trim() + "', jid = '" + txtbjid.Text.Trim() + "', project_number = '" + txtbpjtnum.Text.Trim() + "', billing_num = '" + cbobillingnum.SelectedItem.ToString() + "', billing_amt = '" + txtbillingamt.Text.Trim() + "', billing_date = '" + mskdtxtbillingDate.Text.Trim() + "', estimator = '" + cbobestperson.Text.Trim() + "', estimator_percent = '" + txtbestcomm.Text.Trim() + "', act_estrtl_paid = '" + txtbestpaidcomm.Text.Trim() + "', salesperson = '" + cbobsperson.Text.Trim() + "', salesperson_percent = '" + txtbspcomm.Text.Trim() + "', act_sptl_paid = '" + txtbspcommpaid.Text.Trim() + "', projectmgr = '" + cbobpm.Text.Trim() + "', projectmgr_percent = '" + txtbpgtmgrcomm.Text.Trim() + "', act_pmtl_paid = '" + txtbpmcommpaid.Text.Trim() + "', projectasst = '" + cbobpa.Text.Trim() + "', projectasst_percent = '" + txtbpjtpacomm.Text.Trim() + "', act_patl_paid = '" + txtbpacommpaid.Text.Trim() + "', project_saleamt = '" + txtbpsaleamt.Text.Trim() + "', project_estcost = '" + txtbpestcost.Text.Trim() + "', project_description = '" + txtBPrjDesc.Text.Trim() + "', project_actcost = '" + txtbpactcost.Text.Trim() + "', payest_gp = '" + txtPayEstGP.Text.Trim() + "', payest_cost = '" + txtPayEstCost.Text.Trim() + "', est_gp = '" + txtbestgp.Text.Trim() + "', payact_gp = '" + txtActGP.Text.Trim() + "', chkd_actcost = 'T' ");
                                //Darren you made this update 10/16
                                //string commandString50 = ("INSERT into billing SET pid = '" + txtbpid.Text.Trim() + "', jid = '" + txtbjid.Text.Trim() + "', project_number = '" + txtbpjtnum.Text.Trim() + "', billing_num = '" + cbobillingnum.SelectedItem.ToString() + "', billing_amt = '" + txtbillingamt.Text.Trim() + "', billing_date = '" + mskdtxtbillingDate.Text.Trim() + "', paid_amt = '" + txtPaidAmt.Text.Trim() + "', paid_date = '" + mskdtxtpaidDate.Text.Trim() + "', estimator = '" + cbobestperson.Text.Trim() + "', estimator_percent = '" + txtbestcomm.Text.Trim() + "', estimator_comm = '" + txtbestpaidcomm.Text.Trim() + "', salesperson = '" + cbobsperson.Text.Trim() + "', salesperson_percent = '" + txtbspcomm.Text.Trim() + "', salesperson_comm = '" + txtbspcommpaid.Text.Trim() + "', projectmgr = '" + cbobpm.Text.Trim() + "', projectmgr_percent = '" + txtbpgtmgrcomm.Text.Trim() + "', projectmgr_comm = '" + txtbpmcommpaid.Text.Trim() + "', projectasst = '" + cbobpa.Text.Trim() + "', projectasst_percent = '" + txtbpjtpacomm.Text.Trim() + "', projectasst_comm = '" + txtbpacommpaid.Text.Trim() + "', project_saleamt = '" + txtbpsaleamt.Text.Trim() + "', project_estcost = '" + txtbpestcost.Text.Trim() + "', project_description = '" + txtBPrjDesc.Text.Trim() + "', project_actcost = '" + txtbpactcost.Text.Trim() + "', payest_gp = '" + txtPayEstGP.Text.Trim() + "', payest_cost = '" + txtPayEstCost.Text.Trim() + "', est_gp = '" + txtbestgp.Text.Trim() + "', payact_gp = '" + txtActGP.Text.Trim() + "', chkd_actcost = 'T' ");
                                string commandString50 = ("UPDATE billing SET pid = '" + txtbpid.Text.Trim() + "', jid = '" + txtbjid.Text.Trim() + "', project_number = '" + txtbpjtnum.Text.Trim() + "', billing_num = '" + cbobillingnum.SelectedItem.ToString() + "', billing_amt = '" + txtbillingamt.Text.Trim() + "', billing_date = '" + mskdtxtbillingDate.Text.Trim() + "', paid_amt = '" + txtPaidAmt.Text.Trim() + "', paid_date = '" + mskdtxtpaidDate.Text.Trim() + "', estimator = '" + cbobestperson.Text.Trim() + "', estimator_percent = '" + txtbestcomm.Text.Trim() + "', estimator_comm = '" + txtbestpaidcomm.Text.Trim() + "', salesperson = '" + cbobsperson.Text.Trim() + "', salesperson_percent = '" + txtbspcomm.Text.Trim() + "', salesperson_comm = '" + txtbspcommpaid.Text.Trim() + "', projectmgr = '" + cbobpm.Text.Trim() + "', projectmgr_percent = '" + txtbpgtmgrcomm.Text.Trim() + "', projectmgr_comm = '" + txtbpmcommpaid.Text.Trim() + "', projectasst = '" + cbobpa.Text.Trim() + "', projectasst_percent = '" + txtbpjtpacomm.Text.Trim() + "', projectasst_comm = '" + txtbpacommpaid.Text.Trim() + "', project_saleamt = '" + txtbpsaleamt.Text.Trim() + "', project_estcost = '" + txtbpestcost.Text.Trim() + "', project_description = '" + txtBPrjDesc.Text.Trim() + "', project_actcost = '" + txtbpactcost.Text.Trim() + "', payest_gp = '" + txtPayEstGP.Text.Trim() + "', payest_cost = '" + txtPayEstCost.Text.Trim() + "', est_gp = '" + txtbestgp.Text.Trim() + "', payact_gp = '" + txtActGP.Text.Trim() + "', chkd_calc = 'Y' WHERE bid = '" + txtbid.Text.Trim()+ "'"); //WHERE bid = '" + txtbid.Text.Trim() + "'"); 
                                MySqlCommand mysqlcommand50 = new MySqlCommand(commandString50, MySqlConn);

                                DataTable table50 = GetDataTable(
                                    // Pass open database connection to function
                            ref MySqlConn,
                                    // Pass SQL statement to create SqlDataReader
                            commandString50);


                                string commandString111 = ("UPDATE billing_received SET pact_cost = '" + txtbpactcost.Text.Trim() + "', payact_gp = '" + txtActGP.Text.Trim() + "', ppaid_amt = '" + txtPaidAmt.Text.Trim() + "', ppaid_date = '" + mskdtxtpaidDate.Text.Trim() + "', chkd_actcost = 'T' WHERE bid = '" + txtbid.Text.Trim() + "'");

                                MySqlCommand mysqlcommand111 = new MySqlCommand(commandString111, MySqlConn);

                                DataTable table111 = GetDataTable(
                                    // Pass open database connection to function
                            ref MySqlConn,
                                    // Pass SQL statement to create SqlDataReader
                            commandString111);

                            //    //adding the estimator,sp, pm, pa totals for actual cost to the assigned ps based on bid
                            //    string commandString78 = ("UPDATE assignedps SET estr_tl_paid = ('" + txtbestpaidcomm.Text.Trim() + "' + estr_tl_paid), sp_tl_paid = ('" + txtbspcommpaid.Text.Trim() + "' + sp_tl_paid), pm_tl_paid = ('" + txtbpmcommpaid.Text.Trim() + "' + pm_tl_paid), pa_tl_paid = ('" + txtbpacommpaid.Text.Trim() + "' + pa_tl_paid), payact_gp = '" + txtActGP.Text.Trim() + "', prj_actcost = '" + txtbpactcost.Text.Trim() + "', chkd_actcost = 'T', apbid = LAST_INSERT_ID() WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");
                            //    MySqlCommand mysqlcommand78 = new MySqlCommand(commandString78, MySqlConn);

                            //    DataTable table78 = GetDataTable(
                            //        // Pass open database connection to function
                            //ref MySqlConn,
                            //        // Pass SQL statement to create SqlDataReader
                            //commandString78);


                                //set billing date to user format
                                String ndate = mskdtxtbillingDate.Text;
                                DateTime ne = DateTime.Parse(ndate);
                                mskdtxtbillingDate.Text = ne.ToString("MM/dd/yyyy");

                                //set piad date to user format
                                String nbdate = mskdtxtpaidDate.Text;
                                DateTime nbe = DateTime.Parse(nbdate);
                                mskdtxtpaidDate.Text = nbe.ToString("MM/dd/yyyy");
                                


                            }
                        }



                       

                        //Dont forget to update the gridview
                        string commandString65 = ("SELECT bid, project_number, project_name, billing_num, billing_amt, billing_date, paid_amt, paid_date, estimator, estimator_percent, estimator_comm, salesperson, salesperson_percent, salesperson_comm, projectmgr, projectmgr_percent, projectmgr_comm, projectasst, projectasst_percent, projectasst_comm, project_saleamt, project_estcost, project_description, project_actcost, payest_gp, payest_cost, est_gp, payact_gp FROM billing WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");

                        MySqlCommand mysqlcommand65 = new MySqlCommand(commandString65, MySqlConn);

                        DataTable table65 = GetDataTable(
                            // Pass open database connection to function
                    ref MySqlConn,
                            // Pass SQL statement to create SqlDataReader
                    commandString65);

                        dataGridView1.DataSource = table65;
                        dataGridView1.Refresh();
                        dataGridView1.Enabled = false;

                        
                    }
                    }
               // }

            }
            else
            {


                //check on billing date and paid date
                String qxdate = mskdtxtbillingDate.Text;
                DateTime qxe = DateTime.Parse(qxdate);
                mskdtxtbillingDate.Text = qxe.ToString("MM/dd/yyyy");

                String hdate = mskdtxtbillingDate.Text.Trim();
                DateTime hrz = DateTime.ParseExact(hdate, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                mskdtxtbillingDate.Text = hrz.ToString("yyyy-MM-dd");


                //this converts the paid date into mysql date
                //comes in as '10/25/2011' month day year
                //needs to be '2011-10-25' Year-month-day
                if (mskdtxtpaidDate.Text == string.Empty)
                {
                    string ff = "01/01/0001";
                    mskdtxtpaidDate.Text = ff;
                    String hzzdate = mskdtxtpaidDate.Text.Trim();
                    DateTime hsw = DateTime.ParseExact(hzzdate, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                    mskdtxtpaidDate.Text = hsw.ToString("yyyy-MM-dd");
                }
                else
                {
                    String hbdate = mskdtxtpaidDate.Text;
                    DateTime hbe = DateTime.Parse(hbdate);
                    mskdtxtpaidDate.Text = hbe.ToString("MM/dd/yyyy");

                    String hpdate = mskdtxtpaidDate.Text.Trim();
                    DateTime htv = DateTime.ParseExact(hpdate, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                    mskdtxtpaidDate.Text = htv.ToString("yyyy-MM-dd");
                }

                //estimated cost

                decimal paidAmt;
                decimal estAmt;
                decimal actAmt;
                decimal estCommPrct;
                decimal estAnswer;
                decimal spCommPrct;
                decimal spAnswer;
                decimal pmCommPrct;
                decimal pmAnswer;
                decimal paCommPrct;
                decimal paAnswer;
                decimal estGpAnswer;
                decimal paymentEstCost;
                decimal paymentEstCostEstGP;
                decimal saleAmt;
                decimal totalBillingPaid;                              
                decimal payEstCost;


                //This removes commas from the paid amt
                String f = txtPaidAmt.Text.Trim();
                txtPaidAmt.Text = f.Replace(",", "");

                paidAmt = decimal.Parse(txtPaidAmt.Text);
                estAmt = decimal.Parse(txtbpestcost.Text);
                //actAmt = double.Parse(txtbpactcost.Text);
                if (txtbestcomm.Text == "")
                {
                    txtbestcomm.Text = "0.00";
                }
                estCommPrct = decimal.Parse(txtbestcomm.Text);
                if (txtbspcomm.Text == "")
                {
                    txtbspcomm.Text = "0.00";
                }
                spCommPrct = decimal.Parse(txtbspcomm.Text);
                if (txtbpgtmgrcomm.Text == "")
                {
                    txtbpgtmgrcomm.Text = "0.00";
                }
                pmCommPrct = decimal.Parse(txtbpgtmgrcomm.Text);
                if (txtbpjtpacomm.Text == "")
                {
                    txtbpjtpacomm.Text = "0.00";
                }
                paCommPrct = decimal.Parse(txtbpjtpacomm.Text);
                saleAmt = decimal.Parse(txtbpsaleamt.Text);



               

                
                //this is for the payment estimated Cost
                paymentEstCost = paidAmt / saleAmt * estAmt;
                txtPayEstCost.Text = decimal.Round(paymentEstCost, 2).ToString();
                payEstCost = decimal.Parse(txtPayEstCost.Text);
                //this is for the payment estimated GP
                paymentEstCostEstGP = paidAmt - paymentEstCost;
                txtPayEstGP.Text = decimal.Round(paymentEstCostEstGP, 2).ToString();
                ////estimator calculation
                estAnswer = paymentEstCostEstGP * estCommPrct;
                txtbestpaidcomm.Text = decimal.Round(estAnswer, 2).ToString();
                ////salesperson calculation
                spAnswer = paymentEstCostEstGP * spCommPrct;
                txtbspcommpaid.Text = decimal.Round(spAnswer, 2).ToString();
                ////pm calculation
                pmAnswer = paymentEstCostEstGP * pmCommPrct;
                txtbpmcommpaid.Text = decimal.Round(pmAnswer, 2).ToString();
                //pa calculation
                paAnswer = paymentEstCostEstGP * paCommPrct;
                txtbpacommpaid.Text = decimal.Round(paAnswer, 2).ToString();
                //estimated gross profit
                
                estGpAnswer = paidAmt - payEstCost;
                txtbestgp.Text = decimal.Round(estGpAnswer, 2).ToString();
                
                //*********************************************assigned ps table*****************************************************

                //adding the estimator totals to the assigned ps based on bid
            //    string commandString33 = ("UPDATE assignedps SET estr_tl_paid = ('" + txtbestpaidcomm.Text.Trim() + "' + estr_tl_paid) WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");
            //    MySqlCommand mysqlcommand33 = new MySqlCommand(commandString33, MySqlConn);

            //    DataTable table33 = GetDataTable(
            //        // Pass open database connection to function
            //ref MySqlConn,
            //        // Pass SQL statement to create SqlDataReader
            //commandString33);


                //adding the salespersons totals to the assigned ps based on bid
            //    string commandString34 = ("UPDATE assignedps SET sp_tl_paid = ('" + txtbspcommpaid.Text.Trim() + "' + sp_tl_paid) WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");
            //    MySqlCommand mysqlcommand34 = new MySqlCommand(commandString34, MySqlConn);

            //    DataTable table34 = GetDataTable(
            //        // Pass open database connection to function
            //ref MySqlConn,
            //        // Pass SQL statement to create SqlDataReader
            //commandString34);

                //adding the pm totals to the assigned ps based on bid
            //    string commandString35 = ("UPDATE assignedps SET pm_tl_paid = ('" + txtbpmcommpaid.Text.Trim() + "' + pm_tl_paid) WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");
            //    MySqlCommand mysqlcommand35 = new MySqlCommand(commandString35, MySqlConn);

            //    DataTable table35 = GetDataTable(
            //        // Pass open database connection to function
            //ref MySqlConn,
            //        // Pass SQL statement to create SqlDataReader
            //commandString35);

                //adding the pa totals to the assigned ps table based on bid
            //    string commandString36 = ("UPDATE assignedps SET pa_tl_paid = ('" + txtbpacommpaid.Text.Trim() + "' + pa_tl_paid) WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");
            //    MySqlCommand mysqlcommand36 = new MySqlCommand(commandString36, MySqlConn);

            //    DataTable table36 = GetDataTable(
            //        // Pass open database connection to function
            //ref MySqlConn,
            //        // Pass SQL statement to create SqlDataReader
            //commandString36);


                //adding the new totals to the assignedps tabel based on bid
            //    string commandString41 = ("UPDATE assignedps SET payest_gp = '" + txtPayEstGP.Text.Trim() + "', payest_cost = '" + txtPayEstCost.Text.Trim() + "', est_gp = '" + txtbestgp.Text.Trim() + "' WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");
            //    MySqlCommand mysqlcommand41 = new MySqlCommand(commandString41, MySqlConn);
            //    DataTable table41 = GetDataTable(
            //        // Pass open database connection to function
            //ref MySqlConn,
            //        // Pass SQL statement to create SqlDataReader
            //commandString41);
                
                

                //*******************************************billing table section***********************************************
                
                //adding the estimator, salesperson, pm, pa, payment gp, payment estimated cost, estimated gross profit billing totals to the billing table based on bid
                string commandString37 = ("UPDATE billing SET billing_num = '" + cbobillingnum.SelectedItem.ToString() + "', billing_amt = '" + txtbillingamt.Text.Trim() + "', billing_date = '" + mskdtxtbillingDate.Text.Trim() + "', paid_amt = '" + txtPaidAmt.Text.Trim() + "', paid_date = '" + mskdtxtpaidDate.Text.Trim() + "', estimator_comm = '" + txtbestpaidcomm.Text.Trim() + "', salesperson_comm = '" + txtbspcommpaid.Text.Trim() + "', projectmgr_comm = '" + txtbpmcommpaid.Text.Trim() + "', projectasst_comm = '" + txtbpacommpaid.Text.Trim() + "', payest_gp = '" + txtPayEstGP.Text.Trim() + "', payest_cost = '" + txtPayEstCost.Text.Trim() + "', est_gp = '" + txtbestgp.Text.Trim() + "', paid_stmt = 'Y', chkd_calc = 'Y' WHERE bid = '" + txtbid.Text.Trim() + "'");
                MySqlCommand mysqlcommand37 = new MySqlCommand(commandString37, MySqlConn);
                DataTable table37 = GetDataTable(
                    // Pass open database connection to function
            ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
            commandString37);

              //**************************************billing received table section
                string commandString331 = ("UPDATE billing_received SET payest_gp = '" + txtPayEstGP.Text.Trim() + "', payest_cost = '" + txtPayEstCost.Text.Trim() + "', est_gp = '" + txtbestgp.Text.Trim() + "', payact_gp = '" + txtActGP.Text.Trim() + "', pbilling_cycle = '" + cbobillingnum.SelectedItem.ToString() + "', pbilling_amt = '" + txtbillingamt.Text.Trim() + "', pbilling_date = '" + mskdtxtbillingDate.Text.Trim() + "', ppaid_amt = '" + txtPaidAmt.Text.Trim() + "', ppaid_date = '" + mskdtxtpaidDate.Text.Trim() + "' WHERE bid = '" + txtbid.Text.Trim() + "'");

                MySqlCommand mysqlcommand331 = new MySqlCommand(commandString331, MySqlConn);

                DataTable table331 = GetDataTable(
                    // Pass open database connection to function
            ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
            commandString331);


                //*********************************update the datagridview with the newly added totals********************************
                string commandString19 = ("SELECT bid, project_number, project_name, billing_num, billing_amt, billing_date, paid_amt, paid_date, estimator, estimator_percent, estimator_comm, salesperson, salesperson_percent, salesperson_comm, projectmgr, projectmgr_percent, projectmgr_comm, projectasst, projectasst_percent, projectasst_comm, project_saleamt, project_estcost, project_description, project_actcost, payest_gp, payest_cost, est_gp, payact_gp, paid_stmt FROM billing WHERE project_number = '" + txtbpjtnum.Text.Trim() + "'");
                MySqlCommand mysqlcommand19 = new MySqlCommand(commandString19, MySqlConn);
                DataTable table19 = GetDataTable(
                    // Pass open database connection to function
           ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
           commandString19);

                dataGridView1.DataSource = table19;
                dataGridView1.Refresh();
                //dataGridView1.Enabled = false;

                //decimal.Round(paAnswer, 2);//paAnswer.ToString();
                //txtbpacommpaid.Text = paAnswer.ToString();

                //set billing date to user format
                String mdate = mskdtxtbillingDate.Text;
                DateTime me = DateTime.Parse(mdate);
                mskdtxtbillingDate.Text = me.ToString("MM/dd/yyyy");

                //set piad date to user format
                String mubdate = mskdtxtpaidDate.Text;
                DateTime mube = DateTime.Parse(mubdate);
                mskdtxtpaidDate.Text = mube.ToString("MM/dd/yyyy");

                //Darren put update statement here for new totals

            }

            
        }





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

        private void butxlsexp_Click(object sender, EventArgs e)
        {

            Form Reporting = new Reporting();
            Reporting.Show();
        }


        private void chbkestcost_CheckedChanged(object sender, EventArgs e)
        {
            
            chbkactualcost.Enabled = false;
            txtbpactcost.Clear();
            txtbpactcost.Enabled = false;
            if (chbkestcost.Checked == false)
            {
                chbkactualcost.Enabled = true;
                txtbpactcost.Enabled = true;
            }

        }

        private void chbkactualcost_CheckedChanged(object sender, EventArgs e)
        {

            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(connectionString);


            //Darren add the paid totals for the project here that means every billing statement gets added as a total
            chbkestcost.Enabled = false;
            txtbpestcost.Enabled = false;
            txtPayEstCost.Enabled = false;
            if (chbkactualcost.Checked == false)
            {
                chbkestcost.Enabled = true;
                txtbpestcost.Enabled = true;
                txtPayEstCost.Enabled = true;
            }


        }

        private void cbounpbill_SelectedIndexChanged(object sender, EventArgs e)
        {
                //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
                string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
                MySqlConnection MySqlConn = new MySqlConnection(connectionString);


                string commandString62 = ("SELECT bid, project_number, billing_num, billing_amt, billing_date, paid_amt, paid_date, estimator, estimator_percent, estimator_comm, salesperson, salesperson_percent, salesperson_comm, projectmgr, projectmgr_percent, projectmgr_comm, projectasst, projectasst_percent, projectasst_comm, project_saleamt, project_estcost, project_description, project_actcost, payest_gp, payest_cost, est_gp, payact_gp FROM billing WHERE billing_num = '" + cbounpbill.SelectedItem.ToString() + "' AND project_number = '" +txtbpjtnum.Text.Trim() + "'");//, AND jid = '" + txtbjid.Text + "'");
                MySqlCommand mysqlcommand62 = new MySqlCommand(commandString62, MySqlConn);

                DataTable table62 = GetDataTable(
                    // Pass open database connection to function
       ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
       commandString62);

                //cbobestperson.DataBindings.Clear();
                // cbobestperson.DataBindings.Add(new Binding("Text", table22, "assigned_estimator", true));
                txtbid.DataBindings.Clear();
                txtbid.DataBindings.Add(new Binding("Text", table62, "bid", true));
                txtbpjtnum.DataBindings.Clear();
                txtbpjtnum.DataBindings.Add(new Binding("Text", table62, "project_number", true));
                cbobillingnum.DataBindings.Clear();
                cbobillingnum.DataBindings.Add(new Binding("Text", table62, "billing_num", true));
                txtbillingamt.DataBindings.Clear();
                txtbillingamt.DataBindings.Add(new Binding("Text", table62, "billing_amt", true));
                mskdtxtbillingDate.DataBindings.Clear();
                mskdtxtbillingDate.DataBindings.Add(new Binding("Text", table62, "billing_date", true));
                txtPaidAmt.DataBindings.Clear();
                txtPaidAmt.DataBindings.Add(new Binding("Text", table62, "paid_amt", true));
                mskdtxtpaidDate.DataBindings.Clear();
                mskdtxtpaidDate.DataBindings.Add(new Binding("Text", table62, "paid_date", true));
                cbobestperson.DataBindings.Clear();
                cbobestperson.DataBindings.Add(new Binding("Text", table62, "estimator", true));
                txtbestcomm.DataBindings.Clear();
                txtbestcomm.DataBindings.Add(new Binding("Text", table62, "estimator_percent", true));
                txtbestpaidcomm.DataBindings.Clear();
                txtbestpaidcomm.DataBindings.Add(new Binding("Text", table62, "estimator_comm", true));
                cbobsperson.DataBindings.Clear();
                cbobsperson.DataBindings.Add(new Binding("TExt", table62, "salesperson", true));
                txtbspcomm.DataBindings.Clear();
                txtbspcomm.DataBindings.Add(new Binding("Text", table62, "salesperson_percent", true));
                txtbspcommpaid.DataBindings.Clear();
                txtbspcommpaid.DataBindings.Add(new Binding("Text", table62, "salesperson_comm", true));
                cbobpm.DataBindings.Clear();
                cbobpm.DataBindings.Add(new Binding("Text", table62, "projectmgr", true));
                txtbpgtmgrcomm.DataBindings.Clear();
                txtbpgtmgrcomm.DataBindings.Add(new Binding("Text", table62, "projectmgr_percent", true));
                txtbpmcommpaid.DataBindings.Clear();
                txtbpmcommpaid.DataBindings.Add(new Binding("Text", table62, "projectmgr_comm", true));
                cbobpa.DataBindings.Clear();
                cbobpa.DataBindings.Add(new Binding("Text", table62, "projectasst", true));
                txtbpjtpacomm.DataBindings.Clear();
                txtbpjtpacomm.DataBindings.Add(new Binding("Text", table62, "projectasst_percent", true));
                txtbpacommpaid.DataBindings.Clear();
                txtbpacommpaid.DataBindings.Add(new Binding("Text", table62, "projectasst_comm", true));
                txtbpsaleamt.DataBindings.Clear();
                txtbpsaleamt.DataBindings.Add(new Binding("Text", table62, "project_saleamt", true));
                txtbpestcost.DataBindings.Clear();
                txtbpestcost.DataBindings.Add(new Binding("Text", table62, "project_estcost", true));
                txtBPrjDesc.DataBindings.Clear();
                txtBPrjDesc.DataBindings.Add(new Binding("Text", table62, "project_description", true));
                txtbpactcost.DataBindings.Clear();
                txtbpactcost.DataBindings.Add(new Binding("Text", table62, "project_actcost", true));
                txtPayEstGP.DataBindings.Clear();
                txtPayEstGP.DataBindings.Add(new Binding("Text", table62, "payest_gp", true));
                txtPayEstCost.DataBindings.Clear();
                txtPayEstCost.DataBindings.Add(new Binding("Text", table62, "payest_cost", true));
                txtbestgp.DataBindings.Clear();
                txtbestgp.DataBindings.Add(new Binding("Text", table62, "est_gp", true));
                txtActGP.DataBindings.Clear();
                txtActGP.DataBindings.Add(new Binding("Text", table62, "payact_gp", true));

                String ndate = mskdtxtbillingDate.Text;
                DateTime ne = DateTime.Parse(ndate);
                mskdtxtbillingDate.Text = ne.ToString("MM/dd/yyyy");


                if (mskdtxtpaidDate.Text == "")
                {
                    mskdtxtpaidDate.Clear();
                    if (mskdtxtpaidDate.Text == "0001-01-01")
                    {
                        mskdtxtpaidDate.Clear();
                    }
                }
                else
                {
                    String udate = mskdtxtpaidDate.Text;
                    DateTime ue = DateTime.Parse(udate);
                    mskdtxtpaidDate.Text = ue.ToString("MM/dd/yyyy");

                    //String ldate = mskdtxtpaidDate.Text.Trim();
                    //DateTime lv = DateTime.ParseExact(ldate, "MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None);
                    //mskdtxtpaidDate.Text = lv.ToString("yyyy-MM-dd");
                }
                

        }

        //private void txtPayEstCost_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtPayEstCost_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void txtActGP_TextChanged(object sender, EventArgs e)
        //{

        //}

        
    }
}
