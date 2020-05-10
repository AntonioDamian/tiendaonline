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
using MiLibreria;

namespace TiendaOnline
{
    public partial class FormularioPedidos : Form
    {

        private NegocioPedido _pedido;
        private NegocioProducto _negproducto;
        private NegocioLinped _negLinped;

        Articulo _articulo;

        private List<Articulo> _listArticulos;
        List<Linped> linpeds= new List<Linped>();         
        Linped li = new Linped();
        Pedido pedido ;


        public FormularioPedidos()
        {
            InitializeComponent();
            _pedido = new NegocioPedido();
            _negproducto = new NegocioProducto();
            _articulo = new Articulo();
            _listArticulos = new List<Articulo>();
            _negLinped = new NegocioLinped();
            
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
         

            if (txtUsuarioID.Text.Trim().Length==0)
            {
                FormularioBusquedaUsuario frmBusqueda = new FormularioBusquedaUsuario();
                frmBusqueda.ShowDialog();

              if(frmBusqueda.DialogResult==DialogResult.OK)
                {
                    txtUsuarioID.Text= frmBusqueda.dataGridViewUsuarios.Rows[frmBusqueda.dataGridViewUsuarios.CurrentRow.Index].Cells[0].Value.ToString();
                    txtNombreArticulo.Focus();

                    pedido.UsuarioID = Convert.ToInt32(txtUsuarioID.Text.ToString());
                }
               
            }


        }

        private void FormularioPedidos_Load(object sender, EventArgs e)
        {
            _listArticulos = _negproducto.ObtenerArticulos();
             pedido = new Pedido();

        }

        public static int cont_filas = 0;
        public static decimal total;
        public static decimal totalConIva;
        public static decimal totalIva;


