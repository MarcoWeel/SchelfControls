using ShelfControls.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShelfControls
{
    public class Controls : IControls
    {
        private HttpClient _httpClient;

        public Controls(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<bool> TurnOn()
        {
            try
            {
                using HttpResponseMessage response = await _httpClient.GetAsync("http://192.168.2.41/on");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return false;
            }
        }

        public async Task<bool> TurnOff()
        {
            try
            {
                using HttpResponseMessage response = await _httpClient.GetAsync("http://192.168.2.41/off");
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return false;
            }
        }

        public async Task<bool> ChangeColor(int red, int green, int blue, int white)
        {
            try
            {
                string requestString = $"http://192.168.2.41/newcolor?RED={red}&GREEN={green}&BLUE={blue}&WHITE={white}";
                Console.WriteLine(requestString);
                using HttpResponseMessage response = await _httpClient.GetAsync(requestString);
                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return false;
            }
        }
    }
}
