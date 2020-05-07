using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Capa_negocio;
using Capa_entidades;
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
        DataView dv;

        Dictionary<int,string> especi;



        private int indice;
        int posicionFila = 0;

        private TableLayoutPanel panelDatos;
        private TableLayoutPanel panelEspecificaciones;



        TextBox temp;
        ComboBox comboTipo;
        bool activotext = false, activocombo = false;

        int tipoArticulo = 0;

        TextBox[] t;
        TextBox[] te;
        private bool IsEditar = false;


        

        //limpiar controles

        private void Limpiar()
        {
           
            foreach (TextBox c in this.t)
            {
                c.Text = string.Empty;
            }

            foreach (TextBox c in this.te)
            {
                c.Text = string.Empty;
            }
          

            comboFiltro.SelectedIndex = -1;
           
            labelFiltro.Enabled = false;
            labelFiltro.Visible = false;
          
        }

      

        private void Botones()
        {
            if ( this.IsEditar)
            {
                           
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = true;

            }
            else
            {
                            
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        public FormularioBusquedaProducto(bool habilitar)
        {
            InitializeComponent();

            dt = new DataTable();
            dv = new DataView();
            _neg = new NegocioProducto();
            _negTipo = new NegociotipoArticulo();
            _negEspecificaciones = new NegocioEspecificaciones();

           
            if(habilitar==true)
            {
                btnSeleccionar.Enabled = true;
                btnSeleccionar.Visible = true;
            }
        }

        private void FormularioBusquedaProducto_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            temp = new TextBox();

            _ListaTipoArticulos = new List<TipoArticulo>();
            _ListaTipoArticulos = _negTipo.ObtenertiposArticulos();          

            especi = new Dictionary<int, string>();
            especi.Add(0, "null");

            foreach (TipoArticulo tp in _ListaTipoArticulos)
            {
                especi.Add(tp.TipoArticuloID, tp.Descripcion);
            }

          
            this.Botones();
            LlenarDataGridViewArticulos();
        }

        private void LlenarDataGridViewArticulos()
        {
            _listaArticulos = new List<Articulo>();
            _listaArticulos = _neg.ObtenerArticulos();


            dt = Utilidades.ConvertToDataTable(_listaArticulos);
            dv = new DataView(dt);

            dataGridViewArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewArticulos.DataSource = dt;

        }

      
    

        private void ComboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

            indice = comboFiltro.SelectedIndex;

            switch (indice)
            {
                case 0:
                    if (activotext == true)
                    {
                        temp.TextChanged -= new EventHandler(TextBusqueda_TextChanged);
                        tableLayoutPanel2.Controls.Remove(temp);
                        temp.Dispose();
                    }
                    if (activocombo == false)
                    {

                        labelFiltro.Enabled = true;
                        labelFiltro.Visible = true;

                        labelFiltro.Text = comboFiltro.SelectedItem.ToString();


                        comboTipo = new ComboBox();
                        comboTipo.Anchor = AnchorStyles.Left;
                        comboTipo.Name = "comboTipo";
                        comboTipo.Text = "Seleccione";
                        comboTipo.DataSource = new BindingSource(especi, null);
                       
                        comboTipo.DisplayMember = "Value";
                        comboTipo.ValueMember = "Key";


                        // comboTipo.DataSource = _ListaTipoArticulos;

                     /*   foreach (var li in _ListaTipoArticulos)
                        {
                            comboTipo.Items.Add(li.Descripcion);
                        }
                        comboTipo.Items.Insert(0, "null");*/

                        comboTipo.SelectedIndexChanged += new EventHandler(ComboTipo_SelectedIndexChanged);
                        tableLayoutPanel2.Controls.Add(comboTipo);
                        activocombo = true;
                        activotext = false;
                    }


                    break;
                case 1:
                    if (activocombo == true)
                    {
                        comboTipo.SelectedIndexChanged -= new EventHandler(ComboTipo_SelectedIndexChanged);
                        tableLayoutPanel2.Controls.Remove(comboTipo);
                        comboTipo.Dispose();
                    }
                    if (activotext == false)
                    {
                        labelFiltro.Enabled = true;
                        labelFiltro.Visible = true;
                        labelFiltro.Text = comboFiltro.SelectedItem.ToString();

                        temp = new TextBox();
                        temp.Width = 100;
                        temp.Height = 20;
                        temp.Anchor = AnchorStyles.Left;
                        temp.Name = "txtBusqueda";
                        temp.TextChanged += new EventHandler(TextBusqueda_TextChanged);
                        tableLayoutPanel2.Controls.Add(temp);
                        activotext = true;
                        activocombo = false;
                    }




                    break;
                default:

                   
                    comboTipo.SelectedIndexChanged -= new EventHandler(ComboTipo_SelectedIndexChanged);
                    tableLayoutPanel2.Controls.Remove(comboTipo);
                    comboTipo.Dispose();
                    activocombo = false;
                    temp.TextChanged -= new EventHandler(TextBusqueda_TextChanged);
                    tableLayoutPanel2.Controls.Remove(temp);
                    temp.Dispose();
                    activotext = false;
                    dataGridViewArticulos.DataSource = dt;
                    break;
            }


        }

        private void TextBusqueda_TextChanged(object sender, EventArgs e)
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


        private void ComboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

          
            int index = comboTipo.SelectedIndex;
            string t = comboTipo.SelectedItem.ToString();

            string tipo = comboTipo.SelectedValue.ToString();

          


            if (dv != null)
            {
                if (index != -1)
                {
                   
                    if (tipo !="0")
                    {
                        dv.RowFilter = String.Format(CultureInfo.InvariantCulture.NumberFormat,
                                           "TipoArticuloID = {0}", tipo);
                    }
                    if(tipo=="0")
                    {

                        dv.RowFilter = "TipoArticuloID IS NULL";

                        dataGridViewArticulos.DataSource = dv;
                    }


                    dataGridViewArticulos.DataSource = dv;

                }
                else
                {
                    dataGridViewArticulos.DataSource = dv;
                }


            }






        }

        private void DataGridViewArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            IsEditar = true;
            Botones();

            posicionFila = dataGridViewArticulos.CurrentRow.Index;

            string idArticulo = dataGridViewArticulos.CurrentRow.Cells["articuloID"].Value.ToString();

            CrearPanelDetallesArticulo();

            if (!string.IsNullOrEmpty(Convert.ToString((dataGridViewArticulos.CurrentRow.Cells["tipoArticuloID"].Value))))
            {

                tipoArticulo = Convert.ToInt32(dataGridViewArticulos.CurrentRow.Cells["tipoArticuloID"].Value.ToString());

          

                if (tipoArticulo == 1)
                {
                    List<Tv> listaTv = _negEspecificaciones.ObtenerTvEspecificacionesID(idArticulo);
                    dt = Utilidades.ConvertToDataTable(listaTv);
                }
                if (tipoArticulo == 2)
                {
                    List<Memoria> listamemo = _negEspecificaciones.ObtenerMemoriaEspecificacionesID(idArticulo);
                    dt = Utilidades.ConvertToDataTable(listamemo);
                }


                if (tipoArticulo == 3)
                {
                    List<Camara> listaCamara = _negEspecificaciones.ObtenerCamaraEspecificacionesID(idArticulo);
                    dt = Utilidades.ConvertToDataTable(listaCamara);
                }

                if (tipoArticulo == 4)
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
            int fila, col = 0;


            if (panelDatos != null)
            {
                groupBox1.Controls.Remove(panelDatos);
            }

            panelDatos = new TableLayoutPanel();
            panelDatos.Dock = DockStyle.Fill;
            panelDatos.ColumnCount = 4;           


            groupBox1.Controls.Add(panelDatos);


            fila = 1;
            col = 0;
            panelDatos.RowCount++;
            panelDatos.RowStyles.Add(new RowStyle(SizeType.AutoSize));



          /*  l[0] = new Label();
            l[0].Text = "Detalles del articulo";
            l[0].Font = new Font(l[0].Font, FontStyle.Bold);
            l[0].Width = 250;

            l[0].Parent = panelDatos;
            panelDatos.SetRow(l[0], 0);
            panelDatos.SetColumn(l[0], 1);
            panelDatos.SetColumnSpan(l[0], 2);
            l[0].TextAlign = ContentAlignment.MiddleCenter;*/

            for (int k = 1; k <= count; k++)
            {
                t[k - 1] = new TextBox();
              /*  if(k!=3)
                {
                    t[k - 1].ReadOnly = true;
                }*/

                t[k - 1].ReadOnly = true;

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

            te = new TextBox[count];
            Label[] l = new Label[count];
            int fila, col = 0;


            if (panelEspecificaciones != null)
            {
                groupBox2.Controls.Remove(panelEspecificaciones);
            }
            panelEspecificaciones = new TableLayoutPanel();
            panelEspecificaciones.Dock = DockStyle.Fill;
            panelEspecificaciones.ColumnCount = 4;

            groupBox2.Controls.Add(panelEspecificaciones);

            fila = 1;
            col = 0;
            panelEspecificaciones.RowCount++;
            panelEspecificaciones.RowStyles.Add(new RowStyle(SizeType.AutoSize));


            for (int k = 1; k <= count; k++)
            {

                te[k - 1] = new TextBox();
                te[k - 1].Enabled = false;
                te[k - 1].Text = dt.Rows[0][k - 1].ToString();
                te[k - 1].BackColor = Color.LightGreen;
                te[k - 1].Parent = panelEspecificaciones;
                panelEspecificaciones.SetRow(te[k - 1], fila);
                panelEspecificaciones.SetColumn(te[k - 1], col);

                l[k - 1] = new Label();
                l[k - 1].Text = dt.Columns[k - 1].ColumnName;
                l[k - 1].Font = new Font(l[k - 1].Font, FontStyle.Bold);
                l[k - 1].TextAlign = ContentAlignment.MiddleCenter;
                l[k - 1].Parent = panelEspecificaciones;
                panelEspecificaciones.SetRow(l[k - 1], fila);
                panelEspecificaciones.SetColumn(l[k - 1], col);

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




        }


        private void ComboFiltro_SelectedValueChanged(object sender, EventArgs e)
        {
            dataGridViewArticulos.DataSource = dt; 
        }

        private void Actualizar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            articulo.ArticuloID= t[0].Text.ToString();
            articulo.Nombre= t[1].Text.ToString();
            if (t[2].Text.ToString().Length==0)
            {
                articulo.Pvp = null;
            }
            else
            {
                articulo.Pvp = Convert.ToDecimal(t[2].Text.ToString());
            }
          

            articulo.MarcaID= t[3].Text.ToString();

            if (t[4].Text.ToString().Length == 0)
            {
                articulo.Imagen = null;
            }
            else
            {
                articulo.Imagen = Encoding.ASCII.GetBytes(t[4].Text.ToString());
            }

            articulo.Urlimagen= t[5].Text.ToString();
            articulo.Especificaciones= t[6].Text.ToString();
            articulo.TipoArticuloID=Convert.ToInt32( t[7].Text.ToString());          


           if( _neg.Actualizar(articulo))
            {
                MessageBox.Show("Se ha actualizado correctamente el articulo");

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

       

        private void BtnSeleccionar_Click(object sender, EventArgs e)
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

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (!this.t[0].Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                t[2].ReadOnly = false;
                t[2].BackColor = Color.Maroon;
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el articulo");
            }
        }

      

        //Mostrar mensaje de confirmación

        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Apitienda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
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

            if (_neg.Actualizar(articulo))
            {
             
                MensajeOK("Se ha actualizado correctamnete el articulo");

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
              
                MensajeError("No  se ha actualizado correctamnete el articulo");
            }

            this.IsEditar = false;
            this.Botones();
            Limpiar();
            LlenarDataGridViewArticulos();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
           
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            t[2].ReadOnly = true;
            t[2].BackColor = Color.LightGreen;
        }

        //Mostrar mensaje de error

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Apitienda", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }





    }
}

