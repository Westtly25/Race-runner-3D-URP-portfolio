using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Security.Cryptography;
using Zenject;

namespace Assets.Scripts.Runtime.Save_System
{
    public class PlayerSaveData
    {
        public int HightScore { get; set; }
        public int Money { get; set; }
        public Car[] Car { get; set; }
    }


    public class SaveService : IInitializable
    {
        private readonly FileProvider fileProvider;
        private readonly IFileSaver jSonSaver;

        public SaveService()
        {
            this.fileProvider = new FileProvider();
            this.jSonSaver = new JSonToFileSaver();
        }

        public void Initialize()
        {
            
        }

        public void SaveData()
        {

        }

        public void LoadData()
        {

        }
    }

    public interface IFileSaver
    {
        bool TrySave(PlayerSaveData saveData);
        PlayerSaveData Load(string fileData);
    }

    public class JSonToFileSaver : IFileSaver
    {
        private const string fileName = "PlayerData";
        private readonly string path;

        public JSonToFileSaver()
        {
            path = Application.persistentDataPath + "/Saves/" + fileName + ".json";
        }

        public bool TrySave(PlayerSaveData saveData)
        {
            var s = JsonConvert.SerializeObject(saveData);

            return false;
        }

        public PlayerSaveData Load(string fileData)
        {
            var loadedData = JsonConvert.DeserializeObject<PlayerSaveData>(fileData);

            return loadedData;
        }
    }

    public class FileProvider
    {
        public string ReadFile(string path)
        {
            using (var fileStream = new StreamReader(path))
            {
                return fileStream.ReadToEnd();
            }
        }

        public void WriteFile(string path, string fileToSave)
        {
            using (var fileStream = new StreamWriter(path))
            {
                fileStream.Write(fileToSave);
            }
        }
    }
}
