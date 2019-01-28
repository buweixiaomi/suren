using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Suren
{
    public class TmplHelper
    {
        public static List<SurenTmpl> GetAll()
        {
            var rdata = new List<SurenTmpl>();
            var dir = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ReportTmps");
            if (System.IO.Directory.Exists(dir))
            {
                var fls = System.IO.Directory.GetFiles(dir, "*.stmpl");
                foreach (var fullname in fls)
                {
                    var tp = new SurenTmpl();
                    tp.FileName = fullname;
                    using (var sr = new System.IO.StreamReader(fullname, Encoding.UTF8))
                    {
                        StringBuilder sb = new StringBuilder();
                        while (!sr.EndOfStream)
                        {
                            var line = sr.ReadLine();
                            if (line.StartsWith("###") || line.StartsWith("## ")) continue;
                            if (line.StartsWith("#TITLE"))
                            {
                                tp.Title = line.Substring("#TITLE".Length).Trim();
                            }
                            if (line.StartsWith("#DATAEXPRESSION"))
                            {
                                tp.DataExpression = line.Substring("#DATAEXPRESSION".Length);
                            }
                            else if (line.StartsWith("#BEGIN-TABLE"))
                            {
                                sb.Clear();
                            }
                            else if (line.StartsWith("#END-TABLE"))
                            {
                                tp.Table = sb.ToString();
                            }
                            else if (line.StartsWith("#CHART-DATAFORMAT"))
                            {
                                tp.ChartDataFormat = line.Substring("#CHART-DATAFORMAT".Length).Trim();
                            }
                            else
                            {
                                sb.AppendLine(line);
                            }
                        }
                    }
                    rdata.Add(tp);
                }
            }
            return rdata;
        }

        public static DataSet Exec(int pid, int tid, SurenTmpl tmpl)
        {
            string sql = tmpl.Table;
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

    public class SurenTmpl
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public string Table { get; set; }
        public string ChartDataFormat { get; set; }
        public string DataExpression { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}
