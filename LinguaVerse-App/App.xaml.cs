﻿namespace LinguaVerse_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LogInPage());

            MainPage = new AppShell();
        }
    }
}
