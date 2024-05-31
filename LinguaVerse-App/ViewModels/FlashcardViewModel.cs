﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FlashcardApp;
using Microsoft.Maui.Controls;

namespace Flashcards.ViewModels // Ensure this matches your project's root namespace
{
    public class FlashcardViewModel : INotifyPropertyChanged
    {
        private int _currentIndex;
        private bool _isAnswerVisible;

        public ObservableCollection<Flashcard> Flashcards { get; set; }
        public Flashcard CurrentFlashcard => Flashcards[_currentIndex];

        public ICommand ShowAnswerCommand { get; }
        public ICommand PreviousCommand { get; }
        public ICommand NextCommand { get; }

        public bool IsAnswerVisible
        {
            get => _isAnswerVisible;
            set
            {
                _isAnswerVisible = value;
                OnPropertyChanged();
            }
        }

        public FlashcardViewModel()
        {
            Flashcards = new ObservableCollection<Flashcard>
            {
                new Flashcard { Question = "What is .NET MAUI?", Answer = "A framework for building cross-platform apps." },
                new Flashcard { Question = "What is C#?", Answer = "A programming language developed by Microsoft." },
                new Flashcard { Question = "What is XAML?", Answer = "A markup language for designing UI in .NET applications." }
            };

            ShowAnswerCommand = new Command(ShowAnswer);
            PreviousCommand = new Command(PreviousFlashcard);
            NextCommand = new Command(NextFlashcard);
            _currentIndex = 0;
            _isAnswerVisible = false;
        }

        private void ShowAnswer()
        {
            IsAnswerVisible = true;
        }

        private void PreviousFlashcard()
        {
            if (_currentIndex > 0)
            {
                _currentIndex--;
                OnPropertyChanged(nameof(CurrentFlashcard));
                IsAnswerVisible = false;
            }
        }

        private void NextFlashcard()
        {
            if (_currentIndex < Flashcards.Count - 1)
            {
                _currentIndex++;
                OnPropertyChanged(nameof(CurrentFlashcard));
                IsAnswerVisible = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
