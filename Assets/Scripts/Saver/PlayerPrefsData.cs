using UnityEngine;

namespace Saver
{
    internal sealed class PlayerPrefsData : IData<PlayerData>
    {
        private const string KEY_NAME = "Name";
        private const string KEY_POSITION_X = "PosX";
        private const string KEY_POSITION_Y = "PosY";
        private const string KEY_POSITION_Z = "PosZ";
        private const string KEY_IS_ENABLE = "IsEnable";
        
        public void Save(PlayerData data, string path)
        {
            PlayerPrefs.SetString(KEY_NAME, data.Name);
            PlayerPrefs.SetFloat(KEY_POSITION_X, data.Position.X);
            PlayerPrefs.SetFloat(KEY_POSITION_Y, data.Position.Y);
            PlayerPrefs.SetFloat(KEY_POSITION_Z, data.Position.Z);
            PlayerPrefs.SetString(KEY_IS_ENABLE, data.IsEnabled.ToString());
            
            PlayerPrefs.Save();
            
            // UnityEditor.EditorPrefs
        }

        public PlayerData Load(string path)
        {
            var result = new PlayerData();

            var key = KEY_NAME;
            if (PlayerPrefs.HasKey(key))
            {
                result.Name = PlayerPrefs.GetString(key);
            }

            key = KEY_POSITION_X;
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.X = PlayerPrefs.GetFloat(key);
            }

            key = KEY_POSITION_Y;
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.Y= PlayerPrefs.GetFloat(key);
            }

            key = KEY_POSITION_Z;
            if (PlayerPrefs.HasKey(key))
            {
                result.Position.Z = PlayerPrefs.GetFloat(key);
            }

            key = KEY_IS_ENABLE;
            if (PlayerPrefs.HasKey(key))
            {
                result.IsEnabled = PlayerPrefs.GetString(key).TryBool();
            }
            return result;
        }

        public void Clear()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.DeleteKey(KEY_IS_ENABLE);
        }
    }
}
