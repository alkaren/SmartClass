using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestSmartClass.Models;

namespace TestSmartClass.Helpers
{
    public interface IMahasiswaMasterData
    {
        bool AddData(mahasiswa_tbl obj);
        Task<bool> UpdateData(string id, mahasiswa_tbl obj);
        Task<bool> DeleteData(string id);
        Task<IEnumerable<mahasiswa_tbl>> GetData();
        Task<mahasiswa_tbl> DetailData(string id);
        Task<IEnumerable<mahasiswa_tbl>> GetDataByContaint(string param);
    }
}