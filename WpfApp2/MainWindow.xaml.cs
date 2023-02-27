using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
{

        static HttpClient? httpclient;


        public MainWindow()
        {
            InitializeComponent();
            httpclient = new HttpClient(); // Создание экзземпляра для обмена данных

            // Получение данных Get-метод
            var response = httpclient.GetAsync("https://localhost:7286/WeatherForecast").Result; //Http запрос (get)

            var responseContent = response.Content.ReadAsStringAsync().Result;
            resultText.Content = responseContent.Replace("},{", "},\n{");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получение данных Get-метод
            var response = httpclient.GetAsync("https://localhost:7286/WeatherForecast").Result; //Http запрос (get)

            var responseContent = response.Content.ReadAsStringAsync().Result;
            resultText.Content = responseContent.Replace("},{","},\n{");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Обращаемся к каждому текстовому полю для получения следующих значений:
            string id = idTextBox.Text;                 // Для получения значения id
            string date = dateTextBox.Text;             // Для получения значения даты (date)
            string degree = degreeTextBox.Text;         // Для получения значения градусов (degree)
            string location = locationTextBox.Text;     // Для получения значения местоположения (location)


            string newRecord =
                "{ \"id\":" + id +
                ", \"data\": \"" + date + "\"" +
                ", \"degree\": " + degree +
                ", \"location\": \"" + location + "\"}";

            var stringContent = new StringContent(newRecord, Encoding.UTF8, "application/json");

            var response = httpclient.PostAsync("https://localhost:7286/WeatherForecast", stringContent).Result;

            MessageBox.Show(response.Content.ReadAsStringAsync().Result.ToString());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Обращаемся к каждому текстовому полю для получения следующих значений:
            string id = idTextBox.Text;                         //Для получения значения id
            string date = dateTextBox.Text;                     //Для получения значения даты (date)
            string degree = degreeTextBox.Text;                 //Для получения значения градусов (degree)
            string location =locationTextBox.Text;              //Для получения значения местоположения (location)

            string newRecord =
                "{ \"id\":" + id +
                ", \"data\": \"" + date + "\"" +
                ", \"degree\": " + degree +
                ", \"location\": \"" + location + "\"}";


            var stringContent = new StringContent(newRecord, Encoding.UTF8, "application/json");

            var response = httpclient.PutAsync("https://localhost:7286/WeatherForecast", stringContent).Result;

            MessageBox.Show(response.StatusCode.ToString());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string id = idTextBox.Text; //Обращаемся к текстовому полю для получения значения id

            var response = httpclient.DeleteAsync($"https://localhost:7286/WeatherForecast?id={id}").Result;

            MessageBox.Show(response.StatusCode.ToString());
        }

    }
}
