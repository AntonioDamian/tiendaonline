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
using MiLibreria;
using System.Globalization;
using MiLibreria;

namespace TiendaOnline
{
    public partial class FormularioBusquedaPedido : Form
    {

        NegocioPedido _negPedido;
        List<Pedido> _ListPedidos;

        NegocioLinped _negLinped;
        List<Linped> _listLinpeds;
       
        DataTable dt;
        private DataView dv;
        DataTable aux;


        public static List<Linped> lista = new List<Linped>();
        public static List<Pedido> _pedidoeleguido = new List<Pedido>();
        private DataView df;
        private DateTime[] listaFechas;

        private int indice;


        int id = 0;

        public FormularioBusquedaPedido(string opcion)
        {
            InitializeComponent();

            _negPedido = new NegocioPedido();
            _negLinped = new NegocioLinped();
            dt = new DataTable();
            aux = new DataTable();

            if("Eliminar"==opcion)
            {
                btnEliminar.Visible = true;
                btnEliminar.Enabled = true;
                btnSeleccionar.Enabled = false;
                btnSeleccionar.Visible = false;
            }
           

        }

        private void FormularioBusquedaPedido_Load(object sender, EventArgs e)
        {
            _listLinpeds = new List<Linped>();
            _listLinpeds = _negLinped.ObtenerLinped();

            txtNombre.Enabled = false;
            txtFechaPedido.Enabled = false;
            btnBuscar.Enabled = false;


            LlenarDataGridViewPedidos();

           
        }

        /// <summary>
        /// Metodo que utilizaremos para llenar el datagridview de pedidos obtenidos de la base de datos
        /// </summary>

        private void LlenarDataGridViewPedidos()
        {
            _ListPedidos = new List<Pedido>();
            _ListPedidos = _negPedido.ObtenerPedido();
            Pedido p = new Pedido();

            for(int i=0;i<_ListPedidos.Count;i++)
            {
                for(int j=0;j<_listLinpeds.Count;j++)
                {
                    if(_ListPedidos[i].PedidoID==_listLinpeds[j].PedidoID)
                    {
                        _ListPedidos[i].AddLinped(_listLinpeds[j]);                        
                    }
                }

            }

            dt = Utilidades.ConvertToDataTable(_ListPedidos);
         

            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvPedidos.DataSource = dt;

        }

        /// <summary>
        /// Metodo del comobobox que utilizaremos para seleccionar la opcion de filtrado de los datos de pedidos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmBoxFiltrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            indice = cmBoxFiltrar.SelectedIndex;

            if (indice == 0)//indice  para filtrar por usuarioID
            {
                LlenarDataGridViewPedidos();
                lbUsuarioID.Visible = true;
                txtNombre.Visible = true;
                txtNombre.Enabled = true;

                lbFechaPedido.Visible = false;
                txtFechaPedido.Visible = false;
                txtFechaPedido.Enabled = false;
                btnBuscar.Visible = false;
                btnBuscar.Enabled = false;


            }
            else if (indice == 1)//indice para filtrar por fecha
            {
                LlenarDataGridViewPedidos();
                lbFechaPedido.Visible = true;
                txtFechaPedido.Enabled = true;
                txtFechaPedido.Visible = true;
                btnBuscar.Visible = true;
                btnBuscar.Enabled = true;

                lbUsuarioID.Visible = false;
                txtNombre.Visible = false;
                txtNombre.Enabled = false;
               
              
            }
            else if (indice == 2)
            {
                LlenarDataGridViewPedidos();
                lbUsuarioID.Visible = true;
                txtNombre.Visible = true;
                txtNombre.Enabled = true;

                lbFechaPedido.Visible = true;
                txtFechaPedido.Enabled = true;
                txtFechaPedido.Visible = true;
                btnBuscar.Visible = true;
                btnBuscar.Enabled = true;
            }
        }



