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
using Microsoft.SqlServer.Server;

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

        List<Linped> _lista; //lista aux que utilizaremos cuando carguemos un pedido buscado

        public  int cont_filas = 0;
        int num_fila = 0;

        decimal total=0;
        decimal totalConIva=0;
        decimal totalIva=0;

        




        public FormularioPedidos()
        {
            InitializeComponent();
            _pedido = new NegocioPedido();
            _negproducto = new NegocioProducto();
            _articulo = new Articulo();
            _listArticulos = new List<Articulo>();
            _negLinped = new NegocioLinped();
            
        }

        private void FormularioPedidos_Load(object sender, EventArgs e)
        {
            _listArticulos = _negproducto.ObtenerArticulos();
            pedido = new Pedido();

            dgvLinped.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

          
            btnActualizar.Enabled = false;
            btnEliminarPedido.Enabled = false;
            btnGuardar.Enabled = false;


        }

        private void BtnBuscarUsuario_Click(object sender, EventArgs e)
        {
         

            if (txtUsuarioID.Text.Trim().Length==0)
            {
                FormularioBusquedaUsuario frmBusqueda = new FormularioBusquedaUsuario("Pedido");
               
                frmBusqueda.ShowDialog();

              if(frmBusqueda.DialogResult==DialogResult.OK)
                {
                    txtUsuarioID.Text= frmBusqueda.dataGridViewUsuarios.Rows[frmBusqueda.dataGridViewUsuarios.CurrentRow.Index].Cells[0].Value.ToString();
                    txtNombreArticulo.Focus();

                    pedido.UsuarioID = Convert.ToInt32(txtUsuarioID.Text.ToString());
                }
               
            }


        }

        private void btnColocar_Click(object sender, EventArgs e)
        {
             

            if (txtPedidoID.Text!=""&& txtUsuarioID.Text!="")
            {
                List<Articulo> list = _listArticulos.Where(x => x.Nombre.ToUpper() == txtNombreArticulo.Text.ToUpper()).ToList();

                bool existe = false;
              

                if(list.Count>0)
                {
                    if (cont_filas == 0)
                    {
                        dgvLinped.Rows.Add((cont_filas + 1).ToString(), list[0].ArticuloID.ToString(), txtPrecioArticulo.Text, txtCantidadArticulo.Text);
                        // decimal importe = Convert.ToDecimal(dgvLinped.Rows[cont_filas].Cells[2].Value) * Convert.ToDecimal(dgvLinped.Rows[cont_filas].Cells[3].Value);
                        decimal importe = Convert.ToDecimal(txtPrecioArticulo.Text) * Convert.ToDecimal(txtCantidadArticulo.Text);
                        dgvLinped.Rows[cont_filas].Cells[4].Value = importe;

                        li = new Linped(Convert.ToInt32(txtPedidoID.Text), num_fila+1, list[0].ArticuloID.ToString(), Convert.ToDecimal(txtPrecioArticulo.Text), Convert.ToInt32(dgvLinped.Rows[num_fila].Cells[3].Value));
                     
                        cont_filas++;
                        linpeds.Add(li);
                        pedido.Linpeds = linpeds;
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

                            li = new Linped(Convert.ToInt32(txtPedidoID.Text), num_fila+1, list[0].ArticuloID.ToString(),Convert.ToDecimal( txtPrecioArticulo.Text), Convert.ToInt32(dgvLinped.Rows[num_fila].Cells[3].Value));

                            linpeds.RemoveAt(num_fila);
                            linpeds.Insert(num_fila, li);

                            /*   _negLinped.Actualizar(li);

                               if(_negLinped.Actualizar(li))
                               {
                                   li = linpeds.FirstOrDefault(x => x.Linea == num_fila+1);

                                   if (li != null)
                                   {
                                       linpeds.RemoveAt(num_fila);
                                       linpeds.Insert(num_fila, li);
                                   }
                               }*/

                        }
                        else
                        {
                            dgvLinped.Rows.Add((cont_filas + 1).ToString(), list[0].ArticuloID.ToString(), txtPrecioArticulo.Text, txtCantidadArticulo.Text);
                           // decimal importe = Convert.ToDecimal(dgvLinped.Rows[cont_filas].Cells[2].Value) * Convert.ToDecimal(dgvLinped.Rows[cont_filas].Cells[3].Value);
                            decimal importe = Convert.ToDecimal(txtPrecioArticulo.Text) * Convert.ToDecimal(txtCantidadArticulo.Text);
                            dgvLinped.Rows[cont_filas].Cells[4].Value = importe;
                            cont_filas++;

                            li = new Linped(Convert.ToInt32(txtPedidoID.Text), num_fila+1, list[0].ArticuloID.ToString(), Convert.ToDecimal(txtPrecioArticulo.Text), Convert.ToInt32(dgvLinped.Rows[num_fila].Cells[3].Value));
                            linpeds.Add(li);
                            pedido.Linpeds = linpeds;
                        }

                       
                    }

                    // pedido.AddLinped(li);
                  //  pedido.Linpeds = linpeds;

                    decimal[] resumenFactura = new decimal[3];

                    resumenFactura = _pedido.Datosfactura( pedido,21);

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
            else
            {
                MessageBox.Show("Debe crear un nuevo pedido y/o añdir un usario al pedido");
            }



        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
         
                List<Pedido> pedidos = new List<Pedido>();
                pedidos = _pedido.ObtenerPedido();

                int ultimoPedido = pedidos.Last().PedidoID + 1;

                txtPedidoID.Text = ultimoPedido.ToString();

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

          
            pedido.PedidoID =Convert.ToInt32( ultimoPedido.ToString());

            btnGuardar.Enabled = true;
            
          
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if(cont_filas==1)
            {
                linpeds.RemoveAt(dgvLinped.CurrentRow.Index);
                pedido.Linpeds = linpeds;
                dgvLinped.Rows.RemoveAt(dgvLinped.CurrentRow.Index);
              
               

                total = 0;
                lbTotal.Text = "0";
                totalIva = 0;
                lbIva.Text = totalIva.ToString();
                lbTotalIVa.Text = (total + totalIva).ToString();

              
                cont_filas--;
            }
            if(cont_filas>1)
            {
                linpeds.RemoveAt(dgvLinped.CurrentRow.Index);
                pedido.Linpeds = linpeds;
                dgvLinped.Rows.RemoveAt(dgvLinped.CurrentRow.Index);              
                total = total - Convert.ToDecimal(dgvLinped.Rows[dgvLinped.CurrentRow.Index].Cells[4].Value);
                lbTotal.Text = total.ToString();
                totalIva = total * 21 / 100;
                lbIva.Text = totalIva.ToString();
                lbTotalIVa.Text = (total + totalIva).ToString();


                cont_filas--;
            }
        }      

        private void btnproducto_Click(object sender, EventArgs e)
        {
            txtCantidadArticulo.Text = "0";
            
            FormularioBusquedaProducto formProducto = new FormularioBusquedaProducto("Pedido");
            formProducto.ShowDialog();

            if(formProducto.DialogResult==DialogResult.OK)
            {
                txtNombreArticulo.Text = formProducto.dataGridViewArticulos.Rows[formProducto.dataGridViewArticulos.CurrentRow.Index].Cells[1].Value.ToString();
                txtMarcaArticulo.Text= formProducto.dataGridViewArticulos.Rows[formProducto.dataGridViewArticulos.CurrentRow.Index].Cells[2].Value.ToString();
                txtPrecioArticulo.Text= formProducto.dataGridViewArticulos.Rows[formProducto.dataGridViewArticulos.CurrentRow.Index].Cells[3].Value.ToString();
                txtCantidadArticulo.Focus();
            }
        }

        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            dgvLinped.Rows.Clear();

            btnActualizar.Enabled = true;
            btnEliminarPedido.Enabled = true;

            dgvLinped.ReadOnly = false;
          
            txtPedidoID.Text = "";
            LimpiarDatosPedido();

            _lista = new List<Linped>();
            DataTable dt = new DataTable();
        
            FormularioBusquedaPedido formPedido = new FormularioBusquedaPedido("pedido");
            formPedido.ShowDialog();

            if (formPedido.DialogResult == DialogResult.OK)
            {
                int pedID = Convert.ToInt32(formPedido.dgvPedidos.Rows[formPedido.dgvPedidos.CurrentRow.Index].Cells[0].Value.ToString());
                int usuID = Convert.ToInt32(formPedido.dgvPedidos.Rows[formPedido.dgvPedidos.CurrentRow.Index].Cells[1].Value.ToString());

                txtPedidoID.Text = pedID.ToString();
                txtUsuarioID.Text = usuID.ToString();
               // dateTimePicker1FechaPedido.Value = Convert.ToDateTime(formPedido.dgvPedidos.Rows[formPedido.dgvPedidos.CurrentRow.Index].Cells[2].Value);
                dateTimePicker1FechaPedido.Value = DateTime.Today;
                _lista = FormularioBusquedaPedido.lista;

                cont_filas = _lista.Count();
                num_fila = _lista.Count();
                dt = Utilidades.ConvertToDataTable(_lista);            

                dt.Columns.Add("ImporteTotal", typeof(string));

                foreach (DataRow data in dt.Rows)
                {

                    data["ImporteTotal"] =Convert.ToDouble( data["Importe"].ToString())*Convert.ToDouble( data["Cantidad"].ToString());
                    dgvLinped.Rows.Add(data["Linea"].ToString(), data["ArticuloID"].ToString(),
                    data["Importe"].ToString(), data["Cantidad"].ToString(), data["ImporteTotal"].ToString());

                }

                linpeds.AddRange(_lista);
                   


                decimal[] resumenFactura = new decimal[4];

                resumenFactura = _pedido.Datosfactura(FormularioBusquedaPedido._pedidoeleguido[0], 21);

                total = resumenFactura[0];
                totalIva = resumenFactura[1];
                totalConIva = resumenFactura[2];

                lbTotal.Text = total.ToString() + " €";
                lbIva.Text = totalIva.ToString() + " €";
                lbTotalIVa.Text = totalConIva.ToString() + " €";

                

            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
          
            if(txtPedidoID.Text!="")
            {
                int totalLinped = 0;
                bool correcto = false;
             
                

                if (_pedido.NuevoPedido(Convert.ToInt32(txtPedidoID.Text), Convert.ToInt32(txtUsuarioID.Text),dateTimePicker1FechaPedido.Value.Date, linpeds) == true)
                {
                    correcto = true;
                }
                else
                {
                    MessageBox.Show(string.Format("Problemas al guardar  el pedido {0}", txtPedidoID.Text),"Errror",MessageBoxButtons.OK);
                }

                if(correcto==true)
                {
                    foreach (Linped li in linpeds)
                    {

                        if (_negLinped.NuevoLinped(li.PedidoID, li.Linea, li.ArticuloID, li.Importe, li.Cantidad))
                        {
                            totalLinped++;
                        }

                    }

                    if (totalLinped == linpeds.Count)
                    {
                        MessageBox.Show(string.Format("Se ha guardado correctamente el pedido {0}", txtPedidoID.Text), "Confirmación", MessageBoxButtons.OK);
                    }
                }

              
               

            }
            else
            {
                MessageBox.Show("Debe crrear un  nuevo pedido");
            }

          

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int totalLinped = 0;
            bool correcto = false;

          
                if (_pedido.Actualizar(new Pedido(Convert.ToInt32(txtPedidoID.Text), Convert.ToInt32(txtUsuarioID.Text), dateTimePicker1FechaPedido.Value.Date, linpeds)) == true)
                {
                    correcto = true;
                }
                else
                {
                    MessageBox.Show(string.Format("Problemas al actualizar  el pedido {0}", txtPedidoID.Text), "Errror", MessageBoxButtons.OK);
                }

                if (correcto == true)
                {
                    foreach (Linped li in linpeds)
                    {

                        if (_negLinped.Actualizar(new Linped(li.PedidoID, li.Linea, li.ArticuloID, li.Importe, li.Cantidad)))
                        {
                            totalLinped++;
                        }

                    }

                    if (totalLinped == linpeds.Count)
                    {
                        MessageBox.Show(string.Format("Se ha actualizado correctamente el pedido {0}", txtPedidoID.Text), "Confirmación", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Problemas al actualizar  el pedido {0} ,no se han guardado los linpeds", txtPedidoID.Text), "Errror", MessageBoxButtons.OK);
                    }
                }
        
           

         
        }


      


        private void LimpiarDatosPedido()
        {
            txtUsuarioID.Text = "";
            txtNombreArticulo.Text = "";
            txtMarcaArticulo.Text = "";
            txtPrecioArticulo.Text = "";
            txtCantidadArticulo.Text = "";
            lbTotal.Text = "0";
            lbIva.Text = "0";
            lbTotalIVa.Text = "0";
        }

        private void BtnEliminarPedido_Click(object sender, EventArgs e)
        {

            if(_pedido.Borrar(Convert.ToInt32(txtPedidoID.Text))==true)
            {
                MessageBox.Show(string.Format("Eliminado el pedido {0}", txtPedidoID.Text), "Confirmación", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(string.Format("Problemas al eliminar  el pedido {0}", txtPedidoID.Text), "Errror", MessageBoxButtons.OK);
            }
        }
    }
}

