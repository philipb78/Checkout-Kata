using Checkout.Services;
using CheckOutServiceTests;

namespace CheckOutTests
{
    public class GetTotalTests : CheckoutServiceTests
    {
        [Fact]
        public void Should_ReturnSingleItemPrice_When_SingleItemScanned()
        {
            CheckoutService checkoutService = GetCheckoutService();
            checkoutService.Reset();
            checkoutService.ScanItem("A");
            double total = checkoutService.GetTotalPrice();
            Assert.Equal(50, total);
        }

        [Fact]
        public void Should_ReturnSpecialPriceA_When_ThreeAsScanned()
        {
            CheckoutService checkoutService = GetCheckoutService();
            checkoutService.Reset();
            checkoutService.ScanItem("A");
            checkoutService.ScanItem("A");
            checkoutService.ScanItem("A");
            double total = checkoutService.GetTotalPrice();
            Assert.Equal(130, total);
        }

        [Fact]
        public void Should_ReturnTotalOfIndiviudalPrices_When_AllSingleItemsScanned()
        {
            CheckoutService checkoutService = GetCheckoutService();
            checkoutService.Reset();
            checkoutService.ScanItem("A");
            checkoutService.ScanItem("B");
            checkoutService.ScanItem("C");
            checkoutService.ScanItem("D");

            double total = checkoutService.GetTotalPrice();

            Assert.Equal(115, total);
        }

        [Fact]
        public void Should_ReturnZero_When_NoItemsScanned()
        {
            CheckoutService checkoutService = GetCheckoutService();
            checkoutService.Reset();
            double total = checkoutService.GetTotalPrice();
            Assert.Equal(0, total);
        }
    }
}