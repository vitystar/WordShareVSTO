using DALAPI;
using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAPI
{
    public class AudioService : BaseService<AudioTemplet>, IAudioService
    {
        public AudioService() : base(DBSessionFactory.DBSession.AudioDal)
        {
        }
    }
}
