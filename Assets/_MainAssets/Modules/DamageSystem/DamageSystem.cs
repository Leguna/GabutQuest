using DamageSystem.DamagePopup;
using DamageSystem.HealthBar;
using Unity.VisualScripting;
using UnityEngine;

namespace DamageSystem
{
    public class DamageSystem : MonoBehaviour
    {
        [SerializeField] private DamagePopupComponent damagePopupPrefab;
        [SerializeField] private DamagePopupPool damagePopupPoolPrefab;

        [SerializeField] private HealthBarComponent healthBarPrefab;
        private HealthBarPool healthBarPoolComponent;

        private void Awake()
        {
            damagePopupPoolPrefab = Instantiate(damagePopupPoolPrefab, transform);
            damagePopupPoolPrefab.Init(damagePopupPrefab);
            healthBarPoolComponent = transform.AddComponent<HealthBarPool>();
            healthBarPoolComponent.Init(healthBarPrefab);
        }

        public void ShowHealthBar(HealthComponent healthComponent, Transform position, Vector2 offset = default)
        {
            healthBarPoolComponent.GetObject(healthComponent, position, offset);
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