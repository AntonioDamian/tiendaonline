using Capa_entidades;
using MiLibreria;
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


namespace TiendaOnline
{
    public partial class FormularioInformeFactura : Form
    {
        Negocio _usuario;
        NegocioPedido _negPedido;
        List<Pedido> _listaPedidos = new List<Pedido>();

        public FormularioInformeFactura()
        {
            InitializeComponent();
            _usuario = new Negocio();
            _negPedido = new NegocioPedido();
            

        }

        private void btnBuscarFactura_Click(object sender, EventArgs e)
        {
            dataGridView1Pedido.Rows.Clear();

            List<Linped> _lista = new List<Linped>();


            DataTable dt = new DataTable();

            FormularioBusquedaPedido formPedido = new FormularioBusquedaPedido();
            formPedido.ShowDialog();

            if (formPedido.DialogResult == DialogResult.OK)
            {
                errorTxtnumeroPedido.Text = formPedido.dgvPedidos.Rows[formPedido.dgvPedidos.CurrentRow.Index].Cells[1].Value.ToString();
                errorUsuarioID.Text = formPedido.dgvPedidos.Rows[formPedido.dgvPedidos.CurrentRow.Index].Cells[2].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(formPedido.dgvPedidos.Rows[formPedido.dgvPedidos.CurrentRow.Index].Cells[3].Value);

                _lista = FormularioBusquedaPedido.lista;

             

                List<Usuario> usuarios = new List<Usuario>();
                usuarios = _usuario.ObtenerUsuarios();
                var result = usuarios.Where(x => x.UsuarioID == Convert.ToInt32(formPedido.dgvPedidos.Rows[formPedido.dgvPedidos.CurrentRow.Index].Cells[2].Value.ToString())).ToList();
             
                errorTxtnombre.Text = result[0].Nombre;
                errorTxtdireccion.Text = result[0].Calle;
                errorTxtlocalidad.Text = result[0].PuebloID;
                errorTxtDni.Text = result[0].Dni;
                
                dt = Utilidades.ConvertToDataTable(_lista);

                dt.Columns.Add("ImporteTotal", typeof(string));

                foreach (DataRow data in dt.Rows)
                {

                    data["ImporteTotal"] = Convert.ToDouble(data["Importe"].ToString()) * Convert.ToDouble(data["Cantidad"].ToString());
                    dataGridView1Pedido.Rows.Add(data["Linea"].ToString(), data["ArticuloID"].ToString(),
                    data["Importe"].ToString(), data["Cantidad"].ToString(), data["ImporteTotal"].ToString());

                }
            }
        }

        private void FormularioInformeFactura_Load(object sender, EventArgs e)
        {
            dataGridView1Pedido.AutoGenerateColumns = false;

            //Añadimos las columnas al grid
            dataGridView1Pedido.Columns.Add("linea", "Linea");
            dataGridView1Pedido.Columns.Add("articulo", "Articulo");
            dataGridView1Pedido.Columns.Add("cantidad", "Cantidad");
            dataGridView1Pedido.Columns.Add("importe", "IMPORTE BRUTO");
            dataGridView1Pedido.Columns.Add("importe total", "IMPORTE TOTAL");           
            dataGridView1Pedido.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1Pedido.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1Pedido.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1Pedido.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1Pedido.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1Pedido.Columns[3].DefaultCellStyle.Format = "0.00";
            dataGridView1Pedido.Columns[3].ReadOnly = true;
            dataGridView1Pedido.Columns[4].DefaultCellStyle.Format = "0.00";
            dataGridView1Pedido.Columns[4].ReadOnly = true;
        }


        private void GenerarFactura()
        {

            List<Linped> linpeds = new List<Linped>();

            Pedido pedido = new Pedido();

            pedido.UsuarioID = Convert.ToInt32(errorUsuarioID.Text);
            pedido.PedidoID = Convert.ToInt32(errorTxtnumeroPedido.Text);
            pedido.Fecha = dateTimePicker1.Value;

            Linped linped = new Linped();

            foreach (DataGridViewRow dv in dataGridView1Pedido.Rows)
            {

                if (!dv.IsNewRow)
                    linpeds.Add(new Linped
                    {
                Linea = Convert.ToInt32(dv.Cells[0].Value),
                ArticuloID = dv.Cells[1].Value.ToString(),
                Cantidad = Convert.ToInt32(dv.Cells[3].Value),
                Importe = Math.Round(Convert.ToDecimal(dv.Cells[2].Value), 2),
                PedidoID = Convert.ToInt32(errorTxtnumeroPedido.Text),
            }
                    );
               
                
            }

            pedido.Linpeds = linpeds;

            FacturaReporte facturaReporte = new FacturaReporte();
            facturaReporte.listaPedido.Add(pedido);
            facturaReporte.listaLinpeds = linpeds;
            facturaReporte.NombreRemitenteFactura = errorTxtnombre.Text;
            facturaReporte.DireccionRemitenteFactura = errorTxtdireccion.Text;
            facturaReporte.LocalidadRemitenteFactura = errorTxtlocalidad.Text;
            facturaReporte.DniRemitenteFactura = errorTxtDni.Text;
            facturaReporte.Show();


        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            GenerarFactura();
        }
    }
}
