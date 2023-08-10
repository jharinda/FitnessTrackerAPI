using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;
using UserAPI.Models.ViewModels;

namespace UserAPI.Repository.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<ViewModelUser> Get();
        public void Delete(ViewModelUser user);
        public ViewModelUser Edit(ViewModelUser user);
        public ViewModelUser Get(string email);
        public ViewModelUser Create(ViewModelUser user);
        public ViewModelUser AuthorizeUser(ViewModelUser tempUser);
        public void AddRecord(ViewModelRecord record);
        public void EditRecord(ViewModelRecord record);
        public void DeleteRecord(int recordId);

    }
}
