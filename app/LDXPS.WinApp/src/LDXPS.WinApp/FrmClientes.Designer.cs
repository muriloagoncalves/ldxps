
namespace LDXPS.WinApp
{
    partial class FrmClientes
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
            this.GridViewClientes = new System.Windows.Forms.DataGridView();
            this.BtnCadastroCliente = new System.Windows.Forms.Button();
            this.BtnEditarCliente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // GridViewClientes
            // 
            this.GridViewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewClientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GridViewClientes.Location = new System.Drawing.Point(0, 122);
            this.GridViewClientes.Name = "GridViewClientes";
            this.GridViewClientes.RowTemplate.Height = 25;
            this.GridViewClientes.Size = new System.Drawing.Size(800, 328);
            this.GridViewClientes.TabIndex = 0;
            // 
            // BtnCadastroCliente
            // 
            this.BtnCadastroCliente.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCadastroCliente.Location = new System.Drawing.Point(12, 68);
            this.BtnCadastroCliente.Name = "BtnCadastroCliente";
            this.BtnCadastroCliente.Size = new System.Drawing.Size(175, 48);
            this.BtnCadastroCliente.TabIndex = 2;
            this.BtnCadastroCliente.Text = "Criar Cliente";
            this.BtnCadastroCliente.UseVisualStyleBackColor = true;
            // 
            // BtnEditarCliente
            // 
            this.BtnEditarCliente.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnEditarCliente.Location = new System.Drawing.Point(193, 68);
            this.BtnEditarCliente.Name = "BtnEditarCliente";
            this.BtnEditarCliente.Size = new System.Drawing.Size(175, 48);
            this.BtnEditarCliente.TabIndex = 3;
            this.BtnEditarCliente.Text = "Editar Cliente";
            this.BtnEditarCliente.UseVisualStyleBackColor = true;
            this.BtnEditarCliente.Click += new System.EventHandler(this.BtnEditarCliente_Click);
            // 
            // FrmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnEditarCliente);
            this.Controls.Add(this.BtnCadastroCliente);
            this.Controls.Add(this.GridViewClientes);
            this.Name = "FrmClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmClientes";
            ((System.ComponentModel.ISupportInitialize)(this.GridViewClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridViewClientes;
        private System.Windows.Forms.Button BtnCadastroCliente;
        private System.Windows.Forms.Button BtnEditarCliente;
    }
}