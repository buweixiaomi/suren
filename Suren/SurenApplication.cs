using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Suren
{
    public class SurenApplication : ApplicationContext
    {
        public static SurenApplication SurenApp { get; private set; }
        public bool IsLogin = true;
        public Views.FormMain mainform;
        public SurenApplication()
        {
            this.mainform = new Views.FormMain();
            this.MainForm = this.mainform;
            SurenApp = this;
            Application.ThreadException += Application_ThreadException;
        }

        private void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MsgHelper.ShowWarning("出错", e.Exception.Message);
        }

        public void Start()
        {
            if (!IsLogin)
            {
                var loginview = new Views.FromLogin();
                if (loginview.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                this.IsLogin = true;
            }
            Application.Run(this);
        }

        public void OpenView<T>(string cmd, object[] args)
            where T : Views.FormView
        {
            T instance = null;
            foreach (var a in mainform.GetMidChildren())
            {
                if (a is T)
                {
                    instance = (T)a;
                    break;
                }
            }
            if (instance == null)
            {
                instance = Activator.CreateInstance<T>();
                instance.MdiParent = this.mainform;
                mainform.ShowIn(instance);
            }
            mainform.SetChildCurrent(instance);
            instance.ExecCmd(cmd, args);
        }
    }
}