        /// <summary>
        /// Metodo que itilizaremos para filtrar pedios segùn el id del usuario ,se ira filtrando segun escribamos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void TxtNombre_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()) == false)
            {
                aux = dt.Clone();
              

                id = Convert.ToInt32(txtNombre.Text);

                dt.DefaultView.RowFilter = String.Format(CultureInfo.InvariantCulture.NumberFormat,
                     "UsuarioID = {0}",id );
              

                /*  foreach (DataRow rows in dt.Rows)
                   {
                       DataRow dr = aux.NewRow();
                       dr[0] = rows[0].ToString();
                       dr[1] = rows[1].ToString();
                       dr[2] = rows[2].ToString(); 
                       dr[3] = rows[3].ToString();
                       dr[4] = rows[4].ToString();


                    aux.Rows.Add(dr);
                   }*/

            }
             else if(string.IsNullOrEmpty(txtNombre.Text.Trim()) == true && indice ==2)
            {
                dgvPedidos.DataSource = dt;
            }
            else
            {
                LlenarDataGridViewPedidos();
            }
        }

        /// <summary>
        /// Metodo para comprobar cuando el campo de fecha esta vacio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFechaPedido_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaPedido.Text.Trim()) == true)
            {
                if (indice == 1)
                {
                    dgvPedidos.DataSource = dt;
                }
                if (indice == 2)
                {
                    ((DataTable)dgvPedidos.DataSource).DefaultView.RowFilter = "";
                }
            }
           
        }


        /// <summary>
        /// Metodo para la busqueda segun fecha de pedidos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBuscar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtFechaPedido.Text.Trim()) == false)
            {
                try
                {
                    if (indice == 1)
                    {
                        DateTime myDate = DateTime.ParseExact(txtFechaPedido.Text, "dd/MM/yyyy",
                                                               System.Globalization.CultureInfo.InvariantCulture);

                        dt.DefaultView.RowFilter = String.Format(CultureInfo.InvariantCulture.DateTimeFormat,
                             "fecha = #{0}#", myDate);
                    }
                    if(indice==2)
                    {
                        DateTime myDate = DateTime.ParseExact(txtFechaPedido.Text, "dd/MM/yyyy",
                                                                                      System.Globalization.CultureInfo.InvariantCulture);

                        string idUsu = String.Format(CultureInfo.InvariantCulture.NumberFormat,
                   "UsuarioID = {0}", id);
                        string _sqlOrder = "UsuarioID DESC";

                        aux = dt.Select(idUsu, _sqlOrder).CopyToDataTable();

                        aux.DefaultView.RowFilter = String.Format(CultureInfo.InvariantCulture.DateTimeFormat,
                           "fecha = #{0}#", myDate);

                        dgvPedidos.DataSource = aux;
                    }

                }
                catch(Exception)
                {
                    errorProvider1.SetError(txtFechaPedido, "Establece una fecha válida de búsqueda con formato dd/MM/yyyy");
                }
               
              
            }
            else
            {
               if(indice==1)
                {
                    errorProvider1.SetError(txtFechaPedido, "Establece una fecha válida de búsqueda con formato dd/MM/yyyy");
                }
               if(indice==2 && string.IsNullOrEmpty(txtNombre.Text.Trim()) == true)
                {
                    errorProvider1.SetError(txtFechaPedido, "Establece una fecha válida de búsqueda con formato dd/MM/yyyy");
                    errorProvider1.SetError(txtNombre, "Debe indicar algun UsuarioID");
                }

            }
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.Rows.Count == 0)
            {
                return;
            }
            else
            {

                DialogResult = DialogResult.OK;

                for (int i = 0; i < _ListPedidos.Count; i++)
                {

                    if (_ListPedidos[i].PedidoID.ToString() == dgvPedidos.Rows[dgvPedidos.CurrentRow.Index].Cells[0].Value.ToString())
                    {
                        lista = _ListPedidos[i].Linpeds;

                        _pedidoeleguido.Add(new Pedido(_ListPedidos[i]));
                    }

                  

                }




                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idPedido = Convert.ToInt32(dgvPedidos.Rows[dgvPedidos.CurrentRow.Index].Cells[0].Value.ToString());

            DialogResult result = MessageBox.Show("¿Desea eliminar este pedido?",
             "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (_negPedido.Borrar(idPedido) == true)
                {
                   
                    MessageBox.Show(string.Format("Eliminado el pedido {0}", idPedido), "Confirmación", MessageBoxButtons.OK);
                    LlenarDataGridViewPedidos();
                }
                else
                {
                    MessageBox.Show(string.Format("Problemas al eliminar  el pedido {0}", idPedido), "Errror", MessageBoxButtons.OK);
                }


            }

            
        }
    }
}
