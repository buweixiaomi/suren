using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Suren
{
    public class Dal
    {
        public static readonly Dal Instance = new Dal();
        [ThreadStatic]
        public static RLib.DB.DbConn DbConn;
        private Dal() { }

        public void AddProject(Models.Project project)
        {
            string sql = "insert into `projects`(projectname,`remark`) values(@ProjectName,@Remark);";
            DbConn.ExecuteSql(sql, project);
            project.ProjectId = DbConn.GetIdentity();
        }
        public void UpdateProject(Models.Project project)
        {
            string sql = "update `projects` set projectname=@ProjectName,`remark`=@Remark where `projectid`=@ProjectId";
            DbConn.ExecuteSql(sql, project);
        }
        public void AddTarget(Models.Target target)
        {
            string sql = "insert into `targets`(`projectid`,`targetname`,`remark`) values(@ProjectId,@TargetName,@Remark);";
            DbConn.ExecuteSql(sql, target);
            target.TargetId = DbConn.GetIdentity();
        }
        public void UpdateTarget(Models.Target target)
        {
            string sql = "update `targets` set targetname=@TargetName,`remark`=@Remark where `targetid`=@TargetId";
            DbConn.ExecuteSql(sql, target);
        }

        public void AddPoint(Models.Point point)
        {
            string sql = "insert into `points`(`projectid`,`targetid`,`pointname`,`remark`) values(@ProjectId,@TargetId,@PointName,@Remark);";
            DbConn.ExecuteSql(sql, point);
            point.PointId = DbConn.GetIdentity();
        }

        public void AddSurveying(Models.Surveying surveying)
        {
            string sql = @"INSERT INTO `surveyings`
                (
                `SurveyingName`,
                `SurveyingTime`,
                `DayWeather`,
                `SurveyingMan`,
                `DataUnit`,
                `Remark`,
                `ProjectId`,
                `TargetId`,
                `Status`)
                VALUES
                (
                @SurveyingName,
                @SurveyingTime,
                @DayWeather,
                @SurveyingMan,
                @DataUnit,
                @Remark,
                @ProjectId,
                @TargetId,0);";
            DbConn.ExecuteSql(sql, surveying);
            surveying.SurveyingId = DbConn.GetIdentity();
        }

        public void AddSurveyingDetail(Models.SurveyingDetail surveyingdetail)
        {
            string sql = @"INSERT INTO `surveyingdetails`
            (
            `ProjectId`,
            `TargetId`,
            `SurveyingId`,
            `PointId`,
            `Data1`,
            `Data2`,
            `Data3`,
            `Data4`,
            `NoUseable`,
            `Remark`)
            VALUES
            (
            @ProjectId,
            @TargetId,
            @SurveyingId,
            @PointId,
            @Data1,
            @Data2,
            @Data3,
            @Data4,
            @NoUseable,
            @Remark);
            ";
            DbConn.ExecuteSql(sql, surveyingdetail);
            surveyingdetail.Id = DbConn.GetIdentity();
        }

        public void DeleteSurvingDetails(int surveyingid)
        {
            string sql = "delete from `surveyingdetails` where `surveyingid`=@surveyingid";
            DbConn.ExecuteSql(sql, new { surveyingid });
        }

        public void UpdateSurveying(Models.Surveying surveying)
        {
            string sql = @"UPDATE `surveyings`
SET
`SurveyingName` = @SurveyingName,
`SurveyingTime` = @SurveyingTime,
`DayWeather` = @DayWeather,
`SurveyingMan` = @SurveyingMan,
`DataUnit` = @DataUnit,
`Remark` = @Remark,
`ProjectId` = @ProjectId,
`TargetId` = @TargetId
WHERE `SurveyingId` = @SurveyingId ;";
            DbConn.ExecuteSql(sql, surveying);
        }


        public List<Models.Surveying> GetTargetSurveyings(int projectid, int targetid)
        {
            string sql = "select * from `surveyings` sy " +
                " where `projectid`=@projectid and `targetid`=@targetid" +
                " order by sy.SurveyingTime asc; ";
            var para = new { targetid = targetid, projectid = projectid };
            var models = DbConn.Query<Models.Surveying>(sql, para);
            return models;
        }

        internal Models.PagedList<Models.Surveying> SurveyingPage(int projectid, int pno, int pagesize, string keywords = "")
        {
            var para = new { kw = keywords ?? "", projectid = projectid };
            string wheresql = " where sy.`status`=0 ";
            if (projectid > 0)
            {
                wheresql += " and sy.`projectid`=@projectid ";
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                wheresql += " and sy.`surveyingname` like concat('%',@kw,'%')  ";
            }
            string sqlcount = "select count(1) from `surveyings`  sy  " + wheresql;
            string sqlquery = "select sy.*,pr.`projectName`,ta.`targetName` from `surveyings`  sy " +
                " left join `projects` pr on sy.projectid=pr.projectid " +
                " left join `targets` ta on sy.targetid=ta.targetid " +
                "" + wheresql + "  order by sy.`surveyingid` desc";
            var count = DbConn.ExecuteScalar<int>(sqlcount, para);
            var psql = BuildPSql(sqlquery, pno, pagesize);
            var models = DbConn.Query<Models.Surveying, Models.Target, Models.Project>(psql, para);
            foreach (var m in models)
            {
                m.Item1.Project = m.Item3;
                m.Item1.Target = m.Item2;
            }
            return new Models.PagedList<Models.Surveying>(models.Select(x => x.Item1).ToList()).SetPageInfo(pno, pagesize, count);
        }

        public void UpdatePoint(Models.Point point)
        {
            string sql = "update `points` set pointname=@PointName,`remark`=@Remark where `pointid`=@PointId";
            DbConn.ExecuteSql(sql, point);
        }

        private string BuildPSql(string sql, int pno, int pagesize)
        {
            string tmp = "{0} limit {1},{2};";
            return string.Format(tmp, sql, (pno - 1) * pagesize, pagesize);
        }

        public Models.PagedList<Models.Project> PageProject(int pno, int pagesize, string keywords = "")
        {
            var para = new { kw = keywords ?? "" };
            var count = DbConn.ExecuteScalar<int>("select count(1) from `projects` where `status`=0 and `projectname` like concat('%',@kw,'%') ", para);
            var psql = BuildPSql("select * from `projects`  where `status`=0  and `projectname` like concat('%',@kw,'%')  order by `projectid` desc", pno, pagesize);
            var models = DbConn.Query<Models.Project>(psql, para);
            return new Models.PagedList<Models.Project>(models).SetPageInfo(pno, pagesize, count);
        }

        public List<Models.Target> Targets(int projectid, string keywords = "")
        {
            var para = new { pid = projectid, kw = keywords ?? "" };
            var psql = "select * from `targets` where `projectid`=@pid " +
                " and `status`=0 and `targetname` like concat('%',@kw,'%')  " +
                " order by `targetid` asc;";
            var models = DbConn.Query<Models.Target>(psql, para);
            return models;
        }
        public List<Models.Point> Points(int projectid, int targetid, string keywords = "")
        {
            var para = new { pid = projectid, tid = targetid, kw = keywords ?? "" };
            var psql = "select * from `points` where `projectid`=@pid " +
                " and `targetid`=@tid and `status`=0 " +
                " and `pointname` like concat('%',@kw,'%')  " +
                "order by `pointid` asc;";
            var models = DbConn.Query<Models.Point>(psql, para);
            return models;
        }


        public Models.Project ProjectDetail(int projectid)
        {
            var model = DbConn.Query<Models.Project>("select * from `projects` where projectid=@projectid",
                new { projectid = projectid })
                .FirstOrDefault();
            if (model == null) return null;
            model.Targets = Targets(projectid);
            foreach (var a in model.Targets)
            {
                a.Points = Points(a.ProjectId, a.TargetId);
            }
            return model;
        }


        public Models.Surveying SurveyingDetail(int surveyingid)
        {
            var sql = "select sy.*,pr.projectName,ta.targetName from `surveyings` sy" +
                " left join  `projects` pr on sy.projectId=pr.projectId " +
                " left join  `targets` ta on sy.targetid=ta.targetid " +
                " where sy.surveyingid=@surveyingid";
            var model = DbConn.Query<Models.Surveying, Models.Project, Models.Target>(sql,
                new { surveyingid = surveyingid })
                .FirstOrDefault();
            if (model == null) return null;
            model.Item1.Project = model.Item2;
            model.Item1.Target = model.Item3;
            model.Item1.SurveyingDetails = SurveyingDetails(surveyingid);
            return model.Item1;
        }

        public List<Models.SurveyingDetail> SurveyingDetails(int surveyingid)
        {
            string sql = "select sd.*,p.pointName from `surveyingdetails` sd " +
                " left join `points` p on sd.pointid=p.pointid " +
                "where sd.`surveyingid`=@surveyingid order by sd.`pointid` asc;";
            var model = DbConn.Query<Models.SurveyingDetail, Models.Point>(sql, new { surveyingid = surveyingid });
            foreach (var a in model)
                a.Item1.Point = a.Item2;
            return model.Select(x => x.Item1).ToList();
        }

        public Models.PagedList<Models.SurveyingDetail> QuerySurveyingDetails(int pno, int pagesize,
            int projectid = 0, int targetid = 0, int surveyingid = 0)
        {
            string fields = "sd.*,p.pointName,t.targetName,pt.projectName," +
                " sy.SurveyingName,sy.SurveyingTime ";
            string sql =
                " from `surveyingdetails` sd " +
                "  join `points` p on sd.pointid=p.pointid " +
                "  join `targets` t on sd.targetid=t.targetid " +
                "  join `projects` pt on sd.projectid=pt.projectid " +
                "  join `surveyings` sy on sd.SurveyingId=sy.SurveyingId " +
                " ";
            var whe = " where  p.`status`=0 and t.`status`=0 and pt.`status`=0 and sy.`status`=0  ";
            if (projectid > 0)
                whe += " and sd.projectid=@projectid ";
            if (targetid > 0)
                whe += " and sd.targetid=@targetid ";
            if (surveyingid > 0)
                whe += " and sd.surveyingid=@surveyingid ";
            var orderbysql = " order by sd.`pointid` asc ";
            var pagesql = BuildPSql("select " + fields + sql + whe + orderbysql, pno, pagesize);
            var para = new
            {
                projectid = projectid,
                targetid = targetid,
                surveyingid = surveyingid
            };
            var model = DbConn.Query<Models.SurveyingDetail>(pagesql, para);
            var total = DbConn.ExecuteScalar<int>("select count(1) " + sql + whe, para);
            var pmodel = new Models.PagedList<Models.SurveyingDetail>(model);
            pmodel.SetPageInfo(pno, pagesize, total);
            return pmodel;
        }


        private void DeleteModel(string tname, string field, int id)
        {
            string sql = "update `{0}` set `status`=-1 where `{1}`=@id;";
            sql = string.Format(sql, tname, field, id);
            DbConn.ExecuteSql(sql, new { id = id });
        }

        public void DeleteProject(int id)
        {
            DeleteModel("projects", "projectid", id);
        }
        public void DeleteTarget(int id)
        {
            DeleteModel("targets", "targetid", id);
        }
        public void DeletePoint(int id)
        {
            DeleteModel("points", "pointid", id);
        }

        public void InsertGenData(Models.SurDataGen gen)
        {
            string sql = @"INSERT INTO `surdatagen`(`ProjectId`,`TargetId`,`PointId`,`SurveyingId`,`SurveyingTime`,`Data1`)
                VALUES(@ProjectId,@TargetId,@PointId,@SurveyingId,@SurveyingTime,@Data1);";
            DbConn.ExecuteSql(sql, gen);
        }

        public List<Models.SurDataGen> GetGenDatas(int projectid, int targetid)
        {
            string sql = "select * from `surdatagen` " +
                "where `projectid`=@projectid and `targetid`=@targetid" +
                " order by `pointid`,`SurveyingTime`;";
            var model = DbConn.Query<Models.SurDataGen>(sql,
                new
                {
                    projectid = projectid,
                    targetid = targetid
                });
            return model;
        }
    }
}
