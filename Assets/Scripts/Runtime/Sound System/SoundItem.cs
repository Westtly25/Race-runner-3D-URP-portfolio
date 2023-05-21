using System;
using UnityEngine;

namespace Assets.Scripts.Runtime.Sound_System
{
    [Serializable]
    public class SoundItem
    {
        public AudioClip audioClip { get; set; }
        public float volume { get; set; }
        public bool isLooped { get; set; }
}
}