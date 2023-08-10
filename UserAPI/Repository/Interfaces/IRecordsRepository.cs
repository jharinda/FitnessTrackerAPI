using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;
using UserAPI.Models.ViewModels;

namespace UserAPI.Repository
{
    public interface IRecordsRepository
    {
        public List<Record> GetByUserId(int UserId);
        public ViewModelRecord Add(ViewModelRecord record);
        public ViewModelRecord Update(ViewModelRecord record);
        public void Delete(int recordId);
        public void DeleteAll(int UserId);
        public ViewModelRecord mapModelToViewModel(Record record);
        public Record mapViewModelToModel(ViewModelRecord record);




    }
}
