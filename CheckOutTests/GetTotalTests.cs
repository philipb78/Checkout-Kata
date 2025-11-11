using CheckOutServiceTests;

namespace CheckOutTests
{
    public class GetTotalTests: CheckoutServiceTests
    {
        [Fact]
        public void Should_ReturnZero_When_NoItemsScanned()
        {
            double total = _checkoutService.GetTotalPrice();
            Assert.Equal(0, total);
        }
    }
}
