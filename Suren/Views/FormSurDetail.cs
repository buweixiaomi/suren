using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Suren.Views
{
    public partial class FormSurDetail : FormView
    {
        public FormSurDetail()
        {
            InitializeComponent();
        }



        Models.Surveying surveyingInfo;

        public override bool ExecCmd(string cmd, object[] args)
        {
            var v = base.ExecCmd(cmd, args);
            if (v) return v;
            switch (cmd)
            {
                case "opennew":
                    New();
                    return true;
                case "openshow":
                    ShowDetail((int)args[0]);
                    return true;
            }
            return false;

        }

        private void New()
        {
            this.TabText = "新增测量";
            this.Text = this.TabText;
            surveyingInfo = new Models.Surveying();
            dtpDate.Value = DateTime.Now;
            ShowInUI();
        }
        private void ShowDetail(int surveyingid)
        {
            using (var db = Pub.GetConn())
            {
                surveyingInfo = Dal.Instance.SurveyingDetail(surveyingid);
                if (surveyingInfo == null)
                {
                    MsgHelper.ShowWarning("提示", "测量不存在！");
                    New();
                    return;
                }
                var ps = Dal.Instance.Points(surveyingInfo.ProjectId, surveyingInfo.TargetId);
                foreach (var a in ps)
                {
                    if (!surveyingInfo.SurveyingDetails.Exists(x => x.PointId == a.PointId))
                    {
                        surveyingInfo.SurveyingDetails.Add(new Models.SurveyingDetail()
                        {
                            Point = a,
                            PointId = a.PointId,
                            ProjectId = surveyingInfo.ProjectId,
                            Remark = "",
                            Surveying = surveyingInfo,
                            SurveyingId = surveyingInfo.SurveyingId,
                            TargetId = surveyingInfo.TargetId,
                            Project = surveyingInfo.Project,
                            Target = surveyingInfo.Target
                        });
                    }
                }
                surveyingInfo.SurveyingDetails = surveyingInfo.SurveyingDetails.OrderBy(x => x.PointId).ToList();
                ShowInUI();
            }
        }

        private void ShowInUI()
        {
            sisurid.DisplayValue = surveyingInfo.SurveyingId.ToString();
            sisurtitle.DisplayValue = surveyingInfo.SurveyingName ?? "";
            sisurremark.DisplayValue = surveyingInfo.Remark ?? "";

            sisurproject.RealValue = surveyingInfo.ProjectId;
            sisurproject.DisplayValue = surveyingInfo.Project == null ? "" : surveyingInfo.Project.ProjectName;


            sisurtarget.RealValue = surveyingInfo.TargetId;
            sisurtarget.DisplayValue = surveyingInfo.Target == null ? "" : surveyingInfo.Target.TargetName;

            sisurproject.ReadOnly = surveyingInfo.SurveyingId > 0;
            sisurtarget.ReadOnly = surveyingInfo.SurveyingId > 0;

            ShowTargetGrid();
        }

        private void ShowTargetGrid()
        {
            griddata.Rows.Clear();
            if (surveyingInfo.SurveyingDetails == null)
            {
                surveyingInfo.SurveyingDetails = new List<Models.SurveyingDetail>();
            }
            if (surveyingInfo.SurveyingDetails != null)
            {
                Pub.FillGrid<Models.SurveyingDetail>(griddata, surveyingInfo.SurveyingDetails, (dr, item) =>
                    {
                        dr.Cells["pointid"].Value = item.PointId;
                        dr.Cells["pointname"].Value = item.Point.PointName;
                        dr.Cells["data1"].Value = item.Data1.ToString();
                        dr.Cells["data2"].Value = item.Data2.ToString();
                        dr.Cells["data3"].Value = item.Data3.ToString();
                        dr.Cells["nouseable"].Value = (item.NoUseable > 0);
                        dr.Cells["remark"].Value = item.Remark;
                    });
            }
        }

        private void sisurproject_Searching(object sender, EventArgs e)
        {
            var pid = Lib.ToInt(sisurproject.RealValue);
            var tx = sisurproject.EditText;
            var project = new Views.FormSelect().SelectProject(tx);
            if (project != null && pid != project.ProjectId)
            {
                if (sisurproject.RealValue != (object)project.ProjectId)
                {
                    sisurtarget.Clear();
                }
                sisurproject.DisplayValue = project.ProjectName;
                sisurproject.RealValue = project.ProjectId;
                sisurproject.Tag = project;
                TryGetPoints();
            }
        }

        private void sisurtarget_Searching(object sender, EventArgs e)
        {
            var pid = Lib.ToInt(sisurproject.RealValue);
            var tid = Lib.ToInt(sisurtarget.RealValue);
            if (pid <= 0) return;
            var target = new Views.FormSelect().SelectTarget(pid, sisurtarget.EditText);
            if (target != null && target.TargetId != tid)
            {
                sisurtarget.DisplayValue = target.TargetName;
                sisurtarget.RealValue = target.TargetId;
                sisurtarget.Tag = target;
                TryGetPoints();
            }
        }

        private void TryGetPoints()
        {
            var pid = Lib.ToInt(sisurproject.RealValue);
            var tid = Lib.ToInt(sisurtarget.RealValue);
            if (pid <= 0 || tid <= 0) return;
            using (var db = Pub.GetConn())
            {
                var points = Dal.Instance.Points(pid, tid);
                surveyingInfo.SurveyingDetails = points.Select(x => new Models.SurveyingDetail()
                {
                    Data1 = 0,
                    Data2 = 0,
                    Data3 = 0,
                    Data4 = 0,
                    Id = 0,
                    NoUseable = 0,
                    Point = x,
                    PointId = x.PointId,
                    Project = null,
                    ProjectId = pid,
                    Remark = "",
                    Surveying = null,
                    SurveyingId = surveyingInfo.SurveyingId,
                    Target = null,
                    TargetId = tid
                }).ToList();
                ShowTargetGrid();
            }
        }


        private void toolbtnsave_Click(object sender, EventArgs e)
        {
            griddata.EndEdit();
            surveyingInfo.SurveyingName = sisurtitle.EditText.Trim();
            surveyingInfo.ProjectId = Lib.ToInt(sisurproject.RealValue);
            surveyingInfo.TargetId = Lib.ToInt(sisurtarget.RealValue);
            surveyingInfo.SurveyingTime = dtpDate.Value;
            surveyingInfo.DataUnit = sidataunit.EditText.Trim();
            surveyingInfo.DayWeather = siweather.EditText.Trim();
            surveyingInfo.SurveyingMan = siman.EditText.Trim();
            surveyingInfo.Remark = sisurremark.EditText.Trim();
            surveyingInfo.SurveyingDetails = new List<Models.SurveyingDetail>();
            for (var k = 0; k < griddata.Rows.Count; k++)
            {
                var row = griddata.Rows[k];
                var item = new Models.SurveyingDetail()
                {
                    Data1 = Lib.ToDecimal(row.Cells["data1"].Value),
                    Data2 = Lib.ToDecimal(row.Cells["data2"].Value),
                    Data3 = Lib.ToDecimal(row.Cells["data3"].Value),
                    Data4 = 0,
                    NoUseable = Lib.ToBool(row.Cells["nouseable"].Value) ? 1 : 0,
                    PointId = Lib.ToInt(row.Cells["pointid"].Value),
                    ProjectId = surveyingInfo.ProjectId,
                    Id = 0,
                    Point = null,
                    Project = null,
                    Remark = Lib.ToStr(row.Cells["remark"].Value),
                    Surveying = null,
                    SurveyingId = surveyingInfo.SurveyingId,
                    Target = null,
                    TargetId = surveyingInfo.TargetId
                };
                surveyingInfo.SurveyingDetails.Add(item);
            }

            if (string.IsNullOrWhiteSpace(surveyingInfo.SurveyingName))
            {
                MsgHelper.ShowInfo("测量名称不能为空!");
                return;
            }
            if (surveyingInfo.ProjectId <= 0)
            {
                MsgHelper.ShowInfo("请选择测量所属项目!");
                return;
            }
            if (surveyingInfo.ProjectId <= 0)
            {
                MsgHelper.ShowInfo("请选择测量所属测量对象!");
                return;
            }
            bool isadd = true;
            using (var db = Pub.GetConn())
            {
                db.BeginTransaction();
                try
                {
                    if (surveyingInfo.SurveyingId > 0)
                    {
                        Dal.Instance.UpdateSurveying(surveyingInfo);
                        Dal.Instance.DeleteSurvingDetails(surveyingInfo.SurveyingId);
                        foreach (var a in surveyingInfo.SurveyingDetails)
                        {
                            Dal.Instance.AddSurveyingDetail(a);
                        }
                        isadd = false;
                    }
                    else
                    {
                        Dal.Instance.AddSurveying(surveyingInfo);
                        foreach (var a in surveyingInfo.SurveyingDetails)
                        {
                            a.SurveyingId = surveyingInfo.SurveyingId;
                            Dal.Instance.AddSurveyingDetail(a);
                        }
                    }
                    db.Commit();
                }
                catch (Exception ex)
                {
                    db.Rollback();
                    throw;
                }
                ShowDetail(surveyingInfo.SurveyingId);
                if (isadd)
                {
                    MsgHelper.ShowInfo("添加成功");
                }
                else
                {
                    MsgHelper.ShowInfo("修改成功");
                }
            }

        }

        private void btnreedit_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            surveyingInfo.SurveyingDetails = new List<Models.SurveyingDetail>();
            TryGetPoints();
        }

        private void btnautotitle_Click(object sender, EventArgs e)
        {
            string tmp = "{0}{1} {2}测量记录";
            var title = string.Format(tmp, sisurproject.DisplayValue, sisurtarget.DisplayValue, dtpDate.Value.ToString("yyyy年MM月dd日"));
            sisurtitle.DisplayValue = title;
        }
    }
}
