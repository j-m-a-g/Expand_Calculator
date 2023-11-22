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
			}
			else if (AreaShapePicker.SelectedIndex == 1)
			{
				ChangeAreaShapeCalculation(SquareAreaStackLayout);
			}
			else if (AreaShapePicker.SelectedIndex == 2)
			{
				ChangeAreaShapeCalculation(TriangleAreaStackLayout);
			}
			else if (AreaShapePicker.SelectedIndex == 3)
			{
				ChangeAreaShapeCalculation(ParallelogramStackLayout);
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
		
		private void CalculateSquareAreaButton_OnClicked(object sender, EventArgs e)
		{
			string areaUnit;
			
			if (AreaUnitsChipsGroup.SelectedItem == "Yards (yd)")
			{
				areaUnit = "yd";
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Feet (ft)")
			{
				areaUnit = "ft";
			}
			
		}
		
		/*
		 UNDERLYING PROGRAM METHODS AND FUNCTIONS
		 */

		private void ChangeAreaShapeCalculation(StackLayout change)
		{
			AreaCalcBeginLabel.IsVisible = false;
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
    }
}
