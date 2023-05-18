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
    public partial class FrmMarca : Form
    {
        Marca m;
        public FrmMarca()
        {
            InitializeComponent();
        }

        void limpaControles()
        {
            txtID.Clear();
            txtMarca.Clear();
            txtPesquisar.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            m = new Marca()
            {
                marca = pesquisa
            };
            dgvCidades.DataSource = m.Consultar();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtMarca.Text == String.Empty) return;
            m = new Marca()
            {
                marca = txtMarca.Text,

            };
            m.Incluir();

            limpaControles();
            carregarGrid("");
        }

        private void FrmMarca_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            m = new Marca()
            {
                id = int.Parse(txtID.Text),
                marca = txtMarca.Text
            };
            m.Alterar();

            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") return;

            if (MessageBox.Show("Deseja excluir a marca?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m = new Marca()
                {
                    id = int.Parse(txtID.Text)
                };
                m.Excluir();

                limpaControles();
                carregarGrid("");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisar.Text);
        }

        private void dgvCidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvCidades.Rows.Count > 0)
            {
                txtID.Text = dgvCidades.CurrentRow.Cells["id"].Value.ToString();
                txtMarca.Text = dgvCidades.CurrentRow.Cells["marca"].Value.ToString();
            }
        }
    }
}
