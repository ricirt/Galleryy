using GalleryBusiness.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Gallery.Models;
using System.Linq;
using Gallery.ViewModels;
using System.Security.Cryptography;
using GalleryBusiness.Encrypt;

namespace GalleryBusiness.Core
{
    public class CUserLogin : IUserLogin
    {
        private GalleryContext gc = new GalleryContext();
        public bool Register(UserLoginModel userloginmodel)
        {
            UserLogin ulogin = new UserLogin()
            {
                Username = userloginmodel.UName,
                Password = Sha256.ComputeSha256Hash(userloginmodel.Password)
            };
            UserInformation uInfo = new UserInformation()
            {
                Uage = userloginmodel.Uage,
                Uname = userloginmodel.Name,
                Umail = userloginmodel.Umail,
                Uprofession = userloginmodel.Uprofession,
                Urole = "admin"
            };
            uInfo.UserLogin = ulogin;
            gc.UserInformations.Add(uInfo);
            gc.SaveChanges();
            return true;
        }
        public bool CheckPass(LoginModel userLogin)
        {
            var users = gc.UserLogins.Select(u => u).ToList();
            foreach (UserLogin item in users)
            {
                if (item.Username == userLogin.Username)
                {
                    if (item.Password == Sha256.ComputeSha256Hash(userLogin.Password))
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        public bool isAdmin(string userName)
        {
            var isAdmin = (from uInfo in gc.UserInformations
                           join uLogin in gc.UserLogins
                           on uInfo.Uid equals uLogin.LoginId
                           where uLogin.Username == userName
                           select uInfo.Urole
                           ).FirstOrDefault();
            if (isAdmin == "admin")
                return true;
            return false;
        }

        public ProfilViewModel GetProfileInfo(string username)
        {
            var profile = (from uLogin in gc.UserLogins
                           join UInfo in gc.UserInformations
                           on uLogin.LoginId equals UInfo.Uid
                           where uLogin.Username == username
                           select new ProfilViewModel
                           {
                               UName = uLogin.Username,
                               Name = UInfo.Uname,
                               Password = uLogin.Password,
                               Uage = UInfo.Uage,
                               Umail = UInfo.Umail,
                               Uprofession = UInfo.Uprofession,
                               Urole = UInfo.Urole
                           }
                         ).FirstOrDefault();
            return profile;
        }

        public bool SetProfile(ProfilViewModel profilViewModel)
        {
            var updatedULogin = gc.UserLogins.Where(i => i.Username == profilViewModel.UName).Select(c => c).FirstOrDefault();
            updatedULogin.Username = profilViewModel.UName;
            var UpdatedUInfo = gc.UserInformations.Where(i => i.Uid == updatedULogin.LoginId).Select(c => c).FirstOrDefault();
            UpdatedUInfo.Uage = profilViewModel.Uage;
            UpdatedUInfo.Umail = profilViewModel.Umail;
            UpdatedUInfo.Uname = profilViewModel.Name;
            UpdatedUInfo.Uprofession = profilViewModel.Uprofession;

            UpdatedUInfo.UserLogin = updatedULogin;
            gc.UserInformations.Update(UpdatedUInfo);
            gc.SaveChanges();
            return true;
        }

        public bool updatePassword(string username, string newPassword)
        {
            var updatedPassword = gc.UserLogins.Where(u => u.Username == username).Select(c => c).FirstOrDefault();
            updatedPassword.Password = Sha256.ComputeSha256Hash(newPassword);
            gc.UserLogins.Update(updatedPassword);
            gc.SaveChanges();
            return true;
        }
    }

}

