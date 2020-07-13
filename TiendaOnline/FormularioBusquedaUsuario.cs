using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidades;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TiendaOnline
{
    public partial class FormularioBusquedaUsuario : Form
    {
        Negocio _neg;
        List<Usuario> _listaUsuarios;
        DataTable dt = new DataTable();
        DataTable aux = new DataTable();
        private int indice;

       

        public string usuarioId { get; set; }


        public FormularioBusquedaUsuario( string opcion)
        {
            InitializeComponent();

            _neg = new Negocio();

            if("Pedido"==opcion)
            {
                this.dataGridViewUsuarios.CellContentClick -= new DataGridViewCellEventHandler(this.DataGridViewUsuarios_CellContentClick);
            }          

          
        }

        private void FormularioBusqueda_Load(object sender, EventArgs e)
        {
            _listaUsuarios = new List<Usuario>();
            _listaUsuarios = _neg.ObtenerUsuarios();     

            dt.Columns.Add("UsuarioID");
            dt.Columns.Add("Email");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellidos");
            dt.Columns.Add("Dni");

          


            foreach (Usuario usu in _listaUsuarios)
            {
               // dataGridViewUsuarios.Rows.Add(new object[] { usu.UsuarioID, usu.Email, usu.Nombre, usu.Apellidos, usu.Dni });
                dt.Rows.Add(new object[] { usu.UsuarioID, usu.Email, usu.Nombre, usu.Apellidos, usu.Dni });
            }

           dt.DefaultView.Sort = "UsuarioID";           

            txtBusqueda.Enabled = false;

          dataGridViewUsuarios.DataSource = dt;


        }

        private void RefresDatagridview()
        {
            dt.Clear();
            aux.Clear();          
         

            foreach (Usuario usu in _listaUsuarios)
            {
                dt.Rows.Add(new object[] { usu.UsuarioID, usu.Email, usu.Nombre, usu.Apellidos, usu.Dni });
            }


            dataGridViewUsuarios.DataSource = dt;
        }


        /// <summary>
        /// Metodo que utilizaremos para seleccionar la opcion de filtrado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ComboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            indice = comboFiltro.SelectedIndex;

           
            if (indice == 0)
            {               
                LbSeleccion.Text = "Nombre del usuario";               
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


        /// <summary>
        /// Metodo par introducir el parametro de filtrado,que se realizara según vayamos escribiendo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtBusqueda.Text.Trim()) == false)
            {
               
                if (indice == 0)//filtrado por nombre
                {
                    aux = dt.Clone();
                    lbApellidos.Visible = true;
                    lbApellidos.Text = "Apellidos";
                    textApellidos.Enabled = true;
                    textApellidos.Visible = true;

                   dt.DefaultView.RowFilter = $"Nombre like'{txtBusqueda.Text}%'";
                    // ((DataTable)dataGridViewUsuarios.DataSource).DefaultView.RowFilter = $"Nombre like'{txtBusqueda.Text}%'";  

                   


                    foreach (DataGridViewRow rows in dataGridViewUsuarios.Rows)
                    {
                        DataRow dr = aux.NewRow();
                        dr[0] = rows.Cells[0].Value.ToString();
                        dr[1] = rows.Cells[1].Value.ToString();
                        dr[2] = rows.Cells[2].Value.ToString();
                        dr[3] = rows.Cells[3].Value.ToString();
                        dr[4] = rows.Cells[4].Value.ToString();

                        aux.Rows.Add(dr);
                    }

                }
                if (indice == 1)//filtrado por email
                {                   

                  dt.DefaultView.RowFilter = $"Email like'{txtBusqueda.Text}%'";
                    //((DataTable)dataGridViewUsuarios.DataSource).DefaultView.RowFilter = $"Email like'{txtBusqueda.Text}%'";
                }
                if (indice == 2)//filtrado por deni usuario
                {

                    //((DataTable)dataGridViewUsuarios.DataSource).DefaultView.RowFilter = $"Dni like'{txtBusqueda.Text}%'";
                    dt.DefaultView.RowFilter = $"Dni like'{txtBusqueda.Text}%'";
                }
            }
            else
            {
                txtBusqueda.Text = "";
                lbApellidos.Visible = false;
                textApellidos.Enabled = false; 
                textApellidos.Visible = false;
                // ((DataTable)dataGridViewUsuarios.DataSource).DefaultView.RowFilter ="";


                //  dataGridViewUsuarios.DataSource = dt;
                dataGridViewUsuarios.DataSource = "";
                RefresDatagridview();
             
            }

        }

        /// <summary>
        /// Metodo que utilizzaremos para filtrar por apellidos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void TextApellidos_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textApellidos.Text.Trim()) == false)
            {
               // ((DataTable)dataGridViewUsuarios.DataSource).DefaultView.RowFilter = $"Apellidos like'{textApellidos.Text}%'";
              aux.DefaultView.RowFilter = $"Apellidos like'{textApellidos.Text}%'";
               dataGridViewUsuarios.DataSource = aux;
            }
            else
            {
                ((DataTable)dataGridViewUsuarios.DataSource).DefaultView.RowFilter = "";
               // dataGridViewUsuarios.DataSource = aux;

            }
        }




        /// <summary>
        /// Metodo que se habilitara cuando la llamada  a la clase sea desde formulario usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void DataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DevolverUsuario();
        }

        /// <summary>
        /// Metodo aux qeu nos devolvera el usuario seleccionado
        /// </summary>
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)13)
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("Apellidos Like '%{0}%'", textApellidos.Text);
                dataGridViewUsuarios.DataSource = dv.ToTable();
            }
        }
    }
}


