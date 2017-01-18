using Xunit;
using HoneymoonShop.Controllers;
using HoneymoonShop.Data;
using HoneymoonShop.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit.Sdk;

namespace HoneymoonShop.UnitTests
{
    public class Class1
    {

        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }


        [Fact]
        public void TestDelete()
        {
            Jurk jurk = new Jurk() {Artikelnummer = 9999999, JurkId = 1};
            Jurk jurk2 = new Jurk() {Artikelnummer = 11111111, JurkId = 2};
            HoneyMoonShopContext context = new HoneyMoonShopContext();
            context.Add(jurk);
            context.Add(jurk2);
            var mock = new Mock<IHoneymoonshopRepository>();

            mock.Setup(x => x.DeleteJurk(jurk.JurkId));
            
            BeheerController beheer = new BeheerController(mock.Object);
            beheer.Delete(jurk.JurkId);
            mock.Verify(f => f.DeleteJurk(jurk.JurkId));

        }
        //werkt
        [Fact]
        public void Geldige_Edit_BeheerController()
        {
            var mock = new Mock<IHoneymoonshopRepository>();
            BeheerController controller = new BeheerController(mock.Object);
            Jurk jurk = new Jurk() { Artikelnummer = 9999999, JurkId = 1 };
            var result = controller.Edit(jurk);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Crud", redirectToActionResult.ActionName);
        }

        public void FilterReturnedJuisteJurk()
        {
            string[] filterMerk = { "Maggie Sottero" };
            string[] filterStijl = { "Kant" };
            string neklijnDd =  "strapless";
            string silhouetteDd =  "Fishtail" ;
            string[] slider = { "1200", "2300" };
            string orderType = "ascending";
            string kleurenDd = null;
            Jurk jurk1 = new Jurk() { JurkId = 34, Artikelnummer = 34, Merk = "Maggie Sottero", Stijl = "Kant", MinPrijs = 1200, MaxPrijs = 2300, Neklijn = "strapless", Silhouette = "Fishtail" };
            Jurk jurk2 = new Jurk() { JurkId = 34, Artikelnummer = 012, Merk = "Ladybird", Stijl = "Kant", MinPrijs = 1200, MaxPrijs = 2300, Neklijn = "strapless", Silhouette = "Fishtail" };

            Mock<IHoneymoonshopRepository> mock = new Mock<IHoneymoonshopRepository>();
            DressFinderController dtf = new DressFinderController();
            var result = dtf.FilterVerwerken(filterMerk, filterStijl, neklijnDd, silhouetteDd, kleurenDd ,slider, orderType);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("ProductsPartial", redirectToActionResult.ActionName);

            // string[] filterMerk, string[] filterStijl, string neklijnDd, string silhouetteDd, string kleurenDd, string[] slider, string orderType 

        }
    }
}   