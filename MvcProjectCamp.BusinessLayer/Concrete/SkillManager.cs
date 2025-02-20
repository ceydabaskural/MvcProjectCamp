using MvcProjectCamp.BusinessLayer.Abstract;
using MvcProjectCamp.DataAccessLayer.Abstract;
using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.Concrete
{
    public class SkillManager : ISkillService
    {
       ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public void TDelete(Skill skill)
        {
            throw new NotImplementedException();
        }

        public Skill TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Skill> TGetList()
        {
            return _skillDal.List();
        }

        public void TInsert(Skill skill)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Skill skill)
        {
            throw new NotImplementedException();
        }
    }
}
