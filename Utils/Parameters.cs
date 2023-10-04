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
            Array.Copy(charArray, destinationArray, charArray.Length);
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

        public static RuntimeUtils.ConfigProxy.ParamOfBaseSystem_1_0_1 DeserializeParamOfBaseSystem_1_0_1(
          byte[] baRawData)
        {
            Type type = typeof(RuntimeUtils.ConfigProxy.ParamOfBaseSystem_1_0_1);
            int num1 = Marshal.SizeOf(type);
            if (num1 != baRawData.Length)
                return new RuntimeUtils.ConfigProxy.ParamOfBaseSystem_1_0_1()
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
            return (RuntimeUtils.ConfigProxy.ParamOfBaseSystem_1_0_1)structure;
        }

        public static RuntimeUtils.ConfigProxy.ParamOfBaseSystem DeserializeParamOfBaseSystem(
          byte[] baRawData)
        {
            Type type = typeof(RuntimeUtils.ConfigProxy.ParamOfBaseSystem);
            int num1 = Marshal.SizeOf(type);
            if (num1 != baRawData.Length)
            {
                RuntimeUtils.ConfigProxy.ParamOfBaseSystem sParameter = new RuntimeUtils.ConfigProxy.ParamOfBaseSystem();
                LoadDefaultParameter(ref sParameter);
                return sParameter;
            }
            IntPtr num2 = Marshal.AllocHGlobal(num1);
            Marshal.Copy(baRawData, 0, num2, num1);
            object structure = Marshal.PtrToStructure(num2, type);
            Marshal.FreeHGlobal(num2);
            return (RuntimeUtils.ConfigProxy.ParamOfBaseSystem)structure;
        }

        public static RuntimeUtils.ConfigProxy.ParamOfMusicMode DeserializeParamOfMusicMode(
          byte[] baRawData)
        {
            Type type = typeof(RuntimeUtils.ConfigProxy.ParamOfMusicMode);
            int num1 = Marshal.SizeOf(type);
            if (num1 != baRawData.Length)
            {
                RuntimeUtils.ConfigProxy.ParamOfMusicMode sParameter = new RuntimeUtils.ConfigProxy.ParamOfMusicMode();
                LoadDefaultParameter(ref sParameter);
                return sParameter;
            }
            IntPtr num2 = Marshal.AllocHGlobal(num1);
            Marshal.Copy(baRawData, 0, num2, num1);
            object structure = Marshal.PtrToStructure(num2, type);
            Marshal.FreeHGlobal(num2);
            return (RuntimeUtils.ConfigProxy.ParamOfMusicMode)structure;
        }

        public static RuntimeUtils.ConfigProxy.ParamOfMovieMode DeserializeParamOfMovieMode(
          byte[] baRawData)
        {
            Type type = typeof(RuntimeUtils.ConfigProxy.ParamOfMovieMode);
            int num1 = Marshal.SizeOf(type);
            if (num1 != baRawData.Length)
            {
                RuntimeUtils.ConfigProxy.ParamOfMovieMode sParameter = new RuntimeUtils.ConfigProxy.ParamOfMovieMode();
                LoadDefaultParameter(ref sParameter);
                return sParameter;
            }
            IntPtr num2 = Marshal.AllocHGlobal(num1);
            Marshal.Copy(baRawData, 0, num2, num1);
            object structure = Marshal.PtrToStructure(num2, type);
            Marshal.FreeHGlobal(num2);
            return (RuntimeUtils.ConfigProxy.ParamOfMovieMode)structure;
        }

        public static RuntimeUtils.ConfigProxy.ParamOfFreestyle DeserializeParamOfFreestyle(
          byte[] baRawData)
        {
            Type type = typeof(RuntimeUtils.ConfigProxy.ParamOfFreestyle);
            int num1 = Marshal.SizeOf(type);
            if (num1 != baRawData.Length)
            {
                RuntimeUtils.ConfigProxy.ParamOfFreestyle sParameter = new RuntimeUtils.ConfigProxy.ParamOfFreestyle();
                LoadDefaultParameter(ref sParameter);
                return sParameter;
            }
            IntPtr num2 = Marshal.AllocHGlobal(num1);
            Marshal.Copy(baRawData, 0, num2, num1);
            object structure = Marshal.PtrToStructure(num2, type);
            Marshal.FreeHGlobal(num2);
            return (RuntimeUtils.ConfigProxy.ParamOfFreestyle)structure;
        }

        public static void SaveLocalPreset(
          string szFilePathName,
          RuntimeUtils.ConfigProxy.ParamOfBaseSystem paramBaseSystem,
          RuntimeUtils.ConfigProxy.ParamOfMusicMode paramMusicMode,
          RuntimeUtils.ConfigProxy.ParamOfMovieMode paramMovieMode,
          RuntimeUtils.ConfigProxy.ParamOfFreestyle paramFreestyle)
        {
            byte[] buffer1 = ParameterSerialize(paramBaseSystem);
            byte[] buffer2 = ParameterSerialize(paramMusicMode);
            byte[] buffer3 = ParameterSerialize(paramMovieMode);
            byte[] buffer4 = ParameterSerialize(paramFreestyle);
            if (buffer1 == null || buffer2 == null || buffer3 == null)
                return;
            if (buffer4 == null)
                return;
            try
            {
                FileStream fileStream = new FileStream(szFilePathName, FileMode.Create);
                byte[] buffer5 = new byte[14]
                {
           86,
           105,
           80,
           69,
           82,
           52,
           87,
           105,
           110,
           100,
           111,
           119,
           115,
           88
                };
                fileStream.Write(buffer5, 0, buffer5.Length);
                fileStream.WriteByte(1);
                fileStream.WriteByte(1);
                fileStream.WriteByte(1);
                fileStream.WriteByte(1);
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
                _ = (int)MessageBox.Show(stringBuilder.ToString(), GlobalMessages.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public static bool SavePreset(
          string szFilePathName,
          RuntimeUtils.ConfigProxy.ParamOfMusicMode paramMusicMode)
        {
            byte[] buffer1 = ParameterSerialize(paramMusicMode);
            if (buffer1 == null)
                return false;
            try
            {
                FileStream fileStream = new FileStream(szFilePathName, FileMode.Create);
                byte[] buffer2 = new byte[14]
                {
           86,
           105,
           80,
           69,
           82,
           52,
           87,
           105,
           110,
           100,
           111,
           119,
           115,
           88
                };
                fileStream.Write(buffer2, 0, buffer2.Length);
                fileStream.WriteByte(0);
                fileStream.WriteByte(1);
                fileStream.WriteByte(0);
                fileStream.WriteByte(0);
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
          RuntimeUtils.ConfigProxy.ParamOfMovieMode paramMovieMode)
        {
            byte[] buffer1 = ParameterSerialize(paramMovieMode);
            if (buffer1 == null)
                return false;
            try
            {
                FileStream fileStream = new FileStream(szFilePathName, FileMode.Create);
                byte[] buffer2 = new byte[14]
                {
           86,
           105,
           80,
           69,
           82,
           52,
           87,
           105,
           110,
           100,
           111,
           119,
           115,
           88
                };
                fileStream.Write(buffer2, 0, buffer2.Length);
                fileStream.WriteByte(0);
                fileStream.WriteByte(0);
                fileStream.WriteByte(1);
                fileStream.WriteByte(0);
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
          RuntimeUtils.ConfigProxy.ParamOfFreestyle paramFreestyle)
        {
            byte[] buffer1 = ParameterSerialize(paramFreestyle);
            if (buffer1 == null)
                return false;
            try
            {
                FileStream fileStream = new FileStream(szFilePathName, FileMode.Create);
                byte[] buffer2 = new byte[14]
                {
           86,
           105,
           80,
           69,
           82,
           52,
           87,
           105,
           110,
           100,
           111,
           119,
           115,
           88
                };
                fileStream.Write(buffer2, 0, buffer2.Length);
                fileStream.WriteByte(0);
                fileStream.WriteByte(0);
                fileStream.WriteByte(0);
                fileStream.WriteByte(1);
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
          ref RuntimeUtils.ConfigProxy.ParamOfBaseSystem paramBaseSystem,
          ref RuntimeUtils.ConfigProxy.ParamOfMusicMode paramMusicMode,
          ref RuntimeUtils.ConfigProxy.ParamOfMovieMode paramMovieMode,
          ref RuntimeUtils.ConfigProxy.ParamOfFreestyle paramFreestyle,
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
           86,
           105,
           80,
           69,
           82,
           52,
           87,
           105,
           110,
           100,
           111,
           119,
           115,
           88
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
                    if (buffer[index] != numArray1[index])
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
                    num5 += Marshal.SizeOf(typeof(RuntimeUtils.ConfigProxy.ParamOfBaseSystem));
                if (num2 == 1)
                    num5 += Marshal.SizeOf(typeof(RuntimeUtils.ConfigProxy.ParamOfMusicMode));
                if (num3 == 1)
                    num5 += Marshal.SizeOf(typeof(RuntimeUtils.ConfigProxy.ParamOfMovieMode));
                if (num4 == 1)
                    num5 += Marshal.SizeOf(typeof(RuntimeUtils.ConfigProxy.ParamOfFreestyle));
                if (num5 != length)
                {
                    long num6 = 18;
                    if (num1 == 1)
                        num6 += Marshal.SizeOf(typeof(RuntimeUtils.ConfigProxy.ParamOfBaseSystem_1_0_1));
                    if (num2 == 1)
                        num6 += Marshal.SizeOf(typeof(RuntimeUtils.ConfigProxy.ParamOfMusicMode));
                    if (num3 == 1)
                        num6 += Marshal.SizeOf(typeof(RuntimeUtils.ConfigProxy.ParamOfMovieMode));
                    if (num4 == 1)
                        num6 += Marshal.SizeOf(typeof(RuntimeUtils.ConfigProxy.ParamOfFreestyle));
                    if (num6 == length)
                    {
                        if (num1 == 1)
                        {
                            byte[] numArray2 = new byte[Marshal.SizeOf((object)new RuntimeUtils.ConfigProxy.ParamOfBaseSystem_1_0_1())];
                            if (fileStream.Read(numArray2, 0, numArray2.Length) != numArray2.Length)
                            {
                                fileStream.Close();
                                bPBaseSystem = false;
                                bPMusicMode = false;
                                bPMovieMode = false;
                                bPFreestyle = false;
                                return false;
                            }
                            RuntimeUtils.ConfigProxy.ParamOfBaseSystem_1_0_1 paramOfBaseSystem101 = DeserializeParamOfBaseSystem_1_0_1(numArray2);
                            LoadDefaultParameter(ref paramBaseSystem);
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
                            byte[] numArray3 = new byte[Marshal.SizeOf((object)paramMusicMode)];
                            if (fileStream.Read(numArray3, 0, numArray3.Length) != numArray3.Length)
                            {
                                fileStream.Close();
                                bPBaseSystem = false;
                                bPMusicMode = false;
                                bPMovieMode = false;
                                bPFreestyle = false;
                                return false;
                            }
                            paramMusicMode = DeserializeParamOfMusicMode(numArray3);
                            bPMusicMode = true;
                        }
                        if (num3 == 1)
                        {
                            byte[] numArray4 = new byte[Marshal.SizeOf((object)paramMovieMode)];
                            if (fileStream.Read(numArray4, 0, numArray4.Length) != numArray4.Length)
                            {
                                fileStream.Close();
                                bPBaseSystem = false;
                                bPMusicMode = false;
                                bPMovieMode = false;
                                bPFreestyle = false;
                                return false;
                            }
                            paramMovieMode = DeserializeParamOfMovieMode(numArray4);
                            bPMovieMode = true;
                        }
                        if (num4 == 1)
                        {
                            byte[] numArray5 = new byte[Marshal.SizeOf((object)paramFreestyle)];
                            if (fileStream.Read(numArray5, 0, numArray5.Length) != numArray5.Length)
                            {
                                fileStream.Close();
                                bPBaseSystem = false;
                                bPMusicMode = false;
                                bPMovieMode = false;
                                bPFreestyle = false;
                                return false;
                            }
                            paramFreestyle = DeserializeParamOfFreestyle(numArray5);
                            bPFreestyle = true;
                        }
                        fileStream.Close();
                        if (bPBaseSystem && bPMusicMode && bPMovieMode && bPFreestyle)
                            SaveLocalPreset(szFilePathName, paramBaseSystem, paramMusicMode, paramMovieMode, paramFreestyle);
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
                    byte[] numArray6 = new byte[Marshal.SizeOf((object)paramBaseSystem)];
                    if (fileStream.Read(numArray6, 0, numArray6.Length) != numArray6.Length)
                    {
                        fileStream.Close();
                        bPBaseSystem = false;
                        bPMusicMode = false;
                        bPMovieMode = false;
                        bPFreestyle = false;
                        return false;
                    }
                    paramBaseSystem = DeserializeParamOfBaseSystem(numArray6);
                    bPBaseSystem = true;
                }
                if (num2 == 1)
                {
                    byte[] numArray7 = new byte[Marshal.SizeOf((object)paramMusicMode)];
                    if (fileStream.Read(numArray7, 0, numArray7.Length) != numArray7.Length)
                    {
                        fileStream.Close();
                        bPBaseSystem = false;
                        bPMusicMode = false;
                        bPMovieMode = false;
                        bPFreestyle = false;
                        return false;
                    }
                    paramMusicMode = DeserializeParamOfMusicMode(numArray7);
                    bPMusicMode = true;
                }
                if (num3 == 1)
                {
                    byte[] numArray8 = new byte[Marshal.SizeOf((object)paramMovieMode)];
                    if (fileStream.Read(numArray8, 0, numArray8.Length) != numArray8.Length)
                    {
                        fileStream.Close();
                        bPBaseSystem = false;
                        bPMusicMode = false;
                        bPMovieMode = false;
                        bPFreestyle = false;
                        return false;
                    }
                    paramMovieMode = DeserializeParamOfMovieMode(numArray8);
                    bPMovieMode = true;
                }
                if (num4 == 1)
                {
                    byte[] numArray9 = new byte[Marshal.SizeOf((object)paramFreestyle)];
                    if (fileStream.Read(numArray9, 0, numArray9.Length) != numArray9.Length)
                    {
                        fileStream.Close();
                        bPBaseSystem = false;
                        bPMusicMode = false;
                        bPMovieMode = false;
                        bPFreestyle = false;
                        return false;
                    }
                    paramFreestyle = DeserializeParamOfFreestyle(numArray9);
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

        public static float LOG2PARAM(float x, float mn, float mx)
        {
            return (float)((Math.Log((double)x) - Math.Log((double)mn)) / (Math.Log((double)mx) - Math.Log((double)mn)));
        }

        public static float LIN2PARAM(float x, float mn, float mx)
        {
            return (float)(((double)x - (double)mn) / ((double)mx - (double)mn));
        }

        public static float PARAM2LOG(float x, float mn, float mx)
        {
            return (float)Math.Exp(Math.Log((double)mn) + (double)x * (Math.Log((double)mx) - Math.Log((double)mn)));
        }

        public static float PARAM2LIN(float x, float mn, float mx)
        {
            return mn + x * (mx - mn);
        }

        public static void LoadDefaultParameter(
          ref RuntimeUtils.ConfigProxy.ParamOfBaseSystem sParameter)
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
          ref RuntimeUtils.ConfigProxy.ParamOfMusicMode sParameter)
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
            sParameter.m_rCompAttack = LOG2PARAM(0.005f, 0.0001f, 0.2f);
            sParameter.m_rCompRelease = LOG2PARAM(0.05f, 0.005f, 2f);
            sParameter.m_bCureEnabled = 0;
            sParameter.m_uiCureLevel = 6226570U;
            sParameter.m_bTubeEnabled = 0;
            sParameter.m_rPostVolume = 1f;
        }

        public static void LoadDefaultParameter(
          ref RuntimeUtils.ConfigProxy.ParamOfMovieMode sParameter)
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
            sParameter.m_rCompAttack = LOG2PARAM(0.005f, 0.0001f, 0.2f);
            sParameter.m_rCompRelease = LOG2PARAM(0.05f, 0.005f, 2f);
            sParameter.m_bSmartVolumeEnabled = 0;
            sParameter.m_rSVRatio = 0.5f;
            sParameter.m_rSVVolume = 1f;
            sParameter.m_rSVMaxGain = 4f;
            sParameter.m_rPostVolume = 1f;
        }

        public static void LoadDefaultParameter(
          ref RuntimeUtils.ConfigProxy.ParamOfFreestyle sParameter)
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
            sParameter.m_rCompAttack = LOG2PARAM(0.005f, 0.0001f, 0.2f);
            sParameter.m_rCompRelease = LOG2PARAM(0.05f, 0.005f, 2f);
            sParameter.m_rCompMetaKneeMult = LIN2PARAM(2f, 0.0f, 4f);
            sParameter.m_rCompMetaMaxAttack = LOG2PARAM(0.08f, 0.0001f, 0.2f);
            sParameter.m_rCompMetaMaxRelease = LOG2PARAM(1f, 0.005f, 2f);
            sParameter.m_rCompMetaCrest = LOG2PARAM(0.2f, 0.005f, 2f);
            sParameter.m_rCompMetaAdapt = LOG2PARAM(2.5f, 1f, 4f);
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
