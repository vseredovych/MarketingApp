using System;
using System.Collections.ObjectModel;
using DAL.Entities;


namespace MarketingApp.Repository
{
    public class UserRepository
    {
        private ObservableCollection<EUser> users;

        public UserRepository()
        {
            users = new ObservableCollection<EUser>
            { 
            new EUser {Id=1, Dob=Convert.ToDateTime("2019-10-10"), FirstName="FirstName", LastName="Lastname", IsActive=true},
            new EUser {Id=1, Dob=Convert.ToDateTime("2019-10-10"), FirstName="FirstName", LastName="Lastname", IsActive=true},
            new EUser {Id=1, Dob=Convert.ToDateTime("2019-10-10"), FirstName="FirstName", LastName="Lastname", IsActive=true},
            new EUser {Id=1, Dob=Convert.ToDateTime("2019-10-10"), FirstName="FirstName", LastName="Lastname", IsActive=true},
            new EUser {Id=1, Dob=Convert.ToDateTime("2019-10-10"), FirstName="FirstName", LastName="Lastname", IsActive=true},
            };
        }
        public ObservableCollection<EUser> GetUsers()
        {
            return users;
        }
    }
}
