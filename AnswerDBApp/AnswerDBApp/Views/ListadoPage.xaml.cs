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
    public partial class ListadoPage : ContentPage
    {
        AskViewModel vm { get; set; }
        private int filter = 1;
        List<Ask> MyAskList { get; set; }
        public ListadoPage()
        {
            InitializeComponent();
            BindingContext = vm = new AskViewModel();
            LoadList();
        }

        protected override void OnAppearing() //metodo que al volver a mostrar la pagina, vuelve a refrescar la lista con la nueva DATA
        {
            LoadList();
        }

        private async void LoadList()
        {
            MyAskList = await vm.GetAsksByFilter(1);
            collectionViewAsks.ItemsSource = MyAskList;
            if (MyAskList == null)
            {
                lblNotList.IsVisible = true;
            }
            else
            {
                lblNotList.IsVisible = false;
            }
            MyAskList = null;
            BtnFilter.Text = "Pend";
            lblShow.Text = "Showing... " + BtnFilter.Text;
            BtnFilter.Text = "Resolved";

        }

        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnFilter_Clicked(object sender, EventArgs e)
        {
            if (filter == 1)
            {
                filter = 2;
                MyAskList = await vm.GetAsksByFilter(filter);
                collectionViewAsks.ItemsSource = MyAskList;
                if (MyAskList == null)
                {
                    lblNotList.IsVisible = true;
                }
                else
                {
                    lblNotList.IsVisible = false;
                }
                MyAskList = null;
                BtnFilter.Text = "Resolved";
                lblShow.Text = "Showing... " + BtnFilter.Text;
                BtnFilter.Text = "Deprecated";
            }
            else
            {
                if (filter == 2)
                {
                    filter = 3;
                    MyAskList = await vm.GetAsksByFilter(filter);
                    collectionViewAsks.ItemsSource = MyAskList;
                    if (MyAskList == null)
                    {
                        lblNotList.IsVisible = true;
                    }
                    else
                    {
                        lblNotList.IsVisible = false;
                    }
                    MyAskList = null;
                    BtnFilter.Text = "Deprecated";
                    lblShow.Text = "Showing... " + BtnFilter.Text;
                    BtnFilter.Text = "Pend";
                }
                else
                {
                    if (filter == 3)
                    {
                        filter = 1;
                        MyAskList = await vm.GetAsksByFilter(filter);
                        collectionViewAsks.ItemsSource = MyAskList;
                        if (MyAskList == null)
                        {
                            lblNotList.IsVisible = true;
                        }
                        else
                        {
                            lblNotList.IsVisible = false;
                        }
                        MyAskList = null;
                        BtnFilter.Text = "Pend";
                        lblShow.Text = "Showing... " + BtnFilter.Text;
                        BtnFilter.Text = "Resolved";
                    }
                }
            }
        }

        private async void collectionViewAsks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var itemSelected = e.CurrentSelection[0] as Ask;
            if (itemSelected != null)
            {
                await DisplayAlert("Ask Selected ", $"{itemSelected.Ask1}", "OK");     
            }
        }




    }
}