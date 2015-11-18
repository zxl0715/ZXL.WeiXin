using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using ZXL.DAL;
using ZXL.IBLL;
using ZXL.IDAL;
using ZXL.Models;
using ZXL.Models.Sys;

namespace ZXL.BLL
{
    public class SysSampleBLL : ISysSampleBLL
    {
        DBContainer db = new DBContainer();
        [Dependency]
        public ISysSampleRepository Rep { get; set; }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pager">JQgrid分页</param>
        /// <param name="queryStr">搜索条件</param>
        /// <returns>列表</returns>
        public List<SysSampleModel> GetList(string queryStr)
        {

                IQueryable<SysSample> queryData = null;
                queryData = Rep.GetList(db);
                return CreateModelList(ref queryData);
        }
        private List<SysSampleModel> CreateModelList(ref IQueryable<SysSample> queryData)
        {


            List<SysSampleModel> modelList = (from r in queryData
                                              select new SysSampleModel
                                              {
                                                  Id = r.Id,
                                                  Name = r.Name,
                                                  Age = r.Age,
                                                  Bir = r.Bir,
                                                  Photo = r.Photo,
                                                  Note = r.Note,
                                                  CreateTime = r.CreateTime,

                                              }).ToList();

            return modelList;
        }

        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Create( SysSampleModel model)
        {
            try
            {
                SysSample entity = Rep.GetById(model.Id);
                if (entity != null)
                {
                    return false;
                }
                entity = new SysSample();
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Age = model.Age;
                entity.Bir = model.Bir;
                entity.Photo = model.Photo;
                entity.Note = model.Note;
                entity.CreateTime = model.CreateTime;

                if (Rep.Create(entity) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //ExceptionHander.WriteException(ex);
                return false;
            }
        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="id">id</param>
        /// <returns>是否成功</returns>
        public bool Delete(string id)
        {
            try
            {
                if (Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Edit(SysSampleModel model)
        {
            try
            {
                SysSample entity = Rep.GetById(model.Id);
                if (entity == null)
                {
                    return false;
                }
                entity.Name = model.Name;
                entity.Age = model.Age;
                entity.Bir = model.Bir;
                entity.Photo = model.Photo;
                entity.Note = model.Note;


                if (Rep.Edit(entity) == 1)
                {
                    return true;
                }
                else
                {

                    return false;
                }

            }
            catch (Exception ex)
            {

                //ExceptionHander.WriteException(ex);
                return false;
            }
        }
        /// <summary>
        /// 判断是否存在实体
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns>是否存在</returns>
        public bool IsExists(string id)
        {
            if (db.SysSample.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 根据ID获得一个实体
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>实体</returns>
        public SysSampleModel GetById(string id)
        {
            if (IsExist(id))
            {
                SysSample entity = Rep.GetById(id);
                SysSampleModel model = new SysSampleModel();
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.Age = entity.Age;
                model.Bir = entity.Bir;
                model.Photo = entity.Photo;
                model.Note = entity.Note;
                model.CreateTime = entity.CreateTime;

                return model;
            }
            else
            {
                return new SysSampleModel();
            }
        }

        /// <summary>
        /// 判断一个实体是否存在
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是否存在 true or false</returns>
        public bool IsExist(string id)
        {
            return Rep.IsExist(id);
        }
    }
}
