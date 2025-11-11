using Checkout.Constants;
using Checkout.Services;
using CheckOutServiceTests;

namespace CheckOutTests
{
    public class ScanItemTests : CheckoutServiceTests
    {
        [Fact]
        public void Should_ThrowExceptionWhenSKUIsInvalid()
        {
            CheckoutService checkoutService = GetCheckoutService();
            Action act = () => checkoutService.ScanItem("Z");
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal(MessageConstants.InvalidSKU, exception.Message);
        }
    }
}