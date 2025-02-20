using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MvcProjectCamp.DataAccessLayer.Abstract
{
    public interface ICategoryDal : IRepositoryDal<Category>
    {
        string GetCategoryWithMostTitles();
        int CountTrueOrFalse();
    }
}
