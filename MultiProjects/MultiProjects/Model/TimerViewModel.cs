using MultiProjects.Data;
using MultiProjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultiProjects.Model
{
    public class TimerViewModel : BaseViewModel
    {
        private string _duration;

        private bool isVisiblePrevNavButton;
        private bool isVisibleNextNavButton;
        private bool isVisibleFinishButton;
        public TimerViewModel()
        {
            //StartTimerCommand = new Command(OnStartTimeExecute);
            StartTime = TimeSpan.FromSeconds(1);
           // StartTime = TimeSpan.FromSeconds(60);
            Duration = StartTime.ToString();
            OnStartTimeExecute();

            ProcessAnswerCommand = new Command((optionId) =>
            {

                var questions = QuestionData.GetQuestions.questions;
                var question = questions.Find(x => x.Id == Id);
                var option = question.Options.Find(x => x.Id == (int)optionId);
                option.IsSelected = !option.IsSelected;
                
            });

            FlagQuestionCommand = new Command(() =>
            {

                var questions = QuestionData.GetQuestions.questions;
                var question = questions.Find(x => x.Id == Id);
                question.IsFlagged = !question.IsFlagged;

            });

        }

      


        public ICommand ProcessAnswerCommand { get; private set; }

        public ICommand FlagQuestionCommand { get; private set; }

        public ICommand StartTimerCommand { get;  set; }

        public TimeSpan StartTime { get; set; }

        public bool IsVisibleNextNavButton
        {
            get
            {
                return this.isVisibleNextNavButton;
            }

            set
            {
                if (this.isVisibleNextNavButton == value)
                {
                    return;
                }

                this.isVisibleNextNavButton = value;
                this.NotifyPropertyChanged();
            }
        }


        public bool IsVisibleFinishButton
        {
            get
            {
                return this.isVisibleFinishButton;
            }

            set
            {
                if (this.isVisibleFinishButton == value)
                {
                    return;
                }

                this.isVisibleFinishButton = value;
                this.NotifyPropertyChanged();
            }
        }

        public bool IsVisiblePrevNavButton
        {
            get
            {
                return this.isVisiblePrevNavButton;
            }

            set
            {
                if (this.isVisiblePrevNavButton == value)
                {
                    return;
                }

                this.isVisiblePrevNavButton = value;
                this.NotifyPropertyChanged();
            }
        }

        public string Duration
        {
            get
            {
                return this._duration;
            }

            set
            {
                if (this._duration == value)
                {
                    return;
                }

                this._duration = value;
                //if (this._duration == "00:00:00")
                if (this._duration == "01:00/01:00")
                {
                    IsVisiblePrevNavButton = false;
                     IsVisibleNextNavButton = false;
                   // IsVisibleFinishButton = true;
                }
                this.NotifyPropertyChanged();
            }
        }

        public int Id { get; internal set; }

        private void OnStartTimeExecute()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                if (StartTime.TotalSeconds < 60)
                {
                    StartTime = StartTime + TimeSpan.FromSeconds(1);
                    Duration = StartTime.ToString().Substring(3) + "/" + "01:00";
                    
                    return true;
                }
                else
                {
                    return false;
                }

            });
        }

        //count down approach
        //private void OnStartTimeExecute()
        //{
        //    Device.StartTimer(TimeSpan.FromSeconds(1), () => {
        //        if (StartTime.TotalSeconds > 0)
        //        {
        //            StartTime = StartTime - TimeSpan.FromSeconds(1);
        //            Duration = StartTime.ToString();
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    });
        //}
    }


}
