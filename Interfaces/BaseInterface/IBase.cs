using HRMAspNet.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Interfaces.BaseInterface
{
    public interface IBase<T> where T : class
    {
        public Task<ActionResult<List<T>>> GetAllEntities();
        public Task<ActionResult<T>> GetEntityByID(Guid id);
        public Task<ActionResult<bool>> ChangeAnEntityByID<T>(Guid id, T tEntity) where T : class;
        public Task<ActionResult<bool>> CreateEntity<T>(T tEntity) where T : class;
        public Task<ActionResult<bool>> DeleteEntỉtyByID(Guid id);
    }
}
