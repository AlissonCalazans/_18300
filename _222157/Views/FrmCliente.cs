using _222157.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18300.Views
{
    public partial class FrmCliente : Form
    {
        Cidade ci;
        Cliente cl;

        public FrmCliente()
        {
            InitializeComponent();
        }

        void limpaControles()
        {
            txtID.Clear();
            txtNome.Clear();
            txtUF.Clear();
            dtpDataNasc.Value = DateTime.Now;
            chkVenda.Checked = false;
            mskCPF.Clear();
            txtRenda.Clear();
            cboCidades.SelectedIndex = -1;
            picFoto.ImageLocation = "";
            
        }

        void carregarGrid(string pesquisa)
        {
            cl = new Cliente()
            {
                nome = pesquisa
            };
            dgvClientes.DataSource = cl.Consultar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty) return;

            cl = new Cliente()
            {
                nome = txtNome.Text,
                idCidade = (int)cboCidades.SelectedValue,
                dataNasc = dtpDataNasc.Value,
                renda = double.Parse(txtRenda.Text),
                cpf = mskCPF.Text,
                foto = picFoto.ImageLocation,
                venda = chkVenda.Checked,
            };
            cl.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            //Cria um objeto do tipo cidade
            //E alimenta o combobox
            ci = new Cidade();
            cboCidades.DataSource = ci.Consultar();
            cboCidades.DisplayMember = "nome";
            cboCidades.ValueMember = "id";
            limpaControles();
            carregarGrid("");

            //Deixa invisível colunas do Grid
            dgvClientes.Columns["idCidade"].Visible = false;
            dgvClientes.Columns["foto"].Visible = false;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir o Cliente?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cl = new Cliente()
                {
                    id = int.Parse(txtID.Text)
                };
                cl.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.Rows.Count > 0)
            {
                txtID.Text = dgvClientes.CurrentRow.Cells["id"].Value.ToString();
                txtNome.Text = dgvClientes.CurrentRow.Cells["nome"].Value.ToString();
                txtRenda.Text = dgvClientes.CurrentRow.Cells["renda"].Value.ToString();
                mskCPF.Text = dgvClientes.CurrentRow.Cells["cpf"].Value.ToString();
                cboCidades.SelectedValue = int.Parse(dgvClientes.CurrentRow.Cells["idCidade"].Value.ToString());
                chkVenda.Checked = (bool)dgvClientes.CurrentRow.Cells["venda"].Value;
                picFoto.ImageLocation = dgvClientes.CurrentRow.Cells["foto"].Value.ToString();
                dtpDataNasc.Value = (DateTime)dgvClientes.CurrentRow.Cells["dataNasc"].Value;
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboCidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCidades.SelectedIndex != -1)
            {
                DataRowView reg = (DataRowView)cboCidades.SelectedItem;
                txtUF.Text = reg["uf"].ToString();
            }
        }

        private void picFoto_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "D:/fotos/clientes/";
            ofdArquivo.FileName = "";
            ofdArquivo.ShowDialog();
            picFoto.ImageLocation = ofdArquivo.FileName;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisar.Text);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty) return;

            cl = new Cliente()
            {
                id = int.Parse(txtID.Text),
                nome = txtNome.Text,
                idCidade = (int)cboCidades.SelectedValue,
                dataNasc = dtpDataNasc.Value,
                renda = double.Parse(txtRenda.Text),
                cpf = mskCPF.Text,
                foto = picFoto.ImageLocation,
                venda = chkVenda.Checked,
            };
            cl.Alterar();

            limpaControles();
            carregarGrid("");
        }
    }
}
