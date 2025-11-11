using CheckOutServiceTests;

namespace CheckOutTests
{
    public class GetTotalTests : CheckoutServiceTests
    {
        [Fact]
        public void Should_ReturnSingleItemPrice_When_SingleItemScanned()
        {
            _checkoutService.Reset();
            _checkoutService.ScanItem("A");
            double total = _checkoutService.GetTotalPrice();
            Assert.Equal(50, total);
        }

        [Fact]
        public void Should_ReturnSpecialPriceA_When_ThreeAsScanned()
        {
            _checkoutService.Reset();
            _checkoutService.ScanItem("A");
            _checkoutService.ScanItem("A");
            _checkoutService.ScanItem("A");
            double total = _checkoutService.GetTotalPrice();
            Assert.Equal(130, total);
        }

        [Fact]
        public void Should_ReturnTotalOfIndiviudalPrices_When_AllSingleItemsScanned()
        {
            _checkoutService.Reset();
            _checkoutService.ScanItem("A");
            _checkoutService.ScanItem("B");
            _checkoutService.ScanItem("C");
            _checkoutService.ScanItem("D");

            double total = _checkoutService.GetTotalPrice();

            Assert.Equal(115, total);
        }

        [Fact]
        public void Should_ReturnZero_When_NoItemsScanned()
        {
            _checkoutService.Reset();
            double total = _checkoutService.GetTotalPrice();
            Assert.Equal(0, total);
        }
    }
}