using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using System;

namespace FunctionBindingSampleApp;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        InitializeComponent();
    }
}

public class TrueToVisibleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is bool boolValue)
        {
            return boolValue is true
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        throw new ArgumentException("Value must be a `bool`.");
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

public class NotEmptyStringToVisibleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is string stringValue)
        {
            return string.IsNullOrEmpty(stringValue) is false
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        throw new ArgumentException("Value must be a 'string'.");
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}

public static class Functions
{
    public static Visibility TrueToVisible(bool value)
    {
        return value is true
            ? Visibility.Visible
            : Visibility.Collapsed;
    }

    public static Visibility NotEmptyStringToVisible(string value)
    {
        return string.IsNullOrEmpty(value) is not true
            ? Visibility.Visible
            : Visibility.Collapsed;
    }

    public static Visibility AllTrueToVisible(bool? value1, bool? value2, bool? value3)
    {
        return value1 is true && value2 is true && value3 is true
            ? Visibility.Visible
            : Visibility.Collapsed;
    }

    public static Visibility AnyTrueToVisible(bool? value1, bool? value2, bool? value3)
    {
        return value1 is true || value2 is true || value3 is true
            ? Visibility.Visible
            : Visibility.Collapsed;
    }

    public static Visibility TrueToVisible(bool isAnd, bool? value1, bool? value2, bool? value3)
    {
        return isAnd
            ? AllTrueToVisible(value1, value2, value3)
            : AnyTrueToVisible(value1, value2, value3);
    }
}