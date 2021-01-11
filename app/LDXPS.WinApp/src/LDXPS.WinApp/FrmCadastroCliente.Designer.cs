
namespace LDXPS.WinApp
{
    partial class FrmCadastroCliente
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
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnConfirmar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonPF = new System.Windows.Forms.RadioButton();
            this.radioButtonPJ = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnCriarVendedor = new System.Windows.Forms.Button();
            this.listViewVendedores = new System.Windows.Forms.ListView();
            this.txtLimiteCredito = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnExcluir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnExcluir.Location = new System.Drawing.Point(372, 396);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(120, 42);
            this.BtnExcluir.TabIndex = 7;
            this.BtnExcluir.Text = "Excluir";
            this.BtnExcluir.UseVisualStyleBackColor = true;
            this.BtnExcluir.Visible = false;
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnConfirmar.ForeColor = System.Drawing.Color.Green;
            this.BtnConfirmar.Location = new System.Drawing.Point(37, 396);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(120, 42);
            this.BtnConfirmar.TabIndex = 6;
            this.BtnConfirmar.Text = "Confirmar";
            this.BtnConfirmar.UseVisualStyleBackColor = true;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNome.Location = new System.Drawing.Point(37, 43);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(359, 27);
            this.txtNome.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Limite de crédito";
            // 
            // radioButtonPF
            // 
            this.radioButtonPF.AutoSize = true;
            this.radioButtonPF.Checked = true;
            this.radioButtonPF.Location = new System.Drawing.Point(37, 113);
            this.radioButtonPF.Name = "radioButtonPF";
            this.radioButtonPF.Size = new System.Drawing.Size(38, 19);
            this.radioButtonPF.TabIndex = 12;
            this.radioButtonPF.TabStop = true;
            this.radioButtonPF.Text = "PF";
            this.radioButtonPF.UseVisualStyleBackColor = true;
            // 
            // radioButtonPJ
            // 
            this.radioButtonPJ.AutoSize = true;
            this.radioButtonPJ.Location = new System.Drawing.Point(81, 113);
            this.radioButtonPJ.Name = "radioButtonPJ";
            this.radioButtonPJ.Size = new System.Drawing.Size(35, 19);
            this.radioButtonPJ.TabIndex = 13;
            this.radioButtonPJ.TabStop = true;
            this.radioButtonPJ.Text = "PJ";
            this.radioButtonPJ.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tipo Pessoa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Vendedor";
            // 
            // BtnCriarVendedor
            // 
            this.BtnCriarVendedor.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCriarVendedor.Location = new System.Drawing.Point(372, 129);
            this.BtnCriarVendedor.Name = "BtnCriarVendedor";
            this.BtnCriarVendedor.Size = new System.Drawing.Size(119, 31);
            this.BtnCriarVendedor.TabIndex = 17;
            this.BtnCriarVendedor.Text = "Criar Vendedor";
            this.BtnCriarVendedor.UseVisualStyleBackColor = true;
            this.BtnCriarVendedor.Click += new System.EventHandler(this.BtnCriarVendedor_Click);
            // 
            // listViewVendedores
            // 
            this.listViewVendedores.HideSelection = false;
            this.listViewVendedores.Location = new System.Drawing.Point(37, 166);
            this.listViewVendedores.Name = "listViewVendedores";
            this.listViewVendedores.Size = new System.Drawing.Size(455, 209);
            this.listViewVendedores.TabIndex = 18;
            this.listViewVendedores.UseCompatibleStateImageBehavior = false;
            this.listViewVendedores.View = System.Windows.Forms.View.List;
            // 
            // txtLimiteCredito
            // 
            this.txtLimiteCredito.Location = new System.Drawing.Point(198, 108);
            this.txtLimiteCredito.Name = "txtLimiteCredito";
            this.txtLimiteCredito.Size = new System.Drawing.Size(100, 23);
            this.txtLimiteCredito.TabIndex = 19;
            this.txtLimiteCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FrmCadastroCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 450);
            this.Controls.Add(this.txtLimiteCredito);
            this.Controls.Add(this.listViewVendedores);
            this.Controls.Add(this.BtnCriarVendedor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButtonPJ);
            this.Controls.Add(this.radioButtonPF);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.BtnExcluir);
            this.Controls.Add(this.BtnConfirmar);
            this.KeyPreview = true;
            this.Name = "FrmCadastroCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnConfirmar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonPF;
        private System.Windows.Forms.RadioButton radioButtonPJ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnCriarVendedor;
        private System.Windows.Forms.ListView listViewVendedores;
        private System.Windows.Forms.MaskedTextBox txtLimiteCredito;
    }
}