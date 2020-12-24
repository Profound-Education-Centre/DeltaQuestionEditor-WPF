﻿using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DeltaQuestionEditor_WPF.Helpers
{
    class SeverityToPackIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as Models.Validation.ProblemSeverity?).GetValueOrDefault() == Models.Validation.ProblemSeverity.Error ? PackIconKind.CloseCircle : PackIconKind.Alert;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
