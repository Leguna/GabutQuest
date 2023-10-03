using UnityEngine;

namespace Currency
{
    public class CurrencySystem : MonoBehaviour
    {
        public Gold Gold;
        public Gem Gem;
        public PaidGem PaidGem;
        
        public void Init()
        {
            Gold = new Gold();
            Gem = new Gem();
            PaidGem = new PaidGem();
        }
        
        // TODO: Continue after finish the CurrencyDatabase.cs
        
        
    }
}