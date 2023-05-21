using Zenject;
using Logger = UniRx.Diagnostics.Logger;

namespace Assets.Scripts.Runtime.Save_System
{
    public class SaveService
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
}