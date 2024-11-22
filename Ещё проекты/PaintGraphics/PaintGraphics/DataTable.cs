using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintGraphics
{
    public partial class DataTable : UserControl
    {
        public List<Line> lines;
        public Form1 form;
        public DataTable()
        {
            InitializeComponent();
        }
        public void UpdateTable()
        {
            dataGridView1.Rows.Clear();
            Line line;
            for (int i=0;i<lines.Count;i++)
            {
                line = lines[i];
                dataGridView1.Rows.Add();
                SetRow(i, line);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!setrow)
            {
                if (e.RowIndex > -1 & e.ColumnIndex > -1 & e.ColumnIndex < 9)
                {
                    DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
                    Line line = lines[e.RowIndex];
                    line.ChangeParam(e.ColumnIndex, cell.Value.ToString());
                    form.RewriteAll();
                }
            }
        }
        bool setrow = false;
        private void SetRow(int Row,Line line)
        {
            setrow = true;
            dataGridView1[0, Row].Value = line.point1.X;
            dataGridView1[1, Row].Value = line.point1.Y;
            dataGridView1[2, Row].Value = line.point1.OK;
            dataGridView1[3, Row].Value = line.point2.X;
            dataGridView1[4, Row].Value = line.point2.Y;
            dataGridView1[5, Row].Value = line.point2.OK;
            dataGridView1[6, Row].Value = line.A;
            dataGridView1[7, Row].Value = line.B;
            dataGridView1[8, Row].Value = line.C;
            setrow = false;
        }
        public void AddLine(Line line)
        {
            dataGridView1.Rows.Add();
            SetRow(dataGridView1.Rows.Count-1, line);
            line.Row = dataGridView1.Rows[dataGridView1.Rows.Count - 1];
        }
        public void RemoveLine(int index)
        {
            dataGridView1.Rows.RemoveAt(index);
        }
    }
}
