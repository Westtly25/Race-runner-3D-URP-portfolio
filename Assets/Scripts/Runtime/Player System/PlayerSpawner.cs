using Zenject;
using UnityEngine;

namespace Assets.Scripts.Runtime.Player_System
{

    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField]
        private Player player;

        [Header("INJECTED DATA")]
        private PlayerCarFactory playerCarFactory;

        [Inject]
        public PlayerSpawner(PlayerCarFactory playerCarFactory)
        {
            this.playerCarFactory = playerCarFactory;
        }

        [Inject]
        public void Constructor(PlayerCarFactory playerCarFactory)
        {
            this.playerCarFactory = playerCarFactory;
        }

        public void Spawn()
        {
            playerCarFactory.Create();
        }
    }
}