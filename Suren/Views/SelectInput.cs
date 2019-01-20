using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Suren.Views
{
    public partial class SelectInput : UserControl
    {
        public event EventHandler Searching;
        public bool ButtonVisible
        {
            get
            {
                return panelRight.Visible;
            }
            set
            {
                panelRight.Visible = value;
            }
        }
        public SelectInput()
        {
            InitializeComponent();
            this.ButtonVisible = false;
            this.SelectOnly = false;
            this.ReadOnly = false;
            this.Title = "名称：";
            LayoutUI();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            LayoutUI();
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            LayoutUI();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            LayoutUI();
        }

        private void LayoutUI()
        {

            using (var g = label1.CreateGraphics())
            {
                var sf = g.MeasureString(label1.Text, label1.Font);
                var pd = 8;
                label1.Width = (int)Math.Floor(sf.Width) + pd;
            }
            this.txt.Width = this.panelcontent.Width - 4;
            this.txt.Location = new Point(this.panelcontent.Width / 2 - this.txt.Width / 2,
                this.panelcontent.Height / 2 - this.txt.Height / 2);
            this.panelRight.Width = this.txt.Height + 4;
            btnok.Width = this.txt.Height;
            btnok.Height = this.txt.Height;
            btnok.Location = new Point(this.panelRight.Width / 2 - this.btnok.Width / 2,
                this.panelRight.Height / 2 - this.btnok.Height / 2);
        }


        public string Title
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
                LayoutUI();
            }
        }

        private object realValue;
        private string displayValue;
        public object RealValue
        {
            get { return realValue; }
            set
            {
                realValue = value;
            }
        }
        public string DisplayValue
        {
            get
            {
                if (selectonly) return displayValue;
                return txt.Text;
            }
            set
            {
                displayValue = value;
                if (selectonly)
                {
                    ShowValue();
                }
                else
                {
                    this.txt.Text = displayValue;
                }
            }
        }
        public bool ReadOnly
        {
            get
            {
                return txt.ReadOnly;
            }
            set
            {
                txt.ReadOnly = value;
                btnok.Enabled = !txt.ReadOnly;
            }
        }
        private bool selectonly;
        public bool SelectOnly
        {
            get { return selectonly; }
            set
            {
                selectonly = value;
            }
        }

        public string EditText
        {
            get { return txt.Text; }
            set { txt.Text = value; }
        }


        public void ShowValue()
        {
            if (selectonly)
            {
                this.txt.Text = DisplayValue ?? "";
            }
            else
            {
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (!this.ReadOnly)
            {
                if (Searching != null)
                    Searching.Invoke(this, KeyEventArgs.Empty);
            }
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            ShowValue();
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            ShowValue();
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.SelectOnly && !this.ReadOnly && e.KeyCode == Keys.Enter)
            {
                if (Searching != null)
                    Searching.Invoke(this, KeyEventArgs.Empty);
            }
        }

        public void Clear()
        {
            realValue = null;
            displayValue = "";
            txt.Text = "";
        }
    }
}
