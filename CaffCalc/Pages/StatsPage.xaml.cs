using CaffCalc.CodeBehind;
using CaffCalc.Pages.PagesFunctions.StatsPageFunctions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security;
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
using static CaffCalc.Pages.SumUpCaffeine;

namespace CaffCalc.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy StatsPage.xaml
    /// </summary>
    
    // NOTES
    // - Ogarnij końcówkę kodu bo Ci wyświetlanie procentowego udziału nie działa

    public partial class StatsPage : Page
    {
        public StatsPage()
        {
            InitializeComponent();
            GetStatsFromFile();

            SumUpCaffeine sumUp = new SumUpCaffeine();
            int sumConsumption = sumUp.SumUpCaffeineFunction(0);

            // Obliczanie min, max, średniej, dnia w którym to było

            StatsAssignment stats = new StatsAssignment(); /// Funkcja odpowiadająca za przypisanie

            var maxValues = stats.AssignMaxValue(sumConsumption);

            int maxConsumption = maxValues.Item1;
            string dayMaxConsumption = maxValues.Item2;

            var minValues = stats.AssignMinValue(sumConsumption);

            int minConsumption = minValues.Item1;
            string dayMinConsumption = minValues.Item2;

            int avgConsumption = stats.CalcAverageValue(sumConsumption);

            // ZAPIS SUMY DLA POSZCZEGÓLNYCH NAPOJÓW

            var everyDrink = dailyConsumption.Values.SelectMany(t => t.drinksConsumedThatDay)
                .GroupBy(t => t.Name)
                .Select(g =>
            new {
                Name = g.Key,
                Count = g.Sum(s => s.Count)
            });
            
            // ZAPIS SUMY

            // FUNKCJA TWORZĄCA PROCENTOWY UDZIAŁ
            int totalDrinksSum = 0;
            foreach (var drinkSum in everyDrink)
            {
                totalDrinksSum += drinkSum.Count; /// SUMA WSZYSTKICH NAPOJÓW
            }
            string drinkList = "Procentowy udział: ";
            foreach (var drink in everyDrink)
            {
                float drinkPercentage = (float)Math.Round((double)100 * drink.Count) / totalDrinksSum;
                drinkList += $"\n{drink.Name} - {drinkPercentage}%";
            }
            // KONIEC FUNKCJI TWORZĄCEJ PROCENTOWY UDZIAŁ

            // WYŚWIETLANIE I OUTPUT
            AvgCaffeine_TextBlock.Text = $"Avg: {avgConsumption}";
            MaxCaffeine_TextBlock.Text = $"Max: {maxConsumption} Dnia: {dayMaxConsumption}";
            MinCaffeine_TextBlock.Text = $"Max: {minConsumption} Dnia: {dayMinConsumption}";
            DrinksPercentage_TextBlock.Text = drinkList;
            CaffeineTolerance_TextBlock.Text = $"Tolerancja: {safeDailyDose}";
            // WYŚWIETLANIE I OUTPUT

            // FUNKCJA SORTOWANIE I DATA
            string lastTimeDosed = dailyConsumption.OrderByDescending(x => x.Key).First().Key;
            string format = "dd.MM.yyyy";
            string caffeineToleranceEnd = DateTime.ParseExact(lastTimeDosed, format, CultureInfo.InvariantCulture).AddDays(14).ToString("d");

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
            // KONIEC SORTOWANIE I DATA
        }
    }
}
