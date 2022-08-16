using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AmmoPool 
    {
        private readonly Stack<Rigidbody2D> _pool = new Stack<Rigidbody2D>();
        private readonly Rigidbody2D _prefab;

        public AmmoPool(Rigidbody2D prefab, int initialCount = 0)
        {
            _prefab = prefab;
            for (var i = 0; i < initialCount; i ++)
            {
                Get();
            }
        }

        public Rigidbody2D Get()
        {
            Rigidbody2D result = (_pool.Count == 0) ? Rigidbody2D.Instantiate(_prefab) : _pool.Pop();
            return result;
        }
        public void Return(Rigidbody2D gameObject)
        {
            _pool.Push(gameObject); 
        }

       
    }

}
