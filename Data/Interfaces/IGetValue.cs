using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDataService.Data.Models;

namespace WebApiDataService.Data.Interfaces
{
    /*интерфейс получения данных на основе пересечения*/
    public interface IGetValue
    {
       public IEnumerable<DataIntersection> getValue { get; } //метод получения данных
    }
}
