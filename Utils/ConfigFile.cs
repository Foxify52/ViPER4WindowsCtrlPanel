using System.IO;
using System.Text;

namespace ViPER4WindowsBin.Utils
{
    internal class ConfigFile
    {
        private readonly string m_szConfigPathName = "";

        public ConfigFile(string szConfigPath) => m_szConfigPathName = szConfigPath;

        public string ReadConfig(string szKey)
        {
            if (m_szConfigPathName == null || m_szConfigPathName == "")
                return "";
            int length = m_szConfigPathName.LastIndexOf("\\");
            if (length <= 0 || !Directory.Exists(m_szConfigPathName.Substring(0, length) + "\\"))
                return "";
            if (!File.Exists(m_szConfigPathName))
                return "";
            try
            {
                StreamReader streamReader = new StreamReader(m_szConfigPathName);
                while (!streamReader.EndOfStream)
                {
                    string str = streamReader.ReadLine();
                    if (str != null && !str.StartsWith("#"))
                    {
                        string[] strArray = str.Split('=');
                        if (strArray.Length == 2 && strArray[0].Trim().ToUpper() == szKey.Trim().ToUpper())
                        {
                            streamReader.Close();
                            return strArray[1].Trim();
                        }
                    }
                }
                streamReader.Close();
                return "";
            }
            catch
            {
                return "";
            }
        }

        public void SetConfig(string szKey, string szValue)
        {
            switch (szKey)
            {
                case null:
                    break;
                case "":
                    break;
                default:
                    if (m_szConfigPathName == null || m_szConfigPathName == "")
                        break;
                    int length = m_szConfigPathName.LastIndexOf("\\");
                    if (length > 0)
                    {
                        string path = m_szConfigPathName.Substring(0, length) + "\\";
                        if (!Directory.Exists(path))
                        {
                            try
                            {
                                Directory.CreateDirectory(path);
                            }
                            catch
                            {
                                break;
                            }
                        }
                    }
                    if (!File.Exists(m_szConfigPathName))
                    {
                        try
                        {
                            StreamWriter streamWriter = new StreamWriter(m_szConfigPathName, false, Encoding.Unicode);
                            streamWriter.WriteLine(szKey.Trim().ToUpper() + "=" + szValue.Trim());
                            streamWriter.Flush();
                            streamWriter.Close();
                            break;
                        }
                        catch
                        {
                        }
                    }
                    try
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        StreamReader streamReader = new StreamReader(m_szConfigPathName);
                        bool flag = false;
                        while (!streamReader.EndOfStream)
                        {
                            string str = streamReader.ReadLine();
                            if (str != null)
                            {
                                if (str.StartsWith("#"))
                                {
                                    stringBuilder.AppendLine(str);
                                }
                                else
                                {
                                    string[] strArray = str.Split('=');
                                    if (strArray.Length == 2)
                                    {
                                        if (strArray[0].Trim().ToUpper() == szKey.Trim().ToUpper())
                                        {
                                            stringBuilder.AppendLine(szKey.Trim().ToUpper() + "=" + szValue.Trim());
                                            flag = true;
                                        }
                                        else
                                            stringBuilder.AppendLine(str.Trim());
                                    }
                                    else
                                        stringBuilder.AppendLine(str);
                                }
                            }
                        }
                        streamReader.Close();
                        if (!flag)
                            stringBuilder.AppendLine(szKey.Trim().ToUpper() + "=" + szValue.Trim());
                        StreamWriter streamWriter = new StreamWriter(m_szConfigPathName, false, Encoding.Unicode);
                        streamWriter.Write(stringBuilder.ToString());
                        streamWriter.Flush();
                        streamWriter.Close();
                        break;
                    }
                    catch
                    {
                        break;
                    }
            }
        }
    }
}
