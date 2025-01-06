using MaterialSkin;
using SchoolworkOrganizer.Popup;
using SchoolworkOrganizerUtils;

namespace SchoolworkOrganizer
{
    internal static class Program
    {
        public static readonly Client client = new Client();
        public static User? user => client.user;
        public static bool IsLoggedIn => user != null;
        public static void Logout() => client.Logout();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                _ = client.ConnectAsync();
            }
            catch(Exception ex)
            {
                PopupForm.Show($"An error occurred: {ex.InnerException?.Message ?? ex.Message}");
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(Color.FromArgb(43, 49, 65), Color.FromArgb(34, 40, 54), Color.FromArgb(65, 78, 101), Color.FromArgb(95, 192, 170), MaterialSkin.TextShade.WHITE);

            //User.LoadUsers();
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginPanel());
        }


    }
}