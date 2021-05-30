using HRMAspNet.Entities;
using HRMAspNet.Interfaces;
using HRMAspNet.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Services
{
    public class RollCallService : IRollCall
    {
        private readonly HRMContext _context;

        public RollCallService(HRMContext contex)
        {
            _context = contex;
        }

        public async Task<bool> CreateRollCallFromFaceRecognize(Guid employeeDetailID, string rollCallTimeCode)
        {
            //Tìm kiếm xem ID có trong DB hay không?
            if (employeeDetailID == null) {
                return false;
            }
            var employeeSearching = await _context.Employeedetail.FindAsync(employeeDetailID);
            if (employeeSearching == null)
            {
                return false;
            }

            //Phân tách rollCallTimeCode -> để tạo ra object thêm mới vào DB
            if (rollCallTimeCode == null)
            {
                return false;
            }
            string day = rollCallTimeCode.Substring(0, 2);
            string month = rollCallTimeCode.Substring(2, 2);
            string year = rollCallTimeCode.Substring(4, 4);
            string hour = rollCallTimeCode.Substring(8, 2);
            string minute = rollCallTimeCode.Substring(10, 2);
            string second = rollCallTimeCode.Substring(12);
            if(day == null || month == null || year == null || hour == null || minute == null || second == null)
            {
                return false;
            }
            var dateTimeRollCall = new DateTime(Int32.Parse(year), Int32.Parse(month) , Int32.Parse(day) , Int32.Parse(hour) , Int32.Parse(minute) , Int32.Parse(second));
            var lateTime = CalculateNumberOfMinutesLateSoonLeave(dateTimeRollCall);
            if (lateTime == -9999) return false;

            //Thêm mới bản ghi vào DB
            _context.Rollcall.Add(new Rollcall(Guid.NewGuid(), rollCallTimeCode, employeeDetailID, employeeSearching.EmployeeCode, dateTimeRollCall, lateTime));
            var count = await _context.SaveChangesAsync();
            if (count < 1)
            {
                return false;
            }
            return true;
        }
   

        public async Task<List<RollCallResponse>> GetDataBySqlQuery(Guid rollCallId)
        {
            //Cách 1
            //return _context.Query<Rollcall>().FromSqlRaw("SELECT r.* FROM employeedetail e INNER JOIN rollcall r ON e.EmployeeDetailID = r.EmployeeDetailID").ToList();

            //Cách 3;
            //return _context.Rollcall.FromSqlRaw("SELECT r.* FROM employeedetail e INNER JOIN rollcall r ON e.EmployeeDetailID = r.EmployeeDetailID").ToList();

            //Cách 2;
            var sqlParams = new MySqlParameter[]
            {
                new MySqlParameter{ParameterName="@RollCallId",Value=rollCallId, Direction=ParameterDirection.Input}
            };
            return await _context.Query<RollCallResponse>().FromSqlRaw("CALL Proc_GetRollCall(@RollCallId);", sqlParams).ToListAsync();

            //Cách 4
            //var lstRollCall = _context.Rollcall.Include(x => x.EmployeeDetail).Where(x => x.EmployeeDetailId == new Guid("56ce9b9a-65b6-4b1c-9e41-95c17b87ef4b")).ToList();
            //return lstRollCall;
        }

        /// <summary>
        /// Lấy toàn bộ danh sách điểm danh theo mã thời gian
        /// </summary>
        /// <param name="rollCallTimeCode">Mã thời gian</param>
        /// <returns></returns>
        public Task<List<Rollcall>> GetRollCallIncludeEmployeeByTimeCode(string rollCallTimeCode)
        {
            var data = _context.Rollcall.Include(x => x.EmployeeDetail).Where(x => x.RollCallTimeCode.Contains(rollCallTimeCode)  ).ToListAsync();
            if (data != null)
            {
                return data;
            }
            return null;
                
        }
        /// <summary>
        /// Hàm tính toán số phút mà lao động đi muộn/ về sớm
        /// </summary>
        /// <param name="timeLeave">Giờ đến / hoặc về từ công ty</param>
        /// <returns></returns>
        public float CalculateNumberOfMinutesLateSoonLeave(DateTime timeLeave)
        {
            if(timeLeave == null)
            {
                return -9999;
            }
            var hour = timeLeave.Hour;

            TimeSpan ts;

            //Nếu là buổi sáng
            if(7 <= hour && hour < 12 )
            {
                //Tình thười gian đi làm muộn (Giờ chuẩn là 8h)
                ts = (timeLeave - (new DateTime(timeLeave.Year, timeLeave.Month, timeLeave.Day, 8,0,0)));
                var lateTime = ts.TotalMinutes;
                if (lateTime < 0)
                    return 0;
                return Convert.ToSingle(lateTime);

            }
            else if(13 < hour && hour < 23)
            {
                //Tình thười gian về sớm (Giờ chuẩn là 6h)
                ts = ((new DateTime(timeLeave.Year, timeLeave.Month, timeLeave.Day, 18, 0, 0)) - timeLeave );
                var soonLeaveTime = ts.TotalMinutes;
                if (soonLeaveTime < 0)
                    return 0;
                return Convert.ToSingle(soonLeaveTime);
            }
            return -9999;
        }

        public async Task<bool> CreateRollCallFromFaceRecognizeByEmployeeCode(string employeeCode, string rollCallTimeCode)
        {
            //Tìm kiếm xem ID có trong DB hay không?
            if (employeeCode == null)
            {
                return false;
            }
            var lstEmployeeSearching = await _context.Employeedetail.Where(x=> x.EmployeeCode == employeeCode).ToListAsync();
            if (lstEmployeeSearching == null || lstEmployeeSearching.Count == 0)
            {
                return false;
            }
            var employeeSameCode = lstEmployeeSearching[0];
            //Phân tách rollCallTimeCode -> để tạo ra object thêm mới vào DB
            if (rollCallTimeCode == null)
            {
                return false;
            }
            string day = rollCallTimeCode.Substring(0, 2);
            string month = rollCallTimeCode.Substring(2, 2);
            string year = rollCallTimeCode.Substring(4, 4);
            string hour = rollCallTimeCode.Substring(8, 2);
            string minute = rollCallTimeCode.Substring(10, 2);
            string second = rollCallTimeCode.Substring(12);
            if (day == null || month == null || year == null || hour == null || minute == null || second == null)
            {
                return false;
            }
            var dateTimeRollCall = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day), Int32.Parse(hour), Int32.Parse(minute), Int32.Parse(second));
            var lateTime = CalculateNumberOfMinutesLateSoonLeave(dateTimeRollCall);
            if (lateTime == -9999) return false;

            //Thêm mới bản ghi vào DB
            _context.Rollcall.Add(new Rollcall(Guid.NewGuid(), rollCallTimeCode, employeeSameCode.EmployeeDetailId, employeeCode, dateTimeRollCall, lateTime));
            var count = await _context.SaveChangesAsync();
            if (count < 1)
            {
                return false;
            }
            return true;
        }
    }
}
