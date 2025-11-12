using System.Runtime.InteropServices;
using Checkout.Services;
using CheckOutServiceTests;

namespace CheckOutTests
{
    public class GetTotalTests : CheckoutServiceTests
    {
        [Fact]
        public void Should_ApplySpecialPriceAndNormal_When_SpecialPriceAmountOfItemsPlusExtraItemNotInADeal()
        {
            CheckoutService checkout = GetCheckoutService();
            checkout.ScanItem("A");
            checkout.ScanItem("A");
            checkout.ScanItem("A");
            checkout.ScanItem("A");
            double total = checkout.GetTotalPrice();
            Assert.Equal(180, total);
        }

        [Fact]
        public void Should_ApplySpecialPrices_When_DealsScannedInSequence()
        {
            CheckoutService checkoutService = GetCheckoutService();
            checkoutService.ScanItem("A");
            checkoutService.ScanItem("A");
            checkoutService.ScanItem("A");
            checkoutService.ScanItem("B");
            checkoutService.ScanItem("B");
            double total = checkoutService.GetTotalPrice();
            Assert.Equal(175, total);
        }

        [Fact]
        public void Should_ApplySpecialPrices_WhenDealScannedInMixedOrder()
        {
            CheckoutService checkout = GetCheckoutService();
            checkout.ScanItem("A");
            checkout.ScanItem("B");
            checkout.ScanItem("A");
            checkout.ScanItem("B");
            checkout.ScanItem("A");
            double total = checkout.GetTotalPrice();
            Assert.Equal(175, total);
        }

        [Fact]
        public void Should_ReturnCorrectPrice_When_MultipleGetPriceCalled()
        {
            CheckoutService checkoutService = GetCheckoutService();
            checkoutService.ScanItem("A");
            checkoutService.GetTotalPrice();
            checkoutService.ScanItem("B");
            double total = checkoutService.GetTotalPrice();
            Assert.Equal(80, total);
        }

        [Fact]
        public void Should_ReturnMultipleSpecialPrice_When_EnoughItemsForMultipleSpecialPrice()
        {
            CheckoutService checkoutService = GetCheckoutService();
            checkoutService.ScanItem("A");
            checkoutService.ScanItem("A");
            checkoutService.ScanItem("A");
            checkoutService.ScanItem("A");
            checkoutService.ScanItem("A");
            checkoutService.ScanItem("A");
            double total = checkoutService.GetTotalPrice();
            Assert.Equal(260, total);
        }

        [Fact]
        public void Should_ReturnNormalPrice_When_IncompleteSpecialPrice()
        {
            CheckoutService checkoutService = GetCheckoutService();
            checkoutService.ScanItem("A");
            checkoutService.ScanItem("A");
            double total = checkoutService.GetTotalPrice();
            Assert.Equal(100, total);
        }

        [Fact]
        public void Should_ReturnSingleItemPrice_When_SingleItemScanned()
        {
            CheckoutService checkoutService = GetCheckoutService();

            checkoutService.ScanItem("A");
            double total = checkoutService.GetTotalPrice();
            Assert.Equal(50, total);
        }

        [Fact]
        public void Should_ReturnSpecialAndNonSpecial_When_MixedSpecialAndNonSpecialItems()
        {
            CheckoutService checkoutService = GetCheckoutService();
            checkoutService.ScanItem("A");
            checkoutService.ScanItem("B");
            checkoutService.ScanItem("C");
            checkoutService.ScanItem("D");
            checkoutService.ScanItem("C");
            checkoutService.ScanItem("B");
            double total = checkoutService.GetTotalPrice();
            Assert.Equal(150, total);
        }

        [Fact]
        public void Should_ReturnSpecialPriceA_When_ThreeAsScanned()
        {
            CheckoutService checkoutService = GetCheckoutService();

            checkoutService.ScanItem("A");
            checkoutService.ScanItem("A");
            checkoutService.ScanItem("A");
            double total = checkoutService.GetTotalPrice();
            Assert.Equal(130, total);
        }

        [Fact]
        public void Should_ReturnSpecialPriceB_When_TwoBsScanned()
        {
            CheckoutService checkoutService = GetCheckoutService();
            checkoutService.ScanItem("B");
            checkoutService.ScanItem("B");
            double total = checkoutService.GetTotalPrice();
            Assert.Equal(45, total);
        }

        [Fact]
        public void Should_ReturnTotalOfIndiviudalPrices_When_AllSingleItemsScanned()
        {
            CheckoutService checkoutService = GetCheckoutService();

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

            double total = checkoutService.GetTotalPrice();
            Assert.Equal(0, total);
        }
    }
}
