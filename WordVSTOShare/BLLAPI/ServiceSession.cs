using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAPI
{
    /// <summary>
    /// 业务服务类
    /// </summary>
    public class ServiceSession : IServiceSession
    {
        private IUserInfoService _userInfoService;
        private IOrganizationInfoService _organizationInfoService;
        private IWordTempletService _wordTempletService;
        private IExcelService _excelService;
        private IPPTService _pptService;
        private IImageService _imageService;
        private IAudioService _audioService;
        private IVideoService _videoService;

        public IUserInfoService UserInfoService
        {
            get
            {
                if (_userInfoService == null)
                    _userInfoService = new UserInfoService();
                return _userInfoService;
            }
        }

        public IOrganizationInfoService OrganizationInfoService
        {
            get
            {
                if (_organizationInfoService == null)
                    _organizationInfoService = new OrganizationInfoService();
                return _organizationInfoService;
            }
        }

        public IWordTempletService WordTempletService
        {
            get
            {
                if (_wordTempletService == null)
                    _wordTempletService = new WordTempletService();
                return _wordTempletService;
            }
        }

        public IExcelService ExcelService
        {
            get
            {
                if (_excelService == null)
                    _excelService = new ExcelService();
                return _excelService;
            }
        }

        public IPPTService PPTService
        {
            get
            {
                if (_pptService == null)
                    _pptService = new PPTService();
                return _pptService;
            }
        }

        public IImageService ImageService
        {
            get
            {
                if (_imageService == null)
                    _imageService = new ImageService();
                return _imageService;
            }
        }

        public IAudioService AudioService
        {
            get
            {
                if (_audioService == null)
                    _audioService = new AudioService();
                return _audioService;
            }
        }

        public IVideoService VideoService
        {
            get
            {
                if (_videoService == null)
                    _videoService = new VideoService();
                return _videoService;
            }
        }
    }
}
