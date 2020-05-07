using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_negocio;
using Capa_entidades;
using System.IO;

namespace TiendaOnline
{
    public partial class FormularioBusquedaUsuario : Form
    {
        Negocio _neg;
        List<Usuario> _listaUsuarios;
        DataTable dt = new DataTable();
        private int indice;

        public string usuarioId { get; set; }


        public FormularioBusquedaUsuario()
        {
            InitializeComponent();

            _neg = new Negocio();


        }

        private void FormularioBusqueda_Load(object sender, EventArgs e)
        {
            _listaUsuarios = new List<Usuario>();
            _listaUsuarios = _neg.ObtenerUsuarios();


            dt = ConvertToDataTable(_listaUsuarios);
            dt.DefaultView.Sort = "UsuarioID";

            DataColumn nomApellido = dt.Columns.Add("NomApellido", typeof(string));

            foreach (DataRow data in dt.Rows)
            {

                data["NomApellido"] = data["nombre"].ToString() + " " + data["apellidos"].ToString();
            }

            dataGridViewUsuarios.DataSource = dt;

            dataGridViewUsuarios.Columns["NomApellido"].Visible = false;

            txtBusqueda.Enabled = false;


        }



        private void ComboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            indice = comboFiltro.SelectedIndex;

            if (indice == 0)
            {
                LbSeleccion.Text = "Nombre y Apellidos del usuario";
                txtBusqueda.Enabled = true;

            }
            else if (indice == 1)
            {
                LbSeleccion.Text = "Email del usuario";
                txtBusqueda.Enabled = true;

            }
            else if (indice == 2)
            {
                LbSeleccion.Text = "DNI del usuario ";
                txtBusqueda.Enabled = true;

            }
        }





        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBusqueda.Text.Trim()) == false)
            {

                if (indice == 0)
                {

                    /*  BindingSource bs = new BindingSource
                      {
                          DataSource = dataGridViewUsuarios.DataSource,
                          Filter = "nomApellido like'%" + txtBusqueda.Text + "%'"
                      };
                      dataGridViewUsuarios.DataSource = bs;*/

                    dt.DefaultView.RowFilter = $"nomApellido like'{txtBusqueda.Text}%'";
                }
                if (indice == 1)
                {
                    /* BindingSource bs = new BindingSource
                      {
                          DataSource = dataGridViewUsuarios.DataSource,
                          Filter = "dni like'%" + txtBusqueda.Text + "%'"
                      };
                      dataGridViewUsuarios.DataSource = bs;*/

                    dt.DefaultView.RowFilter = $"Email like'{txtBusqueda.Text}%'";
                }
                if (indice == 2)
                {
                    /*  BindingSource bs = new BindingSource
                      {
                          DataSource = dataGridViewUsuarios.DataSource,
                          Filter = "Email like'%" + txtBusqueda.Text + "%'"
                      };
                      dataGridViewUsuarios.DataSource = bs;*/

                    dt.DefaultView.RowFilter = $"Dni like'{txtBusqueda.Text}%'";
                }
            }
            else
            {
                dataGridViewUsuarios.DataSource = dt;
                txtBusqueda.Text = "";
            }

        }







        private void DataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DevolverUsuario();
        }

        private void DevolverUsuario()
        {
            FormularioNuevoUsuario frmModificar = new FormularioNuevoUsuario();

            DateTime? Fecha = dataGridViewUsuarios.SelectedRows[0].Cells[12].Value == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataGridViewUsuarios.SelectedRows[0].Cells[12].Value);


            FormularioNuevoUsuario.usuario = new Usuario(int.Parse(dataGridViewUsuarios.SelectedRows[0].Cells[0].Value.ToString()),
                dataGridViewUsuarios.SelectedRows[0].Cells[1].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[2].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[3].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[4].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[5].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[6].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[7].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[8].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[9].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[10].Value.ToString(),
                dataGridViewUsuarios.SelectedRows[0].Cells[11].Value.ToString(),
                Fecha);

            frmModificar.MdiParent = MdiParent;
            frmModificar.Text = "Modificar Usuario";
            frmModificar.Show();
        }



        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }


        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

      
    }
}


