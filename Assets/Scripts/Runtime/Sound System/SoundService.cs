using System;
using System.Collections.Generic;

namespace Assets.Scripts.Runtime.Sound_System
{
    [Serializable]
    public class SoundService : ISoundService
    {
        private readonly SoundPool soundPool;

        public SoundService() { }

        public SoundService(SoundPool soundPool)
        {
            this.soundPool = soundPool;
        }

        public void PlaySound(SoundItem soundItem)
        {
        }
    }
}