using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Suren
{
    public class Pub
    {
        public static RLib.DB.DbConn GetConn()
        {
            var conn = RLib.DB.DbConn.CreateConn(RLib.DB.DbType.MYSQL, RLib.ConfigHelper.GetConnConfig("SurenDbMySql"));
            conn.Open();
            Dal.DbConn = conn;
            return conn;
        }
        public static void InitGrid(DataGridView grid, Dictionary<string, string> map)
        {
            grid.Columns.Clear();
            foreach (var a in map)
            {
                grid.Columns.Add(a.Key, a.Value);
                grid.Columns[grid.Columns.Count - 1].MinimumWidth = 100;
                //= DataGridViewAutoSizeColumnMode.ColumnHeader;
            }
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        public static void FillGrid<T>(DataGridView gird, List<T> data, Action<DataGridViewRow, T> action)
        {
            FillGrid(gird, null, data, action);
        }

        public static void FillGrid<T>(DataGridView gird, Views.PagerControl pager, List<T> data, Action<DataGridViewRow, T> action)
        {
            if (pager != null && data is Models.PagedList<T>)
            {
                var ldata = data as Models.PagedList<T>;
                pager.SetPageInfo(ldata.PageNo, ldata.PageSize, ldata.TotalCount, ldata.TotalPage);
            }
            gird.Rows.Clear();
            if (data.Count > 0)
            {
                gird.Rows.Add(data.Count);
            }
            for (var k = 0; k < data.Count; k++)
            {
                var row = gird.Rows[k];
                var item = data[k];
                action.Invoke(row, item);
            }
        }
    }
}
