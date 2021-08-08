using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using IGym.Interface.IRepository;
using Microsoft.EntityFrameworkCore;

namespace IGym.EFRepository.Impl
{
    public class EFDataRepository : IDataRepository
    {
        private readonly EfDbContext _context;
        public EFDataRepository(EfDbContext context)
        {
            this._context = context;
        }

        #region Query
        /// <summary>
        /// 通过Id得到实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find<T>(object id) where T : class
        {
            return this._context.Set<T>().Find(id);
        }

        /// <summary>
        /// 这才是合理的做法，上端给条件，这里查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <returns></returns>
        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            return this._context.Set<T>().Where<T>(funcWhere);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="funcWhere">查询条件表达式目录树</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="funcOrderby">按什么字段排序</param>
        /// <param name="isAsc">升序还是降序</param>
        /// <returns></returns>
        public IQueryable<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOrderby, bool isAsc = true) where T : class
        {
            return null;
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public T Insert<T>(T t) where T : class
        {
            this._context.Set<T>().Add(t);
            return t;
        }

        /// <summary>
        /// 插入集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        /// <returns></returns>
        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            this._context.Set<T>().AddRange(tList);
            return tList;
        }
        #endregion

        #region Update
        /// <summary>
        /// 是没有实现查询，直接更新的,需要Attach和State
        /// 
        /// 如果是已经在context，只能再封装一个(在具体的service)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Update<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");

            this._context.Set<T>().Attach(t);//将数据附加到上下文，支持实体修改和新实体，重置为UnChanged
            this._context.Entry<T>(t).State = EntityState.Modified;//全字段更新
        }

        /// <summary>
        /// 集合修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            foreach (var t in tList)
            {
                this._context.Set<T>().Attach(t);
                this._context.Entry<T>(t).State = EntityState.Modified;
            }
        }

        /// <summary>
        /// 更新数据，指定更新哪些列，哪怕有些列值发生了变化，没有指定列也不能修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void UpdateSpecifyFiled<T>(T t, List<string> filedList) where T : class
        {
            this._context.Set<T>().Attach(t);//将数据附加到上下文
            foreach (var filed in filedList)
            {
                this._context.Entry<T>(t).Property(filed).IsModified = true;//指定某字段被改过
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// 先附加 再删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void Delete<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");
            this._context.Set<T>().Attach(t);
            this._context.Set<T>().Remove(t);
        }

        /// <summary>
        /// 还可以增加非即时commit版本的，
        /// 做成protected
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        public void Delete<T>(int Id) where T : class
        {
            T t = this.Find<T>(Id);//也可以附加
            if (t == null) throw new Exception("t is null");
            this._context.Set<T>().Remove(t);
        }

        /// <summary>
        /// 删除集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        public void Delete<T>(IEnumerable<T> tList) where T : class
        {
            foreach (var t in tList)
            {
                this._context.Set<T>().Attach(t);
            }
            this._context.Set<T>().RemoveRange(tList);
        }
        #endregion

        #region Other
        /// <summary>
        /// 一次性提交
        /// </summary>
        public void Commit()
        {
            this._context.SaveChanges();
        }

        /// <summary>
        /// sql语句查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IQueryable<T> ExcuteQuery<T>(string sql, object[] parameters) where T : class
        {
            //return this._context.Database.SqlQuery<T>(sql, parameters).AsQueryable();
            return null;
        }

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        public void Excute<T>(string sql, object[] parameters) where T : class
        {
            //DbContextTransaction trans = null;
            //try
            //{
            //    trans = this._context.Database.BeginTransaction();
            //    this._context.Database.ExecuteSqlCommand(sql, parameters);
            //    trans.Commit();
            //}
            //catch (Exception ex)
            //{
            //    if (trans != null)
            //        trans.Rollback();
            //    throw ex;
            //}
        }

        public virtual void Dispose()
        {
            if (this._context != null)
            {
                this._context.Dispose();
            }
        }
        #endregion
    }
}
