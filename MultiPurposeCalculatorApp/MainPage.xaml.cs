using System;
using Xamarin.Forms;

namespace MultiPurposeCalculatorApp
{
    public partial class MainPage : ContentPage
    {
	    /*
	    GLOBAL FILE VARIABLES
		 */

	    private string _navigationClickedHex = "#005395";
	    private string _navigationUnclickedHex = "#0297df";
	    
        public MainPage()
        {
            InitializeComponent();
        }

        // WelcomeStackLayout event handlers
		private void HomeImageButton_Clicked(object sender, EventArgs e)
		{
			ClickedOrUnclicked(HomeImageButton);
			
			SwitchXamlPages(WelcomeStackLayout);
			CalcModesGrid.IsVisible = true;
			NavigationInstructionLabel.IsVisible = true;
		}

		private void ConversionCalcImageButton_Clicked(object sender, EventArgs e)
		{
			ClickedOrUnclicked(ConversionCalcImageButton);
			SwitchXamlPages(ConversionCalculator);
		}

		private void AreaCalcImageButton_Clicked(object sender, EventArgs e)
		{
			ClickedOrUnclicked(AreaCalcImageButton);
			SwitchXamlPages(AreaCalculator);
		}

		private void VolumeCalcImageButton_Clicked(object sender, EventArgs e)
		{
			ClickedOrUnclicked(VolumeCalcImageButton);
			SwitchXamlPages(VolumeCalculator);
		}

		private void DateCalcImageButton_Clicked(object sender, EventArgs e)
		{
			ClickedOrUnclicked(DateCalcImageButton);
			SwitchXamlPages(DateCalculator);
		}

		private void AboutImageButton_Clicked(object sender, EventArgs e)
		{
			ClickedOrUnclicked(AboutImageButton);
			SwitchXamlPages(AboutStackLayout);
		}

		private void SettingsImageButton_Clicked(object sender, EventArgs e)
		{
			ClickedOrUnclicked(SettingsImageButton);
			SwitchXamlPages(SettingsStackLayout);
		}
		
		// AreaCalculator event handlers
		private void AreaShapePicker_OnSelectedIndexChanged(object sender, EventArgs e)
		{
			if (AreaShapePicker.SelectedIndex == 0)
			{
				ChangeAreaShapeCalculation(SquareAreaStackLayout);
				SquareFirstSideEntry.Placeholder = "Length (l)";
				SquareSecondSideEntry.Placeholder = "Width (w)";
				ChangeAreaImages(AreaFirstImage, AreaSecondImage, "icons8_border_left_48.png", "icons8_border_bottom_48.png");
			}
			else if (AreaShapePicker.SelectedIndex == 1)
			{
				ChangeAreaShapeCalculation(SquareAreaStackLayout);
				SquareFirstSideEntry.Placeholder = "Length (l)";
				SquareSecondSideEntry.Placeholder = "Width (w)";
			}
			else if (AreaShapePicker.SelectedIndex == 2)
			{
				ChangeAreaShapeCalculation(TriangleAreaStackLayout);
			}
			else if (AreaShapePicker.SelectedIndex == 3)
			{
				ChangeAreaShapeCalculation(SquareAreaStackLayout);
				SquareFirstSideEntry.Placeholder = "Base (b)";
				SquareSecondSideEntry.Placeholder = "Height (h)";
			}
			else if (AreaShapePicker.SelectedIndex == 4)
			{
				ChangeAreaShapeCalculation(TrapezoidStackLayout);
			}
			else if (AreaShapePicker.SelectedIndex == 5)
			{
				ChangeAreaShapeCalculation(CircleStackLayout);
			}
		}

		private void SquareFirstSideEntry_OnFocused(object sender, FocusEventArgs e)
		{
			SwitchDiagramImages(AreaFirstImage, AreaSecondImage, AreaFirstImage);
		}
		
		private void SquareSecondSideEntry_OnFocused(object sender, FocusEventArgs e)
		{
			SwitchDiagramImages(AreaFirstImage, AreaSecondImage, AreaSecondImage);
		}
		
