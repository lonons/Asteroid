using UnityEngine;
namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour
    {
        public static IEnemyFactory Factory;
        public Health Health { get; protected set; }
        public static Asteroid CreateAsteroidEnemy(Health hp, Transform player)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Asteroid"));
            enemy.Health = hp;
            enemy.gameObject.GetComponent<Rigidbody2D>().AddForce(( player.position - enemy.transform.position) * 10f);
            return enemy;
        }
        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }
    }
}
