namespace WindowsFormsApplication1
{
    partial class Projects
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtpjtnum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsaleamt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtestcost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtestcommpert = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtspcommpert = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtprjmgrcomm = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtprjasstcomm = new System.Windows.Forms.TextBox();
            this.insrtprjbut = new System.Windows.Forms.Button();
            this.txtpjid = new System.Windows.Forms.TextBox();
            this.txtprjpid = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.insrtnewprjbut = new System.Windows.Forms.Button();
            this.updtprjbut = new System.Windows.Forms.Button();
            this.cbopjsestr = new System.Windows.Forms.ComboBox();
            this.cbopjssp = new System.Windows.Forms.ComboBox();
            this.cboprjpm = new System.Windows.Forms.ComboBox();
            this.cbopjpa = new System.Windows.Forms.ComboBox();
            this.cboprjnumlist = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.billingbut = new System.Windows.Forms.Button();
            this.txtPrjDesc = new System.Windows.Forms.TextBox();
            this.txtccid = new System.Windows.Forms.TextBox();
            this.txtPrjtName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.projRepBut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project Number";
            // 
            // txtpjtnum
            // 
            this.txtpjtnum.Location = new System.Drawing.Point(160, 9);
            this.txtpjtnum.Name = "txtpjtnum";
            this.txtpjtnum.Size = new System.Drawing.Size(100, 20);
            this.txtpjtnum.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sale Amount";
            // 
            // txtsaleamt
            // 
            this.txtsaleamt.Location = new System.Drawing.Point(160, 72);
            this.txtsaleamt.Name = "txtsaleamt";
            this.txtsaleamt.Size = new System.Drawing.Size(100, 20);
            this.txtsaleamt.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Estimated Cost";
            // 
            // txtestcost
            // 
            this.txtestcost.Location = new System.Drawing.Point(160, 106);
            this.txtestcost.Name = "txtestcost";
            this.txtestcost.Size = new System.Drawing.Size(100, 20);
            this.txtestcost.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Estimator Commission Percentage";
            // 
            // txtestcommpert
            // 
            this.txtestcommpert.Location = new System.Drawing.Point(254, 150);
            this.txtestcommpert.Name = "txtestcommpert";
            this.txtestcommpert.Size = new System.Drawing.Size(100, 20);
            this.txtestcommpert.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Salesperson Commission Percentage";
            // 
            // txtspcommpert
            // 
            this.txtspcommpert.Location = new System.Drawing.Point(254, 183);
            this.txtspcommpert.Name = "txtspcommpert";
            this.txtspcommpert.Size = new System.Drawing.Size(100, 20);
            this.txtspcommpert.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Project Manager Commission Percentage";
            // 
            // txtprjmgrcomm
            // 
            this.txtprjmgrcomm.Location = new System.Drawing.Point(254, 217);
            this.txtprjmgrcomm.Name = "txtprjmgrcomm";
            this.txtprjmgrcomm.Size = new System.Drawing.Size(100, 20);
            this.txtprjmgrcomm.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Project Assistant Commission Percentage";
            // 
            // txtprjasstcomm
            // 
            this.txtprjasstcomm.Location = new System.Drawing.Point(255, 253);
            this.txtprjasstcomm.Name = "txtprjasstcomm";
            this.txtprjasstcomm.Size = new System.Drawing.Size(100, 20);
            this.txtprjasstcomm.TabIndex = 8;
            // 
            // insrtprjbut
            // 
            this.insrtprjbut.Location = new System.Drawing.Point(625, 33);
            this.insrtprjbut.Name = "insrtprjbut";
            this.insrtprjbut.Size = new System.Drawing.Size(162, 23);
            this.insrtprjbut.TabIndex = 14;
            this.insrtprjbut.Text = "SAVE";
            this.insrtprjbut.UseVisualStyleBackColor = true;
            this.insrtprjbut.Click += new System.EventHandler(this.insrtprjbut_Click);
            // 
            // txtpjid
            // 
            this.txtpjid.Location = new System.Drawing.Point(878, 572);
            this.txtpjid.Name = "txtpjid";
            this.txtpjid.Size = new System.Drawing.Size(74, 20);
            this.txtpjid.TabIndex = 15;
            // 
            // txtprjpid
            // 
            this.txtprjpid.Location = new System.Drawing.Point(878, 536);
            this.txtprjpid.Name = "txtprjpid";
            this.txtprjpid.Size = new System.Drawing.Size(74, 20);
            this.txtprjpid.TabIndex = 24;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(12, 468);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(860, 150);
            this.dataGridView1.TabIndex = 25;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // insrtnewprjbut
            // 
            this.insrtnewprjbut.Location = new System.Drawing.Point(625, 7);
            this.insrtnewprjbut.Name = "insrtnewprjbut";
            this.insrtnewprjbut.Size = new System.Drawing.Size(162, 23);
            this.insrtnewprjbut.TabIndex = 26;
            this.insrtnewprjbut.Text = "CLEAR PROJECT FIELDS";
            this.insrtnewprjbut.UseVisualStyleBackColor = true;
            this.insrtnewprjbut.Click += new System.EventHandler(this.insrtnewprjbut_Click);
            // 
            // updtprjbut
            // 
            this.updtprjbut.Location = new System.Drawing.Point(625, 62);
            this.updtprjbut.Name = "updtprjbut";
            this.updtprjbut.Size = new System.Drawing.Size(162, 23);
            this.updtprjbut.TabIndex = 27;
            this.updtprjbut.Text = "UPDATE";
            this.updtprjbut.UseVisualStyleBackColor = true;
            this.updtprjbut.Click += new System.EventHandler(this.updtprjbut_Click);
            // 
            // cbopjsestr
            // 
            this.cbopjsestr.FormattingEnabled = true;
            this.cbopjsestr.Location = new System.Drawing.Point(187, 318);
            this.cbopjsestr.Name = "cbopjsestr";
            this.cbopjsestr.Size = new System.Drawing.Size(224, 21);
            this.cbopjsestr.TabIndex = 9;
            // 
            // cbopjssp
            // 
            this.cbopjssp.FormattingEnabled = true;
            this.cbopjssp.Location = new System.Drawing.Point(187, 351);
            this.cbopjssp.Name = "cbopjssp";
            this.cbopjssp.Size = new System.Drawing.Size(224, 21);
            this.cbopjssp.TabIndex = 10;
            // 
            // cboprjpm
            // 
            this.cboprjpm.FormattingEnabled = true;
            this.cboprjpm.Location = new System.Drawing.Point(187, 383);
            this.cboprjpm.Name = "cboprjpm";
            this.cboprjpm.Size = new System.Drawing.Size(224, 21);
            this.cboprjpm.TabIndex = 11;
            // 
            // cbopjpa
            // 
            this.cbopjpa.FormattingEnabled = true;
            this.cbopjpa.Location = new System.Drawing.Point(187, 415);
            this.cbopjpa.Name = "cbopjpa";
            this.cbopjpa.Size = new System.Drawing.Size(224, 21);
            this.cbopjpa.TabIndex = 12;
            // 
            // cboprjnumlist
            // 
            this.cboprjnumlist.FormattingEnabled = true;
            this.cboprjnumlist.Location = new System.Drawing.Point(531, 167);
            this.cboprjnumlist.Name = "cboprjnumlist";
            this.cboprjnumlist.Size = new System.Drawing.Size(121, 21);
            this.cboprjnumlist.TabIndex = 32;
            this.cboprjnumlist.SelectedIndexChanged += new System.EventHandler(this.cboprjnumlist_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(676, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "SELECT PROJECT NUMBER";
            // 
            // billingbut
            // 
            this.billingbut.Location = new System.Drawing.Point(625, 91);
            this.billingbut.Name = "billingbut";
            this.billingbut.Size = new System.Drawing.Size(162, 23);
            this.billingbut.TabIndex = 34;
            this.billingbut.Text = "BILLING";
            this.billingbut.UseVisualStyleBackColor = true;
            this.billingbut.Click += new System.EventHandler(this.billingbut_Click);
            // 
            // txtPrjDesc
            // 
            this.txtPrjDesc.Location = new System.Drawing.Point(450, 336);
            this.txtPrjDesc.Multiline = true;
            this.txtPrjDesc.Name = "txtPrjDesc";
            this.txtPrjDesc.Size = new System.Drawing.Size(407, 113);
            this.txtPrjDesc.TabIndex = 35;
            // 
            // txtccid
            // 
            this.txtccid.Location = new System.Drawing.Point(878, 598);
            this.txtccid.Name = "txtccid";
            this.txtccid.Size = new System.Drawing.Size(74, 20);
            this.txtccid.TabIndex = 38;
            // 
            // txtPrjtName
            // 
            this.txtPrjtName.Location = new System.Drawing.Point(160, 35);
            this.txtPrjtName.Name = "txtPrjtName";
            this.txtPrjtName.Size = new System.Drawing.Size(207, 20);
            this.txtPrjtName.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(34, 38);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "Project Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "Project Staff";
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 318);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Estimator";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(55, 355);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Salesperson";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(56, 388);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "Project Manager";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(58, 419);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 13);
            this.label13.TabIndex = 45;
            this.label13.Text = "Project Assistant";
            // 
            // projRepBut
            // 
            this.projRepBut.Location = new System.Drawing.Point(625, 120);
            this.projRepBut.Name = "projRepBut";
            this.projRepBut.Size = new System.Drawing.Size(162, 23);
            this.projRepBut.TabIndex = 46;
            this.projRepBut.Text = "REPORTS";
            this.projRepBut.UseVisualStyleBackColor = true;
            this.projRepBut.Click += new System.EventHandler(this.projRepBut_Click);
            // 
            // Projects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 630);
            this.Controls.Add(this.projRepBut);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtPrjtName);
            this.Controls.Add(this.txtccid);
            this.Controls.Add(this.txtPrjDesc);
            this.Controls.Add(this.billingbut);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cboprjnumlist);
            this.Controls.Add(this.cbopjpa);
            this.Controls.Add(this.cboprjpm);
            this.Controls.Add(this.cbopjssp);
            this.Controls.Add(this.cbopjsestr);
            this.Controls.Add(this.updtprjbut);
            this.Controls.Add(this.insrtnewprjbut);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtprjpid);
            this.Controls.Add(this.txtpjid);
            this.Controls.Add(this.insrtprjbut);
            this.Controls.Add(this.txtprjasstcomm);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtprjmgrcomm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtspcommpert);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtestcommpert);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtestcost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtsaleamt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtpjtnum);
            this.Controls.Add(this.label1);
            this.Name = "Projects";
            this.Text = "Projects";
            this.Load += new System.EventHandler(this.Projects_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpjtnum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsaleamt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtestcost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtestcommpert;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtspcommpert;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtprjmgrcomm;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtprjasstcomm;
        private System.Windows.Forms.Button insrtprjbut;
        private System.Windows.Forms.TextBox txtpjid;
        private System.Windows.Forms.TextBox txtprjpid;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button insrtnewprjbut;
        private System.Windows.Forms.Button updtprjbut;
        private System.Windows.Forms.ComboBox cbopjsestr;
        private System.Windows.Forms.ComboBox cbopjssp;
        private System.Windows.Forms.ComboBox cboprjpm;
        private System.Windows.Forms.ComboBox cbopjpa;
        private System.Windows.Forms.ComboBox cboprjnumlist;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button billingbut;
        private System.Windows.Forms.TextBox txtPrjDesc;
        private System.Windows.Forms.TextBox txtccid;
        private System.Windows.Forms.TextBox txtPrjtName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button projRepBut;

    }
}