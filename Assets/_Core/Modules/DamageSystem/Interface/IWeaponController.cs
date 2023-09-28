namespace DamageSystem
{
    public interface IWeaponController : IWeapon
    {
        // Delay
        public float Delay { get; set; }
        void Attack(IDamageable target);
    }
}