namespace TiendaOnline
{
    partial class FormularioPedidos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvLinped = new System.Windows.Forms.DataGridView();
            this.ColumnLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnArticuloID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnImporteTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1FechaPedido = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnproducto = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnColocar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPedidoID = new MiLibreria.ErrorTxtBox();
            this.txtUsuarioID = new MiLibreria.ErrorTxtBox();
            this.txtNombreArticulo = new MiLibreria.ErrorTxtBox();
            this.txtMarcaArticulo = new MiLibreria.ErrorTxtBox();
            this.txtPrecioArticulo = new MiLibreria.ErrorTxtBox();
            this.txtCantidadArticulo = new MiLibreria.ErrorTxtBox();
            this.lbTotalIVa = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTotal = new System.Windows.Forms.Label();
            this.lbivaporcentaje = new System.Windows.Forms.Label();
            this.lbIva = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnBuscarPedido = new System.Windows.Forms.Button();
            this.btnEliminarPedido = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinped)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dgvLinped
            // 
            this.dgvLinped.AllowUserToAddRows = false;
            this.dgvLinped.AllowUserToDeleteRows = false;
            this.dgvLinped.AllowUserToResizeColumns = false;
            this.dgvLinped.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLinped.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLinped.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLinped.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnLinea,
            this.ColumnArticuloID,
            this.ColumnImporte,
            this.ColumnCantidad,
            this.ColumnImporteTotal});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvLinped, 6);
            this.dgvLinped.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLinped.Location = new System.Drawing.Point(98, 170);
            this.dgvLinped.Name = "dgvLinped";
            this.dgvLinped.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLinped.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvLinped.RowHeadersVisible = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvLinped.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.tableLayoutPanel1.SetRowSpan(this.dgvLinped, 7);
            this.dgvLinped.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLinped.Size = new System.Drawing.Size(642, 295);
            this.dgvLinped.TabIndex = 7;
            // 
            // ColumnLinea
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnLinea.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnLinea.HeaderText = "Linea";
            this.ColumnLinea.Name = "ColumnLinea";
            this.ColumnLinea.ReadOnly = true;
            // 
            // ColumnArticuloID
            // 
            this.ColumnArticuloID.HeaderText = "ArticuloID";
            this.ColumnArticuloID.Name = "ColumnArticuloID";
            this.ColumnArticuloID.ReadOnly = true;
            // 
            // ColumnImporte
            // 
            this.ColumnImporte.HeaderText = "Importe";
            this.ColumnImporte.Name = "ColumnImporte";
            this.ColumnImporte.ReadOnly = true;
            this.ColumnImporte.Width = 150;
            // 
            // ColumnCantidad
            // 
            this.ColumnCantidad.HeaderText = "Cantidad";
            this.ColumnCantidad.Name = "ColumnCantidad";
            this.ColumnCantidad.ReadOnly = true;
            this.ColumnCantidad.Width = 150;
            // 
            // ColumnImporteTotal
            // 
            this.ColumnImporteTotal.HeaderText = "ImporteTotal";
            this.ColumnImporteTotal.Name = "ColumnImporteTotal";
            this.ColumnImporteTotal.ReadOnly = true;
            this.ColumnImporteTotal.Width = 116;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(580, 129);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Cantidad";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(201, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 20);
            this.label2.TabIndex = 17;
            this.label2.Text = "Detalles Articulo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(433, 129);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Precio";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(198, 129);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Marca";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nombre";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker1FechaPedido
            // 
            this.dateTimePicker1FechaPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1FechaPedido.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1FechaPedido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1FechaPedido.Location = new System.Drawing.Point(583, 46);
            this.dateTimePicker1FechaPedido.Name = "dateTimePicker1FechaPedido";
            this.dateTimePicker1FechaPedido.Size = new System.Drawing.Size(157, 20);
            this.dateTimePicker1FechaPedido.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(503, 48);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 17);
            this.label10.TabIndex = 15;
            this.label10.Text = "Fecha";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Image = global::TiendaOnline.Properties.Resources.Buscar_p;
            this.button8.Location = new System.Drawing.Point(436, 41);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(61, 31);
            this.button8.TabIndex = 14;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.BtnBuscarUsuario_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(201, 48);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 17);
            this.label9.TabIndex = 12;
            this.label9.Text = "UsuarioID";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 48);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(89, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "PedidoID";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Image = global::TiendaOnline.Properties.Resources.door_in;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(840, 474);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(164, 35);
            this.button7.TabIndex = 6;
            this.button7.Text = "Salir";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.Image = global::TiendaOnline.Properties.Resources.modificar;
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.Location = new System.Drawing.Point(840, 342);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(164, 37);
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Text = "Actualizar Pedido";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.Image = global::TiendaOnline.Properties.Resources.agregar_p;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(840, 170);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(164, 37);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "Nuevo Pedido";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnproducto
            // 
            this.btnproducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnproducto.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnproducto.Image = global::TiendaOnline.Properties.Resources.Buscar_p;
            this.btnproducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnproducto.Location = new System.Drawing.Point(840, 213);
            this.btnproducto.Name = "btnproducto";
            this.btnproducto.Size = new System.Drawing.Size(164, 37);
            this.btnproducto.TabIndex = 3;
            this.btnproducto.Text = "Articulo";
            this.btnproducto.UseVisualStyleBackColor = true;
            this.btnproducto.Click += new System.EventHandler(this.btnproducto_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Image = global::TiendaOnline.Properties.Resources.eliminar;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(840, 256);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(164, 37);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar Articulo";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // btnColocar
            // 
            this.btnColocar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColocar.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColocar.Location = new System.Drawing.Point(840, 119);
            this.btnColocar.Name = "btnColocar";
            this.btnColocar.Size = new System.Drawing.Size(164, 37);
            this.btnColocar.TabIndex = 0;
            this.btnColocar.Text = "Colocar";
            this.btnColocar.UseVisualStyleBackColor = true;
            this.btnColocar.Click += new System.EventHandler(this.btnColocar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.304179F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.10324F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.211632F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.88737F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.562194F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.911207F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.96474F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.031342F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.21239F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.67035F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.022448F));
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.button8, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker1FechaPedido, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgvLinped, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPedidoID, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtUsuarioID, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNombreArticulo, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtMarcaArticulo, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtPrecioArticulo, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtCantidadArticulo, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbTotalIVa, 6, 11);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.lbTotal, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.lbivaporcentaje, 3, 11);
            this.tableLayoutPanel1.Controls.Add(this.lbIva, 4, 11);
            this.tableLayoutPanel1.Controls.Add(this.label12, 5, 11);
            this.tableLayoutPanel1.Controls.Add(this.button7, 9, 11);
            this.tableLayoutPanel1.Controls.Add(this.btnGuardar, 9, 10);
            this.tableLayoutPanel1.Controls.Add(this.btnColocar, 9, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnproducto, 9, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnBuscarPedido, 9, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnActualizar, 9, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnEliminarPedido, 9, 9);
            this.tableLayoutPanel1.Controls.Add(this.btnEliminar, 9, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnNuevo, 9, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.017495F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.43033F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.083517F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.34015F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.391062F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.391062F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.391062F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.391062F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.391062F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.391062F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.391062F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.391062F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1021, 515);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(201, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "Detalles Pedido";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPedidoID
            // 
            this.txtPedidoID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPedidoID.Location = new System.Drawing.Point(98, 46);
            this.txtPedidoID.Name = "txtPedidoID";
            this.txtPedidoID.Size = new System.Drawing.Size(97, 20);
            this.txtPedidoID.SoloNumeros = false;
            this.txtPedidoID.TabIndex = 18;
            this.txtPedidoID.Validar = true;
            // 
            // txtUsuarioID
            // 
            this.txtUsuarioID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuarioID.Location = new System.Drawing.Point(284, 46);
            this.txtUsuarioID.Name = "txtUsuarioID";
            this.txtUsuarioID.Size = new System.Drawing.Size(146, 20);
            this.txtUsuarioID.SoloNumeros = false;
            this.txtUsuarioID.TabIndex = 19;
            this.txtUsuarioID.Validar = true;
            // 
            // txtNombreArticulo
            // 
            this.txtNombreArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreArticulo.Location = new System.Drawing.Point(98, 128);
            this.txtNombreArticulo.Name = "txtNombreArticulo";
            this.txtNombreArticulo.Size = new System.Drawing.Size(97, 20);
            this.txtNombreArticulo.SoloNumeros = false;
            this.txtNombreArticulo.TabIndex = 20;
            this.txtNombreArticulo.Validar = true;
            // 
            // txtMarcaArticulo
            // 
            this.txtMarcaArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMarcaArticulo.Location = new System.Drawing.Point(284, 128);
            this.txtMarcaArticulo.Name = "txtMarcaArticulo";
            this.txtMarcaArticulo.Size = new System.Drawing.Size(146, 20);
            this.txtMarcaArticulo.SoloNumeros = false;
            this.txtMarcaArticulo.TabIndex = 21;
            this.txtMarcaArticulo.Validar = true;
            // 
            // txtPrecioArticulo
            // 
            this.txtPrecioArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrecioArticulo.Location = new System.Drawing.Point(503, 128);
            this.txtPrecioArticulo.Name = "txtPrecioArticulo";
            this.txtPrecioArticulo.Size = new System.Drawing.Size(74, 20);
            this.txtPrecioArticulo.SoloNumeros = false;
            this.txtPrecioArticulo.TabIndex = 22;
            this.txtPrecioArticulo.Validar = true;
            // 
            // txtCantidadArticulo
            // 
            this.txtCantidadArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCantidadArticulo.Location = new System.Drawing.Point(746, 128);
            this.txtCantidadArticulo.Name = "txtCantidadArticulo";
            this.txtCantidadArticulo.Size = new System.Drawing.Size(76, 20);
            this.txtCantidadArticulo.SoloNumeros = false;
            this.txtCantidadArticulo.TabIndex = 23;
            this.txtCantidadArticulo.Validar = true;
            // 
            // lbTotalIVa
            // 
            this.lbTotalIVa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotalIVa.AutoSize = true;
            this.lbTotalIVa.Location = new System.Drawing.Point(583, 485);
            this.lbTotalIVa.Name = "lbTotalIVa";
            this.lbTotalIVa.Size = new System.Drawing.Size(157, 13);
            this.lbTotalIVa.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(98, 483);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Total";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTotal
            // 
            this.lbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(201, 485);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(77, 13);
            this.lbTotal.TabIndex = 25;
            this.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbivaporcentaje
            // 
            this.lbivaporcentaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbivaporcentaje.AutoSize = true;
            this.lbivaporcentaje.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbivaporcentaje.Location = new System.Drawing.Point(284, 483);
            this.lbivaporcentaje.Name = "lbivaporcentaje";
            this.lbivaporcentaje.Size = new System.Drawing.Size(146, 17);
            this.lbivaporcentaje.TabIndex = 26;
            this.lbivaporcentaje.Text = "IVA 21 %";
            this.lbivaporcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbIva
            // 
            this.lbIva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbIva.AutoSize = true;
            this.lbIva.Location = new System.Drawing.Point(436, 485);
            this.lbIva.Name = "lbIva";
            this.lbIva.Size = new System.Drawing.Size(61, 13);
            this.lbIva.TabIndex = 27;
            this.lbIva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(503, 474);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 34);
            this.label12.TabIndex = 29;
            this.label12.Text = "Total con Iva";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = global::TiendaOnline.Properties.Resources.disco1;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(840, 428);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(164, 37);
            this.btnGuardar.TabIndex = 31;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBuscarPedido
            // 
            this.btnBuscarPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarPedido.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPedido.Image = global::TiendaOnline.Properties.Resources.Buscar_p;
            this.btnBuscarPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarPedido.Location = new System.Drawing.Point(840, 299);
            this.btnBuscarPedido.Name = "btnBuscarPedido";
            this.btnBuscarPedido.Size = new System.Drawing.Size(164, 37);
            this.btnBuscarPedido.TabIndex = 30;
            this.btnBuscarPedido.Text = "Buscar Pedido";
            this.btnBuscarPedido.UseVisualStyleBackColor = true;
            this.btnBuscarPedido.Click += new System.EventHandler(this.btnBuscarPedido_Click);
            // 
            // btnEliminarPedido
            // 
            this.btnEliminarPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarPedido.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarPedido.Image = global::TiendaOnline.Properties.Resources.eliminar;
            this.btnEliminarPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarPedido.Location = new System.Drawing.Point(840, 385);
            this.btnEliminarPedido.Name = "btnEliminarPedido";
            this.btnEliminarPedido.Size = new System.Drawing.Size(164, 37);
            this.btnEliminarPedido.TabIndex = 32;
            this.btnEliminarPedido.Text = "Eliminar Pedido";
            this.btnEliminarPedido.UseVisualStyleBackColor = true;
            this.btnEliminarPedido.Click += new System.EventHandler(this.BtnEliminarPedido_Click);
            // 
            // FormularioPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1021, 515);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormularioPedidos";
            this.Text = "FormularioPedidos";
            this.Load += new System.EventHandler(this.FormularioPedidos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinped)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnColocar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnproducto;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker1FechaPedido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvLinped;
        private MiLibreria.ErrorTxtBox txtPedidoID;
        private MiLibreria.ErrorTxtBox txtUsuarioID;
        private MiLibreria.ErrorTxtBox txtNombreArticulo;
        private MiLibreria.ErrorTxtBox txtMarcaArticulo;
        private MiLibreria.ErrorTxtBox txtPrecioArticulo;
        private MiLibreria.ErrorTxtBox txtCantidadArticulo;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label lbivaporcentaje;
        private System.Windows.Forms.Label lbIva;
        private System.Windows.Forms.Label lbTotalIVa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnBuscarPedido;
        private System.Windows.Forms.Button btnEliminarPedido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLinea;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnArticuloID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnImporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnImporteTotal;
    }
}
