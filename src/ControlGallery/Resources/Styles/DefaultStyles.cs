using Microsoft.Maui.Controls;

namespace CSharpinator.Resources.Styles;

public static class DefaultStyles
{
	static Style<Border> borders;
	static Style<BoxView> boxViews;
    static Style<ActivityIndicator> activityIndicators;
	static Style<Button> buttons;
    static Style<Label> labels;

	static Style<CheckBox> checkBoxes;

    public static ResourceDictionary Implicit => new ResourceDictionary { 
		ActivityIndicators, Borders, BoxViews, Buttons, Labels };

	public static Style<ActivityIndicator> ActivityIndicators => activityIndicators ?? (activityIndicators = new Style<ActivityIndicator>(
        
    )
		.AddAppThemeBinding(ActivityIndicator.ColorProperty, AppColors.Primary, AppColors.White)
	);

	public static Style<Border> Borders => borders ?? (borders = new Style<Border>(
        (Border.StrokeShapeProperty, "Rectangle"),
		(Border.StrokeThicknessProperty, 1)
    )
		.AddAppThemeBinding(Border.StrokeProperty, AppColors.Gray200, AppColors.Gray500)
	);
	
	public static Style<BoxView> BoxViews => boxViews ?? (boxViews = new Style<BoxView>(
        (BoxView.ColorProperty, AppColors.Gray500)
    ));

    public static Style<Button> Buttons => buttons ?? (buttons = new Style<Button>(
        (Button.HeightRequestProperty, 44),
        (Button.FontSizeProperty, 13),
		(Button.HorizontalOptionsProperty, LayoutOptions.Center),
        (Button.VerticalOptionsProperty, LayoutOptions.Center),
		(VisualStateManager.VisualStateGroupsProperty, new VisualStateGroupList {
			new VisualStateGroup{
				Name = "CommonStates",
				States = {
					new VisualState {
						Name = "Disabled",
						Setters = {
							new Setter{
								Property = Button.TextColorProperty,
								Value = AppColors.Gray950
							},
							new Setter{
								Property = Button.BackgroundProperty,
								Value = AppColors.Gray200
							}
						}
					}
				}
			}
		})
    )
		.AddAppThemeBinding(Button.TextColorProperty, AppColors.White, AppColors.Primary)
        .AddAppThemeBinding(Button.BackgroundProperty, AppColors.Primary, AppColors.White)
	);

	public static Style<CheckBox> CheckBoxes => checkBoxes ?? (checkBoxes = new Style<CheckBox>(
        (CheckBox.MinimumHeightRequestProperty, 44),
		(CheckBox.MinimumWidthRequestProperty, 44),
		(VisualStateManager.VisualStateGroupsProperty, new VisualStateGroupList {
			new VisualStateGroup{
				Name = "CommonStates",
				States = {
					new VisualState {
						Name = "Disabled",
						Setters = {
							new Setter{
								Property = CheckBox.ColorProperty,
								Value = AppColors.Gray200
							}
						}
					}
				}
			}
		})
    )
		.AddAppThemeBinding(CheckBox.ColorProperty, AppColors.Primary, AppColors.White)
	);

    public static Style<Label> Labels => labels ?? (labels = new Style<Label>(
        (Label.FontSizeProperty, 14),
		(Label.FontFamilyProperty, "OpenSansRegular"),
		(Label.BackgroundProperty, Colors.Transparent)
    )
		.AddAppThemeBinding(Label.TextColorProperty, AppColors.Black, AppColors.White)
	);

	public static Style<Button> OutlineButton => new Style<Button>(
        (Button.HeightRequestProperty, 44),
		(Button.MinimumWidthRequestProperty, 240),
        (Button.FontSizeProperty, 13),
		(Button.HorizontalOptionsProperty, LayoutOptions.Center),
        (Button.VerticalOptionsProperty, LayoutOptions.Center),
		(Button.BackgroundProperty, Colors.Transparent),
		(Button.BorderWidthProperty, 1),
		(Button.CornerRadiusProperty, 8),
		(VisualStateManager.VisualStateGroupsProperty, new VisualStateGroupList {
			new VisualStateGroup{
				Name = "CommonStates",
				States = {
					new VisualState {
						Name = "Disabled",
						Setters = {
							new Setter{
								Property = Button.TextColorProperty,
								Value = AppColors.Gray950
							},
							new Setter{
								Property = Button.BackgroundProperty,
								Value = AppColors.Gray200
							}
						}
					}
				}
			}
		})
    )
		.AddAppThemeBinding(Button.BorderColorProperty, AppColors.Primary, AppColors.White)
		.AddAppThemeBinding(Button.TextColorProperty, AppColors.Primary, AppColors.White)
	;
}

