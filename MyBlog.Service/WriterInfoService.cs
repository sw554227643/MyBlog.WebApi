using MyBlog.IRepository;
using MyBlog.IService;
using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service
{
    public class WriterInfoService:BaseService<WriterInfo>,IWriterInfoService
    {
        private readonly IWriterInfoRepository iWriterInfoRepository;

        public WriterInfoService(IWriterInfoRepository iWriterInfoRepository)
        {
            this.iWriterInfoRepository = iWriterInfoRepository;
            base._iBaseRepository = iWriterInfoRepository;
        }

    }
}
