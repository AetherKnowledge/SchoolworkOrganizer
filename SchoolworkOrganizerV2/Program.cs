using MaterialSkin;

namespace SchoolworkOrganizerV2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(Color.FromArgb(43, 49, 65), Color.FromArgb(34, 40, 54), Color.FromArgb(65, 78, 101), Color.FromArgb(212, 231, 197), MaterialSkin.TextShade.WHITE);


            ApplicationConfiguration.Initialize();
            Application.Run(new LoginPanel());
        }
    }
}