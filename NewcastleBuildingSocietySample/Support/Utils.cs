using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewcastleBuildingSocietySample.Models;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using OpenQA.Selenium.Interactions;
using NUnit.Framework.Internal;
using NUnit.Framework;
using System.Globalization;

namespace NewcastleBuildingSocietySample.Support
{
    internal class Utils
    {
        /// Waits for an element to be clickable by its XPath and then clicks it.
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="xpath">The text of an element.</param>

        public static void ClickElementByText(IWebDriver driver, string text)
        {
            // Find elements by XPath that contains the text
            driver.FindElement(By.XPath($"//*[text()='{text}']")).Click();
        }

        static Func<string, By> ReturnXPathIfTextGiven = (text) => By.XPath($"//*[text()='{text}']");

        /// Waits for an element to be clickable by its XPath and then clicks it.
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="xpath">The XPath of the element to wait for and click.</param>
        /// <param name="timeoutInSeconds">The maximum time to wait in seconds.</param>
        public static void WaitForElementAndClick(IWebDriver driver, string text, string locatorType, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            switch (locatorType.ToLower())
            {
                case "textlocator":
                    wait.Until(ExpectedConditions.ElementToBeClickable(ReturnXPathIfTextGiven(text))).Click();
                    break;
                case "idlocator":
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(text))).Click();
                    break;
                case "xpath":
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(text))).Click();
                    break;
                case "linktext":
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(text))).Click();
                    break;
                default:
                    throw new ArgumentException("Invalid locator type");
            }

        }

        public static void WaitForElementAndClick(IWebDriver driver, string text, int timeoutInSeconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(ReturnXPathIfTextGiven(text))).Click();
        }
        //fills Appointment form form
        public static void FillTheForm(BookModel appt, IWebDriver driver)
        {
            driver.FindElement(By.Id("input_4")).SendKeys(appt.FirstName);
            driver.FindElement(By.Id("input_7")).SendKeys(appt.Email);
            driver.FindElement(By.Id("input_5")).SendKeys(appt.Surname);
            driver.FindElement(By.Id("input_13")).SendKeys(appt.Phone);
            driver.FindElement(By.Id("input_9")).SendKeys(appt.CallTime);
        }

        /// <summary>
        /// Selects an option from a dropdown by visible text.
        /// </summary>
        /// <param name="driver">The WebDriver instance.</param>
        /// <param name="locatorText">locator text as XPath.</param>
        /// <param name="visibleText">The visible text of the option to be selected.</param>
        public static void SelectFromDropdownByGivenLocator(IWebDriver driver, string locatorText, string visibleText)
        {
            var select = new SelectElement(driver.FindElement(By.XPath(locatorText)));
            select.SelectByText(visibleText);
        }
        public static void SelectFromDropdownByGivenId(IWebDriver driver, string idText, string visibleText)
        {
            var select = new SelectElement(driver.FindElement(By.Id(idText)));
            select.SelectByText(visibleText);
        }
        public static void ClickByHoverOverAndActions(IWebDriver driver, string xpathLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpathLocator)));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            driver.FindElement(By.XPath(xpathLocator)).Click();
        }
       

    }
}



