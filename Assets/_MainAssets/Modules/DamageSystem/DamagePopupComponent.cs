using DG.Tweening;
using TMPro;
using UnityEngine;

namespace DamageSystem
{
    public class DamagePopupComponent : MonoBehaviour
    {
        [SerializeField] private TMP_Text damageText;
        [SerializeField] private Color damageColor = Color.red;
        [SerializeField] private int damageFontSize = 20;
        [SerializeField] private float damageDuration = 0.5f;
        
        private Canvas canvas;

        private void Awake()
        {
            Init();
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.R)) return;

            var quad = GameObject.Find("Quad").transform.position;
            var quadPos = Camera.main.WorldToScreenPoint(quad);

            var targetPosition = Input.mousePosition;
            ShowDamage(10, quadPos, new Vector2(0, 10));
        }


        private void Init()
        {
            canvas = damageText.canvas;
        }

        public void ShowDamage(int damage, Vector2 targetPos, Vector2 offset = default)
        {
            targetPos.x -= (float)Screen.width / 2;
            targetPos.y -= (float)Screen.height / 2;
            targetPos += offset;
            targetPos /= canvas.scaleFactor;


            damageText.text = damage.ToString();
            damageText.color = damageColor;
            damageText.fontSize = damageFontSize;
            damageText.enabled = true;
            // Reset Position and Alpha
            damageText.rectTransform.anchoredPosition = targetPos;
            damageText.alpha = 1f;
            // Move and Fade
            damageText.rectTransform.DOLocalMoveY(damageText.rectTransform.localPosition.y + 10, damageDuration)
                .SetEase(Ease.OutQuad);
            damageText.DOFade(0f, damageDuration).SetEase(Ease.OutQuad).OnComplete(() => damageText.enabled = false);
        }
    }
}