using System.Collections.Generic;
using Item;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryModule
{
    public class InventoryView : MonoBehaviour
    {
        private List<BaseItem> _baseItems = new();
        [SerializeField] private Button closeButton;

        [SerializeField] private GameObject inventoryPanel;
        [SerializeField] private ItemView itemPrefab;
        [SerializeField] private Transform itemParent;

        [SerializeField] private GameObject emptyInventoryPanel;
        [SerializeField] private GameObject infoPanel;
        [SerializeField] private TMP_Text itemName;
        [SerializeField] private Image itemImage;
        [SerializeField] private TMP_Text itemDescription;
        [SerializeField] private TMP_Text itemAmount;

        public void Init(List<BaseItem> items)
        {
            SetItems(items);
            SetListeners();
        }

        private void SetListeners()
        {
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(Close);
        }

        private void SetItems(List<BaseItem> items)
        {
            _baseItems = items;
            foreach (Transform child in itemParent)
            {
                Destroy(child.gameObject);
            }

            foreach (var item in _baseItems)
            {
                var itemView = Instantiate(itemPrefab, itemParent);
                itemView.Init(item);
                itemView.SetListener(() => SetSelectedItem(item));
            }
        }

        private void SetSelectedItem(BaseItem item)
        {
            itemName.text = item.itemName;
            itemDescription.text = item.description;
            itemAmount.text = "Amount: " + item.amount;
            itemImage.sprite = Resources.Load<Sprite>(item.resourcePath);
            emptyInventoryPanel.SetActive(false);
            infoPanel.SetActive(true);
        }

        private void Close()
        {
            inventoryPanel.SetActive(false);
            emptyInventoryPanel.SetActive(true);
            infoPanel.SetActive(false);
        }

        private void Open()
        {
            inventoryPanel.SetActive(true);
            emptyInventoryPanel.SetActive(true);
        }
    }
}