using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STQA
{
    class Iframe
    {
        ChromeDriver Chrome;

        [SetUp]
        public void StartBrowser()
        {
            Chrome = new ChromeDriver();
            Chrome.Manage().Window.Maximize();
            Chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }
        [Test]
        public void FindIframes() {

            Console.WriteLine("✔ Navegando a http://toolsqa.wpengine.com/iframe-practice-page/");
            Chrome.Navigate().GoToUrl("http://toolsqa.wpengine.com/iframe-practice-page/");

            List<IWebElement> Iframes = new List<IWebElement>(Chrome.FindElements(By.TagName("iframe")));
            Console.WriteLine("✔ En la página existen " + Iframes.Count.ToString() + "  IFRAMES:\r\n");
            Console.WriteLine("✔ Los Iframe son los siguientes:\r\n");

            for (int i = 0; i < Iframes.Count; i++)
                Console.WriteLine("Iframe[" + i + "]: " + Iframes[i].GetAttribute("id").ToString() + "\r\n");
            
        }
        [Test]
        public void SwitchToIframeByIndex()
        {
            try
            {

                Console.WriteLine("✔ Navegando a http://toolsqa.wpengine.com/iframe-practice-page/");
                Chrome.Navigate().GoToUrl("http://toolsqa.wpengine.com/iframe-practice-page/");

                Console.WriteLine("✔ Seleccionando IFRAME 0");
                Chrome.SwitchTo().Frame(0);

                Console.WriteLine("✔ Seleccionando FirstName Input in IFRAME 0");
                IWebElement FirstName = Chrome.FindElement(By.XPath("//*[@id='content']/div[1]/div/div/div/div[2]/div/form/fieldset/div[8]/input"));

                Console.WriteLine("✔ Seleccionando LastName Input in IFRAME 0");
                IWebElement LastName = Chrome.FindElement(By.XPath("//*[@id='content']/div[1]/div/div/div/div[2]/div/form/fieldset/div[11]/input"));

                Console.WriteLine("✔ Enviando texto a FirstName Input in IFRAME 0");
                FirstName.SendKeys("Rafael");

                Console.WriteLine("✔ Enviando texto a LastName Input in IFRAME 0");
                LastName.SendKeys("Rivera");

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Debug.WriteLine("✘Ha ocurrido un error\r\n" + ex.Message);
            }

        }
        [Test]
        public void SwitchToIframeByName()
        {
            try
            {

                Console.WriteLine("✔ Navegando a http://toolsqa.wpengine.com/iframe-practice-page/");
                Chrome.Navigate().GoToUrl("http://toolsqa.wpengine.com/iframe-practice-page/");

                Console.WriteLine("✔ Seleccionando IFRAME 0");
                Chrome.SwitchTo().Frame("iframe1");

                Console.WriteLine("✔ Seleccionando FirstName Input in IFRAME 0");
                IWebElement FirstName = Chrome.FindElement(By.XPath("//*[@id='content']/div[1]/div/div/div/div[2]/div/form/fieldset/div[8]/input"));

                Console.WriteLine("✔ Seleccionando LastName Input in IFRAME 0");
                IWebElement LastName = Chrome.FindElement(By.XPath("//*[@id='content']/div[1]/div/div/div/div[2]/div/form/fieldset/div[11]/input"));

                Console.WriteLine("✔ Enviando texto a FirstName Input in IFRAME 0");
                FirstName.SendKeys("Rafael");

                Console.WriteLine("✔ Enviando texto a LastName Input in IFRAME 0");
                LastName.SendKeys("Rivera");

            }
            catch (Exception ex)
            {
                Console.WriteLine("✘Ha ocurrido un error\r\n" + ex.Message);
            }

        }
        [TearDown]
        public void CloseBrowser()
        {
            Chrome.Quit();
        }
    }
}
