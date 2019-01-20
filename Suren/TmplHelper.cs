using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Suren
{
    public class TmplHelper
    {
        public static Dictionary<string, string> GetAll()
        {
            return null;
        }

        public static DataSet Exec(int pid, int tid, string tmpl)
        {
            var fullname = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ReportTmps\\" + tmpl);
            if (!System.IO.File.Exists(fullname)) return null;
            string sql = System.IO.File.ReadAllText(fullname, Encoding.UTF8);
            using (var db = Pub.GetConn())
            {
                var svs = Dal.Instance.GetTargetSurveyings(pid, tid);
                var sureyingidfirst = svs.FirstOrDefault();
                var sureyingidlast = svs.LastOrDefault();
                var firstid = sureyingidfirst == null ? 0 : sureyingidfirst.SurveyingId;
                var lastid = sureyingidlast == null ? 0 : sureyingidlast.SurveyingId;
                sql = sql.Replace("@projectid", pid.ToString())
                    .Replace("@targetid", tid.ToString())
                    .Replace("@sureyingidlast", lastid.ToString())
                    .Replace("@sureyingidfirst", firstid.ToString());
                var ds = db.SqlToDataSet(sql, null);
                return ds;
            }
        }
    }
}
