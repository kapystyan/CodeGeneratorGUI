using CodeGeneratorBL;

namespace CodeGeneratorGUI;

public interface IMainForm
{
    MainFormDisplayData DisplayData { get; set; }
    CodeGeneratorSettings Settings { get; set; }

    event Action<CodeGeneratorSettings>? OnGenerate;
    event Action<MainFormDisplayData, CodeGeneratorSettings> OnSaveUIData;

    void ShowCodes(string codes);
    void ShowMessage(string message);
}