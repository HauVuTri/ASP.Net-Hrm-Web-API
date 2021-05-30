using HRMAspNet.Interfaces;
using HRMAspNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMAspNet.Common;
using System.Net;
using HRMAspNet.Responses;

namespace HRMAspNet.Services
{
    public class AministrativeAreaService : IAdministrativeArea
    {
        private readonly HRMContext _context;
        public AministrativeAreaService(HRMContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Service Lấy dữ liệu bản ghi địa bàn hành chính theo Aministrative theo Code
        /// </summary>
        /// <returns></returns>

        public async Task<Aministrativearea> GetAministrativeareaByCode(string administrativeAreaCode)
        {
            return await _context.Aministrativearea.FirstOrDefaultAsync(x => x.AdministrativeAreaCode == administrativeAreaCode);
        }

        public async Task<ActionServiceResult> GetAdministrativeByParentCode(int codeDetect, int parentCode)
        {
            //Mã tỉnh
            if ( codeDetect == 1)
            {
                //Lấy ra danh sách mã huyện/quận
                var data = await _context.Aministrativearea.Where(diaban => diaban.ProvincialCode == parentCode).Select(x => new DistrictAdministrativeAreaResponse(x.ProvincialCode, x.ProvincialName, x.DistrictCode, x.DistrictName)).Distinct().ToListAsync();


                if (data.Count > 0)
                {
                    return new ActionServiceResult(200, true, "Lấy danh mục các huyện thuộc tỉnh thành công", data);
                }

            }
            else if(codeDetect == 2)
            {
                //Lấy ra danh sách xã/phường
                //Lấy ra danh sách mã huyện/quận
                var data = await _context.Aministrativearea.Where(diaban => diaban.DistrictCode == parentCode).Select(x => new WardAdministrativeAreaResponse(x.WardCode, x.WardName,x.DistrictCode, x.DistrictName)).Distinct().ToListAsync();


                if (data.Count > 0)
                {
                    return new ActionServiceResult(200, true, "Lấy danh mục các xã thuộc huyện thành công", data);
                }

            }
            return null;
        }
    }
}
