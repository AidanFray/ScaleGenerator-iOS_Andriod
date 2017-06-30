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
        private string _mode;

        public string get_key()
        {
            return _key;
        }
        public string get_mode()
        {
            return _mode;
        }
    }
}