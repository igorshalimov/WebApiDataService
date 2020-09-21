using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGuideService.Data.Models;

namespace WebApiDataService.Data.Models
{
    /*модель хранения данных на пересечении справочников*/
    public class DataIntersection
    {
        public int id { get; set; } //идентификатор пересечения данных
        public int Objectindex { get; set; }//индекс конктретного объекта строительства
        public int Versionindex { get; set; }// индекс конкретной версии данных
        public int Intersection { get; set; }//данное число на пересечении объекта и версии
    }
}
