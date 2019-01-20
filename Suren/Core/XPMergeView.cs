using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Suren
{
    public class XPMergeView : DataGridView
    {
        public XPMergeView()
        {
            this.CellPainting += XPMergeView_CellPainting;
        }
        Dictionary<int, Dictionary<int, int>> spans = new Dictionary<int, Dictionary<int, int>>();
        public void SetCellColSpan(int row, int col, int count)
        {
            if (count < 1) throw new Exception("count不能小于1");
            if (!spans.ContainsKey(row))
            {
                spans[row] = new Dictionary<int, int>();
            }
            spans[row][col] = count;
        }

        public void ClearSpan()
        {
            spans.Clear();
        }

        private void XPMergeView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (!spans.ContainsKey(e.RowIndex)) return;
            int bindex = -1, eindex = -1;
            foreach (var a in spans[e.RowIndex])
            {
                if (a.Value <= 1) continue;
                if (e.ColumnIndex >= a.Key && e.ColumnIndex <= a.Key + a.Value)
                {
                    bindex = a.Key;
                    eindex = a.Key + a.Value;
                    if (eindex >= this.ColumnCount)
                        eindex = this.ColumnCount - 1;
                    break;
                }
            }
            if (bindex == -1) return;

            bool isstart = bindex == e.ColumnIndex, isend = eindex == e.ColumnIndex;
            using (Brush gridBrush = new SolidBrush(this.GridColor))
            using (var backColorBrush = new SolidBrush(e.CellStyle.BackColor))
            using (var foreColorBrush = new SolidBrush(e.CellStyle.ForeColor))
            using (Pen gridLinePen = new Pen(gridBrush, 1))
            {
                // 清除单元格
                var b = e.CellBounds;
                e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                e.Graphics.DrawLine(gridLinePen, b.Left, b.Top, b.Right, b.Top);
                e.Graphics.DrawLine(gridLinePen, b.Left, b.Bottom - 1, b.Right, b.Bottom - 1);

                if (isstart)
                {
                    e.Graphics.DrawLine(gridLinePen, b.Left, b.Top, b.Left, b.Bottom);
                }
                if (isend)
                {
                    e.Graphics.DrawLine(gridLinePen, b.Right, b.Top, b.Right - 1, b.Bottom);
                }
                if (isend)
                {
                    //e.Graphics.Clear(Color.Red);
                    int width = 0;
                    for (var k = bindex; k <= eindex; k++)
                    {
                        width += this[k, e.RowIndex].Size.Width;
                    }
                    var re = new RectangleF(e.CellBounds.Right - width, e.CellBounds.Top, width, e.CellBounds.Height);
                    var objvalue = this[bindex, e.RowIndex].Value;
                    var v = objvalue == null ? "" : objvalue.ToString();
                    DrawStringInCenter(e.Graphics, v, e.CellStyle.Font, foreColorBrush, re);
                }
                e.Handled = true;
            }

        }


        private void DrawStringInCenter(Graphics g, string s, Font font, Brush brush,RectangleF rectangle)
        {
            //写小标题
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            g.DrawString(s, font, brush, rectangle, sf);

        }
    }
}
