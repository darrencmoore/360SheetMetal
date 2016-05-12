using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using WindowsFormsApplication1;
using System.Configuration;


//using WindowsFormsApplication1.companyDSTableAdapters;



namespace WindowsFormsApplication1
{
    public partial class Projects : Form
    {
        public static string token3;
        public static string token4;
        public static string token5;
        public static string token6;
        public static string token7;
        public static string token8;
        public static string token9;
        public static string token10;
        public static string token11;
        public static string token12;
        public static string token13;
        public static string token14;
        public static string token15;
        public static string token16;
        public static string token17;
        public static string token23;
        public static string token30;
        public static string t;
        public static string holder;

        public Projects()
        {
            InitializeComponent();
            txtpjid.Text = Form1.token;
            txtccid.Text = Form1.token22;
           
            //txtprjpid.Text = Form1.token2;
            
        }

        BindingSource bs = new BindingSource();
        public DataTable GetDataTable(
        ref System.Data.SqlClient.SqlConnection _nSqlConnection,
        string _nSQL)
        {
            //new SQL Server
            // New SQL connection to a command object
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

            // Adds or refreshes rows in the DataSet to match those in the data source
            try
            {
                _nSqlDataAdapter.Fill(_nDataTable);
            }
            catch (Exception _Exception)
            {
                // Error occurred while trying to execute reader
                // send error message to console (change below line to customize error handling)
                // Console.WriteLine(_Exception.Message);
                //MessageBox(_Exception);
                return null;
            }

            return _nDataTable;
        }


        //*****************************************************THis function loads the datagrid from the job datagrid view click
        private void Projects_Load(object sender, EventArgs e)
        {

            //DAta List of blank rows to be removed
            List<DataRow> estRowsRemove = new List<DataRow>();
            List<DataRow> spRowsRemove = new List<DataRow>();
            List<DataRow> pmRowsRemove = new List<DataRow>();
            List<DataRow> paRowsRemove = new List<DataRow>();


            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            SqlConnection SqlConn = new SqlConnection(connectionString);

            SqlConn.Open();


            //**************************************THis command populates the estimator drop down
            string commandString31 = ("SELECT ALL psname FROM projectstaff");
            SqlCommand mysqlcommand = new SqlCommand(commandString31, SqlConn);

            DataTable table = GetDataTable(
                // Pass open database connection to function
        ref SqlConn,
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
                    if (item == "")
                    {
                        estRowsRemove.Add(row);
                    }
                    else
                    {
                        cbopjsestr.Items.Add(item);
                        row.Delete();
                    }   
                }
            }


        //    //*******************************************************This command populates the salesperson drop down box
            string commandString32 = ("SELECT ALL psname FROM projectstaff");
            SqlCommand mysqlcommand32 = new SqlCommand(commandString32, SqlConn);

            DataTable table32 = GetDataTable(
                // Pass open database connection to function
        ref SqlConn,
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
                    if (item == "")
                    {
                        spRowsRemove.Add(row);
                    }
                    else
                    {
                        cbopjssp.Items.Add(item);
                        row.Delete();
                    }
                }
            }



        //    //***********************************************************This command populates the project manager drop down box
            string commandString33 = ("SELECT ALL psname FROM projectstaff");
            SqlCommand mysqlcommand33 = new SqlCommand(commandString33, SqlConn);

