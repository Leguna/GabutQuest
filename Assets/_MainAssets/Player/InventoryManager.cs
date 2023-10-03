using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private GameObject _inventoryPanel;

        [SerializeField] private TMP_Text _woodText;
        [SerializeField] private TMP_Text _stoneText;
        [SerializeField] private TMP_Text _ramText;
        [SerializeField] private TMP_Text _modarText;

        public UnityEvent onInventoryUpdate;

        private void Start()
        {
            _inventoryPanel.SetActive(false);
        }

        private void OnGUI()
        {
            // if (GUI.Button(new Rect(10, 10, 150, 100), "Add Modar"))
            // {
            //     AddCurrency(CurrencyID.Modar, 100);
            // }
            //
            // if (GUI.Button(new Rect(10, 110, 150, 100), "Add Ram"))
            // {
            //     AddCurrency(CurrencyID.Ram, 100);
            // }
            //
            // if (GUI.Button(new Rect(10, 210, 150, 100), "Add Wood"))
            // {
            //     AddCurrency(CurrencyID.Wood, 100);
            // }
            //
            // if (GUI.Button(new Rect(10, 310, 150, 100), "Add Stone"))
            // {
            //     AddCurrency(CurrencyID.Stone, 100);
            // }
        }

        public void InventoryUpdate()
        {
            // Debug.Log("Init");
            // var playerBalance = await EconomyService.Instance.PlayerBalances.GetBalancesAsync();
            // Debug.Log("Player Balance: " + playerBalance.Balances.First().CurrencyId + " " +
            //           playerBalance.Balances.First().Balance);
            // _modarText.text = playerBalance.Balances.Find(x => x.CurrencyId == CurrencyID.Modar).Balance.ToString();
            // _ramText.text = playerBalance.Balances.Find(x => x.CurrencyId == CurrencyID.Ram).Balance.ToString();
            // _inventoryPanel.SetActive(true);
            // onInventoryUpdate.Invoke();
        }

        public void AddCurrency(string currencyId, int amount)
        {
            // await EconomyService.Instance.PlayerBalances.IncrementBalanceAsync(currencyId, amount);
            // InventoryUpdate();
        }
    }
}