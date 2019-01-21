using NPOI.OpenXmlFormats.Dml.Chart;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Suren
{
    public class WordHelper
    {
        public const int DocTitleSize = 16;
        public const int TableTitleSize = 11;
        public const int NormalTitleSize = 11;
        public const int MainTextSize = 10;
        public static string DecimalFomat = "0.000";
        string fileName = "";
        XWPFDocument m_Docx;
        public WordHelper(string name, int w, int h)
        {
            fileName = name;
            m_Docx = new XWPFDocument();
            CT_SectPr m_SectPr = new CT_SectPr();       //实例一个尺寸类的实例
            m_SectPr.pgSz.w = (ulong)w;        //设置宽度（这里是一个ulong类型）
            m_SectPr.pgSz.h = (ulong)h;        //设置高度（这里是一个ulong类型）

            m_SectPr.pgMar.left = (ulong)100;//左边距
            m_SectPr.pgMar.right = (ulong)100;//右边距
            m_SectPr.pgMar.top = "150";//上边距
            m_SectPr.pgMar.bottom = "150";
            m_Docx.Document.body.sectPr = m_SectPr;          //设置页面的尺寸

        }


        public static Font GetFont(float fontsize = TableTitleSize,bool bold=false)
        {
            System.Drawing.FontFamily myFontFamily = new System.Drawing.FontFamily("微软雅黑"); //采用哪种字体
            Font myFont = new Font(myFontFamily, fontsize,bold?FontStyle.Bold:FontStyle.Regular); //字是那种字体（幼圆），显示的
            return myFont;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="type">0:px 1:inc 2:mm</param>
        /// <returns></returns>
        public static int ToTI(float v, int type)
        {
            float vx = 0;
            switch (type)
            {
                case 0: vx = v * 15; break;
                case 1: vx = v * 1440; break;
                case 2: vx = v * 56.7f; break;
                default: vx = v; break;
            }
            return (int)vx;
        }

        public static int TIToPx(int ti)
        {
            return (int)(ti / 15.0f);
        }


        public void DrawTable(DataTable tbtitle, DataTable tbmake, DataTable tbdata)
        {
            var colscount = tbdata.Columns.Count;
            var mkcount = tbmake.Columns.Count;
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

            XWPFTable table = m_Docx.CreateTable(3 + tbdata.Rows.Count, colscount);
            XWPFTableCell cell = null;
            CT_Tc cttc = null;
            CT_TcPr ctPr = null;
            for (var k = 1; k < colscount; k++)
                table.GetRow(0).RemoveCell(0);
            cell = table.GetRow(0).GetCell(0);
            cttc = cell.GetCTTc();
            ctPr = cttc.AddNewTcPr();
            ctPr.AddNewGridspan();
            ctPr.gridSpan.val = colscount.ToString();
            var title = tbtitle.Rows.Count == 0 ? "" : tbtitle.Rows[0][0].ToString();
            var parag = cell.Paragraphs[0];
            parag.Alignment = ParagraphAlignment.CENTER;
            var cellrun = parag.CreateRun();
            cellrun.FontSize = TableTitleSize + 1;
            cellrun.IsBold = true;
            cellrun.SetText(title);
            for (var k = eachspan.Count; k < colscount; k++)
                table.GetRow(1).RemoveCell(0);
            for (var k = 0; k < tbmake.Columns.Count; k++)
            {
                var val = tbmake.Rows.Count == 0 ? "" : tbmake.Rows[0][k].ToString();
                cell = table.GetRow(1).GetCell(k);
                cttc = cell.GetCTTc();
                ctPr = cttc.AddNewTcPr();
                ctPr.AddNewGridspan();
                ctPr.gridSpan.val = eachspan[k].ToString();
                parag = cell.Paragraphs[0];
                parag.Alignment = ParagraphAlignment.CENTER;
                cellrun = parag.CreateRun();
                cellrun.FontSize = TableTitleSize;
                cellrun.IsBold = true;
                cellrun.SetText(val);
            }

            for (int c = 0; c < tbdata.Columns.Count; c++)
            {
                table.GetRow(2).GetCell(c).SetText(tbdata.Columns[c].ColumnName);
            }
            for (var k = 0; k < tbdata.Rows.Count; k++)
            {
                for (int c = 0; c < tbdata.Columns.Count; c++)
                {
                    var val = tbdata.Rows[k][c];
                    cell = table.GetRow(3 + k).GetCell(c);
                    if (val is decimal)
                    {
                        cell.SetText(((decimal)val).ToString("0.000"));
                    }
                    else if (val is double)
                    {
                        cell.SetText(((double)val).ToString("0.000"));
                    }
                    else
                        cell.SetText(val.ToString());
                }
            }
        }

        public void DrawTableChart(MemoryStream imgstream, int w, int h)
        {
            imgstream.Position = 0;
            var gr = m_Docx.CreateParagraph();
            var run = gr.CreateRun();
            run.AddPicture(imgstream, (int)NPOI.SS.UserModel.PictureType.PNG, "aa.png", w * 9525, h * 9525);

        }

        public void AddTitle(string title)
        {
            var gr = m_Docx.CreateParagraph();
            gr.Alignment = ParagraphAlignment.CENTER;
            var run = gr.CreateRun();
            run.IsBold = true;
            run.FontSize = DocTitleSize;
            run.SetText(title ?? "");
        }

        public void AddEmptLine()
        {
            var gr = m_Docx.CreateParagraph();
        }


        public void DrawTable(DataTable tbdata)
        {
            XWPFTable table = m_Docx.CreateTable(1 + tbdata.Rows.Count, tbdata.Columns.Count);
            XWPFTableCell cell = null;
            for (int c = 0; c < tbdata.Columns.Count; c++)
            {
                cell = table.GetRow(0).GetCell(c);
                var para = cell.Paragraphs[0];
                para.Alignment = ParagraphAlignment.CENTER;
                var titlerun = para.CreateRun();
                titlerun.IsBold = true;
                titlerun.FontSize = TableTitleSize;
                titlerun.SetText(tbdata.Columns[c].ColumnName);
            }
            for (var k = 0; k < tbdata.Rows.Count; k++)
            {
                for (int c = 0; c < tbdata.Columns.Count; c++)
                {
                    var val = tbdata.Rows[k][c];
                    cell = table.GetRow(1 + k).GetCell(c);
                    var parag = cell.Paragraphs[0];
                    var ru = parag.CreateRun();
                    ru.FontSize = MainTextSize;
                    if (val is decimal)
                    {
                        ru.SetText(((decimal)val).ToString(DecimalFomat));
                    }
                    else if (val is double)
                    {
                        ru.SetText(((double)val).ToString(DecimalFomat));
                    }
                    else
                    {
                        ru.SetText(val.ToString());
                    }
                }
            }
        }

        public void Save()
        {
            var st = new MemoryStream();
            m_Docx.Write(st);
            if (System.IO.File.Exists(fileName))
                System.IO.File.Delete(fileName);
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                byte[] data = st.ToArray();
                fs.Write(data, 0, data.Length);
                fs.Flush();
                data = null;
            }
        }

        private XWPFDocument CreatDocxTable()
        {


            XWPFTable table = m_Docx.CreateTable(1, 3);//创建一行3列表
            table.GetRow(0).GetCell(0).SetText("111");
            table.GetRow(0).GetCell(1).SetText("222");
            table.GetRow(0).GetCell(2).SetText("333");

            XWPFTableRow m_Row = table.CreateRow();//创建一行
            m_Row = table.CreateRow();//创建一行
            m_Row.GetCell(0).SetText("211");

            //合并单元格
            m_Row = table.InsertNewTableRow(0);//表头插入一行
            XWPFTableCell cell = m_Row.CreateCell();//创建一个单元格,创建单元格时就创建了一个CT_P
            CT_Tc cttc = cell.GetCTTc();
            CT_TcPr ctPr = cttc.AddNewTcPr();
            ctPr.AddNewGridspan();
            ctPr.gridSpan.val = "3";//合并3列
            cttc.GetPList()[0].AddNewPPr().AddNewJc().val = ST_Jc.center;
            cttc.GetPList()[0].AddNewR().AddNewT().Value = "abc";

            XWPFTableRow td3 = table.InsertNewTableRow(table.Rows.Count - 1);//插入行
            cell = td3.CreateCell();
            cttc = cell.GetCTTc();
            ctPr = cttc.AddNewTcPr();
            ctPr.AddNewGridspan();
            ctPr.gridSpan.val = "3";
            cttc.GetPList()[0].AddNewPPr().AddNewJc().val = ST_Jc.center;
            cttc.GetPList()[0].AddNewR().AddNewT().Value = "qqq";

            //表增加行，合并列
            CT_Row m_NewRow = new CT_Row();
            m_Row = new XWPFTableRow(m_NewRow, table);
            table.AddRow(m_Row); //必须要！！！
            cell = m_Row.CreateCell();
            cttc = cell.GetCTTc();
            ctPr = cttc.AddNewTcPr();
            ctPr.AddNewGridspan();
            ctPr.gridSpan.val = "3";
            cttc.GetPList()[0].AddNewPPr().AddNewJc().val = ST_Jc.center;
            cttc.GetPList()[0].AddNewR().AddNewT().Value = "sss";

            //表未增加行，合并2列，合并2行
            //1行
            m_NewRow = new CT_Row();
            m_Row = new XWPFTableRow(m_NewRow, table);
            table.AddRow(m_Row);
            cell = m_Row.CreateCell();
            cttc = cell.GetCTTc();
            ctPr = cttc.AddNewTcPr();
            ctPr.AddNewGridspan();
            ctPr.gridSpan.val = "2";
            ctPr.AddNewVMerge().val = ST_Merge.restart;//合并行
            ctPr.AddNewVAlign().val = ST_VerticalJc.center;//垂直居中
            cttc.GetPList()[0].AddNewPPr().AddNewJc().val = ST_Jc.center;
            cttc.GetPList()[0].AddNewR().AddNewT().Value = "xxx";
            cell = m_Row.CreateCell();
            cell.SetText("ddd");
            //2行，多行合并类似
            m_NewRow = new CT_Row();
            m_Row = new XWPFTableRow(m_NewRow, table);
            table.AddRow(m_Row);
            cell = m_Row.CreateCell();
            cttc = cell.GetCTTc();
            ctPr = cttc.AddNewTcPr();
            ctPr.AddNewGridspan();
            ctPr.gridSpan.val = "2";
            ctPr.AddNewVMerge().val = ST_Merge.@continue;//合并行
            cell = m_Row.CreateCell();
            cell.SetText("kkk");
            ////3行
            //m_NewRow = new CT_Row();
            //m_Row = new XWPFTableRow(m_NewRow, table);
            //table.AddRow(m_Row);
            //cell = m_Row.CreateCell();
            //cttc = cell.GetCTTc();
            //ctPr = cttc.AddNewTcPr();
            //ctPr.gridSpan.val = "2";
            //ctPr.AddNewVMerge().val = ST_Merge.@continue;
            //cell = m_Row.CreateCell();
            //cell.SetText("hhh");

            return m_Docx;
        }
    }
}
