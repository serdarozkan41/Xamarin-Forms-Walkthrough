# Xamarin-Forms-Walkthrough
Xamarin Forms Tutorial Screens

Basic Usage


CS--
 List<Tutorial> Tutorials = new List<Tutorial>();
            Tutorials.Add(new Tutorial { CoverImgUrl = "img_tutorial01", Index = 0, Title = "TEAMWORKS", Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..." });
            Tutorials.Add(new Tutorial { CoverImgUrl = "img_tutorial02", Index = 1, Title = "STRAGEY", Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..." });
            Tutorials.Add(new Tutorial { CoverImgUrl = "img_tutorial03", Index = 2, Title = "START UP", Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..." });
            _tutorialView.Tutorials = Tutorials;
            _tutorialView.FinishAction = delegate
            {
                DisplayAlert("Finish", "Tutorial Finish", "Ok");
            };

XAML

xmlns:freework001="clr-namespace:FreeWork001"

<freework001:TutorialView
            x:Name="_tutorialView"
            HorizontalOptions="FillAndExpand"
            VerticalOptions="FillAndExpand" />
