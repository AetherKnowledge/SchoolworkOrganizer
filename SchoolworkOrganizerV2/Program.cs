using MaterialSkin;
using SchoolworkOrganizerUtils;

namespace SchoolworkOrganizer
{
    internal static class Program
    {
        private readonly static Uri uri = new Uri("ws://localhost:5000/ws");
        public static Client client = new Client(uri);

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _ = client.ConnectAsync();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(Color.FromArgb(43, 49, 65), Color.FromArgb(34, 40, 54), Color.FromArgb(65, 78, 101), Color.FromArgb(212, 231, 197), MaterialSkin.TextShade.WHITE);

            //User.LoadUsers();
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginPanel());
        }


    }
}