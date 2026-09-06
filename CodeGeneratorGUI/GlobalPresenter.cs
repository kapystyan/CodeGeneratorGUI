using CodeGeneratorBL;
using SaveLoadSystemBL;

namespace CodeGeneratorGUI;

public class GlobalPresenter
{
    public const string GUI_DATA_FILE_NAME = "interface";
    public const string SETTINGS_FILE_NAME = "settings";
    private readonly IMainForm _mainForm;
    private readonly CodeGenerator _codeGenerator;

    public GlobalPresenter(IMainForm mainForm, CodeGenerator codeGenerator)
    {
        _mainForm = mainForm;
        _codeGenerator = codeGenerator;

        _codeGenerator.MessageAgent += _mainForm.ShowMessage;
        _codeGenerator.Settings.MessageAgent += _mainForm.ShowMessage;

        _mainForm.DisplayData = SaveLoadSystem<MainFormDisplayData>.Load(GUI_DATA_FILE_NAME, MainFormDisplayData.GetDefault(), _mainForm.ShowMessage);
        _codeGenerator.Settings = SaveLoadSystem<CodeGeneratorSettings>.Load(SETTINGS_FILE_NAME, CodeGeneratorSettings.GetDefault(), _mainForm.ShowMessage);
        _mainForm.Settings = _codeGenerator.Settings;

        _mainForm.OnSaveUIData += MainForm_OnSaveUIData;
        _mainForm.OnGenerate += MainForm_OnGenerate;
    }

    private void MainForm_OnSaveUIData(MainFormDisplayData displayData, CodeGeneratorSettings settings)
    {
        SaveLoadSystem<MainFormDisplayData>.Save(displayData, GUI_DATA_FILE_NAME);
        SaveLoadSystem<CodeGeneratorSettings>.Save(settings, SETTINGS_FILE_NAME);
    }
    private void MainForm_OnGenerate(CodeGeneratorSettings settings)
    {
        _codeGenerator.Settings = settings;
        _mainForm.Settings = _codeGenerator.Settings;

        List<string> codes = _codeGenerator.GetCodeList();
        string result = string.Empty;
        foreach (string code in codes)
            result += $@"{settings.Prefix}{code}{Environment.NewLine}";
        _mainForm.ShowCodes(result);
    }
}