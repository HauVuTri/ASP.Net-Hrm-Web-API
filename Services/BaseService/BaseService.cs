using HRMAspNet.Common;
using HRMAspNet.Interfaces.BaseInterface;
using HRMAspNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Services.BaseService
{
    public class BaseService<T> : IBase<T> where T : class
    {
        //Tạo mới 1 bản ghi
        public async Task<ActionResult<bool>> CreateEntity<T1>(T1 tEntity) where T1 : class
        {
            using (HRMContext context = new HRMContext())
            {
                context.Set<T1>().Add(tEntity);
                var count = await context.SaveChangesAsync();
                if (count < 1)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<ActionResult<List<T>>> GetAllEntities()
        {
            using (HRMContext context = new HRMContext())
            {
                return await context.Set<T>().ToListAsync();
            }

            //return await _context.Aministrativearea.ToListAsync();
        }


        /// <summary>
        /// Lấy 1 bản ghi theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult<T>> GetEntityByID(Guid id)
        {
            using (HRMContext context = new HRMContext())
            {
                var aministrativearea = await context.Set<T>().FindAsync(id);

                if (aministrativearea == null)
                {
                    return null;
                }
                return aministrativearea;
            }

        }

        /// <summary>
        /// Chỉnh sửa 1 bản ghi theo id và thôgn tin mới
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <param name="id"></param>
        /// <param name="tEntity"></param>
        /// <returns></returns>
        public async Task<ActionResult<bool>> ChangeAnEntityByID<T1>(Guid id, T1 tEntity) where T1 : class
        {
            using (HRMContext context = new HRMContext())
            {
                //Tim xem idz`
                context.Entry(tEntity).State = EntityState.Modified;
                   var  res =  await context.SaveChangesAsync();
                if (res < 1)
                {
                    return false;
                }
                return true;
                //return new ActionServiceResult((int)HttpStatusCode.OK, true, "Cập nhật thành công");
            }

        }

        public async Task<ActionResult<bool>> DeleteEntỉtyByID(Guid id)
        {
            using(HRMContext context = new HRMContext())
            {
                //Tìm xem bản ghi có trong DB hay không
                var aministrativearea = await context.Set<T>().FindAsync(id);
                if (aministrativearea == null)
                {
                    return false;
                }

                context.Set<T>().Remove(aministrativearea);
                var resDelete = await context.SaveChangesAsync();
                if (resDelete < 1)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
