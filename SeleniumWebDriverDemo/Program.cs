using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

class Program
{
    static void Main()
    {
        // ChromeDriver servisi oluştur
        ChromeDriverService service = ChromeDriverService.CreateDefaultService();

        // ChromeOptions'u ayarla
        ChromeOptions options = new ChromeOptions();

        // İsteğe bağlı olarak Chrome ayarlarını burada ekleyebilirsiniz
        // options.AddArgument("--headless"); // Örneğin, başsız modu etkinleştirmek için

        // ChromeDriver'ı başlat ve servis ve seçenekleri kullanarak özelleştir
        IWebDriver driver = new ChromeDriver(service, options);

        try
        {
            // Google'a git
            driver.Navigate().GoToUrl("https://www.twitter.com");

            // Sayfa başlığını alana kadar bekleyin
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => !string.IsNullOrEmpty(d.Title));

            // Sayfa başlığını al
            string pageTitle = driver.Title;
            Console.WriteLine("Sayfa Başlığı: " + pageTitle);
        }
        catch (NoSuchWindowException ex)
        {
            // Pencere kapalıysa ilgili hata mesajını yazdırabilirsiniz
            Console.WriteLine("Hata: " + ex.Message);
        }
        finally
        {
            // Tarayıcıyı kapat
            driver.Quit();
        }
    }
}
