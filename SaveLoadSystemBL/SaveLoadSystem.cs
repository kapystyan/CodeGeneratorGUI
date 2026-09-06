using Newtonsoft.Json;

namespace SaveLoadSystemBL
{
    public static class SaveLoadSystem<T> where T : class
    {
        public const string CONFIG_FOLDER_NAME = "config";
        public const string CONFIG_FILE_EXTENCION = ".json";

        static SaveLoadSystem()
        {
            JsonSerializerSettings = new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Error
            };
        }

        public static JsonSerializerSettings JsonSerializerSettings { get; }
        public static string RootFolder => AppDomain.CurrentDomain.BaseDirectory;
        public static string ConfigFolder => Path.GetFullPath(Path.Combine(RootFolder, CONFIG_FOLDER_NAME));

        public static void Save(T data, string fileNameWithoutExtension, Action<string>? messageAgent = null)
        {
            ArgumentNullException.ThrowIfNull(data);
            ArgumentNullException.ThrowIfNull(fileNameWithoutExtension);
            if (!IsValidFileName(fileNameWithoutExtension))
                throw new ArgumentException("Неправильное имя файла");

            if (!Directory.Exists(ConfigFolder))
            {
                Directory.CreateDirectory(ConfigFolder);
                messageAgent?.Invoke($"Директория '{ConfigFolder}' восстановлена");
            }

            string filePath = GetFilePath(fileNameWithoutExtension);
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                messageAgent?.Invoke($"Файл '{Path.GetFileName(filePath)}' создан");
            }

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, json);
            messageAgent?.Invoke($"Файл '{Path.GetFileName(filePath)}' сохранен");
        }
        public static T Load(string fileNameWithoutExtension, T defaultValue, Action<string>? messageAgent = null)
        {
            ArgumentNullException.ThrowIfNull(fileNameWithoutExtension);
            ArgumentNullException.ThrowIfNull(defaultValue);
            if (!IsValidFileName(fileNameWithoutExtension))
                throw new ArgumentException("Имя файла содержит спец. символы");

            string filePath = GetFilePath(fileNameWithoutExtension);
            if (!File.Exists(filePath))
            {
                messageAgent?.Invoke($"Файл '{Path.GetFileName(filePath)}' не найден");
                Save(defaultValue, fileNameWithoutExtension, messageAgent);
            }

            try
            {
                string json = File.ReadAllText(filePath);
                T data = JsonConvert.DeserializeObject<T>(json, JsonSerializerSettings) ?? throw new ArgumentNullException($@"Содержимое файла было '{json}'");
                messageAgent?.Invoke($"Файл '{Path.GetFileName(filePath)}' загружен");
                return data;
            }
            catch (Exception e)
            {
                Save(defaultValue, fileNameWithoutExtension);
                messageAgent?.Invoke($"Загрузка файла '{Path.GetFileName(filePath)}' прервалась с сообщением: {e.Message.Replace("\0", @"\0")}{Environment.NewLine}Восстановленно значение по умолчанию");
                return defaultValue;
            }
        }
        private static string GetFilePath(string fileNameWithoutExtension)
        {
            return Path.GetFullPath(Path.Combine(ConfigFolder, $"{fileNameWithoutExtension}{CONFIG_FILE_EXTENCION}"));
        }
        private static bool IsValidFileName(string fileNameWithoutExtension)
        {
            return fileNameWithoutExtension is not null && fileNameWithoutExtension.IndexOfAny(Path.GetInvalidFileNameChars()) == -1;
        }
    }
}