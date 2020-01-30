# ![Logo](https://i.ibb.co/KW48F2G/app-icon.png) Fristy.Walktrough

### Setup
* Available on NuGet: https://www.nuget.org/packages/Fristy.Walkthrough/ [![NuGet](https://img.shields.io/nuget/v/Plugin.Permissions.svg?label=NuGet)](https://www.nuget.org/packages/Fristy.Walkthrough/)

**Platform Support**

|Platform|Version|
| ------------------- | :-----------: |
|Xamarin.iOS|iOS 8+|
|Xamarin.Android|API 14+|

### Usage
```xaml
	    xmlns:freework001="clr-namespace:FreeWork001;assembly=FreeWork001"

<freework001:TutorialView x:Name="_tutorialView" />
```

```csharp
			//Finish Event
			_tutorialView.FinishAction = delegate
            {
                DisplayAlert("Finish", "Tutorial Finish", "Ok");
            };
			//Change Event
            _tutorialView.ChangeIndex = delegate (int k)
            {
                Debug.WriteLine("Changed " + k);
            };

			//Create List
            List<Tutorial> Tutorials = new List<Tutorial>();
            Tutorials.Add(new Tutorial { CoverImgUrl = "img_tutorial01", Index = 0, Title = "TEAMWORKS", Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..." });
            Tutorials.Add(new Tutorial { CoverImgUrl = "img_tutorial02", Index = 1, Title = "STRAGEY", Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..." });
            Tutorials.Add(new Tutorial { CoverImgUrl = "img_tutorial03", Index = 2, Title = "START UP", Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit..." });
			//Load List
            _tutorialView.Tutorials = Tutorials;
```
