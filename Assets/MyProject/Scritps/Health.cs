

namespace Asteroids
{
     public class Health
    {
        public float Max { get; }
        public float Current { get; private set; }

        public Health(float max, float cerrent)
        {
            Max = max;
            Current = cerrent;
        }
        public void ChangeCurrentHealth(float damage)
        {
            Current -= damage;
        }
    }

}
