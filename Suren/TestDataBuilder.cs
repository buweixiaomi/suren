using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Suren
{
    public class TestDataBuilder
    {
        List<Models.Project> projects = new List<Models.Project>();
        public void Start()
        {
            using (var dbconn = Pub.GetConn())
            {
                Trunctable(dbconn);
                BaseData(3, 5, 8);
                SurvingData(6, 15);
            }
        }


        private void Trunctable(RLib.DB.DbConn dbconn)
        {
            string sql = @"
                TRUNCATE `points`;
                TRUNCATE `projects`;
                TRUNCATE `surdatagen`;
                TRUNCATE `surveyingdetails`;
                TRUNCATE `surveyings`;
                TRUNCATE `targets`;";
            dbconn.ExecuteSql(sql);
        }

        private void BaseData(int procount, int tarcount, int pocount)
        {
            var pronames = new List<string>() { "人民大学工程-",
                "京东政府大楼-",
                "河田希望小学-" };

            var tarnames = new List<string>() { "主楼-",
                "公寓-",
                "后勤设施-" };

            for (var k = 0; k < procount; k++)
            {
                Models.Project project = new Models.Project()
                {
                    ProjectId = 0,
                    ProjectName = pronames[BNo(0, pronames.Count)] + (k + 1).ToString(),
                    Remark = "",
                    Status = 0
                };
                Dal.Instance.AddProject(project);
                projects.Add(project);
                project.Targets = new List<Models.Target>();
                for (var k2 = 0; k2 < tarcount; k2++)
                {
                    Models.Target target = new Models.Target()
                    {
                        ProjectId = project.ProjectId,
                        Remark = "",
                        Status = 0,
                        TargetId = 0,
                        TargetName = tarnames[BNo(0, tarnames.Count)] + (k2 + 1).ToString()
                    };
                    Dal.Instance.AddTarget(target);
                    project.Targets.Add(target);
                    target.Points = new List<Models.Point>();
                    for (var k3 = 0; k3 < tarcount; k3++)
                    {
                        Models.Point point = new Models.Point()
                        {
                            ProjectId = project.ProjectId,
                            Remark = "",
                            Status = 0,
                            TargetId = target.TargetId,
                            PointId = 0,
                            PointName = "P-" + (k3 + 1).ToString()
                        };
                        Dal.Instance.AddPoint(point);
                        target.Points.Add(point);
                    }
                }
            }
        }

        private void SurvingData(int surtimes1, int surtimes2)
        {
            var weathers = new List<string>() { "晴", "阴", "多云", "小雨", "雪" };
            var mans = new List<string>() { "张三", "李四", "王五", "赵六", "周某某" };
            foreach (var p in projects)
            {
                foreach (var tr in p.Targets)
                {
                    var tms = BNo(surtimes1, surtimes2);
                    for (var mt = 0; mt < tms; mt++)
                    {
                        var surving = new Models.Surveying()
                        {
                            DataUnit = "mm",
                            DayWeather = weathers[BNo(0, weathers.Count)],
                            ProjectId = p.ProjectId,
                            Project = null,
                            Remark = "",
                            Status = 0,
                            SurveyingDetails = null,
                            SurveyingId = 0,
                            SurveyingMan = mans[BNo(0, mans.Count)],
                            SurveyingName = p.ProjectName + "" + tr.TargetName + "第" + mt + "次测量",
                            SurveyingTime = DateTime.Now.AddDays(-mt * 10),
                            TargetId = tr.TargetId,
                            Target = null
                        };
                        Dal.Instance.AddSurveying(surving);
                        foreach (var po in tr.Points)
                        {
                            var pointdata = new Models.SurveyingDetail()
                            {
                                Data1 = BNo(10000, 99999) / 1000.0m,
                                Data2 = BNo(10000, 99999) / 1000.0m,
                                Data3 = BNo(10000, 99999) / 1000.0m,
                                Data4 = 0m,
                                Id = 0,
                                NoUseable = BNo(0, 20) == 1 ? 1 : 0,
                                Point = null,
                                PointId = po.PointId,
                                PointName = po.PointName,
                                Project = null,
                                ProjectId = p.ProjectId,
                                ProjectName = p.ProjectName,
                                Remark = "",
                                Surveying = null,
                                SurveyingId = surving.SurveyingId,
                                SurveyingName = surving.SurveyingName,
                                SurveyingTime = surving.SurveyingTime,
                                Target = null,
                                TargetId = tr.TargetId,
                                TargetName = tr.TargetName
                            };
                            if (pointdata.NoUseable > 0)
                                pointdata.Remark = "被遮挡";
                            Dal.Instance.AddSurveyingDetail(pointdata);
                        }
                    }
                }
            }
        }

        private int BNo(int f, int t)
        {
            Random random = new Random();
            return random.Next(f, t);
        }
    }
}
