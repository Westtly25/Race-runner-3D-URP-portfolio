using System;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Runtime.Sound_System
{
    public interface ISoundService
    {
        void PlaySound(AudioClip audioClip, float volume = 1f);
    }

    [Serializable]
    public class SoundService : ISoundService
    {

        public void PlaySound(AudioClip audioClip, float volume = 1f)
        {
        }
    }
}