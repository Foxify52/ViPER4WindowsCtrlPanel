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
        Array.Copy((Array) charArray, (Array) destinationArray, length);
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
          return (float[]) null;
        if (rpEQBands.Length != 18)
          return (float[]) null;
        int ipResponseLength = 65536;
        float[] numArray = new float[ipResponseLength];
        for (int index = 0; index < ipResponseLength; ++index)
          numArray[index] = 0.0f;
        IntPtr rpResponses = Marshal.UnsafeAddrOfPinnedArrayElement((Array) numArray, 0);
        RuntimeUtils.EqualizerUtils.EstimateEqualizer(rpEQBands, rpResponses, ref ipResponseLength, (int) short.MaxValue, 0, 0);
        float num1 = 0.0f;
        for (int index = 0; index < ipResponseLength; ++index)
        {
          if ((double) numArray[index] > (double) num1)
            num1 = numArray[index];
        }
        if ((double) num1 <= 1E-08)
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
            if ((double) numArray[index] > 1.0)
              numArray[index] = 1f;
          }
        }
        float[] destinationArray = new float[ipResponseLength];
        Array.Copy((Array) numArray, (Array) destinationArray, ipResponseLength);
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
        uint impulseResponseLength = RuntimeUtils.ImpulseResponseUtils.GetImpulseResponseLength(szIRSPathName, ref piChannels);
        if (impulseResponseLength == 0U || piChannels == 0)
          return (float[]) null;
        IntPtr num = Marshal.AllocHGlobal((int) impulseResponseLength * 4);
        if (RuntimeUtils.ImpulseResponseUtils.EstimateImpulseResponse(szIRSPathName, num, impulseResponseLength) == 0)
        {
          Marshal.FreeHGlobal(num);
          return (float[]) null;
        }
        nChannelCount = piChannels;
        float[] destination = new float[(int)(IntPtr) impulseResponseLength];
        Marshal.Copy(num, destination, 0, (int) impulseResponseLength);
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

      public static uint GetDriverMainVersion() => RuntimeUtils.EffectDriver.GetDriverVersion(0);

      public static uint GetDriverSubVersion() => RuntimeUtils.EffectDriver.GetDriverVersion(1);

      public static uint GetDriverExtVersion() => RuntimeUtils.EffectDriver.GetDriverVersion(2);

      public static string GetVersion() => RuntimeUtils.EffectDriver.GetDriverMainVersion().ToString() + "." + RuntimeUtils.EffectDriver.GetDriverSubVersion().ToString() + "." + RuntimeUtils.EffectDriver.GetDriverExtVersion().ToString();

      public static string GetCodeName() => Marshal.PtrToStringAnsi(RuntimeUtils.EffectDriver.GetDriverCodeName());
    }

    public class ConfigProxy
    {
      private readonly int kParameterCommitTime = 500;
      private RuntimeUtils.ConfigProxy._ParamOfBaseSystem paramSystem = new RuntimeUtils.ConfigProxy._ParamOfBaseSystem();
      private RuntimeUtils.ConfigProxy._ParamOfMusicMode paramMusic = new RuntimeUtils.ConfigProxy._ParamOfMusicMode();
      private RuntimeUtils.ConfigProxy._ParamOfMovieMode paramMovie = new RuntimeUtils.ConfigProxy._ParamOfMovieMode();
      private RuntimeUtils.ConfigProxy._ParamOfFreestyle paramFreestyle = new RuntimeUtils.ConfigProxy._ParamOfFreestyle();
      private IntPtr ptrConfigProxy = IntPtr.Zero;
      private string szConfigFilePathName = "";
      private Thread thUpdatingThread;
      private Mutex mxUpdatingMutex = new Mutex();
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

      public static bool CheckConfigVersion(string szConfigPathName) => RuntimeUtils.ConfigProxy.CheckConfigCompatibility(szConfigPathName) != 0;

      public static void UpdateConfigToCurrent(string szConfigPathName)
      {
        if (RuntimeUtils.ConfigProxy.GetConfigVersion(szConfigPathName) != 16777217U)
          return;
        RuntimeUtils.ConfigProxy.Update_1_0_1(szConfigPathName);
      }

      public ConfigProxy(string szConfigPathName)
      {
        this.szConfigFilePathName = szConfigPathName;
        Parameters.LoadDefaultParameter(ref this.paramSystem);
        Parameters.LoadDefaultParameter(ref this.paramMusic);
        Parameters.LoadDefaultParameter(ref this.paramMovie);
        Parameters.LoadDefaultParameter(ref this.paramFreestyle);
        this.ptrConfigProxy = RuntimeUtils.ConfigProxy.CreateProxy();
        this.u64UpdateSignal = 0UL;
        if (this.ptrConfigProxy != IntPtr.Zero)
        {
          this.thUpdatingThread = new Thread(new ParameterizedThreadStart(this.UpdatingThread));
          this.thUpdatingThread.IsBackground = true;
          this.bThreadFinished = false;
          this.bKillThread = false;
          this.thUpdatingThread.Start((object) this);
        }
        else
        {
          this.thUpdatingThread = (Thread) null;
          this.bThreadFinished = true;
          this.bKillThread = false;
        }
      }

      ~ConfigProxy() => this.Dispose();

      public void Dispose()
      {
        if (this.thUpdatingThread != null)
        {
          DateTime now = DateTime.Now;
          this.bKillThread = true;
          while (!this.bThreadFinished)
          {
            if (DateTime.Now.Subtract(now).TotalMilliseconds > 200.0)
            {
              this.thUpdatingThread.Abort();
              break;
            }
            Thread.Sleep(10);
          }
        }
        this.thUpdatingThread = (Thread) null;
        this.bThreadFinished = true;
        this.bKillThread = false;
        this.u64UpdateSignal = 0UL;
        if (this.ptrConfigProxy != IntPtr.Zero)
          RuntimeUtils.ConfigProxy.DestoryProxy(this.ptrConfigProxy);
        this.ptrConfigProxy = IntPtr.Zero;
      }

      public bool ProxyUsable() => !(this.ptrConfigProxy == IntPtr.Zero);

      public void UpdateParameter(
        RuntimeUtils.ConfigProxy._ParamOfBaseSystem sParameter)
      {
        this.mxUpdatingMutex.WaitOne();
        this.paramSystem = sParameter;
        if (this.ptrConfigProxy == IntPtr.Zero)
        {
          this.mxUpdatingMutex.ReleaseMutex();
        }
        else
        {
          IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (RuntimeUtils.ConfigProxy._ParamOfBaseSystem)));
          Marshal.StructureToPtr((object) this.paramSystem, num, false);
          RuntimeUtils.ConfigProxy.MarshalSystemParameter(num, (uint) Marshal.SizeOf(typeof (RuntimeUtils.ConfigProxy._ParamOfBaseSystem)), this.ptrConfigProxy);
          Marshal.FreeHGlobal(num);
          this.mxUpdatingMutex.ReleaseMutex();
        }
      }

      public void UpdateParameter(
        RuntimeUtils.ConfigProxy._ParamOfMusicMode sParameter)
      {
        this.mxUpdatingMutex.WaitOne();
        this.paramMusic = sParameter;
        if (this.ptrConfigProxy == IntPtr.Zero)
        {
          this.mxUpdatingMutex.ReleaseMutex();
        }
        else
        {
          IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (RuntimeUtils.ConfigProxy._ParamOfMusicMode)));
          Marshal.StructureToPtr((object) this.paramMusic, num, false);
          RuntimeUtils.ConfigProxy.UpdateMusicParameter(num, (uint) Marshal.SizeOf(typeof (RuntimeUtils.ConfigProxy._ParamOfMusicMode)), this.ptrConfigProxy);
          Marshal.FreeHGlobal(num);
          this.mxUpdatingMutex.ReleaseMutex();
        }
      }

      public void UpdateParameter(
        RuntimeUtils.ConfigProxy._ParamOfMovieMode sParameter)
      {
        this.mxUpdatingMutex.WaitOne();
        this.paramMovie = sParameter;
        if (this.ptrConfigProxy == IntPtr.Zero)
        {
          this.mxUpdatingMutex.ReleaseMutex();
        }
        else
        {
          IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (RuntimeUtils.ConfigProxy._ParamOfMovieMode)));
          Marshal.StructureToPtr((object) this.paramMovie, num, false);
          RuntimeUtils.ConfigProxy.UpdateMovieParameter(num, (uint) Marshal.SizeOf(typeof (RuntimeUtils.ConfigProxy._ParamOfMovieMode)), this.ptrConfigProxy);
          Marshal.FreeHGlobal(num);
          this.mxUpdatingMutex.ReleaseMutex();
        }
      }

      public void UpdateParameter(
        RuntimeUtils.ConfigProxy._ParamOfFreestyle sParameter)
      {
        this.mxUpdatingMutex.WaitOne();
        this.paramFreestyle = sParameter;
        if (this.ptrConfigProxy == IntPtr.Zero)
        {
          this.mxUpdatingMutex.ReleaseMutex();
        }
        else
        {
          IntPtr num = Marshal.AllocHGlobal(Marshal.SizeOf(typeof (RuntimeUtils.ConfigProxy._ParamOfFreestyle)));
          Marshal.StructureToPtr((object) this.paramFreestyle, num, false);
          RuntimeUtils.ConfigProxy.UpdateFreestyleParameter(num, (uint) Marshal.SizeOf(typeof (RuntimeUtils.ConfigProxy._ParamOfFreestyle)), this.ptrConfigProxy);
          Marshal.FreeHGlobal(num);
          this.mxUpdatingMutex.ReleaseMutex();
        }
      }

      public void SyncConfig()
      {
        this.mxUpdatingMutex.WaitOne();
        ++this.u64UpdateSignal;
        this.mxUpdatingMutex.ReleaseMutex();
      }

      private void UpdatingThread(object obj)
      {
        RuntimeUtils.ConfigProxy configProxy = obj as RuntimeUtils.ConfigProxy;
        configProxy.bThreadFinished = false;
        DateTime now = DateTime.Now;
        while (!configProxy.bKillThread)
        {
          if ((int) DateTime.Now.Subtract(now).TotalMilliseconds > this.kParameterCommitTime)
          {
            this.mxUpdatingMutex.WaitOne();
            if (configProxy.ptrConfigProxy != IntPtr.Zero && configProxy.u64UpdateSignal > 0UL)
            {
              RuntimeUtils.ConfigProxy.Commit(configProxy.szConfigFilePathName, configProxy.ptrConfigProxy);
              configProxy.u64UpdateSignal = 0UL;
              now = DateTime.Now;
            }
            this.mxUpdatingMutex.ReleaseMutex();
          }
          Thread.Sleep(10);
        }
        configProxy.bThreadFinished = true;
      }

      [StructLayout(LayoutKind.Sequential, Pack = 1)]
      public struct _ParamOfBaseSystem_1_0_1
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
      public struct _ParamOfBaseSystem
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
      public struct _ParamOfMusicMode
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
      public struct _ParamOfMovieMode
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
      public struct _ParamOfFreestyle
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
