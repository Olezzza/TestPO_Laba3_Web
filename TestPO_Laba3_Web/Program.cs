using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

class Program
{
    static readonly IWebDriver _driver = new ChromeDriver();

    static void Main()
    {
        _driver.Navigate().GoToUrl(@"http://www.google.com");
        string desired_url = "https://en.wikipedia.org/wiki/NUnit";

        IWebElement search = _driver.FindElement(By.ClassName("gLFyf"));

        search.SendKeys("unit testing");
        search.SendKeys(Keys.Enter);

        //IWebElement searchWikipedia = _driver.FindElement(By.ClassName("DKV0Md"));
        IWebElement searchWikipedia = _driver.FindElement(By.PartialLinkText("https://en.wikipedia.org"));
        searchWikipedia.Click();

        IWebElement searchNUnit = _driver.FindElement(By.Name("search"));

        searchNUnit.SendKeys("NUnit");
        searchNUnit.Click();
        System.Threading.Thread.Sleep(2000);
        searchNUnit.SendKeys(Keys.Down);
        searchNUnit.SendKeys(Keys.Enter);

        if (desired_url == _driver.Url)
        {
            Console.WriteLine("First test passed");
        }

        IWebElement searchRUWikipedia = _driver.FindElement(By.ClassName("interwiki-ru"));

        if (searchRUWikipedia != null)
        {
            Console.WriteLine("Second test passed!");
        }
    }
}