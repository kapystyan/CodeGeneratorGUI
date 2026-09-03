using CodeGeneratorBL;

namespace CodeGeneratorGUI;

public interface IMainForm
{
    CodeGeneratorSettings Settings { get; set; }

    event Action<CodeGeneratorSettings>? OnGenerate;

    void ShowCodes<T>(T codes) where T : IEnumerable<string>;
    void ShowMessage(string message);
}