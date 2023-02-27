using System.Net.Http;
using System.Text;


namespace ConsoleClientApi
{
    internal class Program
    {
        static HttpClient? httpClient;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            httpClient = new HttpClient();

            var response = await httpClient.GetAsync("https://localhost:7286/WeatherForecast");

            Console.WriteLine(response);

            Console.WriteLine(await response.Content.ReadAsStringAsync());

            // добавление данных Post-метод

            string newRecord = "{\r\n \"id\": 5,\r\n \"data\": \"01/02/2002\",\r\n \"degree\": -30,\r\n \"location\": \"Самара\"\r\n}";

            var stringContent = new StringContent(newRecord, Encoding.UTF8, "application/json");

            response = await httpClient.PostAsync("https://localhost:7286/WeatherForecast", stringContent);

            Console.WriteLine(response);

            // обновление данных Put-метод

            string updateRecord = "{\r\n \"id\": 5,\r\n \"data\": \"01/02/2002\",\r\n \"degree\": -30,\r\n \"location\": \"Самара\"\r\n}";

            stringContent = new StringContent(updateRecord, Encoding.UTF8, "application/json");

            response = await httpClient.PutAsync("https://localhost:7286/WeatherForecast", stringContent);

            Console.WriteLine(response);


            // повторное получение данных Get-метод 

            response = await httpClient.GetAsync("https://localhost:7286/WeatherForecast");

            Console.WriteLine(response);

            Console.WriteLine(await response.Content.ReadAsStringAsync());

            // удаление данных DELETE-метод 

            response = await httpClient.DeleteAsync("https://localhost:7286/WeatherForecast?id=6");

            Console.WriteLine(response);

            // повторное получение данных Get-метод

            response = await httpClient.GetAsync("https://localhost:7286/WeatherForecast");

            Console.WriteLine(response);

            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}


