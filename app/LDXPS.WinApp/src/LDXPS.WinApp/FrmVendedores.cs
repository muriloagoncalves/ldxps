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
    public partial class FrmVendedores : Form
    {
        private readonly Servico _servico;
        //private Pagination<Vendedor> _pagination;
        private ListaRetornoApi<Vendedor> _vendedores;
        public FrmVendedores()
        {
            var container = AppContainer.ObterContainer();
            _servico = container.GetInstance<Servico>();
            _vendedores = new ListaRetornoApi<Vendedor>();
            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ConfiguraGrid();
            await AtualizarGrid();
        }

        private void ConfiguraGrid()
        {
            GridVendedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridVendedores.Location = new Point(14, 14);
            GridVendedores.Margin = new Padding(4, 3, 4, 3);
            GridVendedores.Name = "GridVendedores";
            GridVendedores.Size = new Size(435, 298);
            GridVendedores.TabIndex = 0;
            GridVendedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private async Task AtualizarGrid()
        {
            _vendedores = await _servico.ObterVendedores();

            GridVendedores.DataSource = _vendedores.ToList();
        }

        private void BtnCadastroVendedor_Click(object sender, EventArgs e)
        {
            using var frmCadatro = new FrmCadastroVendedor();
            frmCadatro.ShowDialog(this);
        }

        private async void BtnExcluirVendedor_Click(object sender, EventArgs e)
        {
            if (GridVendedores.CurrentRow != null)
            {
                var vendedor = _vendedores[GridVendedores.CurrentRow.Index];
                if (vendedor == null) return;
                var retorno = await _servico.DeletarVendedor(vendedor.Codigo.ToString());
                if (retorno) MessageBox.Show("Excluido com sucesso!!!");
            }
        }

        private void BtnEditarVendedor_Click(object sender, EventArgs e)
        {
            if (GridVendedores.CurrentRow != null)
            {
                var vendedor = _vendedores[GridVendedores.CurrentRow.Index];
                if (vendedor == null) return;
                using var frmCadatro = new FrmCadastroVendedor()
                {
                    Adicionando = false,
                    Vendedor = vendedor
                };
                frmCadatro.ShowDialog(this);
            }
        }

        private void BtnCadastroCliente_Click(object sender, EventArgs e)
        {
            using var frmCadatro = new FrmCadastroCliente();
            frmCadatro.ShowDialog(this);
        }
    }
}
