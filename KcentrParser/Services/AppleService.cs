using KcentrParser.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace KcentrParser.Services;

public class AppleService : IAppleService
{
    private const string Url = "https://kcentr.ru/search/smartfony/?q=айфон";
    
    public List<Apple> GetAllApples()
    {
        List<Apple> apples = new List<Apple>();

        var options = new ChromeOptions();
        options.AddArguments(new List<string>() { "headless", "disable-gpu" });

        var driver = new ChromeDriver(options);
        driver.Navigate().GoToUrl(Url);

        var applesElements = driver.FindElements(By.ClassName("a5753"));

        foreach (var element in applesElements)
        {
            string name = element.FindElement(By.ClassName("_38940"))
                .FindElement(By.TagName("a"))
                .GetAttribute("innerText");
            string link = element.FindElement(By.ClassName("_38940"))
                .FindElement(By.TagName("a"))
                .GetAttribute("href");
            string price = element.FindElement(By.ClassName("_4eb93"))
                .GetAttribute("innerText");

            apples.Add(new Apple(name, link, price));
        }

        return apples;
    }
}