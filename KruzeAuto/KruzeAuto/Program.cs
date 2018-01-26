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

            int VehicleType = 1;
            string Condition = "All";
            string Brand = "";
            string Model = "";
            int Kilometer = 1000000;
            int FabricationYear = 2000;
            string FuelType1 = "Petrol";
            string FuelType2 = "Diesel";
            string FuelType3 = "";
            string FuelType4 = "";
            string FuelType5 = "";
            string FuelType6 = "";
            string FuelType7 = "";
            int Price = 1000000;
            Guid user = new Guid("CEBF5C68-9AAB-3590-3E11-E01DFEE0CAB7");



            using (BusinessContext businessContext = new BusinessContext())
            {
                //ShowUser(businessContext, user);
                readSingIn(businessContext, "neagucristianssstefan@yahoo.com", "morassrioan923", "0234");
                Console.Write("\n\n\n\n");
                //ReadLogIn(businessContext, "neagucristianstefan@yahoo.com", "morarioan923");
                //ShowUsers(businessContext);

            }
            Console.ReadLine();
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

        private static void ReadLogIn(BusinessContext businessContext, string email, string password)
        {
            User user = businessContext.UserBusiness.ReadLogIn(email, password);
            Console.WriteLine("Users:");

            Console.WriteLine(" Email:{0} ",
                    user.UserID);
        }
    }
         
}

