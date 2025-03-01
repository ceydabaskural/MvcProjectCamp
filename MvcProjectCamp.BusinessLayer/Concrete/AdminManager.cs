﻿using MvcProjectCamp.BusinessLayer.Abstract;
using MvcProjectCamp.DataAccessLayer.Abstract;
using MvcProjectCamp.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjectCamp.BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void TDelete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public Admin TGetById(int id)
        {
            return _adminDal.Get(x => x.AdminId == id);
        }

        public List<Admin> TGetList()
        {
            return _adminDal.List();
        }

        public void TInsert(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void TUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
