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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using System.Globalization;
using MiLibreria;

namespace TiendaOnline
{
    public partial class FormularioBusquedaProducto : Form

    {
        NegocioProducto _neg;
        NegociotipoArticulo _negTipo;
        NegocioEspecificaciones _negEspecificaciones;

        List<Articulo> _listaArticulos;
        List<TipoArticulo> _ListaTipoArticulos;
        DataTable dt;
        DataTable aux = new DataTable();

        Dictionary<int, string> especi;



        private int indice;
        int posicionFila = 0;

        private TableLayoutPanel panelDatos;
        private TableLayoutPanel panelEspecificaciones;



        TextBox temp;
        ComboBox comboTipo;
        bool activotext = false, activocombo = false;

        int tipoArticulo = 0;

        TextBox[] t;

        public FormularioBusquedaProducto( string opcion)
        {
            InitializeComponent();

            if("Pedido"==opcion)
            {
                btnActualizar.Enabled = false;
                btnActualizar.Visible = false;
            }

            dt = new DataTable();
         
            _neg = new NegocioProducto();
            _negTipo = new NegociotipoArticulo();
            _negEspecificaciones = new NegocioEspecificaciones();

        }

        private void FormularioBusquedaProducto_Load(object sender, EventArgs e)
        {
           // _listaArticulos = new List<Articulo>();
          //  _listaArticulos = _neg.ObtenerArticulos();

            _ListaTipoArticulos = new List<TipoArticulo>();
            _ListaTipoArticulos = _negTipo.ObtenertiposArticulos();

            LlenarDataGridViewArticulos();


       /*     dt = ConvertToDataTable(_listaArticulos);
            dv = new DataView(dt);

            dataGridViewArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewArticulos.DataSource = dt;*/


            especi = new Dictionary<int, string>();
            especi.Add(-1, "Seleccione");
            especi.Add(0, "null");

            foreach (TipoArticulo tp in _ListaTipoArticulos)
            {
                especi.Add(tp.TipoArticuloID, tp.Descripcion);
            }


        }

        private void LlenarDataGridViewArticulos()
        {
            _listaArticulos = new List<Articulo>();
            _listaArticulos = _neg.ObtenerArticulos();

            
           


          //  dt = Utilidades.ConvertToDataTable(_listaArticulos);
          

            dt.Columns.Add("ArticuloID");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("MarcaID");
            dt.Columns.Add("Pvp");
            dt.Columns.Add("TipoArticulo");

            foreach (Articulo art in _listaArticulos)
            {
               
                dt.Rows.Add(new object[] { art.ArticuloID,art.Nombre,art.MarcaID,art.Pvp,art.TipoArticuloID});
            }

            dt.DefaultView.Sort = "ArticuloID";
           

            dataGridViewArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            aux = dt.Copy();
            dataGridViewArticulos.DataSource = dt;

        }


    

        private void comboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

            indice = comboFiltro.SelectedIndex;
          //  dataGridViewArticulos.DataSource = aux;

            switch (indice)
            {
               
                case 0:
                    if (activotext == true)
                    {
                        temp.TextChanged -= new EventHandler(textBusqueda_TextChanged);
                        tableLayoutPanel2.Controls.Remove(temp);
                        temp.Dispose();
                    }
                    if (activocombo == false)
                    {

                        labelFiltro.Text = comboFiltro.SelectedItem.ToString();
                        comboTipo = new ComboBox();
                        comboTipo.Anchor = AnchorStyles.Left;                    

                        comboTipo.DataSource = new BindingSource(especi, null);
                       
                        comboTipo.DisplayMember = "Value";
                        comboTipo.ValueMember = "Key";

                      

                        // comboTipo.DataSource = _ListaTipoArticulos;

                        /*   foreach (var li in _ListaTipoArticulos)
                           {
                               comboTipo.Items.Add(li.Descripcion);
                           }
                           comboTipo.Items.Insert(0, "null");*/

                        comboTipo.SelectedIndexChanged += new EventHandler(comboTipo_SelectedIndexChanged);
                        comboTipo.Name = "comboTipo";
                        comboTipo.Text = "Seleccione";
                        tableLayoutPanel2.Controls.Add(comboTipo);
                        activocombo = true;
                        activotext = false;
                    }


                    break;
                case 1:
                    if (activocombo == true)
                    {
                        comboTipo.SelectedIndexChanged -= new EventHandler(comboTipo_SelectedIndexChanged);
                        tableLayoutPanel2.Controls.Remove(comboTipo);
                        comboTipo.Dispose();
                    }
                    if (activotext == false)
                    {
                        labelFiltro.Text = comboFiltro.SelectedItem.ToString();

                        temp = new TextBox();
                        temp.Width = 100;
                        temp.Height = 20;
                        temp.Anchor = AnchorStyles.Left;
                        temp.Name = "txtBusqueda";
                        temp.TextChanged += new EventHandler(textBusqueda_TextChanged);
                        tableLayoutPanel2.Controls.Add(temp);
                        activotext = true;
                        activocombo = false;
                    }




                    break;
                default:

                   
                    comboTipo.SelectedIndexChanged -= new EventHandler(comboTipo_SelectedIndexChanged);
                    tableLayoutPanel2.Controls.Remove(comboTipo);
                    comboTipo.Dispose();
                    activocombo = false;
                    temp.TextChanged -= new EventHandler(textBusqueda_TextChanged);
                    tableLayoutPanel2.Controls.Remove(temp);
                    temp.Dispose();
                    activotext = false;
                    dataGridViewArticulos.DataSource = dt;
                    break;
            }


        }

