using Capa_entidades;
using Capa_negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaOnline
{
    public partial class ListaUsuarios : Form
    {

        private Negocio _neg;
        public ListaUsuarios()
        {
            InitializeComponent();
            _neg = new Negocio();
        }


        private void DevolverUsuario()
        {
            Form1.Usuario = new Usuario(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()),
                dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[3].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[4].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[5].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[6].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[7].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[8].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[9].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[10].Value.ToString(),
                dataGridView1.SelectedRows[0].Cells[11].Value.ToString(),
                Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[12].Value));
            
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DevolverUsuario();
            this.Close();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            DevolverUsuario();
            this.Close();
        }

        private void ListaUsuarios_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _neg.ObtenerUsuarios();
        }
    }
}
