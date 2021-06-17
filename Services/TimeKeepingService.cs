using HRMAspNet.Interfaces;
using HRMAspNet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMAspNet.Services
{
    public class TimeKeepingService : ITimeKeeping
    {
        private readonly HRMContext _context;

        public TimeKeepingService(HRMContext contex)
        {
            _context = contex;
        }

        public async Task<bool> CalculateTimeKeeping(string timeCode)
        {
            if (timeCode == null)
            {
                return false;
            }
            string month = timeCode.Substring(0, 2);
            string year = timeCode.Substring(2);
            var requestTime = new DateTime(Int32.Parse(year),Int32.Parse(month), 1);

            //Lấy danh sách toàn bộ lao động của kì đó
            var lstEmployeeAllTenant = await  _context.Employeedetail.ToListAsync();
            //if(lstEmployeeAllTenant.Count > 0)

            //Lấy toàn bộ thông tin chấm công của kì đó(Của tất cả lao động)
            var lstTimeKeepingSeeking = (await _context.Timekeeping.ToListAsync()).Where(x => x.Period == requestTime).ToList();

            //Lấy toàn bộ điểm danh 
            var lstAllRollCall = await _context.Rollcall.ToListAsync();
            if (lstAllRollCall.Count < 1)
            {
                return false;
            }
            //Lấy toàn bộ điểm danh trong tháng
            var lstAllRollCallInPeriod = lstAllRollCall.Where(x =>
            {
                return x.TimeCheckin.Month == Int32.Parse(month) && x.TimeCheckin.Year == Int32.Parse(year) ;
            }).ToList();

            //Số ngày trong tháng
            int daysInThisPeriod = DateTime.DaysInMonth(Int32.Parse(year), Int32.Parse(month));

            //CHạy qua tất cả lao động
            for (int i = 0; i < lstEmployeeAllTenant.Count; i++)
            {
                //Tổng số công làm việc
                float numberOfWorkDay = 0;

                #region Tính số công của lao động này trong kỳ đang tra cứu

                //Từ list tất cả điểm danh theo tháng -> lấy ra tất cả điểm danh của NGƯỜI THỨ i này
                var lstRollCallOfiEmployee = lstAllRollCallInPeriod.Where(x => x.EmployeeDetailId == lstEmployeeAllTenant[i].EmployeeDetailId).ToList();
                if (lstRollCallOfiEmployee.Count < 1 || lstRollCallOfiEmployee == null)
                {
                    numberOfWorkDay = 0;
                }
                else
                {
                    //Chạy qua toàn bộ ngày trong tháng -> tìm điểm danh
                    for (int day = 0; day < daysInThisPeriod; day++)
                    {
                        //Lấy list tất cả điểm danh theo NGÀY của người lao động này
                        var lstRollCallByDayOfThisEmployee = lstRollCallOfiEmployee.Where(x => x.TimeCheckin.Day == day).ToList();
                        if (lstRollCallByDayOfThisEmployee == null || lstRollCallByDayOfThisEmployee.Count < 1)
                        {
                            continue;
                        }
                        //Từ thông tin điểm danh -> lấy ra 2 mốc điểm danh sớm nhất và muộn nhất trong ngày
                        //var minTimeRollCall = lstRollCallOfiEmployee.Min(x => x.TimeCheckin);
                        //var maxTimeRollCall = lstRollCallOfiEmployee.Max(x => x.TimeCheckin);
                        var rollCallHasMinTime = lstRollCallByDayOfThisEmployee.OrderBy(i => i.TimeCheckin).First();
                        var rollCallHasMaxTime = lstRollCallByDayOfThisEmployee.OrderByDescending(i => i.TimeCheckin).First();
                        
                        if (rollCallHasMinTime == rollCallHasMaxTime)
                        {
                            numberOfWorkDay = numberOfWorkDay + (float)0.5;
                        }
                        else
                        {
                            if(rollCallHasMinTime.Shift == 1 && rollCallHasMaxTime.Shift == 2)
                            {
                                numberOfWorkDay = numberOfWorkDay + (float)1;
                            }
                            else
                            {
                                numberOfWorkDay = numberOfWorkDay + (float)0.5;
                            }
                        }

                    }
                }


                #endregion

                #region Cập nhật chấm công
                //Tìm thôgn tin chấm công của nhân viên này trong kỳ này
                var foundEmp = lstTimeKeepingSeeking.Find(x => x.EmployeeDetailId == lstEmployeeAllTenant[i].EmployeeDetailId);
                if(foundEmp == null)
                {
                    //Thêm mới(post)
                    _context.Timekeeping.Add(new Timekeeping(Guid.NewGuid(), lstEmployeeAllTenant[i].EmployeeDetailId, lstEmployeeAllTenant[i].EmployeeCode, numberOfWorkDay, lstEmployeeAllTenant[i].FullName, requestTime, month + year));
                    var count = await _context.SaveChangesAsync();

                    if (count < 1)
                    {
                        return false;
                    }

                }
                else
                {
                    var objectModify = foundEmp;
                    objectModify.TotalWorkDayInMonth = numberOfWorkDay;
                    //CHỉnh sửa(put)
                    _context.Entry(foundEmp).State = EntityState.Modified;
                    var res = await _context.SaveChangesAsync();
                    if (res < 1)
                    {
                        return false;
                    }
                }
                #endregion
            }
            return true;
        
        }

        /// <summary>
        /// Lấy số lao động đi muộn trong tháng (từng ngày 1)
        /// </summary>
        /// <param name="timeCode"></param>
        /// <returns></returns>
        public async Task<List<int>> GetNumberOfEmployeeLateInMonth(string timeCode)
        {
            if (timeCode == null)
            {
                return null;
            }
            string month = timeCode.Substring(0, 2);
            string year = timeCode.Substring(2);
            var requestTime = new DateTime(Int32.Parse(year), Int32.Parse(month), 1);

            var nowDay = DateTime.Now;

            //Số ngày trong tháng
            int daysInThisPeriod = DateTime.DaysInMonth(Int32.Parse(year), Int32.Parse(month));

            //Danh scah toàn bộ lao động trong công ty
            var lstEmployeeAllTenant = await _context.Employeedetail.ToListAsync();

            //Lấy toàn bộ điểm danh 
            var lstAllRollCall = await _context.Rollcall.ToListAsync();
            if (lstAllRollCall.Count < 1)
            {
                return null;
            }
            //var lstRollCallsByTimeCodePara = lstAllRollCall.Where(x => x.time)

            //Biến toàn cục lưu return
            List<int> lstLate = new List<int>();
            //Chạy qua toàn bộ ngày trong tháng -> tìm điểm danh
            for (int day = 1; day <= daysInThisPeriod; day++)
            {
                int numberLateToday = 0;
                for (int i = 0; i < lstEmployeeAllTenant.Count; i++)
                {
                    //Từ list tất cả điểm danh theo tháng -> lấy ra tất cả điểm danh của NGƯỜI THỨ (i) này theo ngày (day)
                    var lstRollCallOfiEmployeeByDayInLoop = lstAllRollCall.Where(x => x.EmployeeDetailId == lstEmployeeAllTenant[i].EmployeeDetailId && x.TimeCheckin.Day == day).ToList();
                    //Từ thông tin điểm danh -> lấy ra 2 mốc điểm danh sớm nhất và muộn nhất trong ngày
                    if(lstRollCallOfiEmployeeByDayInLoop == null || lstRollCallOfiEmployeeByDayInLoop.Count < 1)
                    {
                        continue;
                    }
                    var rollCallHasMinTime = lstRollCallOfiEmployeeByDayInLoop.OrderBy(i => i.TimeCheckin).First();
                    var rollCallHasMaxTime = lstRollCallOfiEmployeeByDayInLoop.OrderByDescending(i => i.TimeCheckin).First();

                    //ĐIều kiện khi nào thì là đi muộn
                    //Nếu 
                    if (rollCallHasMinTime == rollCallHasMaxTime)
                    {
                        if(rollCallHasMinTime.LateTime > 0)
                        {
                            numberLateToday += 1;
                        }
                    }
                    else
                    {
                        if (rollCallHasMinTime.LateTime > 0 || rollCallHasMaxTime.LateTime > 0)
                        {
                            numberLateToday += 1;
                        }
                        
                    }

                }
                lstLate.Add(numberLateToday);



            }
            return lstLate;

        }

        /// <summary>
        /// Lấy thông tin chấm công của các nhân viên dựa theo timeCode
        /// timeCode dạng: mm/YYYY
        /// </summary>
        /// <param name="timeCode"></param>
        /// <returns></returns>
        public Task<List<Timekeeping>> GetTimeKeepingIncludeEmployeeByTimeCode(string timeCode)
        {
            //return ;
            var data = _context.Timekeeping.Include(x => x.EmployeeDetail).Where(x => x.TimeCode == timeCode).ToListAsync();
            if (data != null)
            {
                return data;
            }
            return null;
        }
    }
}
