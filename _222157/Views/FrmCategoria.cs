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

namespace _222157.Views
{
    public partial class FrmCategoria : Form
    {
        Categoria c;
        public FrmCategoria()
        {
            InitializeComponent();
        }

        void limpaControles()
        {
            txtID.Clear();
            txtCategoria.Clear();
            txtPesquisar.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            c = new Categoria()
            {
                categoria = pesquisa
            };
            dgvCidades.DataSource = c.Consultar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text == String.Empty) return;
            c = new Categoria()
            {
                categoria = txtCategoria.Text,
            };
            c.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            c = new Categoria()
            {
                id = int.Parse(txtID.Text),
                categoria = txtCategoria.Text,
            };
            c.Alterar();

            limpaControles();
            carregarGrid("");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir a categoria?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Categoria()
                {
                    id = int.Parse(txtID.Text)
                };
                c.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisar.Text);
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void dgvCidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCidades.Rows.Count > 0)
            {
                txtID.Text = dgvCidades.CurrentRow.Cells["id"].Value.ToString();
                txtCategoria.Text = dgvCidades.CurrentRow.Cells["categoria"].Value.ToString();
            }
        }
    }
}
