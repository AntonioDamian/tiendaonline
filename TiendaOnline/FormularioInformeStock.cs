using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_entidades;
using Capa_negocio;
using MiLibreria;

namespace TiendaOnline
{
    public partial class FormularioInformeStock : Form
    {
        NegocioProducto _negProducto;
        NegocioStock _negStock;
        List<Articulo> listArticulos = new List<Articulo>();
        List<Stock> listStock = new List<Stock>();
        List<Stock> lista;
        List<Articulo> art;





        public FormularioInformeStock()
        {
            InitializeComponent();
            _negProducto = new NegocioProducto();
            _negStock = new NegocioStock();

        }

        private void FormularioInformeStock_Load(object sender, EventArgs e)
        {
            listArticulos = _negProducto.ObtenerArticulos();
            listStock = _negStock.ObtenerStocks();

            listStock = listStock.OrderBy(x => x.Disponible).ToList();

            numericUpDown1.Maximum = Convert.ToDecimal(listStock.Last().Disponible);

            dgvStock.AutoGenerateColumns = false;
            dgvStock.Columns.Add("ColumnArticuloID", "ArticuloId");
            dgvStock.Columns.Add("ColumNombre", "Nombre");
            dgvStock.Columns.Add("ColumMarca", "Marca");           
            dgvStock.Columns.Add("ColumnDisponible", "Disponible");
            dgvStock.Columns.Add("ColumnEntrega", "Entrega");
            dgvStock.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvStock.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvStock.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvStock.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvStock.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           
            dgvStock.Columns[0].ReadOnly = true;
            dgvStock.Columns[1].ReadOnly = true;
            dgvStock.Columns[2].ReadOnly = true;
            dgvStock.Columns[3].ReadOnly = true;
            dgvStock.Columns[4].ReadOnly = true;
           

        }

      //  List<object> prueba;

        private void btnMostrar_Click(object sender, EventArgs e)
        {

            dgvStock.Rows.Clear();

            lista = new List<Stock>();
            decimal valor = numericUpDown1.Value;
            lista = listStock.FindAll(x => x.Disponible < valor).ToList();

            art = new List<Articulo>();
            Articulo articulo = new Articulo();         

            foreach(Stock item in lista)
            {
                articulo = listArticulos.Find(x => x.ArticuloID == item.ArticuloID);
                art.Add(articulo);
            }

           var result = (from articulos in listArticulos join stock in lista on articulos.ArticuloID equals stock.ArticuloID
                        // select (stock.ArticuloID, articulos.Nombre,articulo.MarcaID,stock.Disponible, stock.Entrega));
                          select new { Articulo = articulos, Stock = stock });


            /*    DataTable dt = new DataTable();
                dt.Columns.Add("Nombre", typeof(string));
                dt.Columns.Add("Marca", typeof(string));
                dt.Columns.Add("ArticuloID", typeof(string));
                dt.Columns.Add("Disponible", typeof(string));
                dt.Columns.Add("Entrega", typeof(string));




                dt = Utilidades.ToDataTable(result);
                dgvStock.DataSource = dt;*/

            List<object>  prueba = new List<object>();
           

         
            foreach (var item in result)
            {
                dgvStock.Rows.Add(item.Stock.ArticuloID, item.Articulo.Nombre, item.Articulo.MarcaID, item.Stock.Disponible, item.Stock.Entrega);
               
                
                prueba.Add(item);
            }

          

            //ordenar
            dgvStock.Sort(dgvStock.Columns["ColumnArticuloID"], ListSortDirection.Ascending);




        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            List<Articulo> articulos = new List<Articulo>();

            List<Stock> stock = new List<Stock>();

            
           

            StockReporte streporte = new StockReporte();
            streporte.listaStock = lista;
            streporte.articulos = art;
            streporte.Show();

        }
    }
}
