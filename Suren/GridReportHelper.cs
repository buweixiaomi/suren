using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Suren
{
    public class GridReportHelper
    {
        public static void ShowReport(XPMergeView grid,
            DataTable tbtitle, DataTable tbmark, DataTable tbdata)
        {

            var colscount = tbdata.Columns.Count;
            var mkcount = tbmark.Columns.Count;
            double eachdount = colscount / (double)mkcount;
            int max = (int)Math.Ceiling(eachdount);
            int min = (int)Math.Floor(eachdount);
            List<int> eachspan = new List<int>();
            var less = colscount;
            for (var k = 0; k < mkcount; k++)
            {
                if (k == mkcount - 1)
                {
                    eachspan.Add(less);

                    break;
                }
                if (k % 2 == 0)
                {
                    eachspan.Add(min);
                    less -= min;
                }
                else
                {
                    eachspan.Add(max);
                    less -= max;
                }
            }

            DataTable tb = new DataTable();

            for (var k = 0; k < colscount; k++)
            {
                DataColumn column = new DataColumn();
                column.ColumnName = "col_" + k;
                tb.Columns.Add(column);
            }
            var row = tb.NewRow();
            row[0] = tbtitle.Rows.Count == 0 ? "" : tbtitle.Rows[0][0].ToString();
            tb.Rows.Add(row);
            grid.SetCellColSpan(0, 0, colscount);
            row = tb.NewRow();
            int collast = 0;
            for (var k = 0; k < tbmark.Columns.Count; k++)
            {
                grid.SetCellColSpan(1, collast, eachspan[k]);
                var val = tbmark.Rows.Count == 0 ? "" : tbmark.Rows[0][k].ToString();
                row[collast] = val;
                collast += eachspan[k];
            }
            tb.Rows.Add(row);
            row = tb.NewRow();
            for (int c = 0; c < tbdata.Columns.Count; c++)
            {
                row[c] = tbdata.Columns[c].ColumnName;
            }
            tb.Rows.Add(row);

            for (var k = 0; k < tbdata.Rows.Count; k++)
            {
                row = tb.NewRow();
                for (int c = 0; c < tbdata.Columns.Count; c++)
                {
                    var val = tbdata.Rows[k][c].ToString();
                    row[c] = val;
                }
                tb.Rows.Add(row);
            }
            grid.DataSource = tb;
            grid.ReadOnly = true;
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            //grid.AddSpanHeader(0, colscount, "测试");
        }
    }
}