        private void BtnColocar_Click(object sender, EventArgs e)
        {
             

            if (Utilidades.ValidarFormulario(this,errorProvider1)==false)
            {
                List<Articulo> list = _listArticulos.Where(x => x.Nombre.ToUpper() == txtNombreArticulo.Text.ToUpper()).ToList();

                bool existe = false;
                int num_fila = 1;

                if(list.Count>0)
                {
                    if (cont_filas == 0)
                    {
                        dgvLinped.Rows.Add((cont_filas + 1).ToString(), list[0].ArticuloID.ToString(), txtPrecioArticulo.Text, txtCantidadArticulo.Text);
                        decimal importe = Convert.ToDecimal(dgvLinped.Rows[cont_filas].Cells[2].Value) * Convert.ToDecimal(dgvLinped.Rows[cont_filas].Cells[3].Value);
                        dgvLinped.Rows[cont_filas].Cells[4].Value = importe;
                        li = new Linped(Convert.ToInt32(txtPedidoID.Text), num_fila, list[0].ArticuloID.ToString(), importe, Convert.ToInt32(dgvLinped.Rows[num_fila].Cells[3].Value));
                     
                        cont_filas++;
                        linpeds.Add(li);
                    }
                    else
                    {
                       

                        foreach (DataGridViewRow fila in dgvLinped.Rows)
                        {
                            if (fila.Cells[1].Value.ToString() == list[0].ArticuloID.ToString())
                            {
                                existe = true;
                                num_fila = fila.Index;
                            }
                        }

                        if (existe)
                        {
                            dgvLinped.Rows[num_fila].Cells[3].Value = (Convert.ToInt32(txtCantidadArticulo.Text) + Convert.ToInt32(dgvLinped.Rows[num_fila].Cells[3].Value)).ToString();
                            decimal importe = Convert.ToDecimal(dgvLinped.Rows[num_fila].Cells[2].Value) * Convert.ToDecimal(dgvLinped.Rows[num_fila].Cells[3].Value);
                            dgvLinped.Rows[num_fila].Cells[4].Value = importe;

                            li = new Linped(Convert.ToInt32(txtPedidoID.Text), num_fila+1, list[0].ArticuloID.ToString(), importe, Convert.ToInt32(dgvLinped.Rows[num_fila].Cells[3].Value));

                            linpeds.RemoveAt(num_fila);
                            linpeds.Insert(num_fila, li);

                           

                        }
                        //no existe
                        else
                        {
                            dgvLinped.Rows.Add((cont_filas + 1).ToString(), list[0].ArticuloID.ToString(), txtPrecioArticulo.Text, txtCantidadArticulo.Text);
                            decimal importe = Convert.ToDecimal(dgvLinped.Rows[cont_filas].Cells[2].Value) * Convert.ToDecimal(dgvLinped.Rows[cont_filas].Cells[3].Value);
                            dgvLinped.Rows[cont_filas].Cells[2].Value = importe;
                            cont_filas++;

                            li = new Linped(Convert.ToInt32(txtPedidoID.Text), num_fila+1, list[0].ArticuloID.ToString(), importe, Convert.ToInt32(dgvLinped.Rows[num_fila].Cells[3].Value));
                            linpeds.Add(li);
                        }

                       
                    }

                    // pedido.AddLinped(li);
                    pedido.Linpeds = linpeds;

                    decimal[] resumenFactura = new decimal[4];

                    resumenFactura = _pedido.Datosfactura( pedido);

                    total = resumenFactura[0];
                    totalIva = resumenFactura[1];
                    totalConIva = resumenFactura[2];

                    lbTotal.Text = total.ToString() + " €";
                    lbIva.Text = totalIva.ToString() + " €";
                    lbTotalIVa.Text = totalConIva.ToString() + " €";
                }
                else
                {
                    MessageBox.Show("No existe ese articulo");
                }                   
                

            }



        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {

            Reset();
                List<Pedido> pedidos = new List<Pedido>();
                pedidos = _pedido.ObtenerPedido();

                int ultimoPedido = pedidos.Last().PedidoID + 1;

                txtPedidoID.Text = ultimoPedido.ToString();              

          
            pedido.PedidoID =Convert.ToInt32( ultimoPedido.ToString());
            
          
        }

        private void Reset()
        {
            txtPedidoID.Text = "";
            txtUsuarioID.Text = "";
            txtNombreArticulo.Text = "";
            txtMarcaArticulo.Text = "";
            txtPrecioArticulo.Text = "";
            txtCantidadArticulo.Text = "";
            cont_filas = 0;
            lbTotal.Text = "0";
            lbIva.Text = "0";
            lbTotalIVa.Text = "0";
            total = 0;
            totalConIva = 0;
            totalIva = 0;

            dgvLinped.Rows.Clear();
            txtUsuarioID.Focus();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if(cont_filas>0)
            {
                total = total - Convert.ToDecimal(dgvLinped.Rows[dgvLinped.CurrentRow.Index].Cells[4].Value);
                lbTotal.Text = total.ToString();
                totalIva = total * 21 / 100;
                lbIva.Text = totalIva.ToString();
                lbTotalIVa.Text = (total + totalIva).ToString();

                dgvLinped.Rows.RemoveAt(dgvLinped.CurrentRow.Index);
                cont_filas--;
            }
        }

      

        private void Btnproducto_Click(object sender, EventArgs e)
        {
            FormularioBusquedaProducto formProducto = new FormularioBusquedaProducto(true);
            
            formProducto.ShowDialog();

            if(formProducto.DialogResult==DialogResult.OK)
            {
                txtNombreArticulo.Text = formProducto.dataGridViewArticulos.Rows[formProducto.dataGridViewArticulos.CurrentRow.Index].Cells[4].Value.ToString();
                txtMarcaArticulo.Text= formProducto.dataGridViewArticulos.Rows[formProducto.dataGridViewArticulos.CurrentRow.Index].Cells[6].Value.ToString();
                txtPrecioArticulo.Text= formProducto.dataGridViewArticulos.Rows[formProducto.dataGridViewArticulos.CurrentRow.Index].Cells[5].Value.ToString();
                txtCantidadArticulo.Focus();
            }
        }

        private void BtnBuscarPedido_Click(object sender, EventArgs e)
        {
            dgvLinped.Rows.Clear();

            txtPedidoID.Text = "";
            List<Linped> _lista = new List<Linped>();
            DataTable dt = new DataTable();
           // DataView dv = new DataView();

            FormularioBusquedaPedido formPedido = new FormularioBusquedaPedido();
            formPedido.ShowDialog();

            if (formPedido.DialogResult == DialogResult.OK)
            {
                txtPedidoID.Text = formPedido.dgvPedidos.Rows[formPedido.dgvPedidos.CurrentRow.Index].Cells[1].Value.ToString();
                txtUsuarioID.Text = formPedido.dgvPedidos.Rows[formPedido.dgvPedidos.CurrentRow.Index].Cells[2].Value.ToString();
                dateTimePicker1FechaPedido.Value = Convert.ToDateTime(formPedido.dgvPedidos.Rows[formPedido.dgvPedidos.CurrentRow.Index].Cells[3].Value);
                _lista = FormularioBusquedaPedido.lista;

                dt = Utilidades.ConvertToDataTable(_lista);

             

                 dt.Columns.Add("ImporteTotal", typeof(string));

                foreach (DataRow data in dt.Rows)
                {

                    data["ImporteTotal"] =Convert.ToDouble( data["Importe"].ToString())*Convert.ToDouble( data["Cantidad"].ToString());
                    dgvLinped.Rows.Add(data["Linea"].ToString(), data["ArticuloID"].ToString(),
                    data["Importe"].ToString(), data["Cantidad"].ToString(), data["ImporteTotal"].ToString());

                }

            









            }


        }
    }
}
