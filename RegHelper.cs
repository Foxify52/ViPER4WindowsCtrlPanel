using System;
using System.Runtime.InteropServices;

namespace ViPER4WindowsBin
{
  internal class RegHelper
  {
    private const string m_szAppRegisterPath = "SOFTWARE\\ViPER4Windows";
    private const string m_szKeyConfigPath = "ConfigPath";
    private const string m_szKeyConfigFile = "ConfigFile";

    [DllImport("Utils.dll", CharSet = CharSet.Unicode)]
    private static extern int QueryRegistryStringValue(
      string pszBrunch,
      string pszKey,
      IntPtr pszValueBuffer,
      int nBufferSize);

    [DllImport("Utils.dll", CharSet = CharSet.Unicode)]
    private static extern int QueryRegistryDWORDValue(
      string pszBrunch,
      string pszKey,
      IntPtr puiValue);

    [DllImport("Utils.dll", CharSet = CharSet.Unicode)]
    private static extern int WriteRegistryDWORDValue(
      string pszBrunch,
      string pszKey,
      uint uiValue);

    public static bool CheckConfigRegister()
    {
      int nBufferSize = 260;
      char[] destination1 = new char[nBufferSize * 2];
      char[] destination2 = new char[nBufferSize * 2];
      IntPtr num1 = Marshal.AllocHGlobal(nBufferSize * 2);
      int num2 = RegHelper.QueryRegistryStringValue("SOFTWARE\\ViPER4Windows", "ConfigPath", num1, nBufferSize);
      Marshal.Copy(num1, destination1, 0, nBufferSize * 2);
      int num3 = RegHelper.QueryRegistryStringValue("SOFTWARE\\ViPER4Windows", "ConfigFile", num1, nBufferSize);
      Marshal.Copy(num1, destination2, 0, nBufferSize * 2);
      Marshal.FreeHGlobal(num1);
      if (num2 == 0 || num3 == 0)
        return false;
      string str1 = new string(destination1);
      string str2 = new string(destination2);
      if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
        return false;
      char[] charArray1 = str1.ToCharArray();
      int length1 = -1;
      for (int index = 0; index < charArray1.Length; ++index)
      {
        if (charArray1[index] == char.MinValue)
        {
          length1 = index;
          break;
        }
      }
      if (length1 == -1)
        return false;
      char[] destinationArray1 = new char[length1];
      Array.Copy((Array) charArray1, (Array) destinationArray1, length1);
      string str3 = new string(destinationArray1);
      char[] charArray2 = str2.ToCharArray();
      int length2 = -1;
      for (int index = 0; index < charArray2.Length; ++index)
      {
        if (charArray2[index] == char.MinValue)
        {
          length2 = index;
          break;
        }
      }
      if (length2 == -1)
        return false;
      char[] destinationArray2 = new char[length2];
      Array.Copy((Array) charArray2, (Array) destinationArray2, length2);
      string str4 = new string(destinationArray2);
      return !string.IsNullOrEmpty(str3) && !string.IsNullOrEmpty(str4);
    }

    public static string GetConfigPath()
    {
      int nBufferSize = 260;
      char[] destination = new char[nBufferSize * 2];
      IntPtr num1 = Marshal.AllocHGlobal(nBufferSize * 2);
      int num2 = RegHelper.QueryRegistryStringValue("SOFTWARE\\ViPER4Windows", "ConfigPath", num1, nBufferSize);
      Marshal.Copy(num1, destination, 0, nBufferSize * 2);
      Marshal.FreeHGlobal(num1);
      if (num2 == 0)
        return "";
      string str1 = new string(destination);
      if (string.IsNullOrEmpty(str1))
        return "";
      char[] charArray = str1.ToCharArray();
      int length = -1;
      for (int index = 0; index < charArray.Length; ++index)
      {
        if (charArray[index] == char.MinValue)
        {
          length = index;
          break;
        }
      }
      if (length == -1)
        return "";
      char[] destinationArray = new char[length];
      Array.Copy((Array) charArray, (Array) destinationArray, length);
      string str2 = new string(destinationArray);
      return string.IsNullOrEmpty(str2) ? "" : str2;
    }

    public static string GetConfigFile()
    {
      int nBufferSize = 260;
      char[] destination = new char[nBufferSize * 2];
      IntPtr num1 = Marshal.AllocHGlobal(nBufferSize * 2);
      int num2 = RegHelper.QueryRegistryStringValue("SOFTWARE\\ViPER4Windows", "ConfigFile", num1, nBufferSize);
      Marshal.Copy(num1, destination, 0, nBufferSize * 2);
      Marshal.FreeHGlobal(num1);
      if (num2 == 0)
        return "";
      string str1 = new string(destination);
      if (string.IsNullOrEmpty(str1))
        return "";
      char[] charArray = str1.ToCharArray();
      int length = -1;
      for (int index = 0; index < charArray.Length; ++index)
      {
        if (charArray[index] == char.MinValue)
        {
          length = index;
          break;
        }
      }
      if (length == -1)
        return "";
      char[] destinationArray = new char[length];
      Array.Copy((Array) charArray, (Array) destinationArray, length);
      string str2 = new string(destinationArray);
      return string.IsNullOrEmpty(str2) ? "" : str2;
    }

    public static string GetConfig() => RegHelper.GetConfigPath() + "\\" + RegHelper.GetConfigFile();

    public static uint QueryDWORD(string szKeyName, uint uiDefault)
    {
      byte[] destination = new byte[Marshal.SizeOf(typeof (uint))];
      IntPtr num1 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (uint)));
      int num2 = RegHelper.QueryRegistryDWORDValue("SOFTWARE\\ViPER4Windows", szKeyName, num1);
      Marshal.Copy(num1, destination, 0, Marshal.SizeOf(typeof (uint)));
      Marshal.FreeHGlobal(num1);
      uint num3 = BitConverter.ToUInt32(destination, 0);
      if (num2 == 0)
        num3 = uiDefault;
      return num3;
    }

    public static bool WriteDWORD(string szKeyName, uint uiValue)
    {
      uint uiValue1 = uiValue;
      return RegHelper.WriteRegistryDWORDValue("SOFTWARE\\ViPER4Windows", szKeyName, uiValue1) != 0;
    }
  }
}
