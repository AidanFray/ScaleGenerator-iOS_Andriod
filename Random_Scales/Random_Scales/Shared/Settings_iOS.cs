
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;
using static Scales.Core.Settings;
using Scales.Core;

namespace ScalesApp.Shared
{
    public class Settings_iOS : Settings
    {
        public static Settings_iOS SettingiOS = new Settings_iOS();

        //Overided saving and loading
        public override void Save(bool state, string type, int keyNum)
        {
            NSUserDefaults.StandardUserDefaults.SetBool(state, $"{type}_{keyNum.ToString()}");
        }
        public override void Save(bool state, string filename)
        {
            NSUserDefaults.StandardUserDefaults.SetBool(state, filename);
        }
        public override bool Load(string type, int keyNum)
        {
            return NSUserDefaults.StandardUserDefaults.BoolForKey($"{type}_{keyNum.ToString()}");
        }
        public override bool Load(string filename)
        {
            return NSUserDefaults.StandardUserDefaults.BoolForKey(filename);
        }
    }
}