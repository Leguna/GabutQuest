using UnityEngine;
using Utilities;

namespace DamageModule.HealthBar
{
    public class HealthBarPool : ObjectPoolingBase<HealthBarComponent>
    {
        public void GetObject(IHealthBar healthBarData, Transform target, Vector2 offset = default)
        {
            var healthBar = base.GetObject();
            healthBar.Init(healthBarData, target, offset);
        }
    }
}