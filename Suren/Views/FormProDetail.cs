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
    public partial class FormProDetail : FormView
    {
        public FormProDetail()
        {
            InitializeComponent();
        }



        Models.Project projectInfo;

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
            this.TabText = "新增项目";
            this.Text = this.TabText;
            projectInfo = new Models.Project();
            ShowInUI();
        }
        private void ShowDetail(int projectid)
        {
            using (var db = Pub.GetConn())
            {
                projectInfo = Dal.Instance.ProjectDetail(projectid);
                if (projectInfo == null)
                {
                    MsgHelper.ShowWarning("提示", "项目不存在！");
                    New();
                    return;
                }
                ShowInUI();
            }
        }

        private void ShowInUI()
        {
            siprojectid.DisplayValue = projectInfo.ProjectId.ToString();
            siprojectname.DisplayValue = projectInfo.ProjectName;
            siprojectremark.DisplayValue = projectInfo.Remark;
            ShowTargetGrid();
        }

        Models.Target lastSelectTarget = null;
        private void ShowTargetGrid()
        {
            gridpoint.Rows.Clear();
            gridtarget.Rows.Clear();

            if (projectInfo.Targets == null)
            {
                projectInfo.Targets = new List<Models.Target>();
            }
            if (projectInfo.Targets != null)
            {
                Pub.FillGrid<Models.Target>(gridtarget, null, projectInfo.Targets.Where(x => x.Status == 0).ToList(), (dr, item) =>
                    {
                        dr.Tag = item;
                        dr.Cells["targetid"].Value = item.TargetId;
                        dr.Cells["targetname"].Value = item.TargetName;
                        dr.Cells["targetremark"].Value = item.Remark;
                    });
            }
            gridtarget.Rows.Add();
            gridtarget.CurrentCell = null;
            lastSelectTarget = null;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            gridtarget.Rows.Add();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (gridtarget.CurrentCell == null) return;
            var tid = Lib.ToInt(gridtarget.Rows[gridtarget.CurrentCell.RowIndex].Cells["targetid"].Value);
            if (tid > 0 && !MsgHelper.Comfirm("确认", "你确定要删除吗？"))
                return;
            gridtarget.Rows.RemoveAt(gridtarget.CurrentCell.RowIndex);
            if (tid > 0)
            {
                projectInfo.Targets.FirstOrDefault(x => x.TargetId == tid).Status = -1;
            }
            else
            {
                projectInfo.Targets.RemoveAll(x => x.TargetId == tid);
            }
        }

        private void gridtarget_CurrentCellChanged(object sender, EventArgs e)
        {
            if (gridtarget.CurrentCell == null)
            {
                lastSelectTarget = null;
                ShowPointGrid();
                return;
            }
            if (lastSelectTarget == null)
            {
                if (gridtarget.Rows[gridtarget.CurrentCell.RowIndex].Tag != null)
                {
                    lastSelectTarget = gridtarget.Rows[gridtarget.CurrentCell.RowIndex].Tag as Models.Target;
                    ShowPointGrid();
                }
                return;
            }
            if (gridtarget.Rows[gridtarget.CurrentCell.RowIndex].Tag == lastSelectTarget)
            {
                return;
            }
            else
            {
                lastSelectTarget.Points = GetRightPoints();
                lastSelectTarget = gridtarget.Rows[gridtarget.CurrentCell.RowIndex].Tag as Models.Target;
                ShowPointGrid();
            }
        }

        private void ShowPointGrid()
        {
            Models.Target target = lastSelectTarget;
            gridpoint.Rows.Clear();
            if (lastSelectTarget == null) return;
            if (target.Points == null)
            {
                target.Points = new List<Models.Point>();
            }
            Pub.FillGrid<Models.Point>(gridpoint, null, target.Points.Where(x => x.Status == 0).ToList(), (dr, item) =>
                {
                    dr.Cells["pointid"].Value = item.PointId;
                    dr.Cells["pointname"].Value = item.PointName;
                    dr.Cells["pointremark"].Value = item.Remark;
                });
            gridpoint.Rows.Add();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            gridtarget.EndEdit();
            if (lastSelectTarget == null) return;
            gridpoint.Rows.Add();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            gridtarget.EndEdit();
            if (gridpoint.CurrentCell == null) return;
            var pid = Lib.ToInt(gridpoint.Rows[gridpoint.CurrentCell.RowIndex].Cells["pointid"].Value);
            if (pid > 0 && !MsgHelper.Comfirm("确认", "你确定要删除吗？"))
                return;
            gridpoint.Rows.RemoveAt(gridpoint.CurrentCell.RowIndex);
        }

        private void gridtarget_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = gridtarget.Rows[e.RowIndex];
            if (row.Tag != null) return;


            var targetid = Lib.ToInt(row.Cells["targetid"].Value);
            var targetname = Lib.ToStr(row.Cells["targetname"].Value).Trim();
            var targetremark = Lib.ToStr(row.Cells["targetremark"].Value);
            if (string.IsNullOrWhiteSpace(targetname)) return;
            var ntarget = new Models.Target()
            {
                TargetId = 0,
                TargetName = targetname,
                Remark = targetremark,
                Status = 0,
                Points = new List<Models.Point>()
            };
            row.Cells["targetid"].Value = 0;
            row.Tag = ntarget;
            if (gridtarget.CurrentCell != null)
            {
                lastSelectTarget = gridtarget.Rows[gridtarget.CurrentCell.RowIndex].Tag as Models.Target;
                ShowPointGrid();
            }
        }

        private void gridpoint_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            return;
            if (gridtarget.CurrentCell == null)
            {
                MsgHelper.ShowInfo("请选择测量对象！");
                return;
            }
            if (lastSelectTarget == null)
            {
                var r = gridtarget.CurrentCell.RowIndex;
                var targetid = Lib.ToInt(gridtarget.Rows[r].Cells["targetid"].Value);
                var targetname = Lib.ToStr(gridtarget.Rows[r].Cells["targetname"].Value);
                var targetremark = Lib.ToStr(gridtarget.Rows[r].Cells["targetremark"].Value);
                if (targetid != 0)
                {
                    MsgHelper.ShowWarning("提示", "错误！");
                    return;
                }
                var nt = new Models.Target()
                {
                    TargetId = -1,
                    Status = 0,
                    Remark = targetremark,
                    TargetName = targetname,
                    Points = new List<Models.Point>()
                };
                gridtarget.Rows[r].Tag = nt;
                if (projectInfo.Targets == null)
                    projectInfo.Targets = new List<Models.Target>();
                projectInfo.Targets.Add(nt);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            gridpoint.EndEdit();
            gridtarget.EndEdit();
            gridtarget.CurrentCell = null;
            gridpoint.CurrentCell = null;

            projectInfo.ProjectName = siprojectname.DisplayValue;
            projectInfo.Remark = siprojectremark.DisplayValue;
            if (string.IsNullOrWhiteSpace(projectInfo.ProjectName))
            {
                MsgHelper.ShowInfo("项目名称不能为空！");
                return;
            }
            projectInfo.Targets = GetLeftTargets();
            int i = 0;
            foreach (var a in projectInfo.Targets)
            {
                i++;
                if (string.IsNullOrWhiteSpace(a.TargetName))
                {
                    MsgHelper.ShowInfo("第" + i + "个测量对象名称不能为空");
                    return;
                }
                if (a.Points == null) a.Points = new List<Models.Point>();
                int k = 0;
                foreach (var p in a.Points)
                {
                    k++;
                    if (string.IsNullOrWhiteSpace(p.PointName))
                    {
                        MsgHelper.ShowInfo("第" + i + "个测量对象的 第" + k + "个测量点名称不能为空");
                        return;
                    }
                }
            }
            using (var db = Pub.GetConn())
            {
                db.BeginTransaction();
                try
                {
                    if (projectInfo.ProjectId <= 0)
                    {
                        Dal.Instance.AddProject(projectInfo);
                        foreach (var a in projectInfo.Targets)
                        {
                            a.ProjectId = projectInfo.ProjectId;
                            Dal.Instance.AddTarget(a);
                            foreach (var p in a.Points)
                            {
                                p.ProjectId = projectInfo.ProjectId;
                                p.TargetId = a.TargetId;
                                Dal.Instance.AddPoint(p);
                            }
                        }
                    }
                    else
                    {
                        var oldinfo = Dal.Instance.ProjectDetail(projectInfo.ProjectId);
                        Dal.Instance.UpdateProject(projectInfo);
                        //删除target
                        foreach (var a in oldinfo.Targets.Where(x => !projectInfo.Targets.Exists(y => y.TargetId == x.TargetId)))
                        {
                            a.Status = -1;
                            Dal.Instance.DeleteTarget(a.TargetId);
                        }
                        foreach (var a in projectInfo.Targets)
                        {
                            a.ProjectId = projectInfo.ProjectId;
                            if (a.TargetId <= 0)
                            {
                                Dal.Instance.AddTarget(a);
                                foreach (var p in a.Points)
                                {
                                    p.ProjectId = projectInfo.ProjectId;
                                    p.TargetId = a.TargetId;
                                    Dal.Instance.AddPoint(p);
                                }
                            }
                            else
                            {
                                Dal.Instance.UpdateTarget(a);
                                var oldpoints = Dal.Instance.Points(a.ProjectId, a.TargetId);
                                //删除point
                                foreach (var dp in oldpoints.Where(x => !a.Points.Exists(y => y.PointId == x.PointId)))
                                {
                                    dp.Status = -1;
                                    Dal.Instance.DeletePoint(dp.PointId);
                                }
                                foreach (var p in a.Points)
                                {
                                    p.ProjectId = projectInfo.ProjectId;
                                    p.TargetId = a.TargetId;
                                    if (p.PointId <= 0)
                                    {
                                        Dal.Instance.AddPoint(p);
                                    }
                                    else
                                    {
                                        Dal.Instance.UpdatePoint(p);
                                    }
                                }

                            }
                        }
                    }
                    db.Commit();
                }
                catch (Exception ex)
                {
                    db.Rollback();
                    throw;
                }

                ShowDetail(projectInfo.ProjectId);
            }
        }

        private void gridpoint_KeyDown(object sender, KeyEventArgs e)
        {

            if (gridpoint.CurrentCell == null) return;
            if (e.KeyCode != Keys.Enter) return;
            if (gridpoint.CurrentCell.ColumnIndex == gridpoint.ColumnCount - 1)
            {
                if (gridpoint.CurrentCell.RowIndex == gridpoint.RowCount - 1)
                {
                    gridpoint.Rows.Add();
                    gridpoint.CurrentCell = gridpoint.Rows[gridpoint.Rows.Count - 1].Cells[0];
                }
                else
                {
                    gridpoint.CurrentCell = gridpoint.Rows[gridpoint.CurrentCell.RowIndex + 1].Cells[0];
                }
            }
            else
            {
                gridpoint.CurrentCell = gridpoint.Rows[gridpoint.CurrentCell.RowIndex].Cells[gridpoint.CurrentCell.ColumnIndex + 1];
            }
        }

        private List<Models.Point> GetRightPoints()
        {
            gridpoint.EndEdit();
            var points = new List<Models.Point>();
            for (var k = 0; k < gridpoint.Rows.Count; k++)
            {
                var row = gridpoint.Rows[k];
                var item = new Models.Point()
                {
                    PointId = Lib.ToInt(row.Cells["pointid"].Value),
                    PointName = Lib.ToStr(row.Cells["pointname"].Value),
                    Remark = Lib.ToStr(row.Cells["pointremark"].Value)
                };
                if (item.PointId <= 0 && string.IsNullOrWhiteSpace(item.PointName) && string.IsNullOrWhiteSpace(item.Remark))
                {
                    continue;
                }
                points.Add(item);
            }
            return points;
        }


        private List<Models.Target> GetLeftTargets()
        {
            gridtarget.EndEdit();
            gridtarget.CurrentCell = null;
            var targets = new List<Models.Target>();
            for (var k = 0; k < gridtarget.Rows.Count; k++)
            {
                var row = gridtarget.Rows[k];
                if (row.Tag == null) continue;
                targets.Add(row.Tag as Models.Target);
            }
            return targets;
        }
        private void gridtarget_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridtarget.CurrentCell == null) return;
            if (e.KeyCode != Keys.Enter) return;
            if (gridtarget.CurrentCell.ColumnIndex == gridtarget.ColumnCount - 1)
            {
                if (gridtarget.CurrentCell.RowIndex == gridtarget.RowCount - 1)
                {
                    gridtarget.Rows.Add();
                    gridtarget.CurrentCell = gridtarget.Rows[gridtarget.Rows.Count - 1].Cells[0];
                }
                else
                {
                    gridtarget.CurrentCell = gridtarget.Rows[gridtarget.CurrentCell.RowIndex + 1].Cells[0];
                }
            }
            else
            {
                gridtarget.CurrentCell = gridtarget.Rows[gridtarget.CurrentCell.RowIndex].Cells[gridtarget.CurrentCell.ColumnIndex + 1];
            }
        }
    }
}
