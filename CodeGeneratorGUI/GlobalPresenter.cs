using CodeGeneratorBL;

namespace CodeGeneratorGUI;

public class GlobalPresenter
{
    private readonly IMainForm _mainForm;
    private readonly CodeGenerator _codeGenerator;

    public GlobalPresenter(IMainForm mainForm, CodeGenerator codeGenerator)
    {
        _mainForm = mainForm;
        _codeGenerator = codeGenerator;

        _mainForm.OnGenerate += MainForm_OnGenerate;
    }

    private void MainForm_OnGenerate(CodeGeneratorSettings settings)
    {
        _codeGenerator.Settings = settings;
        _mainForm.ShowCodes(_codeGenerator.GetCodeList());
        _mainForm.Settings = settings;
    }
}