            DataTable table33 = GetDataTable(
                // Pass open database connection to function
        ref SqlConn,
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
                    if (item == "")
                    {
                        pmRowsRemove.Add(row);
                    }
                    else
                    {
                        cboprjpm.Items.Add(item);
                        row.Delete();
                    }
                }
            }
            


        //    //***************************************************This command populates the project assistant screen
            string commandString34 = ("SELECT ALL psname FROM projectstaff");
            SqlCommand mysqlcommand34 = new SqlCommand(commandString34, SqlConn);

            DataTable table34 = GetDataTable(
                // Pass open database connection to function
        ref SqlConn,
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
                    if (item == "")
                    {
                        paRowsRemove.Add(row);
                    }
                    else
                    {
                        cbopjpa.Items.Add(item);
                        row.Delete();
                    }
                }
            }




            txtpjtnum.Enabled = false;
            txtPrjtName.Enabled = false;
            txtsaleamt.Enabled = false;
            txtestcost.Enabled = false;           
            txtestcommpert.Enabled = false;
            txtspcommpert.Enabled = false;
            txtprjmgrcomm.Enabled = false;
            txtprjasstcomm.Enabled = false;
            cbopjsestr.Enabled = false;
            cbopjssp.Enabled = false;
            cboprjpm.Enabled = false;
            cbopjpa.Enabled = false;

            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            //MySqlConnection MySqlConn = new MySqlConnection(connectionString);

            string commandString4 = ("SELECT pid, jid, project_number, project_name, sale_amount, estimated_cost, estimator, estimator_commission_percentage, salesperson, salesperson_commission_percentage, projectmgr, projectmgr_commission_percentage, projectasst, projectasst_commission_percentage, description FROM projects WHERE jid = '" + txtpjid.Text.Trim() + "'");
            SqlCommand mysqlcommand4 = new SqlCommand(commandString4, SqlConn);
            DataTable table3 = GetDataTable(
                // Pass open database connection to function
   ref SqlConn,
                // Pass SQL statement to create SqlDataReader
   commandString4);



            dataGridView1.DataSource = table3;
            dataGridView1.Refresh();
            cboprjnumlist.Items.Clear();


            foreach (DataRow row in table3.Rows)
            {
                String item = (row["project_number"].ToString());

                cboprjnumlist.Items.Add(item);
                //cbocname.Items.Add(item);
                //cbojcname.Items.Add(item);
            }


            


        }


        //This is for the datagrid on the projects screen
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            


            txtpjtnum.Text = " ";
            txtPrjtName.Text = " ";
            txtsaleamt.Text = " ";
            txtestcost.Text = " ";           
            txtestcommpert.Text = " ";
            txtspcommpert.Text = " ";
            txtprjmgrcomm.Text = " ";
            txtprjasstcomm.Text = " ";
            cbopjsestr.Text = " ";
            cbopjssp.Text = " ";
            cboprjpm.Text = " ";
            cbopjpa.Text = " ";
            txtPrjDesc.Text = " ";

            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            txtprjpid.Text = (String)dataGridView1["pid", e.RowIndex].Value.ToString();
            txtpjid.Text = (String)dataGridView1["jid", e.RowIndex].Value.ToString();
            txtpjtnum.Text = (String)dataGridView1["project_number", e.RowIndex].Value.ToString();
            txtPrjtName.Text = (String)dataGridView1["project_name", e.RowIndex].Value.ToString();
            txtsaleamt.Text = (String)dataGridView1["sale_amount", e.RowIndex].Value.ToString();
            txtestcost.Text = (String)dataGridView1["estimated_cost", e.RowIndex].Value.ToString();
            cbopjsestr.Text = (String)dataGridView1["estimator", e.RowIndex].Value.ToString();
            txtestcommpert.Text = (String)dataGridView1["estimator_commission_percentage", e.RowIndex].Value.ToString();
            cbopjssp.Text = (String)dataGridView1["salesperson", e.RowIndex].Value.ToString();
            txtspcommpert.Text = (String)dataGridView1["salesperson_commission_percentage", e.RowIndex].Value.ToString();
            cboprjpm.Text = (String)dataGridView1["projectmgr", e.RowIndex].Value.ToString();
            txtprjmgrcomm.Text = (String)dataGridView1["projectmgr_commission_percentage", e.RowIndex].Value.ToString();
            cbopjpa.Text = (String)dataGridView1["projectasst", e.RowIndex].Value.ToString();
            txtprjasstcomm.Text = (String)dataGridView1["projectasst_commission_percentage", e.RowIndex].Value.ToString();
            txtPrjDesc.Text = (String)dataGridView1["description", e.RowIndex].Value.ToString();
            //txtactCost.Text = (String)dataGridView1["actual_cost", e.RowIndex].Value.ToString();
            token3 = txtprjpid.Text.Trim();
            token4 = txtpjtnum.Text.Trim();
            token30 = txtPrjtName.Text.Trim();
            token5 = txtestcommpert.Text.Trim();
            token6 = txtspcommpert.Text.Trim();
            token7 = txtprjmgrcomm.Text.Trim();
            token8 = txtprjasstcomm.Text.Trim();
            token9 = txtpjid.Text.Trim();
            token23 = txtccid.Text.Trim();
            token10 = cbopjsestr.Text.Trim();
            //token10 = cbopjsestr.SelectedItem.ToString();
            token11 = cbopjssp.Text.Trim();
            token12 = cboprjpm.Text.Trim();
            token13 = cbopjpa.Text.Trim();
            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            //string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
           // MySqlConnection MySqlConn = new MySqlConnection(connectionString);




            



            //this enables all the button the project screen
            txtpjtnum.Enabled = true;
            txtPrjtName.Enabled = true;
            txtsaleamt.Enabled = true;
            txtestcost.Enabled = true;           
            txtestcommpert.Enabled = true;
            txtspcommpert.Enabled = true;
            txtprjmgrcomm.Enabled = true;
            txtprjasstcomm.Enabled = true;
            cbopjsestr.Enabled = true;
            cbopjssp.Enabled = true;
            cboprjpm.Enabled = true;
            cbopjpa.Enabled = true;


            //token10 = cbopjsestr.SelectedItem.ToString();
            //token11 = cbopjssp.SelectedItem.ToString();
            //token12 = cboprjpm.SelectedItem.ToString();
            //token13 = cbopjpa.SelectedItem.ToString();
            
        }


        //*********************************************************This function enables the text boxes for data entry
        private void insrtnewprjbut_Click(object sender, EventArgs e)
        {
            //clear the job id for insert of new project
            //txtpjid.Text = " ";

            txtpjtnum.Enabled = true;
            txtPrjtName.Enabled = true;
            txtsaleamt.Enabled = true;
            txtestcost.Enabled = true;            
            txtestcommpert.Enabled = true;
            txtspcommpert.Enabled = true;
            txtprjmgrcomm.Enabled = true;
            txtprjasstcomm.Enabled = true;
            cbopjsestr.Enabled = true;
            //cboEstr.Enabled = true;
            cbopjssp.Enabled = true;
            //cboSp.Enabled = true;
            cboprjpm.Enabled = true;
            //cboPm.Enabled = true;
            cbopjpa.Enabled = true;
            //cboPa.Enabled = true;
            txtPrjDesc.Enabled = true;


            if (txtpjtnum.Enabled == true)
            {
                txtpjtnum.Text = " ";
            }

            if (txtPrjtName.Enabled == true)
            {
                txtPrjtName.Text = " ";
            }

            if (txtsaleamt.Enabled == true)
            {
                txtsaleamt.Text = " ";

            }

            if (txtestcost.Enabled == true)
            {
                txtestcost.Text = " ";
            }

            if (txtestcommpert.Enabled == true)
            {
                txtestcommpert.Text = " ";
            }

            if (txtspcommpert.Enabled == true)
            {
                txtspcommpert.Text = " ";
            }

            if (txtprjmgrcomm.Enabled == true)
            {
                txtprjmgrcomm.Text = " ";
            }

            if (txtprjasstcomm.Enabled == true)
            {
                txtprjasstcomm.Text = " ";
            }

            if (cbopjsestr.Enabled == true)
            {
                cbopjsestr.Text = " ";
            }

            //if (cboEstr.Enabled == true)
            //{
            //    cboEstr.Text = " ";

            //}

            if (cbopjssp.Enabled == true)
            {
                cbopjssp.Text = " ";
            }

            //if (cboSp.Enabled == true)
            //{
            //    cboSp.Text = " ";

            //}

            if (cboprjpm.Enabled == true)
            {
                cboprjpm.Text = " ";
            }

            //if (cboPm.Enabled == true)
            //{
            //    cboPm.Text = " ";

            //}

            if (cbopjpa.Enabled == true)
            {
                cbopjpa.Text = " ";
            }


            //if (cboPa.Enabled == true)
            //{
            //    cboPa.Text = " ";

            //}


            if (txtPrjDesc.Enabled == true)
            {
                txtPrjDesc.Text = " ";
                
            }

            

           

           

           

            //txtpjtnum.Enabled = true;
            //txtsaleamt.Enabled = true;
            //txtestcost.Enabled = true;
            //txtactCost.Enabled = true;
            //txtestcommpert.Enabled = true;
            //txtspcommpert.Enabled = true;
            //txtprjmgrcomm.Enabled = true;
            //txtprjasstcomm.Enabled = true;
            //cbopjsestr.Enabled = true;
            //cbopjssp.Enabled = true;
            //cboprjpm.Enabled = true;
            //cbopjpa.Enabled = true;
            //txtPrjDesc.Enabled = true;
        }




        //******************************************************************THis function inserts a new project and populates the project
        //******************************************************************gridview with the newly added row 
        //******************************************************************this functionis good for second round modifications
        private void insrtprjbut_Click(object sender, EventArgs e)
        {
            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            SqlConnection MySqlConn = new SqlConnection(connectionString);
            //decimal checkNum = 0;

            if (txtpjtnum.Text == string.Empty)
            {
                errorProvider2.SetError(txtpjtnum, "Please Enter a Project Number");
            }
            if (txtPrjtName.Text == string.Empty)
            {
                errorProvider2.SetError(txtPrjtName, "Please Enter a Project Name");
            }
            if (txtsaleamt.Text == string.Empty)
            {
                errorProvider2.SetError(txtsaleamt, "Please Enter a Sale Amount");
            }
            if (txtestcost.Text == string.Empty)
            {
                errorProvider2.SetError(txtestcost, "Please Enter a Estimated Cost");
            }
            if (txtestcommpert.Text == " ")
            {
                //errorProvider2.SetError(txtestcommpert, "Estimator comission percent is blank");
                DialogResult dr = MessageBox.Show("Estimator comission percent is blank, do you wish to continue?", "Important Question", MessageBoxButtons.YesNo);
                
            }
            //else if (txtestcommpert.Text != string.Empty)
            //{
            //    decimal value;
            //    bool isValid = decimal.TryParse(txtestcommpert.Text, out value);

            //    if (isValid != true)
            //    {
            //        throw new ArgumentException("Input must be a decimal value");
            //    }
                
            //}
            if (txtspcommpert.Text == " ")
            {
                //errorProvider2.SetError(txtspcommpert, "Salesperson comission percent is blank");
                DialogResult dr = MessageBox.Show("Salesperson comission percent is blank, do you wish to continue?", "Important Question", MessageBoxButtons.YesNo);
                
            }
            //else if (txtspcommpert.Text != string.Empty)
            //{
            //    decimal value1;
            //    bool isValid = decimal.TryParse(txtestcommpert.Text, out value1);

            //    if (isValid != true)
            //    {
            //        throw new ArgumentException("Input must be a decimal value");
            //    }
            //}
            if (txtprjmgrcomm.Text == " ")
            {
                //errorProvider2.SetError(txtprjmgrcomm, "PM comission percent is blank");
                DialogResult dr = MessageBox.Show("PM comission percent is blank, do you wish to continue?", "Important Question", MessageBoxButtons.YesNo);
                
            }
            //else if (txtprjmgrcomm.Text != string.Empty)
            //{
            //    decimal value2;
            //    bool isValid = decimal.TryParse(txtestcommpert.Text, out value2);

            //    if (isValid != true)
            //    {
            //        throw new ArgumentException("Input must be a decimal value");
            //    }
            //}
            if (txtprjasstcomm.Text == " ")
            {
                //errorProvider2.SetError(txtspcommpert, "PA comission percent is blank");
                DialogResult dr = MessageBox.Show("PA comission percent is blank, do you wish to continue?", "Important Question", MessageBoxButtons.YesNo);
                
                
            }
            //else if (txtprjasstcomm.Text != string.Empty)// == checkNum.ToString())
            //{
            //    decimal value3;
            //    bool isValid = decimal.TryParse(txtestcommpert.Text, out value3);

            //    if (isValid != true)
            //    {
            //        throw new ArgumentException("Input must be a decimal value");
            //    }
            //}
            else
            {
                try
                {

                    MySqlConn.Open();

                    String v = txtsaleamt.Text.Trim();
                    txtsaleamt.Text = v.Replace(",", "");

                    String q = txtestcost.Text.Trim();
                    txtestcost.Text = q.Replace(",", "");

                    if (txtestcommpert.Text == " ")
                    {
                        txtestcommpert.Text = " ";
                    }

                    if (txtspcommpert.Text == " ")
                    {
                        txtspcommpert.Text = " ";
                    }

                    if (txtprjmgrcomm.Text == " ")
                    {
                        txtprjmgrcomm.Text = " ";
                    }

                    if (txtprjasstcomm.Text == " ")
                    {
                        txtprjasstcomm.Text = " ";
                    }

                    


                    string commandString6 = ("INSERT into projects SET cid = '" + txtccid.Text.Trim() + "', jid = '" + txtpjid.Text.Trim() + "', project_number = '" + txtpjtnum.Text.Trim() + "', project_name = '" + txtPrjtName.Text.Trim() + "', sale_amount = '" + txtsaleamt.Text.Trim() + "', estimated_cost = '" + txtestcost.Text.Trim() + "', estimator = '" + cbopjsestr.SelectedItem.ToString() + "', estimator_commission_percentage = '" + txtestcommpert.Text.Trim() + "', salesperson = '" + cbopjssp.SelectedItem.ToString() + "', salesperson_commission_percentage = '" + txtspcommpert.Text.Trim() + "', projectmgr = '" + cboprjpm.SelectedItem.ToString() + "', projectmgr_commission_percentage = '" + txtprjmgrcomm.Text.Trim() + "', projectasst = '" + cbopjpa.SelectedItem.ToString() + "', projectasst_commission_percentage = '" + txtprjasstcomm.Text.Trim() + "', description = '" + txtPrjDesc.Text.Trim() + "'");
                    //token14 = txtsaleamt.Text.Trim();
                    //token15 = txtestcost.Text.Trim();
                    token16 = txtPrjDesc.Text.Trim();

                    SqlCommand mysqlcommand6 = new SqlCommand(commandString6, MySqlConn);
                    DataTable table6 = GetDataTable(
                        // Pass open database connection to function
            ref MySqlConn,
                        // Pass SQL statement to create SqlDataReader
            commandString6);




                    //inserts into the billing table               
                    string commandString8 = ("INSERT into billing SET cid = '" + txtccid.Text.Trim() + "', jid = '" + txtpjid.Text.Trim() + "', project_number = '" + txtpjtnum.Text.Trim() + "', project_name = '" + txtPrjtName.Text.Trim() + "', estimator = '" + cbopjsestr.SelectedItem.ToString() + "', estimator_percent = '" + txtestcommpert.Text.Trim() + "', salesperson = '" + cbopjssp.SelectedItem.ToString() + "', salesperson_percent = '" + txtspcommpert.Text.Trim() + "', projectmgr = '" + cboprjpm.SelectedItem.ToString() + "', projectmgr_percent = '" + txtprjmgrcomm.Text.Trim() + "', projectasst = '" + cbopjpa.SelectedItem.ToString() + "', projectasst_percent = '" + txtprjasstcomm.Text.Trim() + "', project_saleamt = '" + txtsaleamt.Text.Trim() + "', project_estcost = '" + txtestcost.Text.Trim() + "', project_description = '" + txtPrjDesc.Text.Trim() + "', paid_stmt = 'N', pid = LAST_INSERT_ID() ");
                    SqlCommand mysqlcommand8 = new SqlCommand(commandString8, MySqlConn);

                    DataTable table8 = GetDataTable(
                        // Pass open database connection to function
            ref MySqlConn,
                        // Pass SQL statement to create SqlDataReader
            commandString8);


            //        //This inserts new assigned project staff row with bid
            //        string commandString7 = ("INSERT into assignedps SET project_number = '" + txtpjtnum.Text.Trim() + "', assigned_estimator = '" + cbopjsestr.SelectedItem.ToString() + "', estimator_percentage = '" + txtestcommpert.Text.Trim() + "', assigned_salesperson = '" + cbopjssp.SelectedItem.ToString() + "', salesperson_percentage = '" + txtspcommpert.Text.Trim() + "', assigned_pm = '" + cboprjpm.SelectedItem.ToString() + "', pm_percentage = '" + txtprjmgrcomm.Text.Trim() + "', assigned_pa = '" + cbopjpa.SelectedItem.ToString() + "', pa_percentage = '" + txtprjasstcomm.Text.Trim() + "', prj_saleamt = '" + txtsaleamt.Text.Trim() + "', prj_estcost = '" + txtestcost.Text.Trim() + "', apbid = LAST_INSERT_ID() ");
            //        MySqlCommand mysqlcommand7 = new MySqlCommand(commandString7, MySqlConn);
            //        DataTable table7 = GetDataTable(
            //            // Pass open database connection to function
            //ref MySqlConn,
            //            // Pass SQL statement to create SqlDataReader
            //commandString7);


                //    string commandString364 = ("SELECT apbid FROM assignedps ORDER BY apbid DESC LIMIT 1");
                //    MySqlCommand mysqlcommand364 = new MySqlCommand(commandString364, MySqlConn);
                //    DataTable table364 = GetDataTable(
                //        // Pass open database connection to function
                //ref MySqlConn,
                //        // Pass SQL statement to create SqlDataReader
                //commandString364);

                    //foreach (DataRow row in table364.Rows)
                    //{

                    //    t = " ";
                    //    t = (row[0].ToString());
                    //    holder = " ";
                    //    holder = t;
                    //}

                    //Darren this inserts data for comm job type
                    string commandString66 = ("INSERT into comm_job_type SET cid = '" + txtccid.Text.Trim() + "', jid = '" + txtpjid.Text.Trim() + "', bid = LAST_INSERT_ID(), project_number = '" + txtpjtnum.Text.Trim() + "', project_name = '" + txtPrjtName.Text.Trim() + "', name_1 = '" + cbopjsestr.Text.Trim() + "', jtype_1 = 'Estimator', name_2 = '" + cbopjssp.Text.Trim() + "', jtype_2 = 'Salesperson', name_3 = '" + cboprjpm.Text.Trim() + "', jtype_3 = 'ProjectManager', name_4 = '" + cbopjpa.Text.Trim() + "', jtype_4 = 'ProjectAssistant'");
                    SqlCommand mysqlcommand66 = new SqlCommand(commandString66, MySqlConn);
                    DataTable table66 = GetDataTable(
                        // Pass open database connection to function
           ref MySqlConn,
                        // Pass SQL statement to create SqlDataReader
           commandString66);


                    //this command updates the grid view on the project sreen
                    string commandString11 = ("SELECT pid, jid, project_number, project_name, sale_amount, estimated_cost, actual_cost, estimator, estimator_commission_percentage, salesperson, salesperson_commission_percentage, projectmgr, projectmgr_commission_percentage, projectasst, projectasst_commission_percentage, description FROM projects WHERE jid = '" + txtpjid.Text.Trim() + "'");
                    SqlCommand mysqlcommand11 = new SqlCommand(commandString11, MySqlConn);
                    DataTable table3 = GetDataTable(
                        // Pass open database connection to function
           ref MySqlConn,
                        // Pass SQL statement to create SqlDataReader
           commandString11);




                    dataGridView1.DataSource = table3;
                    dataGridView1.Refresh();
                    cboprjnumlist.Items.Clear();

                    foreach (DataRow row in table3.Rows)
                    {
                        String item = (row["project_number"].ToString());

                        cboprjnumlist.Items.Add(item);
                        //cbocname.Items.Add(item);
                        //cbojcname.Items.Add(item);
                    }





                    //CLEAR the text boxes after insert and update the data grid view
                    txtpjid.Text = " ";
                    txtpjtnum.Text = " ";
                    txtPrjtName.Text = " ";
                    txtsaleamt.Text = " ";
                    txtestcost.Text = " ";
                    txtestcommpert.Text = " ";
                    txtspcommpert.Text = " ";
                    txtprjmgrcomm.Text = " ";
                    txtprjasstcomm.Text = " ";
                    cbopjsestr.Text = " ";
                    cbopjssp.Text = " ";
                    cboprjpm.Text = " ";
                    cbopjpa.Text = " ";
                    txtPrjDesc.Text = " ";


                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //********************************************This function updates the project specific to the projec id
        //*********************************************and updates the data grid view
        private void updtprjbut_Click(object sender, EventArgs e)
        {
            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            SqlConnection MySqlConn = new SqlConnection(connectionString);


            String r = txtsaleamt.Text.Trim();
            txtsaleamt.Text = r.Replace(",", "");

            String t = txtestcost.Text.Trim();
            txtestcost.Text = t.Replace(",", "");


            //This command updates the project table
            string commandString10 = ("UPDATE projects SET project_name = '" + txtPrjtName.Text.Trim() + "', sale_amount = '" + txtsaleamt.Text.Trim() + "', estimated_cost = '" + txtestcost.Text.Trim() + "', estimator = '" + cbopjsestr.SelectedItem.ToString() + "', estimator_commission_percentage = '" + txtestcommpert.Text.Trim() + "', salesperson = '" + cbopjssp.SelectedItem.ToString() + "', salesperson_commission_percentage = '" + txtspcommpert.Text.Trim() + "', projectmgr = '" + cboprjpm.SelectedItem.ToString() + "', projectmgr_commission_percentage = '" + txtprjmgrcomm.Text.Trim() + "', projectasst = '" +cbopjpa.SelectedItem.ToString() + "', projectasst_commission_percentage = '" + txtprjasstcomm.Text.Trim() + "', description = '" + txtPrjDesc.Text.Trim() + "' WHERE pid = '" + txtprjpid.Text.Trim() + "'");
            DataTable table3 = GetDataTable(
                // Pass open database connection to function
       ref MySqlConn,
                // Pass SQL statement to create SqlDataReader
       commandString10);



            //updates the billing table               
            string commandString8 = ("UPDATE billing SET project_name = '" + txtPrjtName.Text.Trim() + "', estimator = '" + cbopjsestr.SelectedItem.ToString() + "', estimator_percent = '" + txtestcommpert.Text.Trim() + "', salesperson = '" + cbopjssp.SelectedItem.ToString() + "', salesperson_percent = '" + txtspcommpert.Text.Trim() + "', projectmgr = '" + cboprjpm.SelectedItem.ToString() + "', projectmgr_percent = '" + txtprjmgrcomm.Text.Trim() + "', projectasst = '" + cbopjpa.SelectedItem.ToString() + "', projectasst_percent = '" + txtprjasstcomm.Text.Trim() + "', project_saleamt = '" + txtsaleamt.Text.Trim() + "', project_estcost = '" + txtestcost.Text.Trim() + "', project_description = '" + txtPrjDesc.Text.Trim() + "' WHERE pid = '" + txtprjpid.Text.Trim() + "'");
            SqlCommand mysqlcommand8 = new SqlCommand(commandString8, MySqlConn);

            DataTable table8 = GetDataTable(
                // Pass open database connection to function
    ref MySqlConn,
                // Pass SQL statement to create SqlDataReader
    commandString8);


       //     //this command updates the assignedps table
       //     string commmandString12 = ("UPDATE assignedps SET assigned_estimator = '" + cbopjsestr.SelectedItem.ToString() + "', estimator_percentage = '" + txtestcommpert.Text.Trim() + "', assigned_salesperson = '" + cbopjssp.SelectedItem.ToString() + "', salesperson_percentage = '" + txtspcommpert.Text.Trim() + "', assigned_pm = '" + cboprjpm.SelectedItem.ToString() + "', pm_percentage = '" + txtprjmgrcomm.Text.Trim() + "', assigned_pa = '" + cbopjpa.SelectedItem.ToString() + "', pa_percentage = '" + txtprjasstcomm.Text.Trim() + "' WHERE project_number = '" + txtpjtnum.Text.Trim() + "'");
       //     DataTable table5 = GetDataTable(
       //         // Pass open database connection to function
       //ref MySqlConn,
       //         // Pass SQL statement to create SqlDataReader
       //commmandString12);


            //Darren this updates data for comm job type
            string commandString266 = ("UPDATE comm_job_type SET cid = '" + txtccid.Text.Trim() + "', jid = '" + txtpjid.Text.Trim() + "', pid = '" + txtprjpid.Text.Trim() + "', project_name = '" + txtPrjtName.Text.Trim() + "', name_1 = '" + cbopjsestr.Text.Trim() + "', jtype_1 = 'Estimator', name_2 = '" + cbopjssp.Text.Trim() + "', jtype_2 = 'Salesperson', name_3 = '" + cboprjpm.Text.Trim() + "', jtype_3 = 'ProjectManager', name_4 = '" + cbopjpa.Text.Trim() + "', jtype_4 = 'ProjectAssistant' WHERE project_number = '" + txtpjtnum.Text.Trim() + "'");
            SqlCommand mysqlcommand266 = new SqlCommand(commandString266, MySqlConn);
            DataTable table266 = GetDataTable(
                // Pass open database connection to function
   ref MySqlConn,
                // Pass SQL statement to create SqlDataReader
   commandString266);

           




            string commandString7 = ("SELECT pid, jid, project_number, project_name, sale_amount, estimated_cost, estimator, estimator_commission_percentage, salesperson, salesperson_commission_percentage, projectmgr, projectmgr_commission_percentage, projectasst, projectasst_commission_percentage, description FROM projects WHERE jid = '" + txtpjid.Text.Trim() + "'");
            DataTable table4 = GetDataTable(
                // Pass open database connection to function
   ref MySqlConn,
                // Pass SQL statement to create SqlDataReader
   commandString7);



            dataGridView1.DataSource = table4;
            dataGridView1.Refresh();
            cboprjnumlist.Items.Clear();

            foreach (DataRow row in table4.Rows)
            {
                String item = (row["project_number"].ToString());

                cboprjnumlist.Items.Add(item);
                //cbocname.Items.Add(item);
                //cbojcname.Items.Add(item);
            }

            //CLEAR the text boxes after  update the data grid view
            txtpjid.Text = " ";
            txtpjtnum.Text = " ";
            txtPrjtName.Text = " ";
            txtsaleamt.Text = " ";
            txtestcost.Text = " ";            
            txtestcommpert.Text = " ";
            txtspcommpert.Text = " ";
            txtprjmgrcomm.Text = " ";
            txtprjasstcomm.Text = " ";
            cbopjsestr.Text = " ";
            cbopjssp.Text = " ";
            cboprjpm.Text = " ";
            cbopjpa.Text = " ";
            txtPrjDesc.Text = " ";
                //txtpjtnum.Text = " ";
                //txtsaleamt.Text = " ";
                //txtestcost.Text = " ";
                //txtestcommpert.Text = " ";
                //txtspcommpert.Text = " ";
                //txtprjmgrcomm.Text = " ";
                //txtprjasstcomm.Text = " ";
        }

        private void cboprjnumlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            SqlConnection MySqlConn = new SqlConnection(connectionString);

            try
            {

                //string commandString99 = ("SELECT pid, project_number, sale_amount, estimated_cost, estimator_commission_percentage, salesperson_commission_percentage, projectmgr_commission_percentage, projectasst_commission_percentage FROM projects WHERE pid = '" + txtpjtnum.Text + "'");
                string commandString99 = ("SELECT pid, jid, project_number, project_name, sale_amount, estimated_cost, estimator, estimator_commission_percentage, salesperson, salesperson_commission_percentage, projectmgr, projectmgr_commission_percentage, projectasst, projectasst_commission_percentage, description FROM projects WHERE project_number = '" + cboprjnumlist.Text.ToString() + "'");
                DataTable table4 = GetDataTable(
                    // Pass open database connection to function
   ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
   commandString99);

                txtpjid.DataBindings.Clear();
                txtpjid.DataBindings.Add(new Binding("Text", table4, "jid", true));
                txtprjpid.DataBindings.Clear();
                txtprjpid.DataBindings.Add(new Binding("Text", table4, "pid", true));
                txtpjtnum.DataBindings.Clear();
                txtpjtnum.DataBindings.Add(new Binding("Text", table4, "project_number", true));
                txtPrjtName.DataBindings.Clear();
                txtPrjtName.DataBindings.Add(new Binding("Text", table4, "project_name", true));
                txtsaleamt.DataBindings.Clear();
                txtsaleamt.DataBindings.Add(new Binding("text", table4, "sale_amount", true));
                txtestcost.DataBindings.Clear();
                txtestcost.DataBindings.Add(new Binding("Text", table4, "estimated_cost", true));
                cbopjsestr.DataBindings.Clear();
                cbopjsestr.DataBindings.Add(new Binding("Text", table4, "estimator", true));
                txtestcommpert.DataBindings.Clear();
                txtestcommpert.DataBindings.Add(new Binding("Text", table4, "estimator_commission_percentage", true));
                cbopjssp.DataBindings.Clear();
                cbopjssp.DataBindings.Add(new Binding("Text", table4, "salesperson", true));
                txtspcommpert.DataBindings.Clear();
                txtspcommpert.DataBindings.Add(new Binding("Text", table4, "salesperson_commission_percentage", true));
                cboprjpm.DataBindings.Clear();
                cboprjpm.DataBindings.Add(new Binding("Text", table4, "projectmgr", true));
                txtprjmgrcomm.DataBindings.Clear();
                txtprjmgrcomm.DataBindings.Add(new Binding("Text", table4, "projectmgr_commission_percentage", true));
                cbopjpa.DataBindings.Clear();
                cbopjpa.DataBindings.Add(new Binding("Text", table4, "projectasst", true));
                txtprjasstcomm.DataBindings.Clear();
                txtprjasstcomm.DataBindings.Add(new Binding("Text", table4, "projectasst_commission_percentage", true));

                txtpjtnum.Enabled = true;
                txtPrjtName.Enabled = true;
                txtsaleamt.Enabled = true;
                txtestcost.Enabled = true;
                txtestcommpert.Enabled = true;
                txtspcommpert.Enabled = true;
                txtprjmgrcomm.Enabled = true;
                txtprjasstcomm.Enabled = true;
                cbopjsestr.Enabled = true;
                cbopjssp.Enabled = true;
                cboprjpm.Enabled = true;
                cbopjpa.Enabled = true;


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }



        }


        //This is for the billing button.  It will use pid as a token
        private void billingbut_Click(object sender, EventArgs e)
        {
            token3 = txtprjpid.Text.Trim();
            token4 = txtpjtnum.Text.Trim();
            token5 = txtestcommpert.Text.Trim();
            token6 = txtspcommpert.Text.Trim();
            token7 = txtprjmgrcomm.Text.Trim();
            token8 = txtprjasstcomm.Text.Trim();
            token9 = txtpjid.Text.Trim();
            token10 = cbopjsestr.Text.Trim();
            token11 = cbopjssp.Text.Trim();
            token12 = cboprjpm.Text.Trim();
            token13 = cbopjpa.Text.Trim();
            token16 = txtPrjDesc.Text.Trim();
            token30 = txtPrjtName.Text.Trim();
            token23 = txtccid.Text.Trim();
            Form billing = new Billing();            
            billing.Show();
        }

        private void projRepBut_Click(object sender, EventArgs e)
        {
            Form Reporting = new Reporting();
            Reporting.Show();
        }

        

       

        
    }
}
