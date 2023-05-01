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
using UniRx.Diagnostics;
using Logger = UniRx.Diagnostics.Logger;

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
        private readonly Logger logger;
        private readonly IFileSaver jSonSaver;

        private PlayerSaveData playerSaveData;

        public PlayerSaveData PlayerSaveData => playerSaveData;

        [Inject]
        public SaveService(Logger loger)
        {
            this.fileProvider = new FileProvider();
            this.jSonSaver = new JSonToFileSaver(fileProvider);
        }

        public void Initialize()
        {
            
        }

        public void SaveData()
        {
            if (jSonSaver.TrySave(playerSaveData))
            {
                logger.Log("Data saved successfully");
            }
            else logger.Error("Data not saved");
        }

        public void LoadData()
        {
            playerSaveData = jSonSaver.Load();
        }
    }

    public interface IFileSaver
    {
        bool TrySave(PlayerSaveData saveData);
        PlayerSaveData Load();
    }

    public class JSonToFileSaver : IFileSaver
    {
        private const string fileName = "PlayerData.json";
        private readonly FileProvider fileProvider;

        public JSonToFileSaver(FileProvider fileProvider)
        {
            this.fileProvider = fileProvider;
        }

        public bool TrySave(PlayerSaveData saveData)
        {
            string sorializedData = JsonConvert.SerializeObject(saveData);

            fileProvider.WriteFile(fileName, sorializedData);

            return true;
        }

        public PlayerSaveData Load()
        {
            string file = fileProvider.ReadFile(fileName);

            return JsonConvert.DeserializeObject<PlayerSaveData>(file);
        }
    }

    public class FileProvider
    {
        private readonly string path;

        public FileProvider()
        {
            this.path = Application.persistentDataPath + "/Saves/";
        }

        public string ReadFile(string fileName)
        {
            using (var fileStream = new StreamReader(path))
            {
                return fileStream.ReadToEnd();
            }
        }

        public void WriteFile(string fileName, string fileToSave)
        {
            using (var fileStream = new StreamWriter(path))
            {
                fileStream.Write(fileToSave);
            }
        }
    }
}
