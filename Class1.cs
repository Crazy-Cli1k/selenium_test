using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace selenium_test
{
    [TestFixture]
    public class sibsuti_test
    {
        //http://kremlin.ru/
        IWebDriver webDriver = new ChromeDriver();
        [TestCase]
        public void mainTitle()//проверка правильности заголовка
        {
            webDriver.Url = "https://pop-music.ru/";
            webDriver.Manage().Window.Maximize();
            Assert.AreEqual("Магазин музыкального оборудования POP-MUSIC.RU - Музыкальные инструменты и оборудование по низким ценам в Москве и Санкт-Петербурге", webDriver.Title);
        }

        [TestCase]
        public void button_test()//проверка добавления товара в корзину
        {
            webDriver.Url = "https://pop-music.ru/";
            webDriver.Manage().Window.Maximize();
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 10));
            var element = wait.Until(condition =>
            {
                try
                {
                    //до тех пор, пока указанный элемент не станет видим (Displayed == true)
                    var elementToBeDisplayed =
                    webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div[3]/div[2]/div[1]/div/div[2]/div/div[4]/a"));
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
            IWebElement button = webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div[3]/div[2]/div[1]/div/div[2]/div/div[4]/a"));
            button.Click();
        }
        [TestCase]
        public void label_test()//проверка содержимого лебла
        {
            webDriver.Url = "https://pop-music.ru/";
            webDriver.Manage().Window.Maximize();
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 10));
            var element = wait.Until(condition =>
            {
                try
                {
                    //до тех пор, пока указанный элемент не станет видим (Displayed == true)
                    var elementToBeDisplayed =
                    webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div[3]/h2"));
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
            IWebElement label = webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div[3]/h2"));
            Assert.AreEqual("Наша распродажа", label.Text);
        }
        [TestCase]
        public void link_test()//переход к товару по нажатию на картинку
        {
            webDriver.Url = "https://pop-music.ru/";
            webDriver.Manage().Window.Maximize();
            var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 10));
            var element = wait.Until(condition =>
            {
                try
                {
                    //до тех пор, пока указанный элемент не станет видим (Displayed == true)
                    var elementToBeDisplayed =
                    webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div[3]/div[2]/div[1]/div/div[3]/div/div[1]/a"));
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
            IWebElement link_block = webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div[3]/div[2]/div[1]/div/div[3]/div/div[1]/a"));
            link_block.Click();

            var page = webDriver.FindElement(By.XPath("/html/body/div[1]"));
            Assert.AreEqual(true, page.Displayed);
        }
        [TestCase]
        public void input_test()//проверка поиска
        {
            webDriver.Url = "https://pop-music.ru/";
            webDriver.Manage().Window.Maximize();

            IWebElement search = webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/header/div[2]/div[1]/div[2]/div/form/input"));

            search.Click();

            search.SendKeys("gfgfgfg");

            IWebElement button2 = webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/header/div[2]/div[1]/div[2]/div/form/button"));
            button2.Click();

            IWebElement header = webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div[2]/div/div/h4"));
            Assert.AreEqual("По вашей фразе ничего не найдено. Обратите внимание на наши новинки.", header.Text);
        }

        [TestCase]
        public void Check_test()//проверка входа в корзину
        {
            webDriver.Url = "https://pop-music.ru/";
            webDriver.Manage().Window.Maximize();

            IWebElement button = webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/header/div[2]/div[1]/div[4]/a[4]"));
            button.Click();

            var page = webDriver.FindElement(By.XPath("/html/body/div[1]"));
            Assert.AreEqual(true, page.Displayed);
        }

        [TestCase]
        public void City_test()//проверка смены города
        {
            webDriver.Url = "https://pop-music.ru/";
            webDriver.Manage().Window.Maximize();

            IWebElement button = webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/header/div[1]/div/div/div[1]/div[1]"));
            button.Click();

            IWebElement button2 = webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/header/div[1]/div/div/div[1]/div[1]/div[2]/ul/li[4]/a"));
            button2.Click();

            IWebElement name = webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/header/div[1]/div/div/div[1]/div[1]/div[1]/span"));
            button2.Click();

            Assert.AreEqual("Екатеринбург", button2.Text);
        }

        [TestCase]
        public void Button_Text_test()//проверка текста кнопки
        {
            webDriver.Url = "https://pop-music.ru/";
            webDriver.Manage().Window.Maximize();

            IWebElement button = webDriver.FindElement(By.XPath("/html/body/div[1]/div/div[2]/div[2]/div/div[3]/div[2]/div[1]/div/div[2]/div/div[4]/a"));
            Assert.AreEqual("В корзину", button.Text);
        }
    }
}
