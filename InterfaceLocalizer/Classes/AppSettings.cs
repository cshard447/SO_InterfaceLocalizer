using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using InterfaceLocalizer.Properties;


namespace InterfaceLocalizer.Classes
{
    public class AppSettings
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
        private int colLanguage2Width;
        private int colLanguage3Width;
        private bool serviceColumnsVisible;
        private int settingsFormTop;
        private int settingsFormLeft;
        private int statsFormTop;
        private int statsFormLeft;
        private string pathToFiles;
        private string checkedFiles;
        private string checkedGossipFiles;
        private string pathToGossip;
        private bool spellCheckCompleteBox;
        private string languagesNames;
        private string translationFilenames;
        private string groupNames;
        private string languagesInsideGroups;
        private string filesInsideGroups;

        //******************** UI Properties*******************************************************

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
        public int ColLanguage2Width
        {
            get { return checkColumnWidth(colLanguage2Width); }
            set { colLanguage2Width = checkColumnWidth(value); }
        }
        public int ColLanguage3Width
        {
            get { return checkColumnWidth(colLanguage3Width); }
            set { colLanguage3Width = checkColumnWidth(value); }
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
        public int StatsFormLeft
        {
            get { return checkLocation(statsFormLeft); }
            set { statsFormLeft = checkLocation(value); }
        }
        public int StatsFormTop
        {
            get { return checkLocation(statsFormTop); }
            set { statsFormTop = checkLocation(value); }
        }
        
        // **************** Paths & files properties **********************************************
        
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

        public bool SpellCheckCompleteBox
        {
            get { return spellCheckCompleteBox; }
            set { spellCheckCompleteBox = value; }
        }

        public string LanguagesNames
        {
            get { return languagesNames; }
            set { languagesNames = value; }
        }
        public string TranslationFilenames
        {
            get { return translationFilenames; }
            set { translationFilenames = value; }
        }

        public string GroupNames
        {
            get { return groupNames; }
            set { groupNames = value; }
        }

        public string LanguagesInsideGroups
        {
            get { return languagesInsideGroups; }
            set { languagesInsideGroups = value; }
        }

        public string FilesInsideGroups
        {
            get { return filesInsideGroups; }
            set { filesInsideGroups = value; }
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
            ColLanguage2Width = Properties.Settings.Default.ColLang2Width;
            ColLanguage3Width = Properties.Settings.Default.ColLang3Width;

            ServiceColumnsVisible = Properties.Settings.Default.ServiceColumnsVisible;
            SettingsFormLeft = Properties.Settings.Default.SettingsFormLeft;
            SettingsFormTop = Properties.Settings.Default.SettingsFormTop;
            StatsFormLeft = Properties.Settings.Default.StatsFormLeft;
            StatsFormTop = Properties.Settings.Default.StatsFormTop;

            PathToFiles = Properties.Settings.Default.PathToFiles;
            CheckedFiles = Properties.Settings.Default.CheckedFiles;
            PathToGossip = Properties.Settings.Default.PathToGossip;
            CheckedGossipFiles = Properties.Settings.Default.CheckedGossipFiles;
            SpellCheckCompleteBox = Properties.Settings.Default.SpellCheckCompleteBox;

            LanguagesNames = Properties.Settings.Default.LanguageNames;
            TranslationFilenames = Properties.Settings.Default.TranslationFilenames;

            GroupNames = Properties.Settings.Default.GroupNames;
            LanguagesInsideGroups = Properties.Settings.Default.LanguagesInsideGroups;
            FilesInsideGroups = Properties.Settings.Default.FilesInsideGroups;
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
            Properties.Settings.Default.ColLang2Width = ColLanguage2Width;
            Properties.Settings.Default.ColLang3Width = ColLanguage3Width;

            Properties.Settings.Default.ServiceColumnsVisible = ServiceColumnsVisible;
            Properties.Settings.Default.SettingsFormLeft = SettingsFormLeft;
            Properties.Settings.Default.SettingsFormTop = SettingsFormTop;
            Properties.Settings.Default.StatsFormLeft =  StatsFormLeft;
            Properties.Settings.Default.StatsFormTop = StatsFormTop;

            Properties.Settings.Default.PathToFiles = PathToFiles;
            Properties.Settings.Default.CheckedFiles = CheckedFiles;
            Properties.Settings.Default.PathToGossip = PathToGossip;
            Properties.Settings.Default.CheckedGossipFiles = CheckedGossipFiles;
            Properties.Settings.Default.SpellCheckCompleteBox = SpellCheckCompleteBox;

            Properties.Settings.Default.LanguageNames = LanguagesNames;
            Properties.Settings.Default.TranslationFilenames = TranslationFilenames;

            Properties.Settings.Default.GroupNames = GroupNames;
            Properties.Settings.Default.LanguagesInsideGroups  =LanguagesInsideGroups;
            Properties.Settings.Default.FilesInsideGroups = FilesInsideGroups;

            Properties.Settings.Default.Save();
        }

        private int checkSize(int size)
        {
            if (size > 200 && size < 2500)
                return size;
            else
                return 400;
        }
        private int checkLocation(int location)
        {
            if (location >= -10 && location < 1500)
                return location;
            else
                return 0;
        }
        private int checkColumnWidth(int width)
        {
            if (width > 10 && width < 1000)
                return width;
            else
                return 100;
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
