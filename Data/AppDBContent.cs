using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiDataService.Data.Models;
using WebApiGuideService.Data.Models;

namespace WebApiGuideService.Data
{
    /*класс для работы с базой данных сделан по такому же принципу как и в сервисе справочников*/
    public class AppDBContent: DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {
        }

        public DbSet<DataIntersection> dataIntersection { get; set; } // содержит одну таблицу, которая хранит данные на основе пересечения справочников
    }
}
