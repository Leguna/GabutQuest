namespace DamageModule
{
    public interface IWeaponController : IWeapon
    {
        public float Delay { get; set; }
        void Attack(IDamageable target);
    }
}