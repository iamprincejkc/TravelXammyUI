using System;
using Xamarin.Forms;

namespace TravelXammyUI.Views
{
    public partial class TravelHome : ContentPage
    {
        Button lastButton;
        public TravelHome()
        {
            NavigationPage.SetHasNavigationBar(this,false);
            InitializeComponent();

            for (int i = 1; i <= DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); i++)
            {
                Button btn = new Button()
                {
                    Text = $"{i}",
                    TextColor = Color.Black,
                    Padding = new Thickness(20, 5),
                    BackgroundColor = Color.Transparent
                };
                btn.Clicked += (sender, EventArgs) =>
                {
                    if (lastButton != null)
                    {
                        VisualStateManager.GoToState(lastButton, "DayUnSelected");
                    }
                    VisualStateManager.GoToState((Button)sender, "DaySelected");
                    lastButton = (Button)sender;
                };
                DaysBlock.Children.Add(btn);
            }
        }

    }
}
