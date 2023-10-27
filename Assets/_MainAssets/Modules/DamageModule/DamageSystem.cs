using DamageModule.DamagePopup;
using DamageModule.HealthBar;
using UnityEngine;

namespace DamageModule
{
    public class DamageSystem : MonoBehaviour
    {
        [SerializeField] private DamagePopupComponent damagePopupPrefab;
        [SerializeField] private DamagePopupPool damagePopupPoolPrefab;

        [SerializeField] private HealthBarComponent healthBarPrefab;
        private HealthBarPool healthBarPoolComponent;

        public void Init()
        {
            damagePopupPoolPrefab = Instantiate(damagePopupPoolPrefab, transform);
            damagePopupPoolPrefab.Init(damagePopupPrefab);
            healthBarPoolComponent = transform.gameObject.AddComponent<HealthBarPool>();
            healthBarPoolComponent.Init(healthBarPrefab);
        }

        public void ShowHealthBar(IHealthBar healthBarData, Transform position, Vector2 offset = default)
        {
            healthBarPoolComponent.GetObject(healthBarData, position, offset);
        }

        public void ShowDamagePopup(int damage, Vector3 position, Vector2 offset)
        {
            damagePopupPoolPrefab.GetObject(damage, position, offset);
        }

        public void HideHealthBar(HealthBarComponent healthBarComponent)
        {
            healthBarPoolComponent.ReturnObject(healthBarComponent);
        }

        public void HideDamagePopup(DamagePopupComponent damagePopupComponent)
        {
            damagePopupPoolPrefab.ReturnObject(damagePopupComponent);
        }
    }
}