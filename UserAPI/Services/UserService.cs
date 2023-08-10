using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using UserAPI.Models;
using UserAPI.Models.ViewModels;
using UserAPI.Repository;
using UserAPI.Repository.Interfaces;

namespace UserAPI.Services
{

    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private IRecordsRepository _recordRepository;

        public UserService(IUserRepository userRepository, IRecordsRepository recordRepository)
        {
            _userRepository = userRepository;
            _recordRepository = recordRepository;
        }

        public IEnumerable<ViewModelUser> Get()
        {

            IEnumerable<User> users = _userRepository.Get();
            
            foreach(User user in users)
            {
                mapModelToView(user);
            }

            return null;
        }

        private ViewModelUser mapModelToView(User modelUser)
        {
            ViewModelUser viewUser = new ViewModelUser();
            viewUser.Id = modelUser.Id;
            viewUser.Name = modelUser.Name;
            viewUser.Age = modelUser.Age;
            viewUser.HeightInCm = modelUser.HeightInCm;
            viewUser.Gender = modelUser.Gender;
            viewUser.Email = modelUser.Email;

            List<Record> records =  _recordRepository.GetByUserId(modelUser.Id);
            List<ViewModelRecord> viewRecords = new List<ViewModelRecord>();

            foreach(Record r in records)
            {
                viewRecords.Add(_recordRepository.mapModelToViewModel(r));
            }

            viewUser.Records = viewRecords;

            return viewUser;
        }

        public void Delete(ViewModelUser user)
        {
            User modelUser = mapViewToModel(user);
            _recordRepository.DeleteAll(user.Id);
            _userRepository.Delete(modelUser);
        }

        public ViewModelUser Edit(ViewModelUser user)
        {
            User modelUser = mapViewToModel(user);

            User editedUser =_userRepository.Edit(modelUser);
            foreach (ViewModelRecord record in user.Records) 
            { 
                _recordRepository.Update(record);
                
            }

            return mapModelToView(editedUser);
        }

        private User mapViewToModel(ViewModelUser viewUser)
        {
            User modelUser = new User();
            modelUser.Id = viewUser.Id;
            modelUser.Name = viewUser.Name;
            modelUser.Age = viewUser.Age;
            modelUser.HeightInCm = viewUser.HeightInCm ;
            modelUser.Gender = viewUser.Gender  ;
            modelUser.Email = viewUser.Email;
            modelUser.Password = viewUser.Password;

            return modelUser;
        }

        public ViewModelUser Get(string email)
        {
            ViewModelUser viewUser = new ViewModelUser();
            User modelUser = _userRepository.Get(email);
            if(modelUser != null)
            {
                viewUser = mapModelToView(modelUser);
            }
            return viewUser;
        }

        public ViewModelUser Create(ViewModelUser user)
        {
            User modelUser = mapViewToModel(user);
            ViewModelUser viewUser = mapModelToView(_userRepository.Create(modelUser));
            return viewUser;
        }

        public ViewModelUser AuthorizeUser(ViewModelUser tempUser)
        {
           IEnumerable<User> modelUsers = _userRepository.Get();
           User selectedUser = modelUsers.Where(u => u.Email == tempUser.Email && u.Password == tempUser.Password).FirstOrDefault();
            if(selectedUser != null)
            {
                return mapModelToView(selectedUser);
            }
            else
            {
                throw new AuthenticationException("Authentication failed");
            }
        }

        public void AddRecord(ViewModelRecord record)
        {
            _recordRepository.Add(record);
        }

        public void EditRecord(ViewModelRecord record)
        {
            _recordRepository.Update(record);
        }

        public void DeleteRecord(int recordId)
        {
            _recordRepository.Delete(recordId);
        }
    }
}