		private void CalculateSquareAreaButton_OnClicked(object sender, EventArgs e)
		{
			AreaFirstImage.IsVisible = false;
			AreaSecondImage.IsVisible = false;
			
			if (AreaUnitsChipsGroup.SelectedItem == "Yards (yd)")
			{
				SquareRectangleArea("yd");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Feet (ft)")
			{
				SquareRectangleArea("ft");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Inches (in)")
			{
				SquareRectangleArea("in");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Kilometers (km)")
			{
				SquareRectangleArea("km");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Meters (m)")
			{
				SquareRectangleArea("m");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Centimeters (cm)")
			{
				SquareRectangleArea("cm");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Millimeters (mm)")
			{
				SquareRectangleArea("mm");
			}

			void SquareRectangleArea(string areaUnit)
			{
				if ((SquareFirstSideEntry.Text == null && SquareSecondSideEntry.Text == null) || (SquareFirstSideEntry.Text == "" && SquareSecondSideEntry.Text == ""))
				{
					SquareAreaErrorLabel.IsVisible = true;
				}
				else
				{
					AreaResultEntry.IsVisible = true;
					double SquareFirstSideEntryDouble = double.Parse(SquareFirstSideEntry.Text);
					double SquareSecondSideEntryDouble = double.Parse(SquareSecondSideEntry.Text);
					AreaResultEntry.Text = $"Area = {SquareFirstSideEntryDouble * SquareSecondSideEntryDouble} {areaUnit}\u00b2";
				}
			}
		}
		
		// Settings Page event handlers
		private void DarkModeSwitch_OnToggled(object sender, ToggledEventArgs e)
		{
			if (DarkModeSwitch.IsToggled == true)
			{
				EnableDarkMode("#434343", "#555555");
			}
			else
			{
				DisableDarkMode("#0173b7", "", "");
			}
		}
		
		/*
		 UNDERLYING PROGRAM METHODS AND FUNCTIONS
		 */

		private void ChangeAreaImages(Image firstImage, Image secondImage, string firstImgSource, string secondImgSource)
		{
			firstImage.Source = firstImgSource;
			secondImage.Source = secondImgSource;
		}
		
		private void SwitchDiagramImages(Image firstDiagram, Image secondDiagram, Image showingDiagram)
		{
			AreaResultEntry.IsVisible = false;
			// Method that allows you to change the informational
			// diagram shown to the user in any calculator page.
			firstDiagram.IsVisible = false;
			secondDiagram.IsVisible = false;

			showingDiagram.IsVisible = true;
		}
		
		private void ChangeAreaShapeCalculation(StackLayout change)
		{
			// Hides the initial instructional text on the
			// AreaCalculator page and changes the StackLayout
			// depending on what shape is selected.
			AreaCalcBeginLabel.IsVisible = false;
			SquareAreaStackLayout.IsVisible = false;
			TriangleAreaStackLayout.IsVisible = false;
			TrapezoidStackLayout.IsVisible = false;
			CircleStackLayout.IsVisible = false;
			
			change.IsVisible = true;
		}
		
		private void ClickedOrUnclicked(ImageButton clicked)
		{
			// Local method that resets all the background colors of
			// each ImageButton to a non-clicked state, then sets the
			// desired parameter-based ImageButton to have a BackgroundColor
			// of a clicked state.
			
			HomeImageButton.BackgroundColor = Color.FromHex(_navigationUnclickedHex);
			ConversionCalcImageButton.BackgroundColor = Color.FromHex(_navigationUnclickedHex);
			AreaCalcImageButton.BackgroundColor = Color.FromHex(_navigationUnclickedHex);
			VolumeCalcImageButton.BackgroundColor = Color.FromHex(_navigationUnclickedHex);
			DateCalcImageButton.BackgroundColor = Color.FromHex(_navigationUnclickedHex);
			AboutImageButton.BackgroundColor = Color.FromHex(_navigationUnclickedHex);
			SettingsImageButton.BackgroundColor = Color.FromHex(_navigationUnclickedHex);

			clicked.BackgroundColor = Color.FromHex(_navigationClickedHex);
		}
		
		private void SwitchXamlPages(StackLayout visiblePage)
		{
			// Local method that resets all the StackLayout
			// "pages," to a false visibility value and then
			// setting a parameter-based StackLayout component
			// to have a visibility of true.

			WelcomeStackLayout.IsVisible = false;
			CalcModesGrid.IsVisible = false;
			NavigationInstructionLabel.IsVisible = false;
			
			ConversionCalculator.IsVisible = false;
			AreaCalculator.IsVisible = false;
			VolumeCalculator.IsVisible = false;
			DateCalculator.IsVisible = false;
			AboutStackLayout.IsVisible = false;
			SettingsStackLayout.IsVisible = false;

			visiblePage.IsVisible = true;
		}

		private void EnableDarkMode(string darkAccent1, string darkAccent2)
		{
			ExpandCalcMain.BackgroundColor = Color.FromHex("#262626");
			NavigationFlexLayout.BackgroundColor = Color.FromHex(darkAccent1);
			ImageButton1.BackgroundColor = Color.FromHex(darkAccent2);
			ImageButton2.BackgroundColor = Color.FromHex(darkAccent2);
			ImageButton3.BackgroundColor = Color.FromHex(darkAccent2);
			ImageButton4.BackgroundColor = Color.FromHex(darkAccent2);
			CalculateSquareAreaButton.BackgroundColor = Color.FromHex(darkAccent2);
		}
		
		private void DisableDarkMode(string lightAccent1, string lightAccent2, string lightAccent3)
		{
			ExpandCalcMain.BackgroundColor = Color.FromHex("#0297df");
			NavigationFlexLayout.BackgroundColor = Color.FromHex(lightAccent1);
		}
    }
}
