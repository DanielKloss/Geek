using Windows.Storage;

namespace TheGeek.UserInterface.Controllers
{
    public class SettingsController
    {
        private const string _username = "username";

        public object GetUsername()
        {
            return ApplicationData.Current.LocalSettings.Values[_username];
        }

        public void SetUsername(string username)
        {
            ApplicationData.Current.LocalSettings.Values[_username] = username;
        }
    }
}
