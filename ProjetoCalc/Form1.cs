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

        // Propriedades para armazenar o valor atual e o resultado
        public decimal Resultado { get; set; }
        public decimal Valor { get; set; }
        private Operacao OperacaoSelecionada { get; set; } = Operacao.Nenhuma; // Inicia sem nenhuma operação selecionada

        private enum Operacao
        {
            Nenhuma,
            Adicao,
            Subtracao,
            Multiplicacao,
            Divisao
        }

        // Evento genérico para botões numéricos
        private void btnNumero_Click(object sender, EventArgs e)
        {
            Button botao = sender as Button;
            if (botao != null)
            {
                // Evita que o primeiro número seja 0 repetidamente
                if (txtResultado.Text == "0")
                {
                    txtResultado.Text = botao.Text;
                }
                else
                {
                    txtResultado.Text += botao.Text; // Adiciona o número ao texto atual
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
                txtResultado.Text = ""; // Limpa o display para a próxima entrada
            }
        }

        private void btnSubtrair_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtResultado.Text, out decimal numero))
            {
                Valor = numero;
                OperacaoSelecionada = Operacao.Subtracao;
                txtResultado.Text = ""; // Limpa o display para a próxima entrada
            }
        }

        private void btnMultiplicar_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtResultado.Text, out decimal numero))
            {
                Valor = numero;
                OperacaoSelecionada = Operacao.Multiplicacao;
                txtResultado.Text = ""; // Limpa o display para a próxima entrada
            }
        }

        private void btnDividir_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtResultado.Text, out decimal numero))
            {
                Valor = numero;
                OperacaoSelecionada = Operacao.Divisao;
                txtResultado.Text = ""; // Limpa o display para a próxima entrada
            }
        }

        // Eventos individuais para botões numéricos de 0 a 9
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

        // Botão igual para calcular o resultado
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
                        if (numero != 0) // Previne divisão por zero
                        {
                            Resultado = Valor / numero;
                        }
                        else
                        {
                            MessageBox.Show("Erro: Divisão por zero!");
                            txtResultado.Text = "0"; // Reseta o display
                            return;
                        }
                        break;
                    default:
                        MessageBox.Show("Nenhuma operação foi selecionada.");
                        return;
                }

                // Mostra o resultado no display e reseta a operação
                txtResultado.Text = Resultado.ToString();
                OperacaoSelecionada = Operacao.Nenhuma;
            }
            else
            {
                MessageBox.Show("Entrada inválida!");
            }
        }

        // Botão para limpar o display e resetar valores
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = ""; // Reseta o display
            Valor = 0; // Reseta o valor armazenado
            Resultado = 0; // Reseta o resultado
            OperacaoSelecionada = Operacao.Nenhuma; // Reseta a operação
        }

        // Botão para adicionar uma vírgula decimal
        private void btnVirgula_Click(object sender, EventArgs e)
        {
            if (!txtResultado.Text.Contains(",")) // Adiciona vírgula apenas se não existir
            {
                txtResultado.Text += ",";
            }
        }
    }
}
