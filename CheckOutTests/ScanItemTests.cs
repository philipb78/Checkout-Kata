using Checkout.Constants;
using CheckOutServiceTests;

namespace CheckOutTests
{
    public class ScanItemTests : CheckoutServiceTests
    {
        [Fact]
        public void Should_ThrowExceptionWhenSKUIsInvalid()
        {
            Action act = () => _checkoutService.ScanItem("Z");
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal(MessageConstants.InvalidSKU, exception.Message);
        }
    }
}