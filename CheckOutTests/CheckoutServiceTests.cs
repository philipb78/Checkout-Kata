using Checkout.Interfaces;
using Checkout.Services;
using Checkout.SpecialPricesRules;
using CheckOutServiceTests;
using CheckOutTests;

namespace CheckOutServiceTests
{
    public class CheckoutServiceTests
    {
        protected readonly CheckoutService _checkoutService;

        public CheckoutServiceTests()
        {
            MockProductRepository mockProductRepository = new MockProductRepository();
            List<SpecialPriceRuleBase> rules = new List<SpecialPriceRuleBase>();
            _checkoutService = new CheckoutService(rules, mockProductRepository);
            
        }
    }


}
