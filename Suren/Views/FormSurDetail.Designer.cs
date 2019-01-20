namespace Suren.Views
{
    partial class FormSurDetail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSurDetail));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnautotitle = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.siman = new Suren.Views.SelectInput();
            this.siweather = new Suren.Views.SelectInput();
            this.sidataunit = new Suren.Views.SelectInput();
            this.sisurremark = new Suren.Views.SelectInput();
            this.sisurtitle = new Suren.Views.SelectInput();
            this.sisurid = new Suren.Views.SelectInput();
            this.sisurproject = new Suren.Views.SelectInput();
            this.sisurtarget = new Suren.Views.SelectInput();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.griddata = new System.Windows.Forms.DataGridView();
            this.pointid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nouseable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolbtnsave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.griddata)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnautotitle);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.siman);
            this.groupBox1.Controls.Add(this.siweather);
            this.groupBox1.Controls.Add(this.sidataunit);
            this.groupBox1.Controls.Add(this.sisurremark);
            this.groupBox1.Controls.Add(this.sisurtitle);
            this.groupBox1.Controls.Add(this.sisurid);
            this.groupBox1.Controls.Add(this.sisurproject);
            this.groupBox1.Controls.Add(this.sisurtarget);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(885, 201);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // btnautotitle
            // 
            this.btnautotitle.Location = new System.Drawing.Point(282, 145);
            this.btnautotitle.Name = "btnautotitle";
            this.btnautotitle.Size = new System.Drawing.Size(80, 31);
            this.btnautotitle.TabIndex = 13;
            this.btnautotitle.Text = "自动标题";
            this.btnautotitle.UseVisualStyleBackColor = true;
            this.btnautotitle.Click += new System.EventHandler(this.btnautotitle_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDate.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(106, 149);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(128, 25);
            this.dtpDate.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(21, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "测量日期：";
            // 
            // siman
            // 
            this.siman.ButtonVisible = false;
            this.siman.DisplayValue = "";
            this.siman.EditText = "";
            this.siman.Location = new System.Drawing.Point(407, 85);
            this.siman.Name = "siman";
            this.siman.ReadOnly = false;
            this.siman.RealValue = null;
            this.siman.SelectOnly = false;
            this.siman.Size = new System.Drawing.Size(340, 27);
            this.siman.TabIndex = 7;
            this.siman.Title = "参与人员：";
            // 
            // siweather
            // 
            this.siweather.ButtonVisible = false;
            this.siweather.DisplayValue = "";
            this.siweather.EditText = "";
            this.siweather.Location = new System.Drawing.Point(407, 52);
            this.siweather.Name = "siweather";
            this.siweather.ReadOnly = false;
            this.siweather.RealValue = null;
            this.siweather.SelectOnly = false;
            this.siweather.Size = new System.Drawing.Size(340, 27);
            this.siweather.TabIndex = 6;
            this.siweather.Title = "当前天气：";
            // 
            // sidataunit
            // 
            this.sidataunit.ButtonVisible = false;
            this.sidataunit.DisplayValue = "m";
            this.sidataunit.EditText = "m";
            this.sidataunit.Location = new System.Drawing.Point(407, 23);
            this.sidataunit.Name = "sidataunit";
            this.sidataunit.ReadOnly = false;
            this.sidataunit.RealValue = null;
            this.sidataunit.SelectOnly = false;
            this.sidataunit.Size = new System.Drawing.Size(340, 27);
            this.sidataunit.TabIndex = 5;
            this.sidataunit.Title = "数据单位：";
            // 
            // sisurremark
            // 
            this.sisurremark.ButtonVisible = false;
            this.sisurremark.DisplayValue = "";
            this.sisurremark.EditText = "";
            this.sisurremark.Location = new System.Drawing.Point(407, 116);
            this.sisurremark.Name = "sisurremark";
            this.sisurremark.ReadOnly = false;
            this.sisurremark.RealValue = null;
            this.sisurremark.SelectOnly = false;
            this.sisurremark.Size = new System.Drawing.Size(340, 33);
            this.sisurremark.TabIndex = 8;
            this.sisurremark.Title = "备注：";
            // 
            // sisurtitle
            // 
            this.sisurtitle.ButtonVisible = false;
            this.sisurtitle.DisplayValue = "";
            this.sisurtitle.EditText = "";
            this.sisurtitle.Location = new System.Drawing.Point(23, 53);
            this.sisurtitle.Name = "sisurtitle";
            this.sisurtitle.ReadOnly = false;
            this.sisurtitle.RealValue = null;
            this.sisurtitle.SelectOnly = false;
            this.sisurtitle.Size = new System.Drawing.Size(339, 27);
            this.sisurtitle.TabIndex = 1;
            this.sisurtitle.Title = "测量标题：";
            // 
            // sisurid
            // 
            this.sisurid.ButtonVisible = false;
            this.sisurid.DisplayValue = "";
            this.sisurid.EditText = "";
            this.sisurid.Location = new System.Drawing.Point(25, 20);
            this.sisurid.Name = "sisurid";
            this.sisurid.ReadOnly = true;
            this.sisurid.RealValue = null;
            this.sisurid.SelectOnly = false;
            this.sisurid.Size = new System.Drawing.Size(337, 27);
            this.sisurid.TabIndex = 0;
            this.sisurid.Title = "测量ID：";
            // 
            // sisurproject
            // 
            this.sisurproject.ButtonVisible = true;
            this.sisurproject.DisplayValue = "";
            this.sisurproject.EditText = "";
            this.sisurproject.Location = new System.Drawing.Point(22, 86);
            this.sisurproject.Name = "sisurproject";
            this.sisurproject.ReadOnly = false;
            this.sisurproject.RealValue = null;
            this.sisurproject.SelectOnly = true;
            this.sisurproject.Size = new System.Drawing.Size(340, 27);
            this.sisurproject.TabIndex = 2;
            this.sisurproject.Title = "所属项目：";
            this.sisurproject.Searching += new System.EventHandler(this.sisurproject_Searching);
            // 
            // sisurtarget
            // 
            this.sisurtarget.ButtonVisible = true;
            this.sisurtarget.DisplayValue = "";
            this.sisurtarget.EditText = "";
            this.sisurtarget.Location = new System.Drawing.Point(22, 116);
            this.sisurtarget.Name = "sisurtarget";
            this.sisurtarget.ReadOnly = false;
            this.sisurtarget.RealValue = null;
            this.sisurtarget.SelectOnly = true;
            this.sisurtarget.Size = new System.Drawing.Size(340, 27);
            this.sisurtarget.TabIndex = 3;
            this.sisurtarget.Title = "测量对象：";
            this.sisurtarget.Searching += new System.EventHandler(this.sisurtarget_Searching);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.griddata);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(879, 253);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测量数据";
            // 
            // griddata
            // 
            this.griddata.AllowUserToAddRows = false;
            this.griddata.AllowUserToDeleteRows = false;
            this.griddata.BackgroundColor = System.Drawing.Color.White;
            this.griddata.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.griddata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.griddata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pointid,
            this.pointname,
            this.data1,
            this.data2,
            this.data3,
            this.nouseable,
            this.remark});
            this.griddata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.griddata.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.griddata.Location = new System.Drawing.Point(3, 21);
            this.griddata.MultiSelect = false;
            this.griddata.Name = "griddata";
            this.griddata.RowHeadersWidth = 20;
            this.griddata.RowTemplate.Height = 23;
            this.griddata.Size = new System.Drawing.Size(873, 229);
            this.griddata.TabIndex = 0;
            // 
            // pointid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pointid.DefaultCellStyle = dataGridViewCellStyle1;
            this.pointid.HeaderText = "测量点ID";
            this.pointid.Name = "pointid";
            this.pointid.ReadOnly = true;
            // 
            // pointname
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pointname.DefaultCellStyle = dataGridViewCellStyle2;
            this.pointname.FillWeight = 130F;
            this.pointname.HeaderText = "测量点名称";
            this.pointname.Name = "pointname";
            this.pointname.ReadOnly = true;
            this.pointname.Width = 130;
            // 
            // data1
            // 
            this.data1.HeaderText = "数据1";
            this.data1.Name = "data1";
            // 
            // data2
            // 
            this.data2.HeaderText = "数据2";
            this.data2.Name = "data2";
            // 
            // data3
            // 
            this.data3.HeaderText = "数据3";
            this.data3.Name = "data3";
            // 
            // nouseable
            // 
            this.nouseable.FillWeight = 60F;
            this.nouseable.HeaderText = "不可用";
            this.nouseable.Name = "nouseable";
            this.nouseable.Width = 60;
            // 
            // remark
            // 
            this.remark.FillWeight = 150F;
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            this.remark.Width = 150;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnsave,
            this.toolStripButton1});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(885, 25);
            this.toolStrip3.TabIndex = 5;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolbtnsave
            // 
            this.toolbtnsave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolbtnsave.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnsave.Image")));
            this.toolbtnsave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnsave.Name = "toolbtnsave";
            this.toolbtnsave.Size = new System.Drawing.Size(36, 22);
            this.toolbtnsave.Text = "保存";
            this.toolbtnsave.Click += new System.EventHandler(this.toolbtnsave_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton1.Text = "重填表格";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 226);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(885, 259);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // FormSurDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 485);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip3);
            this.Name = "FormSurDetail";
            this.TabText = "测量详情";
            this.Text = "测量详情";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.griddata)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SelectInput sisurproject;
        private SelectInput sisurtarget;
        private SelectInput sisurid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView griddata;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolbtnsave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private SelectInput sisurremark;
        private SelectInput sisurtitle;
        private SelectInput sidataunit;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label1;
        private SelectInput siman;
        private SelectInput siweather;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointname;
        private System.Windows.Forms.DataGridViewTextBoxColumn data1;
        private System.Windows.Forms.DataGridViewTextBoxColumn data2;
        private System.Windows.Forms.DataGridViewTextBoxColumn data3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn nouseable;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.Button btnautotitle;
    }
}