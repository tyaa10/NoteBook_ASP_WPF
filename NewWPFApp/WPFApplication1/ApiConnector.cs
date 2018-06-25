using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WPFApplication1.Models;
using System.Collections.ObjectModel;

namespace WPFApplication1
{

   public class ApiConnector
    {
        //Наш статический метод, выполняющийся асинхронно, получающий данные из сети
        public static async void PostData(ObservableCollection<State> _states, String _urlParamsString, String _jsonString)
        {

            //Готовим строку - пустой объект json для отправки на сервер
            string emptyJson = "{}";
            if (_jsonString == "")
            {
                _jsonString = emptyJson;
            }

            //Создаем современную версию объекта для Http-запросов к серверу
            using (var client = new HttpClient())
            {
                Console.WriteLine(_jsonString);
                //Делаем пост-запрос на сервер по адресу, взятому из веб-проекта
                String controllerName = _urlParamsString.Contains("state-del") ? "DoActionModel" : "DoAction";
                var response = await client.PostAsync(
                    "http://localhost:49245/Default/" + controllerName + "?" + _urlParamsString,
                     new StringContent(_jsonString, Encoding.UTF8, "application/json"));
                Console.WriteLine("http://localhost:49245/Default/DoAction?" + _urlParamsString);
                //Ждем код результата
                response.EnsureSuccessStatusCode();
                //Стримом читаем строку из ответа
                string content = await response.Content.ReadAsStringAsync();

                if (_urlParamsString.Contains("state-add"))
                {
                    //Разбираем строку 
                    NoteBookAddStateResult result = JsonConvert.DeserializeObject<NoteBookAddStateResult>(content);
                    if (result.Add == "ok")
                    {
                        ApiConnector.PostData(_states, "action=states","");
                    }
                    else {
                        
                    }
                }
                else if (_urlParamsString.Contains("states") && !_urlParamsString.Contains("state-del")) {
                    //Разбираем строку 
                    NoteBookResult result = JsonConvert.DeserializeObject<NoteBookResult>(content);

                    foreach (var item in result.PagesData)
                    {
                        _states.Add(item);
                        Console.WriteLine($"id = {item.Id}; name = {item.Name}");
                    }
                }
                else if (_urlParamsString.Contains("state-del"))
                {
                    try
                    {
                        //NoteBookErrorStateResult result = JsonConvert.DeserializeObject<NoteBookErrorStateResult>(content);
                        NoteBookDelStateResult result = JsonConvert.DeserializeObject<NoteBookDelStateResult>(content);
                        ApiConnector.PostData(_states, "action=states", "");
                        Console.WriteLine(result.Deleted);
                        //Console.WriteLine(result.Error);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
    }
}
