using CodeGeneratorBL;
using SaveLoadSystemBL;

namespace CodeGeneratorGUI;

public partial class MainForm : Form, IMainForm
{
    public const string GUIDATA_FILE_NAME = "settings";
    private CodeGeneratorSettings _settings;

    public MainForm()
    {
        InitializeComponent();
        
        _settings = SaveLoadSystem<CodeGeneratorSettings>.Load(GUIDATA_FILE_NAME, CodeGeneratorSettings.GetDefault(), ShowMessage);
        _settings.MessageAgent += ShowMessage;
        Settings = _settings;
    }

    #region IMainForm
    public CodeGeneratorSettings Settings
    {
        get
        {
            _settings.SymbolWhiteList = _symbolWhiteList.Text;
            _settings.Prefix = _codePrefix.Text;
            _settings.ListLenght = int.Parse(_listLenght.Text);
            _settings.CodeLenght = int.Parse(_codeLenght.Text);

            return _settings;
        }
        set
        {
            ArgumentNullException.ThrowIfNull(value);

            _settings.SymbolWhiteList = value.SymbolWhiteList;
            _settings.Prefix = value.Prefix;
            _settings.ListLenght = value.ListLenght;
            _settings.CodeLenght = value.CodeLenght;

            _symbolWhiteList.Text = _settings.SymbolWhiteList;
            _codePrefix.Text = _settings.Prefix;
            _listLenght.Text = _settings.ListLenght.ToString();
            _codeLenght.Text = _settings.CodeLenght.ToString();
        }
    }

    public event Action<CodeGeneratorSettings>? OnGenerate;

    public void ShowCodes(string codes)
    {
        _viewport.Text = codes;
    }
    public void ShowMessage(string message)
    {
        _terminal.Text += $"{message}{Environment.NewLine}";
    }
    #endregion

    #region event listeners
    private void TextBox_TextChanged(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            e.Handled = true;
    }
    private void Start_BT_Click(object? sender, EventArgs e)
    {
        Generate();
    }
    private void CopyViewport_Click(object? sender, EventArgs e)
    {
        CopyViewport(_viewport.Text);
    }
    private void ClearViewport_BT_Click(object? sender, EventArgs e)
    {
        ClearViewPort();
    }
    private void ClearTerminal_BT_Click(object? sender, EventArgs e)
    {
        ClearTerminal();
    }
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        SaveSettings();
    }
    #endregion

    private void Generate()
    {
        if (!_isAddToCodeList.Checked)
            ClearViewPort();
        OnGenerate?.Invoke(Settings);
    }
    private void SaveSettings()
    {
        SaveLoadSystem<CodeGeneratorSettings>.Save(Settings, GUIDATA_FILE_NAME);
    }
    private void CopyViewport(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            ShowMessage("Нечего копировать");
            return;
        }

        Clipboard.SetText(_viewport.Text);
        ShowMessage("Скопировано");
    }
    private void ClearViewPort()
    {
        _viewport.Clear();
    }
    private void ClearTerminal()
    {
        _terminal.Clear();
    }
}