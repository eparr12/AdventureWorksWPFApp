﻿using AdventureWorksLibrary.Models;
using AdventureWorksLibrary.SqlDataAccess;
using AdventureWorksLibrary.Validators;
using AdventureWorksWPFUI.Views;
using Caliburn.Micro;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace AdventureWorksWPFUI.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            ActivateItemAsync(new LoginViewModel());
        }

        public void LogOut()
        {

            if (LoginViewModel.role == "Administrator")
            {
                var confirmResult = MessageBox.Show($"Are You Sure You Want To LogOut?",
             "Confirm LogOut.", MessageBoxButton.YesNo);
                if (confirmResult == MessageBoxResult.Yes)
                {
                    LoginViewModel.role = "";
                    ActivateItemAsync(new LoginViewModel());
                }
                else
                {
                    return;
                }
             
            }

            if (LoginViewModel.role == "Basic")
            {
                var confirmResult = MessageBox.Show($"Are You Sure You Want To LogOut?",
             "Confirm LogOut.", MessageBoxButton.YesNo);
                if (confirmResult == MessageBoxResult.Yes)
                {
                    LoginViewModel.role = "";
                    ActivateItemAsync(new LoginViewModel());
                }
                else
                {
                    return;
                }

            }
            else
            {
                return;
            }
        }

    }

    internal record struct NewStruct(object Item1, object Item2)
    {
        public static implicit operator (object, object)(NewStruct value)
        {
            return (value.Item1, value.Item2);
        }

        public static implicit operator NewStruct((object, object) value)
        {
            return new NewStruct(value.Item1, value.Item2);
        }
    }
}
