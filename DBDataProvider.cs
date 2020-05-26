using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class DBDataProvider : IDataProvider
    {
        public DBDataProvider(Context context)
        {
            Context = context;
        }

        public Context Context { get;private set; }

        public int GetData()
        {
            return 1;
            return Context.Models.FirstOrDefault().Amount;
        }
    }
}
