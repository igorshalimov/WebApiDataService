using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDataService.ViewModels
{
    /*модель для получения  отображения данных на пересечении справочников*/
    public class DataViewModel
    {
        public string ObjectName { get; set; }//показывается наименование объекта строительства
        public string ObjectCode { get; set; }//показывается его код
        public string VersionName { get; set; }//показывается соответствующая версия данному объекту
        public int DataIntersection { get; set; }//показывается полученное значение на основе пересечения данных
    }
}
