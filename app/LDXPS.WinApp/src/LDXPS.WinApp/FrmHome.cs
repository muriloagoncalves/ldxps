using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LDXPS.Common;
using LDXPS.Common.Entidades;

namespace LDXPS.WinApp
{
    public partial class FrmHome : Form
    {
        private readonly Servico _servico;
        private ListaRetornoApi<Vendedor> _vendedores;
        private Vendedor _vendedorSelecionado;
        public FrmHome()
        {
            InitializeComponent();
            _vendedores = new ListaRetornoApi<Vendedor>();
            var container = AppContainer.ObterContainer();
            _servico = container.GetInstance<Servico>();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ConfiguraGrid();
            await AtualizarGrid();
        }
        private void ConfiguraGrid()
        {
            GridViewVendedores.ReadOnly = true;

            GridViewVendedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //GridViewVendedores.Location = new Point(14, 14);
            //GridViewVendedores.Margin = new Padding(4, 3, 4, 3);
            GridViewVendedores.Name = "GridVendedores";
            //GridViewVendedores.Size = new Size(435, 298);
            //GridViewVendedores.TabIndex = 0;
            GridViewVendedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //GridViewVendedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            GridViewVendedores.AutoGenerateColumns = true;
            GridViewVendedores.DataMember = "Vendedores";
            GridViewVendedores.DataSource = _vendedores.ToList();
            GridViewVendedores.Columns["Codigo"].Visible = false;
            GridViewVendedores.Columns["Clientes"].Visible = false;
            GridViewVendedores.Columns["DataNascimento"].Visible = false;
            GridViewVendedores.Columns["CodigoPrecoPadrao"].Visible = false;
            GridViewVendedores.Columns["Nome"].Width = 400;

            GridViewClientes.ReadOnly = true;
            GridViewClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //GridViewClientes.Location = new Point(14, 14);
            //GridViewClientes.Margin = new Padding(4, 3, 4, 3);
            GridViewClientes.Name = "GridClientes";
            //GridViewClientes.Size = new Size(435, 298);
            //GridViewClientes.TabIndex = 0;
            GridViewClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //GridViewClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            GridViewClientes.AutoGenerateColumns = true;
            //GridViewClientes.DataMember = "Clientes";

            GridViewClientes.DataSource = new List<Cliente>();
            GridViewClientes.Columns["Codigo"].Visible = false;
            GridViewClientes.Columns["TipoPessoa"].Visible = false;
            GridViewClientes.Columns["Vendedor"].Visible = false;
            GridViewClientes.Columns["CodigoVendedor"].Visible = false;
            GridViewClientes.Columns["LimiteCredito"].Visible = false;
            GridViewClientes.Columns["Nome"].Width = 150;
        }

        private async Task AtualizarGrid()
        {
            _vendedores = await _servico.ObterVendedores();

            GridViewVendedores.DataSource = _vendedores.ToList();
        }
        private void BtnVendedores_Click(object sender, EventArgs e)
        {
            using var frmVendedor = new FrmVendedores();
            frmVendedor.ShowDialog(this);
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            using var frmClientes = new FrmClientes();
            frmClientes.ShowDialog(this);
        }

        private async void GridViewVendedores_Click(object sender, EventArgs e)
        {
            if (GridViewVendedores.CurrentRow != null)
            {
                _vendedorSelecionado = _vendedores[GridViewVendedores.CurrentRow.Index];
                if (_vendedorSelecionado == null) return;
                var vendedorCompleto = await _servico.ObterVendedor(_vendedorSelecionado.Codigo.ToString());
                AtualizarGridClientes(vendedorCompleto.Clientes.ToList());
            }
        }

        private void AtualizarGridClientes(IList<Cliente> clientes)
        {
            GridViewClientes.DataSource = clientes;
            GridViewClientes.Visible = clientes.Any();
        }

        private void BtnCriarVendedor_Click(object sender, EventArgs e)
        {
            using var frmCadatro = new FrmCadastroVendedor{ Adicionando = true };
            frmCadatro.ShowDialog(this);
        }

        private void BtnCriarCliente_Click(object sender, EventArgs e)
        {
            using var frmCadatro = new FrmCadastroCliente{ Adicionando = true};
            frmCadatro.ShowDialog(this);
        }

        private async void BtnEditarCliente_Click(object sender, EventArgs e)
        {
            if (GridViewClientes.CurrentRow == null) return;
            var vendedor = await _servico.ObterVendedor(_vendedorSelecionado.Codigo.ToString());
            var clientes = vendedor.Clientes.ToList();
            if (!clientes.Any()) return;
            var clienteSelecionado = clientes[GridViewClientes.CurrentRow.Index];
            if (clienteSelecionado == null) return;
            var clienteCompleto = await _servico.ObterCliente(clienteSelecionado.Codigo.ToString());
            using var frmCadatro = new FrmCadastroCliente
            {
                Adicionando = false,
                Cliente = clienteCompleto
            };
            frmCadatro.ShowDialog(this);
        }

        private async void BtnEditarVendedor_Click(object sender, EventArgs e)
        {
            if (GridViewVendedores.CurrentRow == null) return;
            var vendedor = _vendedores[GridViewVendedores.CurrentRow.Index];
            if (vendedor == null) return;
            var vendedorCompleto = await _servico.ObterVendedor(_vendedorSelecionado.Codigo.ToString());
            using var frmCadatro = new FrmCadastroVendedor
            {
                Adicionando = false,
                Vendedor = vendedorCompleto
            };
            frmCadatro.ShowDialog(this);
        }

        private void GridViewVendedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void BtnTodos_Click_1(object sender, EventArgs e)
        {
            await AtualizarGrid();
        }
    }
}
