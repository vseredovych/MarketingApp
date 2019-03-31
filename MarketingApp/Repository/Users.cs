using System;
using System.Collections.ObjectModel;
using DAL.Entities;
using DAL.Operations;

namespace MarketingApp.Repository
{
    public class UserRepository
    {
        private ObservableCollection<EUser> users;
        OUser operUser = new OUser();

        public UserRepository()
        {
            users = new ObservableCollection<EUser>();
        }
        public void FillRepositoryWithData()
        {
            users = new ObservableCollection<EUser>(operUser.Select());
        }
        public void AddUserToRepository(EUser user)
        {
            users.Add(user);
        }
        public ObservableCollection<EUser> GetUsers()
        {
            return users;
        }
    }
}
