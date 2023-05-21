namespace Assets.Scripts.Runtime.Save_System
{
    public class PlayerSaveData
    {
        public ushort PlayerLevel { get; set; }
        public int HightScore { get; set; }
        public int Money { get; set; }
        public Car[] Car { get; set; }
    }
}