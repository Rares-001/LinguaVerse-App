using LinguaVerse_App.ViewModels;

namespace LinguaVerse_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new QuizViewModel();
        }
    }

}
