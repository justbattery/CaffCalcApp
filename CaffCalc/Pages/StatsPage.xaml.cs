using CaffCalc.CodeBehind;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static CaffCalc.CodeBehind.BackendDB;

namespace CaffCalc.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy StatsPage.xaml
    /// </summary>
    
    // NOTES
    // - Ogarnij końcówkę kodu bo Ci wyświetlanie procentowego udziału nie działa
    // - Zrób resztę
    public partial class StatsPage : Page
    {
        public StatsPage()
        {
            InitializeComponent();
            GetStatsFromFile();

            int sumConsumption = 0;
            int sumLeft = 0;
            foreach (var stats in dailyConsumption)
            {
                sumConsumption += stats.Value.HowMuchConsumedThatDay;
                sumLeft += stats.Value.HowMuchLeftThatDay;
            }
            // Obliczanie min, max, średniej, dnia w którym to było // KOD WZIĘTY Z PIERWSZEJ WERSJI
            int maxConsumption;
            string dayMaxConsumption;
            int minConsumption;
            string dayMinConsumption;

            int maxLeft;
            int minLeft;

            int avgConsumption;
            int avgLeft;
            if (File.Exists(@"Resources\Data\StatsDrinks.xml"))
            {
                maxConsumption = dailyConsumption.Max(x => x.Value.HowMuchConsumedThatDay);
                dayMaxConsumption = dailyConsumption.OrderByDescending(x => x.Value.HowMuchConsumedThatDay).First().Key;
                minConsumption = dailyConsumption.Min(x => x.Value.HowMuchConsumedThatDay);
                dayMinConsumption = dailyConsumption.OrderByDescending(x => x.Value.HowMuchConsumedThatDay).Last().Key;

                // ?? ZDECYDUJ
                    maxLeft = dailyConsumption.Max(x => x.Value.HowMuchLeftThatDay);
                    minLeft = dailyConsumption.Min(x => x.Value.HowMuchLeftThatDay);
                // ??

                avgConsumption = sumConsumption / dailyConsumption.Count();
                avgLeft = sumLeft / dailyConsumption.Count();
            }
            else
            {
                maxConsumption = 0;
                dayMaxConsumption = "0";
                minConsumption = 0;
                dayMinConsumption = "0";

                // ?? ZDECYDUJ
                    maxLeft = 0;
                    minLeft = 0;
                // ??

                avgConsumption = 0;
                avgLeft = 0;
            }
            AvgCaffeine_TextBlock.Text = $"Avg: {avgConsumption}";
            MaxCaffeine_TextBlock.Text = $"Max: {maxConsumption} Dnia: {dayMaxConsumption}";
            MinCaffeine_TextBlock.Text = $"Max: {minConsumption} Dnia: {dayMinConsumption}";

            // ZAPIS SUMY DLA POSZCZEGÓLNYCH NAPOJÓW
            var everyDrink = dailyConsumption.Values.SelectMany(t => t.drinksConsumedThatDay)
                .GroupBy(t => t.Name)
                .Select(g =>
            new {
                Name = g.Key,
                Count = g.Sum(s => s.Count)
            });

            int totalDrinksSum = 0;
            foreach (var drinkSum in everyDrink)
            {
                totalDrinksSum += drinkSum.Count; // SUMA WSZYSTKICH NAPOJÓW
            }
            string drinkList = "Procentowy udział:";
            foreach (var drink in everyDrink)
            {
                float drinkPercentage = (float)Math.Round((double)100 * drink.Count) / totalDrinksSum;
                drinkList = $"{drink.Name} - {drinkPercentage}%";
                string TEST = $"{drink.Name} - {drinkPercentage}%";
            }

            MessageBox.Show($"{totalDrinksSum}");
            //DrinksPercentage_TextBlock.Text = drinkList;
            string lastTimeDosed = dailyConsumption.OrderByDescending(x => x.Key).First().Key;
            string format = "dd.MM.yyyy";
            string caffeineToleranceEnd = DateTime.ParseExact(lastTimeDosed, format, CultureInfo.InvariantCulture).AddDays(14).ToString("d");

            // KONIEC PRZEJEBANEGO KODU

            if (File.Exists(@"Resources\Data\StatsDrinks.xml"))
            {
                var collection = new ObservableCollection<DataGridItem>(
                    dailyConsumption.Select(kv => new DataGridItem { Key = kv.Key, Value = kv.Value }));
                caffeineAbuseStats.ItemsSource = collection;
            }
            else
            {
                TextBlock noStats_TextBlock = new TextBlock();
                noStats_TextBlock.Text = "Jeszcze nic nie wypiłeś";

                statsPage_Grid.Children.Add(noStats_TextBlock); // DO POPRAWY
            }
        }
    }
}
