﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CapaPresentacionWPF
{
    public class Validaciones: ValidationRule
    {
        private string _pass1;

        public string Pass1
        {
            get { return _pass1; }
            set { _pass1 = value; }
        }

        public override ValidationResult Validate(object value,
           CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "value cannot be empty.");
            else
            {
                if (value.ToString().Length > 3)
                    return new ValidationResult(false, "Name cannot be more than 3 characters long.");
            }
            return ValidationResult.ValidResult;


            // return (value is string && !string.IsNullOrEmpty(value.ToString()))? new ValidationResult(true, null): new ValidationResult(false, "Invalid Text");

        }
    }
}

