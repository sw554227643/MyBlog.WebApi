using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> EditAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> QueryAsync();
        /// <summary>
        /// 自定义条件查询
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> expression);
        
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="total">返回到前端的总数</param>
        /// <returns></returns>
        Task<List<TEntity>> QueryAsync(int page, int size,RefAsync<int> total);

        /// <summary>
        /// 自定义分页查询
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> expression, int page, int size, RefAsync<int> total);
        
    }
}
