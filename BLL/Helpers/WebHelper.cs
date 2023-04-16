using DAL.MasterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helpers
{
    public class WebHelper
    {
        MyDbContext context = new MyDbContext();

        public bool isSiteDisable()
        {
            //var result = context.Users.OrderByDescending(p => p.MetaID).FirstOrDefault();
            return true;
        }
    }
}
