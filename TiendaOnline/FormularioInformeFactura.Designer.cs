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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1Pedido = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.textTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textIva = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textsubTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.errorUsuarioID = new MiLibreria.ErrorTxtBox();
            this.errorTxtDni = new MiLibreria.ErrorTxtBox();
            this.errorTxtnumeroPedido = new MiLibreria.ErrorTxtBox();
            this.errorTxtlocalidad = new MiLibreria.ErrorTxtBox();
            this.errorTxtdireccion = new MiLibreria.ErrorTxtBox();
            this.errorTxtnombre = new MiLibreria.ErrorTxtBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1Pedido)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Controls.Add(this.btnBuscarFactura, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.55777F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.85259F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.43426F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.95617F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1011, 551);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnBuscarFactura
            // 
            this.btnBuscarFactura.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBuscarFactura.Location = new System.Drawing.Point(834, 17);
            this.btnBuscarFactura.Name = "btnBuscarFactura";
            this.btnBuscarFactura.Size = new System.Drawing.Size(122, 23);
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
            this.groupBox1.Location = new System.Drawing.Point(53, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(903, 197);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos cliente";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(529, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fecha :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(529, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "DNI :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Numero Pedido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Localidad :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Direccion :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1Pedido);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(53, 264);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(903, 222);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle factura";
            // 
            // dataGridView1Pedido
            // 
            this.dataGridView1Pedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1Pedido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1Pedido.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1Pedido.Name = "dataGridView1Pedido";
            this.dataGridView1Pedido.Size = new System.Drawing.Size(897, 203);
            this.dataGridView1Pedido.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnImprimir);
            this.groupBox3.Controls.Add(this.textTotal);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textIva);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.textsubTotal);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(60, 499);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(889, 42);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(746, 13);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(109, 23);
            this.btnImprimir.TabIndex = 6;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // textTotal
            // 
            this.textTotal.Location = new System.Drawing.Point(525, 12);
            this.textTotal.Name = "textTotal";
            this.textTotal.Size = new System.Drawing.Size(100, 20);
            this.textTotal.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(450, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Total :";
            // 
            // textIva
            // 
            this.textIva.Location = new System.Drawing.Point(316, 12);
            this.textIva.Name = "textIva";
            this.textIva.Size = new System.Drawing.Size(100, 20);
            this.textIva.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(251, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "IVA :";
            // 
            // textsubTotal
            // 
            this.textsubTotal.Location = new System.Drawing.Point(119, 12);
            this.textsubTotal.Name = "textsubTotal";
            this.textsubTotal.Size = new System.Drawing.Size(100, 20);
            this.textsubTotal.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Subtotal :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Usuario ID :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(602, 134);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // errorUsuarioID
            // 
            this.errorUsuarioID.Location = new System.Drawing.Point(126, 25);
            this.errorUsuarioID.Name = "errorUsuarioID";
            this.errorUsuarioID.Size = new System.Drawing.Size(100, 20);
            this.errorUsuarioID.SoloNumeros = false;
            this.errorUsuarioID.TabIndex = 12;
            this.errorUsuarioID.Validar = false;
            // 
            // errorTxtDni
            // 
            this.errorTxtDni.Location = new System.Drawing.Point(602, 95);
            this.errorTxtDni.Name = "errorTxtDni";
            this.errorTxtDni.Size = new System.Drawing.Size(196, 20);
            this.errorTxtDni.SoloNumeros = false;
            this.errorTxtDni.TabIndex = 8;
            this.errorTxtDni.Validar = false;
            // 
            // errorTxtnumeroPedido
            // 
            this.errorTxtnumeroPedido.Location = new System.Drawing.Point(126, 161);
            this.errorTxtnumeroPedido.Name = "errorTxtnumeroPedido";
            this.errorTxtnumeroPedido.Size = new System.Drawing.Size(100, 20);
            this.errorTxtnumeroPedido.SoloNumeros = false;
            this.errorTxtnumeroPedido.TabIndex = 6;
            this.errorTxtnumeroPedido.Validar = false;
            // 
            // errorTxtlocalidad
            // 
            this.errorTxtlocalidad.Location = new System.Drawing.Point(126, 126);
            this.errorTxtlocalidad.Name = "errorTxtlocalidad";
            this.errorTxtlocalidad.Size = new System.Drawing.Size(100, 20);
            this.errorTxtlocalidad.SoloNumeros = false;
            this.errorTxtlocalidad.TabIndex = 4;
            this.errorTxtlocalidad.Validar = false;
            // 
            // errorTxtdireccion
            // 
            this.errorTxtdireccion.Location = new System.Drawing.Point(126, 95);
            this.errorTxtdireccion.Name = "errorTxtdireccion";
            this.errorTxtdireccion.Size = new System.Drawing.Size(100, 20);
            this.errorTxtdireccion.SoloNumeros = false;
            this.errorTxtdireccion.TabIndex = 2;
            this.errorTxtdireccion.Validar = false;
            // 
            // errorTxtnombre
            // 
            this.errorTxtnombre.Location = new System.Drawing.Point(126, 55);
            this.errorTxtnombre.Name = "errorTxtnombre";
            this.errorTxtnombre.Size = new System.Drawing.Size(100, 20);
            this.errorTxtnombre.SoloNumeros = false;
            this.errorTxtnombre.TabIndex = 0;
            this.errorTxtnombre.Validar = false;
            // 
            // FormularioInformeFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 551);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormularioInformeFactura";
            this.Text = "FormularioBusquedafactura";
            this.Load += new System.EventHandler(this.FormularioInformeFactura_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1Pedido)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox3;
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
    }
}
