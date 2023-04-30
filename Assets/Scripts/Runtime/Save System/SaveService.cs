using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Assets.Scripts.Runtime.Save_System
{
    public class PlayerSaveData
    {
        public int HightScore { get; set; }
        public Car[] Car { get; set; }
    }


    public class SaveService
    {
        private readonly FileProvider fileProvider;
        private readonly JSonSaver jSonSaver;

        public SaveService()
        {
            this.fileProvider = new FileProvider();
            this.jSonSaver = new JSonSaver();
        }
    }

    public interface ISaver
    {
        bool TrySave(PlayerSaveData saveData);
        PlayerSaveData Load(string fileData);
    }

    public class JSonSaver : ISaver
    {
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
        public void ReadFile(string path)
        {

        }

        public void WriteFile(string path)
        {

        }
    }
}
