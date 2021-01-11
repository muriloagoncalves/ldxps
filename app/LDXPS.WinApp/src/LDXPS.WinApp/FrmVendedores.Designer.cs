
namespace LDXPS.WinApp
{
    partial class FrmVendedores
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
            this.GridVendedores = new System.Windows.Forms.DataGridView();
            this.BtnCadastroVendedor = new System.Windows.Forms.Button();
            this.BtnEditarVendedor = new System.Windows.Forms.Button();
            this.BtnExcluirVendedor = new System.Windows.Forms.Button();
            this.BtnCadastroCliente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridVendedores)).BeginInit();
            this.SuspendLayout();
            // 
            // GridVendedores
            // 
            this.GridVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridVendedores.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GridVendedores.Location = new System.Drawing.Point(0, 107);
            this.GridVendedores.Name = "GridVendedores";
            this.GridVendedores.RowTemplate.Height = 25;
            this.GridVendedores.Size = new System.Drawing.Size(800, 343);
            this.GridVendedores.TabIndex = 3;
            // 
            // BtnCadastroVendedor
            // 
            this.BtnCadastroVendedor.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCadastroVendedor.Location = new System.Drawing.Point(12, 61);
            this.BtnCadastroVendedor.Name = "BtnCadastroVendedor";
            this.BtnCadastroVendedor.Size = new System.Drawing.Size(135, 40);
            this.BtnCadastroVendedor.TabIndex = 0;
            this.BtnCadastroVendedor.Text = "Criar";
            this.BtnCadastroVendedor.UseVisualStyleBackColor = true;
            this.BtnCadastroVendedor.Click += new System.EventHandler(this.BtnCadastroVendedor_Click);
            // 
            // BtnEditarVendedor
            // 
            this.BtnEditarVendedor.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnEditarVendedor.Location = new System.Drawing.Point(153, 61);
            this.BtnEditarVendedor.Name = "BtnEditarVendedor";
            this.BtnEditarVendedor.Size = new System.Drawing.Size(135, 40);
            this.BtnEditarVendedor.TabIndex = 1;
            this.BtnEditarVendedor.Text = "Editar";
            this.BtnEditarVendedor.UseVisualStyleBackColor = true;
            this.BtnEditarVendedor.Click += new System.EventHandler(this.BtnEditarVendedor_Click);
            // 
            // BtnExcluirVendedor
            // 
            this.BtnExcluirVendedor.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnExcluirVendedor.Location = new System.Drawing.Point(294, 61);
            this.BtnExcluirVendedor.Name = "BtnExcluirVendedor";
            this.BtnExcluirVendedor.Size = new System.Drawing.Size(135, 40);
            this.BtnExcluirVendedor.TabIndex = 3;
            this.BtnExcluirVendedor.Text = "Excluir";
            this.BtnExcluirVendedor.UseVisualStyleBackColor = true;
            this.BtnExcluirVendedor.Click += new System.EventHandler(this.BtnExcluirVendedor_Click);
            // 
            // BtnCadastroCliente
            // 
            this.BtnCadastroCliente.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCadastroCliente.Location = new System.Drawing.Point(653, 61);
            this.BtnCadastroCliente.Name = "BtnCadastroCliente";
            this.BtnCadastroCliente.Size = new System.Drawing.Size(135, 40);
            this.BtnCadastroCliente.TabIndex = 2;
            this.BtnCadastroCliente.Text = "Cadatro Cliente";
            this.BtnCadastroCliente.UseVisualStyleBackColor = true;
            this.BtnCadastroCliente.Click += new System.EventHandler(this.BtnCadastroCliente_Click);
            // 
            // FrmVendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnCadastroCliente);
            this.Controls.Add(this.BtnExcluirVendedor);
            this.Controls.Add(this.BtnEditarVendedor);
            this.Controls.Add(this.BtnCadastroVendedor);
            this.Controls.Add(this.GridVendedores);
            this.KeyPreview = true;
            this.Name = "FrmVendedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vendedores";
            ((System.ComponentModel.ISupportInitialize)(this.GridVendedores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridVendedores;
        private System.Windows.Forms.Button BtnCadastroVendedor;
        private System.Windows.Forms.Button BtnEditarVendedor;
        private System.Windows.Forms.Button BtnExcluirVendedor;
        private System.Windows.Forms.Button BtnCadastroCliente;
    }
}