using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1.Servico.Modelo;
using App1.Servico;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //logoImage.Source
            button.Clicked += BuscarCep;

        }

        private void BuscarCep(object sender, EventArgs args)
        {
            //TODO -  Lógica do programa.
            //TODO - Validações.

            string localCep = "";

            try
            {
                localCep = cep.Text.Trim();//trim remove os espaços.


                if (localCep != string.Empty)
                {


                    if (IsValidCep(localCep))
                    {
                        try
                        {
                            Endereco end = ViaCepServico.BuscarEnderecoViaCep(localCep);
                            if (end != null)
                            {
                                resultado.Text = string.Format("Endereço: {0}, {1}, {2}, {3}", end.localidade, end.uf, end.logradouro, end.bairro);
                            }
                            else
                            {
                                DisplayAlert("CEP Error","CEP não encontrado: " + cep.Text, "OK");
                            }
                        }
                        catch (Exception e)
                        {
                            DisplayAlert("Internet Error", e.Message, "OK");
                        }
                    }
                    else if (localCep == string.Empty)
                    {

                        DisplayAlert("Erro", "Cep inválido! type only numbers!", "OK");
                    }
                }
                else
                {
                    resultado.Text = "Invalid entry, type 8 numbers!";
                }
            }
            catch
            {



                /// Abre uma janela de alerta!
                DisplayAlert("Erro", "Cep inválido! O CEP deve conter 8 caracteres", "OK");
            }



        }

        private bool IsValidCep(string cep)
        {

            if (cep.Length == 8)
            {

                int newCep = 0;

                return int.TryParse(cep, out newCep);

            }
            else
            {

                DisplayAlert("Erro", "Cep inválido! O CEP deve conter  8números", "OK");
            }

            return false;

        }

    }
}
