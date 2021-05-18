using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRMAspNet.Models;
using HRMAspNet.Interfaces;
using HRMAspNet.Common;
using HRMAspNet.Controllers.BaseController;
using HRMAspNet.Interfaces.BaseInterface;
using HRMAspNet.Responses;

namespace HRMAspNet.Controllers
{
    [Route("api/[controller]")]
    public class AministrativeareasController : BaseController<Aministrativearea>
    {
        private readonly IAdministrativeArea _iAministrativeArea;

        public AministrativeareasController(IBase<Aministrativearea> iBase, IAdministrativeArea administrativeArea) : base(iBase)
        {
            _iAministrativeArea = administrativeArea;
        }
        [HttpGet("GetAdministrativeareaByAdministrativeAreaCode")]
        public async Task<Aministrativearea> GetAministrativeareaByCode(string administrativeAreaCode)
        {
            return await _iAministrativeArea.GetAministrativeareaByCode(administrativeAreaCode);
        }

        /// <summary>
        /// Lấy dữ liệu danh mục địa bàn hành chính theo mã cha
        /// 
        /// </summary>
        /// <param name="codeDetect">mã để nhận biết là tìm kiếm theo tỉnh hay huyện
        /// 1: Lấy danh sách huyện theo tỉnh
        /// 2: lấy danh sách xã theo huyện
        /// </param>
        /// <param name="parentCode"></param>
        /// <returns></returns>
        [HttpGet("GetAdministrativeByParentCode")]
        public async Task<ActionServiceResult> GetAdministrativeByParentCode(int codeDetect,int parentCode)
        {
            return await _iAministrativeArea.GetAdministrativeByParentCode(codeDetect,parentCode);
        }
    }
}
