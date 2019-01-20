namespace Suren.Views
{
    partial class SelectInput
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.btnok = new System.Windows.Forms.Button();
            this.panelcontent = new System.Windows.Forms.Panel();
            this.txt = new System.Windows.Forms.TextBox();
            this.panelRight.SuspendLayout();
            this.panelcontent.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.btnok);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(434, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(29, 29);
            this.panelRight.TabIndex = 1;
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(1, 2);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(25, 25);
            this.btnok.TabIndex = 0;
            this.btnok.Text = "..";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // panelcontent
            // 
            this.panelcontent.Controls.Add(this.txt);
            this.panelcontent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelcontent.Location = new System.Drawing.Point(53, 0);
            this.panelcontent.Name = "panelcontent";
            this.panelcontent.Size = new System.Drawing.Size(381, 29);
            this.panelcontent.TabIndex = 2;
            // 
            // txt
            // 
            this.txt.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt.Location = new System.Drawing.Point(0, 2);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(380, 25);
            this.txt.TabIndex = 0;
            this.txt.Enter += new System.EventHandler(this.txt_Enter);
            this.txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            this.txt.Leave += new System.EventHandler(this.txt_Leave);
            // 
            // SelectInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelcontent);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.label1);
            this.Name = "SelectInput";
            this.Size = new System.Drawing.Size(463, 29);
            this.panelRight.ResumeLayout(false);
            this.panelcontent.ResumeLayout(false);
            this.panelcontent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Panel panelcontent;
        private System.Windows.Forms.TextBox txt;
    }
}
