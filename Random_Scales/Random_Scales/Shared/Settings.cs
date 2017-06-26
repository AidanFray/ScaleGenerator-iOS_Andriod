using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreGraphics;

namespace ScalesApp.Shared
{
    public static class Settings
    {
        public static List<bool> activeKeys = new List<bool>();
        public static string[] keys = new string[]
        {"C", "C#", "Db", "D", "D#", "Eb", "E", "F", "F#", "Gb", "G", "G#", "Ab", "A", "A#", "Bb", "B"};

        public static List<bool> activeModes = new List<bool>();
        public static string[] modes = new string[]
        {"Ionian", "Dorian", "Phrygian", "Lydian", "Mixolydian", "Aeolian", "Locrian", "Whole-Tone", "Blues", "Super-Locrian (Alt)"};

        public static void SaveSwitchState(UISwitch s, string type, int keyNum)
        {
            NSUserDefaults.StandardUserDefaults.SetBool(s.On, $"{type}_{keyNum.ToString()}");
        }
        public static void SaveSwitchState(bool state, string type, int keyNum)
        {
            NSUserDefaults.StandardUserDefaults.SetBool(state, $"{type}_{keyNum.ToString()}");
        }
        public static UISwitch LoadSwitchState(UISwitch s, string type, int keyNum)
        {
            s.SetState(NSUserDefaults.StandardUserDefaults.BoolForKey($"{type}_{keyNum.ToString()}"), false);
            return s;
        }

        public static void LoadSettings()
        {
            //Loads scales
            activeKeys.Clear();
            for (int i = 0; i < keys.Length; i++)
            {
                activeKeys.Add(NSUserDefaults.StandardUserDefaults.BoolForKey($"keys_{i.ToString()}"));
            }

            //Loads modes
            activeModes.Clear();
            for (int i = 0; i < modes.Length; i++)
            {
                activeModes.Add(NSUserDefaults.StandardUserDefaults.BoolForKey($"modes_{i.ToString()}"));
            }
        }

        public static void ResetAll()
        {
            //Used to distinguish between which setting page is viewable
            if (KeyTabPage.Page != null)
            {
                //Resets all mode and keys into selected
                foreach (UISwitch _switch in KeyTabPage.Page.PageSwitches)
                {
                    _switch.SetState(true, true);
                }
            }

            if (ModesTabPage.Page != null)
            {
                foreach (UISwitch _switch in ModesTabPage.Page.PageSwitches)
                {
                    _switch.SetState(true, true);
                }
            }


        }
    }
}