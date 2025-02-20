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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageDal;

        public ImageFileManager(IImageFileDal imageDal)
        {
            _imageDal = imageDal;
        }
        public List<ImageFile> TGetList()
        {
            return _imageDal.List();
        }
    }
}
