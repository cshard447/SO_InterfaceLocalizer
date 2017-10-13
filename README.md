# SO_InterfaceLocalizer
Tool for translating your applications. Supports up to 4 languages at the same time. Supports resources in .xml, .strings, .properties, .txt and other formats.

To use this tool as a console application, do the following:
1. Run the CmdTranslationChecker with command line arguments, where specify full paths to the files. Minimum number of files is two, maximum is not limited.
2. Files could be .xml, .strings, .properties or other extensions. Structure should be like plain XML or Key=Value. 
3. Specify /s parameter to start in a silent mode. No statistics, just a result in exit code.
4. Program detects two types of failure:
  - no translation, it means that key or value is missing in one of the files, and present in other files.
  - duplicate, which means that value is not localized, but copied among different files
  
  
  To use this tool with interface, do the following:
  1. Run the InterfaceLocalizer app.
  2. Go to Main Menu - Settings. Choose Multilang tab (this is most common use).
  3. Specify a paths to the files and set a names of the languages. 
  4. Now it's limited to 4 languages, but I will add more in the future.
  5. Click on Show All to see every key-value pair. 
  6. Click on Show troubles to see just the lines with untranslated content.
  7. Go to Main menu - Statistics to check out a number of lines, symbols, undone translations and so on. It might be useful for interpretators who earn money on symbols per dollar basis.
  8. You may change any translation here and Click on Save. Save works for xml only, but I will do it for KeyValue soon.
  9. Spell checker is working for English text also. 
  
  Fell free to comment or discuss this application.
