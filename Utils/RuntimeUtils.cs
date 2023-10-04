using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace ViPER4WindowsBin.Utils
{
    public class RuntimeUtils
    {
        public class GeneralUtils
        {
            public static string CharArrayToString(char[] caArray)
            {
                string str1 = new string(caArray);
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
                Array.Copy(charArray, destinationArray, length);
                string str2 = new string(destinationArray);
                return string.IsNullOrEmpty(str2) ? "" : str2;
            }
        }

        public class EqualizerUtils
        {
            [DllImport("Utils.dll")]
            private static extern void EstimateEqualizer(
              float[] rpEQBands,
              IntPtr rpResponses,
              ref int ipResponseLength,
              int nBandCount,
              int nWindow,
              int nType);

            public static float[] EstimateEqualizerResponse(float[] rpEQBands)
            {
                if (rpEQBands == null)
                    return null;
                if (rpEQBands.Length != 18)
                    return null;
                int ipResponseLength = 65536;
                float[] numArray = new float[ipResponseLength];
                for (int index = 0; index < ipResponseLength; ++index)
                    numArray[index] = 0.0f;
                IntPtr rpResponses = Marshal.UnsafeAddrOfPinnedArrayElement((Array)numArray, 0);
                EstimateEqualizer(rpEQBands, rpResponses, ref ipResponseLength, short.MaxValue, 0, 0);
                float num1 = 0.0f;
                for (int index = 0; index < ipResponseLength; ++index)
                {
                    if (numArray[index] > (double)num1)
                        num1 = numArray[index];
                }
                if ((double)num1 <= 1E-08)
                {
                    for (int index = 0; index < ipResponseLength; ++index)
                        numArray[index] = 0.0f;
                }
                else
                {
                    float num2 = 1f / num1;
                    for (int index = 0; index < ipResponseLength; ++index)
                    {
                        numArray[index] *= num2;
                        if (numArray[index] > 1.0)
                            numArray[index] = 1f;
                    }
                }
                float[] destinationArray = new float[ipResponseLength];
                Array.Copy(numArray, destinationArray, ipResponseLength);
                return destinationArray;
            }
        }

        public class ImpulseResponseUtils
        {
            [DllImport("Utils.dll", CharSet = CharSet.Unicode)]
            private static extern uint GetImpulseResponseLength(
              string pszFilePathName,
              ref int piChannels);

            [DllImport("Utils.dll", CharSet = CharSet.Unicode)]
            private static extern int EstimateImpulseResponse(
              string pszFilePathName,
              IntPtr rpBuffer,
              uint nBufferSize);

            public static float[] EstimateImpulseResponseSample(
              string szIRSPathName,
              out int nChannelCount)
            {
                nChannelCount = 0;
                int piChannels = 0;
                uint impulseResponseLength = GetImpulseResponseLength(szIRSPathName, ref piChannels);
                if (impulseResponseLength == 0U || piChannels == 0)
                    return null;
                IntPtr num = Marshal.AllocHGlobal((int)impulseResponseLength * 4);
                if (EstimateImpulseResponse(szIRSPathName, num, impulseResponseLength) == 0)
                {
                    Marshal.FreeHGlobal(num);
                    return null;
                }
                nChannelCount = piChannels;
                float[] destination = new float[(int)(IntPtr)impulseResponseLength];
                Marshal.Copy(num, destination, 0, (int)impulseResponseLength);
                Marshal.FreeHGlobal(num);
                return destination;
            }
        }

        public class EffectDriver
        {
            [DllImport("ViPER4Windows.dll", CharSet = CharSet.Ansi)]
            private static extern uint GetDriverVersion(int nIndex);

            [DllImport("ViPER4Windows.dll", CharSet = CharSet.Ansi)]
            private static extern IntPtr GetDriverCodeName();

            public static uint GetDriverMainVersion()
            {
                return GetDriverVersion(0);
            }

            public static uint GetDriverSubVersion()
            {
                return GetDriverVersion(1);
            }

            public static uint GetDriverExtVersion()
            {
                return GetDriverVersion(2);
            }

            public static string GetVersion()
            {
                return GetDriverMainVersion().ToString() + "." + GetDriverSubVersion().ToString() + "." + GetDriverExtVersion().ToString();
            }

            public static string GetCodeName()
            {
                return Marshal.PtrToStringAnsi(GetDriverCodeName());
            }
        }

        public class ConfigProxy
        {
            private readonly int kParameterCommitTime = 500;
            private ParamOfBaseSystem paramSystem = new ParamOfBaseSystem();
            private ParamOfMusicMode paramMusic = new ParamOfMusicMode();
            private ParamOfMovieMode paramMovie = new ParamOfMovieMode();
            private ParamOfFreestyle paramFreestyle = new ParamOfFreestyle();
            private IntPtr ptrConfigProxy = IntPtr.Zero;
            private readonly string szConfigFilePathName = "";
            private Thread thUpdatingThread;
            private readonly Mutex mxUpdatingMutex = new Mutex();
            private bool bThreadFinished;
            private bool bKillThread;
            private ulong u64UpdateSignal;

            [DllImport("ConfigProxy.dll", CharSet = CharSet.Unicode)]
            private static extern int CheckConfigCompatibility(string pszConfigFilePathName);

            [DllImport("ConfigProxy.dll", CharSet = CharSet.Unicode)]
            private static extern uint GetConfigVersion(string pszConfigFilePathName);

            [DllImport("ConfigProxy.dll", CharSet = CharSet.Unicode)]
            private static extern void Update_1_0_1(string pszConfigFilePathName);

            [DllImport("ConfigProxy.dll", CharSet = CharSet.Unicode)]
            private static extern IntPtr CreateProxy();

            [DllImport("ConfigProxy.dll", CharSet = CharSet.Unicode)]
            private static extern void DestoryProxy(IntPtr pInstance);

            [DllImport("ConfigProxy.dll", CharSet = CharSet.Unicode)]
            private static extern int UpdateSystemParameter(
              IntPtr pParameter,
              uint uiParameterSize,
              IntPtr pInstance);

            [DllImport("ConfigProxy.dll", CharSet = CharSet.Unicode)]
            private static extern int UpdateMusicParameter(
              IntPtr pParameter,
              uint uiParameterSize,
              IntPtr pInstance);

            [DllImport("ConfigProxy.dll", CharSet = CharSet.Unicode)]
            private static extern int UpdateMovieParameter(
              IntPtr pParameter,
              uint uiParameterSize,
              IntPtr pInstance);

            [DllImport("ConfigProxy.dll", CharSet = CharSet.Unicode)]
            private static extern int UpdateFreestyleParameter(
              IntPtr pParameter,
              uint uiParameterSize,
              IntPtr pInstance);

            [DllImport("ConfigProxy.dll", CharSet = CharSet.Unicode)]
            private static extern int MarshalSystemParameter(
              IntPtr pParameter,
              uint uiParameterSize,
              IntPtr pInstance);

            [DllImport("ConfigProxy.dll", CharSet = CharSet.Unicode)]
            private static extern void Commit(string pszConfigFilePathName, IntPtr pInstance);

            public static bool CheckConfigVersion(string szConfigPathName)
            {
                return CheckConfigCompatibility(szConfigPathName) != 0;
            }

            public static void UpdateConfigToCurrent(string szConfigPathName)
            {
                if (GetConfigVersion(szConfigPathName) != 16777217U)
                    return;
                Update_1_0_1(szConfigPathName);
            }

            public ConfigProxy(string szConfigPathName)
            {
                szConfigFilePathName = szConfigPathName;
                Parameters.LoadDefaultParameter(ref paramSystem);
                Parameters.LoadDefaultParameter(ref paramMusic);
                Parameters.LoadDefaultParameter(ref paramMovie);
                Parameters.LoadDefaultParameter(ref paramFreestyle);
                ptrConfigProxy = CreateProxy();
                u64UpdateSignal = 0UL;
                if (ptrConfigProxy != IntPtr.Zero)
                {
                    thUpdatingThread = new Thread(new ParameterizedThreadStart(UpdatingThread))
                    {
                        IsBackground = true
                    };
                    bThreadFinished = false;
                    bKillThread = false;
                    thUpdatingThread.Start(this);
                }
                else
                {
                    thUpdatingThread = null;
                    bThreadFinished = true;
                    bKillThread = false;
                }
            }

            ~ConfigProxy() => Dispose();

            public void Dispose()
            {
                if (thUpdatingThread != null)
                {
                    DateTime now = DateTime.Now;
                    bKillThread = true;
                    while (!bThreadFinished)
                    {
                        if (DateTime.Now.Subtract(now).TotalMilliseconds > 200.0)
                        {
                            thUpdatingThread.Abort();
                            break;
                        }
                        Thread.Sleep(10);
                    }
                }
                thUpdatingThread = null;
                bThreadFinished = true;
                bKillThread = false;
                u64UpdateSignal = 0UL;
                if (ptrConfigProxy != IntPtr.Zero)
                    DestoryProxy(ptrConfigProxy);
                ptrConfigProxy = IntPtr.Zero;
            }

            public bool ProxyUsable()
            {
                return !(ptrConfigProxy == IntPtr.Zero);
            }

            public void UpdateParameter(
              ParamOfBaseSystem sParameter)
            {
                mxUpdatingMutex.WaitOne();
                paramSystem = sParameter;
                if (ptrConfigProxy == IntPtr.Zero)
                {
                    mxUpdatingMutex.ReleaseMutex();
                }
                else
                {
                    IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ParamOfBaseSystem)));
                    Marshal.StructureToPtr((object)paramSystem, num, false);
                    MarshalSystemParameter(num, (uint)Marshal.SizeOf(typeof(ParamOfBaseSystem)), ptrConfigProxy);
                    Marshal.FreeHGlobal(num);
                    mxUpdatingMutex.ReleaseMutex();
                }
            }

            public void UpdateParameter(
              ParamOfMusicMode sParameter)
            {
                mxUpdatingMutex.WaitOne();
                paramMusic = sParameter;
                if (ptrConfigProxy == IntPtr.Zero)
                {
                    mxUpdatingMutex.ReleaseMutex();
                }
                else
                {
                    IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ParamOfMusicMode)));
                    Marshal.StructureToPtr((object)paramMusic, num, false);
                    UpdateMusicParameter(num, (uint)Marshal.SizeOf(typeof(ParamOfMusicMode)), ptrConfigProxy);
                    Marshal.FreeHGlobal(num);
                    mxUpdatingMutex.ReleaseMutex();
                }
            }

            public void UpdateParameter(
              ParamOfMovieMode sParameter)
            {
                mxUpdatingMutex.WaitOne();
                paramMovie = sParameter;
                if (ptrConfigProxy == IntPtr.Zero)
                {
                    mxUpdatingMutex.ReleaseMutex();
                }
                else
                {
                    IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ParamOfMovieMode)));
                    Marshal.StructureToPtr((object)paramMovie, num, false);
                    UpdateMovieParameter(num, (uint)Marshal.SizeOf(typeof(ParamOfMovieMode)), ptrConfigProxy);
                    Marshal.FreeHGlobal(num);
                    mxUpdatingMutex.ReleaseMutex();
                }
            }

            public void UpdateParameter(
              ParamOfFreestyle sParameter)
            {
                mxUpdatingMutex.WaitOne();
                paramFreestyle = sParameter;
                if (ptrConfigProxy == IntPtr.Zero)
                {
                    mxUpdatingMutex.ReleaseMutex();
                }
                else
                {
                    IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ParamOfFreestyle)));
                    Marshal.StructureToPtr((object)paramFreestyle, num, false);
                    UpdateFreestyleParameter(num, (uint)Marshal.SizeOf(typeof(ParamOfFreestyle)), ptrConfigProxy);
                    Marshal.FreeHGlobal(num);
                    mxUpdatingMutex.ReleaseMutex();
                }
            }

            public void SyncConfig()
            {
                mxUpdatingMutex.WaitOne();
                ++u64UpdateSignal;
                mxUpdatingMutex.ReleaseMutex();
            }

            private void UpdatingThread(object obj)
            {
                ConfigProxy configProxy = obj as ConfigProxy;
                configProxy.bThreadFinished = false;
                DateTime now = DateTime.Now;
                while (!configProxy.bKillThread)
                {
                    if ((int)DateTime.Now.Subtract(now).TotalMilliseconds > kParameterCommitTime)
                    {
                        mxUpdatingMutex.WaitOne();
                        if (configProxy.ptrConfigProxy != IntPtr.Zero && configProxy.u64UpdateSignal > 0UL)
                        {
                            Commit(configProxy.szConfigFilePathName, configProxy.ptrConfigProxy);
                            configProxy.u64UpdateSignal = 0UL;
                            now = DateTime.Now;
                        }
                        mxUpdatingMutex.ReleaseMutex();
                    }
                    Thread.Sleep(10);
                }
                configProxy.bThreadFinished = true;
            }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct ParamOfBaseSystem_1_0_1
            {
                [MarshalAs(UnmanagedType.I4)]
                public int m_bEffectEnabled;
                [MarshalAs(UnmanagedType.U4)]
                public uint m_nEffectMode;
                [MarshalAs(UnmanagedType.I4)]
                public int m_nFilterShortLen;
                [MarshalAs(UnmanagedType.I4)]
                public int m_nFilterMediumLen;
                [MarshalAs(UnmanagedType.I4)]
                public int m_nFilterLongLen;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rChannelPan;
            }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct ParamOfBaseSystem
            {
                [MarshalAs(UnmanagedType.I4)]
                public int m_bEffectEnabled;
                [MarshalAs(UnmanagedType.U4)]
                public uint m_nEffectMode;
                [MarshalAs(UnmanagedType.I4)]
                public int m_nFilterShortLen;
                [MarshalAs(UnmanagedType.I4)]
                public int m_nFilterMediumLen;
                [MarshalAs(UnmanagedType.I4)]
                public int m_nFilterLongLen;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rChannelPan;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bVirtApplied;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.R4)]
                public float[] m_rpChannelAngle_00;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.R4)]
                public float[] m_rpChannelAngle_01;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.R4)]
                public float[] m_rpChannelAngle_02;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.R4)]
                public float[] m_rpChannelAngle_03;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.R4)]
                public float[] m_rpChannelAngle_04;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.R4)]
                public float[] m_rpChannelAngle_05;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.R4)]
                public float[] m_rpChannelAngle_06;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.R4)]
                public float[] m_rpChannelAngle_07;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9, ArraySubType = UnmanagedType.R4)]
                public float[] m_rpChannelAngle_08;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bEnvRealizeEnabled;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bEnvRealizePreprocess;
                [MarshalAs(UnmanagedType.I4)]
                public int m_nEnvRealizePreset;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rEnvRealizeDrySignal;
            }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct ParamOfMusicMode
            {
                [MarshalAs(UnmanagedType.R4)]
                public float m_rPreVolume;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bConvolverEnabled;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rConvolverIRGain;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260, ArraySubType = UnmanagedType.U2)]
                public char[] m_szConvolverIR;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bViPERBassEnabled;
                [MarshalAs(UnmanagedType.I4)]
                public int m_nViPERBassSpkSize;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rViPERBassFactor;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bViPERClarityEnabled;
                [MarshalAs(UnmanagedType.I4)]
                public int m_nViPERClarityMode;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rViPERClarityFactor;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bSurroundEnabled;
                [MarshalAs(UnmanagedType.I4)]
                public int m_nVHERoomSize;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bReverbEnabled;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbSize;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbPredelay;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbDamping;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbDensity;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbBandwidth;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbDecay;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbEarlyMix;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbMix;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbGain;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bEqualizerEnabled;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18, ArraySubType = UnmanagedType.R4)]
                public float[] m_rpEqualizerBands;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bCompressorEnabled;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bCompAutoKnee;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bCompAutoGain;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bCompAutoAttack;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bCompAutoRelease;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompThreshold;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompRatio;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompKneeWidth;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompGain;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompAttack;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompRelease;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bCureEnabled;
                [MarshalAs(UnmanagedType.U4)]
                public uint m_uiCureLevel;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bTubeEnabled;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rPostVolume;
            }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct ParamOfMovieMode
            {
                [MarshalAs(UnmanagedType.R4)]
                public float m_rPreVolume;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bConvolverEnabled;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rConvolverIRGain;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260, ArraySubType = UnmanagedType.U2)]
                public char[] m_szConvolverIR;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bViPERBassEnabled;
                [MarshalAs(UnmanagedType.I4)]
                public int m_nViPERBassSpkSize;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rViPERBassFactor;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bViPERClarityEnabled;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rViPERClarityFactor;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bSurroundEnabled;
                [MarshalAs(UnmanagedType.R4)]
                public float m_r3DSurroundStereo;
                [MarshalAs(UnmanagedType.R4)]
                public float m_r3DSurroundImage;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bReverbEnabled;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbSize;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbPredelay;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbDamping;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbDensity;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbBandwidth;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbDecay;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbEarlyMix;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbMix;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbGain;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bEqualizerEnabled;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18, ArraySubType = UnmanagedType.R4)]
                public float[] m_rpEqualizerBands;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bCompressorEnabled;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bCompAutoKnee;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bCompAutoGain;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bCompAutoAttack;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bCompAutoRelease;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompThreshold;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompRatio;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompKneeWidth;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompGain;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompAttack;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompRelease;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bSmartVolumeEnabled;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rSVRatio;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rSVVolume;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rSVMaxGain;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rPostVolume;
            }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct ParamOfFreestyle
            {
                [MarshalAs(UnmanagedType.R4)]
                public float m_rPreVolume;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bConvolverEnabled;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rConvolverIRGain;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260, ArraySubType = UnmanagedType.U2)]
                public char[] m_szConvolverIR;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bViPERBassEnabled;
                [MarshalAs(UnmanagedType.I4)]
                public int m_nViPERBassMode;
                [MarshalAs(UnmanagedType.I4)]
                public int m_nViPERBassSpkSize;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rViPERBassFactor;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bViPERClarityEnabled;
                [MarshalAs(UnmanagedType.I4)]
                public int m_nViPERClarityMode;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rViPERClarityFactor;
                [MarshalAs(UnmanagedType.I4)]
                public int m_b3DSurroundEnabled;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bVHESurroundEnabled;
                [MarshalAs(UnmanagedType.R4)]
                public float m_r3DSurroundStereo;
                [MarshalAs(UnmanagedType.R4)]
                public float m_r3DSurroundImage;
                [MarshalAs(UnmanagedType.I4)]
                public int m_nVHERoomSize;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bReverbEnabled;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbSize;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbPredelay;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbDamping;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbDensity;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbBandwidth;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbDecay;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbEarlyMix;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbMix;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rReverbGain;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bEqualizerEnabled;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18, ArraySubType = UnmanagedType.R4)]
                public float[] m_rpEqualizerBands;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bCompressorEnabled;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bCompAutoKnee;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bCompAutoGain;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bCompAutoAttack;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bCompAutoRelease;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bCompAutoMetaNoClipping;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompThreshold;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompRatio;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompKneeWidth;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompGain;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompAttack;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompRelease;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompMetaKneeMult;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompMetaMaxAttack;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompMetaMaxRelease;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompMetaCrest;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rCompMetaAdapt;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bSmartVolumeEnabled;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rSVRatio;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rSVVolume;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rSVMaxGain;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bCureEnabled;
                [MarshalAs(UnmanagedType.U4)]
                public uint m_uiCureLevel;
                [MarshalAs(UnmanagedType.I4)]
                public int m_bTubeEnabled;
                [MarshalAs(UnmanagedType.R4)]
                public float m_rPostVolume;
            }
        }
    }
}
