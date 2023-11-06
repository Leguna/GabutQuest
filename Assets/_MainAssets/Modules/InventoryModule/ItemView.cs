using System;
using Item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryModule
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private BaseItem baseItem;

        [SerializeField] private TMP_Text itemName;
        [SerializeField] private Image itemImage;
        [SerializeField] private Button itemButton;

        private Action OnClickAction { get; set; }

        public void Init(BaseItem newBaseItem)
        {
            baseItem = newBaseItem;
            itemName.text = newBaseItem.itemName;
            if (newBaseItem.resourcePath != null)
                itemImage.sprite = Resources.Load<Sprite>(newBaseItem.resourcePath);
            itemButton.onClick.RemoveAllListeners();
            itemButton.onClick.AddListener(OnClick);
        }

        public void SetListener(Action onClickAction)
        {
            OnClickAction = onClickAction;
        }

        private void OnClick()
        {
            OnClickAction?.Invoke();
        }
    }
}