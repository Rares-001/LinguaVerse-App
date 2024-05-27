using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguaVerse_App.Models
{
    public class Question
    {
        public string QuestionText { get; set; }
        public string Answer { get; set; }
        public ObservableCollection<string> Choices { get; set; }
    }
}

