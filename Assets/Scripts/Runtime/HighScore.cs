using System;
using UnityEngine;

namespace Assets.Scripts.Runtime
{
    [Serializable]
    public class HighScore
    {
        [SerializeField]
        private int value;

        public int Value => value;

        public HighScore()
        {
        }

        public void UpdateValue(int value)
        {
            this.value = value;
        }
    }
}
