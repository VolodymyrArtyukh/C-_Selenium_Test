using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriver
{
    
    public class Selenium
    {

        private IWebDriver driver;

        [SetUp]
        public void Start()
        {

            driver = new ChromeDriver();            //selecting Chrome browser
            driver.Manage().Window.Maximize();      //making full screen window in browser
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);     // waiting for 10 seconds before the page loads


        }

        [Test]
        public void OpenBrowser()
        {
            String nameSearchField = "q";
            String firstlink = "DOU: Сообщество программистов";
            String linkFirstJob = "Первая работа";


            driver.Url = "http://www.google.com";       //navigating to Google

            IWebElement searchField = driver.FindElement(By.Name(nameSearchField));     //selecting search field
            searchField.SendKeys("www.dou.ua");     //entering "www.dou.ua" in search field
            searchField.SendKeys(Keys.Enter);       //clicking Enter 


            IWebElement clickingLink = driver.FindElement(By.LinkText(firstlink));      //selecting DOU page
            clickingLink.Click();       //clicking DOU page

            IWebElement firstJob = driver.FindElement(By.LinkText(linkFirstJob));       //selecting link First Job
            Boolean status = firstJob.Displayed;        //Checking if First Job is in (displayed) on the web page

        }

        [TearDown]
        public void Stop()
        {
            Thread.Sleep(5000);     // waiting for 5 seconds 

            if (driver != null)     // if driver is present
            {
                driver.Close();     // close Chrome
            }

        }
    }
}
