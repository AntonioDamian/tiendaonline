using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaOnline
{
    public partial class FormularioPrincipal : Form
    {

        DateTime inicioAplicacion = DateTime.MinValue;
        TimeSpan tiempoTranscurrido;


        public FormularioPrincipal(string nombreUsuario)
        {
            InitializeComponent();
            this.Text = "Usuario: " + nombreUsuario;

          
            this.Update();
           // this.FormClosing += FormularioPrincipal_FormClosing;
            toolStripMenuMostrar.Visible = false;
            toolStripMenuOcultar.Visible = true;

        }

        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void FormularioPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea salir de la aplicación?",
               "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
               // Application.Exit();
            }
        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {

            inicioAplicacion = DateTime.Now;
        }

        private void Salir(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea salir de la aplicación?",
               "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
             // Application.Exit();
                Environment.Exit(0);

               
            }
               
          
                 
        }

        private void MantenimientoUsuarios(object sender, EventArgs e)
        {
            MantenimientoUsuarios mantenimiento = new MantenimientoUsuarios()
            {
                MdiParent = this
            };
            mantenimiento.WindowState = FormWindowState.Maximized;
            mantenimiento.Show();         

        }


        private void InsertarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormularioNuevoUsuario añadir = new FormularioNuevoUsuario()
            {
                MdiParent = this
            };
            añadir.WindowState = FormWindowState.Maximized;
            añadir.Show();
        }

        private void ModificarEliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

           FormularioBusquedaUsuario busqueda=new FormularioBusquedaUsuario()
            {
                MdiParent = this
            };
            busqueda.WindowState = FormWindowState.Maximized;
            busqueda.Show();
        }

        private void ConsultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormularioBusquedaProducto busquedaProducto = new FormularioBusquedaProducto(false)
            {
                MdiParent = this
              }; 
            busquedaProducto.WindowState = FormWindowState.Maximized;
            busquedaProducto.Show();
               
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormularioPedidos pedidos = new FormularioPedidos()
            {
                MdiParent = this
            };
            pedidos.WindowState = FormWindowState.Maximized;
            pedidos.Show();
        }

        private void estadisticasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormularioEstadisticas estadisticas = new FormularioEstadisticas()
            {
                MdiParent = this
            };
            estadisticas.WindowState = FormWindowState.Maximized;
            estadisticas.Show();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormularioInformeFactura factura = new FormularioInformeFactura()
            {
                MdiParent = this
            };
            factura.WindowState = FormWindowState.Maximized;
            factura.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormularioInformeStock stock = new FormularioInformeStock()
            {
                MdiParent = this
            };
            stock.WindowState = FormWindowState.Maximized;
            stock.Show();
        }

        private void menuOrganizarVertical_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void menuOrganizarHorizontal_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void menuAcercaDe_Click(object sender, EventArgs e)
        {
            ApiTiendaAcercaDe acercaDe = new ApiTiendaAcercaDe();
            acercaDe.Show();
        }

       

        public void ActualizarBarraEstado(string texto)
        {
            toolStripStatusLabel1.Text = texto;
        }

        /// <summary>
        ///     Método que abre la aplicación desde el menú contextual
        /// </summary>
        /// <param name="sender">Referencia al botón que lanza el método</param>
        /// <param name="eventsArgs">Argumentos del evento click</param>
        private void ToolStripMenuMostrar_Click(object sender, EventArgs eventsArgs)
        {
            toolStripMenuMostrar.Visible = false;
            toolStripMenuOcultar.Visible = true;
            this.Show();
        }

        /// <summary>
        ///     Método que oculta la aplicación desde el menú contextual
        /// </summary>
        /// <param name="sender">Referencia al botón que lanza el método</param>
        /// <param name="eventsArgs">Argumentos del evento click</param>
        private void ToolStripMenuOcultar_Click(object sender, EventArgs eventsArgs)
        {
            toolStripMenuMostrar.Visible = true;
            toolStripMenuOcultar.Visible = false;
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolHoraSistema.Text = DateTime.Now.ToLongTimeString();
            tiempoTranscurrido = DateTime.Now - inicioAplicacion;
            toolTiempoTranscurrido.Text = string.Format("{0:hh\\:mm\\:ss}", tiempoTranscurrido);
        }

       
    }
}
