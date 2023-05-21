using UnityEngine;

namespace Assets.Scripts.Runtime.Sound_System
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundPoolObject : MonoBehaviour
    {
        private AudioSource audioSource;

        public void Initialize()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void SetSound(SoundItem soundItem)
        {
            audioSource.clip = soundItem.audioClip;
            audioSource.volume = soundItem.volume;
            audioSource.loop = soundItem.isLooped;
        }
    }
}