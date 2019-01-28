using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace Suren
{
    public class RenDataBuilder
    {
        private int projectId;
        Models.Project mProject;
        SurenTmpl mTmpl;
        public RenDataBuilder(int projectid, SurenTmpl tmpl)
        {
            this.projectId = projectid;
            mTmpl = tmpl;
        }

        public void Start()
        {
            Prepare();
            Build();
        }

        private void Prepare()
        {
            using (var dbconn = Pub.GetConn())
            {
                mProject = Dal.Instance.ProjectDetail(projectId);
            }
        }

        private void Build()
        {
            using (var dbconn = Pub.GetConn())
            {
                dbconn.BeginTransaction();
                try
                {
                    Dal.Instance.DeleteProGenData(projectId);
                    foreach (var a in mProject.Targets)
                    {
                        GenOne(a.ProjectId, a.TargetId);
                    }
                    dbconn.Commit();
                }
                catch (Exception ex)
                {
                    dbconn.Rollback();
                    throw;
                }
            }
        }

        private void GenOne(int projectid, int targetid)
        {
            List<Models.SurDataGen> gns = new List<Models.SurDataGen>();
            var points = Dal.Instance.Points(projectid, targetid);
            var svings = Dal.Instance.GetTargetSurveyings(projectid, targetid);

            Dictionary<int, Models.SurveyingDetail> lastmap = new Dictionary<int, Models.SurveyingDetail>();
            int index = 0;
            foreach (var sv in svings)
            {
                index++;
                var details = Dal.Instance.SurveyingDetails(sv.SurveyingId);
                var currmap = ToMap(details);
                foreach (var p in points)
                {
                    var lsdetail = lastmap.ContainsKey(p.PointId) ? lastmap[p.PointId] : null;
                    var sdetail = currmap.ContainsKey(p.PointId) ? currmap[p.PointId] : null;
                    var gitem = new Models.SurDataGen();
                    gitem.ProjectId = p.ProjectId;
                    gitem.TargetId = p.TargetId;
                    gitem.PointId = p.PointId;
                    gitem.SurveyingId = sv.SurveyingId;
                    gitem.SurveyingTime = sv.SurveyingTime;
                    Dictionary<string, double?> para = new Dictionary<string, double?>();
                    para.Add("@data1", sdetail.NoUseable > 0 ? new Nullable<double>() : (double)sdetail.Data1);
                    para.Add("@data2", sdetail.NoUseable > 0 ? new Nullable<double>() : (double)sdetail.Data2);
                    para.Add("@data3", sdetail.NoUseable > 0 ? new Nullable<double>() : (double)sdetail.Data3);
                    if (lsdetail == null)
                    {
                        para.Add("@ldata1", null);
                        para.Add("@ldata2", null);
                        para.Add("@ldata3", null);
                    }
                    else
                    {
                        para.Add("@ldata1", lsdetail.NoUseable > 0 ? new Nullable<double>() : (double)lsdetail.Data1);
                        para.Add("@ldata2", lsdetail.NoUseable > 0 ? new Nullable<double>() : (double)lsdetail.Data2);
                        para.Add("@ldata3", lsdetail.NoUseable > 0 ? new Nullable<double>() : (double)lsdetail.Data3);
                    }
                    var he = HExpression.Parse(mTmpl.DataExpression);
                    if (he == null)
                    {
                        gitem.Data1 = null;
                    }
                    else
                    {
                        var dv = he.Execute(para);
                        if (dv == null)
                            gitem.Data1 = null;
                        else
                            gitem.Data1 = (decimal)dv;
                    }
                    if (index == 1 && gitem.Data1 == null)
                        gitem.Data1 = 0;
                    gns.Add(gitem);
                    if (sdetail != null && sdetail.NoUseable == 0)
                    {
                        lastmap[p.PointId] = sdetail;
                    }
                }
            }

            foreach (var a in gns)
                Dal.Instance.InsertGenData(a);
        }

        private Dictionary<int, Models.SurveyingDetail> ToMap(List<Models.SurveyingDetail> details)
        {
            var map = new Dictionary<int, Models.SurveyingDetail>();
            foreach (var a in details)
            {
                map[a.PointId] = a;
            }
            return map;
        }

        public static DataTable BuildGenTable(int projectid, int targetid, List<Models.SurDataGen> datas, SurenTmpl tmpl)
        {
            Dictionary<int, DateTime> stimes = new Dictionary<int, DateTime>();
            Dictionary<int, string> ptitles = new Dictionary<int, string>();
            using (var dbconn = Pub.GetConn())
            {
                foreach (var p in Dal.Instance.Points(projectid, targetid))
                {
                    ptitles[p.PointId] = p.PointName;
                }

                foreach (var a in Dal.Instance.GetTargetSurveyings(projectid, targetid).OrderBy(x => x.SurveyingTime))
                {
                    stimes[a.SurveyingId] = a.SurveyingTime;
                }
            }
            DataTable tb = new DataTable();
            DataColumn column = new DataColumn();
            column.ColumnName = column.Caption = "测量点";
            tb.Columns.Add(column);
            foreach (var c in stimes)
            {
                DataColumn dc = new DataColumn();
                dc.ColumnName = dc.Caption = c.Value.ToString("MM月dd日");
                tb.Columns.Add(dc);
            }
            foreach (var a in datas.GroupBy(x => x.PointId))
            {
                if (!ptitles.ContainsKey(a.Key)) continue;
                var row = tb.NewRow();
                row[0] = ptitles[a.Key];
                var sds = a.ToList();
                int cindex = 0;
                foreach (var t in stimes)
                {
                    cindex++;
                    var it = a.FirstOrDefault(x => x.SurveyingId == t.Key);
                    if (it == null)
                    {
                        row[cindex] = "";
                    }
                    else if (it.Data1 == null)
                    {
                        row[cindex] = "";
                    }
                    else
                    {
                        if (tmpl != null && !string.IsNullOrWhiteSpace(tmpl.ChartDataFormat))
                        {
                            row[cindex] = it.Data1.Value.ToString(tmpl.ChartDataFormat.Trim());
                        }
                        else
                        {
                            row[cindex] = it.Data1.Value.ToString();
                        }
                    }
                }
                tb.Rows.Add(row);
            }
            return tb;
        }


        public static Dictionary<Models.Point, List<Models.SurDataGen>> BuildChartData
            (int projectid, int targetid, List<Models.SurDataGen> datas)
        {
            var rdata = new Dictionary<Models.Point, List<Models.SurDataGen>>();
            Dictionary<int, DateTime> stimes = new Dictionary<int, DateTime>();
            Dictionary<int, Models.Point> ptitles = new Dictionary<int, Models.Point>();
            using (var dbconn = Pub.GetConn())
            {
                foreach (var p in Dal.Instance.Points(projectid, targetid))
                {
                    rdata[p] = new List<Models.SurDataGen>();
                    ptitles[p.PointId] = p;
                }

                foreach (var a in Dal.Instance.GetTargetSurveyings(projectid, targetid).OrderBy(x => x.SurveyingTime))
                {
                    stimes[a.SurveyingId] = a.SurveyingTime;
                }
            }
            foreach (var a in rdata)
            {
                a.Value.AddRange(datas.Where(x => x.Data1 != null && x.PointId == a.Key.PointId).OrderBy(x => x.SurveyingTime).ToList());
            }
            return rdata;
        }

        public static void BindToChart(string title, Chart chart, Dictionary<Models.Point, List<Models.SurDataGen>> pointsdata, float times)
        {
            chart.Series.Clear();
            chart.Legends.Clear();
            chart.Annotations.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();

            chart.Titles.Add(title ?? "时间变化曲线图");
            chart.Titles[0].Font = WordHelper.GetFont(WordHelper.NormalTitleSize * times);
            var Interval = 1;
            if (pointsdata.Count > 0 && pointsdata.First().Value.Count > 0)
            {
                Interval = (int)Math.Ceiling(pointsdata.First().Value.Count / 12.0);
            }

            var area = new ChartArea("mainarea");
            area.AlignmentStyle = AreaAlignmentStyles.All;
            area.AxisX.Interval = Interval;
            var xx = 255;
            area.AxisX.MajorGrid.LineColor = Color.Transparent;// Color.FromArgb(xx, xx, xx);
            area.AxisX.MinorGrid.LineColor = Color.Transparent;// Color.FromArgb(xx, xx, xx);
                                                               // area.AxisX2.MajorGrid.LineColor = Color.FromArgb(xx, xx, xx);
                                                               // area.AxisX2.MajorGrid.LineColor = Color.FromArgb(xx, xx, xx);
            var vy = 50;
            //area.AxisY.MajorGrid.LineColor = Color.FromArgb(vy, vy, vy);
            //area.AxisY.MinorGrid.LineColor = Color.FromArgb(vy, vy, vy);
            area.AxisY2.MajorGrid.LineColor = Color.FromArgb(vy, vy, vy);
            area.AxisY2.MajorGrid.LineColor = Color.FromArgb(vy, vy, vy);

            area.AxisX.LabelStyle.Font = WordHelper.GetFont(WordHelper.NormalTitleSize * times);
            area.AxisY.LabelStyle.Font = WordHelper.GetFont(WordHelper.NormalTitleSize * times);
            area.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont | LabelAutoFitStyles.StaggeredLabels;
            area.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont | LabelAutoFitStyles.StaggeredLabels;
            area.AxisY.IsLabelAutoFit = true;
            area.AxisX.IsLabelAutoFit = true;
            chart.ChartAreas.Add(area);
            var leg = new Legend("mainleg");
            leg.IsTextAutoFit = true;
            leg.IsDockedInsideChartArea = false;
            leg.Docking = Docking.Bottom;
            leg.DockedToChartArea = "mainarea";
            chart.Legends.Add(leg);
            chart.Legends[0].Font = WordHelper.GetFont(WordHelper.NormalTitleSize * times);
            List<MarkerStyle> mks = new List<MarkerStyle>();
            mks.Add(MarkerStyle.Circle);
            mks.Add(MarkerStyle.Star4);
            mks.Add(MarkerStyle.Cross);
            mks.Add(MarkerStyle.Triangle);
            mks.Add(MarkerStyle.Star5);
            mks.Add(MarkerStyle.Square);
            mks.Add(MarkerStyle.Star10);
            mks.Add(MarkerStyle.Diamond);
            mks.Add(MarkerStyle.Star6);
            int index = -1;
            foreach (var a in pointsdata)
            {
                index++;
                List<string> titles = new List<string>();
                List<decimal?> values = new List<decimal?>();
                foreach (var b in a.Value)
                {
                    titles.Add(b.SurveyingTime.ToString("yyyy/MM/dd"));
                    values.Add(b.Data1);
                }
                //if (a.Value.Count == 0) continue;
                var series = new Series("mainline" + a.Key.PointId);
                series.Font = WordHelper.GetFont(WordHelper.NormalTitleSize * times);
                series.LegendText = a.Key.PointName;
                series.ChartType = SeriesChartType.Line;
                series.ChartArea = "mainarea";
                series.Legend = "mainleg";
                series.BorderWidth = 2;
                // series.MarkerStep = 1;
                series.MarkerStyle = mks[index % mks.Count];
                series.XValueType = ChartValueType.DateTime;
                series.YValueType = ChartValueType.Double;
                series.IsValueShownAsLabel = false;
                series.XValueType = ChartValueType.String;
                series.Points.DataBindXY(titles, values);
                chart.Series.Add(series);
            }

        }
    }
}
