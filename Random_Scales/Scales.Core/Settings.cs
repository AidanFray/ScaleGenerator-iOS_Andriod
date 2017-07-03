using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: Add random order code here?
namespace Scales.Core
{
    public class Settings
    {
        private Random _random = new Random();

        //List of scales to be read of next
        public List<Scale> _currentScalePool = new List<Scale>();

        //Hardcoded list of keys and modes and a list for both that contains a 1:1 comparative method to see what are active
        //The boolean is loaded from file from the respective platforms Settings_[OS].cs file
        public List<bool> activeKeys = new List<bool>();
        public static string[] keys = new string[]
        {"C", "C#", "Db", "D", "D#", "Eb", "E", "F", "F#", "Gb", "G", "G#", "Ab", "A", "A#", "Bb", "B"};

        public List<bool> activeModes = new List<bool>();
        public static string[] modes = new string[]
        {"Ionian", "Dorian", "Phrygian", "Lydian", "Mixolydian", "Aeolian", "Locrian", "Whole-Tone", "Super-Locrian (Alt)"};

        private List<string> _keyPool = new List<string>();
        private List<string> _modePool = new List<string>();

        //Setup
        public void Initial_Setup()
        {
            for (int i = 0; i < keys.Length; i++)
            {
                Save(true, "keys", i);
            }
            for (int i = 0; i < modes.Length; i++)
            {
                Save(true, "modes", i);
            }
            SaveFirstSetupState(true);
        }

        //This method compares the two lists and adds the strings of the active lists
        public void ApplySettings()
        {
            _keyPool.Clear();
            for (int i = 0; i < activeKeys.Count; i++)
            {
                if (activeKeys[i])
                {
                    //Adds scales to the pool
                    _keyPool[i] = keys[i];
                }
            }

            _modePool.Clear();
            for (int i = 0; i < activeModes.Count; i++)
            {
                if (activeModes[i])
                {
                    //Adds scales to the pool
                    _modePool[i] = modes[i];
                }
            }
        }

        //Keeps track of where the program is in the randmoised list
        private int _positionInCurrentPool;
        public int get_positionInCurrentPool()
        {
            return _positionInCurrentPool;
        }
        public void increment_positionInCurrentPool()
        {
            _positionInCurrentPool++;
        }

        //Used to shuffle and check if the list needs shuffling
        public void SetupScaleShuffle()
        {
            //Reset
            _currentScalePool.Clear();

            //Position in the random list
            _positionInCurrentPool = 0;

            //This creates a comprehenisive list of all the scale combinations
            foreach (string key in _keyPool)
            {
                foreach (string mode in _modePool)
                {
                    Scale newScale = new Scale(key, mode);
                    _currentScalePool.Add(newScale);
                }
            }

            //The comprehensive list is then shuffeled
            _currentScalePool = Shuffle(_currentScalePool);
        }
        public List<Scale> Shuffle(List<Scale> listToShuffle)
        {
            //Fisher-Yates Shuffle

            //Copys list to a temp var
            List<Scale> temp = new List<Scale>(listToShuffle);

            for (int index = temp.Count - 1; index > 0; index--)
            {
                //Gets a new index
                int rndIndex = _random.Next(0, index);

                //Swap
                Scale buffer = temp[index];
                temp[index] = temp[rndIndex];
                temp[rndIndex] = buffer;
            }
            return temp;
        }
        public bool PoolEmpty()
        {
            //Checks if both lists are empty
            if (_currentScalePool.Count == 0)
            {
                return true;
            }
            else
            {
                if (_positionInCurrentPool > _currentScalePool.Count - 1)
                {
                    return true;
                }
            }

            return false;
        }

        //Reads of next key/mode from the generated list
        public string NextKey()
        {
            return _currentScalePool[_positionInCurrentPool].get_key();
        }
        public string NextMode()
        {
            return _currentScalePool[_positionInCurrentPool].get_mode();
        }

        //Method used to remove/add keys and modes to their active lists
        public void LoadSettings()
        {
            //Loads scales
            activeKeys.Clear();
            for (int i = 0; i < keys.Length; i++)
            {
                activeKeys.Add(Load("keys", i));
            }

            //Loads modes
            activeModes.Clear();
            for (int i = 0; i < modes.Length; i++)
            {
                activeModes.Add(Load("modes", i));
            }
        }
        //Resets all the settings
        public void ResetAll()
        {
            for (int i = 0; i < activeKeys.Count; i++)
            {
                activeKeys[i] = true;
            }

            for (int i = 0; i < activeModes.Count; i++)
            {
                activeModes[i] = true;
            }

            //TODO: Reload needed here?
        }

        //Used to check if an intitial setup has been completed
        public void SaveFirstSetupState(bool state)
        {
            Save(state, $"first_setup");
        }
        public bool LoadFirstSetupState()
        {
            return Load($"first_setup");
        }

        //----------------------------------------OVERRIDABLE BEHAVOIUR----------------------------------------------//
        //Loads the state of each setting
        public virtual void Save(bool state, string type, int keyNum) { }
        public virtual void Save(bool state, string filename)   { }
        public virtual bool Load(string type, int keyNum) { return false;}
        public virtual bool Load(string filename) { return false; }
        //------------------------------------------------------------------------------------------------------------//
    }
}
