using Acr.UserDialogs;
using AnswerDBApp.Models;
using AnswerDBApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AnswerDBApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BienvenidaPage : ContentPage
    {
        UserViewModel viewModel;
        public BienvenidaPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new UserViewModel();
            GlobalObjects.LocalUser = null;
        }

        private async void BtnEnter_Clicked(object sender, EventArgs e)
        {
            //Ingreso del Usuario

            UserDTO user = new UserDTO();

            try
            {
                UserDialogs.Instance.ShowLoading("Cheking User Access data...");

                await Task.Delay(2000);


                user = await viewModel.GetUserByID(6);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                UserDialogs.Instance.HideLoading();

            }
            

            if (user != null)
            {
                GlobalObjects.LocalUser = user;

                if (GlobalObjects.LocalUser.UserStatusId == 1)
                {
                    await DisplayAlert("Validation Successfull", "You have enter as " + $"{GlobalObjects.LocalUser.FirstName}"+" " + $"{GlobalObjects.LocalUser.LastName}." +
                        Environment.NewLine + "With the user: " + $"{GlobalObjects.LocalUser.UserName}", "OK");
                    await Navigation.PushAsync(new PreguntaPage());
                    
                }
                else
                {
                    await DisplayAlert("Validation Error", "User is inactive!, contact the administrators to activate", "OK");
                    GlobalObjects.LocalUser = null;
                }
                return;
            }
            else
            {
                await DisplayAlert("Validation Error", "User couldn´t be found!, Access Denied", "OK");
                return;
            }
        }

        private async void BtnExit_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Closing", "See you next time!", "Bye!");
            Environment.Exit(0);
        }

        private async void BtnVerPreguntas_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListadoPage());
        }
    }
}