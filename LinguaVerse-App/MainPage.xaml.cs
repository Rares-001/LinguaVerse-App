using LinguaVerse_App.Database;
using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;

namespace LinguaVerse_App
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);

            // Call the database connection method
            DatabaseConnection dbConnection = new DatabaseConnection();
            await dbConnection.ConnectAndReadAsync();
        }
    }
}
