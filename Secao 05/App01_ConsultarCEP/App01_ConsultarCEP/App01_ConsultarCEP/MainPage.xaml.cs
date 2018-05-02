using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
		}

        private void BuscarCEP(object sender, EventArgs e)
        {
            //TODO - Lógica do Programa

            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {

              try
                {
                    Endereco end = ViaCEPServico.BuscarEderecoViaCEP(cep);

                    if (end != null)
                    {
                       RESULTADO.Text = string.Format("Endereço: {0}, {1}, {2}", end.logradouro, end.bairro, end.localidade);
                    }else
                    {
                        DisplayAlert("Erro","Endereço não encontrado para o CEP informado.", "OK");
                    }

                   
                }
                catch(Exception ex)
                {
                    DisplayAlert("ERRO CRITICO", ex.Message, "OK");
                }
              
            }
        }



        private bool isValidCEP(string cep)
        {
            int novocep = 0;

            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "Cep informado deve possuir 8 caracteres", "OK");
                return false;
            }

            if (!int.TryParse(cep, out novocep))
            {
                DisplayAlert("Erro","Use somente números", "OK");

                return false;
            }


            return true;
        }
    }
}
