using Checkout.Interfaces;

namespace Checkout.Services
{
    public class BagPricingService : IBagPricingService
    {
        private readonly double _bagUnitPrice;

        private readonly int _itemsPerBag;

        public BagPricingService(double bagUnitPrice, int itemsPerBag)
        {
            _bagUnitPrice = bagUnitPrice;
            _itemsPerBag = itemsPerBag;
        }

        public double GetBagPrice(int totalItems)
        {
            if ((totalItems == 0) || (_itemsPerBag ==0) || (_bagUnitPrice ==0))
            {
                return 0;
            }
            var bagPrice = Math.Ceiling((double)totalItems / _itemsPerBag) * _bagUnitPrice;
            return bagPrice;
        }
    }
}