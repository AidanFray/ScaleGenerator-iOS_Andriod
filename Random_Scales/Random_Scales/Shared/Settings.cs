using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;

namespace App2.Shared
{
    public static class Settings
    {
        //The settings for scales
        //This is used in conjunction with scales
        public static List<bool> activeScales = new List<bool>();
        public static string[] scales = new string[]
       {"C", "C#", "Db", "D", "D#", "Eb", "E", "F", "F#", "Gb", "G", "G#", "Ab", "A", "A#", "Bb", "B"};

        public static List<bool> activeModes = new List<bool>();
        public static string[] modes = new string[]
        {"Ionian", "Dorian", "Phrygian", "Lydian", "Mixolydian", "Aeolian", "Locrian", "Whole-Tone", "Blues", "Super-Locrian (Alt)"};

        public static void SaveSwitchState(UISwitch s, string type, int keyNum)
        {
            NSUserDefaults.StandardUserDefaults.SetBool(s.On, $"{type}_{keyNum.ToString()}");
        }
        public static UISwitch LoadSwitchState(UISwitch s, string type, int keyNum)
        {
            s.SetState(NSUserDefaults.StandardUserDefaults.BoolForKey($"{type}_{keyNum.ToString()}"), false);
            return s;
        }
        
        public static void LoadSettings()
        {
            //Loads scales
            activeScales.Clear();
            for (int i = 0; i < scales.Length; i++)
            {
                activeScales.Add(NSUserDefaults.StandardUserDefaults.BoolForKey($"keys_{i.ToString()}"));
            }

            //Loads modes
            activeModes.Clear();
            for (int i = 0; i < modes.Length; i++)
            {
                activeModes.Add(NSUserDefaults.StandardUserDefaults.BoolForKey($"modes_{i.ToString()}"));
            }
        }

    }
}