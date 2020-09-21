using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDataService.Data.Models;
using WebApiGuideService.Data.Models;

namespace WebApiGuideService.Data
{
    /*класс для инициализации данных в данном сервисе, присваиваем значения и сохраняем в БД*/
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            Random rnd = new Random();
            if (!content.dataIntersection.Any())
            {
                content.dataIntersection.AddRange
                    (
                        new DataIntersection { Objectindex = 1, Versionindex = 1, Intersection = 4/*rnd.Next(1, 9)*/ },
                        new DataIntersection { Objectindex = 1, Versionindex = 2, Intersection = 8/*rnd.Next(1, 9)*/ },
                        new DataIntersection { Objectindex = 1, Versionindex = 3, Intersection = 3/*rnd.Next(1, 9)*/ },
                        new DataIntersection { Objectindex = 2, Versionindex = 1, Intersection = 2/*rnd.Next(1, 9)*/ },
                        new DataIntersection { Objectindex = 2, Versionindex = 2, Intersection = 9/*rnd.Next(1, 9)*/ },
                        new DataIntersection { Objectindex = 2, Versionindex = 3, Intersection = 5/*rnd.Next(1, 9)*/ },
                        new DataIntersection { Objectindex = 3, Versionindex = 1, Intersection = 6/*rnd.Next(1, 9)*/ },
                        new DataIntersection { Objectindex = 3, Versionindex = 2, Intersection = 1/*rnd.Next(1, 9)*/ },
                        new DataIntersection { Objectindex = 3, Versionindex = 3, Intersection = 7/*rnd.Next(1, 9)*/ }
                    );
            }

            content.SaveChanges();
        }

        

    }
}
