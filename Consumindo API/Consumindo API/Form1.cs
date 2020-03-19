using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consumindo_API
{
    public partial class frmConsumirAPI : Form
    {
        public frmConsumirAPI()
        {
            InitializeComponent();
        }

        API.FilmeAPI filmeAPI = new API.FilmeAPI();
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Models.FilmeModel filmeModel = new Models.FilmeModel();
                filmeModel.DsCategoria = txtCategoria.Text;
                filmeModel.NmFilme = txtFilme.Text;
                filmeModel.DtLancamento = dtpLancamento.Value.Date;

                filmeAPI.Inserir(filmeModel);

                MessageBox.Show("Filme Registrado!");
                LimparCampos();
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro");
            }
        }

        private void btnFiltrarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                dgvLista.AutoGenerateColumns = false;
                dgvLista.DataSource = filmeAPI.ListarTodos();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(Exception)
            {
                MessageBox.Show("Ocorreu um erro");
            }
        }

        private void lblFechar_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception)
            {
                MessageBox.Show("_-_ Como deu erro aqui?");
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                Models.FilmeModel filmeModel = new Models.FilmeModel();
                filmeModel.IdFilme = Convert.ToInt32(nudID.Value);
                filmeModel.DsCategoria = txtCategoria.Text;
                filmeModel.NmFilme = txtFilme.Text;
                filmeModel.DtLancamento = dtpLancamento.Value.Date;

                filmeAPI.Alterar(filmeModel);

                MessageBox.Show("Registro alterado!");
                LimparCampos();
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro");
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(nudID.Value);
                filmeAPI.Remover(id);

                MessageBox.Show("Registro Removido!");
                LimparCampos();
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message); 
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro");
            }
        }

        public void LimparCampos()
        {
            txtCategoria.Text = string.Empty;
            txtFilme.Text = string.Empty;
            nudID.Value = 0;
        }

        private void dgvLista_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var func = dgvLista.CurrentRow.DataBoundItem as Models.FilmeModel;
            txtCategoria.Text = func.DsCategoria;
            txtFilme.Text = func.NmFilme;
            dtpLancamento.Value = func.DtLancamento;
            nudID.Value = func.IdFilme;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvLista.AutoGenerateColumns = false;
                dgvLista.DataSource = filmeAPI.ListarPorCategoria(txtFiltroCategoria.Text.Trim());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro");
            }
        }
    }
}
