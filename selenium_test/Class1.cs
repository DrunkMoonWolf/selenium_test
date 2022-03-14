using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace selenium_test
{
    [TestFixture]
    public class Class1
    {
        IWebDriver driver = new ChromeDriver();

        [TestCase]
        public void MaintTitle()
        {
            driver.Url = "https://www.ozon.ru/";
            Assert.AreEqual("OZON — интернет-магазин. Миллионы товаров по выгодным ценам", driver.Title);
            driver.Close();
        }

        [TestCase]
        public void VisibileTest()
        {
            driver.Url = "https://www.ozon.ru/";
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            //установка условия окончания ожидания
            var element = wait.Until(condition =>
            {
                try
                {
                    //до тех пор, пока указанный элемент не станет видим (Displayed == true)
                    var elementToBeDisplayed =
                    driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[1]/div/ul/li[7]/div"));
                    return elementToBeDisplayed.Displayed;
                }
                //в случае, если такого элемента нет
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });

            IWebElement element1 = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[1]/div/ul/li[7]/div"));
            bool status = element1.Displayed;
            driver.Close();
        }

        [TestCase]
        public void EnabledTest()
        {
            driver.Url = "https://www.ozon.ru/";
            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"layoutPage\"]/div[1]/div[3]/div[1]"));
            Boolean status = element.Enabled;
            Assert.AreEqual(true, status);
            driver.Close();
        }

        [TestCase]
        public void TestLink()
        {

            driver.Url = "https://www.ozon.ru/";
            driver.Manage().Window.Maximize();
            IWebElement link = driver.FindElement(By.XPath("//*[@id=\"layoutPage\"]/div[1]"));
            link.Click();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            //установка условия окончания ожидания
            var element = wait.Until(condition =>
            {
                try
                {
                    //до тех пор, пока указанный элемент не станет видим (Displayed == true)
                    var elementToBeDisplayed =
                    driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/header/div[1]/div[3]/div/form/button"));
                    return elementToBeDisplayed.Displayed;
                }
                //в случае, если такого элемента нет
                catch (StaleElementReferenceException) { return false; }
                catch (NoSuchElementException) { return false; }
            });
            driver.Navigate().Back();
            //установка условия окончания ожидания
            element = wait.Until(condition =>
            {
                try
                {
                    //до тех пор, пока указанный элемент не станет видим (Displayed == true)
                    var elementToBeDisplayed =
                    driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/header/div[1]/div[3]/div/form/button"));
                    return elementToBeDisplayed.Displayed;
                }
                //в случае, если такого элемента нет
                catch (StaleElementReferenceException) { return false; }
                catch (NoSuchElementException) { return false; }
            });
            driver.Close();
        }
        [TestCase]
        public void GetCSSValueComand()
        {
            driver.Url = "https://www.ozon.ru/";
            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[2]/div/div[1]/button"));
            String color = element.GetCssValue("color");
            Assert.AreEqual("rgba(0, 26, 52, 1)", color);
            driver.Close();
        }

        [TestCase]
        public void FunctionTest()
        {
            driver.Url = "https://www.ozon.ru/";

            IWebElement search = driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[3]/div/form/div[2]/input[1]"));
            search.SendKeys("Хаги-ваги");

            IWebElement button = driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/header/div[1]/div[3]/div/form/button"));
            button.Click();
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            //установка условия окончания ожидания
            var element = wait.Until(condition =>
            {
                try
                {
                    //до тех пор, пока указанный элемент не станет видим (Displayed == true)
                    var elementToBeDisplayed =
                    driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/header/div[1]/div[3]/div/form/button"));
                    return elementToBeDisplayed.Displayed;
                }
                //в случае, если такого элемента нет
                catch (StaleElementReferenceException) { return false; }
                catch (NoSuchElementException) { return false; }
            });
            IWebElement clear = driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[3]/div/form/div[2]/input[1]"));
            clear.Clear();
            element = wait.Until(condition =>
            {
                try
                {
                    //до тех пор, пока указанный элемент не станет видим (Displayed == true)
                    var elementToBeDisplayed =
                    driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[3]/div/form/div[2]/input[1]"));
                    return elementToBeDisplayed.Displayed;
                }
                //в случае, если такого элемента нет
                catch (StaleElementReferenceException) { return false; }
                catch (NoSuchElementException) { return false; }
            });
            driver.Close();
        }

        [TestCase]
        public void TestTextCommand()
        {
            driver.Url = "https://www.ozon.ru/";
            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[2]/div/div[1]/button"));
            String text = element.Text;
            Assert.AreEqual("Каталог", text);
            driver.Close();
        }

        /*[TestCase]
        public void testSelect()
        {
            driver.Url = "https://www.ozon.ru/";
            driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[2]/div/div[1]/button")).Click();
            //driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[2]/div/div[2]/div/div[1]/div/a[2]")).Click();
            var element = driver.FindElement(By.XPath("//*[@id=\"stickyHeader\"]/div[2]/div/div[2]/div/div[1]/div"));
            SelectElement select = new SelectElement(element);
            select.SelectByText("Одежда");
            driver.Close();
        }*/

        [TearDown]
        public void TestEnd()
        {
            driver.Quit();
        }
    }
}
