namespace Scales.Core
{
    public class Scale
    {
        public Scale(string key, string mode)
        {
            _key = key;
            _mode = mode;
        }

        private string _key;
        public string Key
        {
            get { return _key; }
        }

        private string _mode;
        public string Mode
        {
            get { return _mode; }
        }
    }
}