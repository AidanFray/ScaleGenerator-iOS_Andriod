using Android.Content;
using Scales.Core;
using Android.Preferences;

namespace Random_Scales_Andriod.Resources.settings
{
    public class Settings_Android : Settings
    {
        public static Settings_Android SettingAndroid = new Settings_Android();

        //Unique functionality for Android preference saving
        public void Assign_Pref(Context context)
        {
            _prefs = PreferenceManager.GetDefaultSharedPreferences(context);
            _editor = _prefs.Edit();
            _editor.Commit();
        }
        private static ISharedPreferences _prefs { get; set; }
        private static ISharedPreferencesEditor _editor { get; set; }
        
        //Method needed to commit the saving of preferences
        public void CommitChanges()
        {
            _editor.Commit();
        }

        //Overided saving a loading
        public override void Save(bool state, string filename)
        {
            _editor.PutBoolean(filename, state);
            CommitChanges();
        }
        public override void Save(bool state, string type, int keyNum)
        {
            _editor.PutBoolean($"{type}_{keyNum.ToString()}", state);
            CommitChanges();
        }
        public override bool Load(string filename)
        {
            return _prefs.GetBoolean(filename, false);
        }
        public override bool Load(string type, int keyNum)
        {
            return _prefs.GetBoolean($"{type}_{keyNum.ToString()}", false);
        }
    }
}