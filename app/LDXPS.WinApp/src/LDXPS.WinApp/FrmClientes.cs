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
    public partial class FrmClientes : Form
    {
        private readonly Servico _servico;
        private ListaRetornoApi<Cliente> _clientes;
        public FrmClientes()
        {
            InitializeComponent();
            var container = AppContainer.Instance.Container;
            _servico = container.GetInstance<Servico>();
            _clientes = new ListaRetornoApi<Cliente>();
        }
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ConfiguraGrid();
            await AtualizarGrid();
        }

        private void ConfiguraGrid()
        {
            GridViewClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridViewClientes.Location = new Point(14, 14);
            GridViewClientes.Margin = new Padding(4, 3, 4, 3);
            GridViewClientes.Name = "GridClientes";
            GridViewClientes.Size = new Size(435, 298);
            GridViewClientes.TabIndex = 0;
            GridViewClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private async Task AtualizarGrid()
        {
            _clientes = await _servico.ObterClientes();

            GridViewClientes.DataSource = _clientes.ToList();
        }

        private void BtnEditarCliente_Click(object sender, EventArgs e)
        {

        }
    }
}
