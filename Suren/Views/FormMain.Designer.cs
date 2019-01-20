namespace Suren.Views
{
    partial class FormMain
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
            this.dockPanelMain = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnAddSur = new System.Windows.Forms.Button();
            this.btnSurList = new System.Windows.Forms.Button();
            this.btnProList = new System.Windows.Forms.Button();
            this.btnbuildtestdata = new System.Windows.Forms.Button();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockPanelMain
            // 
            this.dockPanelMain.ActiveAutoHideContent = null;
            this.dockPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanelMain.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockPanelMain.Location = new System.Drawing.Point(176, 0);
            this.dockPanelMain.Name = "dockPanelMain";
            this.dockPanelMain.Size = new System.Drawing.Size(973, 544);
            this.dockPanelMain.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.btnbuildtestdata);
            this.pnlLeft.Controls.Add(this.btnReport);
            this.pnlLeft.Controls.Add(this.btnAddSur);
            this.pnlLeft.Controls.Add(this.btnSurList);
            this.pnlLeft.Controls.Add(this.btnProList);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(176, 544);
            this.pnlLeft.TabIndex = 2;
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            this.btnReport.Location = new System.Drawing.Point(30, 277);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(125, 52);
            this.btnReport.TabIndex = 3;
            this.btnReport.Text = "报表(&R)";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnAddSur
            // 
            this.btnAddSur.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddSur.Location = new System.Drawing.Point(30, 195);
            this.btnAddSur.Name = "btnAddSur";
            this.btnAddSur.Size = new System.Drawing.Size(125, 52);
            this.btnAddSur.TabIndex = 2;
            this.btnAddSur.Text = "添加测量(&A)";
            this.btnAddSur.UseVisualStyleBackColor = true;
            this.btnAddSur.Click += new System.EventHandler(this.btnAddSur_Click);
            // 
            // btnSurList
            // 
            this.btnSurList.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSurList.Location = new System.Drawing.Point(30, 113);
            this.btnSurList.Name = "btnSurList";
            this.btnSurList.Size = new System.Drawing.Size(125, 52);
            this.btnSurList.TabIndex = 1;
            this.btnSurList.Text = "测量列表(&S)";
            this.btnSurList.UseVisualStyleBackColor = true;
            this.btnSurList.Click += new System.EventHandler(this.btnSurList_Click);
            // 
            // btnProList
            // 
            this.btnProList.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnProList.Location = new System.Drawing.Point(30, 30);
            this.btnProList.Name = "btnProList";
            this.btnProList.Size = new System.Drawing.Size(125, 52);
            this.btnProList.TabIndex = 0;
            this.btnProList.Text = "项目列表(&P)";
            this.btnProList.UseVisualStyleBackColor = true;
            this.btnProList.Click += new System.EventHandler(this.btnProList_Click);
            // 
            // btnbuildtestdata
            // 
            this.btnbuildtestdata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnbuildtestdata.Location = new System.Drawing.Point(12, 509);
            this.btnbuildtestdata.Name = "btnbuildtestdata";
            this.btnbuildtestdata.Size = new System.Drawing.Size(143, 23);
            this.btnbuildtestdata.TabIndex = 4;
            this.btnbuildtestdata.Text = "清空原数据生成测试数据";
            this.btnbuildtestdata.UseVisualStyleBackColor = true;
            this.btnbuildtestdata.Click += new System.EventHandler(this.btnbuildtestdata_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 544);
            this.Controls.Add(this.dockPanelMain);
            this.Controls.Add(this.pnlLeft);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suren项目管理";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.pnlLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanelMain;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Button btnAddSur;
        private System.Windows.Forms.Button btnSurList;
        private System.Windows.Forms.Button btnProList;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnbuildtestdata;
    }
}

