using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using ViPER4WindowsBin.Properties;
using ViPER4WindowsBin.UIControls;
using ViPER4WindowsBin.Utils;

namespace ViPER4WindowsBin
{
  public class frmMain : Form
  {
    private static string m_szLanguagePath = "";
    private static string m_szLanguageFile = "";
    private static string m_szLanguageName = "";
    private readonly string m_szLocalPresetFileName = "LocalPreset.bin";
    private readonly string m_szImpulseResponsePath = "ImpulseResponse";
    private readonly string m_szUserPresetPath = "Presets";
    private bool m_bArgvStartupToMinimized;
    private string m_szLocalPreset = "";
    private string m_szIRSPath = "";
    private string m_szPresetsPath = "";
    private bool m_bCloseToTray;
    private RuntimeUtils.ConfigProxy._ParamOfBaseSystem m_paramBaseSystem = new RuntimeUtils.ConfigProxy._ParamOfBaseSystem();
    private RuntimeUtils.ConfigProxy._ParamOfMusicMode m_paramMusicMode = new RuntimeUtils.ConfigProxy._ParamOfMusicMode();
    private RuntimeUtils.ConfigProxy._ParamOfMovieMode m_paramMovieMode = new RuntimeUtils.ConfigProxy._ParamOfMovieMode();
    private RuntimeUtils.ConfigProxy._ParamOfFreestyle m_paramFreestyle = new RuntimeUtils.ConfigProxy._ParamOfFreestyle();
    private RuntimeUtils.ConfigProxy m_cpConfigProxy;
    private List<TrayMenuPreset> m_lstTrayMenuPreset = new List<TrayMenuPreset>();
    private IContainer components;
    private PictureBox pictureBox_Logo;
    private Label label_MasterPower;
    private OnOffSwitch onOffSwitch_Master;
    private ButtonBox buttonBox_Mode;
    private MenuStrip menuStrip_Main;
    private ToolStripMenuItem toolStripMenuItem_Language;
    private ToolStripMenuItem toolStripMenuItem_Setting;
    private ToolStripMenuItem toolStripMenuItem_Help;
    private ToolStripMenuItem toolStripMenuItem_CheckUpdate;
    private ToolStripMenuItem toolStripMenuItem_AboutV4W;
    private GroupBox groupBox_Main;
    private Label label_Copyright;
    private ToolStripMenuItem toolStripMenuItem_LatencySetting;
    private ToolStripMenuItem toolStripMenuItem_ResetEffect;
    private Panel panel_MusicMode;
    private ToolStripMenuItem toolStripMenuItem_ChannelPan;
    private Label Music_label_PreVolume;
    private HSlider Music_hSlider_PreVolume;
    private HSlider Music_hSlider_PostVolume;
    private Label Music_label_PostVolume;
    private OnOffSwitch Music_onOffSwitch_Convolver;
    private HSlider Music_hSlider_ConvIRGain;
    private Label Music_label_ConvolverIRGain;
    private OpenFileBox Music_openFileBox_ConvIRS;
    private GroupBox Music_groupBox_Convolver;
    private IRShape Music_irShape_ConvIR;
    private GroupBox Music_groupBox_Surround;
    private OnOffSwitch Music_onOffSwitch_Surround;
    private ButtonBox Music_buttonBox_SurroundRoomSize;
    private Label Music_label_Tube;
    private OnOffSwitch Music_onOffSwitch_Tube;
    private GroupBox Music_groupBox_Bass;
    private OnOffSwitch Music_onOffSwitch_Bass;
    private HSlider Music_hSlider_BassSpkSize;
    private Label Music_label_Bass_SpkSize;
    private HSlider Music_hSlider_BassGain;
    private Label Music_label_Bass_Gain;
    private GroupBox Music_groupBox_Clarity;
    private HSlider Music_hSlider_Clarity;
    private Label Music_label_Clarity;
    private OnOffSwitch Music_onOffSwitch_Clarity;
    private ButtonBox Music_buttonBox_ClarityMode;
    private GroupBox Music_groupBox_Cure;
    private ButtonBox Music_buttonBox_CureLevel;
    private OnOffSwitch Music_onOffSwitch_Cure;
    private GroupBox Music_groupBox_Reverb;
    private OnOffSwitch Music_onOffSwitch_Reverb;
    private HSlider Music_hSlider_ReverbDensity;
    private Label Music_label_Reverb_Density;
    private HSlider Music_hSlider_ReverbDamping;
    private Label Music_label_Reverb_Damping;
    private HSlider Music_hSlider_ReverbSize;
    private Label Music_label_Reverb_Size;
    private HSlider Music_hSlider_ReverbMix;
    private Label Music_label_Reverb_Mix;
    private HSlider Music_hSlider_ReverbEarlyMix;
    private Label Music_label_Reverb_EarlyMix;
    private HSlider Music_hSlider_ReverbPreDelay;
    private Label Music_label_Reverb_PreDelay;
    private HSlider Music_hSlider_ReverbDecay;
    private Label Music_label_Reverb_Decay;
    private HSlider Music_hSlider_ReverbBandWidth;
    private Label Music_label_Reverb_BandWidth;
    private SingleButton Music_singleButton_ReverbPreset;
    private SingleButton Music_singleButton_Equalizer;
    private SingleButton Music_singleButton_Compressor;
    private SingleButton singleButton_LoadPreset;
    private SingleButton singleButton_SavePreset;
    private Panel panel_MovieMode;
    private SingleButton Movie_singleButton_Compressor;
    private SingleButton Movie_singleButton_Equalizer;
    private GroupBox Movie_groupBox_Reverb;
    private SingleButton Movie_singleButton_ReverbPreset;
    private HSlider Movie_hSlider_ReverbMix;
    private Label Movie_label_Reverb_Mix;
    private HSlider Movie_hSlider_ReverbEarlyMix;
    private Label Movie_label_Reverb_EarlyMix;
    private HSlider Movie_hSlider_ReverbPreDelay;
    private Label Movie_label_Reverb_PreDelay;
    private HSlider Movie_hSlider_ReverbDecay;
    private Label Movie_label_Reverb_Decay;
    private HSlider Movie_hSlider_ReverbBandWidth;
    private Label Movie_label_Reverb_BandWidth;
    private HSlider Movie_hSlider_ReverbDensity;
    private Label Movie_label_Reverb_Density;
    private HSlider Movie_hSlider_ReverbDamping;
    private Label Movie_label_Reverb_Damping;
    private HSlider Movie_hSlider_ReverbSize;
    private Label Movie_label_Reverb_Size;
    private OnOffSwitch Movie_onOffSwitch_Reverb;
    private GroupBox Movie_groupBox_Clarity;
    private HSlider Movie_hSlider_Clarity;
    private Label Movie_label_Clarity;
    private OnOffSwitch Movie_onOffSwitch_Clarity;
    private GroupBox Movie_groupBox_Bass;
    private HSlider Movie_hSlider_BassGain;
    private Label Movie_label_Bass_Gain;
    private HSlider Movie_hSlider_BassSpkSize;
    private Label Movie_label_Bass_SpkSize;
    private OnOffSwitch Movie_onOffSwitch_Bass;
    private GroupBox Movie_groupBox_Surround;
    private OnOffSwitch Movie_onOffSwitch_Surround;
    private GroupBox Movie_groupBox_Convolver;
    private IRShape Movie_irShape_ConvIR;
    private OnOffSwitch Movie_onOffSwitch_Convolver;
    private HSlider Movie_hSlider_ConvIRGain;
    private OpenFileBox Movie_openFileBox_ConvIRS;
    private Label Movie_label_ConvolverIRGain;
    private HSlider Movie_hSlider_PostVolume;
    private Label Movie_label_PostVolume;
    private HSlider Movie_hSlider_PreVolume;
    private Label Movie_label_PreVolume;
    private HSlider Movie_hSlider_SurroundImage;
    private Label Movie_label_Surround_Image;
    private HSlider Movie_hSlider_Surround3D;
    private Label Movie_label_Surround_3D;
    private GroupBox Movie_groupBox_SmartVolume;
    private HSlider Movie_hSlider_SmartVolumeMaxLevel;
    private Label Movie_label_SmartVolume_MaxLevel;
    private HSlider Movie_hSlider_SmartVolumeRatio;
    private Label Movie_label_SmartVolume_ControlStrength;
    private OnOffSwitch Movie_onOffSwitch_SmartVolume;
    private HSlider Movie_hSlider_SmartVolumeLevel;
    private Label Movie_label_SmartVolume_Level;
    private Panel panel_Freestyle;
    private SingleButton Freestyle_singleButton_Compressor;
    private SingleButton Freestyle_singleButton_Equalizer;
    private GroupBox Freestyle_groupBox_Reverb;
    private SingleButton Freestyle_singleButton_ReverbPreset;
    private HSlider Freestyle_hSlider_ReverbMix;
    private Label Freestyle_label_Reverb_Mix;
    private HSlider Freestyle_hSlider_ReverbEarlyMix;
    private Label Freestyle_label_Reverb_EarlyMix;
    private HSlider Freestyle_hSlider_ReverbPreDelay;
    private Label Freestyle_label_Reverb_PreDelay;
    private HSlider Freestyle_hSlider_ReverbDecay;
    private Label Freestyle_label_Reverb_Decay;
    private HSlider Freestyle_hSlider_ReverbBandWidth;
    private Label Freestyle_label_Reverb_BandWidth;
    private HSlider Freestyle_hSlider_ReverbDensity;
    private Label Freestyle_label_Reverb_Density;
    private HSlider Freestyle_hSlider_ReverbDamping;
    private Label Freestyle_label_Reverb_Damping;
    private HSlider Freestyle_hSlider_ReverbSize;
    private Label Freestyle_label_Reverb_Size;
    private OnOffSwitch Freestyle_onOffSwitch_Reverb;
    private GroupBox Freestyle_groupBox_Cure;
    private ButtonBox Freestyle_buttonBox_CureLevel;
    private OnOffSwitch Freestyle_onOffSwitch_Cure;
    private Label Freestyle_label_Tube;
    private OnOffSwitch Freestyle_onOffSwitch_Tube;
    private GroupBox Freestyle_groupBox_Clarity;
    private ButtonBox Freestyle_buttonBox_ClarityMode;
    private HSlider Freestyle_hSlider_Clarity;
    private Label Freestyle_label_Clarity;
    private OnOffSwitch Freestyle_onOffSwitch_Clarity;
    private GroupBox Freestyle_groupBox_Bass;
    private HSlider Freestyle_hSlider_BassGain;
    private Label Freestyle_label_Bass_Gain;
    private HSlider Freestyle_hSlider_BassSpkSize;
    private Label Freestyle_label_Bass_SpkSize;
    private OnOffSwitch Freestyle_onOffSwitch_Bass;
    private GroupBox Freestyle_groupBox_VHESurround;
    private ButtonBox Freestyle_buttonBox_SurroundVHERoomSize;
    private OnOffSwitch Freestyle_onOffSwitch_SurroundVHE;
    private GroupBox Freestyle_groupBox_Convolver;
    private IRShape Freestyle_irShape_ConvIR;
    private OnOffSwitch Freestyle_onOffSwitch_Convolver;
    private HSlider Freestyle_hSlider_ConvIRGain;
    private OpenFileBox Freestyle_openFileBox_ConvIRS;
    private Label Freestyle_label_ConvolverIRGain;
    private HSlider Freestyle_hSlider_PostVolume;
    private Label Freestyle_label_PostVolume;
    private HSlider Freestyle_hSlider_PreVolume;
    private Label Freestyle_label_PreVolume;
    private GroupBox Freestyle_groupBox_3DSurround;
    private HSlider Freestyle_hSlider_SurroundImage;
    private Label Freestyle_label_Surround_Image;
    private HSlider Freestyle_hSlider_Surround3D;
    private Label Freestyle_label_Surround_3D;
    private OnOffSwitch Freestyle_onOffSwitch_Surround3D;
    private ButtonBox Freestyle_buttonBox_BassMode;
    private GroupBox Freestyle_groupBox_SmartVolume;
    private HSlider Freestyle_hSlider_SmartVolumeLevel;
    private Label Freestyle_label_SmartVolume_Level;
    private HSlider Freestyle_hSlider_SmartVolumeMaxLevel;
    private Label Freestyle_label_SmartVolume_MaxLevel;
    private HSlider Freestyle_hSlider_SmartVolumeRatio;
    private Label Freestyle_label_SmartVolume_ControlStrength;
    private OnOffSwitch Freestyle_onOffSwitch_SmartVolume;
    private ToolStripMenuItem toolStripMenuItem_Virtualization;
    private NotifyIcon notifyIcon_Main;
    private ToolStripMenuItem toolStripMenuItem_Settings;
    private ContextMenuStrip contextMenuStrip_TrayMenu;

    public static void SetLanguage(string szLanguagePath, string szLanguageFile)
    {
      frmMain.m_szLanguagePath = szLanguagePath;
      frmMain.m_szLanguageFile = szLanguageFile;
      if (frmMain.m_szLanguagePath == "" || frmMain.m_szLanguageFile == "")
        frmMain.m_szLanguageName = "";
      else
        frmMain.m_szLanguageName = new ConfigFile(szLanguageFile).ReadConfig("$LANGUAGE_NAME");
    }

