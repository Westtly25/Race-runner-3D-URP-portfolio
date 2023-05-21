using Newtonsoft.Json;

namespace Assets.Scripts.Runtime.Save_System
{
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
}
