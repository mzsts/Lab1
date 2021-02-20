using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private int Age { get; set; }
        public MainPage()
        {
            InitializeComponent();
            dataPicker.Date = DateTime.Now;
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(FirstName) && String.IsNullOrEmpty(LastName))
                DisplayAlert("Ошибка!", "Заполните все поля", "ОК");
            else if (Age == -1)
                DisplayAlert(FirstName + " " + LastName, "Похоже вы ещё не родились)", "ОК");
            else
            {
                DisplayAlert(FirstName + " " + LastName, "Сейчас вам " + Age.ToString() + MakeCorrectWord(), "ОК");
            }
        }

        void OnFirstNameEntryCompleted(object sender, EventArgs e)
        {
            FirstName = ((Entry)sender).Text;
        }

        void OnLastNameEntryCompleted(object sender, EventArgs e)
        {
            LastName = ((Entry)sender).Text;
        }

        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            DateTime DateOfBorn = ((DatePicker)sender).Date;
            CalculateAge(DateOfBorn);
        }

        void CalculateAge(DateTime dateOfBorn)
        {
            if (dateOfBorn > DateTime.Now)
            {
                Age = -1;
            }
            else
            {
                Age = DateTime.Now.Year - dateOfBorn.Year;
            }
        }

        private string MakeCorrectWord()
        {
            string word;
            if (Age % 10 == 1 && (Age < 10 || Age > 20))
                word = " год";
            else if (Age % 10 > 1 && Age % 10 < 5 && (Age < 10 || Age > 20))
                word = " года";
            else
                word = " лет";
            return word;
        }
    }
}
