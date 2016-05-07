using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApplication1.companyDSTableAdapters;
using System.Data.SqlClient;
using WindowsFormsApplication1.commissionDataSet1TableAdapters;
using System.Diagnostics;
using System.Configuration;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public static string token;
        public static string token2;
        public static string token22;
              
        public Form1()
        {
            InitializeComponent();
        }

        BindingSource bs = new BindingSource();
        public DataTable GetDataTable(
        ref System.Data.SqlClient.SqlConnection _nSqlConnection, string _nSQL)       
        {
            // New SQL connection to a command object
            SqlCommand _nSqlCommand = new SqlCommand(_nSQL, _nSqlConnection);
            SqlDataAdapter _nSqlAdapter = new SqlDataAdapter();
            _nSqlAdapter.SelectCommand = _nSqlCommand;
            DataTable _nDataTable = new DataTable();
            _nDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;

            // Adds or refreshes rows in the DataSet to match those in the data source
            try
            {
                _nSqlAdapter.Fill(_nDataTable);
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


        //****************************************************************************Inserts a new company into the company table
        //This function is good for second round modification
        private void submitButton_Click(object sender, EventArgs e)
        {



            if (txtcname.Text == string.Empty)
            {
                errorProvider1.SetError(txtcname, "Please Enter a Company Name");
            }
            if (txtAddr.Text == string.Empty)
            {
                errorProvider1.SetError(txtAddr, "Please Enter a Company Name");
            }
            if (stateComboBox.Text == string.Empty)
            {
                errorProvider1.SetError(stateComboBox, "Please Enter a State");
            }
            if (mskedtxtphone.Text == string.Empty)
            {
                errorProvider1.SetError(mskedtxtphone, "Pleae Enter a Phone Number");
            }
            if (txtcompzip.Text == string.Empty)
            {
                errorProvider1.SetError(txtcompzip, "Pleae Enter a Zip Code");
            }
            if (txtcontact.Text == string.Empty)
            {
                DialogResult dr = MessageBox.Show("Contact is blank, do you wish to continue?", "Important Question", MessageBoxButtons.YesNo);
            }
            
            else
            {

                //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
                string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
                SqlConnection sqlConn = new SqlConnection(connectionString);
                //MySqlConnection MySqlConn = new MySqlConnection(connectionString); DM Remove this

                try
                {
                    sqlConn.Open();
                    //MySqlConn.Open();
                    //company insert query
                    string commandString7 = ("INSERT into company SET company_name = '" + txtcname.Text.Trim() + "', address = '" + txtAddr.Text.Trim() + "', state = '" + stateComboBox.Text.Trim() + "', phone_number = '" + mskedtxtphone.Text.Trim() + "', contact_person = '" + txtcontact.Text.Trim() + "', city = '" + txtcompcity.Text.Trim() + "', zip = '" + txtcompzip.Text.Trim() + "'");
                    SqlCommand sqlcommand = new SqlCommand(commandString7, sqlConn);
                    //MySqlCommand mysqlcommand = new MySqlCommand(commandString7, MySqlConn);

                    //companyTableAdapter getcomp = new companyDSTableAdapters.companyTableAdapter();

                    //DataTable table =  new companyDS.companyDataTable();
                    DataTable table = GetDataTable(
                        // Pass open database connection to function
            ref MySqlConn,
                        // Pass SQL statement to create SqlDataReader
            commandString7);


                    String item = txtcname.Text.Trim();
                    cbocname.Items.Add(item);
                    cbojcname.Items.Add(item);


                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }


                txtcname.Text = " ";
                txtAddr.Text = " ";
                txtcompcity.Text = " ";
                txtcompzip.Text = " ";
                stateComboBox.Text = " ";
                mskedtxtphone.Text = " ";
                txtcontact.Text = " ";

            }

        }


        
        //********************************************************************************Function to update company info in the company table
        //this function is good for second round modifications
        private void updateButton_Click(object sender, EventArgs e)
        {
            

            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(connectionString);
            

            
            try
            {
                MySqlConn.Open();
                string commandString = ("UPDATE company SET company_name = '" + txtcname.Text.Trim() + "', " + "address = '" + txtAddr.Text.Trim() + "', state = '" + stateComboBox.SelectedItem.ToString()  + "', phone_number = '" + mskedtxtphone.Text.Trim() + "', contact_person = '" + txtcontact.Text.Trim() + "', city = '" + txtcompcity.Text.Trim() + "', zip = '" + txtcompzip.Text.Trim() + "' WHERE company_name = '" + txtcname.Text.Trim() + "'");
                textBox1.Text = commandString;
                MySqlCommand mysqlcommand = new MySqlCommand(commandString, MySqlConn);

                companyTableAdapter getcomp = new companyDSTableAdapters.companyTableAdapter();

                //DataTable table =  new companyDS.companyDataTable();
                DataTable table = GetDataTable(
                    // Pass open database connection to function
        ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
        commandString);

                txtcname.Text = " ";
                txtAddr.Text = " ";
                txtcompcity.Text = " ";
                txtcompzip.Text = " "; 
                stateComboBox.Text = " ";
                mskedtxtphone.Text = " ";
                txtcontact.Text = " ";

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }
        
        
        //*********************************************************************************//First time in stops here
        private void Form1_Load_1(object sender, EventArgs e)
        {
            
            
            cbocname.Items.Clear();
            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(connectionString);

            MySqlConn.Open();

            string commandString31 = ("SELECT ALL company_name FROM company ORDER BY company_name ASC");
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
                String item = (row["company_name"].ToString());
                cbocname.Items.Add(item);
                cbojcname.Items.Add(item);
            }



            string commandString66 = ("SELECT psname FROM projectstaff");//, salesperson = '" + txtpjssp.Text.Trim() + "', projectmgr = '" + txtpjspm.Text.Trim() + "', projectasst = '" + txtpjspa.Text.Trim() + "'");
            MySqlCommand mysqlcommand66 = new MySqlCommand(commandString66, MySqlConn);
            DataTable table66 = GetDataTable(
                // Pass open database connection to function
    ref MySqlConn,
                // Pass SQL statement to create SqlDataReader
    commandString66);

            dataGridView2.DataSource = table66;
            dataGridView2.Refresh();


        }



        //********************************************this function populates the fields on the job screen based on row click in the data grid
        //********************************************this function also poulates the project grid
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;            
            txtjid.Text = (String)dataGridView1["jid", e.RowIndex].Value.ToString();
            txtjobname.Text = (String)dataGridView1["job_name", e.RowIndex].Value.ToString();
            txtjobaddr.Text = (String)dataGridView1["job_address", e.RowIndex].Value.ToString();
            txtjobcity.Text = (String)dataGridView1["job_city", e.RowIndex].Value.ToString();
            cbojobstate.Text = (String)dataGridView1["job_state", e.RowIndex].Value.ToString();
            txtjobzip.Text = (String)dataGridView1["job_zip", e.RowIndex].Value.ToString();
            //This is passing the jid to the project screen
            token = txtjid.Text.Trim();
            token22 = txtjcid.Text.Trim();


            Form Projects = new Projects();
            //Darren check to see if this is really needed
            //token = txtjid.Text;
            Projects.Show();
            //insprojbut.Enabled = true;


            //This populates the project grid view
            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(connectionString);

            MySqlConn.Open();

            
        }


        //**************************************************************************************THis function updates job info 
        //**************************************************************************************This function is good for second round modifications
        private void jobupdatebutton_Click(object sender, EventArgs e)
        {
            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(connectionString);

            
            try
            {

              

                MySqlConn.Open();


                //this updates the job table
                string commandString5 = ("UPDATE job SET job_name = '" + txtjobname.Text.Trim() + "', job_address = '" + txtjobaddr.Text.Trim() + "', job_city = '" + txtjobcity.Text.Trim() + "', job_state = '" + cbojobstate.Text.ToString() + "', job_zip = '" + txtjobzip.Text.Trim() + "' WHERE jid = '" + txtjid.Text.Trim() + "'");
                MySqlCommand mysqlcommand = new MySqlCommand(commandString5, MySqlConn);
                DataTable table = GetDataTable(
                    // Pass open database connection to function
        ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
        commandString5);


                //this updates the data grid view after update
                string commandString28 = ("SELECT jid, job_name, job_address, job_city, job_state, job_zip FROM job WHERE cid = '" + txtjcid.Text + "'"); 
                //string commandString15 = ("SELECT * FROM job WHERE job.company_name = '" + txtsrch.Text + "'");
                DataTable table28 = GetDataTable(
                    // Pass open database connection to function
       ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
       commandString28);

                dataGridView1.DataSource = table28;
                dataGridView1.Refresh();

                //Clears the text fields after update
                txtjid.Text = " ";
                txtjobname.Text = " ";
                txtjobaddr.Text = " ";
                txtjobcity.Text = " ";
                cbojobstate.Text = " ";
                txtjobzip.Text = " ";
       

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //*************************************************************THis function Inserts new job
        //*************************************************************THis function is good for second round modifications
        private void jobins_Click(object sender, EventArgs e)
        {
            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(connectionString);



            if (txtjobname.Text == string.Empty)
            {
                errorProvider1.SetError(txtjobname, "Please Enter a Job Name");
            }
            if (txtjobaddr.Text == string.Empty)
            {
                errorProvider1.SetError(txtjobaddr, "Please Enter a Job Address");
            }
            if (txtjobcity.Text == string.Empty)
            {
                errorProvider1.SetError(txtjobcity, "Please Enter a city for the job");
            }
            if (cbojobstate.Text == string.Empty)
            {
                errorProvider1.SetError(cbojobstate, "Please Enter a state for the job");
            }
            if (txtjobzip.Text == string.Empty)
            {
                errorProvider1.SetError(txtjobzip, "Please Enter a zip for the job");
            }
            else
            {

                try
                {

                    MySqlConn.Open();

                    String r = txtjobname.Text;
                    String u = r.Replace("'", "");
                    txtjobname.Text = u;

                       

                    //string commandString6 = ("INSERT into job SET cid = '" + txtjcid.Text + "', company_name = '" + txtjcname.Text.Trim() + "', sale_price = '" + txtsp.Text + "', " + "esitmated_percentage = '" + txtesp.Text + "', actual_cost = '" + txtac.Text + "', gross_profit = '" + txtgp.Text + "', estimator_percentage = '" + txtestpercent.Text + "', sales_percentage = '" + txtsalespercent.Text + "', pm_percentage = '" + txtpmpercent.Text + "', current_billing = '" + txtcb.Text + "', prog_billing_one = '" + txtpb1.Text + "', prog_billing_one_total = '" + txtpb1total.Text + "', prog_billing_two = '" + txtpb2.Text + "', prog_billing_two_total = '" + txtpb2total.Text + "', prog_billing_three = '" + txtpb3.Text + "', prog_billing_four = '" + txtpb4.Text + "', prog_billing_four_total = '" + txtpb4total.Text + "', final_billing = '" + txtfb.Text + "', final_billing_total = '" + txtfbtotal.Text + "', jtype = '" + txtjtype.Text + "'");

                    string commandString6 = ("INSERT into job SET cid = '" + txtjcid.Text + "', job_name = '" + txtjobname.Text.Trim() + "', job_address = '" + txtjobaddr.Text.Trim() + "', job_city = '" + txtjobcity.Text.Trim() + "', job_state = '" + cbojobstate.Text.Trim() + "', job_zip = '" + txtjobzip.Text.Trim() + "'");


                    MySqlCommand mysqlcommand = new MySqlCommand(commandString6, MySqlConn);

                    companyTableAdapter getcomp = new companyDSTableAdapters.companyTableAdapter();

                    //DataTable table =  new companyDS.companyDataTable();
                    DataTable table = GetDataTable(
                        // Pass open database connection to function
            ref MySqlConn,
                        // Pass SQL statement to create SqlDataReader
            commandString6);


                    //CLEAR the text boxes after insert and update the data grid view
                    txtjid.Text = " ";
                    txtjobname.Text = " ";
                    txtjobaddr.Text = " ";
                    txtjobcity.Text = " ";
                    cbojobstate.Text = " ";
                    txtjobzip.Text = " ";



                    //THis updates the data grid view with the newly inserted record
                    string commandString15 = ("SELECT jid, job_name, job_address, job_city, job_state, job_zip from job WHERE job.cid = '" + txtjcid.Text + "'");
                    MySqlCommand mysqlcommand15 = new MySqlCommand(commandString15, MySqlConn);

                    DataTable table7 = GetDataTable(ref MySqlConn, commandString15);
                    dataGridView1.DataSource = table7;
                    dataGridView1.Refresh();
                    cbojoblist.Items.Clear();

                    foreach (DataRow row in table7.Rows)
                    {
                        String item = (row["job_name"].ToString());

                        cbojoblist.Items.Add(item);
                        //cbocname.Items.Add(item);
                        //cbojcname.Items.Add(item);
                    }


                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }




        //This function clears the text fields on the job screen
        private void jfieldclear_Click(object sender, EventArgs e)
        {
            //clears the fields for new entry
            //txtsrch.Text = " ";
            txtjcname.Text = " ";
            txtjaddr.Text = " ";
            txtcompcityj.Text = " ";
            mskdjphone.Text = " ";
            txtjcid.Text = " ";
            txtjstate.Text = " ";
            txtcoompzipj.Text = " ";
            txtjcontact.Text = " ";
            cbojoblist.Text = " ";
            txtjobaddr.Text = " ";
            txtjobname.Text = " ";
            txtjobcity.Text = " ";
            cbojobstate.Text = " ";
            txtjobzip.Text = " ";
            //txtjobsrch.Text = " ";
            txtjid.Text = " ";
            //darren make sure the insert project button is last in the sequence
           
            // darren check this order
            cbojcname.Text = " ";
           
        }


        //**************************************************This function SELECTS job given the jid
        private void txtjobsrch_Click(object sender, EventArgs e)
        {
            //string connectionString = "Data Source=localhost" + "; Database=commission" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(connectionString);

            try
            {

               

                MySqlConn.Open();
                //string commandString25 = ("SELECT company_name, address, state, phone_number, contact_person FROM company WHERE company_name LIKE '%" + txtcid.Text + "%'");
        //        string commandString26 = ("SELECT cid FROM job WHERE jid = '" + txtjobsrch.Text + "'");  //("SELECT company_name, address, state, phone_number, contact_person FROM company WHERE company_name = jc");  
        //        MySqlCommand mysqlcommand26 = new MySqlCommand(commandString26, MySqlConn);

        //        companyTableAdapter getcomp26 = new companyDSTableAdapters.companyTableAdapter();

        //        //DataTable table =  new companyDS.companyDataTable();
        //        DataTable table26 = GetDataTable(
        //            // Pass open database connection to function
        //ref MySqlConn,
        //            // Pass SQL statement to create SqlDataReader
        //commandString26);



                //txtjcname.DataBindings.Clear();
                //txtjcname.DataBindings.Add(new Binding("Text", table26, "company_name", true));
                //txtjcid.DataBindings.Clear();
                //txtjcid.DataBindings.Add(new Binding("Text", table26, "cid", true));
                //txtAddr.DataBindings.Clear();
                //txtAddr.DataBindings.Add(new Binding("Text", table26, "address", true));
                //stateComboBox.DataBindings.Clear();
                //stateComboBox.DataBindings.Add(new Binding("Text", table26, "state", true));
                //mskedtxtphone.DataBindings.Clear();
                //mskedtxtphone.DataBindings.Add(new Binding("Text", table26, "phone_number", true));
                //txtcontact.DataBindings.Clear();
                //txtcontact.DataBindings.Add(new Binding("Text", table26, "contact_person", true));
                //////////////////////////////////////////////////////////////////////////////////////////////////

                ///////////////grab company info with cid
                string commandString27 = ("SELECT company_name, address, state, phone_number, contact_person FROM company WHERE cid = '" + txtjcid.Text + "'");  
                MySqlCommand mysqlcommand27 = new MySqlCommand(commandString27, MySqlConn);

                companyTableAdapter getcomp27 = new companyDSTableAdapters.companyTableAdapter();

                //DataTable table =  new companyDS.companyDataTable();
                DataTable table27 = GetDataTable(
                    // Pass open database connection to function
        ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
        commandString27);

                txtjcname.DataBindings.Clear();
                txtjcname.DataBindings.Add(new Binding("Text", table27, "company_name", true));
                txtjaddr.DataBindings.Clear();
                txtjaddr.DataBindings.Add(new Binding("Text", table27, "address", true));
                txtjstate.DataBindings.Clear();
                txtjstate.DataBindings.Add(new Binding("Text", table27, "state", true));
                mskdjphone.DataBindings.Clear();
                mskdjphone.DataBindings.Add(new Binding("Text", table27, "phone_number", true));
                txtjcontact.DataBindings.Clear();
                txtjcontact.DataBindings.Add(new Binding("Text", table27, "contact_person", true));



            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //Report button
        private void testRepBut_Click(object sender, EventArgs e)
        {

            Form Reporting = new Reporting();
            Reporting.Show();
            
        }


      




        //*******************************************************************This function is for the combo box on the compnay screen
        //*******************************************************************IT is ok for second round modifications
        private void cbocname_SelectedIndexChanged(object sender, EventArgs e)
        {

            

            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(connectionString);



            try
            {

                //This section populates the text fields
                MySqlConn.Open();
                string commandString = ("SELECT company_name, address, state, phone_number, contact_person, city, zip FROM company WHERE company_name = '" + cbocname.SelectedItem.ToString() + "'");
                MySqlCommand mysqlcommand = new MySqlCommand(commandString, MySqlConn);
                
                DataTable table = GetDataTable(
                    // Pass open database connection to function
        ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
        commandString);



                txtcname.DataBindings.Clear();
                txtcname.DataBindings.Add(new Binding("Text", table, "company_name", true));
                txtAddr.DataBindings.Clear();
                txtAddr.DataBindings.Add(new Binding("Text", table, "address", true));
                stateComboBox.DataBindings.Clear();
                stateComboBox.DataBindings.Add(new Binding("Text", table, "state", true));
                mskedtxtphone.DataBindings.Clear();
                mskedtxtphone.DataBindings.Add(new Binding("Text", table, "phone_number", true));
                txtcontact.DataBindings.Clear();
                txtcontact.DataBindings.Add(new Binding("Text", table, "contact_person", true));
                txtcompcity.DataBindings.Clear();
                txtcompcity.DataBindings.Add(new Binding("Text", table, "city", true));
                txtcompzip.DataBindings.Clear();
                txtcompzip.DataBindings.Add(new Binding("Text", table, "zip", true));



            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        


        //*****************************************************************THis is for the combobox on the job screen 
        //*****************************************************************It is ok for second round modifications
        private void cbojcname_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(connectionString);



            try
            {
                
                //This section populates the text fields
                string commandString = ("SELECT cid, company_name, address, state, phone_number, contact_person, city, zip FROM company WHERE company_name = '" + cbojcname.SelectedItem.ToString() + "'");
                MySqlCommand mysqlcommand = new MySqlCommand(commandString, MySqlConn);

                //companyTableAdapter getcomp = new companyDSTableAdapters.companyTableAdapter();

                //DataTable table =  new companyDS.companyDataTable();
                DataTable table = GetDataTable(
                    // Pass open database connection to function
        ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
        commandString);



                txtjcname.DataBindings.Clear();
                txtjcname.DataBindings.Add(new Binding("Text", table, "company_name", true));
                txtjcid.DataBindings.Clear();
                txtjcid.DataBindings.Add(new Binding("Text", table, "cid", true));
                txtjaddr.DataBindings.Clear();
                txtjaddr.DataBindings.Add(new Binding("Text", table, "address", true));
                txtjstate.DataBindings.Clear();
                txtjstate.DataBindings.Add(new Binding("Text", table, "state", true));
                mskdjphone.DataBindings.Clear();
                mskdjphone.DataBindings.Add(new Binding("Text", table, "phone_number", true));
                txtjcontact.DataBindings.Clear();
                txtjcontact.DataBindings.Add(new Binding("Text", table, "contact_person", true));
                txtcompcityj.DataBindings.Clear();
                txtcompcityj.DataBindings.Add(new Binding("Text", table, "city", true));
                txtcoompzipj.DataBindings.Clear();
                txtcoompzipj.DataBindings.Add(new Binding("Text", table, "zip", true));


                //string commandString3 = ("SELECT job_name, cid, company_name, sale_price, esitmated_percentage, actual_cost, gross_profit, estimator_percentage, sales_percentage, pm_percentage, current_billing, prog_billing_one, prog_billing_one_total, prog_billing_two, prog_billing_two_total, prog_billing_three, prog_billing_three_total, prog_billing_four, prog_billing_four_total, final_billing, final_billing_total, jtype from job WHERE cid ='" + txtjcid.Text + "'");

                string commandString3 = ("SELECT jid, job_name, job_address, job_city, job_state, job_zip FROM job WHERE cid = '" + txtjcid.Text + "'");
                DataTable table2 = GetDataTable(
                    // Pass open database connection to function
       ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
       commandString3);



                dataGridView1.DataSource = table2;
                dataGridView1.Refresh();
                cbojoblist.Items.Clear();

                foreach (DataRow row in table2.Rows)
                {
                    String item = (row["job_name"].ToString());
                    
                    cbojoblist.Items.Add(item);
                    //cbocname.Items.Add(item);
                    //cbojcname.Items.Add(item);
                }

                txtjid.Text = " ";
                txtjobname.Text = " ";
                txtjobaddr.Text = " ";
                txtjobcity.Text = " ";
                cbojobstate.Text = " ";
                txtjobzip.Text = " ";
                cbojoblist.Text = " ";
                

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        //********************************This is for the combobox on the job screen to load all the jobs for a specific company
        //********************************This is good for second round mods
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(connectionString);


            try
            {



                string commandString55 = ("SELECT cid, jid, job_name, job_address, job_city, job_state, job_zip FROM job WHERE job_name = '" + cbojoblist.Text.Trim() + "'");

                DataTable table2 = GetDataTable(
                    // Pass open database connection to function
       ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
       commandString55);

                txtjcid.DataBindings.Clear();
                txtjcid.DataBindings.Add(new Binding("Text", table2, "cid", true));
                txtjid.DataBindings.Clear();
                txtjid.DataBindings.Add(new Binding("Text", table2, "jid", true));
                txtjobname.DataBindings.Clear();
                txtjobname.DataBindings.Add(new Binding("Text", table2, "job_name", true));
                txtjobaddr.DataBindings.Clear();
                txtjobaddr.DataBindings.Add(new Binding("Text", table2, "job_address", true));
                txtjobcity.DataBindings.Clear();
                txtjobcity.DataBindings.Add(new Binding("Text", table2, "job_city", true));
                cbojobstate.DataBindings.Clear();
                cbojobstate.DataBindings.Add(new Binding("Text", table2, "job_state", true));
                txtjobzip.DataBindings.Clear();
                txtjobzip.DataBindings.Add(new Binding("Text", table2, "job_zip", true));
                //.DataBindings.Add(new Binding("Text", table2, "job_zip", true));
                token = txtjid.Text.Trim();
                //This is passing the jid to the project screen
                //token = " ";
                //token22 = " ";
                token = txtjid.Text.Trim();
                token22 = txtjcid.Text.Trim();

                Form Projects = new Projects();
                //Darren check to see if this is really needed
                //token = txtjid.Text;
                Projects.Show();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            //token2 = cbojoblist.SelectedItem.ToString();
            
        }




        //This function enters the estimator name to the projectstaff table
        private void pjsinsrtbut_Click(object sender, EventArgs e)
        {

            //string connectionString = "Data Source=localhost" + "; Database=commissionrepo" + "; User ID=root" + "; Password=141210;";
            string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
            MySqlConnection MySqlConn = new MySqlConnection(connectionString);

            try
            {



                string commandString44 = ("INSERT into projectstaff SET psname = '" + txtpjsest.Text.Trim() + "'");//, salesperson = '" + txtpjssp.Text.Trim() + "', projectmgr = '" + txtpjspm.Text.Trim() + "', projectasst = '" + txtpjspa.Text.Trim() + "'");
                DataTable table = GetDataTable(
                    // Pass open database connection to function
        ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
        commandString44);


                txtpjsest.Text = " ";

                string commandString66 = ("SELECT psname FROM projectstaff");//, salesperson = '" + txtpjssp.Text.Trim() + "', projectmgr = '" + txtpjspm.Text.Trim() + "', projectasst = '" + txtpjspa.Text.Trim() + "'");
                MySqlCommand mysqlcommand66 = new MySqlCommand(commandString66, MySqlConn);
                DataTable table66 = GetDataTable(
                    // Pass open database connection to function
        ref MySqlConn,
                    // Pass SQL statement to create SqlDataReader
        commandString66);

                dataGridView2.DataSource = table66;
                dataGridView2.Refresh();


            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        //private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //    string connectionString = ConfigurationManager.ConnectionStrings["CommDB"].ConnectionString;
        //    MySqlConnection MySqlConn = new MySqlConnection(connectionString);


        //    try
        //    {

        //        string commandString66 = ("SELECT * FROM projectstaff");//, salesperson = '" + txtpjssp.Text.Trim() + "', projectmgr = '" + txtpjspm.Text.Trim() + "', projectasst = '" + txtpjspa.Text.Trim() + "'");
        //        MySqlCommand mysqlcommand66 = new MySqlCommand(commandString66, MySqlConn);
        //        DataTable table66 = GetDataTable(
        //            // Pass open database connection to function
        //ref MySqlConn,
        //            // Pass SQL statement to create SqlDataReader
        //commandString66);

        //        dataGridView2.DataSource = table66;
        //        dataGridView2.Refresh();

        //    }
        //    catch (MySqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}

       
       
        //this is thos show the projects popup
        //This isn't needed anymore
        private void insprojbut_Click(object sender, EventArgs e)
        {
            
            Form Projects = new Projects();
            token = txtjid.Text;
            Projects.Show();

        }


        private void compClearBut_Click(object sender, EventArgs e)
        {
            txtcname.Text = " ";
            txtAddr.Text = " ";
            txtcompcity.Text = " ";
            stateComboBox.Text = " ";
            txtcompzip.Text = " ";
            mskedtxtphone.Text = " ";
            txtcontact.Text = " ";
            cbocname.Text = " ";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Reporting = new Reporting();
            Reporting.Show();
        }
        


        
    }
}
