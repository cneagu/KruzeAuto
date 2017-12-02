using KruzeAuto.Model;
using KruzeAuto.Repository;
using System;
using System.Collections.Generic;

namespace KruzeAuto
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid IDtest = Guid.NewGuid();
            UserRepository userRepo = new UserRepository();

            //insert
            User userNew = new User();
            userNew.UserID = IDtest;
            userNew.Email = "testnou@yahoo.com";
            userNew.UserName = "Test1";
            userNew.Password = "parolatest";
            userNew.PhoneNumber = "012351455";
            userNew.CreationDate = new DateTime(1990, 12, 1);
            userNew.Subscribed = true;
            userRepo.Insert(userNew);

            //readByID insert
            User userInsert = userRepo.ReadByID(IDtest);
            Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", userInsert.UserID, userInsert.Email, userInsert.UserName, userInsert.Password, userInsert.PhoneNumber, userInsert.CreationDate, userInsert.Subscribed);
         
            //update
            User userUpdate = new User();
            userUpdate.UserID = IDtest;
            userUpdate.Email = "testnou2@yahoo.com";
            userUpdate.UserName = "Test2";
            userUpdate.Password = "parolatest22222222222222222222222222222222222222222222";
            userUpdate.PhoneNumber = "01356787";
            userUpdate.Subscribed = false;
            userRepo.Update(userUpdate);

            //readByID update
            User userToRead = userRepo.ReadByID(IDtest);
            Console.WriteLine("\n\n\n\n{0} {1} {2} {3} {4} {5} {6}", userToRead.UserID, userToRead.Email, userToRead.UserName, userToRead.Password, userToRead.PhoneNumber, userToRead.CreationDate, userToRead.Subscribed);

            //read all
            Console.Write("\n\n\n\n");            
            List<User> users = userRepo.ReadAll();
            foreach(User user in users)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", user.UserID, user.Email, user.UserName, user.Password, user.PhoneNumber, user.CreationDate, user.Subscribed);
            }

            //deleteByID
            userRepo.DeleteByID(IDtest);

            //read all
            Console.Write("\n\n\n\n");
            List<User> usersAfter = userRepo.ReadAll();
            foreach (User user in usersAfter)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", user.UserID, user.Email, user.UserName, user.Password, user.PhoneNumber, user.CreationDate, user.Subscribed);
            }

            Console.ReadKey();
        }
    }
}
