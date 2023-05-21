using System.IO;
using UnityEngine;

namespace Assets.Scripts.Runtime.Save_System
{
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
