using CodeGeneratorBL;
using SaveLoadSystemBL;

namespace CodeGeneratorGUI;

public partial class MainForm : Form, IMainForm
{
    public const string GUIDATA_FILE_NAME = "settings";
    private static GUIData _guidata;
    private readonly CodeGeneratorSettings _settings;

    static MainForm()
    {
        _guidata = GUIData.GetDefault();
    }
    public MainForm()
    {
        InitializeComponent();

        CodeGenerator.MessageAgent += ShowMessage;
        CodeGeneratorSettings.MessageAgent += ShowMessage;

        _guidata = SaveLoadSystem<GUIData>.Load(GUIDATA_FILE_NAME, GUIData.GetDefault(), ShowMessage);
        _settings = _guidata.Settings;
        Settings = _settings;
        _viewport.Text = _guidata.Viewport;
        _isAddToCodeList.Checked = _guidata.IsAddToCodeList;
    }

    #region IMainForm
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
            ArgumentNullException.ThrowIfNull(value);

            _settings.SymbolWhiteList = value.SymbolWhiteList;
            _settings.ListLenght = value.ListLenght;
            _settings.CodeLenght = value.CodeLenght;

            _symbolWhiteList.Text = _settings.SymbolWhiteList;
            _listLenght.Text = _settings.ListLenght.ToString();
            _codeLenght.Text = _settings.CodeLenght.ToString();
        }
    }

    public event Action<CodeGeneratorSettings>? OnGenerate;

    public void ShowCodes<T>(T codes) where T : IEnumerable<string>
    {
        foreach (string code in codes)
            _viewport.Text += $"{code}{Environment.NewLine}";
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
        if (!_isAddToCodeList.Checked)
            ClearViewPort();
        OnGenerate?.Invoke(Settings);
    }
    private void CopyViewport_Click(object? sender, EventArgs e)
    {
        Copy(_viewport.Text);
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
        _guidata.Settings = Settings;
        _guidata.Viewport = _viewport.Text;
        _guidata.IsAddToCodeList = _isAddToCodeList.Checked;

        SaveLoadSystem<GUIData>.Save(_guidata, GUIDATA_FILE_NAME, ShowMessage);
    }
    #endregion

    private void Copy(string value)
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