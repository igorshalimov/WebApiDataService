using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGuideService.Data.Models;

namespace WebApiDataService.Data.Interfaces
{
    /*Интерфейс получения данных из сервиса справочников */
    public interface IDataRequest
    {
        public Task<List<ConstructionObjects>> getConstructions(); // получить объекты строительства
        public Task<List<DataVersions>> getVersions();// получить версии данных

    }
}
