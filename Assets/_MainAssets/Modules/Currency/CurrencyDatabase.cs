namespace Currency
{
    public class CurrencyDatabase
    {
        public static BaseCurrency GetCurrency(string id)
        {
            switch (id)
            {
                case "gold":
                    return new Gold();
                case "gem":
                    return new Gem();
                case "paid_gem":
                    return new PaidGem();
                default:
                    return null;
            }
        }

        // TODO: Continue after create base API for currency system
    }
}