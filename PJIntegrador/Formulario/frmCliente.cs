using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PJIntegrador.Classes;

namespace PJIntegrador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            mskCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // remove pontos e traços do cpf
            Cliente cliente = new Cliente(
                txtNome.Text,
                mskCpf.Text,
                txtEmail.Text,
                txtTelefone.Text
            );
            cliente.Inserir();

            Endereco endereco = new Endereco(
                txtCep.Text,
                txtLogradouro.Text,
                txtNumero.Text,
                txtTelefone.Text,
                txtBairro.Text,
                txtCidade.Text,
                cmbTipo.Text,
                txtUf.Text
            );
            endereco.Inserir(cliente.Id);
            MessageBox.Show("Cliente " + cliente.Id + " inserir");

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
