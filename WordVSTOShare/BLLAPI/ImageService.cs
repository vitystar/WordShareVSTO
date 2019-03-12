using DALAPI;
using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAPI
{
    public class ImageService : BaseService<ImageTemplet>, IImageService
    {
        public ImageService() : base(DBSessionFactory.DBSession.ImageDal)
        {
        }
    }
}
