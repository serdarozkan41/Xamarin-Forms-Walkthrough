using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FreeWork001
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TutorialView : Grid
    {
        #region PROPS
        uint transitionTime = 750;

        public int TutorialIndex { get; set; } = 0;
        public bool IsLast { get; set; } = false;
        public bool IsFirst { get; set; } = true;

        private List<Tutorial> tutorials;
        public List<Tutorial> Tutorials
        {
            get { return tutorials; }
            set
            {
                tutorials = value;
                OnPropertyChanged();
                InitActiveTutorial();
                OnPropertyChanged("ActiveTutorial");
            }
        }

        private Tutorial activeTutorial;
        private Tutorial ActiveTutorial
        {
            get { return activeTutorial; }
            set
            {
                activeTutorial = value;
                OnPropertyChanged();
                ChangeTutorial();
            }
        }

        private Action finishAction;

        public Action FinishAction
        {
            get { return finishAction; }
            set { finishAction = value;
            }
        }

        #endregion

        #region MAIN
        public TutorialView()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        #endregion

        #region FUNCS
        private void BuNext_Tapped(object sender, EventArgs e)
        {
            if (TutorialIndex <= Tutorials.Count - 1 && IsLast == false)
            {
                TutorialIndex++;
                ActiveTutorial = Tutorials[TutorialIndex];

                if (CheckLast())
                    IsLast = true;
            }
            else
               FinishAction.Invoke();
        }

        private void BuPrev_Tapped(object sender, EventArgs e)
        {
            IsLast = false;
            if (TutorialIndex >= 0)
            {
                TutorialIndex--;
                ActiveTutorial = Tutorials[TutorialIndex];
            }
        }

        private async void StartAnim()
        {
            double displacement = ImgCover.Width;

            await Task.WhenAll(
                ImgCover.FadeTo(0, transitionTime, Easing.Linear),
                ImgCover.TranslateTo(-displacement, ImgCover.Y, transitionTime, Easing.CubicInOut));

            await LbTitle.FadeTo(0, transitionTime, Easing.Linear);
            await LbDescription.FadeTo(0, transitionTime, Easing.Linear);
        }

        private async void StopAnim()
        {
            double displacement = ImgCover.Width;

            await ImgCover.TranslateTo(displacement, 0, 0);
            await Task.WhenAll(
                ImgCover.FadeTo(1, transitionTime, Easing.Linear),
                ImgCover.TranslateTo(0, ImgCover.Y, transitionTime, Easing.CubicInOut));

            await LbTitle.FadeTo(1, transitionTime, Easing.Linear);
            await LbDescription.FadeTo(1, transitionTime, Easing.Linear);
        }

        private void ChangeTutorial()
        {
            StartAnim();
            ImgCover.Source = ActiveTutorial.CoverImgUrl;
            LbTitle.Text = ActiveTutorial.Title;
            LbDescription.Text = activeTutorial.Description;
            ChangePoint(TutorialIndex);
            StopAnim();
            if (TutorialIndex == 0)
                LbPrev.IsVisible = false;
            else
                LbPrev.IsVisible = true;

            if (TutorialIndex == Tutorials.Count - 1)
                LbNext.Text = "START";
            else
                LbNext.Text = "NEXT";
        }

        private void ChangePoint(int SelectedIndex)
        {
            for (int i = 0; i < SlPointList.Children.Count; i++)
            {
                Image pointImg = SlPointList.Children[i] as Image;
                if (i == SelectedIndex)
                    pointImg.Source = "ic_full";
                else
                    pointImg.Source = "ic_empty";
            }
        }

        private void InitActiveTutorial()
        {
            ActiveTutorial = Tutorials[TutorialIndex];
        }

        private bool CheckLast()
        {
            if (TutorialIndex == Tutorials.Count - 1)
                return true;
            else
                return false;
        }
        #endregion
    }
}