using System.Data;
using System.IO;
using UnityEngine;

namespace Saver
{
    internal sealed class PlayerDataRepository
    {
        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;
        private readonly IData<PlayerData> _data;

        public PlayerDataRepository()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                _data = new JsonData<PlayerData>();
            }
            else
            {
                _data = new JsonData<PlayerData>();
            }
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save(PlayerController player, string sceneName = null)
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
            var savePlayer = new PlayerData
            {
                Name = player.name,
                Position = (Vector3Serializable)player.transform.position,
                IsEnabled = player.gameObject.activeSelf
            };
            _data.Save(savePlayer, Path.Combine(_path, $"{sceneName}_{_fileName}"));
            Debug.Log("<color=green>Save</color>");
        }

        public void Load(PlayerController player)
        {
            string file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                throw new DataException($"File {file} not found");
            }
            var newPlayer = _data.Load(file);
            player.transform.position = newPlayer.Position;
            player.name = newPlayer.Name;
            player.gameObject.SetActive(newPlayer.IsEnabled);

            Debug.Log(newPlayer);
        }
    }
}
