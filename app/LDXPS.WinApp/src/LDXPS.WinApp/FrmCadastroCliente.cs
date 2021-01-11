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
    public partial class FrmCadastroCliente : Form
    {
        public bool Adicionando { get; internal set; }
        public Cliente Cliente { get; internal set; }
        private List<Vendedor> _vendedores;
        private readonly Servico _servico;
        public FrmCadastroCliente()
        {
            InitializeComponent();
            Cliente = new Cliente();
            _vendedores = new List<Vendedor>();
            var container = AppContainer.ObterContainer();
            _servico = container.GetInstance<Servico>();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var vendedores = await _servico.ObterVendedores();
            if (!vendedores.HouveErro) _vendedores = vendedores.ToList();

            ConfiguraComponentes();
            CarregarComponentes();

            AplicarEstilos();
            txtNome.Focus();
        }

        private void ConfiguraComponentes()
        {

            listViewVendedores.View = View.Details;
            listViewVendedores.MultiSelect = false;
            listViewVendedores.HideSelection = false;
            listViewVendedores.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listViewVendedores.FullRowSelect = true;

            var colCodigo = new ColumnHeader();
            colCodigo.Text = "Codigo";
            colCodigo.TextAlign = HorizontalAlignment.Left;
            colCodigo.Width = 100;


            var colNome = new ColumnHeader();
            colNome.Text = "Nome";
            colNome.TextAlign = HorizontalAlignment.Left;
            colNome.Width = 250;

            listViewVendedores.Columns.Add(colCodigo);
            listViewVendedores.Columns.Add(colNome);
        }

        private void CarregarComponentes()
        {
            txtNome.Text = Cliente.Nome;
            txtLimiteCredito.Text = Cliente.LimiteCredito.ToString("N0");
            radioButtonPF.Checked = Cliente.TipoPessoa == "PF";
            radioButtonPJ.Checked = Cliente.TipoPessoa == "PJ";


            foreach (var v in _vendedores)
            {
                var listItem = new ListViewItem(v.Codigo.ToString());
                listItem.SubItems.Add(v.Nome);
                listViewVendedores.Items.Add(listItem);
            }

        }

        private void AplicarEstilos()
        {
            BtnExcluir.Visible = !Adicionando;
        }
        private void AtualizarObjeto()
        {
            Cliente.Nome = txtNome.Text;
            if (decimal.TryParse(txtLimiteCredito.Text, out var limite)) Cliente.LimiteCredito = Math.Round(limite, 2);
            Cliente.TipoPessoa = radioButtonPJ.Checked ? "PJ" : "PF";
            if (listViewVendedores.FocusedItem != null) Cliente.CodigoVendedor = new Guid(listViewVendedores.FocusedItem.Text);
        }

        private async void BtnConfirmar_Click(object sender, EventArgs e)
        {
            AtualizarObjeto();
            if (Adicionando)
            {
                var retorno = await _servico.AdicionarCliente(Cliente);
                if (retorno)
                {
                    MessageBox.Show("Incluido com sucesso!");
                    Close();
                }
            }
            else
            {
                var retorno = await _servico.AtualizarCliente(Cliente.Codigo.ToString(), Cliente);
                if (retorno)
                {
                    MessageBox.Show("Alterado com sucesso!");
                    Close();
                }
            }
        }

        private async void BtnExcluir_Click(object sender, EventArgs e)
        {
            var retorno = await _servico.DeletarCliente(Cliente.Codigo.ToString());
            if (retorno)
            {
                MessageBox.Show("Excluido com sucesso!!!");
                Close();
            }
        }

        private void BtnCriarVendedor_Click(object sender, EventArgs e)
        {
            using var frmCadatro = new FrmCadastroVendedor { Adicionando = true };
            frmCadatro.ShowDialog(this);
        }
    }
}
