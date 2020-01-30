using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FreeWork001
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            _tutorialView.FinishAction = delegate
            {
                DisplayAlert("Finish", "Tutorial Finish", "Ok");
            };
            _tutorialView.ChangeIndex = delegate (int k)
            {
                Debug.WriteLine("Changed " + k);
            };

            List<Tutorial> Tutorials = new List<Tutorial>();
            Tutorials.Add(new Tutorial { CoverImgUrl = "img_tutorial01", Index = 0, Title = "TEAMWORKS", Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..." });
            Tutorials.Add(new Tutorial { CoverImgUrl = "img_tutorial02", Index = 1, Title = "STRAGEY", Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..." });
            Tutorials.Add(new Tutorial { CoverImgUrl = "img_tutorial03", Index = 2, Title = "START UP", Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..." });
            _tutorialView.Tutorials = Tutorials;
           
        }
    }
}
