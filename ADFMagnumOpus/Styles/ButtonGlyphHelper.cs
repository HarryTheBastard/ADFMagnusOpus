using System.Windows;
using System.Windows.Controls;

namespace ADFMagnumOpus.Styles;

public enum ButtonGlyph { None, Close, Minimize, Maximize, ToggleFrontBehind }

public static class ButtonGlyphHelperOld
{
    public static ButtonGlyph GetGlyph(Button obj) => (ButtonGlyph)obj.GetValue(GlyphProperty);

    public static void SetGlyph(Button obj, ButtonGlyph value) => obj.SetValue(GlyphProperty, value);

    public static readonly DependencyProperty GlyphProperty =
        DependencyProperty.RegisterAttached(
            "Glyph",
            typeof(ButtonGlyph),
            typeof(ButtonGlyphHelperOld),
            new FrameworkPropertyMetadata(ButtonGlyph.None, FrameworkPropertyMetadataOptions.Inherits));
}

public static class ButtonGlyphHelper
{
    public static ButtonGlyph GetGlyph(DependencyObject obj) => (ButtonGlyph)obj.GetValue(GlyphProperty);

    public static void SetGlyph(DependencyObject obj, ButtonGlyph value) => obj.SetValue(GlyphProperty, value);

    public static readonly DependencyProperty GlyphProperty =
        DependencyProperty.RegisterAttached(
            "Glyph",
            typeof(ButtonGlyph),
            typeof(ButtonGlyphHelper),
            new FrameworkPropertyMetadata(ButtonGlyph.None, FrameworkPropertyMetadataOptions.Inherits));
}
