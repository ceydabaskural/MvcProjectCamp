using MvcProjectCamp.EntityLayer;
using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.Abstract
{
    public interface ISkillService
    {
        List<Skill> TGetList();
        void TInsert(Skill skill);
        void TUpdate(Skill skill);
        void TDelete(Skill skill);
        Skill TGetById(int id);
    }
}
