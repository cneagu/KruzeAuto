using KruzeAuto.Business.Core;
using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid idTest = Guid.NewGuid();


            //insert
            User userNew = new User();
            userNew.UserID = idTest;
            userNew.Email = "testnou@yahoo.com";
            userNew.UserName = "Test1";
            userNew.Password = "parolatest";
            userNew.PhoneNumber = "012351455";
            userNew.CreationDate = new DateTime(1990, 12, 1);
            userNew.Subscribed = true;

            //update
            User userUpdate = new User();
            userUpdate.UserID = idTest;
            userUpdate.Email = "testnou2@yahoo.com";
            userUpdate.UserName = "Test2";
            userUpdate.Password = "parolatest22222222222222222222222222222222222222222222";
            userUpdate.PhoneNumber = "01356787";
            userUpdate.Subscribed = false;

            using (BusinessContext businessContext = new BusinessContext())
            {
                ShowUsers(businessContext);
                Console.Write("\n\n\n\n");
                InsertUser(businessContext, userNew);
                ShowUserByID(businessContext, idTest);
                Console.Write("\n\n\n\n");
                UpdateUser(businessContext, userUpdate);
                ShowUserByID(businessContext, idTest);
                Console.Write("\n\n\n\n");
                DeleteUser(businessContext, idTest);
                ShowUsers(businessContext);

            }
            Console.ReadLine();
        }

        private static void ShowUsers(BusinessContext businessContext)
        {
            List<User> usersAfter = businessContext.UserBusiness.ReadAll();
            Console.WriteLine("Users:");
            foreach (User user in usersAfter)
            {
                Console.WriteLine("UserID:{0} Email:{1} UserName:{2} Password:{3} PhoneNumber:{4} CreationDate:{5} Subscribed:{6}",
                    user.UserID, user.Email, user.UserName, user.Password, user.PhoneNumber, user.CreationDate, user.Subscribed);
            }
        }

        private static void ShowUserByID(BusinessContext businessContext, Guid idTest)
        {
            User userInsert = businessContext.UserBusiness.ReadByID(idTest);
            Console.WriteLine("User:"); 
            Console.WriteLine("UserID:{0} Email:{1} UserName:{2} Password:{3} PhoneNumber:{4} CreationDate:{5} Subscribed:{6}",
                userInsert.UserID, userInsert.Email, userInsert.UserName, userInsert.Password, userInsert.PhoneNumber, userInsert.CreationDate, userInsert.Subscribed);           
        }

        private static void InsertUser(BusinessContext businessContext, User user)
        {
            businessContext.UserBusiness.Insert(user);
        }

        private static void UpdateUser(BusinessContext businessContext, User user)
        {
            businessContext.UserBusiness.Update(user);
        }

        private static void DeleteUser(BusinessContext businessContext, Guid idTest)
        {
            businessContext.UserBusiness.Delete(idTest);
        }
    }
         
}

