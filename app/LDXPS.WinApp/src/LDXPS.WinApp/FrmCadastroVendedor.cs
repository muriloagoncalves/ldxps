using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LDXPS.Common;
using LDXPS.Common.Entidades;
using LDXPS.Common.Extensions;

namespace LDXPS.WinApp
{
    public partial class FrmCadastroVendedor : Form
    {
        private readonly Servico _servico;
        public Vendedor Vendedor { get; set; }
        public bool Adicionando { get; set; }
        public FrmCadastroVendedor()
        {
            var container = AppContainer.ObterContainer();
            _servico = container.GetInstance<Servico>();
            Vendedor = new Vendedor();
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ConfigurarGrid();
            CarregarComponentes();

            AplicarEstilos();
            txtNome.Focus();
        }

        private void AplicarEstilos()
        {
            BtnExcluir.Visible = !Adicionando;
        }

        private void ConfigurarGrid()
        {
            GridViewClientes.ReadOnly = true;
            GridViewClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridViewClientes.Name = "GridClientes";
            GridViewClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            GridViewClientes.DataSource = Vendedor.Clientes ?? new List<Cliente>();
            GridViewClientes.Columns["Codigo"].Visible = false;
            GridViewClientes.Columns["TipoPessoa"].Visible = false;
            GridViewClientes.Columns["Vendedor"].Visible = false;
            GridViewClientes.Columns["CodigoVendedor"].Visible = false;
            GridViewClientes.Columns["LimiteCredito"].Visible = false;
            GridViewClientes.Columns["Nome"].Width = 250;
        }

        private void CarregarComponentes()
        {
            txtCodigoPrecoPadrao.Text = Vendedor.CodigoPrecoPadrao.ToString();
            txtNome.Text = Vendedor.Nome;
            txtDataNascimento.Text = Vendedor.DataNascimento?.ToString("d", CultureInfo.CurrentCulture);
        }

        private async void BtnConfirmar_Click(object sender, EventArgs e)
        {
            AtualizarObjeto();
            if (Adicionando)
            {
                var retorno = await _servico.AdicionarVendedor(Vendedor);
                if (retorno)
                {
                    MessageBox.Show("Incluido com sucesso!");
                    Close();
                }
            }
            else
            {
                var retorno = await _servico.AtualizarVendedor(Vendedor.Codigo.ToString(), Vendedor);
                if (retorno)
                {
                    MessageBox.Show("Alterado com sucesso!");
                    Close();
                }
            }
        }

        private void AtualizarObjeto()
        {
            Vendedor.Nome = txtNome.Text;
            Vendedor.CodigoPrecoPadrao = Convert.ToInt16(txtCodigoPrecoPadrao.Text.ApenasNumeros());
            if (!string.IsNullOrEmpty(txtDataNascimento.Text)) Vendedor.DataNascimento = DateTime.Parse(txtDataNascimento.Text);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            using var frmCadatro = new FrmCadastroCliente{ Adicionando = true };
            frmCadatro.ShowDialog(this);
        }

        private async void BtnExcluir_Click(object sender, EventArgs e)
        {
            var retorno = await _servico.DeletarVendedor(Vendedor.Codigo.ToString());
            if (retorno)
            {
                MessageBox.Show("Excluido com sucesso!!!");
                Close();
            }
        }

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            Vendedor = new Vendedor();
            CarregarComponentes();
            txtNome.Focus();
        }
    }
}
