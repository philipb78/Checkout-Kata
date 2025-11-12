using Checkout.Constants;
using Checkout.Services;
using CheckOutServiceTests;

namespace CheckOutTests
{
    public class ScanItemTests : CheckoutServiceBase
    {
        [Fact]
        public void Should_ThrowException_When_SKUIsInvalid()
        {
            CheckoutService checkoutService = GetCheckoutService();
            Action act = () => checkoutService.ScanItem("Z");
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal(MessageConstants.InvalidSKU, exception.Message);
        }
    }
}