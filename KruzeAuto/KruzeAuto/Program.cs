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

            
            Guid user = new Guid("561FC9B6-74AB-D604-337F-3D83F8504E01");

            Announcement an = new Announcement();
            an.Active = true;
            an.AnnoucementID = new Guid("8984e94a-5b3d-6a22-8bb9-b6f4debd37fc");           
            an.Brand = "Mercedes";
            an.Color = "";
            an.ColorType = "";
            an.Condition = "New";
            an.CreationDate = new DateTime(2017, 1, 18);
            an.CubicCapacity = 0;
            an.Currency = "Any";
            an.Description = "";
            an.EmissionClass = "Any";
            an.FabricationYear = 1234;
            an.FuelType = "Any";
            an.GVW = 0;
            an.Kilometer = 1234;
            an.LoadCapacity = 0;
            an.Model = "B Class";
            an.NegociablePrice = false;
            an.NumberOfSeats = 0;
            an.OperatingHours = 0;
            an.Power = 123;
            an.Price = 1234;
            an.Promoted = false;
            an.Title = "213423fvsv";
            an.Transmission = "any";
            an.Type = "Coupe";
            an.Update = new DateTime(2017, 1, 18);
            an.UserID = user;
            an.VIN = "asda";
            an.VehicleType = 1;
            an.Views = 0;


            using (BusinessContext businessContext = new BusinessContext())
            {
                //ShowUser(businessContext, user);
                //readSingIn(businessContext, "neagucristianssstefan@yahoo.com", "morassrioan923", "0234");
                Insert(businessContext, an);
                Console.Write(" dada\n\n\n\n");
                //ReadLogIn(businessContext, "neagucristianstefan@yahoo.com", "morarioan923");
                //ShowUsers(businessContext);

            }
            Console.ReadLine();
        }

        private static void Insert(BusinessContext businessContext, Announcement announcement)
        {
            businessContext.AnnouncementBusiness.Insert(announcement);
        }



        private static void mainSearch(BusinessContext businessContext, int VehicleType, string Condition, string Brand, string Model,
            int Kilometer, int FabricationYear, string FuelType1, string FuelType2, string FuelType3, string FuelType4,
            string FuelType5, string FuelType6, string FuelType7, int Price)
        {
            List<Search> announcements = businessContext.SearchBusiness.MainSearch(VehicleType, Condition, Brand, Model,
             Kilometer, FabricationYear, FuelType1, FuelType2, FuelType3, FuelType4,
             FuelType5, FuelType6, FuelType7, Price);
            Console.WriteLine("Announcement:");
            foreach (Search announcement in announcements)
            {
                Console.WriteLine("AnnoucementID:{0} UserID:{1} Promoted:{2} Title:{3} Brand:{4} Model:{5} Kilometer:{6}" +
                    " FabricationYear{7} FuelType{8} Price{9} Power{10} UserName{11} Country{12} County{13} ",
                    announcement.AnnoucementID, announcement.UserID, announcement.Promoted, announcement.Title, announcement.Brand,
                    announcement.Model, announcement.Kilometer, announcement.FabricationYear, announcement.FuelType,
                    announcement.Price, announcement.Power, announcement.UserName, announcement.Country, announcement.County);
            }
        }

        private static void ShowUsers(BusinessContext businessContext)
        {
            List<User> usersAfter = businessContext.UserBusiness.ReadAll();
            Console.WriteLine("Users:");
            foreach (User user in usersAfter)
            {
                Console.WriteLine(" Email:{0} UserName:{1}  PhoneNumber:{2} ",
                     user.Email, user.UserName, user.PhoneNumber);
            }
        }
        private static void ShowUser(BusinessContext businessContext,Guid userId)
        {
            User user = businessContext.UserBusiness.ReadByID(userId);
            Console.WriteLine("Users:");
           
                Console.WriteLine(" Email:{0} UserName:{1}  PhoneNumber:{2} ",
                     user.Email, user.UserName, user.PhoneNumber);
           
        }

        private static void readSingIn(BusinessContext businessContext, string email, string userName, string phoneNumber)
        {
            User user = businessContext.UserBusiness.ReadSingIn(email, userName, phoneNumber);
            Console.WriteLine("Users:");

            Console.WriteLine(" Email:{0} UserName:{1}  PhoneNumber:{2} ",
                    user.Email, user.UserName, user.PhoneNumber);
        }

        //private static void ReadLogIn(BusinessContext businessContext, string email, string password)
        //{
        //    User user = businessContext.UserBusiness.ReadLogIn(email, password);
        //    Console.WriteLine("Users:");

        //    Console.WriteLine(" Email:{0} ",
        //            user.UserID);
        //}
    }
         
}

