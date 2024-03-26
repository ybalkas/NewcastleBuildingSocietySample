using NUnit.Framework;
using System.Security.Policy;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using NewcastleBuildingSocietySample.Support;
using static System.Net.Mime.MediaTypeNames;
using NewcastleBuildingSocietySample.Models;
using TechTalk.SpecFlow.Assist;
using System.Threading.Tasks;


namespace NewcastleBuildingSocietySample.StepDefinitions
{
    [Binding]
    public sealed class AppointmentStepDefns
    {
        public IWebDriver driver = new ChromeDriver();
        [Given(@"I am on the homepage of ""([^""]*)""")]
        public void GivenIAmOnTheHomepageOf(string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
           
            Assert.AreEqual(url, driver.Url);
            //Utils.ClickElementByText(driver, "Accept All Cookies");
            Utils.WaitForElementAndClick(driver, "//*[text()='Accept All Cookies']", "xpath", 30);
        }

        [When(@"I navigate to the ""([^""]*)"" by cliking our branches")]
        public void WhenINavigateToTheByClikingOurBranches(string p0)
        {
            Utils.WaitForElementAndClick(driver, "(//*[text()='Our Branches'])[3]", "xpath", 20);
        }

        [When(@"I click book an appointment")]
        public void WhenIClickBookAnAppointment()
        {
            Utils.WaitForElementAndClick(driver, "(//*[text()='Book an Appointment'])[4]", "xpath", 20); 
        }

        [Then(@"Ishould be able to navigate ""([^""]*)""")]
        public void ThenIshouldBeAbleToNavigate(string url)
        {
            Assert.AreEqual(url, driver.Url);
        }

        [Then(@"I enter my personal details including ""([^""]*)"", ""([^""]*)"", and ""([^""]*)"" etc\.\.")]
        public void ThenIEnterMyPersonalDetailsIncludingAndEtc_(string name, string email, string p2, Table table)
        {
            Utils.SelectFromDropdownByGivenId(driver, "input_3", "Mr");
            var details = table.CreateInstance<BookModel>();
            Utils.FillTheForm(details, driver);
            Utils.SelectFromDropdownByGivenId(driver, "input_8", "Newcastle");

        }

        [When(@"I click on the ""([^""]*)"" button to book the appointment")]
        public void WhenIClickOnTheButtonToBookTheAppointment(string submit)
        {

            Utils.WaitForElementAndClick(driver, "//button[text()='Submit']", "xpath", 20);
        }

        [Then(@"I should be able to create an appointment")]
        public void ThenIShouldBeAbleToCreateAnAppointment()
        {
            Assert.AreEqual("Thank you for appointment request.", driver.FindElement(By.XPath("//*[text()='Thank you for appointment request.']")).Text);
            driver.Quit();
        }


    }
}
