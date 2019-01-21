using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Suren.Views
{
    public partial class FormReport : FormView
    {
        public FormReport()
        {
            InitializeComponent();
        }

        private void siproject_Searching(object sender, EventArgs e)
        {
            var pid = Lib.ToInt(siproject.RealValue);
            var tx = siproject.EditText;
            var project = new Views.FormSelect().SelectProject(tx);
            if (project != null && pid != project.ProjectId)
            {
                if (siproject.RealValue != (object)project.ProjectId)
                {
                    sitarget.Clear();
                }
                siproject.DisplayValue = project.ProjectName;
                siproject.RealValue = project.ProjectId;
                siproject.Tag = project;
            }
            if (project == null)
            {
                siproject.Clear();
                sitarget.Clear();
            }
        }

        private void sitarget_Searching(object sender, EventArgs e)
        {
            var pid = Lib.ToInt(siproject.RealValue);
            var tid = Lib.ToInt(sitarget.RealValue);
            if (pid <= 0) return;
            var target = new Views.FormSelect().SelectTarget(pid, sitarget.EditText);
            if (target != null && target.TargetId != tid)
            {
                sitarget.DisplayValue = target.TargetName;
                sitarget.RealValue = target.TargetId;
                sitarget.Tag = target;
            }
            if (target == null)
            {
                sitarget.Clear();
            }
        }


        private void FormReport_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            map.Add("projectname", "项目名称");
            map.Add("targetname", "测量目标名称");
            map.Add("surveyingname", "测量名称");
            map.Add("surveyingtime", "测量时间");
            map.Add("pointname", "测量点");
            map.Add("data1", "data1");
            map.Add("data2", "data2");
            map.Add("data3", "data3");
            map.Add("nouseable", "不可用");
            map.Add("remark", "备注");
            Pub.InitGrid(griddetail, map);
            griddetail.ReadOnly = true;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            SearchShow(1);
        }

        private string GetCurrentTmpl()
        {
            return "suren.report.stmpl";
        }

        private void SearchShow(int pno)
        {
            int pagesize = 100;
            var pid = Lib.ToInt(siproject.RealValue);
            var tid = Lib.ToInt(sitarget.RealValue);
            using (var db = Pub.GetConn())
            {
                var datas = Dal.Instance.QuerySurveyingDetails(pno, pagesize, pid, tid);

                Pub.FillGrid(griddetail, pager1, datas, (dr, item) =>
                {
                    dr.Cells["projectname"].Value = item.ProjectName;
                    dr.Cells["targetname"].Value = item.TargetName;
                    dr.Cells["surveyingname"].Value = item.SurveyingName;
                    dr.Cells["surveyingtime"].Value = item.SurveyingTime.ToString("yyyy-MM-dd");


                    dr.Cells["pointname"].Value = item.PointName;
                    dr.Cells["data1"].Value = item.NoUseable > 0 ? "" : item.Data1.ToString();
                    dr.Cells["data2"].Value = item.NoUseable > 0 ? "" : item.Data2.ToString();
                    dr.Cells["data3"].Value = item.NoUseable > 0 ? "" : item.Data3.ToString();
                    dr.Cells["nouseable"].Value = item.NoUseable > 0 ? "不可用" : "可用";
                    dr.Cells["remark"].Value = item.Remark;
                    dr.Tag = item;
                });
                griddetail.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);

                var gendatas = Dal.Instance.GetGenDatas(pid, tid);
                if (pid > 0 && tid > 0)
                {
                    var tb = RenDataBuilder.BuildGenTable(pid, tid, gendatas);
                    gridgen.DataSource = tb;
                    gridgen.ReadOnly = true;
                    gridgen.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    var cdata = RenDataBuilder.BuildChartData(pid, tid, gendatas);
                    RenDataBuilder.BindToChart(null, chart1, cdata, 1);

                    var ds = TmplHelper.Exec(pid, tid, GetCurrentTmpl());
                    GridReportHelper.ShowReport(gridtarreport, ds.Tables[0], ds.Tables[1], ds.Tables[2]);

                }
                else
                {
                    gridgen.DataSource = null;
                }

            }


        }

        private void pager1_OnPage(int obj)
        {
            SearchShow(obj);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var pid = Lib.ToInt(siproject.RealValue);
            if (pid <= 0)
            {
                MsgHelper.ShowInfo("请选择项目！");
                return;
            }
            var g = new RenDataBuilder(pid);
            g.Start();
            MsgHelper.ShowInfo("生成成功");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var pid = Lib.ToInt(siproject.RealValue);
            if (pid <= 0)
            {
                MsgHelper.ShowInfo("请选择项目");
                return;
            }

            var path = AppDomain.CurrentDomain.BaseDirectory;
            using (var dbconn = Pub.GetConn())
            {
                var proinfo = Dal.Instance.ProjectDetail(pid);

                using (var ms = new System.IO.MemoryStream())
                {
                    var fn = string.Format("{0}-报表.docx", proinfo.ProjectName);
                    string fullname = System.IO.Path.Combine(path, fn);
                    int w = WordHelper.ToTI(210, 2);
                    int h = WordHelper.ToTI(297, 2);
                    var wordh = new WordHelper(fullname, w, h);

                    wordh.AddTitle(string.Format("{0}-报表", proinfo.ProjectName));

                    foreach (var tr in Dal.Instance.Targets(pid))
                    {
                        var tid = tr.TargetId;
                        string title = string.Format("{0}{1}时间变化曲线图", proinfo.ProjectName, tr.TargetName);
                        var gendatas = Dal.Instance.GetGenDatas(pid, tid);
                        var ds = TmplHelper.Exec(pid, tid, GetCurrentTmpl());
                        Chart mychart = new Chart();
                        int wimg = WordHelper.TIToPx(w);
                        int himg = (int)(wimg / 5.0 * 2);
                        mychart.Size = new Size(wimg * 2, himg * 2);
                        var dic = RenDataBuilder.BuildChartData(pid, tid, gendatas);
                        RenDataBuilder.BindToChart(title, mychart, dic, 2);
                        var gtb = RenDataBuilder.BuildGenTable(pid, tid, gendatas);
                        wordh.DrawTable(ds.Tables[0], ds.Tables[1], ds.Tables[2]);
                        wordh.AddEmptLine();
                        wordh.DrawTable(gtb);
                        wordh.AddEmptLine();
                        mychart.SaveImage(ms, ChartImageFormat.Png);
                        wordh.AddEmptLine();
                        wordh.DrawTableChart(ms, wimg - 20, himg);
                        wordh.AddEmptLine();
                    }
                    wordh.Save();
                }
            }

            System.Diagnostics.Process.Start(path);


        }
    }
}
