using SchoolworkOrganizer.Panels;
using SchoolworkOrganizer.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolworkOrganizer
{
    internal static class OpenPanels
    {
        public static LoginPanel loginPage = new LoginPanel();
        public static RegisterPanel registerPage = new RegisterPanel();
        public static AdminPage adminPage = new AdminPage();
        //public static HomePanel homePanel = new HomePanel();
        //public static SettingsPanel settingsPanel = new SettingsPanel();
        //public static SubjectsPanel subjectsPanel = new SubjectsPanel();
        //public static ActivitiesPanel activitiesPanel = new ActivitiesPanel();
        //public static ReviewerPanel reviewerPanel = new ReviewerPanel();

    }
}
