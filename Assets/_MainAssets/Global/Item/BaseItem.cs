using UnityEngine;

namespace Item
{
    [CreateAssetMenu(fileName = "BaseItem", menuName = "Item/BaseItem", order = 0)]
    public class BaseItem : ScriptableObject
    {
        public string id;
        public string itemName;
        public string description;
        public string resourcePath;
        public int amount;

        public BaseItem(string id, string itemName, string description, string resourcePath, int amount)
        {
            this.id = id;
            this.itemName = itemName;
            this.description = description;
            this.resourcePath = resourcePath;
            this.amount = amount;
        }
    }
}