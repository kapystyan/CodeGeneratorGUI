namespace CodeGeneratorBL;

public class CodeGeneratorSettings
{
    #region consts
    public const string Symbol_WHITE_LIST_DEFAULT = "";

    public const int CODE_LENGHT_MIN = 4;
    public const int CODE_LENGHT_MAX = 64;
    public const int CODE_LENGHT_DEFAULT = 8;

    public const int LIST_LENGHT_MIN = 1;
    public const int LIST_LENGHT_MAX = 1024;
    public const int LIST_LENGHT_DEFAULT = 1;

    public const string PREFIX_DEFAULT = "";
    #endregion

    private static readonly CodeGeneratorSettings _default;

    private string _symbolWhiteList;
    private string _prefix;
    private int _codeLenght;
    private int _listLenght;

    static CodeGeneratorSettings()
    {
        _default = new(Symbol_WHITE_LIST_DEFAULT, PREFIX_DEFAULT, CODE_LENGHT_DEFAULT, LIST_LENGHT_DEFAULT);
    }

    public CodeGeneratorSettings(string symbolWhiteList, string prefix, int codeLenght, int listLenght)
    {
        _symbolWhiteList = symbolWhiteList;
        _prefix = prefix;
        _codeLenght = codeLenght;
        _listLenght = listLenght;
    }

    public string SymbolWhiteList
    {
        get => _symbolWhiteList;
        set => _symbolWhiteList = value is not null ? value : Symbol_WHITE_LIST_DEFAULT;
    }
    public string Prefix
    {
        get => _prefix;
        set => _prefix = value is not null ? value : PREFIX_DEFAULT;
    }
    public int CodeLenght
    {
        get => _codeLenght;
        set
        {
            if (value >= CODE_LENGHT_MIN && value <= CODE_LENGHT_MAX)
                _codeLenght = value;
            else
            {
                MessageAgent?.Invoke($"Присваемое значение '{value}' для длинны кода вне диапазона {CODE_LENGHT_MIN}-{CODE_LENGHT_MAX}, присвоено значение по умолчанию '{CODE_LENGHT_DEFAULT}'");
                _codeLenght = CODE_LENGHT_DEFAULT;
            }
        }
    }
    public int ListLenght
    {
        get => _listLenght;
        set
        {
            if (value >= LIST_LENGHT_MIN && value <= LIST_LENGHT_MAX)
                _listLenght = value;
            else
            {
                MessageAgent?.Invoke($"Присваемое значение '{value}' для количества кодов вне диапазона {LIST_LENGHT_MIN}-{LIST_LENGHT_MAX}, присвоено значение по умолчанию '{LIST_LENGHT_DEFAULT}'");
                _listLenght = LIST_LENGHT_DEFAULT;
            }
        }
    }

    public event Action<string>? MessageAgent;

    public static CodeGeneratorSettings GetDefault()
    {
        return _default;
    }
}