using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class RepositoryBase
    {
        protected static DatabaseContext context;

        protected RepositoryBase()
        {
            CreateContext();
        }

        public static void CreateContext() // db nesnesi yalnızca bir kere uretilecek(singleton pattern). daha once uretilmişse aynısı döndürülecek.
        {
            if (context == null)
            {
                context = new DatabaseContext();
            }
        }
    }
}
