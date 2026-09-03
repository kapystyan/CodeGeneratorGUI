using CodeGeneratorBL;

namespace CodeGeneratorGUI;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        MainForm mainForm = new();
        CodeGenerator codeGenerator = new();
        GlobalPresenter globalPresenter = new(mainForm, codeGenerator);

        Application.Run(mainForm);
    }
}