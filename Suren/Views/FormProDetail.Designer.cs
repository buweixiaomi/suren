namespace Suren.Views
{
    partial class FormProDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProDetail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.siprojectname = new Suren.Views.SelectInput();
            this.siprojectremark = new Suren.Views.SelectInput();
            this.siprojectid = new Suren.Views.SelectInput();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridtarget = new System.Windows.Forms.DataGridView();
            this.targetid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targetname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targetremark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridpoint = new System.Windows.Forms.DataGridView();
            this.pointid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointremark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridtarget)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridpoint)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // siprojectname
            // 
            this.siprojectname.ButtonVisible = false;
            this.siprojectname.DisplayValue = "";
            this.siprojectname.EditText = "";
            this.siprojectname.Location = new System.Drawing.Point(22, 61);
            this.siprojectname.Name = "siprojectname";
            this.siprojectname.ReadOnly = false;
            this.siprojectname.RealValue = null;
            this.siprojectname.SelectOnly = false;
            this.siprojectname.Size = new System.Drawing.Size(340, 41);
            this.siprojectname.TabIndex = 1;
            this.siprojectname.Title = "项目名称：";
            // 
            // siprojectremark
            // 
            this.siprojectremark.ButtonVisible = false;
            this.siprojectremark.DisplayValue = "";
            this.siprojectremark.EditText = "";
            this.siprojectremark.Location = new System.Drawing.Point(22, 96);
            this.siprojectremark.Name = "siprojectremark";
            this.siprojectremark.ReadOnly = false;
            this.siprojectremark.RealValue = null;
            this.siprojectremark.SelectOnly = false;
            this.siprojectremark.Size = new System.Drawing.Size(340, 41);
            this.siprojectremark.TabIndex = 2;
            this.siprojectremark.Title = "项目备注：";
            // 
            // siprojectid
            // 
            this.siprojectid.ButtonVisible = false;
            this.siprojectid.DisplayValue = "";
            this.siprojectid.EditText = "";
            this.siprojectid.Location = new System.Drawing.Point(22, 25);
            this.siprojectid.Name = "siprojectid";
            this.siprojectid.ReadOnly = true;
            this.siprojectid.RealValue = null;
            this.siprojectid.SelectOnly = false;
            this.siprojectid.Size = new System.Drawing.Size(340, 40);
            this.siprojectid.TabIndex = 0;
            this.siprojectid.Title = "项目ID：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.siprojectid);
            this.groupBox1.Controls.Add(this.siprojectname);
            this.groupBox1.Controls.Add(this.siprojectremark);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(885, 144);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridtarget);
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 350);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测量对象";
            // 
            // gridtarget
            // 
            this.gridtarget.AllowUserToAddRows = false;
            this.gridtarget.AllowUserToDeleteRows = false;
            this.gridtarget.BackgroundColor = System.Drawing.Color.White;
            this.gridtarget.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridtarget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridtarget.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.targetid,
            this.targetname,
            this.targetremark});
            this.gridtarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridtarget.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridtarget.Location = new System.Drawing.Point(3, 46);
            this.gridtarget.MultiSelect = false;
            this.gridtarget.Name = "gridtarget";
            this.gridtarget.RowTemplate.Height = 23;
            this.gridtarget.Size = new System.Drawing.Size(430, 301);
            this.gridtarget.TabIndex = 0;
            this.gridtarget.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridtarget_CellEndEdit);
            this.gridtarget.CurrentCellChanged += new System.EventHandler(this.gridtarget_CurrentCellChanged);
            this.gridtarget.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridtarget_KeyDown);
            // 
            // targetid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.targetid.DefaultCellStyle = dataGridViewCellStyle1;
            this.targetid.HeaderText = "对象ID";
            this.targetid.Name = "targetid";
            this.targetid.ReadOnly = true;
            // 
            // targetname
            // 
            this.targetname.HeaderText = "对象名称";
            this.targetname.Name = "targetname";
            // 
            // targetremark
            // 
            this.targetremark.HeaderText = "备注";
            this.targetremark.Name = "targetremark";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(3, 21);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(430, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(37, 22);
            this.toolStripButton1.Text = "添加";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(37, 22);
            this.toolStripButton2.Text = "删除";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridpoint);
            this.groupBox3.Controls.Add(this.toolStrip2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F);
            this.groupBox3.Location = new System.Drawing.Point(445, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(437, 350);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "测量点";
            // 
            // gridpoint
            // 
            this.gridpoint.AllowUserToAddRows = false;
            this.gridpoint.AllowUserToDeleteRows = false;
            this.gridpoint.BackgroundColor = System.Drawing.Color.White;
            this.gridpoint.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridpoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridpoint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pointid,
            this.pointname,
            this.pointremark});
            this.gridpoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridpoint.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridpoint.Location = new System.Drawing.Point(3, 46);
            this.gridpoint.Name = "gridpoint";
            this.gridpoint.RowTemplate.Height = 23;
            this.gridpoint.Size = new System.Drawing.Size(431, 301);
            this.gridpoint.TabIndex = 0;
            this.gridpoint.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridpoint_CellEndEdit);
            this.gridpoint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridpoint_KeyDown);
            // 
            // pointid
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pointid.DefaultCellStyle = dataGridViewCellStyle2;
            this.pointid.HeaderText = "测量点ID";
            this.pointid.Name = "pointid";
            this.pointid.ReadOnly = true;
            // 
            // pointname
            // 
            this.pointname.FillWeight = 130F;
            this.pointname.HeaderText = "测量点名称";
            this.pointname.Name = "pointname";
            this.pointname.Width = 130;
            // 
            // pointremark
            // 
            this.pointremark.FillWeight = 130F;
            this.pointremark.HeaderText = "测量点备注";
            this.pointremark.Name = "pointremark";
            this.pointremark.Width = 130;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip2.Location = new System.Drawing.Point(3, 21);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(431, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(37, 22);
            this.toolStripButton3.Text = "添加";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(37, 22);
            this.toolStripButton4.Text = "删除";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(885, 25);
            this.toolStrip3.TabIndex = 5;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(37, 22);
            this.toolStripButton5.Text = "保存";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 169);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(885, 356);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // FormProDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 525);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip3);
            this.Name = "FormProDetail";
            this.TabText = "项目详情";
            this.Text = "项目详情";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridtarget)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridpoint)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SelectInput siprojectname;
        private SelectInput siprojectremark;
        private SelectInput siprojectid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gridtarget;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.DataGridView gridpoint;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetid;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetname;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetremark;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointname;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointremark;
    }
}