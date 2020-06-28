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

namespace TiendaOnline
{
    public partial class FormularioBusquedaPedido : Form
    {

        NegocioPedido _negPedido;
        List<Pedido> _ListPedidos;

        NegocioLinped _negLinped;
        List<Linped> _listLinpeds;
 
        

        DataTable dt;
        DataView dv;
        public FormularioBusquedaPedido()
        {
            InitializeComponent();

            _negPedido = new NegocioPedido();
            _negLinped = new NegocioLinped();
            dt = new DataTable();
            dv = new DataView();

        }

        private void FormularioBusquedaPedido_Load(object sender, EventArgs e)
        {
            _listLinpeds = new List<Linped>();
            _listLinpeds = _negLinped.ObtenerLinped();
          


            LlenarDataGridViewPedidos();

           
        }

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

            dt = ConvertToDataTable(_ListPedidos);
            dv = new DataView(dt);

            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvPedidos.DataSource = dt;

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

        public static List<Linped> lista = new List<Linped>();

        private void btnSeleccionar_Click(object sender, EventArgs e)
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
                   
                        if (_ListPedidos[i].PedidoID.ToString() == dgvPedidos.Rows[dgvPedidos.CurrentRow.Index].Cells[1].Value.ToString())
                        {
                        lista = _ListPedidos[i].Linpeds;
                        }
                  
                }

               


                Close();
            }
        }
    }
}
