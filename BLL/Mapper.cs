using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class Mapper
    {
        //internal static void MappUsersListToModel(List<Users> dbusersList, ref List<UserViewModel> usersListViewModel)
        //{
        //    usersListViewModel = (from dbuser in dbusersList
        //                          select new UserViewModel
        //                          {
        //                              UserID = dbuser.UserID,
        //                              LoginEmail = dbuser.LoginEmail,
        //                              Password = dbuser.Password,
        //                              ExternalLoginID = dbuser.ExternalLoginID,
        //                              UserType = dbuser.UserType,
        //                              UserStatus = dbuser.UserStatus,
        //                              IsVerified = dbuser.IsVerified,
        //                              IsActive = dbuser.IsActive,
        //                              IsOnline = dbuser.IsOnline,
        //                              //org_name = dbuser.org_name,
                                      
        //                              UsersProfileViewModel = dbuser.UsersProfile != null ? MappUserProfileToModel(dbuser.UsersProfile) : null

        //                          }).ToList();
        //}

       
    }
}