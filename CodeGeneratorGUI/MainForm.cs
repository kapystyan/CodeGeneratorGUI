using CodeGeneratorBL;

namespace CodeGeneratorGUI;

public partial class MainForm : Form, IMainForm
{
    private MainFormDisplayData _displayData;
    private CodeGeneratorSettings _settings;

    public MainForm()
    {
        InitializeComponent();

        _displayData = MainFormDisplayData.GetDefault();
        _settings = CodeGeneratorSettings.GetDefault();
    }

    #region IMainForm
    public MainFormDisplayData DisplayData
    {
        get
        {
            _displayData.Viewport = _viewport.Text;
            _displayData.IsAddToCodeList = _isAddToCodeList.Checked;

            return _displayData;
        }
        set
        {
            _displayData = value is not null ? value : MainFormDisplayData.GetDefault();

            _viewport.Text = _displayData.Viewport;
            _isAddToCodeList.Checked = _displayData.IsAddToCodeList;
        }
    }
    public CodeGeneratorSettings Settings
    {
        get
        {
            _settings.SymbolWhiteList = _symbolWhiteList.Text;
            _settings.ListLenght = int.Parse(_listLenght.Text);
            _settings.CodeLenght = int.Parse(_codeLenght.Text);

            return _settings;
        }
        set
        {
            _settings = value is not null ? value : CodeGeneratorSettings.GetDefault();

            _symbolWhiteList.Text = _settings.SymbolWhiteList;
            _listLenght.Text = _settings.ListLenght.ToString();
            _codeLenght.Text = _settings.CodeLenght.ToString();
        }
    }

    public event Action<CodeGeneratorSettings>? OnGenerate;
    public event Action<MainFormDisplayData, CodeGeneratorSettings>? OnSaveUIData;

    public void ShowCodes(string codes)
    {
        if (!_isAddToCodeList.Checked)
            ClearViewPort();

        _viewport.Text += codes;
        _viewport.SelectionStart = _viewport.Text.Length;
        _viewport.ScrollToCaret();
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
        OnGenerate?.Invoke(Settings);
    }
    private void SaveSettings()
    {
        OnSaveUIData?.Invoke(DisplayData, Settings);
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