namespace GymManager3.WinUI.Uplata
{
    partial class frmUplataDodaj
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
            this.txtIznos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSvrha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDatum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSnimi = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.polaznikBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gymManager1DataSet1 = new GymManager3.WinUI.GymManager1DataSet1();
            this.gymManager1DataSet = new GymManager3.WinUI.GymManager1DataSet();
            this.polaznikBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.polaznikTableAdapter = new GymManager3.WinUI.GymManager1DataSetTableAdapters.PolaznikTableAdapter();
            this.polaznikTableAdapter1 = new GymManager3.WinUI.GymManager1DataSet1TableAdapters.PolaznikTableAdapter();
            this.cboPolaznici = new System.Windows.Forms.ComboBox();
            this.cboAdmin = new System.Windows.Forms.ComboBox();
            this.cboSub = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.polaznikBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymManager1DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymManager1DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.polaznikBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIznos
            // 
            this.txtIznos.Location = new System.Drawing.Point(46, 77);
            this.txtIznos.Name = "txtIznos";
            this.txtIznos.Size = new System.Drawing.Size(225, 20);
            this.txtIznos.TabIndex = 0;
            this.txtIznos.Validating += new System.ComponentModel.CancelEventHandler(this.txtIznos_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Iznos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Svrha";
            // 
            // txtSvrha
            // 
            this.txtSvrha.Location = new System.Drawing.Point(46, 166);
            this.txtSvrha.Name = "txtSvrha";
            this.txtSvrha.Size = new System.Drawing.Size(225, 20);
            this.txtSvrha.TabIndex = 3;
            this.txtSvrha.Validating += new System.ComponentModel.CancelEventHandler(this.txtSvrha_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Datum";
            // 
            // txtDatum
            // 
            this.txtDatum.Location = new System.Drawing.Point(46, 258);
            this.txtDatum.Name = "txtDatum";
            this.txtDatum.Size = new System.Drawing.Size(225, 20);
            this.txtDatum.TabIndex = 5;
            this.txtDatum.Validating += new System.ComponentModel.CancelEventHandler(this.txtDatum_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Admin";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 409);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Polaznik";
            // 
            // btnSnimi
            // 
            this.btnSnimi.Location = new System.Drawing.Point(315, 529);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(75, 23);
            this.btnSnimi.TabIndex = 10;
            this.btnSnimi.Text = "Sačuvaj";
            this.btnSnimi.UseVisualStyleBackColor = true;
            this.btnSnimi.Click += new System.EventHandler(this.btnSnimi_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 492);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Subskripcija";
            // 
            // polaznikBindingSource1
            // 
            this.polaznikBindingSource1.DataMember = "Polaznik";
            this.polaznikBindingSource1.DataSource = this.gymManager1DataSet1;
            // 
            // gymManager1DataSet1
            // 
            this.gymManager1DataSet1.DataSetName = "GymManager1DataSet1";
            this.gymManager1DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gymManager1DataSet
            // 
            this.gymManager1DataSet.DataSetName = "GymManager1DataSet";
            this.gymManager1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // polaznikBindingSource
            // 
            this.polaznikBindingSource.DataMember = "Polaznik";
            this.polaznikBindingSource.DataSource = this.gymManager1DataSet;
            // 
            // polaznikTableAdapter
            // 
            this.polaznikTableAdapter.ClearBeforeFill = true;
            // 
            // polaznikTableAdapter1
            // 
            this.polaznikTableAdapter1.ClearBeforeFill = true;
            // 
            // cboPolaznici
            // 
            this.cboPolaznici.FormattingEnabled = true;
            this.cboPolaznici.Location = new System.Drawing.Point(46, 449);
            this.cboPolaznici.Name = "cboPolaznici";
            this.cboPolaznici.Size = new System.Drawing.Size(225, 21);
            this.cboPolaznici.TabIndex = 13;
            this.cboPolaznici.Validating += new System.ComponentModel.CancelEventHandler(this.cboPolaznici_Validating);
            // 
            // cboAdmin
            // 
            this.cboAdmin.FormattingEnabled = true;
            this.cboAdmin.Location = new System.Drawing.Point(46, 360);
            this.cboAdmin.Name = "cboAdmin";
            this.cboAdmin.Size = new System.Drawing.Size(225, 21);
            this.cboAdmin.TabIndex = 14;
            this.cboAdmin.Validating += new System.ComponentModel.CancelEventHandler(this.cboAdmin_Validating);
            // 
            // cboSub
            // 
            this.cboSub.FormattingEnabled = true;
            this.cboSub.Location = new System.Drawing.Point(46, 531);
            this.cboSub.Name = "cboSub";
            this.cboSub.Size = new System.Drawing.Size(225, 21);
            this.cboSub.TabIndex = 15;
            this.cboSub.Validating += new System.ComponentModel.CancelEventHandler(this.cboSub_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmUplataDodaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 576);
            this.Controls.Add(this.cboSub);
            this.Controls.Add(this.cboAdmin);
            this.Controls.Add(this.cboPolaznici);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSnimi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDatum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSvrha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIznos);
            this.Name = "frmUplataDodaj";
            this.Text = "frmUplataDodaj";
            this.Load += new System.EventHandler(this.frmUplataDodaj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.polaznikBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymManager1DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymManager1DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.polaznikBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIznos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSvrha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDatum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSnimi;
        private System.Windows.Forms.Label label6;
        private GymManager1DataSet gymManager1DataSet;
        private System.Windows.Forms.BindingSource polaznikBindingSource;
        private GymManager1DataSetTableAdapters.PolaznikTableAdapter polaznikTableAdapter;
        private GymManager1DataSet1 gymManager1DataSet1;
        private System.Windows.Forms.BindingSource polaznikBindingSource1;
        private GymManager1DataSet1TableAdapters.PolaznikTableAdapter polaznikTableAdapter1;
        private System.Windows.Forms.ComboBox cboPolaznici;
        private System.Windows.Forms.ComboBox cboAdmin;
        private System.Windows.Forms.ComboBox cboSub;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}