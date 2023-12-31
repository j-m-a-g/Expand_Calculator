﻿using System;
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

				SquareFirstSideEntry.Text = "";
				SquareSecondSideEntry.Text = "";
			}
			else if (AreaShapePicker.SelectedIndex == 1)
			{
				ChangeAreaShapeCalculation(SquareAreaStackLayout);
				SquareFirstSideEntry.Placeholder = "Length (l)";
				SquareSecondSideEntry.Placeholder = "Width (w)";
				
				ChangeAreaImages(AreaFirstImage, AreaSecondImage, "icons8_border_left_48.png", "icons8_border_bottom_48.png");
				
				SquareFirstSideEntry.Text = "";
				SquareSecondSideEntry.Text = "";
			}
			else if (AreaShapePicker.SelectedIndex == 2)
			{
				ChangeAreaShapeCalculation(TriangleAreaStackLayout);
				
				ChangeAreaImages(AreaFirstImage, AreaSecondImage, "triangle_base_image.png", "triangle_height_image.png");
			}
			else if (AreaShapePicker.SelectedIndex == 3)
			{
				ChangeAreaShapeCalculation(SquareAreaStackLayout);
				
				SquareFirstSideEntry.Placeholder = "Base (b)";
				SquareSecondSideEntry.Placeholder = "Height (h)";
				
				ChangeAreaImages(AreaFirstImage, AreaSecondImage, "parallelogram_base_image.png", "parallelogram_height_image.png");
				
				SquareFirstSideEntry.Text = "";
				SquareSecondSideEntry.Text = "";
			}
			else if (AreaShapePicker.SelectedIndex == 4)
			{
				ChangeAreaShapeCalculation(TrapezoidStackLayout);
				ChangeTrapezoidAreaImages(AreaFirstImage, AreaSecondImage, AreaThirdImage, "trapezoid_base_a_image.png", "trapezoid_base_b_image.png", "trapezoid_height.png");
			}
			else if (AreaShapePicker.SelectedIndex == 5)
			{
				ChangeAreaShapeCalculation(CircleStackLayout);
			}
		}

		private void SquareFirstSideEntry_OnFocused(object sender, FocusEventArgs e)
		{
			SwitchDiagramImages(AreaFirstImage, AreaSecondImage, AreaFirstImage);
			HideAreaErrorLabel();
		}
		
		private void SquareSecondSideEntry_OnFocused(object sender, FocusEventArgs e)
		{
			SwitchDiagramImages(AreaFirstImage, AreaSecondImage, AreaSecondImage);
			HideAreaErrorLabel();
		}
		
		private void CalculateSquareAreaButton_OnClicked(object sender, EventArgs e)
		{
			CheckUnitSelection();
			
			switch (AreaFirstImage.IsVisible)
			{
				case true:
				{
					AreaFirstImage.IsVisible = false;
					break;
				}
				case false:
				{
					break;
				}
				default:
				{
					AreaFirstImage.IsVisible = false;
					break;
				}
			}
			switch (AreaSecondImage.IsVisible)
			{
				case true:
				{
					AreaSecondImage.IsVisible = false;
					break;
				}
				case false:
				{
					break;
				}
				default:
				{
					AreaSecondImage.IsVisible = false;
					break;
				}
			}
			
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
				if (String.IsNullOrEmpty(SquareFirstSideEntry.Text) || String.IsNullOrEmpty(SquareSecondSideEntry.Text))
				{
					AreaErrorLabel.IsVisible = true;
				}
				else
				{
					HideAreaErrorLabel();
					AreaResultLabel.IsVisible = true;
					double squareFirstSideEntryDouble = double.Parse(SquareFirstSideEntry.Text);
					double squareSecondSideEntryDouble = double.Parse(SquareSecondSideEntry.Text);
					AreaResultLabel.Text = $"Area = {squareFirstSideEntryDouble * squareSecondSideEntryDouble} {areaUnit}\u00b2";
				}
			}
		}

		private void CalculateTriangleAreaButton_OnClicked(object sender, EventArgs e)
		{
			CheckUnitSelection();
			
			switch (AreaFirstImage.IsVisible)
			{
				case true:
				{
					AreaFirstImage.IsVisible = false;
					break;
				}
				case false:
				{
					break;
				}
				default:
				{
					AreaFirstImage.IsVisible = false;
					break;
				}
			}
			switch (AreaSecondImage.IsVisible)
			{
				case true:
				{
					AreaSecondImage.IsVisible = false;
					break;
				}
				case false:
				{
					break;
				}
				default:
				{
					AreaSecondImage.IsVisible = false;
					break;
				}
			}
			
			if (AreaUnitsChipsGroup.SelectedItem == "Yards (yd)")
			{
				TriangleArea("yd");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Feet (ft)")
			{
				TriangleArea("ft");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Inches (in)")
			{
				TriangleArea("in");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Kilometers (km)")
			{
				TriangleArea("km");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Meters (m)")
			{
				TriangleArea("m");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Centimeters (cm)")
			{
				TriangleArea("cm");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Millimeters (mm)")
			{
				TriangleArea("mm");
			}

			void TriangleArea(string areaUnit)
			{
				if (String.IsNullOrEmpty(TriangleBaseEntry.Text) || String.IsNullOrEmpty(TriangleHeightEntry.Text))
				{
					AreaErrorLabel.IsVisible = true;
				}
				else
				{
					HideAreaErrorLabel();
					AreaResultLabel.IsVisible = true;
					double triangleBaseDouble = double.Parse(TriangleBaseEntry.Text);
					double triangleHeightDouble = double.Parse(TriangleHeightEntry.Text);
					AreaResultLabel.Text = $"Area = {triangleBaseDouble * triangleHeightDouble / 2} {areaUnit}\u00b2";
				}
			}
		}
		
		private void TriangleBaseEntry_OnFocused(object sender, FocusEventArgs e)
		{
			SwitchDiagramImages(AreaFirstImage, AreaSecondImage, AreaFirstImage);
			HideAreaErrorLabel();
		}
		
		private void TriangleHeightEntry_OnFocused(object sender, FocusEventArgs e)
		{
			SwitchDiagramImages(AreaFirstImage, AreaSecondImage, AreaSecondImage);
			HideAreaErrorLabel();
		}
		
		private void CalculateTrapezoidAreaButton_OnClicked(object sender, EventArgs e)
		{
			CheckUnitSelection();
			switch (AreaFirstImage.IsVisible)
			{
				case true:
				{
					AreaFirstImage.IsVisible = false;
					break;
				}
				case false:
				{
					break;
				}
				default:
				{
					AreaFirstImage.IsVisible = false;
					break;
				}
			}
			switch (AreaSecondImage.IsVisible)
			{
				case true:
				{
					AreaSecondImage.IsVisible = false;
					break;
				}
				case false:
				{
					break;
				}
				default:
				{
					AreaSecondImage.IsVisible = false;
					break;
				}
			}
			switch (AreaThirdImage.IsVisible)
			{
				case true:
				{
					AreaThirdImage.IsVisible = false;
					break;
				}
				case false:
				{
					break;
				}
				default:
				{
					AreaThirdImage.IsVisible = false;
					break;
				}
			}
			
			if (AreaUnitsChipsGroup.SelectedItem == "Yards (yd)")
			{
				TrapezoidArea("yd");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Feet (ft)")
			{
				TrapezoidArea("ft");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Inches (in)")
			{
				TrapezoidArea("in");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Kilometers (km)")
			{
				TrapezoidArea("km");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Meters (m)")
			{
				TrapezoidArea("m");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Centimeters (cm)")
			{
				TrapezoidArea("cm");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Millimeters (mm)")
			{
				TrapezoidArea("mm");
			}

			void TrapezoidArea(string areaUnit)
			{
				if (String.IsNullOrEmpty(TrapezoidFirstBaseEntry.Text) || String.IsNullOrEmpty(TrapezoidSecondBaseEntry.Text))
				{
					HideAreaImages();
					AreaErrorLabel.IsVisible = true;
				}
				else
				{
					HideAreaErrorLabel();
					AreaResultLabel.IsVisible = true;
					
					double trapezoidFirstBaseDouble = double.Parse(TrapezoidFirstBaseEntry.Text);
					double trapezoidSecondBaseDouble = double.Parse(TrapezoidSecondBaseEntry.Text);
					double trapezoidHeightDouble = double.Parse(TrapezoidHeightEntry.Text);

					double trapezoidBaseTotal = trapezoidFirstBaseDouble + trapezoidSecondBaseDouble;
					double trapezoidBaseHalf = trapezoidBaseTotal / 2;
					double trapezoidTotalArea = trapezoidBaseHalf * trapezoidHeightDouble;
					
					AreaResultLabel.Text = $"Area = {trapezoidTotalArea} {areaUnit}\u00b2";
				}
			}
		}
		
		private void TrapezoidFirstBaseEntry_OnFocused(object sender, FocusEventArgs e)
		{
			SwitchTrapezoidDiagramImages(AreaFirstImage, AreaSecondImage, AreaThirdImage, AreaFirstImage);
			HideAreaErrorLabel();
		}

		private void TrapezoidSecondBaseEntry_OnFocused(object sender, FocusEventArgs e)
		{
			SwitchTrapezoidDiagramImages(AreaFirstImage, AreaSecondImage, AreaThirdImage, AreaSecondImage);
			HideAreaErrorLabel();
		}

		private void TrapezoidHeightEntry_OnFocused(object sender, FocusEventArgs e)
		{
			SwitchTrapezoidDiagramImages(AreaFirstImage, AreaSecondImage, AreaThirdImage, AreaThirdImage);
			HideAreaErrorLabel();
		}
		
		private void CircleRadiusDiameterEntry_OnFocused(object sender, FocusEventArgs e)
		{
			HideAreaErrorLabel();
			
			// PERFORMANCE TWEAKS
			
			// Checks if AreaResultLabel is visible or not
			// and decides to hide it or do nothing accordingly
			switch (AreaResultLabel.IsVisible)
			{
				case true:
				{
					AreaResultLabel.IsVisible = false;
					break;
				}
				case false:
				{
					break;
				}
				default:
				{
					AreaResultLabel.IsVisible = false;
					break;
				}
			}

			// Checks if CircleDiagramsGrid is visible or not
			// and decides to hide it or do nothing accordingly
			switch (CircleDiagramsGrid.IsVisible)
			{
				case true:
				{
					break;
				}
				case false:
				{
					// We want the CircleDiagramsGrid to appear
					CircleDiagramsGrid.IsVisible = true;
					break;
				}
			}
		}
		
		private void CalculateCircleAreaButton_OnClicked(object sender, EventArgs e)
		{
			CheckUnitSelection();
			switch (CircleDiagramsGrid.IsVisible)
			{
				case true:
				{
					CircleDiagramsGrid.IsVisible = false;
					break;
				}
				case false:
				{
					break;
				}
				default:
				{
					CircleDiagramsGrid.IsVisible = false;
					break;
				}
			}
			
			if (AreaUnitsChipsGroup.SelectedItem == "Yards (yd)")
			{
				CircleArea("yd");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Feet (ft)")
			{
				CircleArea("ft");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Inches (in)")
			{
				CircleArea("in");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Kilometers (km)")
			{
				CircleArea("km");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Meters (m)")
			{
				CircleArea("m");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Centimeters (cm)")
			{
				CircleArea("cm");
			}
			else if (AreaUnitsChipsGroup.SelectedItem == "Millimeters (mm)")
			{
				CircleArea("mm");
			}

			void CircleArea(string areaUnit)
			{
				if (String.IsNullOrEmpty(CircleRadiusDiameterEntry.Text))
				{
					AreaResultLabel.IsVisible = false;
					AreaErrorLabel.IsVisible = true;
				}
				else
				{
					AreaResultLabel.IsVisible = true;
					HideAreaErrorLabel();
					
					double circleMeasurement = double.Parse(CircleRadiusDiameterEntry.Text);
				
					if (RadiusDiameterSegmentedControl.SelectedSegment == 0)
					{
						double radiusSquared = circleMeasurement * circleMeasurement;
						AreaResultLabel.Text = $"Area = {radiusSquared * Math.PI} {areaUnit}\u00b2";
					}
					else if (RadiusDiameterSegmentedControl.SelectedSegment == 1)
					{
						AreaResultLabel.Text = $"Area = {circleMeasurement * Math.PI} {areaUnit}\u00b2";
					}
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
				DisableDarkMode("#0173b7", "#27b1f1", "");
			}
		}
		
		/*
		 UNDERLYING PROGRAM METHODS AND FUNCTIONS
		 */

		private void HideAreaErrorLabel()
		{
			if (AreaErrorLabel.IsVisible)
			{
				AreaErrorLabel.IsVisible = false;
			}
		}
		
		private void ChangeAreaImages(Image firstImage, Image secondImage, string firstImgSource, string secondImgSource)
		{
			firstImage.Source = firstImgSource;
			secondImage.Source = secondImgSource;
		}
		
		private void ChangeTrapezoidAreaImages(Image firstImage, Image secondImage, Image thirdImage, string firstImgSource, string secondImgSource, string thirdImgSource)
		{
			firstImage.Source = firstImgSource;
			secondImage.Source = secondImgSource;
			thirdImage.Source = thirdImgSource;
		}
		
		private void SwitchDiagramImages(Image firstDiagram, Image secondDiagram, Image showingDiagram)
		{
			AreaResultLabel.IsVisible = false;
			// Allows you to change the informational
			// diagram shown to the user in any calculator page.
			firstDiagram.IsVisible = false;
			secondDiagram.IsVisible = false;

			showingDiagram.IsVisible = true;
		}
		
		private void HideAreaImages()
		{
			AreaFirstImage.IsVisible = false;
			AreaSecondImage.IsVisible = false;
			AreaThirdImage.IsVisible = false;
		}
		
		private void SwitchTrapezoidDiagramImages(Image firstDiagram, Image secondDiagram, Image thirdDiagram, Image showingDiagram)
		{
			AreaResultLabel.IsVisible = false;
			// Allows you to change the informational
			// diagram shown to the user in the trapezoid area
			// calculator page.
			firstDiagram.IsVisible = false;
			secondDiagram.IsVisible = false;
			thirdDiagram.IsVisible = false;

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
			
			AreaResultLabel.IsVisible = false;
			HideAreaErrorLabel();
			AreaFirstImage.IsVisible = false;
			AreaSecondImage.IsVisible = false;
			
			change.IsVisible = true;
		}
		
		private void ClickedOrUnclicked(ImageButton clicked)
		{
			// Resets all the background colors of
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

		private void CheckUnitSelection()
		{
			if (AreaUnitsChipsGroup.SelectedItem == null)
			{
				AreaErrorLabel.IsVisible = true;
			}
		}

		private void EnableDarkMode(string darkAccent1, string darkAccent2)
		{
			ExpandCalcMain.BackgroundColor = Color.FromHex("#262626");
			
			NavigationFlexLayout.BackgroundColor = Color.FromHex(darkAccent1);
			AreaShapePicker.BackgroundColor = Color.FromHex(darkAccent1);
			
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
			AreaShapePicker.BackgroundColor = Color.FromHex(lightAccent1);
			
			ImageButton1.BackgroundColor = Color.FromHex(lightAccent2);
			ImageButton2.BackgroundColor = Color.FromHex(lightAccent2);
			ImageButton3.BackgroundColor = Color.FromHex(lightAccent2);
			ImageButton4.BackgroundColor = Color.FromHex(lightAccent2);
		}
    }
}
