﻿using SchoolworkOrganizer.Panels;

namespace SchoolworkOrganizer
{
    internal static class OpenPanels
    {
        public static Point location = new Point(0, 0);
        public static Size size = new Size(1280, 720);
        public static FormWindowState windowState = FormWindowState.Normal;

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
