namespace TiendaOnline
{
    partial class FormularioInformeFactura
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnBuscarFactura = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.errorUsuarioID = new MiLibreria.ErrorTxtBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.errorTxtDni = new MiLibreria.ErrorTxtBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorTxtnumeroPedido = new MiLibreria.ErrorTxtBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorTxtlocalidad = new MiLibreria.ErrorTxtBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errorTxtdireccion = new MiLibreria.ErrorTxtBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorTxtnombre = new MiLibreria.ErrorTxtBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1Pedido = new System.Windows.Forms.DataGridView();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.textTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textIva = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textsubTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1Pedido)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.41769F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.586405F));
            this.tableLayoutPanel1.Controls.Add(this.btnBuscarFactura, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.529945F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.66425F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.19782F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.97096F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1221, 515);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnBuscarFactura
            // 
            this.btnBuscarFactura.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBuscarFactura.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarFactura.Image = global::TiendaOnline.Properties.Resources.Buscar_p;
            this.btnBuscarFactura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarFactura.Location = new System.Drawing.Point(958, 3);
            this.btnBuscarFactura.Name = "btnBuscarFactura";
            this.btnBuscarFactura.Size = new System.Drawing.Size(203, 37);
            this.btnBuscarFactura.TabIndex = 0;
            this.btnBuscarFactura.Text = "Buscar  Factura";
            this.btnBuscarFactura.UseVisualStyleBackColor = true;
            this.btnBuscarFactura.Click += new System.EventHandler(this.btnBuscarFactura_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.errorUsuarioID);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.errorTxtDni);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.errorTxtnumeroPedido);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.errorTxtlocalidad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.errorTxtdireccion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.errorTxtnombre);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(64, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1097, 171);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos cliente";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(513, 132);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(264, 26);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(27, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 17);
            this.label10.TabIndex = 13;
            this.label10.Text = "Usuario ID :";
            // 
            // errorUsuarioID
            // 
            this.errorUsuarioID.Location = new System.Drawing.Point(145, 25);
            this.errorUsuarioID.Name = "errorUsuarioID";
            this.errorUsuarioID.ReadOnly = true;
            this.errorUsuarioID.Size = new System.Drawing.Size(186, 26);
            this.errorUsuarioID.SoloNumeros = false;
            this.errorUsuarioID.TabIndex = 12;
            this.errorUsuarioID.Validar = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(397, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fecha :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(397, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "DNI :";
            // 
            // errorTxtDni
            // 
            this.errorTxtDni.Location = new System.Drawing.Point(513, 94);
            this.errorTxtDni.Name = "errorTxtDni";
            this.errorTxtDni.ReadOnly = true;
            this.errorTxtDni.Size = new System.Drawing.Size(196, 26);
            this.errorTxtDni.SoloNumeros = false;
            this.errorTxtDni.TabIndex = 8;
            this.errorTxtDni.Validar = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(397, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Numero Pedido";
            // 
            // errorTxtnumeroPedido
            // 
            this.errorTxtnumeroPedido.Location = new System.Drawing.Point(513, 25);
            this.errorTxtnumeroPedido.Name = "errorTxtnumeroPedido";
            this.errorTxtnumeroPedido.ReadOnly = true;
            this.errorTxtnumeroPedido.Size = new System.Drawing.Size(186, 26);
            this.errorTxtnumeroPedido.SoloNumeros = false;
            this.errorTxtnumeroPedido.TabIndex = 6;
            this.errorTxtnumeroPedido.Validar = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Localidad :";
            // 
            // errorTxtlocalidad
            // 
            this.errorTxtlocalidad.Location = new System.Drawing.Point(145, 126);
            this.errorTxtlocalidad.Name = "errorTxtlocalidad";
            this.errorTxtlocalidad.ReadOnly = true;
            this.errorTxtlocalidad.Size = new System.Drawing.Size(186, 26);
            this.errorTxtlocalidad.SoloNumeros = false;
            this.errorTxtlocalidad.TabIndex = 4;
            this.errorTxtlocalidad.Validar = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Direccion :";
            // 
            // errorTxtdireccion
            // 
            this.errorTxtdireccion.Location = new System.Drawing.Point(145, 95);
            this.errorTxtdireccion.Name = "errorTxtdireccion";
            this.errorTxtdireccion.ReadOnly = true;
            this.errorTxtdireccion.Size = new System.Drawing.Size(186, 26);
            this.errorTxtdireccion.SoloNumeros = false;
            this.errorTxtdireccion.TabIndex = 2;
            this.errorTxtdireccion.Validar = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre :";
            // 
            // errorTxtnombre
            // 
            this.errorTxtnombre.Location = new System.Drawing.Point(145, 55);
            this.errorTxtnombre.Name = "errorTxtnombre";
            this.errorTxtnombre.ReadOnly = true;
            this.errorTxtnombre.Size = new System.Drawing.Size(186, 26);
            this.errorTxtnombre.SoloNumeros = false;
            this.errorTxtnombre.TabIndex = 0;
            this.errorTxtnombre.Validar = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1Pedido);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(64, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1097, 205);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle factura";
            // 
            // dataGridView1Pedido
            // 
            this.dataGridView1Pedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1Pedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1Pedido.Location = new System.Drawing.Point(3, 22);
            this.dataGridView1Pedido.Name = "dataGridView1Pedido";
            this.dataGridView1Pedido.Size = new System.Drawing.Size(1091, 180);
            this.dataGridView1Pedido.TabIndex = 0;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnImprimir.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnImprimir.Image = global::TiendaOnline.Properties.Resources.imprimir;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(899, 18);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(195, 41);
            this.btnImprimir.TabIndex = 6;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // textTotal
            // 
            this.textTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textTotal.Location = new System.Drawing.Point(739, 29);
            this.textTotal.Name = "textTotal";
            this.textTotal.ReadOnly = true;
            this.textTotal.Size = new System.Drawing.Size(121, 20);
            this.textTotal.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(612, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "Total :";
            // 
            // textIva
            // 
            this.textIva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textIva.Location = new System.Drawing.Point(485, 29);
            this.textIva.Name = "textIva";
            this.textIva.ReadOnly = true;
            this.textIva.Size = new System.Drawing.Size(121, 20);
            this.textIva.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(358, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "IVA :";
            // 
            // textsubTotal
            // 
            this.textsubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textsubTotal.Location = new System.Drawing.Point(231, 29);
            this.textsubTotal.Name = "textsubTotal";
            this.textsubTotal.ReadOnly = true;
            this.textsubTotal.Size = new System.Drawing.Size(121, 20);
            this.textsubTotal.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(104, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Subtotal :";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 9;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.302325F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.62791F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.62791F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.62791F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.62791F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.62791F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.62791F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.099362F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.23154F));
            this.tableLayoutPanel2.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.textTotal, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.textsubTotal, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.textIva, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnImprimir, 8, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(64, 434);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1097, 78);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // FormularioInformeFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1221, 515);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormularioInformeFactura";
            this.Text = "FormularioBusquedafactura";
            this.Load += new System.EventHandler(this.FormularioInformeFactura_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1Pedido)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnBuscarFactura;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private MiLibreria.ErrorTxtBox errorTxtDni;
        private System.Windows.Forms.Label label4;
        private MiLibreria.ErrorTxtBox errorTxtnumeroPedido;
        private System.Windows.Forms.Label label3;
        private MiLibreria.ErrorTxtBox errorTxtlocalidad;
        private System.Windows.Forms.Label label2;
        private MiLibreria.ErrorTxtBox errorTxtdireccion;
        private System.Windows.Forms.Label label1;
        private MiLibreria.ErrorTxtBox errorTxtnombre;
        private System.Windows.Forms.DataGridView dataGridView1Pedido;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox textTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textIva;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textsubTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private MiLibreria.ErrorTxtBox errorUsuarioID;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
