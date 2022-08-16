using UnityEngine;
namespace Asteroids
{
    internal sealed class AsteroidFactory : IEnemyFactory
    {
        public Enemy Create(Health hp, Transform _playerTransform)
        {
            var enemy = Object.Instantiate(Resources.Load<Asteroid>("Asteroid"));
            enemy.gameObject.GetComponent<Rigidbody2D>().AddForce((_playerTransform.position - enemy.transform.position) * 10f);
            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}