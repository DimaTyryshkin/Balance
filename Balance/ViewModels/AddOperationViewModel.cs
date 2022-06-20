using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Balance.Models;

namespace Balance.ViewModels
{
    public class AddOperationViewModel : ViewModel
    {
        public ObservableCollection<string> AvailableTypes { get; set; }
        public ObservableCollection<string> AvailableCategoryes { get; set; }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }

        string summ;
        public string Summ
        {
            get => summ;
            set
            {
                if (summ != value)
                {
                    summ = value;
                    SaveCommand.RaiseCanExecuteChanged();
                    NotifyPropertyChanged();
                }
            }
        }

        string selectedOperationType;
        public string SelectedOperationType
        {
            get { return selectedOperationType; }
            set
            {
                if (value != selectedOperationType)
                {
                    selectedOperationType = value;

                    // В зависимости от типа операции, меняем возможные варианты категорий операции
                    AvailableCategoryes.Clear();
                    foreach (var item in Operation.GetCategoryesByType(value))
                        AvailableCategoryes.Add(item);

                    SelectedOperationCategory = AvailableCategoryes[0];

                    NotifyPropertyChanged();
                }
            }
        }

        string selectedOperationCategory;
        public string SelectedOperationCategory
        {
            get { return selectedOperationCategory; }
            set
            {
                if (value != selectedOperationCategory)
                {
                    selectedOperationCategory = value;
                    NotifyPropertyChanged();
                }
            }
        }

        string description;
        public string Description
        {
            get { return description; }
            set
            {
                if (value != description)
                {
                    description = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public AddOperationViewModel()
        {
            SaveCommand = new RelayCommand(SaveOperation, IsInputValid);
            ResetCommand = new RelayCommand(Reset);

            AvailableTypes = new ObservableCollection<string>(Operation.operationTypes);
            AvailableCategoryes = new ObservableCollection<string>();
            Reset();
        }

        /// <summary>
        /// Возвращает true, если пользователь корректно вел сумму.
        /// </summary>
        bool IsInputValid()
        {
            if (Summ.Length == 0)
                return false;

            if (double.TryParse(Summ, NumberStyles.Any, CultureInfo.InvariantCulture, out double summ))
                return true;

            return false;
        }

        void SaveOperation()
        {
            Debug.WriteLine("SaveOperation");
            bool isInputOk = IsInputValid();

            if (isInputOk)
            {
                // Для простоты будем считать только целые числа.
                // На сколько я знаю, в серьезных программах банковских числа с правающей точкой не используются. 
                double summInt = double.Parse(Summ, CultureInfo.InvariantCulture);

                var newOperation = new Operation
                {
                    DateTime = DateTime.Now,
                    Type = SelectedOperationType,
                    Category = SelectedOperationCategory,
                    Summ = summInt,
                    Description = Description,
                };

                SaveOperation(newOperation);
            }
        }

        void SaveOperation(Operation newOperation)
        {
            using (SQLiteContext db = new SQLiteContext())
            {
                db.Operations.Add(newOperation);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Сбрасывает вид страницы к некому начальному состоянию.
        /// </summary>
        void Reset()
        {
            Summ = "0";
            Description = null;
            SelectedOperationType = AvailableTypes[0];
            SelectedOperationCategory = AvailableCategoryes[0];
        }
    }
}