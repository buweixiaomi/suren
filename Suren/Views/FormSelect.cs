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
    public partial class FormSelect : Form
    {
        public FormSelect()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        object selectedItem;

        public Models.Project SelectProject(string keywords)
        {
            using (var db = Pub.GetConn())
            {
                var items = Dal.Instance.PageProject(1, 50, keywords);
                Pub.FillGrid(grid, items, (dr, item) =>
                {
                    dr.Tag = item;
                    dr.Cells["id"].Value = item.ProjectId;
                    dr.Cells["title"].Value = item.ProjectName;
                });
            }
            if (this.ShowDialog() != DialogResult.OK)
                return null;
            if (selectedItem == null) return null;
            return (Models.Project)selectedItem;
        }

        public Models.Target SelectTarget(int projetid,string keywords)
        {
            using (var db = Pub.GetConn())
            {
                var items = Dal.Instance.Targets(projetid, keywords);
                Pub.FillGrid(grid, items, (dr, item) =>
                {
                    dr.Tag = item;
                    dr.Cells["id"].Value = item.TargetId;
                    dr.Cells["title"].Value = item.TargetName;
                });
            }
            if (this.ShowDialog() != DialogResult.OK)
                return null;
            if (selectedItem == null) return null;
            return (Models.Target)selectedItem;
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.CurrentCell != null)
            {
                selectedItem = grid.Rows[grid.CurrentCell.RowIndex].Tag;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && grid.CurrentCell != null)
            {
                selectedItem = grid.Rows[grid.CurrentCell.RowIndex].Tag;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void FormSelect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
