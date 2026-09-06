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

        _codeGenerator.MessageAgent += _mainForm.ShowMessage;

        _mainForm.OnGenerate += MainForm_OnGenerate;
    }

    private void MainForm_OnGenerate(CodeGeneratorSettings settings)
    {
        _codeGenerator.Settings = settings;

        List<string> codes = _codeGenerator.GetCodeList();
        if (codes.Count == 1)
        {
            _mainForm.ShowCodes(codes[0]);
            return;
        }

        string result = string.Empty;
        foreach (string code in codes)
            result += $@"{settings.Prefix}{code}{Environment.NewLine}";
        _mainForm.ShowCodes(result);
    }
}