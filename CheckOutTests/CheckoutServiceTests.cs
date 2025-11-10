using Checkout.Services;
using Checkout.SpecialPricesRules;
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

    public class ScanItemTests : CheckoutServiceTests
    {
        [Fact]
        public void ScanItem()
        {
            _checkoutService.ScanItem("A");
        }
    }

}