using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Suren.Views
{
    public partial class FormView : DockContent
    {
        public FormView()
        {
            InitializeComponent();
            this.ShowIcon = false;
        }

        public virtual bool ExecCmd(string cmd, object[] args)
        {
            switch (cmd)
            {
                case "open": this.Show(); return true;
            }
            return false;
        }
    }

}