        private void textBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (temp.Text != "")
            {


                if (indice == 1)
                {
                    dt.DefaultView.RowFilter = $"nombre like'{temp.Text}%'";
                }

            }
            else
            {
                dataGridViewArticulos.DataSource = dt;
                temp.Text = "";
            }
        }


        private void comboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

          
            int index = comboTipo.SelectedIndex;
            string t = comboTipo.SelectedItem.ToString();

            string tipo = comboTipo.SelectedValue.ToString();          


            if (dt != null)
            {
                if (index != -1)
                {
                   
                    if (tipo !="0")
                    {
                        dt.DefaultView.RowFilter = String.Format(CultureInfo.InvariantCulture.NumberFormat,
                                           "TipoArticulo = {0}", tipo);
                    }
                    if(tipo=="0")
                    {
                        dt.DefaultView.RowFilter = "TipoArticulo IS NULL";
                        dataGridViewArticulos.DataSource = dt;
                    }

                    dataGridViewArticulos.DataSource = dt;
                }
                else
                {
                    dataGridViewArticulos.DataSource = dt;
                }


            }
        }

        private void dataGridViewArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            posicionFila = dataGridViewArticulos.CurrentRow.Index;

            string idArticulo = dataGridViewArticulos.CurrentRow.Cells["articuloID"].Value.ToString();
            CrearPanelDetallesArticulo();

            if (!string.IsNullOrEmpty(Convert.ToString((dataGridViewArticulos.CurrentRow.Cells["TipoArticulo"].Value))))
            {

                tipoArticulo = Convert.ToInt32(dataGridViewArticulos.CurrentRow.Cells["TipoArticulo"].Value.ToString());          

                if (tipoArticulo == 1)
                {
                    List<Tv> listaTv = _negEspecificaciones.ObtenerTvEspecificacionesID(idArticulo);
                    dt = Utilidades.ConvertToDataTable(listaTv);
                }
                else if (tipoArticulo == 2)
                {
                    List<Memoria> listamemo = _negEspecificaciones.ObtenerMemoriaEspecificacionesID(idArticulo);
                    dt = Utilidades.ConvertToDataTable(listamemo);
                }
                else if (tipoArticulo == 3)
                {
                    List<Camara> listaCamara = _negEspecificaciones.ObtenerCamaraEspecificacionesID(idArticulo);
                    dt = Utilidades.ConvertToDataTable(listaCamara);
                }
                else if (tipoArticulo == 4)
                {
                    List<Objetivo> listaObjetivo = _negEspecificaciones.ObtenerObjetivoEspecificacionesID(idArticulo);
                    dt = Utilidades.ConvertToDataTable(listaObjetivo);
                }

               
                CrearPanelEspecificaciones(dt);
            }
        }

        private void CrearPanelDetallesArticulo()
        {

            int count = dataGridViewArticulos.ColumnCount;

            t= new TextBox[count];
            Label[] l = new Label[count + 1];


            if (panelDatos != null)
            {
                splitContainer1.Panel1.Controls.Remove(panelDatos);
            }

            panelDatos = new TableLayoutPanel();
            panelDatos.Size = new Size(750, 150);
            panelDatos.ColumnCount = 4;


            /*  Label titulo = new Label();
              titulo.Text = "Detalles del articulo";           
              titulo.Parent = panelDatos;*/


            splitContainer1.Panel1.Controls.Add(panelDatos);


            int fila = 1;
            int col = 0;
            panelDatos.RowCount++;
            panelDatos.RowStyles.Add(new RowStyle(SizeType.AutoSize));



            l[0] = new Label();
            l[0].Text = "Detalles del articulo";
            l[0].Font = new Font(l[0].Font, FontStyle.Bold);
            l[0].Width = 250;

            l[0].Parent = panelDatos;
            panelDatos.SetRow(l[0], 0);
            panelDatos.SetColumn(l[0], 1);
            panelDatos.SetColumnSpan(l[0], 2);
            l[0].TextAlign = ContentAlignment.MiddleCenter;

            for (int k = 1; k <= count; k++)
            {
                t[k - 1] = new TextBox();
                if(k!=3)
                {
                    t[k - 1].ReadOnly = true;
                }

                t[k - 1].Text = dataGridViewArticulos.CurrentRow.Cells[k - 1].Value.ToString();
                t[k - 1].BackColor = Color.LightGreen;
                t[k - 1].Width = 150;
                t[k - 1].Parent = panelDatos;
                panelDatos.SetRow(t[k - 1], fila);
                panelDatos.SetColumn(t[k - 1], col);

                l[k] = new Label();
                l[k].Text = dataGridViewArticulos.Columns[k - 1].HeaderText;
                l[k].Font = new Font(l[k].Font, FontStyle.Bold);
                l[k].TextAlign = ContentAlignment.MiddleCenter;
                l[k].Parent = panelDatos;
                panelDatos.SetRow(l[k], fila);
                panelDatos.SetColumn(l[k], col);

                if (col == 4)
                {
                    col = 0;
                    fila++;
                    panelDatos.RowCount = panelDatos.RowCount + 1;
                    panelDatos.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }
                else
                    col++;
            }


        }
        private void CrearPanelEspecificaciones(DataTable dt)
        {
            int count = dt.Columns.Count;

            TextBox[] t = new TextBox[count];
            Label[] l = new Label[count+1];
          


            if (panelEspecificaciones != null)
            {
                splitContainer1.Panel2.Controls.Remove(panelEspecificaciones);
            }

            panelEspecificaciones = new TableLayoutPanel();
            panelEspecificaciones.Size = new Size(750, 150);
            panelEspecificaciones.ColumnCount = 4;

            splitContainer1.Panel2.Controls.Add(panelEspecificaciones);

            int fila = 1;
            int col = 0;
            panelEspecificaciones.RowCount++;
            panelEspecificaciones.RowStyles.Add(new RowStyle(SizeType.AutoSize));

          

            l[0] = new Label();
            l[0].Text = "Especificaciones adicionales del articulo";
            l[0].Font = new Font(l[0].Font, FontStyle.Bold);
            l[0].Width = 250;

            l[0].Parent = panelEspecificaciones;
            panelEspecificaciones.SetRow(l[0], 0);
            panelEspecificaciones.SetColumn(l[0], 1);
            panelEspecificaciones.SetColumnSpan(l[0], 2);
            l[0].TextAlign = ContentAlignment.MiddleCenter;


            for (int k = 1; k <= count; k++)
            {

                t[k - 1] = new TextBox();
                t[k - 1].Enabled = false;
                t[k - 1].Text = dt.Rows[0][k - 1].ToString();
                t[k - 1].BackColor = Color.LightGreen;
                t[k - 1].Parent = panelEspecificaciones;
                panelEspecificaciones.SetRow(t[k - 1], fila);
                panelEspecificaciones.SetColumn(t[k - 1], col);

                l[k] = new Label();
                l[k].Text = dt.Columns[k - 1].ColumnName;
                l[k].Font = new Font(l[k].Font, FontStyle.Bold);
                l[k].TextAlign = ContentAlignment.MiddleCenter;
                l[k].Parent = panelEspecificaciones;
                panelEspecificaciones.SetRow(l[k], fila);
                panelEspecificaciones.SetColumn(l[k], col);

                if (col == 4)
                {
                    col = 0;
                    fila++;
                    panelEspecificaciones.RowCount = panelEspecificaciones.RowCount + 1;
                    panelEspecificaciones.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }
                else
                    col++;
            }


          /*  Label titulo = new Label();
            titulo.Width = 100;
            titulo.Text = "Especificaciones adicionales del articulo";
            titulo.Parent = panelEspecificaciones;*/

        }

        private void comboFiltro_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridViewArticulos.DataSource = aux; 
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();        

            if(t!=null)
            {
                articulo.ArticuloID = t[0].Text.ToString();
                articulo.Nombre = t[1].Text.ToString();
                if (t[2].Text.ToString().Length == 0)
                {
                    articulo.Pvp = null;
                }
                else
                {
                    articulo.Pvp = Convert.ToDecimal(t[2].Text.ToString());
                }


                articulo.MarcaID = t[3].Text.ToString();

                if (t[4].Text.ToString().Length == 0)
                {
                    articulo.Imagen = null;
                }
                else
                {
                    articulo.Imagen = Encoding.ASCII.GetBytes(t[4].Text.ToString());
                }

                articulo.Urlimagen = t[5].Text.ToString();
                articulo.Especificaciones = t[6].Text.ToString();
                articulo.TipoArticuloID = Convert.ToInt32(t[7].Text.ToString());

                /*  articulo = new Articulo(t[0].Text.ToString(), t[1].Text.ToString(), Convert.ToDecimal(t[2].Text.ToString()), t[3].Text.ToString(), Encoding.ASCII.GetBytes( t[4].Text.ToString()),
                      t[5].Text.ToString(),
                       t[6].Text.ToString(),Convert.ToInt32( t[7].Text.ToString()));*/




                if (_neg.Actualizar(articulo))
                {
                    MessageBox.Show("Se ha actualizado correctamnete el articulo");

                    if (t[2].Text.ToString().Length == 0)
                    {
                        dataGridViewArticulos[2, posicionFila].Value = DBNull.Value;
                    }
                    else
                    {
                        dataGridViewArticulos[2, posicionFila].Value = Convert.ToDecimal(t[2].Text.ToString());
                    }


                }
                else
                {
                    MessageBox.Show("No  se ha actualizado correctamnete el articulo");
                }
            }
            else
            {
                MessageBox.Show("Nimgun Articulo a actualizar");
            }

         

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dataGridViewArticulos.Rows.Count == 0)
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

