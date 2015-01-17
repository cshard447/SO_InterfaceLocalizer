using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using InterfaceLocalizer.Properties;


namespace InterfaceLocalizer.Classes
{
    class AppSettings
    {
        private int mainFormTop;
        private int mainFormLeft;
        private int mainFormWidth;
        private int mainFormHeight;
        private int colIDWidth;
        private int colFilenameWidth;
        private int colTagsWidth;
        private int colRusWidth;
        private int colEngWidth;
        private bool serviceColumnsVisible;
        private int settingsFormTop;
        private int settingsFormLeft;
        private string pathToFiles;
        private string checkedFiles;
        private string checkedGossipFiles;
        private string pathToGossip;

        public int MainFormTop
        {
            get { return checkLocation(mainFormTop); }
            set { mainFormTop = checkLocation(value); }
        }
        public int MainFormLeft
        {
            get { return checkLocation(mainFormLeft); }
            set { mainFormLeft = checkLocation(value); }
        }
        public int MainFormHeight
        {
            get { return checkSize(mainFormHeight); }
            set { mainFormHeight = checkSize(value); }
        }
        public int MainFormWidth
        {
            get { return checkSize(mainFormWidth); }
            set { mainFormWidth = checkSize(value); }
        }
        public int ColIDWidth
        {
            get { return checkColumnWidth(colIDWidth); }
            set { colIDWidth = checkColumnWidth(value); }
        }
        public int ColFilenameWidth
        {
            get { return checkColumnWidth(colFilenameWidth); }
            set { colFilenameWidth = checkColumnWidth(value); }
        }
        public int ColTagsWidth
        {
            get { return checkColumnWidth(colTagsWidth); }
            set { colTagsWidth = checkColumnWidth(value); }
        }
        public int ColRusWidth
        {
            get { return checkColumnWidth(colRusWidth); }
            set { colRusWidth = checkColumnWidth(value); }
        }
        public int ColEngWidth
        {
            get { return checkColumnWidth(colEngWidth); }
            set { colEngWidth = checkColumnWidth(value); }
        }
        public bool ServiceColumnsVisible
        {
            get { return serviceColumnsVisible; }
            set { serviceColumnsVisible = value; }
        }
        public int SettingsFormLeft
        {
            get { return checkLocation(settingsFormLeft); }
            set { settingsFormLeft = checkLocation(value); }
        }
        public int SettingsFormTop
        {
            get { return checkLocation(settingsFormTop); }
            set { settingsFormTop = checkLocation(value); }
        }
        
	    public string PathToFiles
	    {
		    get { return checkPath(pathToFiles);}
		    set { pathToFiles = checkPath(value);}
	    }

	    public string CheckedFiles
	    {
		    get { return checkedFiles;}
		    set { checkedFiles = value;}
	    }

	    public string PathToGossip
	    {
		    get { return checkPath(pathToGossip);}
		    set { pathToGossip = checkPath(value);}
	    }

	    public string CheckedGossipFiles
	    {
		    get { return checkedGossipFiles;}
		    set { checkedGossipFiles = value;}
	    }

        public AppSettings()
        {
            MainFormTop = Properties.Settings.Default.MainFormTop;
            MainFormLeft = Properties.Settings.Default.MainFormLeft;
            MainFormHeight = Properties.Settings.Default.MainFormHeight;
            MainFormWidth = Properties.Settings.Default.MainFormWidth;

            ColIDWidth = Properties.Settings.Default.ColIDWidth;
            ColFilenameWidth = Properties.Settings.Default.ColFilenameWidth;
            ColTagsWidth = Properties.Settings.Default.ColTagsWidth;
            ColRusWidth = Properties.Settings.Default.ColRusWidth;
            ColEngWidth = Properties.Settings.Default.ColEngWidth;

            ServiceColumnsVisible = Properties.Settings.Default.ServiceColumnsVisible;

            PathToFiles = Properties.Settings.Default.PathToFiles;
            CheckedFiles = Properties.Settings.Default.CheckedFiles;
            PathToGossip = Properties.Settings.Default.PathToGossip;
            CheckedGossipFiles = Properties.Settings.Default.CheckedGossipFiles;

            SettingsFormLeft = Properties.Settings.Default.SettingsFormLeft;
            SettingsFormTop = Properties.Settings.Default.SettingsFormTop;
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.MainFormTop = MainFormTop;
            Properties.Settings.Default.MainFormLeft = MainFormLeft;
            Properties.Settings.Default.MainFormHeight = MainFormHeight;
            Properties.Settings.Default.MainFormWidth = MainFormWidth;

            Properties.Settings.Default.ColIDWidth = ColIDWidth;
            Properties.Settings.Default.ColFilenameWidth = ColFilenameWidth;
            Properties.Settings.Default.ColTagsWidth = ColTagsWidth;
            Properties.Settings.Default.ColRusWidth = ColRusWidth;
            Properties.Settings.Default.ColEngWidth = ColEngWidth;

            Properties.Settings.Default.ServiceColumnsVisible = ServiceColumnsVisible;
            Properties.Settings.Default.SettingsFormLeft = SettingsFormLeft;
            Properties.Settings.Default.SettingsFormTop = SettingsFormTop;

            Properties.Settings.Default.PathToFiles = PathToFiles;
            Properties.Settings.Default.CheckedFiles = CheckedFiles;
            Properties.Settings.Default.CheckedFiles = PathToGossip;
            Properties.Settings.Default.CheckedGossipFiles = CheckedGossipFiles;

            Properties.Settings.Default.Save();
        }

        private int checkSize(int size)
        {
            if (size > 50 && size < 2000)
                return size;
            else
                return 400;
        }
        private int checkLocation(int location)
        {
            if (location > 0 && location < 1000)
                return location;
            else
                return 50;
        }
        private int checkColumnWidth(int width)
        {
            if (width > 10 && width < 500)
                return width;
            else
                return 50;
        }
        private string checkPath(string path)
        {
            if (Directory.Exists(path))
                return path;
            else
                return Directory.GetCurrentDirectory();
        }
    }
}
