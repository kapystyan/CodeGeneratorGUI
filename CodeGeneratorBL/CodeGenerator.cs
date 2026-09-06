namespace CodeGeneratorBL;

public class CodeGenerator
{
    public const int MAX_ITERATION_IF_CODE_REPEAT = 10;
    private static readonly Random _random;
    private readonly CodeGeneratorSettings _settings;

    static CodeGenerator()
    {
        _random = new();
    }
    public CodeGenerator(Action<string>? messageAgent = null)
    {
        _settings = CodeGeneratorSettings.GetDefault();
        MessageAgent = messageAgent;
    }

    public CodeGeneratorSettings Settings
    {
        get => _settings;
        set
        {
            ArgumentNullException.ThrowIfNull(value);

            _settings.SymbolWhiteList = value.SymbolWhiteList;
            _settings.Prefix = value.Prefix;
            _settings.ListLenght = value.ListLenght;
            _settings.CodeLenght = value.CodeLenght;
        }
    }

    public event Action<string>? MessageAgent;

    /// <summary>
    /// Генерирует список кодов используя GetCode(). Гарантирует что все коды уникальные: при повторении кода замещает его другим до количества, указанном в MAX_ITERATION_IF_CODE_REPEAT
    /// </summary>
    /// <returns>Список уникальных кодов, если список символов для генерации пуст, возвращает пустой список</returns>
    public List<string> GetCodeList()
    {
        List<string> codes = [];
        string code;
        int repeatCount = 0;

        if (GetCode() == string.Empty)
            return [];

        for (int i = 0; i < Settings.ListLenght; i++)
        {
            code = GetCode();

            if (codes.Contains(code))
            {
                repeatCount++;
                if (repeatCount == MAX_ITERATION_IF_CODE_REPEAT)
                {
                    MessageAgent?.Invoke($@"Достигнуто максимальное количество попыток перегенерации уникального кода '{MAX_ITERATION_IF_CODE_REPEAT}', количество символов '{Settings.SymbolWhiteList.Length}' слишком мало для такого количества списка '{Settings.ListLenght}'");
                    break;
                }
                i--;
                continue;
            }
            repeatCount = 0;

            codes.Add(code);
        }

        MessageAgent?.Invoke($@"Сгенерированно '{codes.Count}' кодов");

        return codes;
    }
    /// <summary>
    /// Генерирует код из символов указанных в Settings
    /// </summary>
    /// <returns>string.Empty если список символов пуст, иначе код</returns>
    public string GetCode()
    {
        if (Settings.SymbolWhiteList.Length == 0)
        {
            MessageAgent?.Invoke("Белый список символов был пуст");
            return string.Empty;
        }

        string code = string.Empty;
        for (int i = 0; i < Settings.CodeLenght; i++)
            code += Settings.SymbolWhiteList[_random.Next(Settings.SymbolWhiteList.Length)];
        return code;
    }
}