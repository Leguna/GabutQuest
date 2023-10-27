using UnityEngine;
using Utilities;

namespace DamageModule.DamagePopup
{
    public class DamagePopupPool : ObjectPoolingBase<DamagePopupComponent>
    {
        public DamagePopupComponent GetObject(int damage, Vector2 targetPos,
            Vector2 offset = default)
        {
            var damagePopup = base.GetObject();
            damagePopup.Init();
            damagePopup.ShowDamage(damage, targetPos, () => ReturnObject(damagePopup), offset);
            return damagePopup;
        }
    }
}