namespace Assets.Scripts.Runtime.Save_System
{
    public interface IFileSaver
    {
        bool TrySave(PlayerSaveData saveData);
        PlayerSaveData Load();
    }
}
