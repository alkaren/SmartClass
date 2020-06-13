using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestSmartClass.Helpers;
using TestSmartClass.Models;

namespace TestSmartClass.Controllers
{
    public class MahasiswaControlls : IMahasiswaMasterData
    {
        public bool AddData(mahasiswa_tbl obj)
        {
            try
            {
                using (var context = new SmartClassContext())
                {
                    context.mahasiswa_tbl.Add(obj);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
                //LogHelpers.source = this.GetType().Name;
                //LogHelpers.message = ex.Message;
                //LogHelpers.user = "";
                //LogHelpers.WriteLog();
            }

            return false;
        }

        public Task<bool> DeleteData(string id)
        {
            throw new NotImplementedException();
        }

        public Task<mahasiswa_tbl> DetailData(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<mahasiswa_tbl>> GetData()
        {
            try
            {
                using (var context = new smartclassdbEntities())
                {
                    var ret = await context.mahasiswa_tbl.ToListAsync();
                    return ret;
                }
            }
            catch (Exception ex)
            {
                //LogHelpers.source = this.GetType().Name;
                //LogHelpers.message = ex.Message;
                //LogHelpers.user = "";
                //LogHelpers.WriteLog();
            }

            return null;
        }

        public Task<IEnumerable<mahasiswa_tbl>> GetDataByContaint(string param)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateData(string id, mahasiswa_tbl obj)
        {
            throw new NotImplementedException();
        }
    }
}