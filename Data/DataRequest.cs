using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDataService.Data.Interfaces;
using WebApiGuideService.Data.Models;

namespace WebApiDataService
{
    /*класс реализации интерфейса получения данных из сервиса справочников
     не знаю правильно ли сделал, но нашел библиотеку RestSharp
     и использовал ее для реализации запросов
     */
    public class DataRequest : IDataRequest
    {
        public async Task<List<ConstructionObjects>> getConstructions()
        {
            var client = new RestClient($"https://localhost:44386/api/guides/constructions"); //создаю клиента и указываю ему адрес для запроса
            var request = new RestRequest(Method.GET);//устанавливаем соответствующий метод запроса
            IRestResponse response = await client.ExecuteAsync(request);// осуществляем запрос
            if (response.IsSuccessful) //проверяем если статус 200, то
            {
                var content = JsonConvert.DeserializeObject<List<ConstructionObjects>>(response.Content); //получаем контент результата
                                                                                                            //(он будет в качестве json строки) и конвертируем его под соответствующий нам тип
                return content;// возвращаем полный список объектов строительства, 
            }
            return null; //если запрос неуспешен, возвращаем пустое значение
        }

        /*тоже самое  по версии данных*/
        public async Task<List<DataVersions>> getVersions()
        {
            var client = new RestClient($"https://localhost:44386/api/guides/versions");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var content = JsonConvert.DeserializeObject<List<DataVersions>>(response.Content);
                return content;
            }
            return null;
        }


    }
}
