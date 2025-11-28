

namespace Checkout.Interfaces
{
    public interface IBagPricingService
    {
        double GetBagPrice(int totalItems);
    }
}
