using System;
using Windows.Storage;

namespace TheGeek.UserInterface.Controllers
{
    public class SettingsController
    {
        private const string _username = "username";
        private const string _numberOfPlayers = "numberOfPlayers";
        private const string _minimumRating = "minimumRating";
        private const string _maximumRating = "maximumRating";
        private const string _minimumAverageRating = "minimumAverageRating";
        private const string _maximumAverageRating = "maximumAverageRating";
        private const string _minimumComplexity = "minimumComplexity";
        private const string _maximumComplexity = "maximumComplexity";
        private const string _minimumLength = "minimumLength";
        private const string _maximumLength = "maximumLength";
        private const string _isFiltered = "isFiltered";
        private const string _searchTerm = "searchTerm";
        private const string _categoryIndex = "categoryIndex";

        public string GetUsername()
        {
            return ApplicationData.Current.LocalSettings.Values[_username].ToString();
        }

        public void SetUsername(string username)
        {
            ApplicationData.Current.LocalSettings.Values[_username] = username;
        }

        public string GetSearchTerm()
        {
            return ApplicationData.Current.LocalSettings.Values[_searchTerm]?.ToString();
        }

        public int GetCategoryIndex()
        {
            return Convert.ToInt32(ApplicationData.Current.LocalSettings.Values[_categoryIndex]);
        }

        public void SetSearch(string searchTerm, int CategoryIndex)
        {
            ApplicationData.Current.LocalSettings.Values[_searchTerm] = searchTerm;
            ApplicationData.Current.LocalSettings.Values[_categoryIndex] = CategoryIndex;
        }

        public void SetIsFiltered(bool isFiltered)
        {
            ApplicationData.Current.LocalSettings.Values[_isFiltered] = isFiltered;
        }

        public bool GetIsFiltered()
        {
            return Convert.ToBoolean(ApplicationData.Current.LocalSettings.Values[_isFiltered]);
        }

        public void SetFilters(int numberOfPlayers, double minimumRating, double maximumRating, double minimumAverageRating, double maximumAverageRating, double minimumComplexity, double maximumComplexity, int minimumLength, int maximumLength)
        {
            ApplicationData.Current.LocalSettings.Values[_numberOfPlayers] = numberOfPlayers;
            ApplicationData.Current.LocalSettings.Values[_minimumRating] = minimumRating;
            ApplicationData.Current.LocalSettings.Values[_maximumRating] = maximumRating;
            ApplicationData.Current.LocalSettings.Values[_minimumAverageRating] = minimumAverageRating;
            ApplicationData.Current.LocalSettings.Values[_maximumAverageRating] = maximumAverageRating;
            ApplicationData.Current.LocalSettings.Values[_minimumComplexity] = minimumComplexity;
            ApplicationData.Current.LocalSettings.Values[_maximumComplexity] = maximumComplexity;
            ApplicationData.Current.LocalSettings.Values[_minimumLength] = minimumLength;
            ApplicationData.Current.LocalSettings.Values[_maximumLength] = maximumLength;
        }

        public int GetNumberOfPlayers()
        {
            return Convert.ToInt32(ApplicationData.Current.LocalSettings.Values[_numberOfPlayers]);
        }

        public double GetMinimumRating()
        {
            return Convert.ToDouble(ApplicationData.Current.LocalSettings.Values[_minimumRating]);
        }

        public double GetMaximumRating()
        {
            return Convert.ToDouble(ApplicationData.Current.LocalSettings.Values[_maximumRating]);
        }

        public double GetMinimumAverageRating()
        {
            return Convert.ToDouble(ApplicationData.Current.LocalSettings.Values[_minimumAverageRating]);
        }

        public double GetMaximumAverageRating()
        {
            return Convert.ToDouble(ApplicationData.Current.LocalSettings.Values[_maximumAverageRating]);
        }

        public double GetMinimumComplexity()
        {
            return Convert.ToDouble(ApplicationData.Current.LocalSettings.Values[_minimumComplexity]);
        }

        public double GetMaximumComplexity()
        {
            return Convert.ToDouble(ApplicationData.Current.LocalSettings.Values[_maximumComplexity]);
        }

        public int GetMinimumLength()
        {
            return Convert.ToInt32(ApplicationData.Current.LocalSettings.Values[_minimumLength]);
        }

        public int GetMaximumLength()
        {
            return Convert.ToInt32(ApplicationData.Current.LocalSettings.Values[_maximumLength]);
        }
    }
}
