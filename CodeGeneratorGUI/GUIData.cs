using CodeGeneratorBL;

namespace CodeGeneratorGUI;

public class GUIData
{
    private static readonly GUIData _default;

    static GUIData()
    {
        _default = new()
        {
            Settings = CodeGeneratorSettings.GetDefault(),
            Viewport = string.Empty,
            IsAddToCodeList = false
        };
    }

    public required CodeGeneratorSettings Settings { get; set; }
    public required string Viewport { get; set; }
    public required bool IsAddToCodeList { get; set; }

    public static GUIData GetDefault()
    {
        return _default;
    }
}