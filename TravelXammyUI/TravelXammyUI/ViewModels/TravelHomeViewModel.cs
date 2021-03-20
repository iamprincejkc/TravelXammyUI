using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TravelXammyUI.Models;
using Xamarin.Essentials;

namespace TravelXammyUI.ViewModels
{
    public class TravelHomeViewModel : BindableBase
    {
        public ObservableCollection<int> obsanio { get; set; }
        public ObservableCollection<TravelSchedule> travelSchedule { get; set; }
        public TravelHomeViewModel()
        {
            obsanio = new ObservableCollection<int>();

            for (int i = 1; i <= 29; i++)
            {
                obsanio.Add(i);
            }

            travelSchedule = new ObservableCollection<TravelSchedule>
            {
                new TravelSchedule
                {
                     Time = "08:00 AM",
                     Picture = "Place1",
                     Name="Walking Tour",
                     Adress1 = "191 Sutter St.",
                     Adress2 = "CA 91929",
                     TransportType = "Car",
                     TransportColor = ColorConverters.FromHex("#31bea6")
        },
                new TravelSchedule
                {
                     Time = "10:00 AM",
                     Picture = "Place2",
                     Name="LightHouse",
                     Adress1 = "192 Sutter St.",
                     Adress2 = "CA 91929",
                     TransportType = "Walking",
                     TransportColor = ColorConverters.FromHex("#e0995e")

                },
                new TravelSchedule
                {
                     Time = "01:30 PM",
                     Picture = "Place3",
                     Name="Beach Tour",
                     Adress1 = "194 Sutter St.",
                     Adress2 = "CA 91929",
                     TransportType = "Motor",
                     TransportColor = ColorConverters.FromHex("#76c2af")
                },
                 new TravelSchedule
                {
                     Time = "04:30 PM",
                     Picture = "Place4",
                     Name="Island",
                     Adress1 = "200 Sutter St.",
                     Adress2 = "CA 91929",
                     TransportType = "Walking",
                     TransportColor = ColorConverters.FromHex("#e0995e")
                }
            };
        }
    }
}
