

using UnityEngine;

namespace Asteroids
{
    public interface IEnemyFactory
    {
        Enemy Create(Health hp, Transform _playerTransform);
    }
}
 