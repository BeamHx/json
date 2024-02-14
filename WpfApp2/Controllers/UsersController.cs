using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp2.Model
{
    public class UsersController
    {
        public static List<Users> GetUser(string login, string password)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = $"{Manager.RootUrl}login/?login={login}&password={password}";
                    Console.WriteLine(url);
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var content = response.Content.ReadAsStringAsync();
                        var answer = JsonConvert.DeserializeObject <Responce<List<Users>>>(content.Result);
                        return answer.data;
                    }
                    else { return null; }
                }
            }
            catch { throw new Exception("Ошибка подключения к серверу"); }
        }

    }
}
