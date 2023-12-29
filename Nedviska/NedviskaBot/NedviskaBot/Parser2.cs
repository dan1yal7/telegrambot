//using AngleSharp;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NedviskaBot
//{
//    public class Parser2
//    {

//        public static async Task<string> ParseWebsiteAsync()

//        {
//            try
//            {

//                using (var driver = new ChromeDriver())
//                {
//                    driver.Navigate().GoToUrl("");

//                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
//                    wait.Until(d => d.Url == "");

//                    string htmlContent = driver.PageSource;
//                    var config = Configuration.Default.WithDefaultLoader();
//                    var context = BrowsingContext.New(config);
//                    var document = context.OpenAsync(req => req.Content(htmlContent)).Result;



//                    var titles = document.QuerySelectorAll(".vacancy-card");


//                    if (titles != null)
//                    {
//                        StringBuilder result = new StringBuilder();
//                        result.AppendLine("Объявления о вакансих:");


//                        int maxTotalLength = 1500;
//                        foreach (var title in titles)
//                        {
//                            string announcement = title.TextContent.Trim();

//                            // Проверка общей длины сообщения перед добавлением
//                            if (result.Length + announcement.Length <= maxTotalLength)
//                            {
//                                result.AppendLine(announcement);
//                            }
//                            else
//                            {
//                                // Прекращаем добавление объявлений, так как превышен лимит длины сообщения
//                                break;
//                            }

//                        }

//                        //Console.WriteLine($"Length of the message: {result.Length}"); //чтобы увидеть кол-во длины в консоли для изменение или проверки

//                        return result.ToString();


//                    }
//                    else
//                    {
//                        return "Не удалось найти объявления о вакансиях.";
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                return $"Произошла ошибка при поиске.Попробуйте еще раз: {ex.Message}";
//            }
//        }
//    }
//}












    