namespace DamageSystem
{
    public class ObjectController : IDamageable, IHealth
    {
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void Destroy()
        {
            
        }

        public int Health { get; set; }
        public int MaxHealth { get; }
    }
}