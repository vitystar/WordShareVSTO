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

        public override bool EditEntity(ImageTemplet entity) => EditEntityWithSelect(w => w.ID == entity.ID, (temp) =>
        {
            temp.Accessibility = entity.Accessibility;
            temp.FilePath = entity.FilePath;
            temp.ImagePath = entity.ImagePath;
            temp.ModTime = DateTime.Now;
            temp.Organization = entity.Organization;
            temp.TempletIntroduction = entity.TempletIntroduction;
            temp.TempletName = entity.TempletName;
            return temp;
        });
    }
}