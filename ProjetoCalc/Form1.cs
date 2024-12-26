using System;
using System.Windows.Forms;

namespace ProjetoCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public decimal Resultado { get; set; }
        public decimal Valor { get; set; }
        private Operacao OperacaoSelecionada { get; set; } = Operacao.Nenhuma; 

        private enum Operacao
        {
            Nenhuma,
            Adicao,
            Subtracao,
            Multiplicacao,
            Divisao
        }
       
        private void btnNumero_Click(object sender, EventArgs e)
        {
            Button botao = sender as Button;
            if (botao != null)
            {
              
                if (txtResultado.Text == "0")
                {
                    txtResultado.Text = botao.Text;
                }
                else
                {
                    txtResultado.Text += botao.Text; 
                }
            }
        }

        // Eventos individuais para operações
        private void btnSomar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtResultado.Text, out decimal numero))
            {
                Valor = numero;
                OperacaoSelecionada = Operacao.Adicao;
                txtResultado.Text = ""; 
            }
        }

        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtResultado.Text, out decimal numero))
            {
                Valor = numero;
                OperacaoSelecionada = Operacao.Subtracao;
                txtResultado.Text = ""; 
            }
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtResultado.Text, out decimal numero))
            {
                Valor = numero;
                OperacaoSelecionada = Operacao.Multiplicacao;
                txtResultado.Text = ""; 
            }
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtResultado.Text, out decimal numero))
            {
                Valor = numero;
                OperacaoSelecionada = Operacao.Divisao;
                txtResultado.Text = ""; 
            }
        }

        
        private void btnZero_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "0";
        }

        private void btnUm_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "1";
        }

        private void btnDois_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "2";
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "3";
        }

        private void btnQuatro_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "4";
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "5";
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "6";
        }

        private void btnSete_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "7";
        }

        private void btnOito_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "8";
        }

        private void btnNove_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "9";
        }

       
        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtResultado.Text, out decimal numero))
            {
                switch (OperacaoSelecionada)
                {
                    case Operacao.Adicao:
                        Resultado = Valor + numero;
                        break;
                    case Operacao.Subtracao:
                        Resultado = Valor - numero;
                        break;
                    case Operacao.Multiplicacao:
                        Resultado = Valor * numero;
                        break;
                    case Operacao.Divisao:
                        if (numero != 0) 
                        {
                            Resultado = Valor / numero;
                        }
                        else
                        {
                            MessageBox.Show("Erro: Divisão por zero!");
                            txtResultado.Text = "0"; 
                            return;
                        }
                        break;
                    default:
                        MessageBox.Show("Nenhuma operação foi selecionada.");
                        return;
                }

                txtResultado.Text = Resultado.ToString();
                OperacaoSelecionada = Operacao.Nenhuma;
            }
            else
            {
                MessageBox.Show("Entrada inválida!");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = ""; 
            Valor = 0; 
            Resultado = 0; 
            OperacaoSelecionada = Operacao.Nenhuma; 
        }

       
        private void btnVirgula_Click(object sender, EventArgs e)
        {
            if (!txtResultado.Text.Contains(",")) 
            {
                txtResultado.Text += ",";
            }
        }
    }
}
