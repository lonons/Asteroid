using UnityEngine;
namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private Transform _playerTransform;
        private void Start()
        {
            _playerTransform = GameObject.Find("Player").transform;
            Enemy.CreateAsteroidEnemy(new Health(100.0f, 100.0f), _playerTransform);
            IEnemyFactory factory = new AsteroidFactory();
            factory.Create(new Health(100.0f, 100.0f), _playerTransform);
            Enemy.Factory = factory;
            Enemy.Factory.Create(new Health(100.0f, 100.0f), _playerTransform);
        }
    }
}
