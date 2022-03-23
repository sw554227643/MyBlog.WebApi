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
    public class TypeInfoService:BaseService<TypeInfo>,ITypeInfoService
    {
        private readonly ITypeInfoRepository itypeInfoRepository;

        public TypeInfoService(ITypeInfoRepository itypeInfoRepository)
        {
            this.itypeInfoRepository = itypeInfoRepository;
            base._iBaseRepository = itypeInfoRepository;
        }
    }
}
