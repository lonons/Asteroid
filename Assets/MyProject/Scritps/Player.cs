using System.Collections;
using UnityEngine;
namespace Asteroids
{
    internal sealed class Player : MonoBehaviour, IDamageble
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        private Camera _camera;
        private Ship _ship;
        [SerializeField]

        private Health _health = new Health(100f, 100f);
        private AmmoPool _ammoPoll;

        public void OnDamage(float damage)
        {
            _health.ChangeCurrentHealth(damage);
            Debug.Log(_health.Current);
        }

        private void Start()
        {
            _ammoPoll = new AmmoPool(_bullet);
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);
        }
        private void Update()
        {
            var direction = Input.mousePosition -
            _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),
            Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }
            if (Input.GetButtonDown("Fire1"))
            {
                var temAmmunition = _ammoPoll.Get();
                temAmmunition.transform.position = _barrel.transform.position;
                StartCoroutine(corutineDelete(temAmmunition));
              //  var temAmmunition = Instantiate(_bullet, _barrel.position,  _barrel.rotation);
                temAmmunition.AddForce(_barrel.up * _force, ForceMode2D.Impulse);
            }
        }

        IEnumerator corutineDelete(Rigidbody2D _bullet)
        {
            float _time = 0;
            while (_time < 2)
            {
                _time += Time.deltaTime;
                yield return null;
            }
            _ammoPoll.Return(_bullet);
        }

        
    }
}
