using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Asteroid : Enemy
    {
        private float damage = 10f;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageble damageble))
            {
                damageble.OnDamage(damage);
                Destroy(gameObject);
            }
        }
    }

}

