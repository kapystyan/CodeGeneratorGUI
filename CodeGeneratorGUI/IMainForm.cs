using CodeGeneratorBL;

namespace CodeGeneratorGUI;

public interface IMainForm
{
    CodeGeneratorSettings Settings { get; set; }

    event Action<CodeGeneratorSettings>? OnGenerate;

    void ShowCodes(string codes);
    void ShowMessage(string message);
}