using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ViPER4WindowsBin.Utils
{
  internal class Parameters
  {
    public const int EFFECT_MODE_MUSIC = 0;
    public const int EFFECT_MODE_MOVIE = 1;
    public const int EFFECT_MODE_FREESTYLE = 2;
    public const uint CF_DEFAULT_CLEVEL = 2949820;
    public const uint CF_CMOY_CLEVEL = 3932860;
    public const uint CF_JMEIER_CLEVEL = 6226570;
    public const float MINKNEEMULT = 0.0f;
    public const float MAXKNEEMULT = 4f;
    public const float MINATTACKTIME = 0.0001f;
    public const float MAXATTACKTIME = 0.2f;
    public const float MINRELEASETIME = 0.005f;
    public const float MAXRELEASETIME = 2f;
    public const float MAXGAINDB = 60f;
    public const float MINADAPTTIME = 1f;
    public const float MAXADAPTTIME = 4f;
    public const float MINCRESTTIME = 0.005f;
    public const float MAXCRESTTIME = 2f;

    public static char[] WriteStringToArray260(string szContext)
    {
      if (szContext.Length >= 260)
        return new char[260];
      char[] charArray = szContext.ToCharArray();
      char[] destinationArray = new char[260];
      for (int index = 0; index < destinationArray.Length; ++index)
        destinationArray[index] = Convert.ToChar(0);
      Array.Copy((Array) charArray, (Array) destinationArray, charArray.Length);
      return destinationArray;
    }

    public static byte[] ParameterSerialize(object sParameter)
    {
      int length = Marshal.SizeOf(sParameter);
      IntPtr num = Marshal.AllocHGlobal(length);
      Marshal.StructureToPtr(sParameter, num, false);
      byte[] destination = new byte[length];
      Marshal.Copy(num, destination, 0, length);
      Marshal.FreeHGlobal(num);
      return destination;
    }

    public static RuntimeUtils.ConfigProxy._ParamOfBaseSystem_1_0_1 DeserializeParamOfBaseSystem_1_0_1(
      byte[] baRawData)
    {
      System.Type type = typeof (RuntimeUtils.ConfigProxy._ParamOfBaseSystem_1_0_1);
      int num1 = Marshal.SizeOf(type);
      if (num1 != baRawData.Length)
        return new RuntimeUtils.ConfigProxy._ParamOfBaseSystem_1_0_1()
        {
          m_bEffectEnabled = 0,
          m_nEffectMode = 0,
          m_nFilterShortLen = 4096,
          m_nFilterMediumLen = 0,
          m_nFilterLongLen = 0,
          m_rChannelPan = 0.0f
        };
      IntPtr num2 = Marshal.AllocHGlobal(num1);
      Marshal.Copy(baRawData, 0, num2, num1);
      object structure = Marshal.PtrToStructure(num2, type);
      Marshal.FreeHGlobal(num2);
      return (RuntimeUtils.ConfigProxy._ParamOfBaseSystem_1_0_1) structure;
    }

    public static RuntimeUtils.ConfigProxy._ParamOfBaseSystem DeserializeParamOfBaseSystem(
      byte[] baRawData)
    {
      System.Type type = typeof (RuntimeUtils.ConfigProxy._ParamOfBaseSystem);
      int num1 = Marshal.SizeOf(type);
      if (num1 != baRawData.Length)
      {
        RuntimeUtils.ConfigProxy._ParamOfBaseSystem sParameter = new RuntimeUtils.ConfigProxy._ParamOfBaseSystem();
        Parameters.LoadDefaultParameter(ref sParameter);
        return sParameter;
      }
      IntPtr num2 = Marshal.AllocHGlobal(num1);
      Marshal.Copy(baRawData, 0, num2, num1);
      object structure = Marshal.PtrToStructure(num2, type);
      Marshal.FreeHGlobal(num2);
      return (RuntimeUtils.ConfigProxy._ParamOfBaseSystem) structure;
    }

    public static RuntimeUtils.ConfigProxy._ParamOfMusicMode DeserializeParamOfMusicMode(
      byte[] baRawData)
    {
      System.Type type = typeof (RuntimeUtils.ConfigProxy._ParamOfMusicMode);
      int num1 = Marshal.SizeOf(type);
      if (num1 != baRawData.Length)
      {
        RuntimeUtils.ConfigProxy._ParamOfMusicMode sParameter = new RuntimeUtils.ConfigProxy._ParamOfMusicMode();
        Parameters.LoadDefaultParameter(ref sParameter);
        return sParameter;
      }
      IntPtr num2 = Marshal.AllocHGlobal(num1);
      Marshal.Copy(baRawData, 0, num2, num1);
      object structure = Marshal.PtrToStructure(num2, type);
      Marshal.FreeHGlobal(num2);
      return (RuntimeUtils.ConfigProxy._ParamOfMusicMode) structure;
    }

    public static RuntimeUtils.ConfigProxy._ParamOfMovieMode DeserializeParamOfMovieMode(
      byte[] baRawData)
    {
      System.Type type = typeof (RuntimeUtils.ConfigProxy._ParamOfMovieMode);
      int num1 = Marshal.SizeOf(type);
      if (num1 != baRawData.Length)
      {
        RuntimeUtils.ConfigProxy._ParamOfMovieMode sParameter = new RuntimeUtils.ConfigProxy._ParamOfMovieMode();
        Parameters.LoadDefaultParameter(ref sParameter);
        return sParameter;
      }
      IntPtr num2 = Marshal.AllocHGlobal(num1);
      Marshal.Copy(baRawData, 0, num2, num1);
      object structure = Marshal.PtrToStructure(num2, type);
      Marshal.FreeHGlobal(num2);
      return (RuntimeUtils.ConfigProxy._ParamOfMovieMode) structure;
    }

    public static RuntimeUtils.ConfigProxy._ParamOfFreestyle DeserializeParamOfFreestyle(
      byte[] baRawData)
    {
      System.Type type = typeof (RuntimeUtils.ConfigProxy._ParamOfFreestyle);
      int num1 = Marshal.SizeOf(type);
      if (num1 != baRawData.Length)
      {
        RuntimeUtils.ConfigProxy._ParamOfFreestyle sParameter = new RuntimeUtils.ConfigProxy._ParamOfFreestyle();
        Parameters.LoadDefaultParameter(ref sParameter);
        return sParameter;
      }
      IntPtr num2 = Marshal.AllocHGlobal(num1);
      Marshal.Copy(baRawData, 0, num2, num1);
      object structure = Marshal.PtrToStructure(num2, type);
      Marshal.FreeHGlobal(num2);
      return (RuntimeUtils.ConfigProxy._ParamOfFreestyle) structure;
    }

    public static void SaveLocalPreset(
      string szFilePathName,
      RuntimeUtils.ConfigProxy._ParamOfBaseSystem paramBaseSystem,
      RuntimeUtils.ConfigProxy._ParamOfMusicMode paramMusicMode,
      RuntimeUtils.ConfigProxy._ParamOfMovieMode paramMovieMode,
      RuntimeUtils.ConfigProxy._ParamOfFreestyle paramFreestyle)
    {
      byte[] buffer1 = Parameters.ParameterSerialize((object) paramBaseSystem);
      byte[] buffer2 = Parameters.ParameterSerialize((object) paramMusicMode);
      byte[] buffer3 = Parameters.ParameterSerialize((object) paramMovieMode);
      byte[] buffer4 = Parameters.ParameterSerialize((object) paramFreestyle);
      if (buffer1 == null || buffer2 == null || buffer3 == null)
        return;
      if (buffer4 == null)
        return;
      try
      {
        FileStream fileStream = new FileStream(szFilePathName, FileMode.Create);
        byte[] buffer5 = new byte[14]
        {
          (byte) 86,
          (byte) 105,
          (byte) 80,
          (byte) 69,
          (byte) 82,
          (byte) 52,
          (byte) 87,
          (byte) 105,
          (byte) 110,
          (byte) 100,
          (byte) 111,
          (byte) 119,
          (byte) 115,
          (byte) 88
        };
        fileStream.Write(buffer5, 0, buffer5.Length);
        fileStream.WriteByte((byte) 1);
        fileStream.WriteByte((byte) 1);
        fileStream.WriteByte((byte) 1);
        fileStream.WriteByte((byte) 1);
        fileStream.Write(buffer1, 0, buffer1.Length);
        fileStream.Write(buffer2, 0, buffer2.Length);
        fileStream.Write(buffer3, 0, buffer3.Length);
        fileStream.Write(buffer4, 0, buffer4.Length);
        fileStream.Flush();
        fileStream.Close();
      }
      catch (Exception ex)
      {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(GlobalMessages.ERROR);
        stringBuilder.AppendLine(GlobalMessages.TECHNICAL_INFO);
        stringBuilder.AppendLine(ex.Message);
        int num = (int) MessageBox.Show(stringBuilder.ToString(), GlobalMessages.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    public static bool SavePreset(
      string szFilePathName,
      RuntimeUtils.ConfigProxy._ParamOfMusicMode paramMusicMode)
    {
      byte[] buffer1 = Parameters.ParameterSerialize((object) paramMusicMode);
      if (buffer1 == null)
        return false;
      try
      {
        FileStream fileStream = new FileStream(szFilePathName, FileMode.Create);
        byte[] buffer2 = new byte[14]
        {
          (byte) 86,
          (byte) 105,
          (byte) 80,
          (byte) 69,
          (byte) 82,
          (byte) 52,
          (byte) 87,
          (byte) 105,
          (byte) 110,
          (byte) 100,
          (byte) 111,
          (byte) 119,
          (byte) 115,
          (byte) 88
        };
        fileStream.Write(buffer2, 0, buffer2.Length);
        fileStream.WriteByte((byte) 0);
        fileStream.WriteByte((byte) 1);
        fileStream.WriteByte((byte) 0);
        fileStream.WriteByte((byte) 0);
        fileStream.Write(buffer1, 0, buffer1.Length);
        fileStream.Flush();
        fileStream.Close();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public static bool SavePreset(
      string szFilePathName,
      RuntimeUtils.ConfigProxy._ParamOfMovieMode paramMovieMode)
    {
      byte[] buffer1 = Parameters.ParameterSerialize((object) paramMovieMode);
      if (buffer1 == null)
        return false;
      try
      {
        FileStream fileStream = new FileStream(szFilePathName, FileMode.Create);
        byte[] buffer2 = new byte[14]
        {
          (byte) 86,
          (byte) 105,
          (byte) 80,
          (byte) 69,
          (byte) 82,
          (byte) 52,
          (byte) 87,
          (byte) 105,
          (byte) 110,
          (byte) 100,
          (byte) 111,
          (byte) 119,
          (byte) 115,
          (byte) 88
        };
        fileStream.Write(buffer2, 0, buffer2.Length);
        fileStream.WriteByte((byte) 0);
        fileStream.WriteByte((byte) 0);
        fileStream.WriteByte((byte) 1);
        fileStream.WriteByte((byte) 0);
        fileStream.Write(buffer1, 0, buffer1.Length);
        fileStream.Flush();
        fileStream.Close();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public static bool SavePreset(
      string szFilePathName,
      RuntimeUtils.ConfigProxy._ParamOfFreestyle paramFreestyle)
    {
      byte[] buffer1 = Parameters.ParameterSerialize((object) paramFreestyle);
      if (buffer1 == null)
        return false;
      try
      {
        FileStream fileStream = new FileStream(szFilePathName, FileMode.Create);
        byte[] buffer2 = new byte[14]
        {
          (byte) 86,
          (byte) 105,
          (byte) 80,
          (byte) 69,
          (byte) 82,
          (byte) 52,
          (byte) 87,
          (byte) 105,
          (byte) 110,
          (byte) 100,
          (byte) 111,
          (byte) 119,
          (byte) 115,
          (byte) 88
        };
        fileStream.Write(buffer2, 0, buffer2.Length);
        fileStream.WriteByte((byte) 0);
        fileStream.WriteByte((byte) 0);
        fileStream.WriteByte((byte) 0);
        fileStream.WriteByte((byte) 1);
        fileStream.Write(buffer1, 0, buffer1.Length);
        fileStream.Flush();
        fileStream.Close();
        return true;
      }
      catch
      {
        return false;
      }
    }

    public static bool ReadPreset(
      string szFilePathName,
      ref RuntimeUtils.ConfigProxy._ParamOfBaseSystem paramBaseSystem,
      ref RuntimeUtils.ConfigProxy._ParamOfMusicMode paramMusicMode,
      ref RuntimeUtils.ConfigProxy._ParamOfMovieMode paramMovieMode,
      ref RuntimeUtils.ConfigProxy._ParamOfFreestyle paramFreestyle,
      out bool bPBaseSystem,
      out bool bPMusicMode,
      out bool bPMovieMode,
      out bool bPFreestyle)
    {
      if (szFilePathName == null)
      {
        bPBaseSystem = false;
        bPMusicMode = false;
        bPMovieMode = false;
        bPFreestyle = false;
        return false;
      }
      if (szFilePathName.Length <= 0)
      {
        bPBaseSystem = false;
        bPMusicMode = false;
        bPMovieMode = false;
        bPFreestyle = false;
        return false;
      }
      if (!File.Exists(szFilePathName))
      {
        bPBaseSystem = false;
        bPMusicMode = false;
        bPMovieMode = false;
        bPFreestyle = false;
        return false;
      }
      long length;
      try
      {
        length = new FileInfo(szFilePathName).Length;
      }
      catch
      {
        bPBaseSystem = false;
        bPMusicMode = false;
        bPMovieMode = false;
        bPFreestyle = false;
        return false;
      }
      if (length <= 0L)
      {
        bPBaseSystem = false;
        bPMusicMode = false;
        bPMovieMode = false;
        bPFreestyle = false;
        return false;
      }
      try
      {
        FileStream fileStream = new FileStream(szFilePathName, FileMode.Open);
        byte[] numArray1 = new byte[14]
        {
          (byte) 86,
          (byte) 105,
          (byte) 80,
          (byte) 69,
          (byte) 82,
          (byte) 52,
          (byte) 87,
          (byte) 105,
          (byte) 110,
          (byte) 100,
          (byte) 111,
          (byte) 119,
          (byte) 115,
          (byte) 88
        };
        byte[] buffer = new byte[14];
        if (fileStream.Read(buffer, 0, buffer.Length) != buffer.Length)
        {
          fileStream.Close();
          bPBaseSystem = false;
          bPMusicMode = false;
          bPMovieMode = false;
          bPFreestyle = false;
          return false;
        }
        for (int index = 0; index < numArray1.Length; ++index)
        {
          if ((int) buffer[index] != (int) numArray1[index])
          {
            fileStream.Close();
            bPBaseSystem = false;
            bPMusicMode = false;
            bPMovieMode = false;
            bPFreestyle = false;
            return false;
          }
        }
        int num1 = fileStream.ReadByte();
        int num2 = fileStream.ReadByte();
        int num3 = fileStream.ReadByte();
        int num4 = fileStream.ReadByte();
        bPBaseSystem = false;
        bPMusicMode = false;
        bPMovieMode = false;
        bPFreestyle = false;
        long num5 = 18;
        if (num1 == 1)
          num5 += (long) Marshal.SizeOf(typeof (RuntimeUtils.ConfigProxy._ParamOfBaseSystem));
        if (num2 == 1)
          num5 += (long) Marshal.SizeOf(typeof (RuntimeUtils.ConfigProxy._ParamOfMusicMode));
        if (num3 == 1)
          num5 += (long) Marshal.SizeOf(typeof (RuntimeUtils.ConfigProxy._ParamOfMovieMode));
        if (num4 == 1)
          num5 += (long) Marshal.SizeOf(typeof (RuntimeUtils.ConfigProxy._ParamOfFreestyle));
        if (num5 != length)
        {
          long num6 = 18;
          if (num1 == 1)
            num6 += (long) Marshal.SizeOf(typeof (RuntimeUtils.ConfigProxy._ParamOfBaseSystem_1_0_1));
          if (num2 == 1)
            num6 += (long) Marshal.SizeOf(typeof (RuntimeUtils.ConfigProxy._ParamOfMusicMode));
          if (num3 == 1)
            num6 += (long) Marshal.SizeOf(typeof (RuntimeUtils.ConfigProxy._ParamOfMovieMode));
          if (num4 == 1)
            num6 += (long) Marshal.SizeOf(typeof (RuntimeUtils.ConfigProxy._ParamOfFreestyle));
          if (num6 == length)
          {
            if (num1 == 1)
            {
              byte[] numArray2 = new byte[Marshal.SizeOf((object) new RuntimeUtils.ConfigProxy._ParamOfBaseSystem_1_0_1())];
              if (fileStream.Read(numArray2, 0, numArray2.Length) != numArray2.Length)
              {
                fileStream.Close();
                bPBaseSystem = false;
                bPMusicMode = false;
                bPMovieMode = false;
                bPFreestyle = false;
                return false;
              }
              RuntimeUtils.ConfigProxy._ParamOfBaseSystem_1_0_1 paramOfBaseSystem101 = Parameters.DeserializeParamOfBaseSystem_1_0_1(numArray2);
              Parameters.LoadDefaultParameter(ref paramBaseSystem);
              paramBaseSystem.m_bEffectEnabled = paramOfBaseSystem101.m_bEffectEnabled;
              paramBaseSystem.m_nEffectMode = paramOfBaseSystem101.m_nEffectMode;
              paramBaseSystem.m_nFilterShortLen = paramOfBaseSystem101.m_nFilterShortLen;
              paramBaseSystem.m_nFilterMediumLen = paramOfBaseSystem101.m_nFilterMediumLen;
              paramBaseSystem.m_nFilterLongLen = paramOfBaseSystem101.m_nFilterLongLen;
              paramBaseSystem.m_rChannelPan = paramOfBaseSystem101.m_rChannelPan;
              bPBaseSystem = true;
            }
            if (num2 == 1)
            {
              byte[] numArray3 = new byte[Marshal.SizeOf((object) paramMusicMode)];
              if (fileStream.Read(numArray3, 0, numArray3.Length) != numArray3.Length)
              {
                fileStream.Close();
                bPBaseSystem = false;
                bPMusicMode = false;
                bPMovieMode = false;
                bPFreestyle = false;
                return false;
              }
              paramMusicMode = Parameters.DeserializeParamOfMusicMode(numArray3);
              bPMusicMode = true;
            }
            if (num3 == 1)
            {
              byte[] numArray4 = new byte[Marshal.SizeOf((object) paramMovieMode)];
              if (fileStream.Read(numArray4, 0, numArray4.Length) != numArray4.Length)
              {
                fileStream.Close();
                bPBaseSystem = false;
                bPMusicMode = false;
                bPMovieMode = false;
                bPFreestyle = false;
                return false;
              }
              paramMovieMode = Parameters.DeserializeParamOfMovieMode(numArray4);
              bPMovieMode = true;
            }
            if (num4 == 1)
            {
              byte[] numArray5 = new byte[Marshal.SizeOf((object) paramFreestyle)];
              if (fileStream.Read(numArray5, 0, numArray5.Length) != numArray5.Length)
              {
                fileStream.Close();
                bPBaseSystem = false;
                bPMusicMode = false;
                bPMovieMode = false;
                bPFreestyle = false;
                return false;
              }
              paramFreestyle = Parameters.DeserializeParamOfFreestyle(numArray5);
              bPFreestyle = true;
            }
            fileStream.Close();
            if (bPBaseSystem && bPMusicMode && bPMovieMode && bPFreestyle)
              Parameters.SaveLocalPreset(szFilePathName, paramBaseSystem, paramMusicMode, paramMovieMode, paramFreestyle);
            return true;
          }
          fileStream.Close();
          bPBaseSystem = false;
          bPMusicMode = false;
          bPMovieMode = false;
          bPFreestyle = false;
          return false;
        }
        if (num1 == 1)
        {
          byte[] numArray6 = new byte[Marshal.SizeOf((object) paramBaseSystem)];
          if (fileStream.Read(numArray6, 0, numArray6.Length) != numArray6.Length)
          {
            fileStream.Close();
            bPBaseSystem = false;
            bPMusicMode = false;
            bPMovieMode = false;
            bPFreestyle = false;
            return false;
          }
          paramBaseSystem = Parameters.DeserializeParamOfBaseSystem(numArray6);
          bPBaseSystem = true;
        }
        if (num2 == 1)
        {
          byte[] numArray7 = new byte[Marshal.SizeOf((object) paramMusicMode)];
          if (fileStream.Read(numArray7, 0, numArray7.Length) != numArray7.Length)
          {
            fileStream.Close();
            bPBaseSystem = false;
            bPMusicMode = false;
            bPMovieMode = false;
            bPFreestyle = false;
            return false;
          }
          paramMusicMode = Parameters.DeserializeParamOfMusicMode(numArray7);
          bPMusicMode = true;
        }
        if (num3 == 1)
        {
          byte[] numArray8 = new byte[Marshal.SizeOf((object) paramMovieMode)];
          if (fileStream.Read(numArray8, 0, numArray8.Length) != numArray8.Length)
          {
            fileStream.Close();
            bPBaseSystem = false;
            bPMusicMode = false;
            bPMovieMode = false;
            bPFreestyle = false;
            return false;
          }
          paramMovieMode = Parameters.DeserializeParamOfMovieMode(numArray8);
          bPMovieMode = true;
        }
        if (num4 == 1)
        {
          byte[] numArray9 = new byte[Marshal.SizeOf((object) paramFreestyle)];
          if (fileStream.Read(numArray9, 0, numArray9.Length) != numArray9.Length)
          {
            fileStream.Close();
            bPBaseSystem = false;
            bPMusicMode = false;
            bPMovieMode = false;
            bPFreestyle = false;
            return false;
          }
          paramFreestyle = Parameters.DeserializeParamOfFreestyle(numArray9);
          bPFreestyle = true;
        }
        fileStream.Close();
        return true;
      }
      catch
      {
        bPBaseSystem = false;
        bPMusicMode = false;
        bPMovieMode = false;
        bPFreestyle = false;
        return false;
      }
    }

    public static float LOG2PARAM(float x, float mn, float mx) => (float) ((Math.Log((double) x) - Math.Log((double) mn)) / (Math.Log((double) mx) - Math.Log((double) mn)));

    public static float LIN2PARAM(float x, float mn, float mx) => (float) (((double) x - (double) mn) / ((double) mx - (double) mn));

    public static float PARAM2LOG(float x, float mn, float mx) => (float) Math.Exp(Math.Log((double) mn) + (double) x * (Math.Log((double) mx) - Math.Log((double) mn)));

    public static float PARAM2LIN(float x, float mn, float mx) => mn + x * (mx - mn);

    public static void LoadDefaultParameter(
      ref RuntimeUtils.ConfigProxy._ParamOfBaseSystem sParameter)
    {
      sParameter.m_bEffectEnabled = 0;
      sParameter.m_nEffectMode = 0U;
      sParameter.m_nFilterShortLen = 4096;
      sParameter.m_nFilterMediumLen = 0;
      sParameter.m_nFilterLongLen = 0;
      sParameter.m_rChannelPan = 0.0f;
      sParameter.m_bVirtApplied = 0;
      sParameter.m_rpChannelAngle_00 = new float[9];
      sParameter.m_rpChannelAngle_01 = new float[9];
      sParameter.m_rpChannelAngle_02 = new float[9];
      sParameter.m_rpChannelAngle_03 = new float[9];
      sParameter.m_rpChannelAngle_04 = new float[9];
      sParameter.m_rpChannelAngle_05 = new float[9];
      sParameter.m_rpChannelAngle_06 = new float[9];
      sParameter.m_rpChannelAngle_07 = new float[9];
      sParameter.m_rpChannelAngle_08 = new float[9];
      sParameter.m_rpChannelAngle_00[0] = 0.0f;
      sParameter.m_rpChannelAngle_01[0] = -30f;
      sParameter.m_rpChannelAngle_01[1] = 30f;
      sParameter.m_rpChannelAngle_02[0] = -90f;
      sParameter.m_rpChannelAngle_02[1] = 90f;
      sParameter.m_rpChannelAngle_03[0] = -150f;
      sParameter.m_rpChannelAngle_03[1] = 150f;
      sParameter.m_rpChannelAngle_04[0] = -45f;
      sParameter.m_rpChannelAngle_04[1] = 45f;
      sParameter.m_rpChannelAngle_04[2] = -135f;
      sParameter.m_rpChannelAngle_04[3] = 135f;
      sParameter.m_rpChannelAngle_05[0] = -30f;
      sParameter.m_rpChannelAngle_05[1] = 30f;
      sParameter.m_rpChannelAngle_05[2] = 0.0f;
      sParameter.m_rpChannelAngle_05[3] = 0.0f;
      sParameter.m_rpChannelAngle_05[4] = -110f;
      sParameter.m_rpChannelAngle_05[5] = 110f;
      sParameter.m_rpChannelAngle_06[0] = -30f;
      sParameter.m_rpChannelAngle_06[1] = 30f;
      sParameter.m_rpChannelAngle_06[2] = 0.0f;
      sParameter.m_rpChannelAngle_06[3] = 0.0f;
      sParameter.m_rpChannelAngle_06[4] = 180f;
      sParameter.m_rpChannelAngle_06[5] = -90f;
      sParameter.m_rpChannelAngle_06[6] = 90f;
      sParameter.m_rpChannelAngle_07[0] = -30f;
      sParameter.m_rpChannelAngle_07[1] = 30f;
      sParameter.m_rpChannelAngle_07[2] = 0.0f;
      sParameter.m_rpChannelAngle_07[3] = 0.0f;
      sParameter.m_rpChannelAngle_07[4] = -150f;
      sParameter.m_rpChannelAngle_07[5] = 150f;
      sParameter.m_rpChannelAngle_07[6] = -90f;
      sParameter.m_rpChannelAngle_07[7] = 90f;
      sParameter.m_rpChannelAngle_08[0] = -30f;
      sParameter.m_rpChannelAngle_08[1] = 30f;
      sParameter.m_rpChannelAngle_08[2] = 0.0f;
      sParameter.m_rpChannelAngle_08[3] = 0.0f;
      sParameter.m_rpChannelAngle_08[4] = -150f;
      sParameter.m_rpChannelAngle_08[5] = 150f;
      sParameter.m_rpChannelAngle_08[6] = 180f;
      sParameter.m_rpChannelAngle_08[7] = -90f;
      sParameter.m_rpChannelAngle_08[8] = 90f;
      sParameter.m_bEnvRealizeEnabled = 0;
      sParameter.m_bEnvRealizePreprocess = 1;
      sParameter.m_nEnvRealizePreset = 2;
      sParameter.m_rEnvRealizeDrySignal = 1f;
    }

    public static void LoadDefaultParameter(
      ref RuntimeUtils.ConfigProxy._ParamOfMusicMode sParameter)
    {
      sParameter.m_rPreVolume = 1f;
      sParameter.m_bConvolverEnabled = 0;
      sParameter.m_szConvolverIR = new char[260];
      for (int index = 0; index < 256; ++index)
        sParameter.m_szConvolverIR[index] = char.MinValue;
      sParameter.m_rConvolverIRGain = 1f;
      sParameter.m_bViPERBassEnabled = 0;
      sParameter.m_nViPERBassSpkSize = 60;
      sParameter.m_rViPERBassFactor = 0.0f;
      sParameter.m_bViPERClarityEnabled = 0;
      sParameter.m_nViPERClarityMode = 0;
      sParameter.m_rViPERClarityFactor = 0.0f;
      sParameter.m_bSurroundEnabled = 0;
      sParameter.m_nVHERoomSize = 0;
      sParameter.m_bReverbEnabled = 0;
      sParameter.m_rReverbSize = 0.0f;
      sParameter.m_rReverbPredelay = 0.0f;
      sParameter.m_rReverbDamping = 0.0f;
      sParameter.m_rReverbDensity = 0.0f;
      sParameter.m_rReverbBandwidth = 1f;
      sParameter.m_rReverbDecay = 0.0f;
      sParameter.m_rReverbEarlyMix = 0.0f;
      sParameter.m_rReverbMix = 0.0f;
      sParameter.m_rReverbGain = 1f;
      sParameter.m_bEqualizerEnabled = 0;
      sParameter.m_rpEqualizerBands = new float[18];
      for (int index = 0; index < 18; ++index)
        sParameter.m_rpEqualizerBands[index] = 1f;
      sParameter.m_bCompressorEnabled = 0;
      sParameter.m_bCompAutoKnee = 1;
      sParameter.m_bCompAutoGain = 1;
      sParameter.m_bCompAutoAttack = 1;
      sParameter.m_bCompAutoRelease = 1;
      sParameter.m_rCompThreshold = 0.0f;
      sParameter.m_rCompRatio = 0.0f;
      sParameter.m_rCompKneeWidth = 0.0f;
      sParameter.m_rCompGain = 0.0f;
      sParameter.m_rCompAttack = Parameters.LOG2PARAM(0.005f, 0.0001f, 0.2f);
      sParameter.m_rCompRelease = Parameters.LOG2PARAM(0.05f, 0.005f, 2f);
      sParameter.m_bCureEnabled = 0;
      sParameter.m_uiCureLevel = 6226570U;
      sParameter.m_bTubeEnabled = 0;
      sParameter.m_rPostVolume = 1f;
    }

    public static void LoadDefaultParameter(
      ref RuntimeUtils.ConfigProxy._ParamOfMovieMode sParameter)
    {
      sParameter.m_rPreVolume = 1f;
      sParameter.m_bConvolverEnabled = 0;
      sParameter.m_szConvolverIR = new char[260];
      for (int index = 0; index < 256; ++index)
        sParameter.m_szConvolverIR[index] = char.MinValue;
      sParameter.m_rConvolverIRGain = 1f;
      sParameter.m_bViPERBassEnabled = 0;
      sParameter.m_nViPERBassSpkSize = 60;
      sParameter.m_rViPERBassFactor = 0.0f;
      sParameter.m_bViPERClarityEnabled = 0;
      sParameter.m_rViPERClarityFactor = 0.0f;
      sParameter.m_bSurroundEnabled = 0;
      sParameter.m_r3DSurroundStereo = 1f;
      sParameter.m_r3DSurroundImage = 1f;
      sParameter.m_bReverbEnabled = 0;
      sParameter.m_rReverbSize = 0.0f;
      sParameter.m_rReverbPredelay = 0.0f;
      sParameter.m_rReverbDamping = 0.0f;
      sParameter.m_rReverbDensity = 0.0f;
      sParameter.m_rReverbBandwidth = 1f;
      sParameter.m_rReverbDecay = 0.0f;
      sParameter.m_rReverbEarlyMix = 0.0f;
      sParameter.m_rReverbMix = 0.0f;
      sParameter.m_rReverbGain = 1f;
      sParameter.m_bEqualizerEnabled = 0;
      sParameter.m_rpEqualizerBands = new float[18];
      for (int index = 0; index < 18; ++index)
        sParameter.m_rpEqualizerBands[index] = 1f;
      sParameter.m_bCompressorEnabled = 0;
      sParameter.m_bCompAutoKnee = 1;
      sParameter.m_bCompAutoGain = 1;
      sParameter.m_bCompAutoAttack = 1;
      sParameter.m_bCompAutoRelease = 1;
      sParameter.m_rCompThreshold = 0.0f;
      sParameter.m_rCompRatio = 0.0f;
      sParameter.m_rCompKneeWidth = 0.0f;
      sParameter.m_rCompGain = 0.0f;
      sParameter.m_rCompAttack = Parameters.LOG2PARAM(0.005f, 0.0001f, 0.2f);
      sParameter.m_rCompRelease = Parameters.LOG2PARAM(0.05f, 0.005f, 2f);
      sParameter.m_bSmartVolumeEnabled = 0;
      sParameter.m_rSVRatio = 0.5f;
      sParameter.m_rSVVolume = 1f;
      sParameter.m_rSVMaxGain = 4f;
      sParameter.m_rPostVolume = 1f;
    }

    public static void LoadDefaultParameter(
      ref RuntimeUtils.ConfigProxy._ParamOfFreestyle sParameter)
    {
      sParameter.m_rPreVolume = 1f;
      sParameter.m_bConvolverEnabled = 0;
      sParameter.m_szConvolverIR = new char[260];
      for (int index = 0; index < 256; ++index)
        sParameter.m_szConvolverIR[index] = char.MinValue;
      sParameter.m_rConvolverIRGain = 1f;
      sParameter.m_bViPERBassEnabled = 0;
      sParameter.m_nViPERBassMode = 0;
      sParameter.m_nViPERBassSpkSize = 60;
      sParameter.m_rViPERBassFactor = 0.0f;
      sParameter.m_bViPERClarityEnabled = 0;
      sParameter.m_nViPERClarityMode = 0;
      sParameter.m_rViPERClarityFactor = 0.0f;
      sParameter.m_b3DSurroundEnabled = 0;
      sParameter.m_r3DSurroundStereo = 1f;
      sParameter.m_r3DSurroundImage = 1f;
      sParameter.m_bVHESurroundEnabled = 0;
      sParameter.m_nVHERoomSize = 0;
      sParameter.m_bReverbEnabled = 0;
      sParameter.m_rReverbSize = 0.0f;
      sParameter.m_rReverbPredelay = 0.0f;
      sParameter.m_rReverbDamping = 0.0f;
      sParameter.m_rReverbDensity = 0.0f;
      sParameter.m_rReverbBandwidth = 1f;
      sParameter.m_rReverbDecay = 0.0f;
      sParameter.m_rReverbEarlyMix = 0.0f;
      sParameter.m_rReverbMix = 0.0f;
      sParameter.m_rReverbGain = 1f;
      sParameter.m_bEqualizerEnabled = 0;
      sParameter.m_rpEqualizerBands = new float[18];
      for (int index = 0; index < 18; ++index)
        sParameter.m_rpEqualizerBands[index] = 1f;
      sParameter.m_bCompressorEnabled = 0;
      sParameter.m_bCompAutoKnee = 1;
      sParameter.m_bCompAutoGain = 1;
      sParameter.m_bCompAutoAttack = 1;
      sParameter.m_bCompAutoRelease = 1;
      sParameter.m_bCompAutoMetaNoClipping = 1;
      sParameter.m_rCompThreshold = 0.0f;
      sParameter.m_rCompRatio = 0.0f;
      sParameter.m_rCompKneeWidth = 0.0f;
      sParameter.m_rCompGain = 0.0f;
      sParameter.m_rCompAttack = Parameters.LOG2PARAM(0.005f, 0.0001f, 0.2f);
      sParameter.m_rCompRelease = Parameters.LOG2PARAM(0.05f, 0.005f, 2f);
      sParameter.m_rCompMetaKneeMult = Parameters.LIN2PARAM(2f, 0.0f, 4f);
      sParameter.m_rCompMetaMaxAttack = Parameters.LOG2PARAM(0.08f, 0.0001f, 0.2f);
      sParameter.m_rCompMetaMaxRelease = Parameters.LOG2PARAM(1f, 0.005f, 2f);
      sParameter.m_rCompMetaCrest = Parameters.LOG2PARAM(0.2f, 0.005f, 2f);
      sParameter.m_rCompMetaAdapt = Parameters.LOG2PARAM(2.5f, 1f, 4f);
      sParameter.m_bSmartVolumeEnabled = 0;
      sParameter.m_rSVRatio = 0.5f;
      sParameter.m_rSVVolume = 1f;
      sParameter.m_rSVMaxGain = 4f;
      sParameter.m_bCureEnabled = 0;
      sParameter.m_uiCureLevel = 6226570U;
      sParameter.m_bTubeEnabled = 0;
      sParameter.m_rPostVolume = 1f;
    }
  }
}
