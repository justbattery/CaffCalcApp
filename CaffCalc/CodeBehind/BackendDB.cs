using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Windows;

namespace CaffCalc.CodeBehind
{
    internal class BackendDB
    {
        public static Users User; // UŻYTKOWNIK JEDEN JEDYNY

        public static List<Drink> drinks = new List<Drink>(); // NAPOJE WSZYSTKIE
        public static int DrinkId = 1; // ID (?)

        // STATYSTYKI DO DZIENNEGO
        public static string DateToday = DateTime.Now.ToString("d"); // DATA
        public static int TodaysCaffeineConsumption; // TO CO WYPIŁ DZISIAJ
        public static int HowMuchLeft; // ILE MU ZOSTAŁO
        public static int safeDailyDose; // TYLE MOŻE WYPIĆ

        public static List<TodaysDrinks> TodaysDrinksList = new List<TodaysDrinks>(); // LISTA DZISIAJ WYPITYCH

        [DataMember] public static Dictionary<string, DailyConsumption> dailyConsumption = new Dictionary<string, DailyConsumption>(); // SŁOWNIK RESZTY STATYSTYK

        // STARY KOD // DO DECYZJI !!!!!!!!!!!!!!!
        // DANE UŻYTKOWNIKA
        //public static void UserToFile()
        //{
        //    DataContractSerializer userSerializer = new DataContractSerializer(typeof(Users));
        //    using (FileStream userStream = new FileStream(@"Resources\Data\UserData.xml", FileMode.Create))
        //    {
        //        userSerializer.WriteObject(userStream, User);
        //    }
        //}
        //public static void UserFromFile() 
        //{
        //    if (File.Exists(@"Resources\Data\UserData.xml"))
        //    {
        //        DataContractSerializer userSerializer = new DataContractSerializer(typeof(Users));
        //        using (FileStream userStream = new FileStream(@"Resources\Data\UserData.xml", FileMode.Open))
        //        {
        //            User = (Users)userSerializer.ReadObject(userStream);
        //        }
        //    }
        //}
        //
        // Dane napoju
        //public static void DrinkToFile()
        //{
        //    DataContractSerializer drinkSerializer = new DataContractSerializer(typeof(List<Drink>));
        //    using (FileStream drinkStream = new FileStream(@"Resources\Data\DrinkList.xml", FileMode.Create))
        //    {
        //        drinkSerializer.WriteObject(drinkStream, drinks);
        //    }
        //}
        //public static void DrinkFromFile()
        //{
        //    if (File.Exists(@"Resources\Data\DrinkList.xml"))
        //    {
        //        DataContractSerializer drinkSerializer = new DataContractSerializer(typeof(List<Drink>));
        //        using (FileStream drinkStream = new FileStream(@"Resources\Data\DrinkList.xml", FileMode.Open))
        //        {
        //            drinks = (List<Drink>)drinkSerializer.ReadObject(drinkStream);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("BŁĄD: BRAK PLIKU DrinkList.xml");
        //    }
        //}

        // Obliczanie dziennej dawki
        public static (int, int) CalcSafeDailyDose()
        {
            if (File.Exists(@"Resources\Data\UserData.xml"))
            {
                return (safeDailyDose = 6 * User.WeightKg, HowMuchLeft = safeDailyDose);
            }
            else
            {
                return (0, 0);
            }
        }

        // Statystyki
        public static void SaveStatsToDictionary() // ZAPIS NAPOJÓW DO SŁOWNIKA
        {
            if (dailyConsumption.ContainsKey(DateToday))
            {
                dailyConsumption[DateToday] = new DailyConsumption
                {
                    HowMuchLeftThatDay = HowMuchLeft,
                    HowMuchConsumedThatDay = TodaysCaffeineConsumption,
                    drinksConsumedThatDay = TodaysDrinksList
                };
            }
            else dailyConsumption.Add(DateToday, new DailyConsumption
            {
                HowMuchLeftThatDay = HowMuchLeft,
                HowMuchConsumedThatDay = TodaysCaffeineConsumption,
                drinksConsumedThatDay = TodaysDrinksList
            });
        }
        //public static void SaveStatsToFile() // ZAPIS STATYSTYK NAPOJÓW DO PLIKU
        //{
        //    DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<string, DailyConsumption>));
        //    using (FileStream stats = new FileStream(@"Resources\Data\StatsDrinks.xml", FileMode.Create))
        //    {
        //        serializer.WriteObject(stats, dailyConsumption);
        //    }
        //}
        public static void GetStatsFromFile()
        {
            if (File.Exists(@"Resources\Data\StatsDrinks.xml"))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<string, DailyConsumption>));
                using (FileStream stats = new FileStream(@"Resources\Data\StatsDrinks.xml", FileMode.Open))
                {
                    dailyConsumption = (Dictionary<string, DailyConsumption>)serializer.ReadObject(stats);
                }
                if (dailyConsumption.ContainsKey(DateToday))
                {
                    HowMuchLeft = dailyConsumption[DateToday].HowMuchLeftThatDay;
                    TodaysCaffeineConsumption = dailyConsumption[DateToday].HowMuchConsumedThatDay;
                    TodaysDrinksList = dailyConsumption[DateToday].drinksConsumedThatDay;
                }
            }
        }
    }
}
