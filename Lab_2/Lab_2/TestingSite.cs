using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Compatibility;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Lab_2
{
    [TestFixture]
    public class TestingSite
    {
        IWebDriver webDriver;
        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
            webDriver.Url = "https://www.toolsqa.com/";
            webDriver.Manage().Window.Maximize();
        }
        

        [Test]
        public void title_test()
        {
            Assert.AreEqual("Tools QA", webDriver.Title);
        }

        [Test]
        public void visible_of_hamgurger_menu_button_test()
        {
            Assert.NotNull(webDriver.FindElement(By.Id("hamburger-menu")).Displayed);
        }

        [Test]
        public void link_read_more_test()
        {
            IWebElement link = webDriver.FindElement(By.XPath(".//div[@class='col-auto pl-0']"));
            link.Click();
            webDriver.Close();
        }

        [Test]
        public void enroll_yourself_button_test()
        {
            IWebElement firstClick = webDriver.FindElement(By.XPath(".//div[@class='col col-sm-6 col-md-7']/a"));
            firstClick.Click();
            webDriver.Close();
        }

        [Test]
        public void search_test()
        {
            IWebElement textBox = webDriver.FindElement(By.CssSelector("input[class=navbar__search--input]"));
            textBox.SendKeys("example" + OpenQA.Selenium.Keys.Enter);

            webDriver.Close();
        }

        [Test]
        public void go_to_youtube_channel_test()
        {
            IWebElement accept = webDriver.FindElement(By.CssSelector("button[id=accept-cookie-policy]"));
            accept.Click();

            IWebElement link = webDriver.FindElement(By.XPath(".//span[text()='Youtube']"));
            link.Click();

            webDriver.Close();
        }

        [Test]
        public void go_to_tutorials_test()
        {
            IWebElement link = webDriver.FindElement(By.CssSelector("a[class=navbar__tutorial-menu]"));
            link.Click();

            IWebElement span = webDriver.FindElement(By.XPath(".//span[text()='Front-End Testing Automation']"));

            new Actions(webDriver)
                .ClickAndHold(span)
                .Perform();

            IWebElement istb = webDriver.FindElement(By.XPath(".//a[text()='Cypress']"));

            new Actions(webDriver)
                .ClickAndHold(istb)
                .Perform();

            
            IWebElement istbLink = webDriver.FindElement(By.XPath("./html/body/nav/div/div/div[2]/div/ul/li[2]/a"));

            istbLink.Click();

            webDriver.Close();

        }

        [TearDown]
        public void test_end()
        {
            webDriver.Quit();
        }
    }
}
