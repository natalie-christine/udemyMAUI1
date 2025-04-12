namespace MauiComponentLib.Layouts;

using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;

public class ResponsiveLayout : Layout
{
    public static readonly BindableProperty HorizontalThresholdProperty =
        BindableProperty.Create(nameof(HorizontalThreshold), typeof(int), typeof(ResponsiveLayoutManager), 800);
    public static readonly BindableProperty HorizontalModeHeightProperty =
            BindableProperty.Create(nameof(HorizontalModeHeight), typeof(int), typeof(ResponsiveLayoutManager), 300);
    public static readonly BindableProperty VerticalModeHeightProperty =
            BindableProperty.Create(nameof(VerticalModeHeight), typeof(int), typeof(ResponsiveLayoutManager), 300);
    public static readonly BindableProperty HorizontalSpacingProperty =
            BindableProperty.Create(nameof(HorizontalSpacing), typeof(int), typeof(ResponsiveLayoutManager), 10);
    public static readonly BindableProperty VerticalSpacingProperty =
            BindableProperty.Create(nameof(VerticalSpacing), typeof(int), typeof(ResponsiveLayoutManager), 20);

    public int HorizontalThreshold
    {
        get { return (int)GetValue(HorizontalThresholdProperty); }
        set { SetValue(HorizontalThresholdProperty, value); }
    }

    public int HorizontalModeHeight
    {
        get { return (int)GetValue(HorizontalModeHeightProperty); }
        set { SetValue(HorizontalModeHeightProperty, value); }
    }

    public int VerticalModeHeight
    {
        get { return (int)GetValue(VerticalModeHeightProperty); }
        set { SetValue(VerticalModeHeightProperty, value); }
    }

    public int HorizontalSpacing
    {
        get { return (int)GetValue(HorizontalSpacingProperty); }
        set { SetValue(HorizontalSpacingProperty, value); }
    }

    public int VerticalSpacing
    {
        get { return (int)GetValue(VerticalSpacingProperty); }
        set { SetValue(VerticalSpacingProperty, value); }
    }

    protected override ILayoutManager CreateLayoutManager()
    {
        return new ResponsiveLayoutManager(this)
        {
            HorizontalThreshold = HorizontalThreshold,
            HorizontalModeHeight = HorizontalModeHeight,
            VerticalModeHeight = VerticalModeHeight,
            HorizontalSpacing = HorizontalSpacing,
            VerticalSpacing = VerticalSpacing
        };
    }
}
