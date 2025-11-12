using Checkout.Services;
using Checkout.SpecialPricesRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // As IRepository is not nullable should never be null but  in case it's not injected incorrectly should return null exception
            Assert.Throws<NullReferenceException>(() => new CheckoutService(rules, null));

        }

        [Fact]
        public void Should_ThrowNullException_When_RulesListIsNull()
        {
            MockProductRepository mockProductRepository = new MockProductRepository();
         
            // As PricesRules is not nullable should never be null but  in case it's not injected incorrectly should return null exception
            Assert.Throws<NullReferenceException>(() => new CheckoutService(null, mockProductRepository));
        }
    }
}
