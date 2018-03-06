using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace Busqueda
{
    public partial class Form1 : Form
    {
        ConsultaSQL sql = new ConsultaSQL();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sql.MostrarDatos();
        }
        private void tbFolio_TextChanged(object sender, EventArgs e)
        {
            if (tbFolio.Text != "")
                dataGridView1.DataSource = sql.Buscar(tbFolio.Text);
            else
                dataGridView1.DataSource = sql.MostrarDatos();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                if (Convert.ToInt32(dataGridView1[0, e.RowIndex].Value) == 0)
                    dataGridView1[0, e.RowIndex].Value = 1;
                else
                    dataGridView1[0, e.RowIndex].Value = 0;
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
                var allCheckedRows = this.dataGridView1.Rows.Cast<DataGridViewRow>()
                                .Where(row => (int?)row.Cells[0].Value == 1)
                                .ToList();
                var builder = new StringBuilder();
                allCheckedRows.ForEach(row =>
                {
                    var cellValues = row.Cells.Cast<DataGridViewCell>()
                        .Where(cell => cell.ColumnIndex > 0)
                        .Select(cell => string.Format("{0}", cell.Value))
                        .ToArray();
                    builder.AppendLine(string.Join(", ", cellValues));    
                });
                e.Graphics.DrawString(builder.ToString(),
                            this.dataGridView1.Font,
                            new SolidBrush(this.dataGridView1.ForeColor),
                            new RectangleF(0, 0, this.printDocument1.DefaultPageSettings.PrintableArea.Width, this.printDocument1.DefaultPageSettings.PrintableArea.Height));
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
