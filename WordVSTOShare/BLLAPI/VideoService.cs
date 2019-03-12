using DALAPI;
using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAPI
{
    public class VideoService : BaseService<VideoTemplet>, IVideoService
    {
        public VideoService() : base(DBSessionFactory.DBSession.VideoDal)
        {
        }
    }
}
