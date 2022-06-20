using System;
using System.Collections.Generic; 
using System.Linq; 
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls; 

using Balance.Models;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace Balance.Views
{
    public sealed partial class AddOperation : Page
    { 
        string operationType;
        string[] operationCategoryes;

        public string Summ { get; set; }
        public string Description { get; set; }
        public List<string> availableTypes;
        public ObservableCollection<string> availableCategoryes;

        public string OperationType
        {
            get => operationType;
            set
            {
                if (value != null && value != operationType)
                {
                    operationType = value;

                    // В зависимости от типа операции, меняем возможные варианты категорий операции
                    operationCategoryes = Operation.GetCategoryesByType(value);
                    categoryComboBox.ItemsSource = operationCategoryes;
                    categoryComboBox.SelectedIndex = 0;
                }
            }
        }

        public string OperationCategory
        {
            get;
            set;
        }

        public AddOperation()
        {
            this.InitializeComponent();
            typeComboBox.ItemsSource = Operation.operationTypes;

            Reset();
            categoryComboBox.SelectedItem = operationCategoryes[0];
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            bool isInputOk = Summ.Length > 0 && Summ.All(char.IsDigit);

            if (isInputOk)
            {
                // Для простоты будем считать только целые числа.
                // На сколько я знаю, в серьезных программах банковских числа с правающей точкой не используются. 
                int summInt = int.Parse(Summ);

                var newOperation = new Operation
                {
                    DateTime = DateTime.Now,
                    Type = operationType,
                    Category = OperationCategory,
                    Summ = summInt,
                    Description = Description,
                };

                using (SQLiteContext db = new SQLiteContext())
                {
                    db.Operations.Add(newOperation);
                    db.SaveChanges();
                }
            }
            else
            {
                ContentDialog deleteFileDialog = new ContentDialog()
                {

                    Title = "Плохие данные",
                    Content = "Введите сумму операции, в виде цифр",
                    PrimaryButtonText = "ОК"
                };

                ContentDialogResult result = await deleteFileDialog.ShowAsync();
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        /// <summary>
        /// Сбрасывает вид страницы к некому начальному состоянию.
        /// </summary>
        void Reset()
        {
            Summ = "0";
            Description = null;
            OperationType = Operation.operationTypes[0];

            Bindings.Update();
        }
    }
}