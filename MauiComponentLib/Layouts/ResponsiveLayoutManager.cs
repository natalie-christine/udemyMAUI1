using Microsoft.Maui.Layouts;

namespace MauiComponentLib.Layouts;

public class ResponsiveLayoutManager : LayoutManager
{
    private readonly Microsoft.Maui.ILayout _layout;

    public int HorizontalThreshold;
    public int HorizontalModeHeight;
    public int VerticalModeHeight;
    public int HorizontalSpacing;
    public int VerticalSpacing;

    public ResponsiveLayoutManager(Microsoft.Maui.ILayout layout) : base(layout)
    {
        _layout = layout;
    }

    public override Size Measure(double widthConstraint, double heightConstraint)
    {
        if (widthConstraint < HorizontalThreshold) // vertical mode
        {
            var totalSpacing = VerticalSpacing * (_layout.Count - 1);
            foreach (IView child in _layout)
            {
                child.Measure(widthConstraint, VerticalModeHeight);
            }
            return new Size(widthConstraint, VerticalModeHeight * _layout.Count + totalSpacing);
        }
        else // horizontal mode
        {
            var totalSpacing = HorizontalSpacing * (_layout.Count - 1);
            foreach (IView child in _layout)
            {
                child.Measure((widthConstraint - totalSpacing) / _layout.Count, HorizontalModeHeight);
            }
            return new Size(widthConstraint, HorizontalModeHeight);
        }
    }

    public override Size ArrangeChildren(Rect bounds)
    {
        if (bounds.Width < HorizontalThreshold) // vertical mode
        {
            var totalSpacing = VerticalSpacing * (_layout.Count - 1);
            var ew = bounds.Width;
            var i = 0;

            foreach (IView child in _layout)
            {
                child.Arrange(new Rect(0, (VerticalModeHeight + VerticalSpacing) * i, ew, VerticalModeHeight));
                ++i;
            }

            return new Size(bounds.Width, (VerticalModeHeight + VerticalSpacing) * _layout.Count);
        }
        else // horizontal mode
        {
            var totalSpacing = HorizontalSpacing * (_layout.Count - 1);
            var ew = (bounds.Width - totalSpacing) / _layout.Count;
            var i = 0;
        
            foreach (IView child in _layout)
            {
                child.Arrange(new Rect((ew + HorizontalSpacing) * i, 0, ew, HorizontalModeHeight));
                ++i;
            }

            return new Size(bounds.Width, HorizontalModeHeight);
        }
    }

}
