using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using ViPER4WindowsBin.Utils;

namespace ViPER4WindowsBin
{
  internal static class Program
  {
    [STAThread]
    private static void Main(string[] szArgs)
    {
      if (Program.RunningInstance() != null)
        return;
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      string szLanguagePath = "";
      string szLanguageFile = "";
      string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
      if (!baseDirectory.EndsWith("\\"))
        baseDirectory += "\\";
      string szFolder = baseDirectory + "Language\\";
      string str1 = new ConfigFile(baseDirectory + "Config.ini").ReadConfig("$LANGUAGE_NAME");
      if (str1 == "")
        str1 = "English";
      string[] strArray = new FolderExplorer().ListFiles(szFolder);
      string str2 = "";
      foreach (string szConfigPath in strArray)
      {
        if (new ConfigFile(szConfigPath).ReadConfig("$LANGUAGE_NAME").Trim() == str1)
        {
          str2 = szConfigPath;
          break;
        }
      }
      if (str2 != "")
      {
        szLanguagePath = szFolder;
        szLanguageFile = str2;
      }
      else if (str1 == "English")
      {
        int num1 = (int) MessageBox.Show("Can not load default language (English), use built-in language.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        string str3 = "English";
        foreach (string szConfigPath in strArray)
        {
          if (new ConfigFile(szConfigPath).ReadConfig("$LANGUAGE_NAME").Trim() == str3)
          {
            str2 = szConfigPath;
            break;
          }
        }
        if (str2 != "")
        {
          szLanguagePath = szFolder;
          szLanguageFile = str2;
        }
        else
        {
          int num2 = (int) MessageBox.Show("Can not load default language (English), use built-in language.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
      if (szLanguagePath != "" && szLanguageFile != "")
        GlobalMessages.LoadMessages(szLanguageFile);
      if (!RegHelper.CheckConfigRegister())
      {
        int num3 = (int) MessageBox.Show(GlobalMessages.DRIVER_NOT_CONFIG, GlobalMessages.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        frmMain.SetLanguage(szLanguagePath, szLanguageFile);
        Application.Run((Form) new frmMain(szArgs));
      }
    }

    private static Process RunningInstance()
    {
      Process currentProcess = Process.GetCurrentProcess();
      foreach (Process process in Process.GetProcessesByName(currentProcess.ProcessName))
      {
        if (process.Id != currentProcess.Id && Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == currentProcess.MainModule.FileName)
          return process;
      }
      return (Process) null;
    }
  }
}
