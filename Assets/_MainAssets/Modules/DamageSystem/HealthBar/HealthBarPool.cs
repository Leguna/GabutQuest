using UnityEngine;
using Utilities;

namespace DamageSystem.HealthBar
{
    public class HealthBarPool : ObjectPoolingBase<HealthBarComponent>
    {
        public void GetObject(HealthComponent healthComponent, Transform target, Vector2 offset = default)
        {
            var healthBar = base.GetObject();
            healthBar.Init(healthComponent, target, offset);
        }
    }
}