    public frmMain(string[] szArgs)
    {
      this.InitializeComponent();
      this.m_bArgvStartupToMinimized = false;
      if (szArgs != null)
      {
        int length = szArgs.Length;
      }
      this.m_szLocalPreset = AppDomain.CurrentDomain.BaseDirectory;
      if (!this.m_szLocalPreset.EndsWith("\\"))
        this.m_szLocalPreset += "\\";
      this.m_szLocalPreset += this.m_szLocalPresetFileName;
      this.m_szIRSPath = AppDomain.CurrentDomain.BaseDirectory;
      if (!this.m_szIRSPath.EndsWith("\\"))
        this.m_szIRSPath += "\\";
      frmMain frmMain1 = this;
      frmMain1.m_szIRSPath = frmMain1.m_szIRSPath + this.m_szImpulseResponsePath + "\\";
      if (!Directory.Exists(this.m_szIRSPath))
      {
        try
        {
          Directory.CreateDirectory(this.m_szIRSPath);
        }
        catch
        {
        }
      }
      this.m_szPresetsPath = AppDomain.CurrentDomain.BaseDirectory;
      if (!this.m_szPresetsPath.EndsWith("\\"))
        this.m_szPresetsPath += "\\";
      frmMain frmMain2 = this;
      frmMain2.m_szPresetsPath = frmMain2.m_szPresetsPath + this.m_szUserPresetPath + "\\";
      if (!Directory.Exists(this.m_szPresetsPath))
      {
        try
        {
          Directory.CreateDirectory(this.m_szPresetsPath);
        }
        catch
        {
        }
      }
      string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
      if (!baseDirectory.EndsWith("\\"))
        baseDirectory += "\\";
      ConfigFile configFile = new ConfigFile(baseDirectory + "Config.ini");
      string str1 = configFile.ReadConfig("$CLOSE_APP_TO_TRAY");
      this.m_bCloseToTray = !string.IsNullOrEmpty(str1) && str1.ToUpper() == "TRUE";
      this.m_lstTrayMenuPreset.Clear();
      string s = configFile.ReadConfig("$TRAY_MENU_PRESET_COUNT");
      if (!string.IsNullOrEmpty(s))
      {
        int result = 0;
        try
        {
          if (int.TryParse(s, out result))
          {
            for (int index = 0; index < result; ++index)
            {
              string szName = configFile.ReadConfig("$TRAY_MENU_PRESET_NAME_" + index.ToString());
              string str2 = configFile.ReadConfig("$TRAY_MENU_PRESET_MODE_" + index.ToString());
              string szFile = configFile.ReadConfig("$TRAY_MENU_PRESET_FILE_" + index.ToString());
              if (string.IsNullOrEmpty(szName))
                szName = GlobalMessages.UNNAMED;
              if (!string.IsNullOrEmpty(str2))
              {
                int nMode = -1;
                if (str2 == "EFFECT_MODE_MUSIC")
                  nMode = 0;
                if (str2 == "EFFECT_MODE_MOVIE")
                  nMode = 1;
                if (str2 == "EFFECT_MODE_FREESTYLE")
                  nMode = 2;
                if (nMode != -1)
                  this.m_lstTrayMenuPreset.Add(new TrayMenuPreset(szName, nMode, szFile));
              }
            }
          }
        }
        catch
        {
          this.m_lstTrayMenuPreset.Clear();
        }
      }
      string config = RegHelper.GetConfig();
      if (!RuntimeUtils.ConfigProxy.CheckConfigVersion(config))
        RuntimeUtils.ConfigProxy.UpdateConfigToCurrent(config);
      this.m_cpConfigProxy = new RuntimeUtils.ConfigProxy(config);
      Parameters.LoadDefaultParameter(ref this.m_paramBaseSystem);
      Parameters.LoadDefaultParameter(ref this.m_paramMusicMode);
      Parameters.LoadDefaultParameter(ref this.m_paramMovieMode);
      Parameters.LoadDefaultParameter(ref this.m_paramFreestyle);
      bool bPBaseSystem = false;
      bool bPMusicMode = false;
      bool bPMovieMode = false;
      bool bPFreestyle = false;
      if (!Parameters.ReadPreset(this.m_szLocalPreset, ref this.m_paramBaseSystem, ref this.m_paramMusicMode, ref this.m_paramMovieMode, ref this.m_paramFreestyle, out bPBaseSystem, out bPMusicMode, out bPMovieMode, out bPFreestyle))
      {
        Parameters.LoadDefaultParameter(ref this.m_paramBaseSystem);
        Parameters.LoadDefaultParameter(ref this.m_paramMusicMode);
        Parameters.LoadDefaultParameter(ref this.m_paramMovieMode);
        Parameters.LoadDefaultParameter(ref this.m_paramFreestyle);
      }
      else
      {
        if (!bPBaseSystem)
          Parameters.LoadDefaultParameter(ref this.m_paramBaseSystem);
        if (!bPMusicMode)
          Parameters.LoadDefaultParameter(ref this.m_paramMusicMode);
        if (!bPMovieMode)
          Parameters.LoadDefaultParameter(ref this.m_paramMovieMode);
        if (!bPFreestyle)
          Parameters.LoadDefaultParameter(ref this.m_paramFreestyle);
      }
      this.m_cpConfigProxy.UpdateParameter(this.m_paramBaseSystem);
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
      this.toolStripMenuItem_Language.Text = GlobalMessages.MENU_LANGUAGE;
      this.toolStripMenuItem_Setting.Text = GlobalMessages.MENU_SETTING;
      this.toolStripMenuItem_LatencySetting.Text = GlobalMessages.LATENCY_SETTING;
      this.toolStripMenuItem_ChannelPan.Text = GlobalMessages.CHANNEL_PAN;
      this.toolStripMenuItem_Virtualization.Text = GlobalMessages.VIRTUALIZATION;
      this.toolStripMenuItem_ResetEffect.Text = GlobalMessages.RESET_EFFECT;
      this.toolStripMenuItem_Settings.Text = GlobalMessages.SETTINGS;
      this.toolStripMenuItem_Help.Text = GlobalMessages.MENU_HELP;
      this.toolStripMenuItem_CheckUpdate.Text = GlobalMessages.CHECK_UPDATE;
      this.toolStripMenuItem_AboutV4W.Text = GlobalMessages.ABOUT;
      this.label_MasterPower.Text = GlobalMessages.MASTER_POWER;
      this.singleButton_LoadPreset.ButtonText = GlobalMessages.LOAD_PRESET;
      this.singleButton_SavePreset.ButtonText = GlobalMessages.SAVE_PRESET;
      this.label_Copyright.Text = GlobalMessages.COPYRIGHT;
      this.buttonBox_Mode.AddItem(new ButtonBox.Item(GlobalMessages.MUSIC_MODE, (object) 0.ToString()));
      this.buttonBox_Mode.AddItem(new ButtonBox.Item(GlobalMessages.MOVIE_MODE, (object) 1.ToString()));
      this.buttonBox_Mode.AddItem(new ButtonBox.Item(GlobalMessages.FREESTYLE_MODE, (object) 2.ToString()));
      this.Music_label_PreVolume.Text = GlobalMessages.PRE_VOLUME;
      this.Music_label_PostVolume.Text = GlobalMessages.POST_VOLUME;
      this.Music_groupBox_Convolver.Text = GlobalMessages.CONVOLVER;
      this.Music_label_ConvolverIRGain.Text = GlobalMessages.CONV_IR_GAIN;
      this.Music_openFileBox_ConvIRS.DialogTitle = GlobalMessages.OPEN_CONV_IRS;
      this.Music_openFileBox_ConvIRS.FileFilter = "*.irs; *.wav|*.irs;*.wav|*.*|*.*";
      if (Directory.Exists(this.m_szIRSPath))
        this.Music_openFileBox_ConvIRS.OpenDirectory = this.m_szIRSPath;
      this.Music_groupBox_Surround.Text = GlobalMessages.SURROUND;
      this.Music_buttonBox_SurroundRoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_SMALLEST_ROOM, (object) "0"));
      this.Music_buttonBox_SurroundRoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_SMALL_ROOM, (object) "1"));
      this.Music_buttonBox_SurroundRoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_MID_ROOM, (object) "2"));
      this.Music_buttonBox_SurroundRoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_LARGE_ROOM, (object) "3"));
      this.Music_buttonBox_SurroundRoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_LARGEST_ROOM, (object) "4"));
      this.Music_groupBox_Bass.Text = GlobalMessages.BASS;
      this.Music_label_Bass_SpkSize.Text = GlobalMessages.BASS_SPKSIZE;
      this.Music_label_Bass_Gain.Text = GlobalMessages.BASS_GAIN;
      this.Music_groupBox_Clarity.Text = GlobalMessages.CLARITY;
      this.Music_buttonBox_ClarityMode.AddItem(new ButtonBox.Item(GlobalMessages.NATURAL_CLARITY, (object) "0"));
      this.Music_buttonBox_ClarityMode.AddItem(new ButtonBox.Item(GlobalMessages.OZONE_CLARITY, (object) "1"));
      this.Music_buttonBox_ClarityMode.AddItem(new ButtonBox.Item(GlobalMessages.XHIFI_CLARITY, (object) "2"));
      this.Music_label_Clarity.Text = GlobalMessages.CLARITY;
      this.Music_groupBox_Cure.Text = GlobalMessages.CURE;
      this.Music_buttonBox_CureLevel.AddItem(new ButtonBox.Item(GlobalMessages.SLIGHT_CURE, (object) 6226570U.ToString()));
      this.Music_buttonBox_CureLevel.AddItem(new ButtonBox.Item(GlobalMessages.MODERATE_CURE, (object) 3932860U.ToString()));
      this.Music_buttonBox_CureLevel.AddItem(new ButtonBox.Item(GlobalMessages.EXTREME_CURE, (object) 2949820U.ToString()));
      this.Music_label_Tube.Text = GlobalMessages.TUBE;
      this.Music_groupBox_Reverb.Text = GlobalMessages.REVERB;
      this.Music_singleButton_ReverbPreset.ButtonText = GlobalMessages.PRESET;
      this.Music_label_Reverb_Size.Text = GlobalMessages.REVERB_SIZE;
      this.Music_label_Reverb_Damping.Text = GlobalMessages.REVERB_DAMPING;
      this.Music_label_Reverb_Density.Text = GlobalMessages.REVERB_DENSITY;
      this.Music_label_Reverb_BandWidth.Text = GlobalMessages.REVERB_BANDWIDTH;
      this.Music_label_Reverb_Decay.Text = GlobalMessages.REVERB_DECAY;
      this.Music_label_Reverb_PreDelay.Text = GlobalMessages.REVERB_PREDELAY;
      this.Music_label_Reverb_EarlyMix.Text = GlobalMessages.REVERB_EARLYMIX;
      this.Music_label_Reverb_Mix.Text = GlobalMessages.REVERB_MIX;
      this.Music_singleButton_Equalizer.ButtonText = GlobalMessages.EQUALIZER_ADJUST;
      this.Music_singleButton_Compressor.ButtonText = GlobalMessages.COMPRESSOR_ADJUST;
      this.Movie_label_PreVolume.Text = GlobalMessages.PRE_VOLUME;
      this.Movie_label_PostVolume.Text = GlobalMessages.POST_VOLUME;
      this.Movie_groupBox_Convolver.Text = GlobalMessages.CONVOLVER;
      this.Movie_label_ConvolverIRGain.Text = GlobalMessages.CONV_IR_GAIN;
      this.Movie_openFileBox_ConvIRS.DialogTitle = GlobalMessages.OPEN_CONV_IRS;
      if (Directory.Exists(this.m_szIRSPath))
        this.Movie_openFileBox_ConvIRS.FileFilter = "*.irs; *.wav|*.irs;*.wav|*.*|*.*";
      this.Movie_openFileBox_ConvIRS.OpenDirectory = this.m_szIRSPath;
      this.Movie_groupBox_Surround.Text = GlobalMessages.SURROUND;
      this.Movie_label_Surround_3D.Text = GlobalMessages.SURROUND_3D;
      this.Movie_label_Surround_Image.Text = GlobalMessages.SURROUND_IMAGE;
      this.Movie_groupBox_Bass.Text = GlobalMessages.BASS;
      this.Movie_label_Bass_SpkSize.Text = GlobalMessages.BASS_SPKSIZE;
      this.Movie_label_Bass_Gain.Text = GlobalMessages.BASS_GAIN;
      this.Movie_groupBox_Clarity.Text = GlobalMessages.CLARITY;
      this.Movie_label_Clarity.Text = GlobalMessages.CLARITY;
      this.Movie_groupBox_SmartVolume.Text = GlobalMessages.SMART_VOLUME;
      this.Movie_label_SmartVolume_ControlStrength.Text = GlobalMessages.SMART_VOLUME_CONTROL_STRENGTH;
      this.Movie_label_SmartVolume_MaxLevel.Text = GlobalMessages.SMART_VOLUME_MAXLEVEL;
      this.Movie_label_SmartVolume_Level.Text = GlobalMessages.SMART_VOLUME_LEVEL;
      this.Movie_groupBox_Reverb.Text = GlobalMessages.REVERB;
      this.Movie_singleButton_ReverbPreset.ButtonText = GlobalMessages.PRESET;
      this.Movie_label_Reverb_Size.Text = GlobalMessages.REVERB_SIZE;
      this.Movie_label_Reverb_Damping.Text = GlobalMessages.REVERB_DAMPING;
      this.Movie_label_Reverb_Density.Text = GlobalMessages.REVERB_DENSITY;
      this.Movie_label_Reverb_BandWidth.Text = GlobalMessages.REVERB_BANDWIDTH;
      this.Movie_label_Reverb_Decay.Text = GlobalMessages.REVERB_DECAY;
      this.Movie_label_Reverb_PreDelay.Text = GlobalMessages.REVERB_PREDELAY;
      this.Movie_label_Reverb_EarlyMix.Text = GlobalMessages.REVERB_EARLYMIX;
      this.Movie_label_Reverb_Mix.Text = GlobalMessages.REVERB_MIX;
      this.Movie_singleButton_Equalizer.ButtonText = GlobalMessages.EQUALIZER_ADJUST;
      this.Movie_singleButton_Compressor.ButtonText = GlobalMessages.COMPRESSOR_ADJUST;
      this.Freestyle_label_PreVolume.Text = GlobalMessages.PRE_VOLUME;
      this.Freestyle_label_PostVolume.Text = GlobalMessages.POST_VOLUME;
      this.Freestyle_groupBox_Convolver.Text = GlobalMessages.CONVOLVER;
      this.Freestyle_label_ConvolverIRGain.Text = GlobalMessages.CONV_IR_GAIN;
      this.Freestyle_openFileBox_ConvIRS.DialogTitle = GlobalMessages.OPEN_CONV_IRS;
      this.Freestyle_openFileBox_ConvIRS.FileFilter = "*.irs; *.wav|*.irs;*.wav|*.*|*.*";
      if (Directory.Exists(this.m_szIRSPath))
        this.Freestyle_openFileBox_ConvIRS.OpenDirectory = this.m_szIRSPath;
      this.Freestyle_groupBox_3DSurround.Text = GlobalMessages.THREE_D_SURROUND;
      this.Freestyle_label_Surround_3D.Text = GlobalMessages.SURROUND_3D;
      this.Freestyle_label_Surround_Image.Text = GlobalMessages.SURROUND_IMAGE;
      this.Freestyle_groupBox_VHESurround.Text = GlobalMessages.VHE_SURROUND;
      this.Freestyle_buttonBox_SurroundVHERoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_SMALLEST_ROOM, (object) "0"));
      this.Freestyle_buttonBox_SurroundVHERoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_SMALL_ROOM, (object) "1"));
      this.Freestyle_buttonBox_SurroundVHERoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_MID_ROOM, (object) "2"));
      this.Freestyle_buttonBox_SurroundVHERoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_LARGE_ROOM, (object) "3"));
      this.Freestyle_buttonBox_SurroundVHERoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_LARGEST_ROOM, (object) "4"));
      this.Freestyle_groupBox_Bass.Text = GlobalMessages.BASS;
      this.Freestyle_label_Bass_SpkSize.Text = GlobalMessages.BASS_SPKSIZE;
      this.Freestyle_label_Bass_Gain.Text = GlobalMessages.BASS_GAIN;
      this.Freestyle_buttonBox_BassMode.AddItem(new ButtonBox.Item(GlobalMessages.NATURAL_BASS, (object) "0"));
      this.Freestyle_buttonBox_BassMode.AddItem(new ButtonBox.Item(GlobalMessages.PURE_BASS, (object) "1"));
      this.Freestyle_groupBox_Clarity.Text = GlobalMessages.CLARITY;
      this.Freestyle_buttonBox_ClarityMode.AddItem(new ButtonBox.Item(GlobalMessages.NATURAL_CLARITY, (object) "0"));
      this.Freestyle_buttonBox_ClarityMode.AddItem(new ButtonBox.Item(GlobalMessages.OZONE_CLARITY, (object) "1"));
      this.Freestyle_buttonBox_ClarityMode.AddItem(new ButtonBox.Item(GlobalMessages.XHIFI_CLARITY, (object) "2"));
      this.Freestyle_label_Clarity.Text = GlobalMessages.CLARITY;
      this.Freestyle_groupBox_Cure.Text = GlobalMessages.CURE;
      this.Freestyle_buttonBox_CureLevel.AddItem(new ButtonBox.Item(GlobalMessages.SLIGHT_CURE, (object) 6226570U.ToString()));
      this.Freestyle_buttonBox_CureLevel.AddItem(new ButtonBox.Item(GlobalMessages.MODERATE_CURE, (object) 3932860U.ToString()));
      this.Freestyle_buttonBox_CureLevel.AddItem(new ButtonBox.Item(GlobalMessages.EXTREME_CURE, (object) 2949820U.ToString()));
      this.Freestyle_label_Tube.Text = GlobalMessages.TUBE;
      this.Freestyle_groupBox_Reverb.Text = GlobalMessages.REVERB;
      this.Freestyle_singleButton_ReverbPreset.ButtonText = GlobalMessages.PRESET;
      this.Freestyle_label_Reverb_Size.Text = GlobalMessages.REVERB_SIZE;
      this.Freestyle_label_Reverb_Damping.Text = GlobalMessages.REVERB_DAMPING;
      this.Freestyle_label_Reverb_Density.Text = GlobalMessages.REVERB_DENSITY;
      this.Freestyle_label_Reverb_BandWidth.Text = GlobalMessages.REVERB_BANDWIDTH;
      this.Freestyle_label_Reverb_Decay.Text = GlobalMessages.REVERB_DECAY;
      this.Freestyle_label_Reverb_PreDelay.Text = GlobalMessages.REVERB_PREDELAY;
      this.Freestyle_label_Reverb_EarlyMix.Text = GlobalMessages.REVERB_EARLYMIX;
      this.Freestyle_label_Reverb_Mix.Text = GlobalMessages.REVERB_MIX;
      this.Freestyle_groupBox_SmartVolume.Text = GlobalMessages.SMART_VOLUME;
      this.Freestyle_label_SmartVolume_ControlStrength.Text = GlobalMessages.SMART_VOLUME_CONTROL_STRENGTH;
      this.Freestyle_label_SmartVolume_MaxLevel.Text = GlobalMessages.SMART_VOLUME_MAXLEVEL;
      this.Freestyle_label_SmartVolume_Level.Text = GlobalMessages.SMART_VOLUME_LEVEL;
      this.Freestyle_singleButton_Equalizer.ButtonText = GlobalMessages.EQUALIZER_ADJUST;
      this.Freestyle_singleButton_Compressor.ButtonText = GlobalMessages.COMPRESSOR_ADJUST;
      this.toolStripMenuItem_Language.DropDownItems.Clear();
      foreach (string listFile in new FolderExplorer().ListFiles(frmMain.m_szLanguagePath))
      {
        string str3 = new ConfigFile(listFile).ReadConfig("$LANGUAGE_NAME");
        ToolStripItem toolStripItem = (ToolStripItem) new ToolStripMenuItem();
        toolStripItem.Text = str3;
        toolStripItem.Tag = (object) listFile;
        toolStripItem.Click += new EventHandler(this.LanguageChanged);
        this.toolStripMenuItem_Language.DropDownItems.Add(toolStripItem);
      }
      this.groupBox_Main.Controls.Clear();
      this.groupBox_Main.Controls.Add((Control) this.panel_MusicMode);
      this.groupBox_Main.Controls.Add((Control) this.panel_MovieMode);
      this.groupBox_Main.Controls.Add((Control) this.panel_Freestyle);
      this.panel_MusicMode.Dock = DockStyle.Fill;
      this.panel_MovieMode.Dock = DockStyle.Fill;
      this.panel_Freestyle.Dock = DockStyle.Fill;
      this.UpdateAllControlsFromParameters();
      if (szArgs == null || szArgs.Length <= 0)
        return;
      for (int index = 0; index < szArgs.Length; ++index)
      {
        if (szArgs[index].ToLower().Trim() == "--hide")
          this.m_bArgvStartupToMinimized = this.m_bCloseToTray;
        else if (szArgs[index].ToLower().Trim() == "-m")
          this.m_bArgvStartupToMinimized = this.m_bCloseToTray;
      }
    }

    private void SaveAppSettings()
    {
      string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
      if (!baseDirectory.EndsWith("\\"))
        baseDirectory += "\\";
      ConfigFile configFile = new ConfigFile(baseDirectory + "Config.ini");
      if (this.m_bCloseToTray)
        configFile.SetConfig("$CLOSE_APP_TO_TRAY", "TRUE");
      else
        configFile.SetConfig("$CLOSE_APP_TO_TRAY", "FALSE");
      int num1 = 0;
      for (int index = 0; index < this.m_lstTrayMenuPreset.Count; ++index)
      {
        if (this.m_lstTrayMenuPreset[index].Valid())
          ++num1;
      }
      configFile.SetConfig("$TRAY_MENU_PRESET_COUNT", num1.ToString());
      int index1 = 0;
      int num2 = 0;
      for (; index1 < this.m_lstTrayMenuPreset.Count; ++index1)
      {
        if (this.m_lstTrayMenuPreset[index1].Valid())
        {
          if (string.IsNullOrEmpty(this.m_lstTrayMenuPreset[index1].PresetName))
            this.m_lstTrayMenuPreset[index1].PresetName = GlobalMessages.UNNAMED;
          string szValue = "";
          if (this.m_lstTrayMenuPreset[index1].PresetMode == 0)
            szValue = "EFFECT_MODE_MUSIC";
          if (this.m_lstTrayMenuPreset[index1].PresetMode == 1)
            szValue = "EFFECT_MODE_MOVIE";
          if (this.m_lstTrayMenuPreset[index1].PresetMode == 2)
            szValue = "EFFECT_MODE_FREESTYLE";
          configFile.SetConfig("$TRAY_MENU_PRESET_NAME_" + num2.ToString(), this.m_lstTrayMenuPreset[index1].PresetName);
          configFile.SetConfig("$TRAY_MENU_PRESET_MODE_" + num2.ToString(), szValue);
          configFile.SetConfig("$TRAY_MENU_PRESET_FILE_" + num2.ToString(), this.m_lstTrayMenuPreset[index1].PresetFile);
          ++num2;
        }
      }
    }

    private void SetupTrayMenu()
    {
      this.contextMenuStrip_TrayMenu.Items.Clear();
      bool flag = false;
      for (int index = 0; index < this.m_lstTrayMenuPreset.Count; ++index)
      {
        if (this.m_lstTrayMenuPreset[index].Valid())
        {
          ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
          toolStripMenuItem.Text = this.m_lstTrayMenuPreset[index].PresetName;
          toolStripMenuItem.Tag = (object) this.m_lstTrayMenuPreset[index];
          toolStripMenuItem.Click += new EventHandler(this.TrayMenu_SelectPreset);
          this.contextMenuStrip_TrayMenu.Items.Add((ToolStripItem) toolStripMenuItem);
          flag = true;
        }
      }
      if (flag)
        this.contextMenuStrip_TrayMenu.Items.Add((ToolStripItem) new ToolStripSeparator());
      ToolStripMenuItem toolStripMenuItem1 = new ToolStripMenuItem();
      toolStripMenuItem1.Text = GlobalMessages.MUSIC_MODE;
      toolStripMenuItem1.Tag = (object) "MUSIC_MODE";
      if (this.m_paramBaseSystem.m_nEffectMode == 0U)
        toolStripMenuItem1.Checked = true;
      toolStripMenuItem1.Click += new EventHandler(this.TrayMenu_SwitchEffectMode);
      this.contextMenuStrip_TrayMenu.Items.Add((ToolStripItem) toolStripMenuItem1);
      ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
      toolStripMenuItem2.Text = GlobalMessages.MOVIE_MODE;
      toolStripMenuItem2.Tag = (object) "MOVIE_MODE";
      if (this.m_paramBaseSystem.m_nEffectMode == 1U)
        toolStripMenuItem2.Checked = true;
      toolStripMenuItem2.Click += new EventHandler(this.TrayMenu_SwitchEffectMode);
      this.contextMenuStrip_TrayMenu.Items.Add((ToolStripItem) toolStripMenuItem2);
      ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem();
      toolStripMenuItem3.Text = GlobalMessages.FREESTYLE_MODE;
      toolStripMenuItem3.Tag = (object) "FREESTYLE_MODE";
      if (this.m_paramBaseSystem.m_nEffectMode == 2U)
        toolStripMenuItem3.Checked = true;
      toolStripMenuItem3.Click += new EventHandler(this.TrayMenu_SwitchEffectMode);
      this.contextMenuStrip_TrayMenu.Items.Add((ToolStripItem) toolStripMenuItem3);
      this.contextMenuStrip_TrayMenu.Items.Add((ToolStripItem) new ToolStripSeparator());
      ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem();
      if (this.m_paramBaseSystem.m_bEffectEnabled == 0)
        toolStripMenuItem4.Text = GlobalMessages.SWITCH_ON_EFFECT;
      else
        toolStripMenuItem4.Text = GlobalMessages.SWITCH_OFF_EFFECT;
      toolStripMenuItem4.Click += new EventHandler(this.TrayMenu_SwitchEffectOnOff);
      this.contextMenuStrip_TrayMenu.Items.Add((ToolStripItem) toolStripMenuItem4);
      this.contextMenuStrip_TrayMenu.Items.Add((ToolStripItem) new ToolStripSeparator());
      ToolStripMenuItem toolStripMenuItem5 = new ToolStripMenuItem();
      toolStripMenuItem5.Text = GlobalMessages.EXIT_APPLICTION;
      toolStripMenuItem5.Click += new EventHandler(this.TrayMenu_ExitApplication);
      this.contextMenuStrip_TrayMenu.Items.Add((ToolStripItem) toolStripMenuItem5);
    }

    private void TrayMenu_ExitApplication(object sender, EventArgs e)
    {
      Parameters.SaveLocalPreset(this.m_szLocalPreset, this.m_paramBaseSystem, this.m_paramMusicMode, this.m_paramMovieMode, this.m_paramFreestyle);
      this.SaveAppSettings();
      Application.Exit();
    }

    private void TrayMenu_SwitchEffectOnOff(object sender, EventArgs e)
    {
      if (sender == null || sender.GetType() != typeof (ToolStripMenuItem))
        return;
      ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
      this.m_paramBaseSystem.m_bEffectEnabled = this.m_paramBaseSystem.m_bEffectEnabled != 0 ? 0 : 1;
      if (this.m_paramBaseSystem.m_bEffectEnabled == 0)
        toolStripMenuItem.Text = GlobalMessages.SWITCH_ON_EFFECT;
      else
        toolStripMenuItem.Text = GlobalMessages.SWITCH_OFF_EFFECT;
      this.UpdateAllControlsFromParameters();
    }

    private void TrayMenu_SwitchEffectMode(object sender, EventArgs e)
    {
      if (sender == null || sender.GetType() != typeof (ToolStripMenuItem))
        return;
      ToolStripMenuItem toolStripMenuItem1 = sender as ToolStripMenuItem;
      if (toolStripMenuItem1.Tag == null || toolStripMenuItem1.Tag.GetType() != typeof (string))
        return;
      string tag1 = toolStripMenuItem1.Tag as string;
      if (string.IsNullOrEmpty(tag1))
        return;
      ToolStripMenuItem toolStripMenuItem2 = (ToolStripMenuItem) null;
      ToolStripMenuItem toolStripMenuItem3 = (ToolStripMenuItem) null;
      ToolStripMenuItem toolStripMenuItem4 = (ToolStripMenuItem) null;
      foreach (object obj in (ArrangedElementCollection) this.contextMenuStrip_TrayMenu.Items)
      {
        if (obj != null && obj.GetType() == typeof (ToolStripMenuItem))
        {
          ToolStripMenuItem toolStripMenuItem5 = obj as ToolStripMenuItem;
          if (toolStripMenuItem5.Tag != null && toolStripMenuItem5.Tag.GetType() == typeof (string))
          {
            string tag2 = toolStripMenuItem5.Tag as string;
            if (!string.IsNullOrEmpty(tag2))
            {
              switch (tag2)
              {
                case "MUSIC_MODE":
                  toolStripMenuItem2 = toolStripMenuItem5;
                  continue;
                case "MOVIE_MODE":
                  toolStripMenuItem3 = toolStripMenuItem5;
                  continue;
                case "FREESTYLE_MODE":
                  toolStripMenuItem4 = toolStripMenuItem5;
                  continue;
                default:
                  continue;
              }
            }
          }
        }
      }
      if (toolStripMenuItem2 == null || toolStripMenuItem3 == null || toolStripMenuItem4 == null)
        return;
      switch (tag1)
      {
        case "MUSIC_MODE":
          toolStripMenuItem2.Checked = true;
          toolStripMenuItem3.Checked = false;
          toolStripMenuItem4.Checked = false;
          this.m_paramBaseSystem.m_nEffectMode = 0U;
          this.UpdateAllControlsFromParameters();
          break;
        case "MOVIE_MODE":
          toolStripMenuItem2.Checked = false;
          toolStripMenuItem3.Checked = true;
          toolStripMenuItem4.Checked = false;
          this.m_paramBaseSystem.m_nEffectMode = 1U;
          this.UpdateAllControlsFromParameters();
          break;
        case "FREESTYLE_MODE":
          toolStripMenuItem2.Checked = false;
          toolStripMenuItem3.Checked = false;
          toolStripMenuItem4.Checked = true;
          this.m_paramBaseSystem.m_nEffectMode = 2U;
          this.UpdateAllControlsFromParameters();
          break;
      }
    }

    private void TrayMenu_SelectPreset(object sender, EventArgs e)
    {
      if (sender == null || sender.GetType() != typeof (ToolStripMenuItem))
        return;
      ToolStripMenuItem toolStripMenuItem1 = sender as ToolStripMenuItem;
      if (toolStripMenuItem1.Tag == null || toolStripMenuItem1.Tag.GetType() != typeof (TrayMenuPreset))
        return;
      TrayMenuPreset tag1 = toolStripMenuItem1.Tag as TrayMenuPreset;
      if (!tag1.Valid())
        return;
      this.m_paramBaseSystem.m_nEffectMode = (uint) tag1.PresetMode;
      ToolStripMenuItem toolStripMenuItem2 = (ToolStripMenuItem) null;
      ToolStripMenuItem toolStripMenuItem3 = (ToolStripMenuItem) null;
      ToolStripMenuItem toolStripMenuItem4 = (ToolStripMenuItem) null;
      foreach (object obj in (ArrangedElementCollection) this.contextMenuStrip_TrayMenu.Items)
      {
        if (obj != null && obj.GetType() == typeof (ToolStripMenuItem))
        {
          ToolStripMenuItem toolStripMenuItem5 = obj as ToolStripMenuItem;
          if (toolStripMenuItem5.Tag != null && toolStripMenuItem5.Tag.GetType() == typeof (string))
          {
            string tag2 = toolStripMenuItem5.Tag as string;
            if (!string.IsNullOrEmpty(tag2))
            {
              switch (tag2)
              {
                case "MUSIC_MODE":
                  toolStripMenuItem2 = toolStripMenuItem5;
                  continue;
                case "MOVIE_MODE":
                  toolStripMenuItem3 = toolStripMenuItem5;
                  continue;
                case "FREESTYLE_MODE":
                  toolStripMenuItem4 = toolStripMenuItem5;
                  continue;
                default:
                  continue;
              }
            }
          }
        }
      }
      if (toolStripMenuItem2 == null || toolStripMenuItem3 == null || toolStripMenuItem4 == null)
        return;
      if (this.m_paramBaseSystem.m_nEffectMode == 0U)
      {
        toolStripMenuItem2.Checked = true;
        toolStripMenuItem3.Checked = false;
        toolStripMenuItem4.Checked = false;
      }
      else if (this.m_paramBaseSystem.m_nEffectMode == 1U)
      {
        toolStripMenuItem2.Checked = false;
        toolStripMenuItem3.Checked = true;
        toolStripMenuItem4.Checked = false;
      }
      else if (this.m_paramBaseSystem.m_nEffectMode == 2U)
      {
        toolStripMenuItem2.Checked = false;
        toolStripMenuItem3.Checked = false;
        toolStripMenuItem4.Checked = true;
      }
      if (!tag1.PresetLoadable())
        return;
      RuntimeUtils.ConfigProxy._ParamOfBaseSystem paramOfBaseSystem = new RuntimeUtils.ConfigProxy._ParamOfBaseSystem();
      RuntimeUtils.ConfigProxy._ParamOfMusicMode paramOfMusicMode = new RuntimeUtils.ConfigProxy._ParamOfMusicMode();
      RuntimeUtils.ConfigProxy._ParamOfMovieMode paramOfMovieMode = new RuntimeUtils.ConfigProxy._ParamOfMovieMode();
      RuntimeUtils.ConfigProxy._ParamOfFreestyle paramOfFreestyle = new RuntimeUtils.ConfigProxy._ParamOfFreestyle();
      Parameters.LoadDefaultParameter(ref paramOfBaseSystem);
      Parameters.LoadDefaultParameter(ref paramOfMusicMode);
      Parameters.LoadDefaultParameter(ref paramOfMovieMode);
      Parameters.LoadDefaultParameter(ref paramOfFreestyle);
      bool bPBaseSystem = false;
      bool bPMusicMode = false;
      bool bPMovieMode = false;
      bool bPFreestyle = false;
      if (!Parameters.ReadPreset(tag1.PresetFile, ref paramOfBaseSystem, ref paramOfMusicMode, ref paramOfMovieMode, ref paramOfFreestyle, out bPBaseSystem, out bPMusicMode, out bPMovieMode, out bPFreestyle))
      {
        int num = (int) MessageBox.Show(GlobalMessages.CANT_LOAD_PRESET, GlobalMessages.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        if (!bPMusicMode && !bPMovieMode && !bPFreestyle)
          return;
        if (bPMusicMode)
          this.m_paramMusicMode = paramOfMusicMode;
        if (bPMovieMode)
          this.m_paramMovieMode = paramOfMovieMode;
        if (bPFreestyle)
          this.m_paramFreestyle = paramOfFreestyle;
        this.UpdateAllControlsFromParameters();
      }
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      if (!this.m_bArgvStartupToMinimized)
        return;
      this.SetupTrayMenu();
      this.WindowState = FormWindowState.Minimized;
      this.Hide();
      this.ShowInTaskbar = false;
      this.notifyIcon_Main.Visible = true;
    }

    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      Parameters.SaveLocalPreset(this.m_szLocalPreset, this.m_paramBaseSystem, this.m_paramMusicMode, this.m_paramMovieMode, this.m_paramFreestyle);
      this.SaveAppSettings();
      if (!this.m_bCloseToTray || e.CloseReason != CloseReason.UserClosing)
        return;
      this.SetupTrayMenu();
      e.Cancel = true;
      this.WindowState = FormWindowState.Minimized;
      this.Hide();
      this.ShowInTaskbar = false;
      this.notifyIcon_Main.Visible = true;
    }

    private void frmMain_SizeChanged(object sender, EventArgs e)
    {
      if (this.WindowState != FormWindowState.Minimized)
        return;
      Parameters.SaveLocalPreset(this.m_szLocalPreset, this.m_paramBaseSystem, this.m_paramMusicMode, this.m_paramMovieMode, this.m_paramFreestyle);
      this.SetupTrayMenu();
      this.Hide();
      this.ShowInTaskbar = false;
      this.notifyIcon_Main.Visible = true;
    }

    private void notifyIcon_Main_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left || this.WindowState != FormWindowState.Minimized)
        return;
      this.ShowInTaskbar = true;
      this.Show();
      this.WindowState = FormWindowState.Normal;
      this.Activate();
      this.notifyIcon_Main.Visible = false;
    }

    private float PostVolumeToFloat(float fPostVolume) => fPostVolume / 6f;

    private float FloatToPostVolume(float fValue) => fValue * 6f;

    private float BassSpeakerSizeToFloat(int nSpkSize) => 1f - (float) (((double) nSpkSize - 40.0) / 85.0);

    private int FloatToBassSpeakerSize(float fValue)
    {
      fValue = 1f - fValue;
      int bassSpeakerSize = (int) ((double) fValue * 85.0 + 40.0);
      if (bassSpeakerSize < 40)
        bassSpeakerSize = 40;
      if (bassSpeakerSize > 125)
        bassSpeakerSize = 125;
      return bassSpeakerSize;
    }

    private float BassGainToFloat(float fBassGain) => fBassGain / 7f;

    private float FloatToBassGain(float fValue) => fValue * 7f;

    private float ClarityToFloat(float fClarity) => fClarity / 2f;

    public float FloatToClarity(float fValue) => fValue * 2f;

    public float Surround3DToFloat(float fSurround3D)
    {
      float num = (float) (((double) fSurround3D - 1.0) / 2.0);
      if ((double) num < 0.0)
        num = 0.0f;
      if ((double) num > 1.0)
        num = 1f;
      return num;
    }

    public float FloatToSurround3D(float fValue) => (float) ((double) fValue * 2.0 + 1.0);

    public float SVCSToFloat(float fSVCS) => (float) (((double) fSVCS - 0.5) / 4.5);

    public float FloatToSVCS(float fValue) => (float) ((double) fValue * 4.5 + 0.5);

    public float SVMaxLevelToFloat(float fSVMaxLevel) => (float) (((double) fSVMaxLevel - 1.0) / 9.0);

    public float FloatToSVMaxLevel(float fValue) => (float) ((double) fValue * 9.0 + 1.0);

    public float SVLevelToFloat(float fSVLevel) => (float) (((double) fSVLevel - 0.20000000298023224) / 0.800000011920929);

    public float FloatToSVLevel(float fValue) => (float) ((double) fValue * 0.800000011920929 + 0.20000000298023224);

    private void LanguageChanged(object sender, EventArgs e)
    {
      try
      {
        if (!((sender as ToolStripMenuItem).Tag is string tag) || !(tag != ""))
          return;
        string szValue = new ConfigFile(tag).ReadConfig("$LANGUAGE_NAME");
        if (szValue == "")
          return;
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        if (!baseDirectory.EndsWith("\\"))
          baseDirectory += "\\";
        new ConfigFile(baseDirectory + "Config.ini").SetConfig("$LANGUAGE_NAME", szValue);
        if (MessageBox.Show(GlobalMessages.LANGUAGE_CHANGE_NOTICE, GlobalMessages.INFORMATION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
        Application.Exit();
      }
      catch
      {
      }
    }

    private void UpdateAllControlsFromParameters()
    {
      this.onOffSwitch_Master.SwitchedOn = this.m_paramBaseSystem.m_bEffectEnabled != 0;
      if (this.m_paramBaseSystem.m_nEffectMode == 0U)
        this.buttonBox_Mode.SelectItem(0);
      else if (this.m_paramBaseSystem.m_nEffectMode == 1U)
        this.buttonBox_Mode.SelectItem(1);
      else if (this.m_paramBaseSystem.m_nEffectMode == 2U)
        this.buttonBox_Mode.SelectItem(2);
      this.Music_hSlider_PreVolume.PositionFloat = this.m_paramMusicMode.m_rPreVolume;
      this.Music_hSlider_PostVolume.PositionFloat = this.PostVolumeToFloat(this.m_paramMusicMode.m_rPostVolume);
      this.Music_onOffSwitch_Convolver.SwitchedOn = this.m_paramMusicMode.m_bConvolverEnabled != 0;
      this.Music_openFileBox_ConvIRS.FilePathName = RuntimeUtils.GeneralUtils.CharArrayToString(this.m_paramMusicMode.m_szConvolverIR);
      this.Music_hSlider_ConvIRGain.PositionFloat = this.m_paramMusicMode.m_rConvolverIRGain;
      this.Music_onOffSwitch_Surround.SwitchedOn = this.m_paramMusicMode.m_bSurroundEnabled != 0;
      this.Music_buttonBox_SurroundRoomSize.SelectItem(this.m_paramMusicMode.m_nVHERoomSize);
      this.Music_onOffSwitch_Bass.SwitchedOn = this.m_paramMusicMode.m_bViPERBassEnabled != 0;
      this.Music_hSlider_BassSpkSize.PositionFloat = this.BassSpeakerSizeToFloat(this.m_paramMusicMode.m_nViPERBassSpkSize);
      this.Music_hSlider_BassGain.PositionFloat = this.BassGainToFloat(this.m_paramMusicMode.m_rViPERBassFactor);
      this.Music_onOffSwitch_Clarity.SwitchedOn = this.m_paramMusicMode.m_bViPERClarityEnabled != 0;
      this.Music_buttonBox_ClarityMode.SelectItem(this.m_paramMusicMode.m_nViPERClarityMode);
      this.Music_hSlider_Clarity.PositionFloat = this.ClarityToFloat(this.m_paramMusicMode.m_rViPERClarityFactor);
      this.Music_onOffSwitch_Cure.SwitchedOn = this.m_paramMusicMode.m_bCureEnabled != 0;
      if (this.m_paramMusicMode.m_uiCureLevel == 6226570U)
        this.Music_buttonBox_CureLevel.SelectItem(0);
      else if (this.m_paramMusicMode.m_uiCureLevel == 3932860U)
        this.Music_buttonBox_CureLevel.SelectItem(1);
      else if (this.m_paramMusicMode.m_uiCureLevel == 2949820U)
        this.Music_buttonBox_CureLevel.SelectItem(2);
      this.Music_onOffSwitch_Tube.SwitchedOn = this.m_paramMusicMode.m_bTubeEnabled != 0;
      this.Music_onOffSwitch_Reverb.SwitchedOn = this.m_paramMusicMode.m_bReverbEnabled != 0;
      this.Music_hSlider_ReverbSize.PositionFloat = this.m_paramMusicMode.m_rReverbSize;
      this.Music_hSlider_ReverbDamping.PositionFloat = this.m_paramMusicMode.m_rReverbDamping;
      this.Music_hSlider_ReverbDensity.PositionFloat = this.m_paramMusicMode.m_rReverbDensity;
      this.Music_hSlider_ReverbBandWidth.PositionFloat = this.m_paramMusicMode.m_rReverbBandwidth;
      this.Music_hSlider_ReverbDecay.PositionFloat = this.m_paramMusicMode.m_rReverbDecay;
      this.Music_hSlider_ReverbPreDelay.PositionFloat = this.m_paramMusicMode.m_rReverbPredelay;
      this.Music_hSlider_ReverbEarlyMix.PositionFloat = this.m_paramMusicMode.m_rReverbEarlyMix;
      this.Music_hSlider_ReverbMix.PositionFloat = this.m_paramMusicMode.m_rReverbMix;
      this.Movie_hSlider_PreVolume.PositionFloat = this.m_paramMovieMode.m_rPreVolume;
      this.Movie_hSlider_PostVolume.PositionFloat = this.PostVolumeToFloat(this.m_paramMovieMode.m_rPostVolume);
      this.Movie_onOffSwitch_Convolver.SwitchedOn = this.m_paramMovieMode.m_bConvolverEnabled != 0;
      this.Movie_openFileBox_ConvIRS.FilePathName = RuntimeUtils.GeneralUtils.CharArrayToString(this.m_paramMovieMode.m_szConvolverIR);
      this.Movie_hSlider_ConvIRGain.PositionFloat = this.m_paramMovieMode.m_rConvolverIRGain;
      this.Movie_onOffSwitch_Surround.SwitchedOn = this.m_paramMovieMode.m_bSurroundEnabled != 0;
      this.Movie_hSlider_Surround3D.PositionFloat = this.Surround3DToFloat(this.m_paramMovieMode.m_r3DSurroundStereo);
      this.Movie_hSlider_SurroundImage.PositionFloat = this.Surround3DToFloat(this.m_paramMovieMode.m_r3DSurroundImage);
      this.Movie_onOffSwitch_Bass.SwitchedOn = this.m_paramMovieMode.m_bViPERBassEnabled != 0;
      this.Movie_hSlider_BassSpkSize.PositionFloat = this.BassSpeakerSizeToFloat(this.m_paramMovieMode.m_nViPERBassSpkSize);
      this.Movie_hSlider_BassGain.PositionFloat = this.BassGainToFloat(this.m_paramMovieMode.m_rViPERBassFactor);
      this.Movie_onOffSwitch_Clarity.SwitchedOn = this.m_paramMovieMode.m_bViPERClarityEnabled != 0;
      this.Movie_hSlider_Clarity.PositionFloat = this.ClarityToFloat(this.m_paramMovieMode.m_rViPERClarityFactor);
      this.Movie_onOffSwitch_SmartVolume.SwitchedOn = this.m_paramMovieMode.m_bSmartVolumeEnabled != 0;
      this.Movie_hSlider_SmartVolumeRatio.PositionFloat = this.SVCSToFloat(this.m_paramMovieMode.m_rSVRatio);
      this.Movie_hSlider_SmartVolumeMaxLevel.PositionFloat = this.SVMaxLevelToFloat(this.m_paramMovieMode.m_rSVMaxGain);
      this.Movie_hSlider_SmartVolumeLevel.PositionFloat = this.SVLevelToFloat(this.m_paramMovieMode.m_rSVVolume);
      this.Movie_onOffSwitch_Reverb.SwitchedOn = this.m_paramMovieMode.m_bReverbEnabled != 0;
      this.Movie_hSlider_ReverbSize.PositionFloat = this.m_paramMovieMode.m_rReverbSize;
      this.Movie_hSlider_ReverbDamping.PositionFloat = this.m_paramMovieMode.m_rReverbDamping;
      this.Movie_hSlider_ReverbDensity.PositionFloat = this.m_paramMovieMode.m_rReverbDensity;
      this.Movie_hSlider_ReverbBandWidth.PositionFloat = this.m_paramMovieMode.m_rReverbBandwidth;
      this.Movie_hSlider_ReverbDecay.PositionFloat = this.m_paramMovieMode.m_rReverbDecay;
      this.Movie_hSlider_ReverbPreDelay.PositionFloat = this.m_paramMovieMode.m_rReverbPredelay;
      this.Movie_hSlider_ReverbEarlyMix.PositionFloat = this.m_paramMovieMode.m_rReverbEarlyMix;
      this.Movie_hSlider_ReverbMix.PositionFloat = this.m_paramMovieMode.m_rReverbMix;
      this.Freestyle_hSlider_PreVolume.PositionFloat = this.m_paramFreestyle.m_rPreVolume;
      this.Freestyle_hSlider_PostVolume.PositionFloat = this.PostVolumeToFloat(this.m_paramFreestyle.m_rPostVolume);
      this.Freestyle_onOffSwitch_Convolver.SwitchedOn = this.m_paramFreestyle.m_bConvolverEnabled != 0;
      this.Freestyle_openFileBox_ConvIRS.FilePathName = RuntimeUtils.GeneralUtils.CharArrayToString(this.m_paramFreestyle.m_szConvolverIR);
      this.Freestyle_hSlider_ConvIRGain.PositionFloat = this.m_paramFreestyle.m_rConvolverIRGain;
      this.Freestyle_onOffSwitch_Surround3D.SwitchedOn = this.m_paramFreestyle.m_b3DSurroundEnabled != 0;
      this.Freestyle_hSlider_Surround3D.PositionFloat = this.Surround3DToFloat(this.m_paramFreestyle.m_r3DSurroundStereo);
      this.Freestyle_hSlider_SurroundImage.PositionFloat = this.Surround3DToFloat(this.m_paramFreestyle.m_r3DSurroundImage);
      this.Freestyle_onOffSwitch_SurroundVHE.SwitchedOn = this.m_paramFreestyle.m_bVHESurroundEnabled != 0;
      this.Freestyle_buttonBox_SurroundVHERoomSize.SelectItem(this.m_paramFreestyle.m_nVHERoomSize);
      this.Freestyle_onOffSwitch_Bass.SwitchedOn = this.m_paramFreestyle.m_bViPERBassEnabled != 0;
      this.Freestyle_buttonBox_BassMode.SelectItem(this.m_paramFreestyle.m_nViPERBassMode);
      this.Freestyle_hSlider_BassSpkSize.PositionFloat = this.BassSpeakerSizeToFloat(this.m_paramFreestyle.m_nViPERBassSpkSize);
      this.Freestyle_hSlider_BassGain.PositionFloat = this.BassGainToFloat(this.m_paramFreestyle.m_rViPERBassFactor);
      this.Freestyle_onOffSwitch_Clarity.SwitchedOn = this.m_paramFreestyle.m_bViPERClarityEnabled != 0;
      this.Freestyle_buttonBox_ClarityMode.SelectItem(this.m_paramFreestyle.m_nViPERClarityMode);
      this.Freestyle_hSlider_Clarity.PositionFloat = this.ClarityToFloat(this.m_paramFreestyle.m_rViPERClarityFactor);
      this.Freestyle_onOffSwitch_Cure.SwitchedOn = this.m_paramFreestyle.m_bCureEnabled != 0;
      if (this.m_paramFreestyle.m_uiCureLevel == 6226570U)
        this.Freestyle_buttonBox_CureLevel.SelectItem(0);
      else if (this.m_paramFreestyle.m_uiCureLevel == 3932860U)
        this.Freestyle_buttonBox_CureLevel.SelectItem(1);
      else if (this.m_paramFreestyle.m_uiCureLevel == 2949820U)
        this.Freestyle_buttonBox_CureLevel.SelectItem(2);
      this.Freestyle_onOffSwitch_Tube.SwitchedOn = this.m_paramFreestyle.m_bTubeEnabled != 0;
      this.Freestyle_onOffSwitch_SmartVolume.SwitchedOn = this.m_paramFreestyle.m_bSmartVolumeEnabled != 0;
      this.Freestyle_hSlider_SmartVolumeRatio.PositionFloat = this.SVCSToFloat(this.m_paramFreestyle.m_rSVRatio);
      this.Freestyle_hSlider_SmartVolumeMaxLevel.PositionFloat = this.SVMaxLevelToFloat(this.m_paramFreestyle.m_rSVMaxGain);
      this.Freestyle_hSlider_SmartVolumeLevel.PositionFloat = this.SVLevelToFloat(this.m_paramFreestyle.m_rSVVolume);
      this.Freestyle_onOffSwitch_Reverb.SwitchedOn = this.m_paramFreestyle.m_bReverbEnabled != 0;
      this.Freestyle_hSlider_ReverbSize.PositionFloat = this.m_paramFreestyle.m_rReverbSize;
      this.Freestyle_hSlider_ReverbDamping.PositionFloat = this.m_paramFreestyle.m_rReverbDamping;
      this.Freestyle_hSlider_ReverbDensity.PositionFloat = this.m_paramFreestyle.m_rReverbDensity;
      this.Freestyle_hSlider_ReverbBandWidth.PositionFloat = this.m_paramFreestyle.m_rReverbBandwidth;
      this.Freestyle_hSlider_ReverbDecay.PositionFloat = this.m_paramFreestyle.m_rReverbDecay;
      this.Freestyle_hSlider_ReverbPreDelay.PositionFloat = this.m_paramFreestyle.m_rReverbPredelay;
      this.Freestyle_hSlider_ReverbEarlyMix.PositionFloat = this.m_paramFreestyle.m_rReverbEarlyMix;
      this.Freestyle_hSlider_ReverbMix.PositionFloat = this.m_paramFreestyle.m_rReverbMix;
    }

    private void toolStripMenuItem_LatencySetting_Click(object sender, EventArgs e)
    {
      frmLatency frmLatency = new frmLatency();
      frmLatency.ShortFilterLen = this.m_paramBaseSystem.m_nFilterShortLen;
      frmLatency.MiddleFilterLen = this.m_paramBaseSystem.m_nFilterMediumLen;
      frmLatency.LongFilterLen = this.m_paramBaseSystem.m_nFilterLongLen;
      if (frmLatency.ShowDialog() == DialogResult.Cancel)
        return;
      this.m_paramBaseSystem.m_nFilterShortLen = frmLatency.ShortFilterLen;
      this.m_paramBaseSystem.m_nFilterMediumLen = frmLatency.MiddleFilterLen;
      this.m_paramBaseSystem.m_nFilterLongLen = frmLatency.LongFilterLen;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramBaseSystem);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void toolStripMenuItem_ChannelPan_Click(object sender, EventArgs e)
    {
      frmChannelPan frmChannelPan = new frmChannelPan();
      frmChannelPan.ChannelPan = this.m_paramBaseSystem.m_rChannelPan;
      int num = (int) frmChannelPan.ShowDialog();
      this.m_paramBaseSystem.m_rChannelPan = frmChannelPan.ChannelPan;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramBaseSystem);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void toolStripMenuItem_Virtualization_Click(object sender, EventArgs e)
    {
      frmVirtualization frmVirtualization = new frmVirtualization();
      frmVirtualization.SetBaseSystemParam(this.m_paramBaseSystem);
      if (frmVirtualization.ShowDialog() == DialogResult.Cancel)
        return;
      this.m_paramBaseSystem = frmVirtualization.GetBaseSystemParam();
      this.m_cpConfigProxy.UpdateParameter(this.m_paramBaseSystem);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void toolStripMenuItem_ResetEffect_Click(object sender, EventArgs e)
    {
      Parameters.LoadDefaultParameter(ref this.m_paramMusicMode);
      Parameters.LoadDefaultParameter(ref this.m_paramMovieMode);
      Parameters.LoadDefaultParameter(ref this.m_paramFreestyle);
      this.UpdateAllControlsFromParameters();
    }

    private void toolStripMenuItem_Settings_Click(object sender, EventArgs e)
    {
      uint num1 = RegHelper.QueryDWORD("LoadChildAPO", 0U);
      frmSettings frmSettings = new frmSettings();
      frmSettings.SetPresetPath(this.m_szPresetsPath);
      frmSettings.SetCloseToTray(this.m_bCloseToTray);
      frmSettings.SetTrayMenuPresetList(this.m_lstTrayMenuPreset);
      if (frmSettings.ShowDialog() == DialogResult.Cancel)
        return;
      this.m_bCloseToTray = frmSettings.GetCloseToTray();
      List<TrayMenuPreset> trayMenuPresetList = frmSettings.GetTrayMenuPresetList();
      this.m_lstTrayMenuPreset.Clear();
      foreach (TrayMenuPreset trayMenuPreset in trayMenuPresetList)
      {
        if (trayMenuPreset.Valid())
        {
          if (string.IsNullOrEmpty(trayMenuPreset.PresetName))
            trayMenuPreset.PresetName = GlobalMessages.UNNAMED;
          this.m_lstTrayMenuPreset.Add(trayMenuPreset.Clone());
        }
      }
      this.SaveAppSettings();
      uint uiValue = !frmSettings.GetAPOCoexistEnabled() ? 0U : 1U;
      if ((int) uiValue == (int) num1)
        return;
      RegHelper.WriteDWORD("LoadChildAPO", uiValue);
      if (uiValue == 1U)
      {
        int num2 = (int) MessageBox.Show(GlobalMessages.ENABLE_APO_COEXIST_WRN_LINE1 + "\n" + GlobalMessages.ENABLE_APO_COEXIST_WRN_LINE2 + "\n\n" + GlobalMessages.ENABLE_APO_COEXIST_RESTART, GlobalMessages.ENABLE_APO_COEXIST, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        int num3 = (int) MessageBox.Show(GlobalMessages.ENABLE_APO_COEXIST_RESTART, GlobalMessages.ENABLE_APO_COEXIST, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
    }

    private void toolStripMenuItem_CheckUpdate_Click(object sender, EventArgs e)
    {
      int num = (int) new frmCheckUpdate().ShowDialog();
    }

    private void toolStripMenuItem_AboutV4W_Click(object sender, EventArgs e)
    {
      int num = (int) new frmAbout().ShowDialog();
    }

    private void onOffSwitch_Master_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender)
    {
      this.m_paramBaseSystem.m_bEffectEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramBaseSystem);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void buttonBox_Mode_ItemSelectedNotify(
      ButtonBox.Item itPrevItem,
      ButtonBox.Item itCurrItem,
      ButtonBox objSender)
    {
      if (itCurrItem == null || itCurrItem.Tag == null || !(itCurrItem.Tag is string tag))
        return;
      if (tag == 0.ToString())
      {
        this.panel_MusicMode.Visible = true;
        this.panel_MovieMode.Visible = false;
        this.panel_Freestyle.Visible = false;
        this.m_paramBaseSystem.m_nEffectMode = 0U;
        this.m_cpConfigProxy.UpdateParameter(this.m_paramBaseSystem);
        this.m_cpConfigProxy.SyncConfig();
      }
      else if (tag == 1.ToString())
      {
        this.panel_MusicMode.Visible = false;
        this.panel_MovieMode.Visible = true;
        this.panel_Freestyle.Visible = false;
        this.m_paramBaseSystem.m_nEffectMode = 1U;
        this.m_cpConfigProxy.UpdateParameter(this.m_paramBaseSystem);
        this.m_cpConfigProxy.SyncConfig();
      }
      else
      {
        if (!(tag == 2.ToString()))
          return;
        this.panel_MusicMode.Visible = false;
        this.panel_MovieMode.Visible = false;
        this.panel_Freestyle.Visible = true;
        this.m_paramBaseSystem.m_nEffectMode = 2U;
        this.m_cpConfigProxy.UpdateParameter(this.m_paramBaseSystem);
        this.m_cpConfigProxy.SyncConfig();
      }
    }

    private void singleButton_LoadPreset_ButtonClickNotify(SingleButton objSender)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Title = GlobalMessages.LOAD_PRESET;
      openFileDialog.Filter = "*.vpf|*.vpf";
      openFileDialog.DefaultExt = "vpf";
      openFileDialog.InitialDirectory = this.m_szPresetsPath;
      if (openFileDialog.ShowDialog() == DialogResult.Cancel)
        return;
      RuntimeUtils.ConfigProxy._ParamOfBaseSystem paramOfBaseSystem = new RuntimeUtils.ConfigProxy._ParamOfBaseSystem();
      RuntimeUtils.ConfigProxy._ParamOfMusicMode paramOfMusicMode = new RuntimeUtils.ConfigProxy._ParamOfMusicMode();
      RuntimeUtils.ConfigProxy._ParamOfMovieMode paramOfMovieMode = new RuntimeUtils.ConfigProxy._ParamOfMovieMode();
      RuntimeUtils.ConfigProxy._ParamOfFreestyle paramOfFreestyle = new RuntimeUtils.ConfigProxy._ParamOfFreestyle();
      Parameters.LoadDefaultParameter(ref paramOfBaseSystem);
      Parameters.LoadDefaultParameter(ref paramOfMusicMode);
      Parameters.LoadDefaultParameter(ref paramOfMovieMode);
      Parameters.LoadDefaultParameter(ref paramOfFreestyle);
      bool bPBaseSystem = false;
      bool bPMusicMode = false;
      bool bPMovieMode = false;
      bool bPFreestyle = false;
      if (!Parameters.ReadPreset(openFileDialog.FileName, ref paramOfBaseSystem, ref paramOfMusicMode, ref paramOfMovieMode, ref paramOfFreestyle, out bPBaseSystem, out bPMusicMode, out bPMovieMode, out bPFreestyle))
      {
        int num = (int) MessageBox.Show(GlobalMessages.CANT_LOAD_PRESET, GlobalMessages.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
      else
      {
        if (!bPMusicMode && !bPMovieMode && !bPFreestyle)
          return;
        if (bPMusicMode)
          this.m_paramMusicMode = paramOfMusicMode;
        if (bPMovieMode)
          this.m_paramMovieMode = paramOfMovieMode;
        if (bPFreestyle)
          this.m_paramFreestyle = paramOfFreestyle;
        this.UpdateAllControlsFromParameters();
      }
    }

    private void singleButton_SavePreset_ButtonClickNotify(SingleButton objSender)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Title = GlobalMessages.SAVE_PRESET;
      saveFileDialog.Filter = "*.vpf|*.vpf";
      saveFileDialog.DefaultExt = "vpf";
      saveFileDialog.InitialDirectory = this.m_szPresetsPath;
      if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
        return;
      switch (this.m_paramBaseSystem.m_nEffectMode)
      {
        case 0:
          Parameters.SavePreset(saveFileDialog.FileName, this.m_paramMusicMode);
          break;
        case 1:
          Parameters.SavePreset(saveFileDialog.FileName, this.m_paramMovieMode);
          break;
        case 2:
          Parameters.SavePreset(saveFileDialog.FileName, this.m_paramFreestyle);
          break;
        default:
          int num = (int) MessageBox.Show(GlobalMessages.CANT_SAVE_PRESET, GlobalMessages.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
          break;
      }
    }

    private void Freestyle_hSlider_PreVolume_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramFreestyle.m_rPreVolume = fPercent;
      this.Freestyle_label_PreVolume.Text = GlobalMessages.PRE_VOLUME + " : " + (20.0 * Math.Log10((double) fPercent + 1E-06)).ToString("F02") + "dB";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_hSlider_PostVolume_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramFreestyle.m_rPostVolume = this.FloatToPostVolume(fPercent);
      this.Freestyle_label_PostVolume.Text = GlobalMessages.POST_VOLUME + " : " + (20.0 * Math.Log10((double) this.FloatToPostVolume(fPercent) + 1E-06)).ToString("F02") + "dB";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_onOffSwitch_Convolver_SwitchChangeNotify(
      bool bSwitchedOn,
      OnOffSwitch objSender)
    {
      this.m_paramFreestyle.m_bConvolverEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_hSlider_ConvIRGain_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramFreestyle.m_rConvolverIRGain = fPercent;
      this.Freestyle_label_ConvolverIRGain.Text = GlobalMessages.CONV_IR_GAIN + " : " + (20.0 * Math.Log10((double) fPercent + 1E-06)).ToString("F02") + "dB";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_openFileBox_ConvIRS_FileChangeNotify(
      string szFilePathName,
      OpenFileBox objSender)
    {
      this.m_paramFreestyle.m_szConvolverIR = Parameters.WriteStringToArray260(szFilePathName);
      int nChannelCount = 0;
      this.Freestyle_irShape_ConvIR.SetImpulseResponse(RuntimeUtils.ImpulseResponseUtils.EstimateImpulseResponseSample(szFilePathName, out nChannelCount), nChannelCount);
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_onOffSwitch_Surround3D_SwitchChangeNotify(
      bool bSwitchedOn,
      OnOffSwitch objSender)
    {
      this.m_paramFreestyle.m_b3DSurroundEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_hSlider_Surround3D_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramFreestyle.m_r3DSurroundStereo = this.FloatToSurround3D(fPercent);
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_hSlider_SurroundImage_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramFreestyle.m_r3DSurroundImage = this.FloatToSurround3D(fPercent);
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_onOffSwitch_SurroundVHE_SwitchChangeNotify(
      bool bSwitchedOn,
      OnOffSwitch objSender)
    {
      this.m_paramFreestyle.m_bVHESurroundEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_buttonBox_SurroundVHERoomSize_ItemSelectedNotify(
      ButtonBox.Item itPrevItem,
      ButtonBox.Item itCurrItem,
      ButtonBox objSender)
    {
      if (itCurrItem == null || itCurrItem.Tag == null || !(itCurrItem.Tag is string tag))
        return;
      int result = -1;
      if (!int.TryParse(tag, out result) || result < 0 || result > 4)
        return;
      this.m_paramFreestyle.m_nVHERoomSize = result;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_onOffSwitch_Bass_SwitchChangeNotify(
      bool bSwitchedOn,
      OnOffSwitch objSender)
    {
      this.m_paramFreestyle.m_bViPERBassEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_hSlider_BassSpkSize_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramFreestyle.m_nViPERBassSpkSize = this.FloatToBassSpeakerSize(fPercent);
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_hSlider_BassGain_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramFreestyle.m_rViPERBassFactor = this.FloatToBassGain(fPercent);
      this.Freestyle_label_Bass_Gain.Text = GlobalMessages.BASS_GAIN + " : " + (20.0 * Math.Log10((double) this.FloatToBassGain(fPercent) + 1.0)).ToString("F02") + "dB";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_buttonBox_BassMode_ItemSelectedNotify(
      ButtonBox.Item itPrevItem,
      ButtonBox.Item itCurrItem,
      ButtonBox objSender)
    {
      if (itCurrItem == null || itCurrItem.Tag == null || !(itCurrItem.Tag is string tag))
        return;
      int result = -1;
      if (!int.TryParse(tag, out result) || result < 0 || result > 1)
        return;
      this.m_paramFreestyle.m_nViPERBassMode = result;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_onOffSwitch_Clarity_SwitchChangeNotify(
      bool bSwitchedOn,
      OnOffSwitch objSender)
    {
      this.m_paramFreestyle.m_bViPERClarityEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_buttonBox_ClarityMode_ItemSelectedNotify(
      ButtonBox.Item itPrevItem,
      ButtonBox.Item itCurrItem,
      ButtonBox objSender)
    {
      if (itCurrItem == null || itCurrItem.Tag == null || !(itCurrItem.Tag is string tag))
        return;
      int result = -1;
      if (!int.TryParse(tag, out result) || result < 0 || result > 2)
        return;
      this.m_paramFreestyle.m_nViPERClarityMode = result;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_hSlider_Clarity_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramFreestyle.m_rViPERClarityFactor = this.FloatToClarity(fPercent);
      this.Freestyle_label_Clarity.Text = GlobalMessages.CLARITY + " : " + (20.0 * Math.Log10((double) this.FloatToClarity(fPercent) + 1.0)).ToString("F02") + "dB";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_onOffSwitch_Cure_SwitchChangeNotify(
      bool bSwitchedOn,
      OnOffSwitch objSender)
    {
      this.m_paramFreestyle.m_bCureEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_buttonBox_CureLevel_ItemSelectedNotify(
      ButtonBox.Item itPrevItem,
      ButtonBox.Item itCurrItem,
      ButtonBox objSender)
    {
      if (itCurrItem == null || itCurrItem.Tag == null || !(itCurrItem.Tag is string tag))
        return;
      if (tag == 6226570U.ToString())
      {
        this.m_paramFreestyle.m_uiCureLevel = 6226570U;
        this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
        this.m_cpConfigProxy.SyncConfig();
      }
      else if (tag == 3932860U.ToString())
      {
        this.m_paramFreestyle.m_uiCureLevel = 3932860U;
        this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
        this.m_cpConfigProxy.SyncConfig();
      }
      else
      {
        if (!(tag == 2949820U.ToString()))
          return;
        this.m_paramFreestyle.m_uiCureLevel = 2949820U;
        this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
        this.m_cpConfigProxy.SyncConfig();
      }
    }

    private void Freestyle_onOffSwitch_Tube_SwitchChangeNotify(
      bool bSwitchedOn,
      OnOffSwitch objSender)
    {
      this.m_paramFreestyle.m_bTubeEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_onOffSwitch_SmartVolume_SwitchChangeNotify(
      bool bSwitchedOn,
      OnOffSwitch objSender)
    {
      this.m_paramFreestyle.m_bSmartVolumeEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_hSlider_SmartVolumeRatio_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramFreestyle.m_rSVRatio = this.FloatToSVCS(fPercent);
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_hSlider_SmartVolumeMaxLevel_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramFreestyle.m_rSVMaxGain = this.FloatToSVMaxLevel(fPercent);
      this.Freestyle_label_SmartVolume_MaxLevel.Text = GlobalMessages.SMART_VOLUME_MAXLEVEL + " : " + this.FloatToSVMaxLevel(fPercent).ToString("F02") + "x";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_hSlider_SmartVolumeLevel_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramFreestyle.m_rSVVolume = this.FloatToSVLevel(fPercent);
      this.Freestyle_label_SmartVolume_Level.Text = GlobalMessages.SMART_VOLUME_LEVEL + " : " + (20.0 * Math.Log10((double) this.FloatToSVLevel(fPercent))).ToString("F02") + "dB";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_onOffSwitch_Reverb_SwitchChangeNotify(
      bool bSwitchedOn,
      OnOffSwitch objSender)
    {
      this.m_paramFreestyle.m_bReverbEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_singleButton_ReverbPreset_ButtonClickNotify(SingleButton objSender)
    {
      frmReverbPreset frmReverbPreset = new frmReverbPreset();
      frmReverbPreset.ReverbSize = this.m_paramFreestyle.m_rReverbSize;
      frmReverbPreset.ReverbDamping = this.m_paramFreestyle.m_rReverbDamping;
      frmReverbPreset.ReverbDensity = this.m_paramFreestyle.m_rReverbDensity;
      frmReverbPreset.ReverbBandwidth = this.m_paramFreestyle.m_rReverbBandwidth;
      frmReverbPreset.ReverbDecay = this.m_paramFreestyle.m_rReverbDecay;
      frmReverbPreset.ReverbPredelay = this.m_paramFreestyle.m_rReverbPredelay;
      frmReverbPreset.ReverbEarlyMix = this.m_paramFreestyle.m_rReverbEarlyMix;
      frmReverbPreset.ReverbMix = this.m_paramFreestyle.m_rReverbMix;
      if (frmReverbPreset.ShowDialog() == DialogResult.Cancel)
        return;
      this.m_paramFreestyle.m_rReverbSize = frmReverbPreset.ReverbSize;
      this.m_paramFreestyle.m_rReverbDamping = frmReverbPreset.ReverbDamping;
      this.m_paramFreestyle.m_rReverbDensity = frmReverbPreset.ReverbDensity;
      this.m_paramFreestyle.m_rReverbBandwidth = frmReverbPreset.ReverbBandwidth;
      this.m_paramFreestyle.m_rReverbDecay = frmReverbPreset.ReverbDecay;
      this.m_paramFreestyle.m_rReverbPredelay = frmReverbPreset.ReverbPredelay;
      this.m_paramFreestyle.m_rReverbEarlyMix = frmReverbPreset.ReverbEarlyMix;
      this.m_paramFreestyle.m_rReverbMix = frmReverbPreset.ReverbMix;
      this.Freestyle_hSlider_ReverbSize.PositionFloat = this.m_paramFreestyle.m_rReverbSize;
      this.Freestyle_hSlider_ReverbDamping.PositionFloat = this.m_paramFreestyle.m_rReverbDamping;
      this.Freestyle_hSlider_ReverbDensity.PositionFloat = this.m_paramFreestyle.m_rReverbDensity;
      this.Freestyle_hSlider_ReverbBandWidth.PositionFloat = this.m_paramFreestyle.m_rReverbBandwidth;
      this.Freestyle_hSlider_ReverbDecay.PositionFloat = this.m_paramFreestyle.m_rReverbDecay;
      this.Freestyle_hSlider_ReverbPreDelay.PositionFloat = this.m_paramFreestyle.m_rReverbPredelay;
      this.Freestyle_hSlider_ReverbEarlyMix.PositionFloat = this.m_paramFreestyle.m_rReverbEarlyMix;
      this.Freestyle_hSlider_ReverbMix.PositionFloat = this.m_paramFreestyle.m_rReverbMix;
    }

    private void Freestyle_hSlider_ReverbSize_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramFreestyle.m_rReverbSize = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_hSlider_ReverbDamping_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramFreestyle.m_rReverbDamping = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_hSlider_ReverbDensity_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramFreestyle.m_rReverbDensity = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_hSlider_ReverbBandWidth_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramFreestyle.m_rReverbBandwidth = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_hSlider_ReverbDecay_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramFreestyle.m_rReverbDecay = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_hSlider_ReverbPreDelay_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramFreestyle.m_rReverbPredelay = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_hSlider_ReverbEarlyMix_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramFreestyle.m_rReverbEarlyMix = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_hSlider_ReverbMix_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramFreestyle.m_rReverbMix = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_singleButton_Equalizer_ButtonClickNotify(SingleButton objSender)
    {
      frmEqualizer frmEqualizer = new frmEqualizer();
      frmEqualizer.SetRealtimeParameters(this.m_paramBaseSystem, this.m_paramMusicMode, this.m_paramMovieMode, this.m_paramFreestyle, this.m_cpConfigProxy);
      if (this.m_paramFreestyle.m_bEqualizerEnabled == 0)
        frmEqualizer.SetParameters(this.m_paramFreestyle.m_rpEqualizerBands, false);
      else
        frmEqualizer.SetParameters(this.m_paramFreestyle.m_rpEqualizerBands, true);
      int num = (int) frmEqualizer.ShowDialog();
      this.m_paramFreestyle.m_bEqualizerEnabled = !frmEqualizer.GetEQEnabled() ? 0 : 1;
      if (frmEqualizer.GetParameter() != null)
        this.m_paramFreestyle.m_rpEqualizerBands = frmEqualizer.GetParameter();
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Freestyle_singleButton_Compressor_ButtonClickNotify(SingleButton objSender)
    {
      frmCompressor frmCompressor = new frmCompressor();
      frmCompressor.CompressorEnabled = this.m_paramFreestyle.m_bCompressorEnabled != 0;
      frmCompressor.AutoKnee = this.m_paramFreestyle.m_bCompAutoKnee != 0;
      frmCompressor.AutoAttack = this.m_paramFreestyle.m_bCompAutoAttack != 0;
      frmCompressor.AutoRelease = this.m_paramFreestyle.m_bCompAutoRelease != 0;
      frmCompressor.AutoGain = this.m_paramFreestyle.m_bCompAutoGain != 0;
      frmCompressor.NoClip = this.m_paramFreestyle.m_bCompAutoMetaNoClipping != 0;
      frmCompressor.Threshold = this.m_paramFreestyle.m_rCompThreshold;
      frmCompressor.KneeWidth = this.m_paramFreestyle.m_rCompKneeWidth;
      frmCompressor.Ratio = this.m_paramFreestyle.m_rCompRatio;
      frmCompressor.AttackTime = this.m_paramFreestyle.m_rCompAttack;
      frmCompressor.ReleaseTime = this.m_paramFreestyle.m_rCompRelease;
      frmCompressor.KneeMult = this.m_paramFreestyle.m_rCompMetaKneeMult;
      frmCompressor.CrestTime = this.m_paramFreestyle.m_rCompMetaCrest;
      frmCompressor.AdaptTime = this.m_paramFreestyle.m_rCompMetaAdapt;
      frmCompressor.MakeupGain = this.m_paramFreestyle.m_rCompGain;
      if (frmCompressor.ShowDialog() == DialogResult.Cancel)
        return;
      this.m_paramFreestyle.m_bCompressorEnabled = !frmCompressor.CompressorEnabled ? 0 : 1;
      this.m_paramFreestyle.m_bCompAutoKnee = !frmCompressor.AutoKnee ? 0 : 1;
      this.m_paramFreestyle.m_bCompAutoAttack = !frmCompressor.AutoAttack ? 0 : 1;
      this.m_paramFreestyle.m_bCompAutoRelease = !frmCompressor.AutoRelease ? 0 : 1;
      this.m_paramFreestyle.m_bCompAutoGain = !frmCompressor.AutoGain ? 0 : 1;
      this.m_paramFreestyle.m_bCompAutoMetaNoClipping = !frmCompressor.NoClip ? 0 : 1;
      this.m_paramFreestyle.m_rCompThreshold = frmCompressor.Threshold;
      this.m_paramFreestyle.m_rCompKneeWidth = frmCompressor.KneeWidth;
      this.m_paramFreestyle.m_rCompRatio = frmCompressor.Ratio;
      this.m_paramFreestyle.m_rCompAttack = frmCompressor.AttackTime;
      this.m_paramFreestyle.m_rCompRelease = frmCompressor.ReleaseTime;
      this.m_paramFreestyle.m_rCompMetaKneeMult = frmCompressor.KneeMult;
      this.m_paramFreestyle.m_rCompMetaCrest = frmCompressor.CrestTime;
      this.m_paramFreestyle.m_rCompMetaAdapt = frmCompressor.AdaptTime;
      this.m_paramFreestyle.m_rCompGain = frmCompressor.MakeupGain;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramFreestyle);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_hSlider_PreVolume_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMovieMode.m_rPreVolume = fPercent;
      this.Movie_label_PreVolume.Text = GlobalMessages.PRE_VOLUME + " : " + (20.0 * Math.Log10((double) fPercent + 1E-06)).ToString("F02") + "dB";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_hSlider_PostVolume_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMovieMode.m_rPostVolume = this.FloatToPostVolume(fPercent);
      this.Movie_label_PostVolume.Text = GlobalMessages.POST_VOLUME + " : " + (20.0 * Math.Log10((double) this.FloatToPostVolume(fPercent) + 1E-06)).ToString("F02") + "dB";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_onOffSwitch_Convolver_SwitchChangeNotify(
      bool bSwitchedOn,
      OnOffSwitch objSender)
    {
      this.m_paramMovieMode.m_bConvolverEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_hSlider_ConvIRGain_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMovieMode.m_rConvolverIRGain = fPercent;
      this.Movie_label_ConvolverIRGain.Text = GlobalMessages.CONV_IR_GAIN + " : " + (20.0 * Math.Log10((double) fPercent + 1E-06)).ToString("F02") + "dB";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_openFileBox_ConvIRS_FileChangeNotify(
      string szFilePathName,
      OpenFileBox objSender)
    {
      this.m_paramMovieMode.m_szConvolverIR = Parameters.WriteStringToArray260(szFilePathName);
      int nChannelCount = 0;
      this.Movie_irShape_ConvIR.SetImpulseResponse(RuntimeUtils.ImpulseResponseUtils.EstimateImpulseResponseSample(szFilePathName, out nChannelCount), nChannelCount);
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_onOffSwitch_Surround_SwitchChangeNotify(
      bool bSwitchedOn,
      OnOffSwitch objSender)
    {
      this.m_paramMovieMode.m_bSurroundEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_hSlider_Surround3D_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMovieMode.m_r3DSurroundStereo = this.FloatToSurround3D(fPercent);
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_hSlider_SurroundImage_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMovieMode.m_r3DSurroundImage = this.FloatToSurround3D(fPercent);
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_onOffSwitch_Bass_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender)
    {
      this.m_paramMovieMode.m_bViPERBassEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_hSlider_BassSpkSize_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMovieMode.m_nViPERBassSpkSize = this.FloatToBassSpeakerSize(fPercent);
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_hSlider_BassGain_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMovieMode.m_rViPERBassFactor = this.FloatToBassGain(fPercent);
      this.Movie_label_Bass_Gain.Text = GlobalMessages.BASS_GAIN + " : " + (20.0 * Math.Log10((double) this.FloatToBassGain(fPercent) + 1.0)).ToString("F02") + "dB";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_onOffSwitch_Clarity_SwitchChangeNotify(
      bool bSwitchedOn,
      OnOffSwitch objSender)
    {
      this.m_paramMovieMode.m_bViPERClarityEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_hSlider_Clarity_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMovieMode.m_rViPERClarityFactor = this.FloatToClarity(fPercent);
      this.Movie_label_Clarity.Text = GlobalMessages.CLARITY + " : " + (20.0 * Math.Log10((double) this.FloatToClarity(fPercent) + 1.0)).ToString("F02") + "dB";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_onOffSwitch_SmartVolume_SwitchChangeNotify(
      bool bSwitchedOn,
      OnOffSwitch objSender)
    {
      this.m_paramMovieMode.m_bSmartVolumeEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_hSlider_SmartVolumeRatio_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramMovieMode.m_rSVRatio = this.FloatToSVCS(fPercent);
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_hSlider_SmartVolumeMaxLevel_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramMovieMode.m_rSVMaxGain = this.FloatToSVMaxLevel(fPercent);
      this.Movie_label_SmartVolume_MaxLevel.Text = GlobalMessages.SMART_VOLUME_MAXLEVEL + " : " + this.FloatToSVMaxLevel(fPercent).ToString("F02") + "x";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_hSlider_SmartVolumeLevel_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramMovieMode.m_rSVVolume = this.FloatToSVLevel(fPercent);
      this.Movie_label_SmartVolume_Level.Text = GlobalMessages.SMART_VOLUME_LEVEL + " : " + (20.0 * Math.Log10((double) this.FloatToSVLevel(fPercent))).ToString("F02") + "dB";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_onOffSwitch_Reverb_SwitchChangeNotify(
      bool bSwitchedOn,
      OnOffSwitch objSender)
    {
      this.m_paramMovieMode.m_bReverbEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_singleButton_ReverbPreset_ButtonClickNotify(SingleButton objSender)
    {
      frmReverbPreset frmReverbPreset = new frmReverbPreset();
      frmReverbPreset.ReverbSize = this.m_paramMovieMode.m_rReverbSize;
      frmReverbPreset.ReverbDamping = this.m_paramMovieMode.m_rReverbDamping;
      frmReverbPreset.ReverbDensity = this.m_paramMovieMode.m_rReverbDensity;
      frmReverbPreset.ReverbBandwidth = this.m_paramMovieMode.m_rReverbBandwidth;
      frmReverbPreset.ReverbDecay = this.m_paramMovieMode.m_rReverbDecay;
      frmReverbPreset.ReverbPredelay = this.m_paramMovieMode.m_rReverbPredelay;
      frmReverbPreset.ReverbEarlyMix = this.m_paramMovieMode.m_rReverbEarlyMix;
      frmReverbPreset.ReverbMix = this.m_paramMovieMode.m_rReverbMix;
      if (frmReverbPreset.ShowDialog() == DialogResult.Cancel)
        return;
      this.m_paramMovieMode.m_rReverbSize = frmReverbPreset.ReverbSize;
      this.m_paramMovieMode.m_rReverbDamping = frmReverbPreset.ReverbDamping;
      this.m_paramMovieMode.m_rReverbDensity = frmReverbPreset.ReverbDensity;
      this.m_paramMovieMode.m_rReverbBandwidth = frmReverbPreset.ReverbBandwidth;
      this.m_paramMovieMode.m_rReverbDecay = frmReverbPreset.ReverbDecay;
      this.m_paramMovieMode.m_rReverbPredelay = frmReverbPreset.ReverbPredelay;
      this.m_paramMovieMode.m_rReverbEarlyMix = frmReverbPreset.ReverbEarlyMix;
      this.m_paramMovieMode.m_rReverbMix = frmReverbPreset.ReverbMix;
      this.Movie_hSlider_ReverbSize.PositionFloat = this.m_paramMovieMode.m_rReverbSize;
      this.Movie_hSlider_ReverbDamping.PositionFloat = this.m_paramMovieMode.m_rReverbDamping;
      this.Movie_hSlider_ReverbDensity.PositionFloat = this.m_paramMovieMode.m_rReverbDensity;
      this.Movie_hSlider_ReverbBandWidth.PositionFloat = this.m_paramMovieMode.m_rReverbBandwidth;
      this.Movie_hSlider_ReverbDecay.PositionFloat = this.m_paramMovieMode.m_rReverbDecay;
      this.Movie_hSlider_ReverbPreDelay.PositionFloat = this.m_paramMovieMode.m_rReverbPredelay;
      this.Movie_hSlider_ReverbEarlyMix.PositionFloat = this.m_paramMovieMode.m_rReverbEarlyMix;
      this.Movie_hSlider_ReverbMix.PositionFloat = this.m_paramMovieMode.m_rReverbMix;
    }

    private void Movie_hSlider_ReverbSize_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMovieMode.m_rReverbSize = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_hSlider_ReverbDamping_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMovieMode.m_rReverbDamping = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_hSlider_ReverbDensity_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMovieMode.m_rReverbDensity = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_hSlider_ReverbBandWidth_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramMovieMode.m_rReverbBandwidth = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_hSlider_ReverbDecay_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMovieMode.m_rReverbDecay = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_hSlider_ReverbPreDelay_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramMovieMode.m_rReverbPredelay = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_hSlider_ReverbEarlyMix_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramMovieMode.m_rReverbEarlyMix = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_hSlider_ReverbMix_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMovieMode.m_rReverbMix = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_singleButton_Equalizer_ButtonClickNotify(SingleButton objSender)
    {
      frmEqualizer frmEqualizer = new frmEqualizer();
      frmEqualizer.SetRealtimeParameters(this.m_paramBaseSystem, this.m_paramMusicMode, this.m_paramMovieMode, this.m_paramFreestyle, this.m_cpConfigProxy);
      if (this.m_paramMovieMode.m_bEqualizerEnabled == 0)
        frmEqualizer.SetParameters(this.m_paramMovieMode.m_rpEqualizerBands, false);
      else
        frmEqualizer.SetParameters(this.m_paramMovieMode.m_rpEqualizerBands, true);
      int num = (int) frmEqualizer.ShowDialog();
      this.m_paramMovieMode.m_bEqualizerEnabled = !frmEqualizer.GetEQEnabled() ? 0 : 1;
      if (frmEqualizer.GetParameter() != null)
        this.m_paramMovieMode.m_rpEqualizerBands = frmEqualizer.GetParameter();
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Movie_singleButton_Compressor_ButtonClickNotify(SingleButton objSender)
    {
      frmCompressorLite frmCompressorLite = new frmCompressorLite();
      frmCompressorLite.CompressorEnabled = this.m_paramMovieMode.m_bCompressorEnabled != 0;
      frmCompressorLite.AutoKnee = this.m_paramMovieMode.m_bCompAutoKnee != 0;
      frmCompressorLite.AutoAttack = this.m_paramMovieMode.m_bCompAutoAttack != 0;
      frmCompressorLite.AutoRelease = this.m_paramMovieMode.m_bCompAutoRelease != 0;
      frmCompressorLite.AutoGain = this.m_paramMovieMode.m_bCompAutoGain != 0;
      frmCompressorLite.Threshold = this.m_paramMovieMode.m_rCompThreshold;
      frmCompressorLite.KneeWidth = this.m_paramMovieMode.m_rCompKneeWidth;
      frmCompressorLite.Ratio = this.m_paramMovieMode.m_rCompRatio;
      frmCompressorLite.AttackTime = this.m_paramMovieMode.m_rCompAttack;
      frmCompressorLite.ReleaseTime = this.m_paramMovieMode.m_rCompRelease;
      frmCompressorLite.MakeupGain = this.m_paramMovieMode.m_rCompGain;
      if (frmCompressorLite.ShowDialog() == DialogResult.Cancel)
        return;
      this.m_paramMovieMode.m_bCompressorEnabled = !frmCompressorLite.CompressorEnabled ? 0 : 1;
      this.m_paramMovieMode.m_bCompAutoKnee = !frmCompressorLite.AutoKnee ? 0 : 1;
      this.m_paramMovieMode.m_bCompAutoAttack = !frmCompressorLite.AutoAttack ? 0 : 1;
      this.m_paramMovieMode.m_bCompAutoRelease = !frmCompressorLite.AutoRelease ? 0 : 1;
      this.m_paramMovieMode.m_bCompAutoGain = !frmCompressorLite.AutoGain ? 0 : 1;
      this.m_paramMovieMode.m_rCompThreshold = frmCompressorLite.Threshold;
      this.m_paramMovieMode.m_rCompKneeWidth = frmCompressorLite.KneeWidth;
      this.m_paramMovieMode.m_rCompRatio = frmCompressorLite.Ratio;
      this.m_paramMovieMode.m_rCompAttack = frmCompressorLite.AttackTime;
      this.m_paramMovieMode.m_rCompRelease = frmCompressorLite.ReleaseTime;
      this.m_paramMovieMode.m_rCompGain = frmCompressorLite.MakeupGain;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMovieMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_hSlider_PreVolume_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMusicMode.m_rPreVolume = fPercent;
      this.Music_label_PreVolume.Text = GlobalMessages.PRE_VOLUME + " : " + (20.0 * Math.Log10((double) fPercent + 1E-06)).ToString("F02") + "dB";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_hSlider_PostVolume_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMusicMode.m_rPostVolume = this.FloatToPostVolume(fPercent);
      this.Music_label_PostVolume.Text = GlobalMessages.POST_VOLUME + " : " + (20.0 * Math.Log10((double) this.FloatToPostVolume(fPercent) + 1E-06)).ToString("F02") + "dB";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_onOffSwitch_Convolver_SwitchChangeNotify(
      bool bSwitchedOn,
      OnOffSwitch objSender)
    {
      this.m_paramMusicMode.m_bConvolverEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_hSlider_ConvIRGain_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMusicMode.m_rConvolverIRGain = fPercent;
      this.Music_label_ConvolverIRGain.Text = GlobalMessages.CONV_IR_GAIN + " : " + (20.0 * Math.Log10((double) fPercent + 1E-06)).ToString("F02") + "dB";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_openFileBox_ConvIRS_FileChangeNotify(
      string szFilePathName,
      OpenFileBox objSender)
    {
      this.m_paramMusicMode.m_szConvolverIR = Parameters.WriteStringToArray260(szFilePathName);
      int nChannelCount = 0;
      this.Music_irShape_ConvIR.SetImpulseResponse(RuntimeUtils.ImpulseResponseUtils.EstimateImpulseResponseSample(szFilePathName, out nChannelCount), nChannelCount);
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_onOffSwitch_Surround_SwitchChangeNotify(
      bool bSwitchedOn,
      OnOffSwitch objSender)
    {
      this.m_paramMusicMode.m_bSurroundEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_buttonBox_SurroundRoomSize_ItemSelectedNotify(
      ButtonBox.Item itPrevItem,
      ButtonBox.Item itCurrItem,
      ButtonBox objSender)
    {
      if (itCurrItem == null || itCurrItem.Tag == null || !(itCurrItem.Tag is string tag))
        return;
      int result = -1;
      if (!int.TryParse(tag, out result) || result < 0 || result > 4)
        return;
      this.m_paramMusicMode.m_nVHERoomSize = result;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_onOffSwitch_Bass_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender)
    {
      this.m_paramMusicMode.m_bViPERBassEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_hSlider_BassSpkSize_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMusicMode.m_nViPERBassSpkSize = this.FloatToBassSpeakerSize(fPercent);
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_hSlider_BassGain_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMusicMode.m_rViPERBassFactor = this.FloatToBassGain(fPercent);
      this.Music_label_Bass_Gain.Text = GlobalMessages.BASS_GAIN + " : " + (20.0 * Math.Log10((double) this.FloatToBassGain(fPercent) + 1.0)).ToString("F02") + "dB";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_onOffSwitch_Clarity_SwitchChangeNotify(
      bool bSwitchedOn,
      OnOffSwitch objSender)
    {
      this.m_paramMusicMode.m_bViPERClarityEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_buttonBox_ClarityMode_ItemSelectedNotify(
      ButtonBox.Item itPrevItem,
      ButtonBox.Item itCurrItem,
      ButtonBox objSender)
    {
      if (itCurrItem == null || itCurrItem.Tag == null || !(itCurrItem.Tag is string tag))
        return;
      int result = -1;
      if (!int.TryParse(tag, out result) || result < 0 || result > 2)
        return;
      this.m_paramMusicMode.m_nViPERClarityMode = result;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_hSlider_Clarity_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMusicMode.m_rViPERClarityFactor = this.FloatToClarity(fPercent);
      this.Music_label_Clarity.Text = GlobalMessages.CLARITY + " : " + (20.0 * Math.Log10((double) this.FloatToClarity(fPercent) + 1.0)).ToString("F02") + "dB";
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_onOffSwitch_Cure_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender)
    {
      this.m_paramMusicMode.m_bCureEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_buttonBox_CureLevel_ItemSelectedNotify(
      ButtonBox.Item itPrevItem,
      ButtonBox.Item itCurrItem,
      ButtonBox objSender)
    {
      if (itCurrItem == null || itCurrItem.Tag == null || !(itCurrItem.Tag is string tag))
        return;
      if (tag == 6226570U.ToString())
      {
        this.m_paramMusicMode.m_uiCureLevel = 6226570U;
        this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
        this.m_cpConfigProxy.SyncConfig();
      }
      else if (tag == 3932860U.ToString())
      {
        this.m_paramMusicMode.m_uiCureLevel = 3932860U;
        this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
        this.m_cpConfigProxy.SyncConfig();
      }
      else
      {
        if (!(tag == 2949820U.ToString()))
          return;
        this.m_paramMusicMode.m_uiCureLevel = 2949820U;
        this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
        this.m_cpConfigProxy.SyncConfig();
      }
    }

    private void Music_onOffSwitch_Tube_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender)
    {
      this.m_paramMusicMode.m_bTubeEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_onOffSwitch_Reverb_SwitchChangeNotify(
      bool bSwitchedOn,
      OnOffSwitch objSender)
    {
      this.m_paramMusicMode.m_bReverbEnabled = !bSwitchedOn ? 0 : 1;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_singleButton_ReverbPreset_ButtonClickNotify(SingleButton objSender)
    {
      frmReverbPreset frmReverbPreset = new frmReverbPreset();
      frmReverbPreset.ReverbSize = this.m_paramMusicMode.m_rReverbSize;
      frmReverbPreset.ReverbDamping = this.m_paramMusicMode.m_rReverbDamping;
      frmReverbPreset.ReverbDensity = this.m_paramMusicMode.m_rReverbDensity;
      frmReverbPreset.ReverbBandwidth = this.m_paramMusicMode.m_rReverbBandwidth;
      frmReverbPreset.ReverbDecay = this.m_paramMusicMode.m_rReverbDecay;
      frmReverbPreset.ReverbPredelay = this.m_paramMusicMode.m_rReverbPredelay;
      frmReverbPreset.ReverbEarlyMix = this.m_paramMusicMode.m_rReverbEarlyMix;
      frmReverbPreset.ReverbMix = this.m_paramMusicMode.m_rReverbMix;
      if (frmReverbPreset.ShowDialog() == DialogResult.Cancel)
        return;
      this.m_paramMusicMode.m_rReverbSize = frmReverbPreset.ReverbSize;
      this.m_paramMusicMode.m_rReverbDamping = frmReverbPreset.ReverbDamping;
      this.m_paramMusicMode.m_rReverbDensity = frmReverbPreset.ReverbDensity;
      this.m_paramMusicMode.m_rReverbBandwidth = frmReverbPreset.ReverbBandwidth;
      this.m_paramMusicMode.m_rReverbDecay = frmReverbPreset.ReverbDecay;
      this.m_paramMusicMode.m_rReverbPredelay = frmReverbPreset.ReverbPredelay;
      this.m_paramMusicMode.m_rReverbEarlyMix = frmReverbPreset.ReverbEarlyMix;
      this.m_paramMusicMode.m_rReverbMix = frmReverbPreset.ReverbMix;
      this.Music_hSlider_ReverbSize.PositionFloat = this.m_paramMusicMode.m_rReverbSize;
      this.Music_hSlider_ReverbDamping.PositionFloat = this.m_paramMusicMode.m_rReverbDamping;
      this.Music_hSlider_ReverbDensity.PositionFloat = this.m_paramMusicMode.m_rReverbDensity;
      this.Music_hSlider_ReverbBandWidth.PositionFloat = this.m_paramMusicMode.m_rReverbBandwidth;
      this.Music_hSlider_ReverbDecay.PositionFloat = this.m_paramMusicMode.m_rReverbDecay;
      this.Music_hSlider_ReverbPreDelay.PositionFloat = this.m_paramMusicMode.m_rReverbPredelay;
      this.Music_hSlider_ReverbEarlyMix.PositionFloat = this.m_paramMusicMode.m_rReverbEarlyMix;
      this.Music_hSlider_ReverbMix.PositionFloat = this.m_paramMusicMode.m_rReverbMix;
    }

    private void Music_hSlider_ReverbSize_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMusicMode.m_rReverbSize = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_hSlider_ReverbDamping_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMusicMode.m_rReverbDamping = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_hSlider_ReverbDensity_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMusicMode.m_rReverbDensity = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_hSlider_ReverbBandWidth_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramMusicMode.m_rReverbBandwidth = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_hSlider_ReverbDecay_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMusicMode.m_rReverbDecay = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_hSlider_ReverbPreDelay_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramMusicMode.m_rReverbPredelay = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_hSlider_ReverbEarlyMix_PositionChangeNotify(
      float fPercent,
      HSlider objSender)
    {
      this.m_paramMusicMode.m_rReverbEarlyMix = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_hSlider_ReverbMix_PositionChangeNotify(float fPercent, HSlider objSender)
    {
      this.m_paramMusicMode.m_rReverbMix = fPercent;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_singleButton_Equalizer_ButtonClickNotify(SingleButton objSender)
    {
      frmEqualizer frmEqualizer = new frmEqualizer();
      frmEqualizer.SetRealtimeParameters(this.m_paramBaseSystem, this.m_paramMusicMode, this.m_paramMovieMode, this.m_paramFreestyle, this.m_cpConfigProxy);
      if (this.m_paramMusicMode.m_bEqualizerEnabled == 0)
        frmEqualizer.SetParameters(this.m_paramMusicMode.m_rpEqualizerBands, false);
      else
        frmEqualizer.SetParameters(this.m_paramMusicMode.m_rpEqualizerBands, true);
      int num = (int) frmEqualizer.ShowDialog();
      this.m_paramMusicMode.m_bEqualizerEnabled = !frmEqualizer.GetEQEnabled() ? 0 : 1;
      if (frmEqualizer.GetParameter() != null)
        this.m_paramMusicMode.m_rpEqualizerBands = frmEqualizer.GetParameter();
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    private void Music_singleButton_Compressor_ButtonClickNotify(SingleButton objSender)
    {
      frmCompressorLite frmCompressorLite = new frmCompressorLite();
      frmCompressorLite.CompressorEnabled = this.m_paramMusicMode.m_bCompressorEnabled != 0;
      frmCompressorLite.AutoKnee = this.m_paramMusicMode.m_bCompAutoKnee != 0;
      frmCompressorLite.AutoAttack = this.m_paramMusicMode.m_bCompAutoAttack != 0;
      frmCompressorLite.AutoRelease = this.m_paramMusicMode.m_bCompAutoRelease != 0;
      frmCompressorLite.AutoGain = this.m_paramMusicMode.m_bCompAutoGain != 0;
      frmCompressorLite.Threshold = this.m_paramMusicMode.m_rCompThreshold;
      frmCompressorLite.KneeWidth = this.m_paramMusicMode.m_rCompKneeWidth;
      frmCompressorLite.Ratio = this.m_paramMusicMode.m_rCompRatio;
      frmCompressorLite.AttackTime = this.m_paramMusicMode.m_rCompAttack;
      frmCompressorLite.ReleaseTime = this.m_paramMusicMode.m_rCompRelease;
      frmCompressorLite.MakeupGain = this.m_paramMusicMode.m_rCompGain;
      if (frmCompressorLite.ShowDialog() == DialogResult.Cancel)
        return;
      this.m_paramMusicMode.m_bCompressorEnabled = !frmCompressorLite.CompressorEnabled ? 0 : 1;
      this.m_paramMusicMode.m_bCompAutoKnee = !frmCompressorLite.AutoKnee ? 0 : 1;
      this.m_paramMusicMode.m_bCompAutoAttack = !frmCompressorLite.AutoAttack ? 0 : 1;
      this.m_paramMusicMode.m_bCompAutoRelease = !frmCompressorLite.AutoRelease ? 0 : 1;
      this.m_paramMusicMode.m_bCompAutoGain = !frmCompressorLite.AutoGain ? 0 : 1;
      this.m_paramMusicMode.m_rCompThreshold = frmCompressorLite.Threshold;
      this.m_paramMusicMode.m_rCompKneeWidth = frmCompressorLite.KneeWidth;
      this.m_paramMusicMode.m_rCompRatio = frmCompressorLite.Ratio;
      this.m_paramMusicMode.m_rCompAttack = frmCompressorLite.AttackTime;
      this.m_paramMusicMode.m_rCompRelease = frmCompressorLite.ReleaseTime;
      this.m_paramMusicMode.m_rCompGain = frmCompressorLite.MakeupGain;
      this.m_cpConfigProxy.UpdateParameter(this.m_paramMusicMode);
      this.m_cpConfigProxy.SyncConfig();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmMain));
      this.pictureBox_Logo = new PictureBox();
      this.label_MasterPower = new Label();
      this.menuStrip_Main = new MenuStrip();
      this.toolStripMenuItem_Language = new ToolStripMenuItem();
      this.toolStripMenuItem_Setting = new ToolStripMenuItem();
      this.toolStripMenuItem_LatencySetting = new ToolStripMenuItem();
      this.toolStripMenuItem_ChannelPan = new ToolStripMenuItem();
      this.toolStripMenuItem_Virtualization = new ToolStripMenuItem();
      this.toolStripMenuItem_ResetEffect = new ToolStripMenuItem();
      this.toolStripMenuItem_Settings = new ToolStripMenuItem();
      this.toolStripMenuItem_Help = new ToolStripMenuItem();
      this.toolStripMenuItem_CheckUpdate = new ToolStripMenuItem();
      this.toolStripMenuItem_AboutV4W = new ToolStripMenuItem();
      this.groupBox_Main = new GroupBox();
      this.panel_Freestyle = new Panel();
      this.Freestyle_groupBox_SmartVolume = new GroupBox();
      this.Freestyle_hSlider_SmartVolumeLevel = new HSlider();
      this.Freestyle_label_SmartVolume_Level = new Label();
      this.Freestyle_hSlider_SmartVolumeMaxLevel = new HSlider();
      this.Freestyle_label_SmartVolume_MaxLevel = new Label();
      this.Freestyle_hSlider_SmartVolumeRatio = new HSlider();
      this.Freestyle_label_SmartVolume_ControlStrength = new Label();
      this.Freestyle_onOffSwitch_SmartVolume = new OnOffSwitch();
      this.Freestyle_groupBox_3DSurround = new GroupBox();
      this.Freestyle_hSlider_SurroundImage = new HSlider();
      this.Freestyle_label_Surround_Image = new Label();
      this.Freestyle_hSlider_Surround3D = new HSlider();
      this.Freestyle_label_Surround_3D = new Label();
      this.Freestyle_onOffSwitch_Surround3D = new OnOffSwitch();
      this.Freestyle_singleButton_Compressor = new SingleButton();
      this.Freestyle_singleButton_Equalizer = new SingleButton();
      this.Freestyle_groupBox_Reverb = new GroupBox();
      this.Freestyle_singleButton_ReverbPreset = new SingleButton();
      this.Freestyle_hSlider_ReverbMix = new HSlider();
      this.Freestyle_label_Reverb_Mix = new Label();
      this.Freestyle_hSlider_ReverbEarlyMix = new HSlider();
      this.Freestyle_label_Reverb_EarlyMix = new Label();
      this.Freestyle_hSlider_ReverbPreDelay = new HSlider();
      this.Freestyle_label_Reverb_PreDelay = new Label();
      this.Freestyle_hSlider_ReverbDecay = new HSlider();
      this.Freestyle_label_Reverb_Decay = new Label();
      this.Freestyle_hSlider_ReverbBandWidth = new HSlider();
      this.Freestyle_label_Reverb_BandWidth = new Label();
      this.Freestyle_hSlider_ReverbDensity = new HSlider();
      this.Freestyle_label_Reverb_Density = new Label();
      this.Freestyle_hSlider_ReverbDamping = new HSlider();
      this.Freestyle_label_Reverb_Damping = new Label();
      this.Freestyle_hSlider_ReverbSize = new HSlider();
      this.Freestyle_label_Reverb_Size = new Label();
      this.Freestyle_onOffSwitch_Reverb = new OnOffSwitch();
      this.Freestyle_groupBox_Cure = new GroupBox();
      this.Freestyle_buttonBox_CureLevel = new ButtonBox();
      this.Freestyle_onOffSwitch_Cure = new OnOffSwitch();
      this.Freestyle_label_Tube = new Label();
      this.Freestyle_onOffSwitch_Tube = new OnOffSwitch();
      this.Freestyle_groupBox_Clarity = new GroupBox();
      this.Freestyle_buttonBox_ClarityMode = new ButtonBox();
      this.Freestyle_hSlider_Clarity = new HSlider();
      this.Freestyle_label_Clarity = new Label();
      this.Freestyle_onOffSwitch_Clarity = new OnOffSwitch();
      this.Freestyle_groupBox_Bass = new GroupBox();
      this.Freestyle_buttonBox_BassMode = new ButtonBox();
      this.Freestyle_hSlider_BassGain = new HSlider();
      this.Freestyle_label_Bass_Gain = new Label();
      this.Freestyle_hSlider_BassSpkSize = new HSlider();
      this.Freestyle_label_Bass_SpkSize = new Label();
      this.Freestyle_onOffSwitch_Bass = new OnOffSwitch();
      this.Freestyle_groupBox_VHESurround = new GroupBox();
      this.Freestyle_buttonBox_SurroundVHERoomSize = new ButtonBox();
      this.Freestyle_onOffSwitch_SurroundVHE = new OnOffSwitch();
      this.Freestyle_groupBox_Convolver = new GroupBox();
      this.Freestyle_irShape_ConvIR = new IRShape();
      this.Freestyle_onOffSwitch_Convolver = new OnOffSwitch();
      this.Freestyle_hSlider_ConvIRGain = new HSlider();
      this.Freestyle_openFileBox_ConvIRS = new OpenFileBox();
      this.Freestyle_label_ConvolverIRGain = new Label();
      this.Freestyle_hSlider_PostVolume = new HSlider();
      this.Freestyle_label_PostVolume = new Label();
      this.Freestyle_hSlider_PreVolume = new HSlider();
      this.Freestyle_label_PreVolume = new Label();
      this.panel_MusicMode = new Panel();
      this.panel_MovieMode = new Panel();
      this.Movie_groupBox_SmartVolume = new GroupBox();
      this.Movie_hSlider_SmartVolumeLevel = new HSlider();
      this.Movie_label_SmartVolume_Level = new Label();
      this.Movie_hSlider_SmartVolumeMaxLevel = new HSlider();
      this.Movie_label_SmartVolume_MaxLevel = new Label();
      this.Movie_hSlider_SmartVolumeRatio = new HSlider();
      this.Movie_label_SmartVolume_ControlStrength = new Label();
      this.Movie_onOffSwitch_SmartVolume = new OnOffSwitch();
      this.Movie_singleButton_Compressor = new SingleButton();
      this.Movie_singleButton_Equalizer = new SingleButton();
      this.Movie_groupBox_Reverb = new GroupBox();
      this.Movie_singleButton_ReverbPreset = new SingleButton();
      this.Movie_hSlider_ReverbMix = new HSlider();
      this.Movie_label_Reverb_Mix = new Label();
      this.Movie_hSlider_ReverbEarlyMix = new HSlider();
      this.Movie_label_Reverb_EarlyMix = new Label();
      this.Movie_hSlider_ReverbPreDelay = new HSlider();
      this.Movie_label_Reverb_PreDelay = new Label();
      this.Movie_hSlider_ReverbDecay = new HSlider();
      this.Movie_label_Reverb_Decay = new Label();
      this.Movie_hSlider_ReverbBandWidth = new HSlider();
      this.Movie_label_Reverb_BandWidth = new Label();
      this.Movie_hSlider_ReverbDensity = new HSlider();
      this.Movie_label_Reverb_Density = new Label();
      this.Movie_hSlider_ReverbDamping = new HSlider();
      this.Movie_label_Reverb_Damping = new Label();
      this.Movie_hSlider_ReverbSize = new HSlider();
      this.Movie_label_Reverb_Size = new Label();
      this.Movie_onOffSwitch_Reverb = new OnOffSwitch();
      this.Movie_groupBox_Clarity = new GroupBox();
      this.Movie_hSlider_Clarity = new HSlider();
      this.Movie_label_Clarity = new Label();
      this.Movie_onOffSwitch_Clarity = new OnOffSwitch();
      this.Movie_groupBox_Bass = new GroupBox();
      this.Movie_hSlider_BassGain = new HSlider();
      this.Movie_label_Bass_Gain = new Label();
      this.Movie_hSlider_BassSpkSize = new HSlider();
      this.Movie_label_Bass_SpkSize = new Label();
      this.Movie_onOffSwitch_Bass = new OnOffSwitch();
      this.Movie_groupBox_Surround = new GroupBox();
      this.Movie_hSlider_SurroundImage = new HSlider();
      this.Movie_label_Surround_Image = new Label();
      this.Movie_hSlider_Surround3D = new HSlider();
      this.Movie_label_Surround_3D = new Label();
      this.Movie_onOffSwitch_Surround = new OnOffSwitch();
      this.Movie_groupBox_Convolver = new GroupBox();
      this.Movie_irShape_ConvIR = new IRShape();
      this.Movie_onOffSwitch_Convolver = new OnOffSwitch();
      this.Movie_hSlider_ConvIRGain = new HSlider();
      this.Movie_openFileBox_ConvIRS = new OpenFileBox();
      this.Movie_label_ConvolverIRGain = new Label();
      this.Movie_hSlider_PostVolume = new HSlider();
      this.Movie_label_PostVolume = new Label();
      this.Movie_hSlider_PreVolume = new HSlider();
      this.Movie_label_PreVolume = new Label();
      this.Music_singleButton_Compressor = new SingleButton();
      this.Music_singleButton_Equalizer = new SingleButton();
      this.Music_groupBox_Reverb = new GroupBox();
      this.Music_singleButton_ReverbPreset = new SingleButton();
      this.Music_hSlider_ReverbMix = new HSlider();
      this.Music_label_Reverb_Mix = new Label();
      this.Music_hSlider_ReverbEarlyMix = new HSlider();
      this.Music_label_Reverb_EarlyMix = new Label();
      this.Music_hSlider_ReverbPreDelay = new HSlider();
      this.Music_label_Reverb_PreDelay = new Label();
      this.Music_hSlider_ReverbDecay = new HSlider();
      this.Music_label_Reverb_Decay = new Label();
      this.Music_hSlider_ReverbBandWidth = new HSlider();
      this.Music_label_Reverb_BandWidth = new Label();
      this.Music_hSlider_ReverbDensity = new HSlider();
      this.Music_label_Reverb_Density = new Label();
      this.Music_hSlider_ReverbDamping = new HSlider();
      this.Music_label_Reverb_Damping = new Label();
      this.Music_hSlider_ReverbSize = new HSlider();
      this.Music_label_Reverb_Size = new Label();
      this.Music_onOffSwitch_Reverb = new OnOffSwitch();
      this.Music_groupBox_Cure = new GroupBox();
      this.Music_buttonBox_CureLevel = new ButtonBox();
      this.Music_onOffSwitch_Cure = new OnOffSwitch();
      this.Music_label_Tube = new Label();
      this.Music_onOffSwitch_Tube = new OnOffSwitch();
      this.Music_groupBox_Clarity = new GroupBox();
      this.Music_buttonBox_ClarityMode = new ButtonBox();
      this.Music_hSlider_Clarity = new HSlider();
      this.Music_label_Clarity = new Label();
      this.Music_onOffSwitch_Clarity = new OnOffSwitch();
      this.Music_groupBox_Bass = new GroupBox();
      this.Music_hSlider_BassGain = new HSlider();
      this.Music_label_Bass_Gain = new Label();
      this.Music_hSlider_BassSpkSize = new HSlider();
      this.Music_label_Bass_SpkSize = new Label();
      this.Music_onOffSwitch_Bass = new OnOffSwitch();
      this.Music_groupBox_Surround = new GroupBox();
      this.Music_buttonBox_SurroundRoomSize = new ButtonBox();
      this.Music_onOffSwitch_Surround = new OnOffSwitch();
      this.Music_groupBox_Convolver = new GroupBox();
      this.Music_irShape_ConvIR = new IRShape();
      this.Music_onOffSwitch_Convolver = new OnOffSwitch();
      this.Music_hSlider_ConvIRGain = new HSlider();
      this.Music_openFileBox_ConvIRS = new OpenFileBox();
      this.Music_label_ConvolverIRGain = new Label();
      this.Music_hSlider_PostVolume = new HSlider();
      this.Music_label_PostVolume = new Label();
      this.Music_hSlider_PreVolume = new HSlider();
      this.Music_label_PreVolume = new Label();
      this.label_Copyright = new Label();
      this.notifyIcon_Main = new NotifyIcon(this.components);
      this.contextMenuStrip_TrayMenu = new ContextMenuStrip(this.components);
      this.singleButton_SavePreset = new SingleButton();
      this.singleButton_LoadPreset = new SingleButton();
      this.buttonBox_Mode = new ButtonBox();
      this.onOffSwitch_Master = new OnOffSwitch();
      ((ISupportInitialize) this.pictureBox_Logo).BeginInit();
      this.menuStrip_Main.SuspendLayout();
      this.groupBox_Main.SuspendLayout();
      this.panel_Freestyle.SuspendLayout();
      this.Freestyle_groupBox_SmartVolume.SuspendLayout();
      this.Freestyle_groupBox_3DSurround.SuspendLayout();
      this.Freestyle_groupBox_Reverb.SuspendLayout();
      this.Freestyle_groupBox_Cure.SuspendLayout();
      this.Freestyle_groupBox_Clarity.SuspendLayout();
      this.Freestyle_groupBox_Bass.SuspendLayout();
      this.Freestyle_groupBox_VHESurround.SuspendLayout();
      this.Freestyle_groupBox_Convolver.SuspendLayout();
      this.panel_MusicMode.SuspendLayout();
      this.panel_MovieMode.SuspendLayout();
      this.Movie_groupBox_SmartVolume.SuspendLayout();
      this.Movie_groupBox_Reverb.SuspendLayout();
      this.Movie_groupBox_Clarity.SuspendLayout();
      this.Movie_groupBox_Bass.SuspendLayout();
      this.Movie_groupBox_Surround.SuspendLayout();
      this.Movie_groupBox_Convolver.SuspendLayout();
      this.Music_groupBox_Reverb.SuspendLayout();
      this.Music_groupBox_Cure.SuspendLayout();
      this.Music_groupBox_Clarity.SuspendLayout();
      this.Music_groupBox_Bass.SuspendLayout();
      this.Music_groupBox_Surround.SuspendLayout();
      this.Music_groupBox_Convolver.SuspendLayout();
      this.SuspendLayout();
      this.pictureBox_Logo.Image = (Image) Resources.Logo;
      this.pictureBox_Logo.Location = new Point(28, 69);
      this.pictureBox_Logo.Name = "pictureBox_Logo";
      this.pictureBox_Logo.Size = new Size(128, 128);
      this.pictureBox_Logo.SizeMode = PictureBoxSizeMode.AutoSize;
      this.pictureBox_Logo.TabIndex = 0;
      this.pictureBox_Logo.TabStop = false;
      this.label_MasterPower.AutoSize = true;
      this.label_MasterPower.Location = new Point(48, 246);
      this.label_MasterPower.Name = "label_MasterPower";
      this.label_MasterPower.Size = new Size(83, 12);
      this.label_MasterPower.TabIndex = 1;
      this.label_MasterPower.Text = "$MASTER_POWER";
      this.menuStrip_Main.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.toolStripMenuItem_Language,
        (ToolStripItem) this.toolStripMenuItem_Setting,
        (ToolStripItem) this.toolStripMenuItem_Help
      });
      this.menuStrip_Main.Location = new Point(0, 0);
      this.menuStrip_Main.Name = "menuStrip_Main";
      this.menuStrip_Main.Size = new Size(1042, 25);
      this.menuStrip_Main.TabIndex = 4;
      this.toolStripMenuItem_Language.Name = "toolStripMenuItem_Language";
      this.toolStripMenuItem_Language.Size = new Size(136, 21);
      this.toolStripMenuItem_Language.Text = "$MENU_LANGUAGE";
      this.toolStripMenuItem_Setting.DropDownItems.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.toolStripMenuItem_LatencySetting,
        (ToolStripItem) this.toolStripMenuItem_ChannelPan,
        (ToolStripItem) this.toolStripMenuItem_Virtualization,
        (ToolStripItem) this.toolStripMenuItem_ResetEffect,
        (ToolStripItem) this.toolStripMenuItem_Settings
      });
      this.toolStripMenuItem_Setting.Name = "toolStripMenuItem_Setting";
      this.toolStripMenuItem_Setting.Size = new Size(121, 21);
      this.toolStripMenuItem_Setting.Text = "$MENU_SETTING";
      this.toolStripMenuItem_LatencySetting.Name = "toolStripMenuItem_LatencySetting";
      this.toolStripMenuItem_LatencySetting.Size = new Size(192, 22);
      this.toolStripMenuItem_LatencySetting.Text = "$LATENCY_SETTING";
      this.toolStripMenuItem_LatencySetting.Click += new EventHandler(this.toolStripMenuItem_LatencySetting_Click);
      this.toolStripMenuItem_ChannelPan.Name = "toolStripMenuItem_ChannelPan";
      this.toolStripMenuItem_ChannelPan.Size = new Size(192, 22);
      this.toolStripMenuItem_ChannelPan.Text = "$CHANNEL_PAN";
      this.toolStripMenuItem_ChannelPan.Click += new EventHandler(this.toolStripMenuItem_ChannelPan_Click);
      this.toolStripMenuItem_Virtualization.Name = "toolStripMenuItem_Virtualization";
      this.toolStripMenuItem_Virtualization.Size = new Size(192, 22);
      this.toolStripMenuItem_Virtualization.Text = "$VIRTUALIZATION";
      this.toolStripMenuItem_Virtualization.Click += new EventHandler(this.toolStripMenuItem_Virtualization_Click);
      this.toolStripMenuItem_ResetEffect.Name = "toolStripMenuItem_ResetEffect";
      this.toolStripMenuItem_ResetEffect.Size = new Size(192, 22);
      this.toolStripMenuItem_ResetEffect.Text = "$RESET_EFFECT";
      this.toolStripMenuItem_ResetEffect.Click += new EventHandler(this.toolStripMenuItem_ResetEffect_Click);
      this.toolStripMenuItem_Settings.Name = "toolStripMenuItem_Settings";
      this.toolStripMenuItem_Settings.Size = new Size(192, 22);
      this.toolStripMenuItem_Settings.Text = "$SETTINGS";
      this.toolStripMenuItem_Settings.Click += new EventHandler(this.toolStripMenuItem_Settings_Click);
      this.toolStripMenuItem_Help.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.toolStripMenuItem_CheckUpdate,
        (ToolStripItem) this.toolStripMenuItem_AboutV4W
      });
      this.toolStripMenuItem_Help.Name = "toolStripMenuItem_Help";
      this.toolStripMenuItem_Help.Size = new Size(99, 21);
      this.toolStripMenuItem_Help.Text = "$MENU_HELP";
      this.toolStripMenuItem_CheckUpdate.Name = "toolStripMenuItem_CheckUpdate";
      this.toolStripMenuItem_CheckUpdate.Size = new Size(175, 22);
      this.toolStripMenuItem_CheckUpdate.Text = "$CHECK_UPDATE";
      this.toolStripMenuItem_CheckUpdate.Click += new EventHandler(this.toolStripMenuItem_CheckUpdate_Click);
      this.toolStripMenuItem_AboutV4W.Name = "toolStripMenuItem_AboutV4W";
      this.toolStripMenuItem_AboutV4W.Size = new Size(175, 22);
      this.toolStripMenuItem_AboutV4W.Text = "$ABOUT";
      this.toolStripMenuItem_AboutV4W.Click += new EventHandler(this.toolStripMenuItem_AboutV4W_Click);
      this.groupBox_Main.Controls.Add((Control) this.panel_Freestyle);
      this.groupBox_Main.Controls.Add((Control) this.panel_MusicMode);
      this.groupBox_Main.Location = new Point(186, 28);
      this.groupBox_Main.Name = "groupBox_Main";
      this.groupBox_Main.Size = new Size(841, 572);
      this.groupBox_Main.TabIndex = 5;
      this.groupBox_Main.TabStop = false;
      this.panel_Freestyle.Controls.Add((Control) this.Freestyle_groupBox_SmartVolume);
      this.panel_Freestyle.Controls.Add((Control) this.Freestyle_groupBox_3DSurround);
      this.panel_Freestyle.Controls.Add((Control) this.Freestyle_singleButton_Compressor);
      this.panel_Freestyle.Controls.Add((Control) this.Freestyle_singleButton_Equalizer);
      this.panel_Freestyle.Controls.Add((Control) this.Freestyle_groupBox_Reverb);
      this.panel_Freestyle.Controls.Add((Control) this.Freestyle_groupBox_Cure);
      this.panel_Freestyle.Controls.Add((Control) this.Freestyle_groupBox_Clarity);
      this.panel_Freestyle.Controls.Add((Control) this.Freestyle_groupBox_Bass);
      this.panel_Freestyle.Controls.Add((Control) this.Freestyle_groupBox_VHESurround);
      this.panel_Freestyle.Controls.Add((Control) this.Freestyle_groupBox_Convolver);
      this.panel_Freestyle.Controls.Add((Control) this.Freestyle_hSlider_PostVolume);
      this.panel_Freestyle.Controls.Add((Control) this.Freestyle_label_PostVolume);
      this.panel_Freestyle.Controls.Add((Control) this.Freestyle_hSlider_PreVolume);
      this.panel_Freestyle.Controls.Add((Control) this.Freestyle_label_PreVolume);
      this.panel_Freestyle.Dock = DockStyle.Fill;
      this.panel_Freestyle.Location = new Point(3, 17);
      this.panel_Freestyle.Name = "panel_Freestyle";
      this.panel_Freestyle.Size = new Size(835, 552);
      this.panel_Freestyle.TabIndex = 10;
      this.Freestyle_groupBox_SmartVolume.Controls.Add((Control) this.Freestyle_hSlider_SmartVolumeLevel);
      this.Freestyle_groupBox_SmartVolume.Controls.Add((Control) this.Freestyle_label_SmartVolume_Level);
      this.Freestyle_groupBox_SmartVolume.Controls.Add((Control) this.Freestyle_hSlider_SmartVolumeMaxLevel);
      this.Freestyle_groupBox_SmartVolume.Controls.Add((Control) this.Freestyle_label_SmartVolume_MaxLevel);
      this.Freestyle_groupBox_SmartVolume.Controls.Add((Control) this.Freestyle_hSlider_SmartVolumeRatio);
      this.Freestyle_groupBox_SmartVolume.Controls.Add((Control) this.Freestyle_label_SmartVolume_ControlStrength);
      this.Freestyle_groupBox_SmartVolume.Controls.Add((Control) this.Freestyle_onOffSwitch_SmartVolume);
      this.Freestyle_groupBox_SmartVolume.Location = new Point(216, 391);
      this.Freestyle_groupBox_SmartVolume.Name = "Freestyle_groupBox_SmartVolume";
      this.Freestyle_groupBox_SmartVolume.Size = new Size(384, 148);
      this.Freestyle_groupBox_SmartVolume.TabIndex = 23;
      this.Freestyle_groupBox_SmartVolume.TabStop = false;
      this.Freestyle_groupBox_SmartVolume.Text = "$SMART_VOLUME";
      this.Freestyle_hSlider_SmartVolumeLevel.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_SmartVolumeLevel.Location = new Point(195, 85);
      this.Freestyle_hSlider_SmartVolumeLevel.MoveDelta = 1U;
      this.Freestyle_hSlider_SmartVolumeLevel.Name = "Freestyle_hSlider_SmartVolumeLevel";
      this.Freestyle_hSlider_SmartVolumeLevel.Position = 0U;
      this.Freestyle_hSlider_SmartVolumeLevel.PositionFloat = 0.0f;
      this.Freestyle_hSlider_SmartVolumeLevel.Size = new Size(174, 39);
      this.Freestyle_hSlider_SmartVolumeLevel.TabIndex = 23;
      this.Freestyle_hSlider_SmartVolumeLevel.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_SmartVolumeLevel_PositionChangeNotify);
      this.Freestyle_label_SmartVolume_Level.AutoSize = true;
      this.Freestyle_label_SmartVolume_Level.Location = new Point(214, 67);
      this.Freestyle_label_SmartVolume_Level.Name = "Freestyle_label_SmartVolume_Level";
      this.Freestyle_label_SmartVolume_Level.Size = new Size(155, 12);
      this.Freestyle_label_SmartVolume_Level.TabIndex = 22;
      this.Freestyle_label_SmartVolume_Level.Text = "$SMART_VOLUME_LEVEL : 0dB";
      this.Freestyle_hSlider_SmartVolumeMaxLevel.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_SmartVolumeMaxLevel.Location = new Point(9, 115);
      this.Freestyle_hSlider_SmartVolumeMaxLevel.MoveDelta = 1U;
      this.Freestyle_hSlider_SmartVolumeMaxLevel.Name = "Freestyle_hSlider_SmartVolumeMaxLevel";
      this.Freestyle_hSlider_SmartVolumeMaxLevel.Position = 0U;
      this.Freestyle_hSlider_SmartVolumeMaxLevel.PositionFloat = 0.0f;
      this.Freestyle_hSlider_SmartVolumeMaxLevel.Size = new Size(161, 24);
      this.Freestyle_hSlider_SmartVolumeMaxLevel.TabIndex = 21;
      this.Freestyle_hSlider_SmartVolumeMaxLevel.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_SmartVolumeMaxLevel_PositionChangeNotify);
      this.Freestyle_label_SmartVolume_MaxLevel.AutoSize = true;
      this.Freestyle_label_SmartVolume_MaxLevel.Location = new Point(19, 100);
      this.Freestyle_label_SmartVolume_MaxLevel.Name = "Freestyle_label_SmartVolume_MaxLevel";
      this.Freestyle_label_SmartVolume_MaxLevel.Size = new Size(167, 12);
      this.Freestyle_label_SmartVolume_MaxLevel.TabIndex = 20;
      this.Freestyle_label_SmartVolume_MaxLevel.Text = "$SMART_VOLUME_MAXLEVEL : 1x";
      this.Freestyle_hSlider_SmartVolumeRatio.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_SmartVolumeRatio.Location = new Point(9, 73);
      this.Freestyle_hSlider_SmartVolumeRatio.MoveDelta = 1U;
      this.Freestyle_hSlider_SmartVolumeRatio.Name = "Freestyle_hSlider_SmartVolumeRatio";
      this.Freestyle_hSlider_SmartVolumeRatio.Position = 0U;
      this.Freestyle_hSlider_SmartVolumeRatio.PositionFloat = 0.0f;
      this.Freestyle_hSlider_SmartVolumeRatio.Size = new Size(161, 24);
      this.Freestyle_hSlider_SmartVolumeRatio.TabIndex = 19;
      this.Freestyle_hSlider_SmartVolumeRatio.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_SmartVolumeRatio_PositionChangeNotify);
      this.Freestyle_label_SmartVolume_ControlStrength.AutoSize = true;
      this.Freestyle_label_SmartVolume_ControlStrength.Location = new Point(19, 58);
      this.Freestyle_label_SmartVolume_ControlStrength.Name = "Freestyle_label_SmartVolume_ControlStrength";
      this.Freestyle_label_SmartVolume_ControlStrength.Size = new Size(185, 12);
      this.Freestyle_label_SmartVolume_ControlStrength.TabIndex = 18;
      this.Freestyle_label_SmartVolume_ControlStrength.Text = "$SMART_VOLUME_CONTROL_STRENGTH";
      this.Freestyle_onOffSwitch_SmartVolume.BackColor = Color.Transparent;
      this.Freestyle_onOffSwitch_SmartVolume.Location = new Point(13, 23);
      this.Freestyle_onOffSwitch_SmartVolume.Name = "Freestyle_onOffSwitch_SmartVolume";
      this.Freestyle_onOffSwitch_SmartVolume.Size = new Size(49, 20);
      this.Freestyle_onOffSwitch_SmartVolume.SwitchedOn = false;
      this.Freestyle_onOffSwitch_SmartVolume.TabIndex = 17;
      this.Freestyle_onOffSwitch_SmartVolume.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Freestyle_onOffSwitch_SmartVolume_SwitchChangeNotify);
      this.Freestyle_groupBox_3DSurround.Controls.Add((Control) this.Freestyle_hSlider_SurroundImage);
      this.Freestyle_groupBox_3DSurround.Controls.Add((Control) this.Freestyle_label_Surround_Image);
      this.Freestyle_groupBox_3DSurround.Controls.Add((Control) this.Freestyle_hSlider_Surround3D);
      this.Freestyle_groupBox_3DSurround.Controls.Add((Control) this.Freestyle_label_Surround_3D);
      this.Freestyle_groupBox_3DSurround.Controls.Add((Control) this.Freestyle_onOffSwitch_Surround3D);
      this.Freestyle_groupBox_3DSurround.Location = new Point(476, 6);
      this.Freestyle_groupBox_3DSurround.Name = "Freestyle_groupBox_3DSurround";
      this.Freestyle_groupBox_3DSurround.Size = new Size(121, 179);
      this.Freestyle_groupBox_3DSurround.TabIndex = 22;
      this.Freestyle_groupBox_3DSurround.TabStop = false;
      this.Freestyle_groupBox_3DSurround.Text = "$3D_SURROUND";
      this.Freestyle_hSlider_SurroundImage.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_SurroundImage.Location = new Point(6, 126);
      this.Freestyle_hSlider_SurroundImage.MoveDelta = 1U;
      this.Freestyle_hSlider_SurroundImage.Name = "Freestyle_hSlider_SurroundImage";
      this.Freestyle_hSlider_SurroundImage.Position = 0U;
      this.Freestyle_hSlider_SurroundImage.PositionFloat = 0.0f;
      this.Freestyle_hSlider_SurroundImage.Size = new Size(110, 24);
      this.Freestyle_hSlider_SurroundImage.TabIndex = 25;
      this.Freestyle_hSlider_SurroundImage.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_SurroundImage_PositionChangeNotify);
      this.Freestyle_label_Surround_Image.AutoSize = true;
      this.Freestyle_label_Surround_Image.Location = new Point(16, 111);
      this.Freestyle_label_Surround_Image.Name = "Freestyle_label_Surround_Image";
      this.Freestyle_label_Surround_Image.Size = new Size(95, 12);
      this.Freestyle_label_Surround_Image.TabIndex = 24;
      this.Freestyle_label_Surround_Image.Text = "$SURROUND_IMAGE";
      this.Freestyle_hSlider_Surround3D.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_Surround3D.Location = new Point(6, 84);
      this.Freestyle_hSlider_Surround3D.MoveDelta = 1U;
      this.Freestyle_hSlider_Surround3D.Name = "Freestyle_hSlider_Surround3D";
      this.Freestyle_hSlider_Surround3D.Position = 0U;
      this.Freestyle_hSlider_Surround3D.PositionFloat = 0.0f;
      this.Freestyle_hSlider_Surround3D.Size = new Size(110, 24);
      this.Freestyle_hSlider_Surround3D.TabIndex = 23;
      this.Freestyle_hSlider_Surround3D.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_Surround3D_PositionChangeNotify);
      this.Freestyle_label_Surround_3D.AutoSize = true;
      this.Freestyle_label_Surround_3D.Location = new Point(16, 69);
      this.Freestyle_label_Surround_3D.Name = "Freestyle_label_Surround_3D";
      this.Freestyle_label_Surround_3D.Size = new Size(77, 12);
      this.Freestyle_label_Surround_3D.TabIndex = 22;
      this.Freestyle_label_Surround_3D.Text = "$SURROUND_3D";
      this.Freestyle_onOffSwitch_Surround3D.BackColor = Color.Transparent;
      this.Freestyle_onOffSwitch_Surround3D.Location = new Point(13, 23);
      this.Freestyle_onOffSwitch_Surround3D.Name = "Freestyle_onOffSwitch_Surround3D";
      this.Freestyle_onOffSwitch_Surround3D.Size = new Size(49, 20);
      this.Freestyle_onOffSwitch_Surround3D.SwitchedOn = false;
      this.Freestyle_onOffSwitch_Surround3D.TabIndex = 6;
      this.Freestyle_onOffSwitch_Surround3D.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Freestyle_onOffSwitch_Surround3D_SwitchChangeNotify);
      this.Freestyle_singleButton_Compressor.BackColor = SystemColors.Control;
      this.Freestyle_singleButton_Compressor.ButtonText = "$COMPRESSOR_ADJUST";
      this.Freestyle_singleButton_Compressor.Location = new Point(30, 500);
      this.Freestyle_singleButton_Compressor.Name = "Freestyle_singleButton_Compressor";
      this.Freestyle_singleButton_Compressor.Size = new Size(174, 39);
      this.Freestyle_singleButton_Compressor.TabIndex = 21;
      this.Freestyle_singleButton_Compressor.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.Freestyle_singleButton_Compressor_ButtonClickNotify);
      this.Freestyle_singleButton_Equalizer.BackColor = SystemColors.Control;
      this.Freestyle_singleButton_Equalizer.ButtonText = "$EQUALIZER_ADJUST";
      this.Freestyle_singleButton_Equalizer.Location = new Point(30, 455);
      this.Freestyle_singleButton_Equalizer.Name = "Freestyle_singleButton_Equalizer";
      this.Freestyle_singleButton_Equalizer.Size = new Size(174, 39);
      this.Freestyle_singleButton_Equalizer.TabIndex = 20;
      this.Freestyle_singleButton_Equalizer.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.Freestyle_singleButton_Equalizer_ButtonClickNotify);
      this.Freestyle_groupBox_Reverb.Controls.Add((Control) this.Freestyle_singleButton_ReverbPreset);
      this.Freestyle_groupBox_Reverb.Controls.Add((Control) this.Freestyle_hSlider_ReverbMix);
      this.Freestyle_groupBox_Reverb.Controls.Add((Control) this.Freestyle_label_Reverb_Mix);
      this.Freestyle_groupBox_Reverb.Controls.Add((Control) this.Freestyle_hSlider_ReverbEarlyMix);
      this.Freestyle_groupBox_Reverb.Controls.Add((Control) this.Freestyle_label_Reverb_EarlyMix);
      this.Freestyle_groupBox_Reverb.Controls.Add((Control) this.Freestyle_hSlider_ReverbPreDelay);
      this.Freestyle_groupBox_Reverb.Controls.Add((Control) this.Freestyle_label_Reverb_PreDelay);
      this.Freestyle_groupBox_Reverb.Controls.Add((Control) this.Freestyle_hSlider_ReverbDecay);
      this.Freestyle_groupBox_Reverb.Controls.Add((Control) this.Freestyle_label_Reverb_Decay);
      this.Freestyle_groupBox_Reverb.Controls.Add((Control) this.Freestyle_hSlider_ReverbBandWidth);
      this.Freestyle_groupBox_Reverb.Controls.Add((Control) this.Freestyle_label_Reverb_BandWidth);
      this.Freestyle_groupBox_Reverb.Controls.Add((Control) this.Freestyle_hSlider_ReverbDensity);
      this.Freestyle_groupBox_Reverb.Controls.Add((Control) this.Freestyle_label_Reverb_Density);
      this.Freestyle_groupBox_Reverb.Controls.Add((Control) this.Freestyle_hSlider_ReverbDamping);
      this.Freestyle_groupBox_Reverb.Controls.Add((Control) this.Freestyle_label_Reverb_Damping);
      this.Freestyle_groupBox_Reverb.Controls.Add((Control) this.Freestyle_hSlider_ReverbSize);
      this.Freestyle_groupBox_Reverb.Controls.Add((Control) this.Freestyle_label_Reverb_Size);
      this.Freestyle_groupBox_Reverb.Controls.Add((Control) this.Freestyle_onOffSwitch_Reverb);
      this.Freestyle_groupBox_Reverb.Location = new Point(606, 150);
      this.Freestyle_groupBox_Reverb.Name = "Freestyle_groupBox_Reverb";
      this.Freestyle_groupBox_Reverb.Size = new Size(208, 389);
      this.Freestyle_groupBox_Reverb.TabIndex = 19;
      this.Freestyle_groupBox_Reverb.TabStop = false;
      this.Freestyle_groupBox_Reverb.Text = "$REVERB";
      this.Freestyle_singleButton_ReverbPreset.BackColor = SystemColors.Control;
      this.Freestyle_singleButton_ReverbPreset.ButtonText = "$PRESET";
      this.Freestyle_singleButton_ReverbPreset.Location = new Point(121, 14);
      this.Freestyle_singleButton_ReverbPreset.Name = "Freestyle_singleButton_ReverbPreset";
      this.Freestyle_singleButton_ReverbPreset.Size = new Size(81, 29);
      this.Freestyle_singleButton_ReverbPreset.TabIndex = 36;
      this.Freestyle_singleButton_ReverbPreset.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.Freestyle_singleButton_ReverbPreset_ButtonClickNotify);
      this.Freestyle_hSlider_ReverbMix.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_ReverbMix.Location = new Point(24, 356);
      this.Freestyle_hSlider_ReverbMix.MoveDelta = 1U;
      this.Freestyle_hSlider_ReverbMix.Name = "Freestyle_hSlider_ReverbMix";
      this.Freestyle_hSlider_ReverbMix.Position = 0U;
      this.Freestyle_hSlider_ReverbMix.PositionFloat = 0.0f;
      this.Freestyle_hSlider_ReverbMix.Size = new Size(161, 24);
      this.Freestyle_hSlider_ReverbMix.TabIndex = 35;
      this.Freestyle_hSlider_ReverbMix.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_ReverbMix_PositionChangeNotify);
      this.Freestyle_label_Reverb_Mix.AutoSize = true;
      this.Freestyle_label_Reverb_Mix.Location = new Point(34, 341);
      this.Freestyle_label_Reverb_Mix.Name = "Freestyle_label_Reverb_Mix";
      this.Freestyle_label_Reverb_Mix.Size = new Size(71, 12);
      this.Freestyle_label_Reverb_Mix.TabIndex = 34;
      this.Freestyle_label_Reverb_Mix.Text = "$REVERB_MIX";
      this.Freestyle_hSlider_ReverbEarlyMix.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_ReverbEarlyMix.Location = new Point(24, 314);
      this.Freestyle_hSlider_ReverbEarlyMix.MoveDelta = 1U;
      this.Freestyle_hSlider_ReverbEarlyMix.Name = "Freestyle_hSlider_ReverbEarlyMix";
      this.Freestyle_hSlider_ReverbEarlyMix.Position = 0U;
      this.Freestyle_hSlider_ReverbEarlyMix.PositionFloat = 0.0f;
      this.Freestyle_hSlider_ReverbEarlyMix.Size = new Size(161, 24);
      this.Freestyle_hSlider_ReverbEarlyMix.TabIndex = 33;
      this.Freestyle_hSlider_ReverbEarlyMix.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_ReverbEarlyMix_PositionChangeNotify);
      this.Freestyle_label_Reverb_EarlyMix.AutoSize = true;
      this.Freestyle_label_Reverb_EarlyMix.Location = new Point(34, 299);
      this.Freestyle_label_Reverb_EarlyMix.Name = "Freestyle_label_Reverb_EarlyMix";
      this.Freestyle_label_Reverb_EarlyMix.Size = new Size(101, 12);
      this.Freestyle_label_Reverb_EarlyMix.TabIndex = 32;
      this.Freestyle_label_Reverb_EarlyMix.Text = "$REVERB_EARLYMIX";
      this.Freestyle_hSlider_ReverbPreDelay.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_ReverbPreDelay.Location = new Point(24, 272);
      this.Freestyle_hSlider_ReverbPreDelay.MoveDelta = 1U;
      this.Freestyle_hSlider_ReverbPreDelay.Name = "Freestyle_hSlider_ReverbPreDelay";
      this.Freestyle_hSlider_ReverbPreDelay.Position = 0U;
      this.Freestyle_hSlider_ReverbPreDelay.PositionFloat = 0.0f;
      this.Freestyle_hSlider_ReverbPreDelay.Size = new Size(161, 24);
      this.Freestyle_hSlider_ReverbPreDelay.TabIndex = 31;
      this.Freestyle_hSlider_ReverbPreDelay.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_ReverbPreDelay_PositionChangeNotify);
      this.Freestyle_label_Reverb_PreDelay.AutoSize = true;
      this.Freestyle_label_Reverb_PreDelay.Location = new Point(34, 257);
      this.Freestyle_label_Reverb_PreDelay.Name = "Freestyle_label_Reverb_PreDelay";
      this.Freestyle_label_Reverb_PreDelay.Size = new Size(101, 12);
      this.Freestyle_label_Reverb_PreDelay.TabIndex = 30;
      this.Freestyle_label_Reverb_PreDelay.Text = "$REVERB_PREDELAY";
      this.Freestyle_hSlider_ReverbDecay.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_ReverbDecay.Location = new Point(24, 230);
      this.Freestyle_hSlider_ReverbDecay.MoveDelta = 1U;
      this.Freestyle_hSlider_ReverbDecay.Name = "Freestyle_hSlider_ReverbDecay";
      this.Freestyle_hSlider_ReverbDecay.Position = 0U;
      this.Freestyle_hSlider_ReverbDecay.PositionFloat = 0.0f;
      this.Freestyle_hSlider_ReverbDecay.Size = new Size(161, 24);
      this.Freestyle_hSlider_ReverbDecay.TabIndex = 29;
      this.Freestyle_hSlider_ReverbDecay.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_ReverbDecay_PositionChangeNotify);
      this.Freestyle_label_Reverb_Decay.AutoSize = true;
      this.Freestyle_label_Reverb_Decay.Location = new Point(34, 215);
      this.Freestyle_label_Reverb_Decay.Name = "Freestyle_label_Reverb_Decay";
      this.Freestyle_label_Reverb_Decay.Size = new Size(83, 12);
      this.Freestyle_label_Reverb_Decay.TabIndex = 28;
      this.Freestyle_label_Reverb_Decay.Text = "$REVERB_DECAY";
      this.Freestyle_hSlider_ReverbBandWidth.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_ReverbBandWidth.Location = new Point(24, 188);
      this.Freestyle_hSlider_ReverbBandWidth.MoveDelta = 1U;
      this.Freestyle_hSlider_ReverbBandWidth.Name = "Freestyle_hSlider_ReverbBandWidth";
      this.Freestyle_hSlider_ReverbBandWidth.Position = 0U;
      this.Freestyle_hSlider_ReverbBandWidth.PositionFloat = 0.0f;
      this.Freestyle_hSlider_ReverbBandWidth.Size = new Size(161, 24);
      this.Freestyle_hSlider_ReverbBandWidth.TabIndex = 27;
      this.Freestyle_hSlider_ReverbBandWidth.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_ReverbBandWidth_PositionChangeNotify);
      this.Freestyle_label_Reverb_BandWidth.AutoSize = true;
      this.Freestyle_label_Reverb_BandWidth.Location = new Point(34, 173);
      this.Freestyle_label_Reverb_BandWidth.Name = "Freestyle_label_Reverb_BandWidth";
      this.Freestyle_label_Reverb_BandWidth.Size = new Size(107, 12);
      this.Freestyle_label_Reverb_BandWidth.TabIndex = 26;
      this.Freestyle_label_Reverb_BandWidth.Text = "$REVERB_BANDWIDTH";
      this.Freestyle_hSlider_ReverbDensity.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_ReverbDensity.Location = new Point(24, 146);
      this.Freestyle_hSlider_ReverbDensity.MoveDelta = 1U;
      this.Freestyle_hSlider_ReverbDensity.Name = "Freestyle_hSlider_ReverbDensity";
      this.Freestyle_hSlider_ReverbDensity.Position = 0U;
      this.Freestyle_hSlider_ReverbDensity.PositionFloat = 0.0f;
      this.Freestyle_hSlider_ReverbDensity.Size = new Size(161, 24);
      this.Freestyle_hSlider_ReverbDensity.TabIndex = 25;
      this.Freestyle_hSlider_ReverbDensity.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_ReverbDensity_PositionChangeNotify);
      this.Freestyle_label_Reverb_Density.AutoSize = true;
      this.Freestyle_label_Reverb_Density.Location = new Point(34, 131);
      this.Freestyle_label_Reverb_Density.Name = "Freestyle_label_Reverb_Density";
      this.Freestyle_label_Reverb_Density.Size = new Size(95, 12);
      this.Freestyle_label_Reverb_Density.TabIndex = 24;
      this.Freestyle_label_Reverb_Density.Text = "$REVERB_DENSITY";
      this.Freestyle_hSlider_ReverbDamping.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_ReverbDamping.Location = new Point(24, 104);
      this.Freestyle_hSlider_ReverbDamping.MoveDelta = 1U;
      this.Freestyle_hSlider_ReverbDamping.Name = "Freestyle_hSlider_ReverbDamping";
      this.Freestyle_hSlider_ReverbDamping.Position = 0U;
      this.Freestyle_hSlider_ReverbDamping.PositionFloat = 0.0f;
      this.Freestyle_hSlider_ReverbDamping.Size = new Size(161, 24);
      this.Freestyle_hSlider_ReverbDamping.TabIndex = 23;
      this.Freestyle_hSlider_ReverbDamping.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_ReverbDamping_PositionChangeNotify);
      this.Freestyle_label_Reverb_Damping.AutoSize = true;
      this.Freestyle_label_Reverb_Damping.Location = new Point(34, 89);
      this.Freestyle_label_Reverb_Damping.Name = "Freestyle_label_Reverb_Damping";
      this.Freestyle_label_Reverb_Damping.Size = new Size(95, 12);
      this.Freestyle_label_Reverb_Damping.TabIndex = 22;
      this.Freestyle_label_Reverb_Damping.Text = "$REVERB_DAMPING";
      this.Freestyle_hSlider_ReverbSize.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_ReverbSize.Location = new Point(24, 64);
      this.Freestyle_hSlider_ReverbSize.MoveDelta = 1U;
      this.Freestyle_hSlider_ReverbSize.Name = "Freestyle_hSlider_ReverbSize";
      this.Freestyle_hSlider_ReverbSize.Position = 0U;
      this.Freestyle_hSlider_ReverbSize.PositionFloat = 0.0f;
      this.Freestyle_hSlider_ReverbSize.Size = new Size(161, 24);
      this.Freestyle_hSlider_ReverbSize.TabIndex = 21;
      this.Freestyle_hSlider_ReverbSize.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_ReverbSize_PositionChangeNotify);
      this.Freestyle_label_Reverb_Size.AutoSize = true;
      this.Freestyle_label_Reverb_Size.Location = new Point(34, 49);
      this.Freestyle_label_Reverb_Size.Name = "Freestyle_label_Reverb_Size";
      this.Freestyle_label_Reverb_Size.Size = new Size(77, 12);
      this.Freestyle_label_Reverb_Size.TabIndex = 20;
      this.Freestyle_label_Reverb_Size.Text = "$REVERB_SIZE";
      this.Freestyle_onOffSwitch_Reverb.BackColor = Color.Transparent;
      this.Freestyle_onOffSwitch_Reverb.Location = new Point(13, 23);
      this.Freestyle_onOffSwitch_Reverb.Name = "Freestyle_onOffSwitch_Reverb";
      this.Freestyle_onOffSwitch_Reverb.Size = new Size(49, 20);
      this.Freestyle_onOffSwitch_Reverb.SwitchedOn = false;
      this.Freestyle_onOffSwitch_Reverb.TabIndex = 7;
      this.Freestyle_onOffSwitch_Reverb.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Freestyle_onOffSwitch_Reverb_SwitchChangeNotify);
      this.Freestyle_groupBox_Cure.Controls.Add((Control) this.Freestyle_buttonBox_CureLevel);
      this.Freestyle_groupBox_Cure.Controls.Add((Control) this.Freestyle_onOffSwitch_Cure);
      this.Freestyle_groupBox_Cure.Controls.Add((Control) this.Freestyle_label_Tube);
      this.Freestyle_groupBox_Cure.Controls.Add((Control) this.Freestyle_onOffSwitch_Tube);
      this.Freestyle_groupBox_Cure.Location = new Point(411, 214);
      this.Freestyle_groupBox_Cure.Name = "Freestyle_groupBox_Cure";
      this.Freestyle_groupBox_Cure.Size = new Size(189, 148);
      this.Freestyle_groupBox_Cure.TabIndex = 18;
      this.Freestyle_groupBox_Cure.TabStop = false;
      this.Freestyle_groupBox_Cure.Text = "$CURE";
      this.Freestyle_buttonBox_CureLevel.BackColor = SystemColors.Control;
      this.Freestyle_buttonBox_CureLevel.Location = new Point(68, 17);
      this.Freestyle_buttonBox_CureLevel.Name = "Freestyle_buttonBox_CureLevel";
      this.Freestyle_buttonBox_CureLevel.Size = new Size(106, 70);
      this.Freestyle_buttonBox_CureLevel.TabIndex = 18;
      this.Freestyle_buttonBox_CureLevel.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(this.Freestyle_buttonBox_CureLevel_ItemSelectedNotify);
      this.Freestyle_onOffSwitch_Cure.BackColor = Color.Transparent;
      this.Freestyle_onOffSwitch_Cure.Location = new Point(13, 23);
      this.Freestyle_onOffSwitch_Cure.Name = "Freestyle_onOffSwitch_Cure";
      this.Freestyle_onOffSwitch_Cure.Size = new Size(49, 20);
      this.Freestyle_onOffSwitch_Cure.SwitchedOn = false;
      this.Freestyle_onOffSwitch_Cure.TabIndex = 17;
      this.Freestyle_onOffSwitch_Cure.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Freestyle_onOffSwitch_Cure_SwitchChangeNotify);
      this.Freestyle_label_Tube.AutoSize = true;
      this.Freestyle_label_Tube.Location = new Point(11, 113);
      this.Freestyle_label_Tube.Name = "Freestyle_label_Tube";
      this.Freestyle_label_Tube.Size = new Size(35, 12);
      this.Freestyle_label_Tube.TabIndex = 14;
      this.Freestyle_label_Tube.Text = "$TUBE";
      this.Freestyle_onOffSwitch_Tube.BackColor = Color.Transparent;
      this.Freestyle_onOffSwitch_Tube.Location = new Point(121, 105);
      this.Freestyle_onOffSwitch_Tube.Name = "Freestyle_onOffSwitch_Tube";
      this.Freestyle_onOffSwitch_Tube.Size = new Size(53, 26);
      this.Freestyle_onOffSwitch_Tube.SwitchedOn = false;
      this.Freestyle_onOffSwitch_Tube.TabIndex = 15;
      this.Freestyle_onOffSwitch_Tube.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Freestyle_onOffSwitch_Tube_SwitchChangeNotify);
      this.Freestyle_groupBox_Clarity.Controls.Add((Control) this.Freestyle_buttonBox_ClarityMode);
      this.Freestyle_groupBox_Clarity.Controls.Add((Control) this.Freestyle_hSlider_Clarity);
      this.Freestyle_groupBox_Clarity.Controls.Add((Control) this.Freestyle_label_Clarity);
      this.Freestyle_groupBox_Clarity.Controls.Add((Control) this.Freestyle_onOffSwitch_Clarity);
      this.Freestyle_groupBox_Clarity.Location = new Point(216, 214);
      this.Freestyle_groupBox_Clarity.Name = "Freestyle_groupBox_Clarity";
      this.Freestyle_groupBox_Clarity.Size = new Size(189, 148);
      this.Freestyle_groupBox_Clarity.TabIndex = 17;
      this.Freestyle_groupBox_Clarity.TabStop = false;
      this.Freestyle_groupBox_Clarity.Text = "$CLARITY";
      this.Freestyle_buttonBox_ClarityMode.BackColor = SystemColors.Control;
      this.Freestyle_buttonBox_ClarityMode.Location = new Point(68, 17);
      this.Freestyle_buttonBox_ClarityMode.Name = "Freestyle_buttonBox_ClarityMode";
      this.Freestyle_buttonBox_ClarityMode.Size = new Size(106, 70);
      this.Freestyle_buttonBox_ClarityMode.TabIndex = 18;
      this.Freestyle_buttonBox_ClarityMode.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(this.Freestyle_buttonBox_ClarityMode_ItemSelectedNotify);
      this.Freestyle_hSlider_Clarity.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_Clarity.Location = new Point(13, 115);
      this.Freestyle_hSlider_Clarity.MoveDelta = 1U;
      this.Freestyle_hSlider_Clarity.Name = "Freestyle_hSlider_Clarity";
      this.Freestyle_hSlider_Clarity.Position = 0U;
      this.Freestyle_hSlider_Clarity.PositionFloat = 0.0f;
      this.Freestyle_hSlider_Clarity.Size = new Size(161, 24);
      this.Freestyle_hSlider_Clarity.TabIndex = 21;
      this.Freestyle_hSlider_Clarity.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_Clarity_PositionChangeNotify);
      this.Freestyle_label_Clarity.AutoSize = true;
      this.Freestyle_label_Clarity.Location = new Point(23, 100);
      this.Freestyle_label_Clarity.Name = "Freestyle_label_Clarity";
      this.Freestyle_label_Clarity.Size = new Size(89, 12);
      this.Freestyle_label_Clarity.TabIndex = 20;
      this.Freestyle_label_Clarity.Text = "$CLARITY : 0dB";
      this.Freestyle_onOffSwitch_Clarity.BackColor = Color.Transparent;
      this.Freestyle_onOffSwitch_Clarity.Location = new Point(13, 23);
      this.Freestyle_onOffSwitch_Clarity.Name = "Freestyle_onOffSwitch_Clarity";
      this.Freestyle_onOffSwitch_Clarity.Size = new Size(49, 20);
      this.Freestyle_onOffSwitch_Clarity.SwitchedOn = false;
      this.Freestyle_onOffSwitch_Clarity.TabIndex = 17;
      this.Freestyle_onOffSwitch_Clarity.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Freestyle_onOffSwitch_Clarity_SwitchChangeNotify);
      this.Freestyle_groupBox_Bass.Controls.Add((Control) this.Freestyle_buttonBox_BassMode);
      this.Freestyle_groupBox_Bass.Controls.Add((Control) this.Freestyle_hSlider_BassGain);
      this.Freestyle_groupBox_Bass.Controls.Add((Control) this.Freestyle_label_Bass_Gain);
      this.Freestyle_groupBox_Bass.Controls.Add((Control) this.Freestyle_hSlider_BassSpkSize);
      this.Freestyle_groupBox_Bass.Controls.Add((Control) this.Freestyle_label_Bass_SpkSize);
      this.Freestyle_groupBox_Bass.Controls.Add((Control) this.Freestyle_onOffSwitch_Bass);
      this.Freestyle_groupBox_Bass.Location = new Point(21, 214);
      this.Freestyle_groupBox_Bass.Name = "Freestyle_groupBox_Bass";
      this.Freestyle_groupBox_Bass.Size = new Size(189, 223);
      this.Freestyle_groupBox_Bass.TabIndex = 16;
      this.Freestyle_groupBox_Bass.TabStop = false;
      this.Freestyle_groupBox_Bass.Text = "$BASS";
      this.Freestyle_buttonBox_BassMode.BackColor = SystemColors.Control;
      this.Freestyle_buttonBox_BassMode.Location = new Point(21, 150);
      this.Freestyle_buttonBox_BassMode.Name = "Freestyle_buttonBox_BassMode";
      this.Freestyle_buttonBox_BassMode.Size = new Size(143, 61);
      this.Freestyle_buttonBox_BassMode.TabIndex = 22;
      this.Freestyle_buttonBox_BassMode.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(this.Freestyle_buttonBox_BassMode_ItemSelectedNotify);
      this.Freestyle_hSlider_BassGain.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_BassGain.Location = new Point(13, 115);
      this.Freestyle_hSlider_BassGain.MoveDelta = 1U;
      this.Freestyle_hSlider_BassGain.Name = "Freestyle_hSlider_BassGain";
      this.Freestyle_hSlider_BassGain.Position = 0U;
      this.Freestyle_hSlider_BassGain.PositionFloat = 0.0f;
      this.Freestyle_hSlider_BassGain.Size = new Size(161, 24);
      this.Freestyle_hSlider_BassGain.TabIndex = 21;
      this.Freestyle_hSlider_BassGain.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_BassGain_PositionChangeNotify);
      this.Freestyle_label_Bass_Gain.AutoSize = true;
      this.Freestyle_label_Bass_Gain.Location = new Point(23, 100);
      this.Freestyle_label_Bass_Gain.Name = "Freestyle_label_Bass_Gain";
      this.Freestyle_label_Bass_Gain.Size = new Size(101, 12);
      this.Freestyle_label_Bass_Gain.TabIndex = 20;
      this.Freestyle_label_Bass_Gain.Text = "$BASS_GAIN : 0dB";
      this.Freestyle_hSlider_BassSpkSize.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_BassSpkSize.Location = new Point(13, 73);
      this.Freestyle_hSlider_BassSpkSize.MoveDelta = 1U;
      this.Freestyle_hSlider_BassSpkSize.Name = "Freestyle_hSlider_BassSpkSize";
      this.Freestyle_hSlider_BassSpkSize.Position = 0U;
      this.Freestyle_hSlider_BassSpkSize.PositionFloat = 0.0f;
      this.Freestyle_hSlider_BassSpkSize.Size = new Size(161, 24);
      this.Freestyle_hSlider_BassSpkSize.TabIndex = 19;
      this.Freestyle_hSlider_BassSpkSize.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_BassSpkSize_PositionChangeNotify);
      this.Freestyle_label_Bass_SpkSize.AutoSize = true;
      this.Freestyle_label_Bass_SpkSize.Location = new Point(23, 58);
      this.Freestyle_label_Bass_SpkSize.Name = "Freestyle_label_Bass_SpkSize";
      this.Freestyle_label_Bass_SpkSize.Size = new Size(83, 12);
      this.Freestyle_label_Bass_SpkSize.TabIndex = 18;
      this.Freestyle_label_Bass_SpkSize.Text = "$BASS_SPKSIZE";
      this.Freestyle_onOffSwitch_Bass.BackColor = Color.Transparent;
      this.Freestyle_onOffSwitch_Bass.Location = new Point(13, 23);
      this.Freestyle_onOffSwitch_Bass.Name = "Freestyle_onOffSwitch_Bass";
      this.Freestyle_onOffSwitch_Bass.Size = new Size(49, 20);
      this.Freestyle_onOffSwitch_Bass.SwitchedOn = false;
      this.Freestyle_onOffSwitch_Bass.TabIndex = 17;
      this.Freestyle_onOffSwitch_Bass.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Freestyle_onOffSwitch_Bass_SwitchChangeNotify);
      this.Freestyle_groupBox_VHESurround.Controls.Add((Control) this.Freestyle_buttonBox_SurroundVHERoomSize);
      this.Freestyle_groupBox_VHESurround.Controls.Add((Control) this.Freestyle_onOffSwitch_SurroundVHE);
      this.Freestyle_groupBox_VHESurround.Location = new Point(606, 6);
      this.Freestyle_groupBox_VHESurround.Name = "Freestyle_groupBox_VHESurround";
      this.Freestyle_groupBox_VHESurround.Size = new Size(208, 138);
      this.Freestyle_groupBox_VHESurround.TabIndex = 13;
      this.Freestyle_groupBox_VHESurround.TabStop = false;
      this.Freestyle_groupBox_VHESurround.Text = "$VHE_SURROUND";
      this.Freestyle_buttonBox_SurroundVHERoomSize.BackColor = SystemColors.Control;
      this.Freestyle_buttonBox_SurroundVHERoomSize.Location = new Point(68, 23);
      this.Freestyle_buttonBox_SurroundVHERoomSize.Name = "Freestyle_buttonBox_SurroundVHERoomSize";
      this.Freestyle_buttonBox_SurroundVHERoomSize.Size = new Size((int) sbyte.MaxValue, 101);
      this.Freestyle_buttonBox_SurroundVHERoomSize.TabIndex = 7;
      this.Freestyle_buttonBox_SurroundVHERoomSize.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(this.Freestyle_buttonBox_SurroundVHERoomSize_ItemSelectedNotify);
      this.Freestyle_onOffSwitch_SurroundVHE.BackColor = Color.Transparent;
      this.Freestyle_onOffSwitch_SurroundVHE.Location = new Point(13, 23);
      this.Freestyle_onOffSwitch_SurroundVHE.Name = "Freestyle_onOffSwitch_SurroundVHE";
      this.Freestyle_onOffSwitch_SurroundVHE.Size = new Size(49, 20);
      this.Freestyle_onOffSwitch_SurroundVHE.SwitchedOn = false;
      this.Freestyle_onOffSwitch_SurroundVHE.TabIndex = 6;
      this.Freestyle_onOffSwitch_SurroundVHE.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Freestyle_onOffSwitch_SurroundVHE_SwitchChangeNotify);
      this.Freestyle_groupBox_Convolver.Controls.Add((Control) this.Freestyle_irShape_ConvIR);
      this.Freestyle_groupBox_Convolver.Controls.Add((Control) this.Freestyle_onOffSwitch_Convolver);
      this.Freestyle_groupBox_Convolver.Controls.Add((Control) this.Freestyle_hSlider_ConvIRGain);
      this.Freestyle_groupBox_Convolver.Controls.Add((Control) this.Freestyle_openFileBox_ConvIRS);
      this.Freestyle_groupBox_Convolver.Controls.Add((Control) this.Freestyle_label_ConvolverIRGain);
      this.Freestyle_groupBox_Convolver.Location = new Point(235, 6);
      this.Freestyle_groupBox_Convolver.Name = "Freestyle_groupBox_Convolver";
      this.Freestyle_groupBox_Convolver.Size = new Size(235, 179);
      this.Freestyle_groupBox_Convolver.TabIndex = 12;
      this.Freestyle_groupBox_Convolver.TabStop = false;
      this.Freestyle_groupBox_Convolver.Text = "$CONVOLVER";
      this.Freestyle_irShape_ConvIR.Location = new Point(13, 61);
      this.Freestyle_irShape_ConvIR.Name = "Freestyle_irShape_ConvIR";
      this.Freestyle_irShape_ConvIR.ShapeBackColor = Color.White;
      this.Freestyle_irShape_ConvIR.ShapeForeColor = Color.Black;
      this.Freestyle_irShape_ConvIR.Size = new Size(209, 63);
      this.Freestyle_irShape_ConvIR.TabIndex = 8;
      this.Freestyle_onOffSwitch_Convolver.BackColor = Color.Transparent;
      this.Freestyle_onOffSwitch_Convolver.Location = new Point(13, 23);
      this.Freestyle_onOffSwitch_Convolver.Name = "Freestyle_onOffSwitch_Convolver";
      this.Freestyle_onOffSwitch_Convolver.Size = new Size(49, 20);
      this.Freestyle_onOffSwitch_Convolver.SwitchedOn = false;
      this.Freestyle_onOffSwitch_Convolver.TabIndex = 5;
      this.Freestyle_onOffSwitch_Convolver.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Freestyle_onOffSwitch_Convolver_SwitchChangeNotify);
      this.Freestyle_hSlider_ConvIRGain.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_ConvIRGain.Location = new Point(85, 31);
      this.Freestyle_hSlider_ConvIRGain.MoveDelta = 1U;
      this.Freestyle_hSlider_ConvIRGain.Name = "Freestyle_hSlider_ConvIRGain";
      this.Freestyle_hSlider_ConvIRGain.Position = 0U;
      this.Freestyle_hSlider_ConvIRGain.PositionFloat = 0.0f;
      this.Freestyle_hSlider_ConvIRGain.Size = new Size(137, 24);
      this.Freestyle_hSlider_ConvIRGain.TabIndex = 7;
      this.Freestyle_hSlider_ConvIRGain.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_ConvIRGain_PositionChangeNotify);
      this.Freestyle_openFileBox_ConvIRS.BackColor = SystemColors.Control;
      this.Freestyle_openFileBox_ConvIRS.FilePathName = "";
      this.Freestyle_openFileBox_ConvIRS.Location = new Point(13, 136);
      this.Freestyle_openFileBox_ConvIRS.Name = "Freestyle_openFileBox_ConvIRS";
      this.Freestyle_openFileBox_ConvIRS.Size = new Size(209, 29);
      this.Freestyle_openFileBox_ConvIRS.TabIndex = 9;
      this.Freestyle_openFileBox_ConvIRS.FileChangeNotify += new OpenFileBox.FileChangeEventDelegate(this.Freestyle_openFileBox_ConvIRS_FileChangeNotify);
      this.Freestyle_label_ConvolverIRGain.AutoSize = true;
      this.Freestyle_label_ConvolverIRGain.Location = new Point(95, 16);
      this.Freestyle_label_ConvolverIRGain.Name = "Freestyle_label_ConvolverIRGain";
      this.Freestyle_label_ConvolverIRGain.Size = new Size(119, 12);
      this.Freestyle_label_ConvolverIRGain.TabIndex = 6;
      this.Freestyle_label_ConvolverIRGain.Text = "$CONV_IR_GAIN : 0dB";
      this.Freestyle_hSlider_PostVolume.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_PostVolume.Location = new Point(21, 118);
      this.Freestyle_hSlider_PostVolume.MoveDelta = 1U;
      this.Freestyle_hSlider_PostVolume.Name = "Freestyle_hSlider_PostVolume";
      this.Freestyle_hSlider_PostVolume.Position = 0U;
      this.Freestyle_hSlider_PostVolume.PositionFloat = 0.0f;
      this.Freestyle_hSlider_PostVolume.Size = new Size(208, 39);
      this.Freestyle_hSlider_PostVolume.TabIndex = 3;
      this.Freestyle_hSlider_PostVolume.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_PostVolume_PositionChangeNotify);
      this.Freestyle_label_PostVolume.AutoSize = true;
      this.Freestyle_label_PostVolume.Location = new Point(40, 100);
      this.Freestyle_label_PostVolume.Name = "Freestyle_label_PostVolume";
      this.Freestyle_label_PostVolume.Size = new Size(113, 12);
      this.Freestyle_label_PostVolume.TabIndex = 2;
      this.Freestyle_label_PostVolume.Text = "$POST_VOLUME : 0dB";
      this.Freestyle_hSlider_PreVolume.BackColor = SystemColors.Control;
      this.Freestyle_hSlider_PreVolume.Location = new Point(21, 39);
      this.Freestyle_hSlider_PreVolume.MoveDelta = 1U;
      this.Freestyle_hSlider_PreVolume.Name = "Freestyle_hSlider_PreVolume";
      this.Freestyle_hSlider_PreVolume.Position = 0U;
      this.Freestyle_hSlider_PreVolume.PositionFloat = 0.0f;
      this.Freestyle_hSlider_PreVolume.Size = new Size(208, 39);
      this.Freestyle_hSlider_PreVolume.TabIndex = 1;
      this.Freestyle_hSlider_PreVolume.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Freestyle_hSlider_PreVolume_PositionChangeNotify);
      this.Freestyle_label_PreVolume.AutoSize = true;
      this.Freestyle_label_PreVolume.Location = new Point(40, 21);
      this.Freestyle_label_PreVolume.Name = "Freestyle_label_PreVolume";
      this.Freestyle_label_PreVolume.Size = new Size(107, 12);
      this.Freestyle_label_PreVolume.TabIndex = 0;
      this.Freestyle_label_PreVolume.Text = "$PRE_VOLUME : 0dB";
      this.panel_MusicMode.Controls.Add((Control) this.panel_MovieMode);
      this.panel_MusicMode.Controls.Add((Control) this.Music_singleButton_Compressor);
      this.panel_MusicMode.Controls.Add((Control) this.Music_singleButton_Equalizer);
      this.panel_MusicMode.Controls.Add((Control) this.Music_groupBox_Reverb);
      this.panel_MusicMode.Controls.Add((Control) this.Music_groupBox_Cure);
      this.panel_MusicMode.Controls.Add((Control) this.Music_groupBox_Clarity);
      this.panel_MusicMode.Controls.Add((Control) this.Music_groupBox_Bass);
      this.panel_MusicMode.Controls.Add((Control) this.Music_groupBox_Surround);
      this.panel_MusicMode.Controls.Add((Control) this.Music_groupBox_Convolver);
      this.panel_MusicMode.Controls.Add((Control) this.Music_hSlider_PostVolume);
      this.panel_MusicMode.Controls.Add((Control) this.Music_label_PostVolume);
      this.panel_MusicMode.Controls.Add((Control) this.Music_hSlider_PreVolume);
      this.panel_MusicMode.Controls.Add((Control) this.Music_label_PreVolume);
      this.panel_MusicMode.Dock = DockStyle.Fill;
      this.panel_MusicMode.Location = new Point(3, 17);
      this.panel_MusicMode.Name = "panel_MusicMode";
      this.panel_MusicMode.Size = new Size(835, 552);
      this.panel_MusicMode.TabIndex = 0;
      this.panel_MovieMode.Controls.Add((Control) this.Movie_groupBox_SmartVolume);
      this.panel_MovieMode.Controls.Add((Control) this.Movie_singleButton_Compressor);
      this.panel_MovieMode.Controls.Add((Control) this.Movie_singleButton_Equalizer);
      this.panel_MovieMode.Controls.Add((Control) this.Movie_groupBox_Reverb);
      this.panel_MovieMode.Controls.Add((Control) this.Movie_groupBox_Clarity);
      this.panel_MovieMode.Controls.Add((Control) this.Movie_groupBox_Bass);
      this.panel_MovieMode.Controls.Add((Control) this.Movie_groupBox_Surround);
      this.panel_MovieMode.Controls.Add((Control) this.Movie_groupBox_Convolver);
      this.panel_MovieMode.Controls.Add((Control) this.Movie_hSlider_PostVolume);
      this.panel_MovieMode.Controls.Add((Control) this.Movie_label_PostVolume);
      this.panel_MovieMode.Controls.Add((Control) this.Movie_hSlider_PreVolume);
      this.panel_MovieMode.Controls.Add((Control) this.Movie_label_PreVolume);
      this.panel_MovieMode.Dock = DockStyle.Fill;
      this.panel_MovieMode.Location = new Point(0, 0);
      this.panel_MovieMode.Name = "panel_MovieMode";
      this.panel_MovieMode.Size = new Size(835, 552);
      this.panel_MovieMode.TabIndex = 9;
      this.Movie_groupBox_SmartVolume.Controls.Add((Control) this.Movie_hSlider_SmartVolumeLevel);
      this.Movie_groupBox_SmartVolume.Controls.Add((Control) this.Movie_label_SmartVolume_Level);
      this.Movie_groupBox_SmartVolume.Controls.Add((Control) this.Movie_hSlider_SmartVolumeMaxLevel);
      this.Movie_groupBox_SmartVolume.Controls.Add((Control) this.Movie_label_SmartVolume_MaxLevel);
      this.Movie_groupBox_SmartVolume.Controls.Add((Control) this.Movie_hSlider_SmartVolumeRatio);
      this.Movie_groupBox_SmartVolume.Controls.Add((Control) this.Movie_label_SmartVolume_ControlStrength);
      this.Movie_groupBox_SmartVolume.Controls.Add((Control) this.Movie_onOffSwitch_SmartVolume);
      this.Movie_groupBox_SmartVolume.Location = new Point(21, 391);
      this.Movie_groupBox_SmartVolume.Name = "Movie_groupBox_SmartVolume";
      this.Movie_groupBox_SmartVolume.Size = new Size(579, 148);
      this.Movie_groupBox_SmartVolume.TabIndex = 22;
      this.Movie_groupBox_SmartVolume.TabStop = false;
      this.Movie_groupBox_SmartVolume.Text = "$SMART_VOLUME";
      this.Movie_hSlider_SmartVolumeLevel.BackColor = SystemColors.Control;
      this.Movie_hSlider_SmartVolumeLevel.Location = new Point(254, 78);
      this.Movie_hSlider_SmartVolumeLevel.MoveDelta = 1U;
      this.Movie_hSlider_SmartVolumeLevel.Name = "Movie_hSlider_SmartVolumeLevel";
      this.Movie_hSlider_SmartVolumeLevel.Position = 0U;
      this.Movie_hSlider_SmartVolumeLevel.PositionFloat = 0.0f;
      this.Movie_hSlider_SmartVolumeLevel.Size = new Size(319, 39);
      this.Movie_hSlider_SmartVolumeLevel.TabIndex = 23;
      this.Movie_hSlider_SmartVolumeLevel.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_SmartVolumeLevel_PositionChangeNotify);
      this.Movie_label_SmartVolume_Level.AutoSize = true;
      this.Movie_label_SmartVolume_Level.Location = new Point(273, 60);
      this.Movie_label_SmartVolume_Level.Name = "Movie_label_SmartVolume_Level";
      this.Movie_label_SmartVolume_Level.Size = new Size(155, 12);
      this.Movie_label_SmartVolume_Level.TabIndex = 22;
      this.Movie_label_SmartVolume_Level.Text = "$SMART_VOLUME_LEVEL : 0dB";
      this.Movie_hSlider_SmartVolumeMaxLevel.BackColor = SystemColors.Control;
      this.Movie_hSlider_SmartVolumeMaxLevel.Location = new Point(13, 115);
      this.Movie_hSlider_SmartVolumeMaxLevel.MoveDelta = 1U;
      this.Movie_hSlider_SmartVolumeMaxLevel.Name = "Movie_hSlider_SmartVolumeMaxLevel";
      this.Movie_hSlider_SmartVolumeMaxLevel.Position = 0U;
      this.Movie_hSlider_SmartVolumeMaxLevel.PositionFloat = 0.0f;
      this.Movie_hSlider_SmartVolumeMaxLevel.Size = new Size(161, 24);
      this.Movie_hSlider_SmartVolumeMaxLevel.TabIndex = 21;
      this.Movie_hSlider_SmartVolumeMaxLevel.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_SmartVolumeMaxLevel_PositionChangeNotify);
      this.Movie_label_SmartVolume_MaxLevel.AutoSize = true;
      this.Movie_label_SmartVolume_MaxLevel.Location = new Point(23, 100);
      this.Movie_label_SmartVolume_MaxLevel.Name = "Movie_label_SmartVolume_MaxLevel";
      this.Movie_label_SmartVolume_MaxLevel.Size = new Size(167, 12);
      this.Movie_label_SmartVolume_MaxLevel.TabIndex = 20;
      this.Movie_label_SmartVolume_MaxLevel.Text = "$SMART_VOLUME_MAXLEVEL : 1x";
      this.Movie_hSlider_SmartVolumeRatio.BackColor = SystemColors.Control;
      this.Movie_hSlider_SmartVolumeRatio.Location = new Point(13, 73);
      this.Movie_hSlider_SmartVolumeRatio.MoveDelta = 1U;
      this.Movie_hSlider_SmartVolumeRatio.Name = "Movie_hSlider_SmartVolumeRatio";
      this.Movie_hSlider_SmartVolumeRatio.Position = 0U;
      this.Movie_hSlider_SmartVolumeRatio.PositionFloat = 0.0f;
      this.Movie_hSlider_SmartVolumeRatio.Size = new Size(161, 24);
      this.Movie_hSlider_SmartVolumeRatio.TabIndex = 19;
      this.Movie_hSlider_SmartVolumeRatio.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_SmartVolumeRatio_PositionChangeNotify);
      this.Movie_label_SmartVolume_ControlStrength.AutoSize = true;
      this.Movie_label_SmartVolume_ControlStrength.Location = new Point(23, 58);
      this.Movie_label_SmartVolume_ControlStrength.Name = "Movie_label_SmartVolume_ControlStrength";
      this.Movie_label_SmartVolume_ControlStrength.Size = new Size(185, 12);
      this.Movie_label_SmartVolume_ControlStrength.TabIndex = 18;
      this.Movie_label_SmartVolume_ControlStrength.Text = "$SMART_VOLUME_CONTROL_STRENGTH";
      this.Movie_onOffSwitch_SmartVolume.BackColor = Color.Transparent;
      this.Movie_onOffSwitch_SmartVolume.Location = new Point(13, 23);
      this.Movie_onOffSwitch_SmartVolume.Name = "Movie_onOffSwitch_SmartVolume";
      this.Movie_onOffSwitch_SmartVolume.Size = new Size(49, 20);
      this.Movie_onOffSwitch_SmartVolume.SwitchedOn = false;
      this.Movie_onOffSwitch_SmartVolume.TabIndex = 17;
      this.Movie_onOffSwitch_SmartVolume.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Movie_onOffSwitch_SmartVolume_SwitchChangeNotify);
      this.Movie_singleButton_Compressor.BackColor = SystemColors.Control;
      this.Movie_singleButton_Compressor.ButtonText = "$COMPRESSOR_ADJUST";
      this.Movie_singleButton_Compressor.Location = new Point(420, 301);
      this.Movie_singleButton_Compressor.Name = "Movie_singleButton_Compressor";
      this.Movie_singleButton_Compressor.Size = new Size(174, 39);
      this.Movie_singleButton_Compressor.TabIndex = 21;
      this.Movie_singleButton_Compressor.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.Movie_singleButton_Compressor_ButtonClickNotify);
      this.Movie_singleButton_Equalizer.BackColor = SystemColors.Control;
      this.Movie_singleButton_Equalizer.ButtonText = "$EQUALIZER_ADJUST";
      this.Movie_singleButton_Equalizer.Location = new Point(420, 245);
      this.Movie_singleButton_Equalizer.Name = "Movie_singleButton_Equalizer";
      this.Movie_singleButton_Equalizer.Size = new Size(174, 39);
      this.Movie_singleButton_Equalizer.TabIndex = 20;
      this.Movie_singleButton_Equalizer.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.Movie_singleButton_Equalizer_ButtonClickNotify);
      this.Movie_groupBox_Reverb.Controls.Add((Control) this.Movie_singleButton_ReverbPreset);
      this.Movie_groupBox_Reverb.Controls.Add((Control) this.Movie_hSlider_ReverbMix);
      this.Movie_groupBox_Reverb.Controls.Add((Control) this.Movie_label_Reverb_Mix);
      this.Movie_groupBox_Reverb.Controls.Add((Control) this.Movie_hSlider_ReverbEarlyMix);
      this.Movie_groupBox_Reverb.Controls.Add((Control) this.Movie_label_Reverb_EarlyMix);
      this.Movie_groupBox_Reverb.Controls.Add((Control) this.Movie_hSlider_ReverbPreDelay);
      this.Movie_groupBox_Reverb.Controls.Add((Control) this.Movie_label_Reverb_PreDelay);
      this.Movie_groupBox_Reverb.Controls.Add((Control) this.Movie_hSlider_ReverbDecay);
      this.Movie_groupBox_Reverb.Controls.Add((Control) this.Movie_label_Reverb_Decay);
      this.Movie_groupBox_Reverb.Controls.Add((Control) this.Movie_hSlider_ReverbBandWidth);
      this.Movie_groupBox_Reverb.Controls.Add((Control) this.Movie_label_Reverb_BandWidth);
      this.Movie_groupBox_Reverb.Controls.Add((Control) this.Movie_hSlider_ReverbDensity);
      this.Movie_groupBox_Reverb.Controls.Add((Control) this.Movie_label_Reverb_Density);
      this.Movie_groupBox_Reverb.Controls.Add((Control) this.Movie_hSlider_ReverbDamping);
      this.Movie_groupBox_Reverb.Controls.Add((Control) this.Movie_label_Reverb_Damping);
      this.Movie_groupBox_Reverb.Controls.Add((Control) this.Movie_hSlider_ReverbSize);
      this.Movie_groupBox_Reverb.Controls.Add((Control) this.Movie_label_Reverb_Size);
      this.Movie_groupBox_Reverb.Controls.Add((Control) this.Movie_onOffSwitch_Reverb);
      this.Movie_groupBox_Reverb.Location = new Point(606, 150);
      this.Movie_groupBox_Reverb.Name = "Movie_groupBox_Reverb";
      this.Movie_groupBox_Reverb.Size = new Size(208, 389);
      this.Movie_groupBox_Reverb.TabIndex = 19;
      this.Movie_groupBox_Reverb.TabStop = false;
      this.Movie_groupBox_Reverb.Text = "$REVERB";
      this.Movie_singleButton_ReverbPreset.BackColor = SystemColors.Control;
      this.Movie_singleButton_ReverbPreset.ButtonText = "$PRESET";
      this.Movie_singleButton_ReverbPreset.Location = new Point(121, 14);
      this.Movie_singleButton_ReverbPreset.Name = "Movie_singleButton_ReverbPreset";
      this.Movie_singleButton_ReverbPreset.Size = new Size(81, 29);
      this.Movie_singleButton_ReverbPreset.TabIndex = 36;
      this.Movie_singleButton_ReverbPreset.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.Movie_singleButton_ReverbPreset_ButtonClickNotify);
      this.Movie_hSlider_ReverbMix.BackColor = SystemColors.Control;
      this.Movie_hSlider_ReverbMix.Location = new Point(24, 356);
      this.Movie_hSlider_ReverbMix.MoveDelta = 1U;
      this.Movie_hSlider_ReverbMix.Name = "Movie_hSlider_ReverbMix";
      this.Movie_hSlider_ReverbMix.Position = 0U;
      this.Movie_hSlider_ReverbMix.PositionFloat = 0.0f;
      this.Movie_hSlider_ReverbMix.Size = new Size(161, 24);
      this.Movie_hSlider_ReverbMix.TabIndex = 35;
      this.Movie_hSlider_ReverbMix.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_ReverbMix_PositionChangeNotify);
      this.Movie_label_Reverb_Mix.AutoSize = true;
      this.Movie_label_Reverb_Mix.Location = new Point(34, 341);
      this.Movie_label_Reverb_Mix.Name = "Movie_label_Reverb_Mix";
      this.Movie_label_Reverb_Mix.Size = new Size(71, 12);
      this.Movie_label_Reverb_Mix.TabIndex = 34;
      this.Movie_label_Reverb_Mix.Text = "$REVERB_MIX";
      this.Movie_hSlider_ReverbEarlyMix.BackColor = SystemColors.Control;
      this.Movie_hSlider_ReverbEarlyMix.Location = new Point(24, 314);
      this.Movie_hSlider_ReverbEarlyMix.MoveDelta = 1U;
      this.Movie_hSlider_ReverbEarlyMix.Name = "Movie_hSlider_ReverbEarlyMix";
      this.Movie_hSlider_ReverbEarlyMix.Position = 0U;
      this.Movie_hSlider_ReverbEarlyMix.PositionFloat = 0.0f;
      this.Movie_hSlider_ReverbEarlyMix.Size = new Size(161, 24);
      this.Movie_hSlider_ReverbEarlyMix.TabIndex = 33;
      this.Movie_hSlider_ReverbEarlyMix.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_ReverbEarlyMix_PositionChangeNotify);
      this.Movie_label_Reverb_EarlyMix.AutoSize = true;
      this.Movie_label_Reverb_EarlyMix.Location = new Point(34, 299);
      this.Movie_label_Reverb_EarlyMix.Name = "Movie_label_Reverb_EarlyMix";
      this.Movie_label_Reverb_EarlyMix.Size = new Size(101, 12);
      this.Movie_label_Reverb_EarlyMix.TabIndex = 32;
      this.Movie_label_Reverb_EarlyMix.Text = "$REVERB_EARLYMIX";
      this.Movie_hSlider_ReverbPreDelay.BackColor = SystemColors.Control;
      this.Movie_hSlider_ReverbPreDelay.Location = new Point(24, 272);
      this.Movie_hSlider_ReverbPreDelay.MoveDelta = 1U;
      this.Movie_hSlider_ReverbPreDelay.Name = "Movie_hSlider_ReverbPreDelay";
      this.Movie_hSlider_ReverbPreDelay.Position = 0U;
      this.Movie_hSlider_ReverbPreDelay.PositionFloat = 0.0f;
      this.Movie_hSlider_ReverbPreDelay.Size = new Size(161, 24);
      this.Movie_hSlider_ReverbPreDelay.TabIndex = 31;
      this.Movie_hSlider_ReverbPreDelay.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_ReverbPreDelay_PositionChangeNotify);
      this.Movie_label_Reverb_PreDelay.AutoSize = true;
      this.Movie_label_Reverb_PreDelay.Location = new Point(34, 257);
      this.Movie_label_Reverb_PreDelay.Name = "Movie_label_Reverb_PreDelay";
      this.Movie_label_Reverb_PreDelay.Size = new Size(101, 12);
      this.Movie_label_Reverb_PreDelay.TabIndex = 30;
      this.Movie_label_Reverb_PreDelay.Text = "$REVERB_PREDELAY";
      this.Movie_hSlider_ReverbDecay.BackColor = SystemColors.Control;
      this.Movie_hSlider_ReverbDecay.Location = new Point(24, 230);
      this.Movie_hSlider_ReverbDecay.MoveDelta = 1U;
      this.Movie_hSlider_ReverbDecay.Name = "Movie_hSlider_ReverbDecay";
      this.Movie_hSlider_ReverbDecay.Position = 0U;
      this.Movie_hSlider_ReverbDecay.PositionFloat = 0.0f;
      this.Movie_hSlider_ReverbDecay.Size = new Size(161, 24);
      this.Movie_hSlider_ReverbDecay.TabIndex = 29;
      this.Movie_hSlider_ReverbDecay.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_ReverbDecay_PositionChangeNotify);
      this.Movie_label_Reverb_Decay.AutoSize = true;
      this.Movie_label_Reverb_Decay.Location = new Point(34, 215);
      this.Movie_label_Reverb_Decay.Name = "Movie_label_Reverb_Decay";
      this.Movie_label_Reverb_Decay.Size = new Size(83, 12);
      this.Movie_label_Reverb_Decay.TabIndex = 28;
      this.Movie_label_Reverb_Decay.Text = "$REVERB_DECAY";
      this.Movie_hSlider_ReverbBandWidth.BackColor = SystemColors.Control;
      this.Movie_hSlider_ReverbBandWidth.Location = new Point(24, 188);
      this.Movie_hSlider_ReverbBandWidth.MoveDelta = 1U;
      this.Movie_hSlider_ReverbBandWidth.Name = "Movie_hSlider_ReverbBandWidth";
      this.Movie_hSlider_ReverbBandWidth.Position = 0U;
      this.Movie_hSlider_ReverbBandWidth.PositionFloat = 0.0f;
      this.Movie_hSlider_ReverbBandWidth.Size = new Size(161, 24);
      this.Movie_hSlider_ReverbBandWidth.TabIndex = 27;
      this.Movie_hSlider_ReverbBandWidth.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_ReverbBandWidth_PositionChangeNotify);
      this.Movie_label_Reverb_BandWidth.AutoSize = true;
      this.Movie_label_Reverb_BandWidth.Location = new Point(34, 173);
      this.Movie_label_Reverb_BandWidth.Name = "Movie_label_Reverb_BandWidth";
      this.Movie_label_Reverb_BandWidth.Size = new Size(107, 12);
      this.Movie_label_Reverb_BandWidth.TabIndex = 26;
      this.Movie_label_Reverb_BandWidth.Text = "$REVERB_BANDWIDTH";
      this.Movie_hSlider_ReverbDensity.BackColor = SystemColors.Control;
      this.Movie_hSlider_ReverbDensity.Location = new Point(24, 146);
      this.Movie_hSlider_ReverbDensity.MoveDelta = 1U;
      this.Movie_hSlider_ReverbDensity.Name = "Movie_hSlider_ReverbDensity";
      this.Movie_hSlider_ReverbDensity.Position = 0U;
      this.Movie_hSlider_ReverbDensity.PositionFloat = 0.0f;
      this.Movie_hSlider_ReverbDensity.Size = new Size(161, 24);
      this.Movie_hSlider_ReverbDensity.TabIndex = 25;
      this.Movie_hSlider_ReverbDensity.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_ReverbDensity_PositionChangeNotify);
      this.Movie_label_Reverb_Density.AutoSize = true;
      this.Movie_label_Reverb_Density.Location = new Point(34, 131);
      this.Movie_label_Reverb_Density.Name = "Movie_label_Reverb_Density";
      this.Movie_label_Reverb_Density.Size = new Size(95, 12);
      this.Movie_label_Reverb_Density.TabIndex = 24;
      this.Movie_label_Reverb_Density.Text = "$REVERB_DENSITY";
      this.Movie_hSlider_ReverbDamping.BackColor = SystemColors.Control;
      this.Movie_hSlider_ReverbDamping.Location = new Point(24, 104);
      this.Movie_hSlider_ReverbDamping.MoveDelta = 1U;
      this.Movie_hSlider_ReverbDamping.Name = "Movie_hSlider_ReverbDamping";
      this.Movie_hSlider_ReverbDamping.Position = 0U;
      this.Movie_hSlider_ReverbDamping.PositionFloat = 0.0f;
      this.Movie_hSlider_ReverbDamping.Size = new Size(161, 24);
      this.Movie_hSlider_ReverbDamping.TabIndex = 23;
      this.Movie_hSlider_ReverbDamping.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_ReverbDamping_PositionChangeNotify);
      this.Movie_label_Reverb_Damping.AutoSize = true;
      this.Movie_label_Reverb_Damping.Location = new Point(34, 89);
      this.Movie_label_Reverb_Damping.Name = "Movie_label_Reverb_Damping";
      this.Movie_label_Reverb_Damping.Size = new Size(95, 12);
      this.Movie_label_Reverb_Damping.TabIndex = 22;
      this.Movie_label_Reverb_Damping.Text = "$REVERB_DAMPING";
      this.Movie_hSlider_ReverbSize.BackColor = SystemColors.Control;
      this.Movie_hSlider_ReverbSize.Location = new Point(24, 64);
      this.Movie_hSlider_ReverbSize.MoveDelta = 1U;
      this.Movie_hSlider_ReverbSize.Name = "Movie_hSlider_ReverbSize";
      this.Movie_hSlider_ReverbSize.Position = 0U;
      this.Movie_hSlider_ReverbSize.PositionFloat = 0.0f;
      this.Movie_hSlider_ReverbSize.Size = new Size(161, 24);
      this.Movie_hSlider_ReverbSize.TabIndex = 21;
      this.Movie_hSlider_ReverbSize.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_ReverbSize_PositionChangeNotify);
      this.Movie_label_Reverb_Size.AutoSize = true;
      this.Movie_label_Reverb_Size.Location = new Point(34, 49);
      this.Movie_label_Reverb_Size.Name = "Movie_label_Reverb_Size";
      this.Movie_label_Reverb_Size.Size = new Size(77, 12);
      this.Movie_label_Reverb_Size.TabIndex = 20;
      this.Movie_label_Reverb_Size.Text = "$REVERB_SIZE";
      this.Movie_onOffSwitch_Reverb.BackColor = Color.Transparent;
      this.Movie_onOffSwitch_Reverb.Location = new Point(13, 23);
      this.Movie_onOffSwitch_Reverb.Name = "Movie_onOffSwitch_Reverb";
      this.Movie_onOffSwitch_Reverb.Size = new Size(49, 20);
      this.Movie_onOffSwitch_Reverb.SwitchedOn = false;
      this.Movie_onOffSwitch_Reverb.TabIndex = 7;
      this.Movie_onOffSwitch_Reverb.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Movie_onOffSwitch_Reverb_SwitchChangeNotify);
      this.Movie_groupBox_Clarity.Controls.Add((Control) this.Movie_hSlider_Clarity);
      this.Movie_groupBox_Clarity.Controls.Add((Control) this.Movie_label_Clarity);
      this.Movie_groupBox_Clarity.Controls.Add((Control) this.Movie_onOffSwitch_Clarity);
      this.Movie_groupBox_Clarity.Location = new Point(216, 213);
      this.Movie_groupBox_Clarity.Name = "Movie_groupBox_Clarity";
      this.Movie_groupBox_Clarity.Size = new Size(189, 148);
      this.Movie_groupBox_Clarity.TabIndex = 17;
      this.Movie_groupBox_Clarity.TabStop = false;
      this.Movie_groupBox_Clarity.Text = "$CLARITY";
      this.Movie_hSlider_Clarity.BackColor = SystemColors.Control;
      this.Movie_hSlider_Clarity.Location = new Point(13, 93);
      this.Movie_hSlider_Clarity.MoveDelta = 1U;
      this.Movie_hSlider_Clarity.Name = "Movie_hSlider_Clarity";
      this.Movie_hSlider_Clarity.Position = 0U;
      this.Movie_hSlider_Clarity.PositionFloat = 0.0f;
      this.Movie_hSlider_Clarity.Size = new Size(161, 24);
      this.Movie_hSlider_Clarity.TabIndex = 21;
      this.Movie_hSlider_Clarity.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_Clarity_PositionChangeNotify);
      this.Movie_label_Clarity.AutoSize = true;
      this.Movie_label_Clarity.Location = new Point(23, 78);
      this.Movie_label_Clarity.Name = "Movie_label_Clarity";
      this.Movie_label_Clarity.Size = new Size(89, 12);
      this.Movie_label_Clarity.TabIndex = 20;
      this.Movie_label_Clarity.Text = "$CLARITY : 0dB";
      this.Movie_onOffSwitch_Clarity.BackColor = Color.Transparent;
      this.Movie_onOffSwitch_Clarity.Location = new Point(13, 23);
      this.Movie_onOffSwitch_Clarity.Name = "Movie_onOffSwitch_Clarity";
      this.Movie_onOffSwitch_Clarity.Size = new Size(49, 20);
      this.Movie_onOffSwitch_Clarity.SwitchedOn = false;
      this.Movie_onOffSwitch_Clarity.TabIndex = 17;
      this.Movie_onOffSwitch_Clarity.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Movie_onOffSwitch_Clarity_SwitchChangeNotify);
      this.Movie_groupBox_Bass.Controls.Add((Control) this.Movie_hSlider_BassGain);
      this.Movie_groupBox_Bass.Controls.Add((Control) this.Movie_label_Bass_Gain);
      this.Movie_groupBox_Bass.Controls.Add((Control) this.Movie_hSlider_BassSpkSize);
      this.Movie_groupBox_Bass.Controls.Add((Control) this.Movie_label_Bass_SpkSize);
      this.Movie_groupBox_Bass.Controls.Add((Control) this.Movie_onOffSwitch_Bass);
      this.Movie_groupBox_Bass.Location = new Point(21, 213);
      this.Movie_groupBox_Bass.Name = "Movie_groupBox_Bass";
      this.Movie_groupBox_Bass.Size = new Size(189, 148);
      this.Movie_groupBox_Bass.TabIndex = 16;
      this.Movie_groupBox_Bass.TabStop = false;
      this.Movie_groupBox_Bass.Text = "$BASS";
      this.Movie_hSlider_BassGain.BackColor = SystemColors.Control;
      this.Movie_hSlider_BassGain.Location = new Point(13, 115);
      this.Movie_hSlider_BassGain.MoveDelta = 1U;
      this.Movie_hSlider_BassGain.Name = "Movie_hSlider_BassGain";
      this.Movie_hSlider_BassGain.Position = 0U;
      this.Movie_hSlider_BassGain.PositionFloat = 0.0f;
      this.Movie_hSlider_BassGain.Size = new Size(161, 24);
      this.Movie_hSlider_BassGain.TabIndex = 21;
      this.Movie_hSlider_BassGain.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_BassGain_PositionChangeNotify);
      this.Movie_label_Bass_Gain.AutoSize = true;
      this.Movie_label_Bass_Gain.Location = new Point(23, 100);
      this.Movie_label_Bass_Gain.Name = "Movie_label_Bass_Gain";
      this.Movie_label_Bass_Gain.Size = new Size(101, 12);
      this.Movie_label_Bass_Gain.TabIndex = 20;
      this.Movie_label_Bass_Gain.Text = "$BASS_GAIN : 0dB";
      this.Movie_hSlider_BassSpkSize.BackColor = SystemColors.Control;
      this.Movie_hSlider_BassSpkSize.Location = new Point(13, 73);
      this.Movie_hSlider_BassSpkSize.MoveDelta = 1U;
      this.Movie_hSlider_BassSpkSize.Name = "Movie_hSlider_BassSpkSize";
      this.Movie_hSlider_BassSpkSize.Position = 0U;
      this.Movie_hSlider_BassSpkSize.PositionFloat = 0.0f;
      this.Movie_hSlider_BassSpkSize.Size = new Size(161, 24);
      this.Movie_hSlider_BassSpkSize.TabIndex = 19;
      this.Movie_hSlider_BassSpkSize.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_BassSpkSize_PositionChangeNotify);
      this.Movie_label_Bass_SpkSize.AutoSize = true;
      this.Movie_label_Bass_SpkSize.Location = new Point(23, 58);
      this.Movie_label_Bass_SpkSize.Name = "Movie_label_Bass_SpkSize";
      this.Movie_label_Bass_SpkSize.Size = new Size(83, 12);
      this.Movie_label_Bass_SpkSize.TabIndex = 18;
      this.Movie_label_Bass_SpkSize.Text = "$BASS_SPKSIZE";
      this.Movie_onOffSwitch_Bass.BackColor = Color.Transparent;
      this.Movie_onOffSwitch_Bass.Location = new Point(13, 23);
      this.Movie_onOffSwitch_Bass.Name = "Movie_onOffSwitch_Bass";
      this.Movie_onOffSwitch_Bass.Size = new Size(49, 20);
      this.Movie_onOffSwitch_Bass.SwitchedOn = false;
      this.Movie_onOffSwitch_Bass.TabIndex = 17;
      this.Movie_onOffSwitch_Bass.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Movie_onOffSwitch_Bass_SwitchChangeNotify);
      this.Movie_groupBox_Surround.Controls.Add((Control) this.Movie_hSlider_SurroundImage);
      this.Movie_groupBox_Surround.Controls.Add((Control) this.Movie_label_Surround_Image);
      this.Movie_groupBox_Surround.Controls.Add((Control) this.Movie_hSlider_Surround3D);
      this.Movie_groupBox_Surround.Controls.Add((Control) this.Movie_label_Surround_3D);
      this.Movie_groupBox_Surround.Controls.Add((Control) this.Movie_onOffSwitch_Surround);
      this.Movie_groupBox_Surround.Location = new Point(606, 6);
      this.Movie_groupBox_Surround.Name = "Movie_groupBox_Surround";
      this.Movie_groupBox_Surround.Size = new Size(208, 138);
      this.Movie_groupBox_Surround.TabIndex = 13;
      this.Movie_groupBox_Surround.TabStop = false;
      this.Movie_groupBox_Surround.Text = "$SURROUND";
      this.Movie_hSlider_SurroundImage.BackColor = SystemColors.Control;
      this.Movie_hSlider_SurroundImage.Location = new Point(24, 109);
      this.Movie_hSlider_SurroundImage.MoveDelta = 1U;
      this.Movie_hSlider_SurroundImage.Name = "Movie_hSlider_SurroundImage";
      this.Movie_hSlider_SurroundImage.Position = 0U;
      this.Movie_hSlider_SurroundImage.PositionFloat = 0.0f;
      this.Movie_hSlider_SurroundImage.Size = new Size(161, 24);
      this.Movie_hSlider_SurroundImage.TabIndex = 25;
      this.Movie_hSlider_SurroundImage.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_SurroundImage_PositionChangeNotify);
      this.Movie_label_Surround_Image.AutoSize = true;
      this.Movie_label_Surround_Image.Location = new Point(34, 94);
      this.Movie_label_Surround_Image.Name = "Movie_label_Surround_Image";
      this.Movie_label_Surround_Image.Size = new Size(95, 12);
      this.Movie_label_Surround_Image.TabIndex = 24;
      this.Movie_label_Surround_Image.Text = "$SURROUND_IMAGE";
      this.Movie_hSlider_Surround3D.BackColor = SystemColors.Control;
      this.Movie_hSlider_Surround3D.Location = new Point(24, 67);
      this.Movie_hSlider_Surround3D.MoveDelta = 1U;
      this.Movie_hSlider_Surround3D.Name = "Movie_hSlider_Surround3D";
      this.Movie_hSlider_Surround3D.Position = 0U;
      this.Movie_hSlider_Surround3D.PositionFloat = 0.0f;
      this.Movie_hSlider_Surround3D.Size = new Size(161, 24);
      this.Movie_hSlider_Surround3D.TabIndex = 23;
      this.Movie_hSlider_Surround3D.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_Surround3D_PositionChangeNotify);
      this.Movie_label_Surround_3D.AutoSize = true;
      this.Movie_label_Surround_3D.Location = new Point(34, 52);
      this.Movie_label_Surround_3D.Name = "Movie_label_Surround_3D";
      this.Movie_label_Surround_3D.Size = new Size(77, 12);
      this.Movie_label_Surround_3D.TabIndex = 22;
      this.Movie_label_Surround_3D.Text = "$SURROUND_3D";
      this.Movie_onOffSwitch_Surround.BackColor = Color.Transparent;
      this.Movie_onOffSwitch_Surround.Location = new Point(13, 23);
      this.Movie_onOffSwitch_Surround.Name = "Movie_onOffSwitch_Surround";
      this.Movie_onOffSwitch_Surround.Size = new Size(49, 20);
      this.Movie_onOffSwitch_Surround.SwitchedOn = false;
      this.Movie_onOffSwitch_Surround.TabIndex = 6;
      this.Movie_onOffSwitch_Surround.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Movie_onOffSwitch_Surround_SwitchChangeNotify);
      this.Movie_groupBox_Convolver.Controls.Add((Control) this.Movie_irShape_ConvIR);
      this.Movie_groupBox_Convolver.Controls.Add((Control) this.Movie_onOffSwitch_Convolver);
      this.Movie_groupBox_Convolver.Controls.Add((Control) this.Movie_hSlider_ConvIRGain);
      this.Movie_groupBox_Convolver.Controls.Add((Control) this.Movie_openFileBox_ConvIRS);
      this.Movie_groupBox_Convolver.Controls.Add((Control) this.Movie_label_ConvolverIRGain);
      this.Movie_groupBox_Convolver.Location = new Point(312, 6);
      this.Movie_groupBox_Convolver.Name = "Movie_groupBox_Convolver";
      this.Movie_groupBox_Convolver.Size = new Size(288, 179);
      this.Movie_groupBox_Convolver.TabIndex = 12;
      this.Movie_groupBox_Convolver.TabStop = false;
      this.Movie_groupBox_Convolver.Text = "$CONVOLVER";
      this.Movie_irShape_ConvIR.Location = new Point(13, 61);
      this.Movie_irShape_ConvIR.Name = "Movie_irShape_ConvIR";
      this.Movie_irShape_ConvIR.ShapeBackColor = Color.White;
      this.Movie_irShape_ConvIR.ShapeForeColor = Color.Black;
      this.Movie_irShape_ConvIR.Size = new Size(260, 63);
      this.Movie_irShape_ConvIR.TabIndex = 8;
      this.Movie_onOffSwitch_Convolver.BackColor = Color.Transparent;
      this.Movie_onOffSwitch_Convolver.Location = new Point(13, 23);
      this.Movie_onOffSwitch_Convolver.Name = "Movie_onOffSwitch_Convolver";
      this.Movie_onOffSwitch_Convolver.Size = new Size(49, 20);
      this.Movie_onOffSwitch_Convolver.SwitchedOn = false;
      this.Movie_onOffSwitch_Convolver.TabIndex = 5;
      this.Movie_onOffSwitch_Convolver.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Movie_onOffSwitch_Convolver_SwitchChangeNotify);
      this.Movie_hSlider_ConvIRGain.BackColor = SystemColors.Control;
      this.Movie_hSlider_ConvIRGain.Location = new Point(85, 31);
      this.Movie_hSlider_ConvIRGain.MoveDelta = 1U;
      this.Movie_hSlider_ConvIRGain.Name = "Movie_hSlider_ConvIRGain";
      this.Movie_hSlider_ConvIRGain.Position = 0U;
      this.Movie_hSlider_ConvIRGain.PositionFloat = 0.0f;
      this.Movie_hSlider_ConvIRGain.Size = new Size(188, 24);
      this.Movie_hSlider_ConvIRGain.TabIndex = 7;
      this.Movie_hSlider_ConvIRGain.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_ConvIRGain_PositionChangeNotify);
      this.Movie_openFileBox_ConvIRS.BackColor = SystemColors.Control;
      this.Movie_openFileBox_ConvIRS.FilePathName = "";
      this.Movie_openFileBox_ConvIRS.Location = new Point(13, 136);
      this.Movie_openFileBox_ConvIRS.Name = "Movie_openFileBox_ConvIRS";
      this.Movie_openFileBox_ConvIRS.Size = new Size(260, 29);
      this.Movie_openFileBox_ConvIRS.TabIndex = 9;
      this.Movie_openFileBox_ConvIRS.FileChangeNotify += new OpenFileBox.FileChangeEventDelegate(this.Movie_openFileBox_ConvIRS_FileChangeNotify);
      this.Movie_label_ConvolverIRGain.AutoSize = true;
      this.Movie_label_ConvolverIRGain.Location = new Point(95, 16);
      this.Movie_label_ConvolverIRGain.Name = "Movie_label_ConvolverIRGain";
      this.Movie_label_ConvolverIRGain.Size = new Size(119, 12);
      this.Movie_label_ConvolverIRGain.TabIndex = 6;
      this.Movie_label_ConvolverIRGain.Text = "$CONV_IR_GAIN : 0dB";
      this.Movie_hSlider_PostVolume.BackColor = SystemColors.Control;
      this.Movie_hSlider_PostVolume.Location = new Point(21, 118);
      this.Movie_hSlider_PostVolume.MoveDelta = 1U;
      this.Movie_hSlider_PostVolume.Name = "Movie_hSlider_PostVolume";
      this.Movie_hSlider_PostVolume.Position = 0U;
      this.Movie_hSlider_PostVolume.PositionFloat = 0.0f;
      this.Movie_hSlider_PostVolume.Size = new Size(285, 39);
      this.Movie_hSlider_PostVolume.TabIndex = 3;
      this.Movie_hSlider_PostVolume.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_PostVolume_PositionChangeNotify);
      this.Movie_label_PostVolume.AutoSize = true;
      this.Movie_label_PostVolume.Location = new Point(40, 100);
      this.Movie_label_PostVolume.Name = "Movie_label_PostVolume";
      this.Movie_label_PostVolume.Size = new Size(113, 12);
      this.Movie_label_PostVolume.TabIndex = 2;
      this.Movie_label_PostVolume.Text = "$POST_VOLUME : 0dB";
      this.Movie_hSlider_PreVolume.BackColor = SystemColors.Control;
      this.Movie_hSlider_PreVolume.Location = new Point(21, 39);
      this.Movie_hSlider_PreVolume.MoveDelta = 1U;
      this.Movie_hSlider_PreVolume.Name = "Movie_hSlider_PreVolume";
      this.Movie_hSlider_PreVolume.Position = 0U;
      this.Movie_hSlider_PreVolume.PositionFloat = 0.0f;
      this.Movie_hSlider_PreVolume.Size = new Size(285, 39);
      this.Movie_hSlider_PreVolume.TabIndex = 1;
      this.Movie_hSlider_PreVolume.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Movie_hSlider_PreVolume_PositionChangeNotify);
      this.Movie_label_PreVolume.AutoSize = true;
      this.Movie_label_PreVolume.Location = new Point(40, 21);
      this.Movie_label_PreVolume.Name = "Movie_label_PreVolume";
      this.Movie_label_PreVolume.Size = new Size(107, 12);
      this.Movie_label_PreVolume.TabIndex = 0;
      this.Movie_label_PreVolume.Text = "$PRE_VOLUME : 0dB";
      this.Music_singleButton_Compressor.BackColor = SystemColors.Control;
      this.Music_singleButton_Compressor.ButtonText = "$COMPRESSOR_ADJUST";
      this.Music_singleButton_Compressor.Location = new Point(216, 460);
      this.Music_singleButton_Compressor.Name = "Music_singleButton_Compressor";
      this.Music_singleButton_Compressor.Size = new Size(174, 39);
      this.Music_singleButton_Compressor.TabIndex = 21;
      this.Music_singleButton_Compressor.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.Music_singleButton_Compressor_ButtonClickNotify);
      this.Music_singleButton_Equalizer.BackColor = SystemColors.Control;
      this.Music_singleButton_Equalizer.ButtonText = "$EQUALIZER_ADJUST";
      this.Music_singleButton_Equalizer.Location = new Point(216, 404);
      this.Music_singleButton_Equalizer.Name = "Music_singleButton_Equalizer";
      this.Music_singleButton_Equalizer.Size = new Size(174, 39);
      this.Music_singleButton_Equalizer.TabIndex = 20;
      this.Music_singleButton_Equalizer.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.Music_singleButton_Equalizer_ButtonClickNotify);
      this.Music_groupBox_Reverb.Controls.Add((Control) this.Music_singleButton_ReverbPreset);
      this.Music_groupBox_Reverb.Controls.Add((Control) this.Music_hSlider_ReverbMix);
      this.Music_groupBox_Reverb.Controls.Add((Control) this.Music_label_Reverb_Mix);
      this.Music_groupBox_Reverb.Controls.Add((Control) this.Music_hSlider_ReverbEarlyMix);
      this.Music_groupBox_Reverb.Controls.Add((Control) this.Music_label_Reverb_EarlyMix);
      this.Music_groupBox_Reverb.Controls.Add((Control) this.Music_hSlider_ReverbPreDelay);
      this.Music_groupBox_Reverb.Controls.Add((Control) this.Music_label_Reverb_PreDelay);
      this.Music_groupBox_Reverb.Controls.Add((Control) this.Music_hSlider_ReverbDecay);
      this.Music_groupBox_Reverb.Controls.Add((Control) this.Music_label_Reverb_Decay);
      this.Music_groupBox_Reverb.Controls.Add((Control) this.Music_hSlider_ReverbBandWidth);
      this.Music_groupBox_Reverb.Controls.Add((Control) this.Music_label_Reverb_BandWidth);
      this.Music_groupBox_Reverb.Controls.Add((Control) this.Music_hSlider_ReverbDensity);
      this.Music_groupBox_Reverb.Controls.Add((Control) this.Music_label_Reverb_Density);
      this.Music_groupBox_Reverb.Controls.Add((Control) this.Music_hSlider_ReverbDamping);
      this.Music_groupBox_Reverb.Controls.Add((Control) this.Music_label_Reverb_Damping);
      this.Music_groupBox_Reverb.Controls.Add((Control) this.Music_hSlider_ReverbSize);
      this.Music_groupBox_Reverb.Controls.Add((Control) this.Music_label_Reverb_Size);
      this.Music_groupBox_Reverb.Controls.Add((Control) this.Music_onOffSwitch_Reverb);
      this.Music_groupBox_Reverb.Location = new Point(606, 150);
      this.Music_groupBox_Reverb.Name = "Music_groupBox_Reverb";
      this.Music_groupBox_Reverb.Size = new Size(208, 389);
      this.Music_groupBox_Reverb.TabIndex = 19;
      this.Music_groupBox_Reverb.TabStop = false;
      this.Music_groupBox_Reverb.Text = "$REVERB";
      this.Music_singleButton_ReverbPreset.BackColor = SystemColors.Control;
      this.Music_singleButton_ReverbPreset.ButtonText = "$PRESET";
      this.Music_singleButton_ReverbPreset.Location = new Point(121, 14);
      this.Music_singleButton_ReverbPreset.Name = "Music_singleButton_ReverbPreset";
      this.Music_singleButton_ReverbPreset.Size = new Size(81, 29);
      this.Music_singleButton_ReverbPreset.TabIndex = 36;
      this.Music_singleButton_ReverbPreset.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.Music_singleButton_ReverbPreset_ButtonClickNotify);
      this.Music_hSlider_ReverbMix.BackColor = SystemColors.Control;
      this.Music_hSlider_ReverbMix.Location = new Point(24, 356);
      this.Music_hSlider_ReverbMix.MoveDelta = 1U;
      this.Music_hSlider_ReverbMix.Name = "Music_hSlider_ReverbMix";
      this.Music_hSlider_ReverbMix.Position = 0U;
      this.Music_hSlider_ReverbMix.PositionFloat = 0.0f;
      this.Music_hSlider_ReverbMix.Size = new Size(161, 24);
      this.Music_hSlider_ReverbMix.TabIndex = 35;
      this.Music_hSlider_ReverbMix.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Music_hSlider_ReverbMix_PositionChangeNotify);
      this.Music_label_Reverb_Mix.AutoSize = true;
      this.Music_label_Reverb_Mix.Location = new Point(34, 341);
      this.Music_label_Reverb_Mix.Name = "Music_label_Reverb_Mix";
      this.Music_label_Reverb_Mix.Size = new Size(71, 12);
      this.Music_label_Reverb_Mix.TabIndex = 34;
      this.Music_label_Reverb_Mix.Text = "$REVERB_MIX";
      this.Music_hSlider_ReverbEarlyMix.BackColor = SystemColors.Control;
      this.Music_hSlider_ReverbEarlyMix.Location = new Point(24, 314);
      this.Music_hSlider_ReverbEarlyMix.MoveDelta = 1U;
      this.Music_hSlider_ReverbEarlyMix.Name = "Music_hSlider_ReverbEarlyMix";
      this.Music_hSlider_ReverbEarlyMix.Position = 0U;
      this.Music_hSlider_ReverbEarlyMix.PositionFloat = 0.0f;
      this.Music_hSlider_ReverbEarlyMix.Size = new Size(161, 24);
      this.Music_hSlider_ReverbEarlyMix.TabIndex = 33;
      this.Music_hSlider_ReverbEarlyMix.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Music_hSlider_ReverbEarlyMix_PositionChangeNotify);
      this.Music_label_Reverb_EarlyMix.AutoSize = true;
      this.Music_label_Reverb_EarlyMix.Location = new Point(34, 299);
      this.Music_label_Reverb_EarlyMix.Name = "Music_label_Reverb_EarlyMix";
      this.Music_label_Reverb_EarlyMix.Size = new Size(101, 12);
      this.Music_label_Reverb_EarlyMix.TabIndex = 32;
      this.Music_label_Reverb_EarlyMix.Text = "$REVERB_EARLYMIX";
      this.Music_hSlider_ReverbPreDelay.BackColor = SystemColors.Control;
      this.Music_hSlider_ReverbPreDelay.Location = new Point(24, 272);
      this.Music_hSlider_ReverbPreDelay.MoveDelta = 1U;
      this.Music_hSlider_ReverbPreDelay.Name = "Music_hSlider_ReverbPreDelay";
      this.Music_hSlider_ReverbPreDelay.Position = 0U;
      this.Music_hSlider_ReverbPreDelay.PositionFloat = 0.0f;
      this.Music_hSlider_ReverbPreDelay.Size = new Size(161, 24);
      this.Music_hSlider_ReverbPreDelay.TabIndex = 31;
      this.Music_hSlider_ReverbPreDelay.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Music_hSlider_ReverbPreDelay_PositionChangeNotify);
      this.Music_label_Reverb_PreDelay.AutoSize = true;
      this.Music_label_Reverb_PreDelay.Location = new Point(34, 257);
      this.Music_label_Reverb_PreDelay.Name = "Music_label_Reverb_PreDelay";
      this.Music_label_Reverb_PreDelay.Size = new Size(101, 12);
      this.Music_label_Reverb_PreDelay.TabIndex = 30;
      this.Music_label_Reverb_PreDelay.Text = "$REVERB_PREDELAY";
      this.Music_hSlider_ReverbDecay.BackColor = SystemColors.Control;
      this.Music_hSlider_ReverbDecay.Location = new Point(24, 230);
      this.Music_hSlider_ReverbDecay.MoveDelta = 1U;
      this.Music_hSlider_ReverbDecay.Name = "Music_hSlider_ReverbDecay";
      this.Music_hSlider_ReverbDecay.Position = 0U;
      this.Music_hSlider_ReverbDecay.PositionFloat = 0.0f;
      this.Music_hSlider_ReverbDecay.Size = new Size(161, 24);
      this.Music_hSlider_ReverbDecay.TabIndex = 29;
      this.Music_hSlider_ReverbDecay.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Music_hSlider_ReverbDecay_PositionChangeNotify);
      this.Music_label_Reverb_Decay.AutoSize = true;
      this.Music_label_Reverb_Decay.Location = new Point(34, 215);
      this.Music_label_Reverb_Decay.Name = "Music_label_Reverb_Decay";
      this.Music_label_Reverb_Decay.Size = new Size(83, 12);
      this.Music_label_Reverb_Decay.TabIndex = 28;
      this.Music_label_Reverb_Decay.Text = "$REVERB_DECAY";
      this.Music_hSlider_ReverbBandWidth.BackColor = SystemColors.Control;
      this.Music_hSlider_ReverbBandWidth.Location = new Point(24, 188);
      this.Music_hSlider_ReverbBandWidth.MoveDelta = 1U;
      this.Music_hSlider_ReverbBandWidth.Name = "Music_hSlider_ReverbBandWidth";
      this.Music_hSlider_ReverbBandWidth.Position = 0U;
      this.Music_hSlider_ReverbBandWidth.PositionFloat = 0.0f;
      this.Music_hSlider_ReverbBandWidth.Size = new Size(161, 24);
      this.Music_hSlider_ReverbBandWidth.TabIndex = 27;
      this.Music_hSlider_ReverbBandWidth.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Music_hSlider_ReverbBandWidth_PositionChangeNotify);
      this.Music_label_Reverb_BandWidth.AutoSize = true;
      this.Music_label_Reverb_BandWidth.Location = new Point(34, 173);
      this.Music_label_Reverb_BandWidth.Name = "Music_label_Reverb_BandWidth";
      this.Music_label_Reverb_BandWidth.Size = new Size(107, 12);
      this.Music_label_Reverb_BandWidth.TabIndex = 26;
      this.Music_label_Reverb_BandWidth.Text = "$REVERB_BANDWIDTH";
      this.Music_hSlider_ReverbDensity.BackColor = SystemColors.Control;
      this.Music_hSlider_ReverbDensity.Location = new Point(24, 146);
      this.Music_hSlider_ReverbDensity.MoveDelta = 1U;
      this.Music_hSlider_ReverbDensity.Name = "Music_hSlider_ReverbDensity";
      this.Music_hSlider_ReverbDensity.Position = 0U;
      this.Music_hSlider_ReverbDensity.PositionFloat = 0.0f;
      this.Music_hSlider_ReverbDensity.Size = new Size(161, 24);
      this.Music_hSlider_ReverbDensity.TabIndex = 25;
      this.Music_hSlider_ReverbDensity.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Music_hSlider_ReverbDensity_PositionChangeNotify);
      this.Music_label_Reverb_Density.AutoSize = true;
      this.Music_label_Reverb_Density.Location = new Point(34, 131);
      this.Music_label_Reverb_Density.Name = "Music_label_Reverb_Density";
      this.Music_label_Reverb_Density.Size = new Size(95, 12);
      this.Music_label_Reverb_Density.TabIndex = 24;
      this.Music_label_Reverb_Density.Text = "$REVERB_DENSITY";
      this.Music_hSlider_ReverbDamping.BackColor = SystemColors.Control;
      this.Music_hSlider_ReverbDamping.Location = new Point(24, 104);
      this.Music_hSlider_ReverbDamping.MoveDelta = 1U;
      this.Music_hSlider_ReverbDamping.Name = "Music_hSlider_ReverbDamping";
      this.Music_hSlider_ReverbDamping.Position = 0U;
      this.Music_hSlider_ReverbDamping.PositionFloat = 0.0f;
      this.Music_hSlider_ReverbDamping.Size = new Size(161, 24);
      this.Music_hSlider_ReverbDamping.TabIndex = 23;
      this.Music_hSlider_ReverbDamping.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Music_hSlider_ReverbDamping_PositionChangeNotify);
      this.Music_label_Reverb_Damping.AutoSize = true;
      this.Music_label_Reverb_Damping.Location = new Point(34, 89);
      this.Music_label_Reverb_Damping.Name = "Music_label_Reverb_Damping";
      this.Music_label_Reverb_Damping.Size = new Size(95, 12);
      this.Music_label_Reverb_Damping.TabIndex = 22;
      this.Music_label_Reverb_Damping.Text = "$REVERB_DAMPING";
      this.Music_hSlider_ReverbSize.BackColor = SystemColors.Control;
      this.Music_hSlider_ReverbSize.Location = new Point(24, 64);
      this.Music_hSlider_ReverbSize.MoveDelta = 1U;
      this.Music_hSlider_ReverbSize.Name = "Music_hSlider_ReverbSize";
      this.Music_hSlider_ReverbSize.Position = 0U;
      this.Music_hSlider_ReverbSize.PositionFloat = 0.0f;
      this.Music_hSlider_ReverbSize.Size = new Size(161, 24);
      this.Music_hSlider_ReverbSize.TabIndex = 21;
      this.Music_hSlider_ReverbSize.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Music_hSlider_ReverbSize_PositionChangeNotify);
      this.Music_label_Reverb_Size.AutoSize = true;
      this.Music_label_Reverb_Size.Location = new Point(34, 49);
      this.Music_label_Reverb_Size.Name = "Music_label_Reverb_Size";
      this.Music_label_Reverb_Size.Size = new Size(77, 12);
      this.Music_label_Reverb_Size.TabIndex = 20;
      this.Music_label_Reverb_Size.Text = "$REVERB_SIZE";
      this.Music_onOffSwitch_Reverb.BackColor = Color.Transparent;
      this.Music_onOffSwitch_Reverb.Location = new Point(13, 23);
      this.Music_onOffSwitch_Reverb.Name = "Music_onOffSwitch_Reverb";
      this.Music_onOffSwitch_Reverb.Size = new Size(49, 20);
      this.Music_onOffSwitch_Reverb.SwitchedOn = false;
      this.Music_onOffSwitch_Reverb.TabIndex = 7;
      this.Music_onOffSwitch_Reverb.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Music_onOffSwitch_Reverb_SwitchChangeNotify);
      this.Music_groupBox_Cure.Controls.Add((Control) this.Music_buttonBox_CureLevel);
      this.Music_groupBox_Cure.Controls.Add((Control) this.Music_onOffSwitch_Cure);
      this.Music_groupBox_Cure.Controls.Add((Control) this.Music_label_Tube);
      this.Music_groupBox_Cure.Controls.Add((Control) this.Music_onOffSwitch_Tube);
      this.Music_groupBox_Cure.Location = new Point(411, 206);
      this.Music_groupBox_Cure.Name = "Music_groupBox_Cure";
      this.Music_groupBox_Cure.Size = new Size(189, 148);
      this.Music_groupBox_Cure.TabIndex = 18;
      this.Music_groupBox_Cure.TabStop = false;
      this.Music_groupBox_Cure.Text = "$CURE";
      this.Music_buttonBox_CureLevel.BackColor = SystemColors.Control;
      this.Music_buttonBox_CureLevel.Location = new Point(68, 17);
      this.Music_buttonBox_CureLevel.Name = "Music_buttonBox_CureLevel";
      this.Music_buttonBox_CureLevel.Size = new Size(106, 70);
      this.Music_buttonBox_CureLevel.TabIndex = 18;
      this.Music_buttonBox_CureLevel.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(this.Music_buttonBox_CureLevel_ItemSelectedNotify);
      this.Music_onOffSwitch_Cure.BackColor = Color.Transparent;
      this.Music_onOffSwitch_Cure.Location = new Point(13, 23);
      this.Music_onOffSwitch_Cure.Name = "Music_onOffSwitch_Cure";
      this.Music_onOffSwitch_Cure.Size = new Size(49, 20);
      this.Music_onOffSwitch_Cure.SwitchedOn = false;
      this.Music_onOffSwitch_Cure.TabIndex = 17;
      this.Music_onOffSwitch_Cure.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Music_onOffSwitch_Cure_SwitchChangeNotify);
      this.Music_label_Tube.AutoSize = true;
      this.Music_label_Tube.Location = new Point(11, 112);
      this.Music_label_Tube.Name = "Music_label_Tube";
      this.Music_label_Tube.Size = new Size(35, 12);
      this.Music_label_Tube.TabIndex = 14;
      this.Music_label_Tube.Text = "$TUBE";
      this.Music_onOffSwitch_Tube.BackColor = Color.Transparent;
      this.Music_onOffSwitch_Tube.Location = new Point(121, 105);
      this.Music_onOffSwitch_Tube.Name = "Music_onOffSwitch_Tube";
      this.Music_onOffSwitch_Tube.Size = new Size(53, 26);
      this.Music_onOffSwitch_Tube.SwitchedOn = false;
      this.Music_onOffSwitch_Tube.TabIndex = 15;
      this.Music_onOffSwitch_Tube.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Music_onOffSwitch_Tube_SwitchChangeNotify);
      this.Music_groupBox_Clarity.Controls.Add((Control) this.Music_buttonBox_ClarityMode);
      this.Music_groupBox_Clarity.Controls.Add((Control) this.Music_hSlider_Clarity);
      this.Music_groupBox_Clarity.Controls.Add((Control) this.Music_label_Clarity);
      this.Music_groupBox_Clarity.Controls.Add((Control) this.Music_onOffSwitch_Clarity);
      this.Music_groupBox_Clarity.Location = new Point(216, 206);
      this.Music_groupBox_Clarity.Name = "Music_groupBox_Clarity";
      this.Music_groupBox_Clarity.Size = new Size(189, 148);
      this.Music_groupBox_Clarity.TabIndex = 17;
      this.Music_groupBox_Clarity.TabStop = false;
      this.Music_groupBox_Clarity.Text = "$CLARITY";
      this.Music_buttonBox_ClarityMode.BackColor = SystemColors.Control;
      this.Music_buttonBox_ClarityMode.Location = new Point(68, 17);
      this.Music_buttonBox_ClarityMode.Name = "Music_buttonBox_ClarityMode";
      this.Music_buttonBox_ClarityMode.Size = new Size(106, 70);
      this.Music_buttonBox_ClarityMode.TabIndex = 18;
      this.Music_buttonBox_ClarityMode.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(this.Music_buttonBox_ClarityMode_ItemSelectedNotify);
      this.Music_hSlider_Clarity.BackColor = SystemColors.Control;
      this.Music_hSlider_Clarity.Location = new Point(13, 115);
      this.Music_hSlider_Clarity.MoveDelta = 1U;
      this.Music_hSlider_Clarity.Name = "Music_hSlider_Clarity";
      this.Music_hSlider_Clarity.Position = 0U;
      this.Music_hSlider_Clarity.PositionFloat = 0.0f;
      this.Music_hSlider_Clarity.Size = new Size(161, 24);
      this.Music_hSlider_Clarity.TabIndex = 21;
      this.Music_hSlider_Clarity.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Music_hSlider_Clarity_PositionChangeNotify);
      this.Music_label_Clarity.AutoSize = true;
      this.Music_label_Clarity.Location = new Point(23, 100);
      this.Music_label_Clarity.Name = "Music_label_Clarity";
      this.Music_label_Clarity.Size = new Size(89, 12);
      this.Music_label_Clarity.TabIndex = 20;
      this.Music_label_Clarity.Text = "$CLARITY : 0dB";
      this.Music_onOffSwitch_Clarity.BackColor = Color.Transparent;
      this.Music_onOffSwitch_Clarity.Location = new Point(13, 23);
      this.Music_onOffSwitch_Clarity.Name = "Music_onOffSwitch_Clarity";
      this.Music_onOffSwitch_Clarity.Size = new Size(49, 20);
      this.Music_onOffSwitch_Clarity.SwitchedOn = false;
      this.Music_onOffSwitch_Clarity.TabIndex = 17;
      this.Music_onOffSwitch_Clarity.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Music_onOffSwitch_Clarity_SwitchChangeNotify);
      this.Music_groupBox_Bass.Controls.Add((Control) this.Music_hSlider_BassGain);
      this.Music_groupBox_Bass.Controls.Add((Control) this.Music_label_Bass_Gain);
      this.Music_groupBox_Bass.Controls.Add((Control) this.Music_hSlider_BassSpkSize);
      this.Music_groupBox_Bass.Controls.Add((Control) this.Music_label_Bass_SpkSize);
      this.Music_groupBox_Bass.Controls.Add((Control) this.Music_onOffSwitch_Bass);
      this.Music_groupBox_Bass.Location = new Point(21, 206);
      this.Music_groupBox_Bass.Name = "Music_groupBox_Bass";
      this.Music_groupBox_Bass.Size = new Size(189, 148);
      this.Music_groupBox_Bass.TabIndex = 16;
      this.Music_groupBox_Bass.TabStop = false;
      this.Music_groupBox_Bass.Text = "$BASS";
      this.Music_hSlider_BassGain.BackColor = SystemColors.Control;
      this.Music_hSlider_BassGain.Location = new Point(13, 115);
      this.Music_hSlider_BassGain.MoveDelta = 1U;
      this.Music_hSlider_BassGain.Name = "Music_hSlider_BassGain";
      this.Music_hSlider_BassGain.Position = 0U;
      this.Music_hSlider_BassGain.PositionFloat = 0.0f;
      this.Music_hSlider_BassGain.Size = new Size(161, 24);
      this.Music_hSlider_BassGain.TabIndex = 21;
      this.Music_hSlider_BassGain.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Music_hSlider_BassGain_PositionChangeNotify);
      this.Music_label_Bass_Gain.AutoSize = true;
      this.Music_label_Bass_Gain.Location = new Point(23, 100);
      this.Music_label_Bass_Gain.Name = "Music_label_Bass_Gain";
      this.Music_label_Bass_Gain.Size = new Size(101, 12);
      this.Music_label_Bass_Gain.TabIndex = 20;
      this.Music_label_Bass_Gain.Text = "$BASS_GAIN : 0dB";
      this.Music_hSlider_BassSpkSize.BackColor = SystemColors.Control;
      this.Music_hSlider_BassSpkSize.Location = new Point(13, 73);
      this.Music_hSlider_BassSpkSize.MoveDelta = 1U;
      this.Music_hSlider_BassSpkSize.Name = "Music_hSlider_BassSpkSize";
      this.Music_hSlider_BassSpkSize.Position = 0U;
      this.Music_hSlider_BassSpkSize.PositionFloat = 0.0f;
      this.Music_hSlider_BassSpkSize.Size = new Size(161, 24);
      this.Music_hSlider_BassSpkSize.TabIndex = 19;
      this.Music_hSlider_BassSpkSize.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Music_hSlider_BassSpkSize_PositionChangeNotify);
      this.Music_label_Bass_SpkSize.AutoSize = true;
      this.Music_label_Bass_SpkSize.Location = new Point(23, 58);
      this.Music_label_Bass_SpkSize.Name = "Music_label_Bass_SpkSize";
      this.Music_label_Bass_SpkSize.Size = new Size(83, 12);
      this.Music_label_Bass_SpkSize.TabIndex = 18;
      this.Music_label_Bass_SpkSize.Text = "$BASS_SPKSIZE";
      this.Music_onOffSwitch_Bass.BackColor = Color.Transparent;
      this.Music_onOffSwitch_Bass.Location = new Point(13, 23);
      this.Music_onOffSwitch_Bass.Name = "Music_onOffSwitch_Bass";
      this.Music_onOffSwitch_Bass.Size = new Size(49, 20);
      this.Music_onOffSwitch_Bass.SwitchedOn = false;
      this.Music_onOffSwitch_Bass.TabIndex = 17;
      this.Music_onOffSwitch_Bass.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Music_onOffSwitch_Bass_SwitchChangeNotify);
      this.Music_groupBox_Surround.Controls.Add((Control) this.Music_buttonBox_SurroundRoomSize);
      this.Music_groupBox_Surround.Controls.Add((Control) this.Music_onOffSwitch_Surround);
      this.Music_groupBox_Surround.Location = new Point(606, 6);
      this.Music_groupBox_Surround.Name = "Music_groupBox_Surround";
      this.Music_groupBox_Surround.Size = new Size(208, 138);
      this.Music_groupBox_Surround.TabIndex = 13;
      this.Music_groupBox_Surround.TabStop = false;
      this.Music_groupBox_Surround.Text = "$SURROUND";
      this.Music_buttonBox_SurroundRoomSize.BackColor = SystemColors.Control;
      this.Music_buttonBox_SurroundRoomSize.Location = new Point(68, 23);
      this.Music_buttonBox_SurroundRoomSize.Name = "Music_buttonBox_SurroundRoomSize";
      this.Music_buttonBox_SurroundRoomSize.Size = new Size((int) sbyte.MaxValue, 101);
      this.Music_buttonBox_SurroundRoomSize.TabIndex = 7;
      this.Music_buttonBox_SurroundRoomSize.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(this.Music_buttonBox_SurroundRoomSize_ItemSelectedNotify);
      this.Music_onOffSwitch_Surround.BackColor = Color.Transparent;
      this.Music_onOffSwitch_Surround.Location = new Point(13, 23);
      this.Music_onOffSwitch_Surround.Name = "Music_onOffSwitch_Surround";
      this.Music_onOffSwitch_Surround.Size = new Size(49, 20);
      this.Music_onOffSwitch_Surround.SwitchedOn = false;
      this.Music_onOffSwitch_Surround.TabIndex = 6;
      this.Music_onOffSwitch_Surround.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Music_onOffSwitch_Surround_SwitchChangeNotify);
      this.Music_groupBox_Convolver.Controls.Add((Control) this.Music_irShape_ConvIR);
      this.Music_groupBox_Convolver.Controls.Add((Control) this.Music_onOffSwitch_Convolver);
      this.Music_groupBox_Convolver.Controls.Add((Control) this.Music_hSlider_ConvIRGain);
      this.Music_groupBox_Convolver.Controls.Add((Control) this.Music_openFileBox_ConvIRS);
      this.Music_groupBox_Convolver.Controls.Add((Control) this.Music_label_ConvolverIRGain);
      this.Music_groupBox_Convolver.Location = new Point(312, 6);
      this.Music_groupBox_Convolver.Name = "Music_groupBox_Convolver";
      this.Music_groupBox_Convolver.Size = new Size(288, 179);
      this.Music_groupBox_Convolver.TabIndex = 12;
      this.Music_groupBox_Convolver.TabStop = false;
      this.Music_groupBox_Convolver.Text = "$CONVOLVER";
      this.Music_irShape_ConvIR.Location = new Point(13, 61);
      this.Music_irShape_ConvIR.Name = "Music_irShape_ConvIR";
      this.Music_irShape_ConvIR.ShapeBackColor = Color.White;
      this.Music_irShape_ConvIR.ShapeForeColor = Color.Black;
      this.Music_irShape_ConvIR.Size = new Size(260, 63);
      this.Music_irShape_ConvIR.TabIndex = 8;
      this.Music_onOffSwitch_Convolver.BackColor = Color.Transparent;
      this.Music_onOffSwitch_Convolver.Location = new Point(13, 23);
      this.Music_onOffSwitch_Convolver.Name = "Music_onOffSwitch_Convolver";
      this.Music_onOffSwitch_Convolver.Size = new Size(49, 20);
      this.Music_onOffSwitch_Convolver.SwitchedOn = false;
      this.Music_onOffSwitch_Convolver.TabIndex = 5;
      this.Music_onOffSwitch_Convolver.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.Music_onOffSwitch_Convolver_SwitchChangeNotify);
      this.Music_hSlider_ConvIRGain.BackColor = SystemColors.Control;
      this.Music_hSlider_ConvIRGain.Location = new Point(85, 31);
      this.Music_hSlider_ConvIRGain.MoveDelta = 1U;
      this.Music_hSlider_ConvIRGain.Name = "Music_hSlider_ConvIRGain";
      this.Music_hSlider_ConvIRGain.Position = 0U;
      this.Music_hSlider_ConvIRGain.PositionFloat = 0.0f;
      this.Music_hSlider_ConvIRGain.Size = new Size(188, 24);
      this.Music_hSlider_ConvIRGain.TabIndex = 7;
      this.Music_hSlider_ConvIRGain.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Music_hSlider_ConvIRGain_PositionChangeNotify);
      this.Music_openFileBox_ConvIRS.BackColor = SystemColors.Control;
      this.Music_openFileBox_ConvIRS.FilePathName = "";
      this.Music_openFileBox_ConvIRS.Location = new Point(13, 136);
      this.Music_openFileBox_ConvIRS.Name = "Music_openFileBox_ConvIRS";
      this.Music_openFileBox_ConvIRS.Size = new Size(260, 29);
      this.Music_openFileBox_ConvIRS.TabIndex = 9;
      this.Music_openFileBox_ConvIRS.FileChangeNotify += new OpenFileBox.FileChangeEventDelegate(this.Music_openFileBox_ConvIRS_FileChangeNotify);
      this.Music_label_ConvolverIRGain.AutoSize = true;
      this.Music_label_ConvolverIRGain.Location = new Point(95, 16);
      this.Music_label_ConvolverIRGain.Name = "Music_label_ConvolverIRGain";
      this.Music_label_ConvolverIRGain.Size = new Size(119, 12);
      this.Music_label_ConvolverIRGain.TabIndex = 6;
      this.Music_label_ConvolverIRGain.Text = "$CONV_IR_GAIN : 0dB";
      this.Music_hSlider_PostVolume.BackColor = SystemColors.Control;
      this.Music_hSlider_PostVolume.Location = new Point(21, 118);
      this.Music_hSlider_PostVolume.MoveDelta = 1U;
      this.Music_hSlider_PostVolume.Name = "Music_hSlider_PostVolume";
      this.Music_hSlider_PostVolume.Position = 0U;
      this.Music_hSlider_PostVolume.PositionFloat = 0.0f;
      this.Music_hSlider_PostVolume.Size = new Size(285, 39);
      this.Music_hSlider_PostVolume.TabIndex = 3;
      this.Music_hSlider_PostVolume.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Music_hSlider_PostVolume_PositionChangeNotify);
      this.Music_label_PostVolume.AutoSize = true;
      this.Music_label_PostVolume.Location = new Point(40, 100);
      this.Music_label_PostVolume.Name = "Music_label_PostVolume";
      this.Music_label_PostVolume.Size = new Size(113, 12);
      this.Music_label_PostVolume.TabIndex = 2;
      this.Music_label_PostVolume.Text = "$POST_VOLUME : 0dB";
      this.Music_hSlider_PreVolume.BackColor = SystemColors.Control;
      this.Music_hSlider_PreVolume.Location = new Point(21, 39);
      this.Music_hSlider_PreVolume.MoveDelta = 1U;
      this.Music_hSlider_PreVolume.Name = "Music_hSlider_PreVolume";
      this.Music_hSlider_PreVolume.Position = 0U;
      this.Music_hSlider_PreVolume.PositionFloat = 0.0f;
      this.Music_hSlider_PreVolume.Size = new Size(285, 39);
      this.Music_hSlider_PreVolume.TabIndex = 1;
      this.Music_hSlider_PreVolume.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(this.Music_hSlider_PreVolume_PositionChangeNotify);
      this.Music_label_PreVolume.AutoSize = true;
      this.Music_label_PreVolume.Location = new Point(40, 21);
      this.Music_label_PreVolume.Name = "Music_label_PreVolume";
      this.Music_label_PreVolume.Size = new Size(107, 12);
      this.Music_label_PreVolume.TabIndex = 0;
      this.Music_label_PreVolume.Text = "$PRE_VOLUME : 0dB";
      this.label_Copyright.Location = new Point(472, 604);
      this.label_Copyright.Name = "label_Copyright";
      this.label_Copyright.Size = new Size(555, 23);
      this.label_Copyright.TabIndex = 6;
      this.label_Copyright.Text = "$COPYRIGHT";
      this.label_Copyright.TextAlign = ContentAlignment.MiddleRight;
      this.notifyIcon_Main.ContextMenuStrip = this.contextMenuStrip_TrayMenu;
      this.notifyIcon_Main.Icon = (Icon) componentResourceManager.GetObject("notifyIcon_Main.Icon");
      this.notifyIcon_Main.Text = "ViPER4Windows";
      this.notifyIcon_Main.MouseUp += new MouseEventHandler(this.notifyIcon_Main_MouseUp);
      this.contextMenuStrip_TrayMenu.Name = "contextMenuStrip_TrayMenu";
      this.contextMenuStrip_TrayMenu.Size = new Size(61, 4);
      this.singleButton_SavePreset.BackColor = SystemColors.Control;
      this.singleButton_SavePreset.ButtonText = "$SAVE_PRESET";
      this.singleButton_SavePreset.Location = new Point(37, 560);
      this.singleButton_SavePreset.Name = "singleButton_SavePreset";
      this.singleButton_SavePreset.Size = new Size(112, 40);
      this.singleButton_SavePreset.TabIndex = 8;
      this.singleButton_SavePreset.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_SavePreset_ButtonClickNotify);
      this.singleButton_LoadPreset.BackColor = SystemColors.Control;
      this.singleButton_LoadPreset.ButtonText = "$LOAD_PRESET";
      this.singleButton_LoadPreset.Location = new Point(37, 514);
      this.singleButton_LoadPreset.Name = "singleButton_LoadPreset";
      this.singleButton_LoadPreset.Size = new Size(112, 40);
      this.singleButton_LoadPreset.TabIndex = 7;
      this.singleButton_LoadPreset.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(this.singleButton_LoadPreset_ButtonClickNotify);
      this.buttonBox_Mode.BackColor = SystemColors.Control;
      this.buttonBox_Mode.Location = new Point(16, 312);
      this.buttonBox_Mode.Name = "buttonBox_Mode";
      this.buttonBox_Mode.Size = new Size(152, 170);
      this.buttonBox_Mode.TabIndex = 3;
      this.buttonBox_Mode.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(this.buttonBox_Mode_ItemSelectedNotify);
      this.onOffSwitch_Master.BackColor = Color.Transparent;
      this.onOffSwitch_Master.Location = new Point(50, 266);
      this.onOffSwitch_Master.Name = "onOffSwitch_Master";
      this.onOffSwitch_Master.Size = new Size(81, 28);
      this.onOffSwitch_Master.SwitchedOn = false;
      this.onOffSwitch_Master.TabIndex = 2;
      this.onOffSwitch_Master.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(this.onOffSwitch_Master_SwitchChangeNotify);
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1042, 633);
      this.Controls.Add((Control) this.singleButton_SavePreset);
      this.Controls.Add((Control) this.singleButton_LoadPreset);
      this.Controls.Add((Control) this.label_Copyright);
      this.Controls.Add((Control) this.groupBox_Main);
      this.Controls.Add((Control) this.buttonBox_Mode);
      this.Controls.Add((Control) this.onOffSwitch_Master);
      this.Controls.Add((Control) this.label_MasterPower);
      this.Controls.Add((Control) this.pictureBox_Logo);
      this.Controls.Add((Control) this.menuStrip_Main);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MainMenuStrip = this.menuStrip_Main;
      this.MaximizeBox = false;
      this.Name = nameof (frmMain);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "ViPER4Windows";
      this.FormClosing += new FormClosingEventHandler(this.frmMain_FormClosing);
      this.Load += new EventHandler(this.frmMain_Load);
      this.SizeChanged += new EventHandler(this.frmMain_SizeChanged);
      ((ISupportInitialize) this.pictureBox_Logo).EndInit();
      this.menuStrip_Main.ResumeLayout(false);
      this.menuStrip_Main.PerformLayout();
      this.groupBox_Main.ResumeLayout(false);
      this.panel_Freestyle.ResumeLayout(false);
      this.panel_Freestyle.PerformLayout();
      this.Freestyle_groupBox_SmartVolume.ResumeLayout(false);
      this.Freestyle_groupBox_SmartVolume.PerformLayout();
      this.Freestyle_groupBox_3DSurround.ResumeLayout(false);
      this.Freestyle_groupBox_3DSurround.PerformLayout();
      this.Freestyle_groupBox_Reverb.ResumeLayout(false);
      this.Freestyle_groupBox_Reverb.PerformLayout();
      this.Freestyle_groupBox_Cure.ResumeLayout(false);
      this.Freestyle_groupBox_Cure.PerformLayout();
      this.Freestyle_groupBox_Clarity.ResumeLayout(false);
      this.Freestyle_groupBox_Clarity.PerformLayout();
      this.Freestyle_groupBox_Bass.ResumeLayout(false);
      this.Freestyle_groupBox_Bass.PerformLayout();
      this.Freestyle_groupBox_VHESurround.ResumeLayout(false);
      this.Freestyle_groupBox_Convolver.ResumeLayout(false);
      this.Freestyle_groupBox_Convolver.PerformLayout();
      this.panel_MusicMode.ResumeLayout(false);
      this.panel_MusicMode.PerformLayout();
      this.panel_MovieMode.ResumeLayout(false);
      this.panel_MovieMode.PerformLayout();
      this.Movie_groupBox_SmartVolume.ResumeLayout(false);
      this.Movie_groupBox_SmartVolume.PerformLayout();
      this.Movie_groupBox_Reverb.ResumeLayout(false);
      this.Movie_groupBox_Reverb.PerformLayout();
      this.Movie_groupBox_Clarity.ResumeLayout(false);
      this.Movie_groupBox_Clarity.PerformLayout();
      this.Movie_groupBox_Bass.ResumeLayout(false);
      this.Movie_groupBox_Bass.PerformLayout();
      this.Movie_groupBox_Surround.ResumeLayout(false);
      this.Movie_groupBox_Surround.PerformLayout();
      this.Movie_groupBox_Convolver.ResumeLayout(false);
      this.Movie_groupBox_Convolver.PerformLayout();
      this.Music_groupBox_Reverb.ResumeLayout(false);
      this.Music_groupBox_Reverb.PerformLayout();
      this.Music_groupBox_Cure.ResumeLayout(false);
      this.Music_groupBox_Cure.PerformLayout();
      this.Music_groupBox_Clarity.ResumeLayout(false);
      this.Music_groupBox_Clarity.PerformLayout();
      this.Music_groupBox_Bass.ResumeLayout(false);
      this.Music_groupBox_Bass.PerformLayout();
      this.Music_groupBox_Surround.ResumeLayout(false);
      this.Music_groupBox_Convolver.ResumeLayout(false);
      this.Music_groupBox_Convolver.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
