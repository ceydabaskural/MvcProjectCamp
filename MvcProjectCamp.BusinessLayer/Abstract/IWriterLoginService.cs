using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.Abstract
{
    public interface IWriteLoginService
    {
        Writer TGetWriter(string username, string password);
    }
}
