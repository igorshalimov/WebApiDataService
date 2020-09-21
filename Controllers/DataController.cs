using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiDataService.Data.Interfaces;
using WebApiDataService.ViewModels;
using WebApiGuideService.Data.Models;


namespace WebApiDataService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IGetValue _values; //экземпляры интерфейсов для получения значений и запросов в сервис справочников с целью получения всех данных по справочникам
        private readonly IDataRequest _dataRequests;
        private List<DataViewModel> dataviews=new List<DataViewModel>(); //View модель для отображения результата

        /*получаем данные из контейнера зависимостей*/
        public DataController(IGetValue values, IDataRequest dataRequest)
        {
            _values = values;
            _dataRequests = dataRequest;

        }
        // метод по умолчанию
        //адрес : localhost:<port>/api/data
        //выдает данные на основе запроса, в качестве параметра -  первый объект строительства
        [HttpGet]
        public ActionResult Get()
        {
            dataviews = new List<DataViewModel>();
            ConstructionObjects construct = _dataRequests.getConstructions().Result.FirstOrDefault();
            var dataVersions = _dataRequests.getVersions().Result;
            foreach (var vers in dataVersions)
            {
                dataviews.Add
                (
                    new DataViewModel
                    {
                        ObjectName = construct.Name,
                        ObjectCode = construct.ObjectCode,
                        VersionName = vers.Name,
                        DataIntersection = _values.getValue.ToList().Find(di => di.Objectindex == construct.id && di.Versionindex == vers.id).Intersection
                    }
                );
            }
            return this.Ok(dataviews);
        }


        // 1 основной метод
        //адрес : localhost:<port>/api/data/object=ObjectId => выдает данные на основе запроса, в качестве параметра -  объект строительства, указаный по индексу ObjectId={1,2,3}
        [HttpGet("Object={ObjectId}")]
        public ActionResult GetByObject(int ObjectId)
        {
            dataviews = new List<DataViewModel>();
            ConstructionObjects construct = _dataRequests.getConstructions().Result.Find(o => o.id == ObjectId);
            var dataVersions = _dataRequests.getVersions().Result;
            foreach (var vers in dataVersions) //получаем все версии и соответсвенно все значения, которые соответствуют данному объекту
            {
                dataviews.Add
                (
                    new DataViewModel
                    {
                        ObjectName = construct.Name,
                        ObjectCode = construct.ObjectCode,
                        VersionName = vers.Name,
                        DataIntersection = _values.getValue.ToList().Find(di => di.Objectindex == construct.id && di.Versionindex == vers.id).Intersection
                    }
                );
            }
            return this.Ok(dataviews);
        }

        // 2 основной метод
        //адрес : localhost:<port>/api/data/version=VersionId => выдает данные на основе запроса, в качестве параметра -  версия данных, указаная по индексу VersionId={1,2,3}
        [HttpGet("Version={VersionId}")]
        public ActionResult GetByVersion(int VersionId)
        {
            dataviews = new List<DataViewModel>();
            DataVersions version = _dataRequests.getVersions().Result.Find(o => o.id == VersionId);
            var constructionObjcts = _dataRequests.getConstructions().Result;
            foreach (var obj in constructionObjcts) //получаем все объекты и соответсвенно все значения, которые соответствуют данной версии
            {
                dataviews.Add
                (
                    new DataViewModel
                    {
                        ObjectName = obj.Name,
                        ObjectCode = obj.ObjectCode,
                        VersionName = version.Name,
                        DataIntersection = _values.getValue.ToList().Find(di => di.Objectindex == obj.id && di.Versionindex == version.id).Intersection
                    }
                );
            }
            return this.Ok(dataviews);
        }

    }
}
