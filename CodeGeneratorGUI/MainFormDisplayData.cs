namespace CodeGeneratorGUI
{
    public class MainFormDisplayData
    {
        private readonly static MainFormDisplayData _default;
        private string _viewport;
        private bool _isAddToCodeList;

        static MainFormDisplayData()
        {
            _default = new(string.Empty, false);
        }
        public MainFormDisplayData(string viewport, bool isAddToCodeList)
        {
            _viewport = viewport;
            _isAddToCodeList = isAddToCodeList;
        }

        public string Viewport
        {
            get => _viewport;
            set => _viewport = value is not null ? value : string.Empty;
        }
        public bool IsAddToCodeList
        {
            get => _isAddToCodeList;
            set => _isAddToCodeList = value;
        }

        public static MainFormDisplayData GetDefault()
        {
            return _default;
        }
    }
}