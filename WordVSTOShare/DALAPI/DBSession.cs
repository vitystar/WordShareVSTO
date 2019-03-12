using ModelAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALAPI
{
    /// <summary>
    /// 封装数据操作类
    /// </summary>
    public class DBSession : IDBSession
    {


        private IUserInfoDal _userInfoDal;
        private IOrganizationInfoDal _organizationInfoDal;
        private IWordTempletDal _wordTempletDal;
        private IPPTDal _pptDal;
        private IExcelDal _excelDal;
        private IImageDal _imageDal;
        private IAudioDal _audioDal;
        private IVideoDal _videoDal;

        /// <summary>
        /// 组织数据操作对象
        /// </summary>
        public IOrganizationInfoDal OrganizationInfoDal
        {
            get
            {
                if (_organizationInfoDal == null)
                {
                    _organizationInfoDal = new OrganizationInfoDal();
                    _userInfoDal.CreateDataBase();
                }
                return _organizationInfoDal;
            }
        }

        /// <summary>
        /// 模板数据操作对象
        /// </summary>
        public IWordTempletDal WordTempletDal
        {
            get
            {
                if (_wordTempletDal == null)
                {
                    _wordTempletDal = new WordTempletDal();
                    _wordTempletDal.CreateDataBase();
                }
                return _wordTempletDal;
            }
        }

        /// <summary>
        /// 用户数据操作对象
        /// </summary>
        public IUserInfoDal UserInfoDal
        {
            get
            {
                if (_userInfoDal == null)
                {
                    _userInfoDal = new UserInfoDal();
                    _userInfoDal.CreateDataBase();
                }
                return _userInfoDal;
            }
        }

        /// <summary>
        /// excel模板操作对象
        /// </summary>
        public IExcelDal ExcelDal
        {
            get
            {
                if (_excelDal == null)
                {
                    _excelDal = new ExcelDal();
                    _excelDal.CreateDataBase();
                }
                return _excelDal;
            }
        }

        /// <summary>
        /// PPT模板操作对象
        /// </summary>
        public IPPTDal PPTDal
        {
            get
            {
                if (_pptDal == null)
                {
                    _pptDal = new PPTDal();
                    _pptDal.CreateDataBase();
                }
                return _pptDal;
            }
        }

        /// <summary>
        /// 图片素材操作对象
        /// </summary>
        public IImageDal ImageDal
        {
            get
            {
                if (_imageDal == null)
                {
                    _imageDal = new ImageDal();
                    _imageDal.CreateDataBase();
                }
                return _imageDal;
            }
        }

        /// <summary>
        /// 音频素材操作对象
        /// </summary>
        public IAudioDal AudioDal
        {
            get
            {
                if (_audioDal == null)
                {
                    _audioDal = new AudioDal();
                    _audioDal.CreateDataBase();
                }
                return _audioDal;
            }
        }

        /// <summary>
        /// 视频素材操作对象
        /// </summary>
        public IVideoDal VideoDal
        {
            get
            {
                if (_videoDal == null)
                {
                    _videoDal = new VideoDal();
                    _videoDal.CreateDataBase();
                }
                return _videoDal;
            }
        }
    }
}
