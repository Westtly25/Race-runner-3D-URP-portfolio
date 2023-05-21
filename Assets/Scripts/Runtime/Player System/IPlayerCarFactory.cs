using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Player_System
{
    public interface IPlayerCarFactory
    {
        Task<Car> Create();
        Task<Car> Create(Vector3 at, Transform parent);
    }
}