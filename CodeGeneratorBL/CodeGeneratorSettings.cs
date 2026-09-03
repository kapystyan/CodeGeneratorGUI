namespace CodeGeneratorBL;

public sealed class CodeGeneratorSettings
{
    #region consts
    public const string Symbol_WHITE_LIST_DEFAULT = "";

    public const int CODE_LENGHT_MIN = 4;
    public const int CODE_LENGHT_MAX = 64;
    public const int CODE_LENGHT_DEFAULT = 8;

    public const int LIST_LENGHT_MIN = 1;
    public const int LIST_LENGHT_MAX = 1024;
    public const int LIST_LENGHT_DEFAULT = 1;
    #endregion

    private static readonly CodeGeneratorSettings _default;

    private int _codeLenght;
    private int _listLenght;

    static CodeGeneratorSettings()
    {
        _default = new()
        {
            SymbolWhiteList = Symbol_WHITE_LIST_DEFAULT,
            CodeLenght = CODE_LENGHT_DEFAULT,
            ListLenght = LIST_LENGHT_DEFAULT
        };
    }

    public required string SymbolWhiteList { get; set; }
    public required int CodeLenght
    {
        get => _codeLenght;
        set
        {
            if (value >= CODE_LENGHT_MIN && value <= CODE_LENGHT_MAX)
                _codeLenght = value;
            else
            {
                MessageAgent?.Invoke($@"Присваемое значение '{value}' для длинны кода вне диапазона {CODE_LENGHT_MIN}-{CODE_LENGHT_MAX}, присвоено значение по умолчанию '{CODE_LENGHT_DEFAULT}'");
                _codeLenght = CODE_LENGHT_DEFAULT;
            }
        }
    }
    public required int ListLenght
    {
        get => _listLenght;
        set
        {
            if (value >= LIST_LENGHT_MIN && value <= LIST_LENGHT_MAX)
                _listLenght = value;
            else
            {
                MessageAgent?.Invoke($@"Присваемое значение '{value}' для количества кодов вне диапазона {LIST_LENGHT_MIN}-{LIST_LENGHT_MAX}, присвоено значение по умолчанию '{LIST_LENGHT_DEFAULT}'");
                _listLenght = LIST_LENGHT_DEFAULT;
            }
        }
    }

    public static event Action<string>? MessageAgent;

    public static CodeGeneratorSettings GetDefault()
    {
        return _default;
    }
}