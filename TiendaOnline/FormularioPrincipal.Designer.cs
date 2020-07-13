using System;
using System.Windows.Forms;

namespace TiendaOnline
{
    partial class FormularioPrincipal
    {


        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BarraMenuFormPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarEliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadisticasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInformes = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVentana = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrganizarVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrganizarHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuMostrar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuOcultar = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStripApiTienda = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolHoraSistema = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTiempoTranscurrido = new System.Windows.Forms.ToolStripStatusLabel();
            this.BarraMenuFormPrincipal.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.statusStripApiTienda.SuspendLayout();
            this.SuspendLayout();
            // 
            // BarraMenuFormPrincipal
            // 
            this.BarraMenuFormPrincipal.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.BarraMenuFormPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuArchivo,
            this.usuariosToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.menuUsuarios,
            this.estadisticasToolStripMenuItem,
            this.menuInformes,
            this.menuVentana,
            this.menuAcercaDe});
            this.BarraMenuFormPrincipal.Location = new System.Drawing.Point(0, 0);
            this.BarraMenuFormPrincipal.MdiWindowListItem = this.menuVentana;
            this.BarraMenuFormPrincipal.Name = "BarraMenuFormPrincipal";
            this.BarraMenuFormPrincipal.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.BarraMenuFormPrincipal.Size = new System.Drawing.Size(1284, 25);
            this.BarraMenuFormPrincipal.TabIndex = 0;
            this.BarraMenuFormPrincipal.Text = "menuStrip1";
            // 
            // menuArchivo
            // 
            this.menuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.menuArchivo.Name = "menuArchivo";
            this.menuArchivo.Size = new System.Drawing.Size(60, 19);
            this.menuArchivo.Text = "A&rchivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.Salir);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertarToolStripMenuItem,
            this.modificarEliminarToolStripMenuItem,
            this.mantenimientoUsuariosToolStripMenuItem});
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(64, 19);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // insertarToolStripMenuItem
            // 
            this.insertarToolStripMenuItem.Name = "insertarToolStripMenuItem";
            this.insertarToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.insertarToolStripMenuItem.Text = "Insertar";
            this.insertarToolStripMenuItem.Click += new System.EventHandler(this.InsertarToolStripMenuItem_Click);
            // 
            // modificarEliminarToolStripMenuItem
            // 
            this.modificarEliminarToolStripMenuItem.Name = "modificarEliminarToolStripMenuItem";
            this.modificarEliminarToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.modificarEliminarToolStripMenuItem.Text = "Modificar/Eliminar";
            this.modificarEliminarToolStripMenuItem.Click += new System.EventHandler(this.ModificarEliminarToolStripMenuItem_Click);
            // 
            // mantenimientoUsuariosToolStripMenuItem
            // 
            this.mantenimientoUsuariosToolStripMenuItem.Name = "mantenimientoUsuariosToolStripMenuItem";
            this.mantenimientoUsuariosToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.mantenimientoUsuariosToolStripMenuItem.Text = "Mantenimiento Usuarios";
            this.mantenimientoUsuariosToolStripMenuItem.Click += new System.EventHandler(this.MantenimientoUsuarios);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarToolStripMenuItem});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(73, 19);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.consultarToolStripMenuItem.Text = "Consultar/Modificar";
            this.consultarToolStripMenuItem.Click += new System.EventHandler(this.ConsultarToolStripMenuItem_Click);
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(61, 19);
            this.menuUsuarios.Text = "Pedidos";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo/Modificacion/Eliminacion";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(251, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // estadisticasToolStripMenuItem
            // 
            this.estadisticasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estadisticasToolStripMenuItem1});
            this.estadisticasToolStripMenuItem.Name = "estadisticasToolStripMenuItem";
            this.estadisticasToolStripMenuItem.Size = new System.Drawing.Size(79, 19);
            this.estadisticasToolStripMenuItem.Text = "Estadisticas";
            // 
            // estadisticasToolStripMenuItem1
            // 
            this.estadisticasToolStripMenuItem1.Name = "estadisticasToolStripMenuItem1";
            this.estadisticasToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.estadisticasToolStripMenuItem1.Text = "Estadisticas";
            this.estadisticasToolStripMenuItem1.Click += new System.EventHandler(this.estadisticasToolStripMenuItem1_Click);
            // 
            // menuInformes
            // 
            this.menuInformes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturaToolStripMenuItem,
            this.stockToolStripMenuItem});
            this.menuInformes.Name = "menuInformes";
            this.menuInformes.Size = new System.Drawing.Size(66, 19);
            this.menuInformes.Text = "&Informes";
            // 
            // facturaToolStripMenuItem
            // 
            this.facturaToolStripMenuItem.Name = "facturaToolStripMenuItem";
            this.facturaToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.facturaToolStripMenuItem.Text = "factura";
            this.facturaToolStripMenuItem.Click += new System.EventHandler(this.facturaToolStripMenuItem_Click);
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.stockToolStripMenuItem.Text = "Stock";
            this.stockToolStripMenuItem.Click += new System.EventHandler(this.stockToolStripMenuItem_Click);
            // 
            // menuVentana
            // 
            this.menuVentana.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOrganizarVertical,
            this.menuOrganizarHorizontal});
            this.menuVentana.Name = "menuVentana";
            this.menuVentana.Size = new System.Drawing.Size(61, 19);
            this.menuVentana.Text = "&Ventana";
            // 
            // menuOrganizarVertical
            // 
            this.menuOrganizarVertical.Name = "menuOrganizarVertical";
            this.menuOrganizarVertical.Size = new System.Drawing.Size(181, 22);
            this.menuOrganizarVertical.Text = "Organizar &vertical";
            this.menuOrganizarVertical.Click += new System.EventHandler(this.menuOrganizarVertical_Click);
            // 
            // menuOrganizarHorizontal
            // 
            this.menuOrganizarHorizontal.Name = "menuOrganizarHorizontal";
            this.menuOrganizarHorizontal.Size = new System.Drawing.Size(181, 22);
            this.menuOrganizarHorizontal.Text = "Organizar horizontal";
            this.menuOrganizarHorizontal.Click += new System.EventHandler(this.menuOrganizarHorizontal_Click);
            // 
            // menuAcercaDe
            // 
            this.menuAcercaDe.Name = "menuAcercaDe";
            this.menuAcercaDe.Size = new System.Drawing.Size(80, 19);
            this.menuAcercaDe.Text = "&Acerca de...";
            this.menuAcercaDe.Click += new System.EventHandler(this.menuAcercaDe_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Text = "Antº Damian - TiendaOnline DAM";
            this.notifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuMostrar,
            this.toolStripMenuOcultar});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(173, 48);
            // 
            // toolStripMenuMostrar
            // 
            this.toolStripMenuMostrar.Name = "toolStripMenuMostrar";
            this.toolStripMenuMostrar.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuMostrar.Text = "Mostrar aplicación";
            // 
            // toolStripMenuOcultar
            // 
            this.toolStripMenuOcultar.Name = "toolStripMenuOcultar";
            this.toolStripMenuOcultar.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuOcultar.Text = "Ocultar aplicación";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStripApiTienda
            // 
            this.statusStripApiTienda.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolHoraSistema,
            this.toolStripStatusLabel4,
            this.toolTiempoTranscurrido});
            this.statusStripApiTienda.Location = new System.Drawing.Point(0, 727);
            this.statusStripApiTienda.Name = "statusStripApiTienda";
            this.statusStripApiTienda.Padding = new System.Windows.Forms.Padding(2, 0, 23, 0);
            this.statusStripApiTienda.Size = new System.Drawing.Size(1284, 22);
            this.statusStripApiTienda.TabIndex = 4;
            this.statusStripApiTienda.Text = "Estado";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Estado";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(700, 3, 0, 2);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(87, 17);
            this.toolStripStatusLabel2.Text = "Hora de sitema";
            // 
            // toolHoraSistema
            // 
            this.toolHoraSistema.Name = "toolHoraSistema";
            this.toolHoraSistema.Size = new System.Drawing.Size(59, 17);
            this.toolHoraSistema.Text = "hh:mm:ss";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(117, 17);
            this.toolStripStatusLabel4.Text = "Tiempo en ejecucion";
            // 
            // toolTiempoTranscurrido
            // 
            this.toolTiempoTranscurrido.Name = "toolTiempoTranscurrido";
            this.toolTiempoTranscurrido.Size = new System.Drawing.Size(59, 17);
            this.toolTiempoTranscurrido.Text = "hh:mm:ss";
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1284, 749);
            this.Controls.Add(this.statusStripApiTienda);
            this.Controls.Add(this.BarraMenuFormPrincipal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.BarraMenuFormPrincipal;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximumSize = new System.Drawing.Size(2123, 1403);
            this.MinimumSize = new System.Drawing.Size(1278, 726);
            this.Name = "FormularioPrincipal";
            this.Text = "Usuario: Usuario conectado";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormularioPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FormularioPrincipal_Load);
            this.BarraMenuFormPrincipal.ResumeLayout(false);
            this.BarraMenuFormPrincipal.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.statusStripApiTienda.ResumeLayout(false);
            this.statusStripApiTienda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip BarraMenuFormPrincipal;
        private System.Windows.Forms.ToolStripMenuItem menuArchivo;

        private System.Windows.Forms.ToolStripMenuItem menuUsuarios;

        private System.Windows.Forms.ToolStripMenuItem menuInformes;
        private System.Windows.Forms.ToolStripMenuItem menuVentana;


        private System.Windows.Forms.ToolStripMenuItem menuOrganizarVertical;
        private System.Windows.Forms.ToolStripMenuItem menuOrganizarHorizontal;
        private System.Windows.Forms.ToolStripMenuItem menuAcercaDe;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuMostrar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuOcultar;
        private System.Windows.Forms.Timer timer1;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem estadisticasToolStripMenuItem;
        private ToolStripMenuItem insertarToolStripMenuItem;
        private ToolStripMenuItem modificarEliminarToolStripMenuItem;
        private ToolStripMenuItem consultarToolStripMenuItem;
        private ToolStripMenuItem nuevoToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private ToolStripMenuItem facturaToolStripMenuItem;
        private ToolStripMenuItem stockToolStripMenuItem;
        private ToolStripMenuItem estadisticasToolStripMenuItem1;
        private StatusStrip statusStripApiTienda;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolHoraSistema;
        private ToolStripStatusLabel toolStripStatusLabel4;
        private ToolStripStatusLabel toolTiempoTranscurrido;
        private ToolStripMenuItem mantenimientoUsuariosToolStripMenuItem;
    }
}



