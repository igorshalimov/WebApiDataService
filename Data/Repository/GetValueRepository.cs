using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDataService.Data.Interfaces;
using WebApiDataService.Data.Models;
using WebApiGuideService.Data;

namespace WebApiDataService.Data.Repository
{
    /*класс реализации интерфейса получения данных из БД, все на подобии также как и в сервисе спарвочников*/
    public class GetValueRepository : IGetValue
    {
        private readonly AppDBContent appDbContent;

        public GetValueRepository(AppDBContent _appdbcontent)
        {
            appDbContent = _appdbcontent;
        }

        public IEnumerable<DataIntersection> getValue => appDbContent.dataIntersection; // достаем данные из таблицы пересечений данных
    }
}
