
namespace LDXPS.WinApp
{
    partial class FrmHome
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnTodos = new System.Windows.Forms.Button();
            this.GridViewVendedores = new System.Windows.Forms.DataGridView();
            this.BtnCriarVendedor = new System.Windows.Forms.Button();
            this.BtnCriarCliente = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GridViewClientes = new System.Windows.Forms.DataGridView();
            this.BtnEditarCliente = new System.Windows.Forms.Button();
            this.BtnEditarVendedor = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewVendedores)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnTodos);
            this.groupBox1.Controls.Add(this.GridViewVendedores);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 364);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vendedores";
            // 
            // BtnTodos
            // 
            this.BtnTodos.Location = new System.Drawing.Point(416, 27);
            this.BtnTodos.Name = "BtnTodos";
            this.BtnTodos.Size = new System.Drawing.Size(104, 23);
            this.BtnTodos.TabIndex = 4;
            this.BtnTodos.Text = "Todos";
            this.BtnTodos.UseVisualStyleBackColor = true;
            this.BtnTodos.Click += new System.EventHandler(this.BtnTodos_Click_1);
            // 
            // GridViewVendedores
            // 
            this.GridViewVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewVendedores.Location = new System.Drawing.Point(6, 56);
            this.GridViewVendedores.Name = "GridViewVendedores";
            this.GridViewVendedores.RowTemplate.Height = 25;
            this.GridViewVendedores.Size = new System.Drawing.Size(514, 296);
            this.GridViewVendedores.TabIndex = 2;
            this.GridViewVendedores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewVendedores_CellContentClick);
            this.GridViewVendedores.Click += new System.EventHandler(this.GridViewVendedores_Click);
            // 
            // BtnCriarVendedor
            // 
            this.BtnCriarVendedor.Location = new System.Drawing.Point(18, 415);
            this.BtnCriarVendedor.Name = "BtnCriarVendedor";
            this.BtnCriarVendedor.Size = new System.Drawing.Size(104, 23);
            this.BtnCriarVendedor.TabIndex = 5;
            this.BtnCriarVendedor.Text = "Criar Vendedor";
            this.BtnCriarVendedor.UseVisualStyleBackColor = true;
            this.BtnCriarVendedor.Click += new System.EventHandler(this.BtnCriarVendedor_Click);
            // 
            // BtnCriarCliente
            // 
            this.BtnCriarCliente.Location = new System.Drawing.Point(557, 411);
            this.BtnCriarCliente.Name = "BtnCriarCliente";
            this.BtnCriarCliente.Size = new System.Drawing.Size(104, 23);
            this.BtnCriarCliente.TabIndex = 6;
            this.BtnCriarCliente.Text = "Criar Cliente";
            this.BtnCriarCliente.UseVisualStyleBackColor = true;
            this.BtnCriarCliente.Click += new System.EventHandler(this.BtnCriarCliente_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GridViewClientes);
            this.groupBox2.Location = new System.Drawing.Point(551, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 364);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clientes";
            // 
            // GridViewClientes
            // 
            this.GridViewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewClientes.Location = new System.Drawing.Point(6, 56);
            this.GridViewClientes.Name = "GridViewClientes";
            this.GridViewClientes.RowTemplate.Height = 25;
            this.GridViewClientes.Size = new System.Drawing.Size(227, 297);
            this.GridViewClientes.TabIndex = 4;
            this.GridViewClientes.Visible = false;
            // 
            // BtnEditarCliente
            // 
            this.BtnEditarCliente.Location = new System.Drawing.Point(667, 411);
            this.BtnEditarCliente.Name = "BtnEditarCliente";
            this.BtnEditarCliente.Size = new System.Drawing.Size(104, 23);
            this.BtnEditarCliente.TabIndex = 7;
            this.BtnEditarCliente.Text = "Editar Cliente";
            this.BtnEditarCliente.UseVisualStyleBackColor = true;
            this.BtnEditarCliente.Click += new System.EventHandler(this.BtnEditarCliente_Click);
            // 
            // BtnEditarVendedor
            // 
            this.BtnEditarVendedor.Location = new System.Drawing.Point(128, 415);
            this.BtnEditarVendedor.Name = "BtnEditarVendedor";
            this.BtnEditarVendedor.Size = new System.Drawing.Size(104, 23);
            this.BtnEditarVendedor.TabIndex = 6;
            this.BtnEditarVendedor.Text = "Editar Vendedor";
            this.BtnEditarVendedor.UseVisualStyleBackColor = true;
            this.BtnEditarVendedor.Click += new System.EventHandler(this.BtnEditarVendedor_Click);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnEditarCliente);
            this.Controls.Add(this.BtnEditarVendedor);
            this.Controls.Add(this.BtnCriarCliente);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BtnCriarVendedor);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewVendedores)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnTodos;
        private System.Windows.Forms.DataGridView GridViewVendedores;
        private System.Windows.Forms.Button BtnCriarVendedor;
        private System.Windows.Forms.Button BtnCriarCliente;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView GridViewClientes;
        private System.Windows.Forms.Button BtnEditarCliente;
        private System.Windows.Forms.Button BtnEditarVendedor;
    }
}