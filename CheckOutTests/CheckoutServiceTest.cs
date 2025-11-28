using Checkout.Services;
using Checkout.SpecialPricesRules;


namespace CheckOutTests
{
    public class CheckoutServiceTest
    {
        [Fact]
        public void Should_ThrowNullException_When_RepositoryIsNull()
        {
            List<SpecialPriceRuleBase> rules = new List<SpecialPriceRuleBase>() {
                new SpecialPriceRuleMultiBuy("A", 130, 3),
                new SpecialPriceRuleMultiBuy("B", 45, 2)
            };
            BagPricingService bagPricingService = new BagPricingService(0, 0);
            // As IRepository is not nullable should never be null but  in case it's not injected incorrectly should return null exception
            Assert.Throws<NullReferenceException>(() => new CheckoutService(rules, null, bagPricingService));
        }

        [Fact]
        public void Should_ThrowNullException_When_RulesListIsNull()
        {
            MockProductRepository mockProductRepository = new MockProductRepository();
            BagPricingService bagPricingService = new BagPricingService(0, 0);
            // As PricesRules is not nullable should never be null but  in case it's not injected incorrectly should return null exception
            Assert.Throws<NullReferenceException>(() => new CheckoutService(null, mockProductRepository, bagPricingService));
        }

        [Fact]
        public void Should_ThrowNullException_When_BagPricingServiceIsNull()
        {
            MockProductRepository mockProductRepository = new MockProductRepository();
            List<SpecialPriceRuleBase> rules = new List<SpecialPriceRuleBase>();
            
            // As BagPricingService is not nullable should never be null but  in case it's not injected incorrectly should return null exception
            Assert.Throws<NullReferenceException>(() => new CheckoutService(rules, mockProductRepository, null));
        }
    }
}