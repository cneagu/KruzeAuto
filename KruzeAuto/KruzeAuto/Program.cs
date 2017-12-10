using KruseAuto.Repository.Core;
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

            using (RepositoryContext repositoryContext = new RepositoryContext())
            {
                ShowUsers(repositoryContext);
                Console.Write("\n\n\n\n");
                InsertUser(repositoryContext, userNew);
                ShowUserByID(repositoryContext, idTest);
                Console.Write("\n\n\n\n");
                UpdateUser(repositoryContext, userUpdate);
                ShowUserByID(repositoryContext, idTest);
                Console.Write("\n\n\n\n");
                DeleteUser(repositoryContext, idTest);
                ShowUsers(repositoryContext);

            }
            Console.ReadKey();
            Console.ReadLine();
        }

        private static void ShowUsers(RepositoryContext repositoryContext)
        {
            List<User> usersAfter = repositoryContext.UserRepository.ReadAll();
            Console.WriteLine("Users:");
            foreach (User user in usersAfter)
            {
                Console.WriteLine("UserID:{0} Email:{1} UserName:{2} Password:{3} PhoneNumber:{4} CreationDate:{5} Subscribed:{6}",
                    user.UserID, user.Email, user.UserName, user.Password, user.PhoneNumber, user.CreationDate, user.Subscribed);
            }
        }

        private static void ShowUserByID(RepositoryContext repositoryContext, Guid idTest)
        {
            User userInsert = repositoryContext.UserRepository.ReadByID(idTest);
            Console.WriteLine("User:"); 
            Console.WriteLine("UserID:{0} Email:{1} UserName:{2} Password:{3} PhoneNumber:{4} CreationDate:{5} Subscribed:{6}",
                userInsert.UserID, userInsert.Email, userInsert.UserName, userInsert.Password, userInsert.PhoneNumber, userInsert.CreationDate, userInsert.Subscribed);           
        }

        private static void InsertUser(RepositoryContext repositoryContext, User user)
        {
           repositoryContext.UserRepository.Insert(user);
        }

        private static void UpdateUser(RepositoryContext repositoryContext, User user)
        {
            repositoryContext.UserRepository.Update(user);
        }

        private static void DeleteUser(RepositoryContext repositoryContext, Guid idTest)
        {
            repositoryContext.UserRepository.DeleteByID(idTest);
        }
    }
         
}

