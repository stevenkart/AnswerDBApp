using Acr.UserDialogs;
using AnswerDBApp.Models;
using AnswerDBApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnswerDBApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreguntaPage : ContentPage
    {
        AskViewModel viewModel;
        Ask MyLocalAsk { get; set; } // eliminar sino se usa

        public PreguntaPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AskViewModel();
            lblUser.Text = "Logged as: " + GlobalObjects.LocalUser.FirstName.ToString();
        }

        private async void BtnExit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnSeeQuestions_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListadoPage());
        }

        private void CleanSpaces()
        {
            TxtAsk.Text = null;
            TxtAskDetail.Text = null;
        }

        private void BtnSetNull_Clicked(object sender, EventArgs e)
        {
            CleanSpaces();
        }

        private async void BtnSaveAsk_Clicked(object sender, EventArgs e)
        {
            if (TxtAsk.Text == null || TxtAsk.Text.Trim() == "")
            {
                await DisplayAlert("Validation Error", "At least the question must be filled, it cannot be null, Ask Details can be null, if you want to.", "OK");
                return;  
            }
            else
            {
                try
                {
                    UserDialogs.Instance.ShowLoading("Posting your question...");

                    await Task.Delay(2000);


                    bool R = await viewModel.AddNewAsk(TxtAsk.Text.Trim(), TxtAskDetail.Text.Trim());

                    if (R)
                    {
                        await DisplayAlert("Ask Successfull posted", "You can watch the pending respond asks in the other page.", "OK");
                        CleanSpaces();
                    }
                    else
                    {
                        await DisplayAlert("Validation Error", "Ask couldn´t be Post!, Something went wrong!", "OK");
                        return;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    UserDialogs.Instance.HideLoading();

                }
            }
        }


    }
}