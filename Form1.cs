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

namespace Busqueda
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        ConsultaSQL sql = new ConsultaSQL();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sql.MostrarDatos();
        }

        private void tbFolio_TextChanged(object sender, EventArgs e)
        {
            if (tbFolio.Text != "") dataGridView1.
                    DataSource = sql.Buscar(tbFolio.Text);
            else
                dataGridView1.DataSource = sql.MostrarDatos();
        }

        
        
    }
}
