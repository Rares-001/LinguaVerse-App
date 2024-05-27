using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LinguaVerse_App.Models;
using System.Linq;

namespace LinguaVerse_App.ViewModels
{
    public class QuizViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Question> Questions { get; set; }
        private string _result;

        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public Command CheckAnswersCommand { get; }

        public QuizViewModel()
        {
            Questions = new ObservableCollection<Question>
            {
                new Question
                {
                    QuestionText = "Are you a teacher?",
                    Answer = "Yes",
                    Choices = new ObservableCollection<string> { "Yes", "No" }
                },
                new Question
                {
                    QuestionText = "Is your name Marcus?",
                    Answer = "Yes",
                    Choices = new ObservableCollection<string> { "Yes", "No" }
                },
                new Question
                {
                    QuestionText = "Are your children here?",
                    Answer = "No, they aren't",
                    Choices = new ObservableCollection<string> { "Yes, they are", "No, they aren't" }
                },
                // Add more questions as needed
            };

            CheckAnswersCommand = new Command(CheckAnswers);
        }

        private void CheckAnswers()
        {
            bool allCorrect = Questions.All(q => q.Answer == q.Choices[0]); 
            Result = allCorrect ? "Correct" : "Wrong";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
