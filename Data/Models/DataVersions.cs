using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGuideService.Data.Models
{
    /*В последний момент увидел рекомендацию по Dto объектам, и понял что скорее всего сделал неправильно
      поэтому ничего умнее не придумал как копировать данные модели для работы с сервисом
    */
    public class DataVersions //Версии данных
    {
        /*Идентификатор*/
        public int id { get; set; }
        /*Наименование*/
        public string Name { get; set; }
        /*Тип версии*/
        public string VersionType { get; set; }
    }
}
