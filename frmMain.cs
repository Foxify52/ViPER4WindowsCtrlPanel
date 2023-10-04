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
    public class FrmMain : Form
    {
        private static string m_szLanguagePath = "";
        private static string m_szLanguageFile = "";
        private static string m_szLanguageName = "";
        private readonly string m_szLocalPresetFileName = "LocalPreset.bin";
        private readonly string m_szImpulseResponsePath = "ImpulseResponse";
        private readonly string m_szUserPresetPath = "Presets";
        private readonly bool m_bArgvStartupToMinimized;
        private readonly string m_szLocalPreset = "";
        private string m_szIRSPath = "";
        private string m_szPresetsPath = "";
        private bool m_bCloseToTray;
        private RuntimeUtils.ConfigProxy.ParamOfBaseSystem m_paramBaseSystem = new RuntimeUtils.ConfigProxy.ParamOfBaseSystem();
        private RuntimeUtils.ConfigProxy.ParamOfMusicMode m_paramMusicMode = new RuntimeUtils.ConfigProxy.ParamOfMusicMode();
        private RuntimeUtils.ConfigProxy.ParamOfMovieMode m_paramMovieMode = new RuntimeUtils.ConfigProxy.ParamOfMovieMode();
        private RuntimeUtils.ConfigProxy.ParamOfFreestyle m_paramFreestyle = new RuntimeUtils.ConfigProxy.ParamOfFreestyle();
        private readonly RuntimeUtils.ConfigProxy m_cpConfigProxy;
        private readonly List<TrayMenuPreset> m_lstTrayMenuPreset = new List<TrayMenuPreset>();
        private IContainer components;
        private PictureBox pictureBox_Logo;
        private Label label_MasterPower;
        private OnOffSwitch onOffSwitch_Master;
        private ButtonBox ButtonBox_Mode;
        private MenuStrip menuStrip_Main;
        private ToolStripMenuItem ToolStripMenuItem_Language;
        private ToolStripMenuItem ToolStripMenuItem_Setting;
        private ToolStripMenuItem ToolStripMenuItem_Help;
        private ToolStripMenuItem ToolStripMenuItem_CheckUpdate;
        private ToolStripMenuItem ToolStripMenuItem_AboutV4W;
        private GroupBox groupBox_Main;
        private Label label_Copyright;
        private ToolStripMenuItem ToolStripMenuItem_LatencySetting;
        private ToolStripMenuItem ToolStripMenuItem_ResetEffect;
        private Panel panel_MusicMode;
        private ToolStripMenuItem ToolStripMenuItem_ChannelPan;
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
        private ButtonBox Music_ButtonBox_SurroundRoomSize;
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
        private ButtonBox Music_ButtonBox_ClarityMode;
        private GroupBox Music_groupBox_Cure;
        private ButtonBox Music_ButtonBox_CureLevel;
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
        private SingleButton Music_SingleButton_ReverbPreset;
        private SingleButton Music_SingleButton_Equalizer;
        private SingleButton Music_SingleButton_Compressor;
        private SingleButton SingleButton_LoadPreset;
        private SingleButton SingleButton_SavePreset;
        private Panel panel_MovieMode;
        private SingleButton Movie_SingleButton_Compressor;
        private SingleButton Movie_SingleButton_Equalizer;
        private GroupBox Movie_groupBox_Reverb;
        private SingleButton Movie_SingleButton_ReverbPreset;
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
        private SingleButton Freestyle_SingleButton_Compressor;
        private SingleButton Freestyle_SingleButton_Equalizer;
        private GroupBox Freestyle_groupBox_Reverb;
        private SingleButton Freestyle_SingleButton_ReverbPreset;
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
        private ButtonBox Freestyle_ButtonBox_CureLevel;
        private OnOffSwitch Freestyle_onOffSwitch_Cure;
        private Label Freestyle_label_Tube;
        private OnOffSwitch Freestyle_onOffSwitch_Tube;
        private GroupBox Freestyle_groupBox_Clarity;
        private ButtonBox Freestyle_ButtonBox_ClarityMode;
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
        private ButtonBox Freestyle_ButtonBox_SurroundVHERoomSize;
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
        private ButtonBox Freestyle_ButtonBox_BassMode;
        private GroupBox Freestyle_groupBox_SmartVolume;
        private HSlider Freestyle_hSlider_SmartVolumeLevel;
        private Label Freestyle_label_SmartVolume_Level;
        private HSlider Freestyle_hSlider_SmartVolumeMaxLevel;
        private Label Freestyle_label_SmartVolume_MaxLevel;
        private HSlider Freestyle_hSlider_SmartVolumeRatio;
        private Label Freestyle_label_SmartVolume_ControlStrength;
        private OnOffSwitch Freestyle_onOffSwitch_SmartVolume;
        private ToolStripMenuItem ToolStripMenuItem_Virtualization;
        private NotifyIcon notifyIcon_Main;
        private ToolStripMenuItem ToolStripMenuItem_Settings;
        private ContextMenuStrip contextMenuStrip_TrayMenu;

        public static void SetLanguage(string szLanguagePath, string szLanguageFile)
        {
            m_szLanguagePath = szLanguagePath;
            m_szLanguageFile = szLanguageFile;
            if (m_szLanguagePath == "" || m_szLanguageFile == "")
                m_szLanguageName = "";
            else
                m_szLanguageName = new ConfigFile(szLanguageFile).ReadConfig("$LANGUAGE_NAME");
        }

        public FrmMain(string[] szArgs)
        {
            InitializeComponent();
            m_bArgvStartupToMinimized = false;
            if (szArgs != null)
            {
                int length = szArgs.Length;
            }
            m_szLocalPreset = AppDomain.CurrentDomain.BaseDirectory;
            if (!m_szLocalPreset.EndsWith("\\"))
                m_szLocalPreset += "\\";
            m_szLocalPreset += m_szLocalPresetFileName;
            m_szIRSPath = AppDomain.CurrentDomain.BaseDirectory;
            if (!m_szIRSPath.EndsWith("\\"))
                m_szIRSPath += "\\";
            FrmMain frmMain1 = this;
            frmMain1.m_szIRSPath = frmMain1.m_szIRSPath + m_szImpulseResponsePath + "\\";
            if (!Directory.Exists(m_szIRSPath))
            {
                try
                {
                    Directory.CreateDirectory(m_szIRSPath);
                }
                catch
                {
                }
            }
            m_szPresetsPath = AppDomain.CurrentDomain.BaseDirectory;
            if (!m_szPresetsPath.EndsWith("\\"))
                m_szPresetsPath += "\\";
            FrmMain frmMain2 = this;
            frmMain2.m_szPresetsPath = frmMain2.m_szPresetsPath + m_szUserPresetPath + "\\";
            if (!Directory.Exists(m_szPresetsPath))
            {
                try
                {
                    Directory.CreateDirectory(m_szPresetsPath);
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
            m_bCloseToTray = !string.IsNullOrEmpty(str1) && str1.ToUpper() == "TRUE";
            m_lstTrayMenuPreset.Clear();
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
                                    m_lstTrayMenuPreset.Add(new TrayMenuPreset(szName, nMode, szFile));
                            }
                        }
                    }
                }
                catch
                {
                    m_lstTrayMenuPreset.Clear();
                }
            }
            string config = RegHelper.GetConfig();
            if (!RuntimeUtils.ConfigProxy.CheckConfigVersion(config))
                RuntimeUtils.ConfigProxy.UpdateConfigToCurrent(config);
            m_cpConfigProxy = new RuntimeUtils.ConfigProxy(config);
            Parameters.LoadDefaultParameter(ref m_paramBaseSystem);
            Parameters.LoadDefaultParameter(ref m_paramMusicMode);
            Parameters.LoadDefaultParameter(ref m_paramMovieMode);
            Parameters.LoadDefaultParameter(ref m_paramFreestyle);
            if (!Parameters.ReadPreset(m_szLocalPreset, ref m_paramBaseSystem, ref m_paramMusicMode, ref m_paramMovieMode, ref m_paramFreestyle, out bool bPBaseSystem, out bool bPMusicMode, out bool bPMovieMode, out bool bPFreestyle))
            {
                Parameters.LoadDefaultParameter(ref m_paramBaseSystem);
                Parameters.LoadDefaultParameter(ref m_paramMusicMode);
                Parameters.LoadDefaultParameter(ref m_paramMovieMode);
                Parameters.LoadDefaultParameter(ref m_paramFreestyle);
            }
            else
            {
                if (!bPBaseSystem)
                    Parameters.LoadDefaultParameter(ref m_paramBaseSystem);
                if (!bPMusicMode)
                    Parameters.LoadDefaultParameter(ref m_paramMusicMode);
                if (!bPMovieMode)
                    Parameters.LoadDefaultParameter(ref m_paramMovieMode);
                if (!bPFreestyle)
                    Parameters.LoadDefaultParameter(ref m_paramFreestyle);
            }
            m_cpConfigProxy.UpdateParameter(m_paramBaseSystem);
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
            ToolStripMenuItem_Language.Text = GlobalMessages.MENU_LANGUAGE;
            ToolStripMenuItem_Setting.Text = GlobalMessages.MENU_SETTING;
            ToolStripMenuItem_LatencySetting.Text = GlobalMessages.LATENCY_SETTING;
            ToolStripMenuItem_ChannelPan.Text = GlobalMessages.CHANNEL_PAN;
            ToolStripMenuItem_Virtualization.Text = GlobalMessages.VIRTUALIZATION;
            ToolStripMenuItem_ResetEffect.Text = GlobalMessages.RESET_EFFECT;
            ToolStripMenuItem_Settings.Text = GlobalMessages.SETTINGS;
            ToolStripMenuItem_Help.Text = GlobalMessages.MENU_HELP;
            ToolStripMenuItem_CheckUpdate.Text = GlobalMessages.CHECK_UPDATE;
            ToolStripMenuItem_AboutV4W.Text = GlobalMessages.ABOUT;
            label_MasterPower.Text = GlobalMessages.MASTER_POWER;
            SingleButton_LoadPreset.ButtonText = GlobalMessages.LOAD_PRESET;
            SingleButton_SavePreset.ButtonText = GlobalMessages.SAVE_PRESET;
            label_Copyright.Text = GlobalMessages.COPYRIGHT;
            ButtonBox_Mode.AddItem(new ButtonBox.Item(GlobalMessages.MUSIC_MODE, 0.ToString()));
            ButtonBox_Mode.AddItem(new ButtonBox.Item(GlobalMessages.MOVIE_MODE, 1.ToString()));
            ButtonBox_Mode.AddItem(new ButtonBox.Item(GlobalMessages.FREESTYLE_MODE, 2.ToString()));
            Music_label_PreVolume.Text = GlobalMessages.PRE_VOLUME;
            Music_label_PostVolume.Text = GlobalMessages.POST_VOLUME;
            Music_groupBox_Convolver.Text = GlobalMessages.CONVOLVER;
            Music_label_ConvolverIRGain.Text = GlobalMessages.CONV_IR_GAIN;
            Music_openFileBox_ConvIRS.DialogTitle = GlobalMessages.OPEN_CONV_IRS;
            Music_openFileBox_ConvIRS.FileFilter = "*.irs; *.wav|*.irs;*.wav|*.*|*.*";
            if (Directory.Exists(m_szIRSPath))
                Music_openFileBox_ConvIRS.OpenDirectory = m_szIRSPath;
            Music_groupBox_Surround.Text = GlobalMessages.SURROUND;
            Music_ButtonBox_SurroundRoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_SMALLEST_ROOM, "0"));
            Music_ButtonBox_SurroundRoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_SMALL_ROOM, "1"));
            Music_ButtonBox_SurroundRoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_MID_ROOM, "2"));
            Music_ButtonBox_SurroundRoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_LARGE_ROOM, "3"));
            Music_ButtonBox_SurroundRoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_LARGEST_ROOM, "4"));
            Music_groupBox_Bass.Text = GlobalMessages.BASS;
            Music_label_Bass_SpkSize.Text = GlobalMessages.BASS_SPKSIZE;
            Music_label_Bass_Gain.Text = GlobalMessages.BASS_GAIN;
            Music_groupBox_Clarity.Text = GlobalMessages.CLARITY;
            Music_ButtonBox_ClarityMode.AddItem(new ButtonBox.Item(GlobalMessages.NATURAL_CLARITY, "0"));
            Music_ButtonBox_ClarityMode.AddItem(new ButtonBox.Item(GlobalMessages.OZONE_CLARITY, "1"));
            Music_ButtonBox_ClarityMode.AddItem(new ButtonBox.Item(GlobalMessages.XHIFI_CLARITY, "2"));
            Music_label_Clarity.Text = GlobalMessages.CLARITY;
            Music_groupBox_Cure.Text = GlobalMessages.CURE;
            Music_ButtonBox_CureLevel.AddItem(new ButtonBox.Item(GlobalMessages.SLIGHT_CURE, 6226570U.ToString()));
            Music_ButtonBox_CureLevel.AddItem(new ButtonBox.Item(GlobalMessages.MODERATE_CURE, 3932860U.ToString()));
            Music_ButtonBox_CureLevel.AddItem(new ButtonBox.Item(GlobalMessages.EXTREME_CURE, 2949820U.ToString()));
            Music_label_Tube.Text = GlobalMessages.TUBE;
            Music_groupBox_Reverb.Text = GlobalMessages.REVERB;
            Music_SingleButton_ReverbPreset.ButtonText = GlobalMessages.PRESET;
            Music_label_Reverb_Size.Text = GlobalMessages.REVERB_SIZE;
            Music_label_Reverb_Damping.Text = GlobalMessages.REVERB_DAMPING;
            Music_label_Reverb_Density.Text = GlobalMessages.REVERB_DENSITY;
            Music_label_Reverb_BandWidth.Text = GlobalMessages.REVERB_BANDWIDTH;
            Music_label_Reverb_Decay.Text = GlobalMessages.REVERB_DECAY;
            Music_label_Reverb_PreDelay.Text = GlobalMessages.REVERB_PREDELAY;
            Music_label_Reverb_EarlyMix.Text = GlobalMessages.REVERB_EARLYMIX;
            Music_label_Reverb_Mix.Text = GlobalMessages.REVERB_MIX;
            Music_SingleButton_Equalizer.ButtonText = GlobalMessages.EQUALIZER_ADJUST;
            Music_SingleButton_Compressor.ButtonText = GlobalMessages.COMPRESSOR_ADJUST;
            Movie_label_PreVolume.Text = GlobalMessages.PRE_VOLUME;
            Movie_label_PostVolume.Text = GlobalMessages.POST_VOLUME;
            Movie_groupBox_Convolver.Text = GlobalMessages.CONVOLVER;
            Movie_label_ConvolverIRGain.Text = GlobalMessages.CONV_IR_GAIN;
            Movie_openFileBox_ConvIRS.DialogTitle = GlobalMessages.OPEN_CONV_IRS;
            if (Directory.Exists(m_szIRSPath))
                Movie_openFileBox_ConvIRS.FileFilter = "*.irs; *.wav|*.irs;*.wav|*.*|*.*";
            Movie_openFileBox_ConvIRS.OpenDirectory = m_szIRSPath;
            Movie_groupBox_Surround.Text = GlobalMessages.SURROUND;
            Movie_label_Surround_3D.Text = GlobalMessages.SURROUND_3D;
            Movie_label_Surround_Image.Text = GlobalMessages.SURROUND_IMAGE;
            Movie_groupBox_Bass.Text = GlobalMessages.BASS;
            Movie_label_Bass_SpkSize.Text = GlobalMessages.BASS_SPKSIZE;
            Movie_label_Bass_Gain.Text = GlobalMessages.BASS_GAIN;
            Movie_groupBox_Clarity.Text = GlobalMessages.CLARITY;
            Movie_label_Clarity.Text = GlobalMessages.CLARITY;
            Movie_groupBox_SmartVolume.Text = GlobalMessages.SMART_VOLUME;
            Movie_label_SmartVolume_ControlStrength.Text = GlobalMessages.SMART_VOLUME_CONTROL_STRENGTH;
            Movie_label_SmartVolume_MaxLevel.Text = GlobalMessages.SMART_VOLUME_MAXLEVEL;
            Movie_label_SmartVolume_Level.Text = GlobalMessages.SMART_VOLUME_LEVEL;
            Movie_groupBox_Reverb.Text = GlobalMessages.REVERB;
            Movie_SingleButton_ReverbPreset.ButtonText = GlobalMessages.PRESET;
            Movie_label_Reverb_Size.Text = GlobalMessages.REVERB_SIZE;
            Movie_label_Reverb_Damping.Text = GlobalMessages.REVERB_DAMPING;
            Movie_label_Reverb_Density.Text = GlobalMessages.REVERB_DENSITY;
            Movie_label_Reverb_BandWidth.Text = GlobalMessages.REVERB_BANDWIDTH;
            Movie_label_Reverb_Decay.Text = GlobalMessages.REVERB_DECAY;
            Movie_label_Reverb_PreDelay.Text = GlobalMessages.REVERB_PREDELAY;
            Movie_label_Reverb_EarlyMix.Text = GlobalMessages.REVERB_EARLYMIX;
            Movie_label_Reverb_Mix.Text = GlobalMessages.REVERB_MIX;
            Movie_SingleButton_Equalizer.ButtonText = GlobalMessages.EQUALIZER_ADJUST;
            Movie_SingleButton_Compressor.ButtonText = GlobalMessages.COMPRESSOR_ADJUST;
            Freestyle_label_PreVolume.Text = GlobalMessages.PRE_VOLUME;
            Freestyle_label_PostVolume.Text = GlobalMessages.POST_VOLUME;
            Freestyle_groupBox_Convolver.Text = GlobalMessages.CONVOLVER;
            Freestyle_label_ConvolverIRGain.Text = GlobalMessages.CONV_IR_GAIN;
            Freestyle_openFileBox_ConvIRS.DialogTitle = GlobalMessages.OPEN_CONV_IRS;
            Freestyle_openFileBox_ConvIRS.FileFilter = "*.irs; *.wav|*.irs;*.wav|*.*|*.*";
            if (Directory.Exists(m_szIRSPath))
                Freestyle_openFileBox_ConvIRS.OpenDirectory = m_szIRSPath;
            Freestyle_groupBox_3DSurround.Text = GlobalMessages.THREE_D_SURROUND;
            Freestyle_label_Surround_3D.Text = GlobalMessages.SURROUND_3D;
            Freestyle_label_Surround_Image.Text = GlobalMessages.SURROUND_IMAGE;
            Freestyle_groupBox_VHESurround.Text = GlobalMessages.VHE_SURROUND;
            Freestyle_ButtonBox_SurroundVHERoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_SMALLEST_ROOM, "0"));
            Freestyle_ButtonBox_SurroundVHERoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_SMALL_ROOM, "1"));
            Freestyle_ButtonBox_SurroundVHERoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_MID_ROOM, "2"));
            Freestyle_ButtonBox_SurroundVHERoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_LARGE_ROOM, "3"));
            Freestyle_ButtonBox_SurroundVHERoomSize.AddItem(new ButtonBox.Item(GlobalMessages.VHE_LARGEST_ROOM, "4"));
            Freestyle_groupBox_Bass.Text = GlobalMessages.BASS;
            Freestyle_label_Bass_SpkSize.Text = GlobalMessages.BASS_SPKSIZE;
            Freestyle_label_Bass_Gain.Text = GlobalMessages.BASS_GAIN;
            Freestyle_ButtonBox_BassMode.AddItem(new ButtonBox.Item(GlobalMessages.NATURAL_BASS, "0"));
            Freestyle_ButtonBox_BassMode.AddItem(new ButtonBox.Item(GlobalMessages.PURE_BASS, "1"));
            Freestyle_groupBox_Clarity.Text = GlobalMessages.CLARITY;
            Freestyle_ButtonBox_ClarityMode.AddItem(new ButtonBox.Item(GlobalMessages.NATURAL_CLARITY, "0"));
            Freestyle_ButtonBox_ClarityMode.AddItem(new ButtonBox.Item(GlobalMessages.OZONE_CLARITY, "1"));
            Freestyle_ButtonBox_ClarityMode.AddItem(new ButtonBox.Item(GlobalMessages.XHIFI_CLARITY, "2"));
            Freestyle_label_Clarity.Text = GlobalMessages.CLARITY;
            Freestyle_groupBox_Cure.Text = GlobalMessages.CURE;
            Freestyle_ButtonBox_CureLevel.AddItem(new ButtonBox.Item(GlobalMessages.SLIGHT_CURE, 6226570U.ToString()));
            Freestyle_ButtonBox_CureLevel.AddItem(new ButtonBox.Item(GlobalMessages.MODERATE_CURE, 3932860U.ToString()));
            Freestyle_ButtonBox_CureLevel.AddItem(new ButtonBox.Item(GlobalMessages.EXTREME_CURE, 2949820U.ToString()));
            Freestyle_label_Tube.Text = GlobalMessages.TUBE;
            Freestyle_groupBox_Reverb.Text = GlobalMessages.REVERB;
            Freestyle_SingleButton_ReverbPreset.ButtonText = GlobalMessages.PRESET;
            Freestyle_label_Reverb_Size.Text = GlobalMessages.REVERB_SIZE;
            Freestyle_label_Reverb_Damping.Text = GlobalMessages.REVERB_DAMPING;
            Freestyle_label_Reverb_Density.Text = GlobalMessages.REVERB_DENSITY;
            Freestyle_label_Reverb_BandWidth.Text = GlobalMessages.REVERB_BANDWIDTH;
            Freestyle_label_Reverb_Decay.Text = GlobalMessages.REVERB_DECAY;
            Freestyle_label_Reverb_PreDelay.Text = GlobalMessages.REVERB_PREDELAY;
            Freestyle_label_Reverb_EarlyMix.Text = GlobalMessages.REVERB_EARLYMIX;
            Freestyle_label_Reverb_Mix.Text = GlobalMessages.REVERB_MIX;
            Freestyle_groupBox_SmartVolume.Text = GlobalMessages.SMART_VOLUME;
            Freestyle_label_SmartVolume_ControlStrength.Text = GlobalMessages.SMART_VOLUME_CONTROL_STRENGTH;
            Freestyle_label_SmartVolume_MaxLevel.Text = GlobalMessages.SMART_VOLUME_MAXLEVEL;
            Freestyle_label_SmartVolume_Level.Text = GlobalMessages.SMART_VOLUME_LEVEL;
            Freestyle_SingleButton_Equalizer.ButtonText = GlobalMessages.EQUALIZER_ADJUST;
            Freestyle_SingleButton_Compressor.ButtonText = GlobalMessages.COMPRESSOR_ADJUST;
            ToolStripMenuItem_Language.DropDownItems.Clear();
            foreach (string listFile in new FolderExplorer().ListFiles(m_szLanguagePath))
            {
                string str3 = new ConfigFile(listFile).ReadConfig("$LANGUAGE_NAME");
                ToolStripItem toolStripItem = new ToolStripMenuItem
                {
                    Text = str3,
                    Tag = listFile
                };
                toolStripItem.Click += new EventHandler(LanguageChanged);
                ToolStripMenuItem_Language.DropDownItems.Add(toolStripItem);
            }
            groupBox_Main.Controls.Clear();
            groupBox_Main.Controls.Add(panel_MusicMode);
            groupBox_Main.Controls.Add(panel_MovieMode);
            groupBox_Main.Controls.Add(panel_Freestyle);
            panel_MusicMode.Dock = DockStyle.Fill;
            panel_MovieMode.Dock = DockStyle.Fill;
            panel_Freestyle.Dock = DockStyle.Fill;
            UpdateAllControlsFromParameters();
            if (szArgs == null || szArgs.Length <= 0)
                return;
            for (int index = 0; index < szArgs.Length; ++index)
            {
                if (szArgs[index].ToLower().Trim() == "--hide")
                    m_bArgvStartupToMinimized = m_bCloseToTray;
                else if (szArgs[index].ToLower().Trim() == "-m")
                    m_bArgvStartupToMinimized = m_bCloseToTray;
            }
        }

        private void SaveAppSettings()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (!baseDirectory.EndsWith("\\"))
                baseDirectory += "\\";
            ConfigFile configFile = new ConfigFile(baseDirectory + "Config.ini");
            if (m_bCloseToTray)
                configFile.SetConfig("$CLOSE_APP_TO_TRAY", "TRUE");
            else
                configFile.SetConfig("$CLOSE_APP_TO_TRAY", "FALSE");
            int num1 = 0;
            for (int index = 0; index < m_lstTrayMenuPreset.Count; ++index)
            {
                if (m_lstTrayMenuPreset[index].Valid())
                    ++num1;
            }
            configFile.SetConfig("$TRAY_MENU_PRESET_COUNT", num1.ToString());
            int index1 = 0;
            int num2 = 0;
            for (; index1 < m_lstTrayMenuPreset.Count; ++index1)
            {
                if (m_lstTrayMenuPreset[index1].Valid())
                {
                    if (string.IsNullOrEmpty(m_lstTrayMenuPreset[index1].PresetName))
                        m_lstTrayMenuPreset[index1].PresetName = GlobalMessages.UNNAMED;
                    string szValue = "";
                    if (m_lstTrayMenuPreset[index1].PresetMode == 0)
                        szValue = "EFFECT_MODE_MUSIC";
                    if (m_lstTrayMenuPreset[index1].PresetMode == 1)
                        szValue = "EFFECT_MODE_MOVIE";
                    if (m_lstTrayMenuPreset[index1].PresetMode == 2)
                        szValue = "EFFECT_MODE_FREESTYLE";
                    configFile.SetConfig("$TRAY_MENU_PRESET_NAME_" + num2.ToString(), m_lstTrayMenuPreset[index1].PresetName);
                    configFile.SetConfig("$TRAY_MENU_PRESET_MODE_" + num2.ToString(), szValue);
                    configFile.SetConfig("$TRAY_MENU_PRESET_FILE_" + num2.ToString(), m_lstTrayMenuPreset[index1].PresetFile);
                    ++num2;
                }
            }
        }

        private void SetupTrayMenu()
        {
            contextMenuStrip_TrayMenu.Items.Clear();
            bool flag = false;
            for (int index = 0; index < m_lstTrayMenuPreset.Count; ++index)
            {
                if (m_lstTrayMenuPreset[index].Valid())
                {
                    ToolStripMenuItem ToolStripMenuItem = new ToolStripMenuItem
                    {
                        Text = m_lstTrayMenuPreset[index].PresetName,
                        Tag = m_lstTrayMenuPreset[index]
                    };
                    ToolStripMenuItem.Click += new EventHandler(TrayMenu_SelectPreset);
                    contextMenuStrip_TrayMenu.Items.Add(ToolStripMenuItem);
                    flag = true;
                }
            }
            if (flag)
                contextMenuStrip_TrayMenu.Items.Add(new ToolStripSeparator());
            ToolStripMenuItem ToolStripMenuItem1 = new ToolStripMenuItem
            {
                Text = GlobalMessages.MUSIC_MODE,
                Tag = "MUSIC_MODE"
            };
            if (m_paramBaseSystem.m_nEffectMode == 0U)
                ToolStripMenuItem1.Checked = true;
            ToolStripMenuItem1.Click += new EventHandler(TrayMenu_SwitchEffectMode);
            contextMenuStrip_TrayMenu.Items.Add(ToolStripMenuItem1);
            ToolStripMenuItem ToolStripMenuItem2 = new ToolStripMenuItem
            {
                Text = GlobalMessages.MOVIE_MODE,
                Tag = "MOVIE_MODE"
            };
            if (m_paramBaseSystem.m_nEffectMode == 1U)
                ToolStripMenuItem2.Checked = true;
            ToolStripMenuItem2.Click += new EventHandler(TrayMenu_SwitchEffectMode);
            contextMenuStrip_TrayMenu.Items.Add(ToolStripMenuItem2);
            ToolStripMenuItem ToolStripMenuItem3 = new ToolStripMenuItem
            {
                Text = GlobalMessages.FREESTYLE_MODE,
                Tag = "FREESTYLE_MODE"
            };
            if (m_paramBaseSystem.m_nEffectMode == 2U)
                ToolStripMenuItem3.Checked = true;
            ToolStripMenuItem3.Click += new EventHandler(TrayMenu_SwitchEffectMode);
            contextMenuStrip_TrayMenu.Items.Add(ToolStripMenuItem3);
            contextMenuStrip_TrayMenu.Items.Add(new ToolStripSeparator());
            ToolStripMenuItem ToolStripMenuItem4 = new ToolStripMenuItem();
            if (m_paramBaseSystem.m_bEffectEnabled == 0)
                ToolStripMenuItem4.Text = GlobalMessages.SWITCH_ON_EFFECT;
            else
                ToolStripMenuItem4.Text = GlobalMessages.SWITCH_OFF_EFFECT;
            ToolStripMenuItem4.Click += new EventHandler(TrayMenu_SwitchEffectOnOff);
            contextMenuStrip_TrayMenu.Items.Add(ToolStripMenuItem4);
            contextMenuStrip_TrayMenu.Items.Add(new ToolStripSeparator());
            ToolStripMenuItem ToolStripMenuItem5 = new ToolStripMenuItem
            {
                Text = GlobalMessages.EXIT_APPLICTION
            };
            ToolStripMenuItem5.Click += new EventHandler(TrayMenu_ExitApplication);
            contextMenuStrip_TrayMenu.Items.Add(ToolStripMenuItem5);
        }

        private void TrayMenu_ExitApplication(object sender, EventArgs e)
        {
            Parameters.SaveLocalPreset(m_szLocalPreset, m_paramBaseSystem, m_paramMusicMode, m_paramMovieMode, m_paramFreestyle);
            SaveAppSettings();
            Application.Exit();
        }

        private void TrayMenu_SwitchEffectOnOff(object sender, EventArgs e)
        {
            if (sender == null || sender.GetType() != typeof(ToolStripMenuItem))
                return;
            ToolStripMenuItem ToolStripMenuItem = sender as ToolStripMenuItem;
            m_paramBaseSystem.m_bEffectEnabled = m_paramBaseSystem.m_bEffectEnabled != 0 ? 0 : 1;
            if (m_paramBaseSystem.m_bEffectEnabled == 0)
                ToolStripMenuItem.Text = GlobalMessages.SWITCH_ON_EFFECT;
            else
                ToolStripMenuItem.Text = GlobalMessages.SWITCH_OFF_EFFECT;
            UpdateAllControlsFromParameters();
        }

        private void TrayMenu_SwitchEffectMode(object sender, EventArgs e)
        {
            if (sender == null || sender.GetType() != typeof(ToolStripMenuItem))
                return;
            ToolStripMenuItem ToolStripMenuItem1 = sender as ToolStripMenuItem;
            if (ToolStripMenuItem1.Tag == null || ToolStripMenuItem1.Tag.GetType() != typeof(string))
                return;
            string tag1 = ToolStripMenuItem1.Tag as string;
            if (string.IsNullOrEmpty(tag1))
                return;
            ToolStripMenuItem ToolStripMenuItem2 = null;
            ToolStripMenuItem ToolStripMenuItem3 = null;
            ToolStripMenuItem ToolStripMenuItem4 = null;
            foreach (object obj in (ArrangedElementCollection)contextMenuStrip_TrayMenu.Items)
            {
                if (obj != null && obj.GetType() == typeof(ToolStripMenuItem))
                {
                    ToolStripMenuItem ToolStripMenuItem5 = obj as ToolStripMenuItem;
                    if (ToolStripMenuItem5.Tag != null && ToolStripMenuItem5.Tag.GetType() == typeof(string))
                    {
                        string tag2 = ToolStripMenuItem5.Tag as string;
                        if (!string.IsNullOrEmpty(tag2))
                        {
                            switch (tag2)
                            {
                                case "MUSIC_MODE":
                                    ToolStripMenuItem2 = ToolStripMenuItem5;
                                    continue;
                                case "MOVIE_MODE":
                                    ToolStripMenuItem3 = ToolStripMenuItem5;
                                    continue;
                                case "FREESTYLE_MODE":
                                    ToolStripMenuItem4 = ToolStripMenuItem5;
                                    continue;
                                default:
                                    continue;
                            }
                        }
                    }
                }
            }
            if (ToolStripMenuItem2 == null || ToolStripMenuItem3 == null || ToolStripMenuItem4 == null)
                return;
            switch (tag1)
            {
                case "MUSIC_MODE":
                    ToolStripMenuItem2.Checked = true;
                    ToolStripMenuItem3.Checked = false;
                    ToolStripMenuItem4.Checked = false;
                    m_paramBaseSystem.m_nEffectMode = 0U;
                    UpdateAllControlsFromParameters();
                    break;
                case "MOVIE_MODE":
                    ToolStripMenuItem2.Checked = false;
                    ToolStripMenuItem3.Checked = true;
                    ToolStripMenuItem4.Checked = false;
                    m_paramBaseSystem.m_nEffectMode = 1U;
                    UpdateAllControlsFromParameters();
                    break;
                case "FREESTYLE_MODE":
                    ToolStripMenuItem2.Checked = false;
                    ToolStripMenuItem3.Checked = false;
                    ToolStripMenuItem4.Checked = true;
                    m_paramBaseSystem.m_nEffectMode = 2U;
                    UpdateAllControlsFromParameters();
                    break;
            }
        }

        private void TrayMenu_SelectPreset(object sender, EventArgs e)
        {
            if (sender == null || sender.GetType() != typeof(ToolStripMenuItem))
                return;
            ToolStripMenuItem ToolStripMenuItem1 = sender as ToolStripMenuItem;
            if (ToolStripMenuItem1.Tag == null || ToolStripMenuItem1.Tag.GetType() != typeof(TrayMenuPreset))
                return;
            TrayMenuPreset tag1 = ToolStripMenuItem1.Tag as TrayMenuPreset;
            if (!tag1.Valid())
                return;
            m_paramBaseSystem.m_nEffectMode = (uint)tag1.PresetMode;
            ToolStripMenuItem ToolStripMenuItem2 = null;
            ToolStripMenuItem ToolStripMenuItem3 = null;
            ToolStripMenuItem ToolStripMenuItem4 = null;
            foreach (object obj in (ArrangedElementCollection)contextMenuStrip_TrayMenu.Items)
            {
                if (obj != null && obj.GetType() == typeof(ToolStripMenuItem))
                {
                    ToolStripMenuItem ToolStripMenuItem5 = obj as ToolStripMenuItem;
                    if (ToolStripMenuItem5.Tag != null && ToolStripMenuItem5.Tag.GetType() == typeof(string))
                    {
                        string tag2 = ToolStripMenuItem5.Tag as string;
                        if (!string.IsNullOrEmpty(tag2))
                        {
                            switch (tag2)
                            {
                                case "MUSIC_MODE":
                                    ToolStripMenuItem2 = ToolStripMenuItem5;
                                    continue;
                                case "MOVIE_MODE":
                                    ToolStripMenuItem3 = ToolStripMenuItem5;
                                    continue;
                                case "FREESTYLE_MODE":
                                    ToolStripMenuItem4 = ToolStripMenuItem5;
                                    continue;
                                default:
                                    continue;
                            }
                        }
                    }
                }
            }
            if (ToolStripMenuItem2 == null || ToolStripMenuItem3 == null || ToolStripMenuItem4 == null)
                return;
            if (m_paramBaseSystem.m_nEffectMode == 0U)
            {
                ToolStripMenuItem2.Checked = true;
                ToolStripMenuItem3.Checked = false;
                ToolStripMenuItem4.Checked = false;
            }
            else if (m_paramBaseSystem.m_nEffectMode == 1U)
            {
                ToolStripMenuItem2.Checked = false;
                ToolStripMenuItem3.Checked = true;
                ToolStripMenuItem4.Checked = false;
            }
            else if (m_paramBaseSystem.m_nEffectMode == 2U)
            {
                ToolStripMenuItem2.Checked = false;
                ToolStripMenuItem3.Checked = false;
                ToolStripMenuItem4.Checked = true;
            }
            if (!tag1.PresetLoadable())
                return;
            RuntimeUtils.ConfigProxy.ParamOfBaseSystem paramOfBaseSystem = new RuntimeUtils.ConfigProxy.ParamOfBaseSystem();
            RuntimeUtils.ConfigProxy.ParamOfMusicMode paramOfMusicMode = new RuntimeUtils.ConfigProxy.ParamOfMusicMode();
            RuntimeUtils.ConfigProxy.ParamOfMovieMode paramOfMovieMode = new RuntimeUtils.ConfigProxy.ParamOfMovieMode();
            RuntimeUtils.ConfigProxy.ParamOfFreestyle paramOfFreestyle = new RuntimeUtils.ConfigProxy.ParamOfFreestyle();
            Parameters.LoadDefaultParameter(ref paramOfBaseSystem);
            Parameters.LoadDefaultParameter(ref paramOfMusicMode);
            Parameters.LoadDefaultParameter(ref paramOfMovieMode);
            Parameters.LoadDefaultParameter(ref paramOfFreestyle);
            if (!Parameters.ReadPreset(tag1.PresetFile, ref paramOfBaseSystem, ref paramOfMusicMode, ref paramOfMovieMode, ref paramOfFreestyle, out _, out bool bPMusicMode, out bool bPMovieMode, out bool bPFreestyle))
            {
                _ = (int)MessageBox.Show(GlobalMessages.CANT_LOAD_PRESET, GlobalMessages.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (!bPMusicMode && !bPMovieMode && !bPFreestyle)
                    return;
                if (bPMusicMode)
                    m_paramMusicMode = paramOfMusicMode;
                if (bPMovieMode)
                    m_paramMovieMode = paramOfMovieMode;
                if (bPFreestyle)
                    m_paramFreestyle = paramOfFreestyle;
                UpdateAllControlsFromParameters();
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (!m_bArgvStartupToMinimized)
                return;
            SetupTrayMenu();
            WindowState = FormWindowState.Minimized;
            Hide();
            ShowInTaskbar = false;
            notifyIcon_Main.Visible = true;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Parameters.SaveLocalPreset(m_szLocalPreset, m_paramBaseSystem, m_paramMusicMode, m_paramMovieMode, m_paramFreestyle);
            SaveAppSettings();
            if (!m_bCloseToTray || e.CloseReason != CloseReason.UserClosing)
                return;
            SetupTrayMenu();
            e.Cancel = true;
            WindowState = FormWindowState.Minimized;
            Hide();
            ShowInTaskbar = false;
            notifyIcon_Main.Visible = true;
        }

        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState != FormWindowState.Minimized)
                return;
            Parameters.SaveLocalPreset(m_szLocalPreset, m_paramBaseSystem, m_paramMusicMode, m_paramMovieMode, m_paramFreestyle);
            SetupTrayMenu();
            Hide();
            ShowInTaskbar = false;
            notifyIcon_Main.Visible = true;
        }

        private void NotifyIcon_Main_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || WindowState != FormWindowState.Minimized)
                return;
            ShowInTaskbar = true;
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
            notifyIcon_Main.Visible = false;
        }

        private float PostVolumeToFloat(float fPostVolume)
        {
            return fPostVolume / 6f;
        }

        private float FloatToPostVolume(float fValue)
        {
            return fValue * 6f;
        }

        private float BassSpeakerSizeToFloat(int nSpkSize)
        {
            return 1f - (float)((nSpkSize - 40.0) / 85.0);
        }

        private int FloatToBassSpeakerSize(float fValue)
        {
            fValue = 1f - fValue;
            int bassSpeakerSize = (int)((double)fValue * 85.0 + 40.0);
            if (bassSpeakerSize < 40)
                bassSpeakerSize = 40;
            if (bassSpeakerSize > 125)
                bassSpeakerSize = 125;
            return bassSpeakerSize;
        }

        private float BassGainToFloat(float fBassGain)
        {
            return fBassGain / 7f;
        }

        private float FloatToBassGain(float fValue)
        {
            return fValue * 7f;
        }

        private float ClarityToFloat(float fClarity)
        {
            return fClarity / 2f;
        }

        public float FloatToClarity(float fValue)
        {
            return fValue * 2f;
        }

        public float Surround3DToFloat(float fSurround3D)
        {
            float num = (float)(((double)fSurround3D - 1.0) / 2.0);
            if ((double)num < 0.0)
                num = 0.0f;
            if ((double)num > 1.0)
                num = 1f;
            return num;
        }

        public float FloatToSurround3D(float fValue)
        {
            return (float)((double)fValue * 2.0 + 1.0);
        }

        public float SVCSToFloat(float fSVCS)
        {
            return (float)(((double)fSVCS - 0.5) / 4.5);
        }

        public float FloatToSVCS(float fValue)
        {
            return (float)((double)fValue * 4.5 + 0.5);
        }

        public float SVMaxLevelToFloat(float fSVMaxLevel)
        {
            return (float)(((double)fSVMaxLevel - 1.0) / 9.0);
        }

        public float FloatToSVMaxLevel(float fValue)
        {
            return (float)((double)fValue * 9.0 + 1.0);
        }

        public float SVLevelToFloat(float fSVLevel)
        {
            return (float)(((double)fSVLevel - 0.20000000298023224) / 0.800000011920929);
        }

        public float FloatToSVLevel(float fValue)
        {
            return (float)((double)fValue * 0.800000011920929 + 0.20000000298023224);
        }

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
            onOffSwitch_Master.SwitchedOn = m_paramBaseSystem.m_bEffectEnabled != 0;
            if (m_paramBaseSystem.m_nEffectMode == 0U)
                ButtonBox_Mode.SelectItem(0);
            else if (m_paramBaseSystem.m_nEffectMode == 1U)
                ButtonBox_Mode.SelectItem(1);
            else if (m_paramBaseSystem.m_nEffectMode == 2U)
                ButtonBox_Mode.SelectItem(2);
            Music_hSlider_PreVolume.PositionFloat = m_paramMusicMode.m_rPreVolume;
            Music_hSlider_PostVolume.PositionFloat = PostVolumeToFloat(m_paramMusicMode.m_rPostVolume);
            Music_onOffSwitch_Convolver.SwitchedOn = m_paramMusicMode.m_bConvolverEnabled != 0;
            Music_openFileBox_ConvIRS.FilePathName = RuntimeUtils.GeneralUtils.CharArrayToString(m_paramMusicMode.m_szConvolverIR);
            Music_hSlider_ConvIRGain.PositionFloat = m_paramMusicMode.m_rConvolverIRGain;
            Music_onOffSwitch_Surround.SwitchedOn = m_paramMusicMode.m_bSurroundEnabled != 0;
            Music_ButtonBox_SurroundRoomSize.SelectItem(m_paramMusicMode.m_nVHERoomSize);
            Music_onOffSwitch_Bass.SwitchedOn = m_paramMusicMode.m_bViPERBassEnabled != 0;
            Music_hSlider_BassSpkSize.PositionFloat = BassSpeakerSizeToFloat(m_paramMusicMode.m_nViPERBassSpkSize);
            Music_hSlider_BassGain.PositionFloat = BassGainToFloat(m_paramMusicMode.m_rViPERBassFactor);
            Music_onOffSwitch_Clarity.SwitchedOn = m_paramMusicMode.m_bViPERClarityEnabled != 0;
            Music_ButtonBox_ClarityMode.SelectItem(m_paramMusicMode.m_nViPERClarityMode);
            Music_hSlider_Clarity.PositionFloat = ClarityToFloat(m_paramMusicMode.m_rViPERClarityFactor);
            Music_onOffSwitch_Cure.SwitchedOn = m_paramMusicMode.m_bCureEnabled != 0;
            if (m_paramMusicMode.m_uiCureLevel == 6226570U)
                Music_ButtonBox_CureLevel.SelectItem(0);
            else if (m_paramMusicMode.m_uiCureLevel == 3932860U)
                Music_ButtonBox_CureLevel.SelectItem(1);
            else if (m_paramMusicMode.m_uiCureLevel == 2949820U)
                Music_ButtonBox_CureLevel.SelectItem(2);
            Music_onOffSwitch_Tube.SwitchedOn = m_paramMusicMode.m_bTubeEnabled != 0;
            Music_onOffSwitch_Reverb.SwitchedOn = m_paramMusicMode.m_bReverbEnabled != 0;
            Music_hSlider_ReverbSize.PositionFloat = m_paramMusicMode.m_rReverbSize;
            Music_hSlider_ReverbDamping.PositionFloat = m_paramMusicMode.m_rReverbDamping;
            Music_hSlider_ReverbDensity.PositionFloat = m_paramMusicMode.m_rReverbDensity;
            Music_hSlider_ReverbBandWidth.PositionFloat = m_paramMusicMode.m_rReverbBandwidth;
            Music_hSlider_ReverbDecay.PositionFloat = m_paramMusicMode.m_rReverbDecay;
            Music_hSlider_ReverbPreDelay.PositionFloat = m_paramMusicMode.m_rReverbPredelay;
            Music_hSlider_ReverbEarlyMix.PositionFloat = m_paramMusicMode.m_rReverbEarlyMix;
            Music_hSlider_ReverbMix.PositionFloat = m_paramMusicMode.m_rReverbMix;
            Movie_hSlider_PreVolume.PositionFloat = m_paramMovieMode.m_rPreVolume;
            Movie_hSlider_PostVolume.PositionFloat = PostVolumeToFloat(m_paramMovieMode.m_rPostVolume);
            Movie_onOffSwitch_Convolver.SwitchedOn = m_paramMovieMode.m_bConvolverEnabled != 0;
            Movie_openFileBox_ConvIRS.FilePathName = RuntimeUtils.GeneralUtils.CharArrayToString(m_paramMovieMode.m_szConvolverIR);
            Movie_hSlider_ConvIRGain.PositionFloat = m_paramMovieMode.m_rConvolverIRGain;
            Movie_onOffSwitch_Surround.SwitchedOn = m_paramMovieMode.m_bSurroundEnabled != 0;
            Movie_hSlider_Surround3D.PositionFloat = Surround3DToFloat(m_paramMovieMode.m_r3DSurroundStereo);
            Movie_hSlider_SurroundImage.PositionFloat = Surround3DToFloat(m_paramMovieMode.m_r3DSurroundImage);
            Movie_onOffSwitch_Bass.SwitchedOn = m_paramMovieMode.m_bViPERBassEnabled != 0;
            Movie_hSlider_BassSpkSize.PositionFloat = BassSpeakerSizeToFloat(m_paramMovieMode.m_nViPERBassSpkSize);
            Movie_hSlider_BassGain.PositionFloat = BassGainToFloat(m_paramMovieMode.m_rViPERBassFactor);
            Movie_onOffSwitch_Clarity.SwitchedOn = m_paramMovieMode.m_bViPERClarityEnabled != 0;
            Movie_hSlider_Clarity.PositionFloat = ClarityToFloat(m_paramMovieMode.m_rViPERClarityFactor);
            Movie_onOffSwitch_SmartVolume.SwitchedOn = m_paramMovieMode.m_bSmartVolumeEnabled != 0;
            Movie_hSlider_SmartVolumeRatio.PositionFloat = SVCSToFloat(m_paramMovieMode.m_rSVRatio);
            Movie_hSlider_SmartVolumeMaxLevel.PositionFloat = SVMaxLevelToFloat(m_paramMovieMode.m_rSVMaxGain);
            Movie_hSlider_SmartVolumeLevel.PositionFloat = SVLevelToFloat(m_paramMovieMode.m_rSVVolume);
            Movie_onOffSwitch_Reverb.SwitchedOn = m_paramMovieMode.m_bReverbEnabled != 0;
            Movie_hSlider_ReverbSize.PositionFloat = m_paramMovieMode.m_rReverbSize;
            Movie_hSlider_ReverbDamping.PositionFloat = m_paramMovieMode.m_rReverbDamping;
            Movie_hSlider_ReverbDensity.PositionFloat = m_paramMovieMode.m_rReverbDensity;
            Movie_hSlider_ReverbBandWidth.PositionFloat = m_paramMovieMode.m_rReverbBandwidth;
            Movie_hSlider_ReverbDecay.PositionFloat = m_paramMovieMode.m_rReverbDecay;
            Movie_hSlider_ReverbPreDelay.PositionFloat = m_paramMovieMode.m_rReverbPredelay;
            Movie_hSlider_ReverbEarlyMix.PositionFloat = m_paramMovieMode.m_rReverbEarlyMix;
            Movie_hSlider_ReverbMix.PositionFloat = m_paramMovieMode.m_rReverbMix;
            Freestyle_hSlider_PreVolume.PositionFloat = m_paramFreestyle.m_rPreVolume;
            Freestyle_hSlider_PostVolume.PositionFloat = PostVolumeToFloat(m_paramFreestyle.m_rPostVolume);
            Freestyle_onOffSwitch_Convolver.SwitchedOn = m_paramFreestyle.m_bConvolverEnabled != 0;
            Freestyle_openFileBox_ConvIRS.FilePathName = RuntimeUtils.GeneralUtils.CharArrayToString(m_paramFreestyle.m_szConvolverIR);
            Freestyle_hSlider_ConvIRGain.PositionFloat = m_paramFreestyle.m_rConvolverIRGain;
            Freestyle_onOffSwitch_Surround3D.SwitchedOn = m_paramFreestyle.m_b3DSurroundEnabled != 0;
            Freestyle_hSlider_Surround3D.PositionFloat = Surround3DToFloat(m_paramFreestyle.m_r3DSurroundStereo);
            Freestyle_hSlider_SurroundImage.PositionFloat = Surround3DToFloat(m_paramFreestyle.m_r3DSurroundImage);
            Freestyle_onOffSwitch_SurroundVHE.SwitchedOn = m_paramFreestyle.m_bVHESurroundEnabled != 0;
            Freestyle_ButtonBox_SurroundVHERoomSize.SelectItem(m_paramFreestyle.m_nVHERoomSize);
            Freestyle_onOffSwitch_Bass.SwitchedOn = m_paramFreestyle.m_bViPERBassEnabled != 0;
            Freestyle_ButtonBox_BassMode.SelectItem(m_paramFreestyle.m_nViPERBassMode);
            Freestyle_hSlider_BassSpkSize.PositionFloat = BassSpeakerSizeToFloat(m_paramFreestyle.m_nViPERBassSpkSize);
            Freestyle_hSlider_BassGain.PositionFloat = BassGainToFloat(m_paramFreestyle.m_rViPERBassFactor);
            Freestyle_onOffSwitch_Clarity.SwitchedOn = m_paramFreestyle.m_bViPERClarityEnabled != 0;
            Freestyle_ButtonBox_ClarityMode.SelectItem(m_paramFreestyle.m_nViPERClarityMode);
            Freestyle_hSlider_Clarity.PositionFloat = ClarityToFloat(m_paramFreestyle.m_rViPERClarityFactor);
            Freestyle_onOffSwitch_Cure.SwitchedOn = m_paramFreestyle.m_bCureEnabled != 0;
            if (m_paramFreestyle.m_uiCureLevel == 6226570U)
                Freestyle_ButtonBox_CureLevel.SelectItem(0);
            else if (m_paramFreestyle.m_uiCureLevel == 3932860U)
                Freestyle_ButtonBox_CureLevel.SelectItem(1);
            else if (m_paramFreestyle.m_uiCureLevel == 2949820U)
                Freestyle_ButtonBox_CureLevel.SelectItem(2);
            Freestyle_onOffSwitch_Tube.SwitchedOn = m_paramFreestyle.m_bTubeEnabled != 0;
            Freestyle_onOffSwitch_SmartVolume.SwitchedOn = m_paramFreestyle.m_bSmartVolumeEnabled != 0;
            Freestyle_hSlider_SmartVolumeRatio.PositionFloat = SVCSToFloat(m_paramFreestyle.m_rSVRatio);
            Freestyle_hSlider_SmartVolumeMaxLevel.PositionFloat = SVMaxLevelToFloat(m_paramFreestyle.m_rSVMaxGain);
            Freestyle_hSlider_SmartVolumeLevel.PositionFloat = SVLevelToFloat(m_paramFreestyle.m_rSVVolume);
            Freestyle_onOffSwitch_Reverb.SwitchedOn = m_paramFreestyle.m_bReverbEnabled != 0;
            Freestyle_hSlider_ReverbSize.PositionFloat = m_paramFreestyle.m_rReverbSize;
            Freestyle_hSlider_ReverbDamping.PositionFloat = m_paramFreestyle.m_rReverbDamping;
            Freestyle_hSlider_ReverbDensity.PositionFloat = m_paramFreestyle.m_rReverbDensity;
            Freestyle_hSlider_ReverbBandWidth.PositionFloat = m_paramFreestyle.m_rReverbBandwidth;
            Freestyle_hSlider_ReverbDecay.PositionFloat = m_paramFreestyle.m_rReverbDecay;
            Freestyle_hSlider_ReverbPreDelay.PositionFloat = m_paramFreestyle.m_rReverbPredelay;
            Freestyle_hSlider_ReverbEarlyMix.PositionFloat = m_paramFreestyle.m_rReverbEarlyMix;
            Freestyle_hSlider_ReverbMix.PositionFloat = m_paramFreestyle.m_rReverbMix;
        }

        private void ToolStripMenuItem_LatencySetting_Click(object sender, EventArgs e)
        {
            FrmLatency frmLatency = new FrmLatency
            {
                ShortFilterLen = m_paramBaseSystem.m_nFilterShortLen,
                MiddleFilterLen = m_paramBaseSystem.m_nFilterMediumLen,
                LongFilterLen = m_paramBaseSystem.m_nFilterLongLen
            };
            if (frmLatency.ShowDialog() == DialogResult.Cancel)
                return;
            m_paramBaseSystem.m_nFilterShortLen = frmLatency.ShortFilterLen;
            m_paramBaseSystem.m_nFilterMediumLen = frmLatency.MiddleFilterLen;
            m_paramBaseSystem.m_nFilterLongLen = frmLatency.LongFilterLen;
            m_cpConfigProxy.UpdateParameter(m_paramBaseSystem);
            m_cpConfigProxy.SyncConfig();
        }

        private void ToolStripMenuItem_ChannelPan_Click(object sender, EventArgs e)
        {
            FrmChannelPan frmChannelPan = new FrmChannelPan
            {
                ChannelPan = m_paramBaseSystem.m_rChannelPan
            };
            _ = (int)frmChannelPan.ShowDialog();
            m_paramBaseSystem.m_rChannelPan = frmChannelPan.ChannelPan;
            m_cpConfigProxy.UpdateParameter(m_paramBaseSystem);
            m_cpConfigProxy.SyncConfig();
        }

        private void ToolStripMenuItem_Virtualization_Click(object sender, EventArgs e)
        {
            FrmVirtualization frmVirtualization = new FrmVirtualization();
            frmVirtualization.SetBaseSystemParam(m_paramBaseSystem);
            if (frmVirtualization.ShowDialog() == DialogResult.Cancel)
                return;
            m_paramBaseSystem = frmVirtualization.GetBaseSystemParam();
            m_cpConfigProxy.UpdateParameter(m_paramBaseSystem);
            m_cpConfigProxy.SyncConfig();
        }

        private void ToolStripMenuItem_ResetEffect_Click(object sender, EventArgs e)
        {
            Parameters.LoadDefaultParameter(ref m_paramMusicMode);
            Parameters.LoadDefaultParameter(ref m_paramMovieMode);
            Parameters.LoadDefaultParameter(ref m_paramFreestyle);
            UpdateAllControlsFromParameters();
        }

        private void ToolStripMenuItem_Settings_Click(object sender, EventArgs e)
        {
            uint num1 = RegHelper.QueryDWORD("LoadChildAPO", 0U);
            FrmSettings frmSettings = new FrmSettings();
            frmSettings.SetPresetPath(m_szPresetsPath);
            frmSettings.SetCloseToTray(m_bCloseToTray);
            frmSettings.SetTrayMenuPresetList(m_lstTrayMenuPreset);
            if (frmSettings.ShowDialog() == DialogResult.Cancel)
                return;
            m_bCloseToTray = frmSettings.GetCloseToTray();
            List<TrayMenuPreset> trayMenuPresetList = frmSettings.GetTrayMenuPresetList();
            m_lstTrayMenuPreset.Clear();
            foreach (TrayMenuPreset trayMenuPreset in trayMenuPresetList)
            {
                if (trayMenuPreset.Valid())
                {
                    if (string.IsNullOrEmpty(trayMenuPreset.PresetName))
                        trayMenuPreset.PresetName = GlobalMessages.UNNAMED;
                    m_lstTrayMenuPreset.Add(trayMenuPreset.Clone());
                }
            }
            SaveAppSettings();
            uint uiValue = !frmSettings.GetAPOCoexistEnabled() ? 0U : 1U;
            if ((int)uiValue == (int)num1)
                return;
            RegHelper.WriteDWORD("LoadChildAPO", uiValue);
            if (uiValue == 1U)
            {
                _ = (int)MessageBox.Show(GlobalMessages.ENABLE_APO_COEXIST_WRN_LINE1 + "\n" + GlobalMessages.ENABLE_APO_COEXIST_WRN_LINE2 + "\n\n" + GlobalMessages.ENABLE_APO_COEXIST_RESTART, GlobalMessages.ENABLE_APO_COEXIST, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                _ = (int)MessageBox.Show(GlobalMessages.ENABLE_APO_COEXIST_RESTART, GlobalMessages.ENABLE_APO_COEXIST, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void ToolStripMenuItem_CheckUpdate_Click(object sender, EventArgs e)
        {
            _ = (int)new FrmCheckUpdate().ShowDialog();
        }

        private void ToolStripMenuItem_AboutV4W_Click(object sender, EventArgs e)
        {
            _ = (int)new FrmAbout().ShowDialog();
        }

        private void OnOffSwitch_Master_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender)
        {
            m_paramBaseSystem.m_bEffectEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramBaseSystem);
            m_cpConfigProxy.SyncConfig();
        }

        private void ButtonBox_Mode_ItemSelectedNotify(
          ButtonBox.Item itPrevItem,
          ButtonBox.Item itCurrItem,
          ButtonBox objSender)
        {
            if (itCurrItem == null || itCurrItem.Tag == null || !(itCurrItem.Tag is string tag))
                return;
            if (tag == 0.ToString())
            {
                panel_MusicMode.Visible = true;
                panel_MovieMode.Visible = false;
                panel_Freestyle.Visible = false;
                m_paramBaseSystem.m_nEffectMode = 0U;
                m_cpConfigProxy.UpdateParameter(m_paramBaseSystem);
                m_cpConfigProxy.SyncConfig();
            }
            else if (tag == 1.ToString())
            {
                panel_MusicMode.Visible = false;
                panel_MovieMode.Visible = true;
                panel_Freestyle.Visible = false;
                m_paramBaseSystem.m_nEffectMode = 1U;
                m_cpConfigProxy.UpdateParameter(m_paramBaseSystem);
                m_cpConfigProxy.SyncConfig();
            }
            else
            {
                if (!(tag == 2.ToString()))
                    return;
                panel_MusicMode.Visible = false;
                panel_MovieMode.Visible = false;
                panel_Freestyle.Visible = true;
                m_paramBaseSystem.m_nEffectMode = 2U;
                m_cpConfigProxy.UpdateParameter(m_paramBaseSystem);
                m_cpConfigProxy.SyncConfig();
            }
        }

        private void SingleButton_LoadPreset_ButtonClickNotify(SingleButton objSender)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = GlobalMessages.LOAD_PRESET,
                Filter = "*.vpf|*.vpf",
                DefaultExt = "vpf",
                InitialDirectory = m_szPresetsPath
            };
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            RuntimeUtils.ConfigProxy.ParamOfBaseSystem paramOfBaseSystem = new RuntimeUtils.ConfigProxy.ParamOfBaseSystem();
            RuntimeUtils.ConfigProxy.ParamOfMusicMode paramOfMusicMode = new RuntimeUtils.ConfigProxy.ParamOfMusicMode();
            RuntimeUtils.ConfigProxy.ParamOfMovieMode paramOfMovieMode = new RuntimeUtils.ConfigProxy.ParamOfMovieMode();
            RuntimeUtils.ConfigProxy.ParamOfFreestyle paramOfFreestyle = new RuntimeUtils.ConfigProxy.ParamOfFreestyle();
            Parameters.LoadDefaultParameter(ref paramOfBaseSystem);
            Parameters.LoadDefaultParameter(ref paramOfMusicMode);
            Parameters.LoadDefaultParameter(ref paramOfMovieMode);
            Parameters.LoadDefaultParameter(ref paramOfFreestyle);
            if (!Parameters.ReadPreset(openFileDialog.FileName, ref paramOfBaseSystem, ref paramOfMusicMode, ref paramOfMovieMode, ref paramOfFreestyle, out _, out bool bPMusicMode, out bool bPMovieMode, out bool bPFreestyle))
            {
                _ = (int)MessageBox.Show(GlobalMessages.CANT_LOAD_PRESET, GlobalMessages.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (!bPMusicMode && !bPMovieMode && !bPFreestyle)
                    return;
                if (bPMusicMode)
                    m_paramMusicMode = paramOfMusicMode;
                if (bPMovieMode)
                    m_paramMovieMode = paramOfMovieMode;
                if (bPFreestyle)
                    m_paramFreestyle = paramOfFreestyle;
                UpdateAllControlsFromParameters();
            }
        }

        private void SingleButton_SavePreset_ButtonClickNotify(SingleButton objSender)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = GlobalMessages.SAVE_PRESET,
                Filter = "*.vpf|*.vpf",
                DefaultExt = "vpf",
                InitialDirectory = m_szPresetsPath
            };
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            switch (m_paramBaseSystem.m_nEffectMode)
            {
                case 0:
                    Parameters.SavePreset(saveFileDialog.FileName, m_paramMusicMode);
                    break;
                case 1:
                    Parameters.SavePreset(saveFileDialog.FileName, m_paramMovieMode);
                    break;
                case 2:
                    Parameters.SavePreset(saveFileDialog.FileName, m_paramFreestyle);
                    break;
                default:
                    _ = (int)MessageBox.Show(GlobalMessages.CANT_SAVE_PRESET, GlobalMessages.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
            }
        }

        private void Freestyle_hSlider_PreVolume_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramFreestyle.m_rPreVolume = fPercent;
            Freestyle_label_PreVolume.Text = GlobalMessages.PRE_VOLUME + " : " + (20.0 * Math.Log10((double)fPercent + 1E-06)).ToString("F02") + "dB";
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_hSlider_PostVolume_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramFreestyle.m_rPostVolume = FloatToPostVolume(fPercent);
            Freestyle_label_PostVolume.Text = GlobalMessages.POST_VOLUME + " : " + (20.0 * Math.Log10((double)FloatToPostVolume(fPercent) + 1E-06)).ToString("F02") + "dB";
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_onOffSwitch_Convolver_SwitchChangeNotify(
          bool bSwitchedOn,
          OnOffSwitch objSender)
        {
            m_paramFreestyle.m_bConvolverEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_hSlider_ConvIRGain_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramFreestyle.m_rConvolverIRGain = fPercent;
            Freestyle_label_ConvolverIRGain.Text = GlobalMessages.CONV_IR_GAIN + " : " + (20.0 * Math.Log10((double)fPercent + 1E-06)).ToString("F02") + "dB";
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_openFileBox_ConvIRS_FileChangeNotify(
          string szFilePathName,
          OpenFileBox objSender)
        {
            m_paramFreestyle.m_szConvolverIR = Parameters.WriteStringToArray260(szFilePathName);
            Freestyle_irShape_ConvIR.SetImpulseResponse(RuntimeUtils.ImpulseResponseUtils.EstimateImpulseResponseSample(szFilePathName, out int nChannelCount), nChannelCount);
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_onOffSwitch_Surround3D_SwitchChangeNotify(
          bool bSwitchedOn,
          OnOffSwitch objSender)
        {
            m_paramFreestyle.m_b3DSurroundEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_hSlider_Surround3D_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramFreestyle.m_r3DSurroundStereo = FloatToSurround3D(fPercent);
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_hSlider_SurroundImage_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramFreestyle.m_r3DSurroundImage = FloatToSurround3D(fPercent);
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_onOffSwitch_SurroundVHE_SwitchChangeNotify(
          bool bSwitchedOn,
          OnOffSwitch objSender)
        {
            m_paramFreestyle.m_bVHESurroundEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_ButtonBox_SurroundVHERoomSize_ItemSelectedNotify(
          ButtonBox.Item itPrevItem,
          ButtonBox.Item itCurrItem,
          ButtonBox objSender)
        {
            if (itCurrItem == null || itCurrItem.Tag == null || !(itCurrItem.Tag is string tag))
                return;
            if (!int.TryParse(tag, out int result) || result < 0 || result > 4)
                return;
            m_paramFreestyle.m_nVHERoomSize = result;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_onOffSwitch_Bass_SwitchChangeNotify(
          bool bSwitchedOn,
          OnOffSwitch objSender)
        {
            m_paramFreestyle.m_bViPERBassEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_hSlider_BassSpkSize_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramFreestyle.m_nViPERBassSpkSize = FloatToBassSpeakerSize(fPercent);
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_hSlider_BassGain_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramFreestyle.m_rViPERBassFactor = FloatToBassGain(fPercent);
            Freestyle_label_Bass_Gain.Text = GlobalMessages.BASS_GAIN + " : " + (20.0 * Math.Log10((double)FloatToBassGain(fPercent) + 1.0)).ToString("F02") + "dB";
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_ButtonBox_BassMode_ItemSelectedNotify(
          ButtonBox.Item itPrevItem,
          ButtonBox.Item itCurrItem,
          ButtonBox objSender)
        {
            if (itCurrItem == null || itCurrItem.Tag == null || !(itCurrItem.Tag is string tag))
                return;
            if (!int.TryParse(tag, out int result) || result < 0 || result > 1)
                return;
            m_paramFreestyle.m_nViPERBassMode = result;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_onOffSwitch_Clarity_SwitchChangeNotify(
          bool bSwitchedOn,
          OnOffSwitch objSender)
        {
            m_paramFreestyle.m_bViPERClarityEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_ButtonBox_ClarityMode_ItemSelectedNotify(
          ButtonBox.Item itPrevItem,
          ButtonBox.Item itCurrItem,
          ButtonBox objSender)
        {
            if (itCurrItem == null || itCurrItem.Tag == null || !(itCurrItem.Tag is string tag))
                return;
            if (!int.TryParse(tag, out int result) || result < 0 || result > 2)
                return;
            m_paramFreestyle.m_nViPERClarityMode = result;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_hSlider_Clarity_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramFreestyle.m_rViPERClarityFactor = FloatToClarity(fPercent);
            Freestyle_label_Clarity.Text = GlobalMessages.CLARITY + " : " + (20.0 * Math.Log10((double)FloatToClarity(fPercent) + 1.0)).ToString("F02") + "dB";
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_onOffSwitch_Cure_SwitchChangeNotify(
          bool bSwitchedOn,
          OnOffSwitch objSender)
        {
            m_paramFreestyle.m_bCureEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_ButtonBox_CureLevel_ItemSelectedNotify(
          ButtonBox.Item itPrevItem,
          ButtonBox.Item itCurrItem,
          ButtonBox objSender)
        {
            if (itCurrItem == null || itCurrItem.Tag == null || !(itCurrItem.Tag is string tag))
                return;
            if (tag == 6226570U.ToString())
            {
                m_paramFreestyle.m_uiCureLevel = 6226570U;
                m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
                m_cpConfigProxy.SyncConfig();
            }
            else if (tag == 3932860U.ToString())
            {
                m_paramFreestyle.m_uiCureLevel = 3932860U;
                m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
                m_cpConfigProxy.SyncConfig();
            }
            else
            {
                if (!(tag == 2949820U.ToString()))
                    return;
                m_paramFreestyle.m_uiCureLevel = 2949820U;
                m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
                m_cpConfigProxy.SyncConfig();
            }
        }

        private void Freestyle_onOffSwitch_Tube_SwitchChangeNotify(
          bool bSwitchedOn,
          OnOffSwitch objSender)
        {
            m_paramFreestyle.m_bTubeEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_onOffSwitch_SmartVolume_SwitchChangeNotify(
          bool bSwitchedOn,
          OnOffSwitch objSender)
        {
            m_paramFreestyle.m_bSmartVolumeEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_hSlider_SmartVolumeRatio_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramFreestyle.m_rSVRatio = FloatToSVCS(fPercent);
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_hSlider_SmartVolumeMaxLevel_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramFreestyle.m_rSVMaxGain = FloatToSVMaxLevel(fPercent);
            Freestyle_label_SmartVolume_MaxLevel.Text = GlobalMessages.SMART_VOLUME_MAXLEVEL + " : " + FloatToSVMaxLevel(fPercent).ToString("F02") + "x";
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_hSlider_SmartVolumeLevel_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramFreestyle.m_rSVVolume = FloatToSVLevel(fPercent);
            Freestyle_label_SmartVolume_Level.Text = GlobalMessages.SMART_VOLUME_LEVEL + " : " + (20.0 * Math.Log10((double)FloatToSVLevel(fPercent))).ToString("F02") + "dB";
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_onOffSwitch_Reverb_SwitchChangeNotify(
          bool bSwitchedOn,
          OnOffSwitch objSender)
        {
            m_paramFreestyle.m_bReverbEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_SingleButton_ReverbPreset_ButtonClickNotify(SingleButton objSender)
        {
            FrmReverbPreset frmReverbPreset = new FrmReverbPreset
            {
                ReverbSize = m_paramFreestyle.m_rReverbSize,
                ReverbDamping = m_paramFreestyle.m_rReverbDamping,
                ReverbDensity = m_paramFreestyle.m_rReverbDensity,
                ReverbBandwidth = m_paramFreestyle.m_rReverbBandwidth,
                ReverbDecay = m_paramFreestyle.m_rReverbDecay,
                ReverbPredelay = m_paramFreestyle.m_rReverbPredelay,
                ReverbEarlyMix = m_paramFreestyle.m_rReverbEarlyMix,
                ReverbMix = m_paramFreestyle.m_rReverbMix
            };
            if (frmReverbPreset.ShowDialog() == DialogResult.Cancel)
                return;
            m_paramFreestyle.m_rReverbSize = frmReverbPreset.ReverbSize;
            m_paramFreestyle.m_rReverbDamping = frmReverbPreset.ReverbDamping;
            m_paramFreestyle.m_rReverbDensity = frmReverbPreset.ReverbDensity;
            m_paramFreestyle.m_rReverbBandwidth = frmReverbPreset.ReverbBandwidth;
            m_paramFreestyle.m_rReverbDecay = frmReverbPreset.ReverbDecay;
            m_paramFreestyle.m_rReverbPredelay = frmReverbPreset.ReverbPredelay;
            m_paramFreestyle.m_rReverbEarlyMix = frmReverbPreset.ReverbEarlyMix;
            m_paramFreestyle.m_rReverbMix = frmReverbPreset.ReverbMix;
            Freestyle_hSlider_ReverbSize.PositionFloat = m_paramFreestyle.m_rReverbSize;
            Freestyle_hSlider_ReverbDamping.PositionFloat = m_paramFreestyle.m_rReverbDamping;
            Freestyle_hSlider_ReverbDensity.PositionFloat = m_paramFreestyle.m_rReverbDensity;
            Freestyle_hSlider_ReverbBandWidth.PositionFloat = m_paramFreestyle.m_rReverbBandwidth;
            Freestyle_hSlider_ReverbDecay.PositionFloat = m_paramFreestyle.m_rReverbDecay;
            Freestyle_hSlider_ReverbPreDelay.PositionFloat = m_paramFreestyle.m_rReverbPredelay;
            Freestyle_hSlider_ReverbEarlyMix.PositionFloat = m_paramFreestyle.m_rReverbEarlyMix;
            Freestyle_hSlider_ReverbMix.PositionFloat = m_paramFreestyle.m_rReverbMix;
        }

        private void Freestyle_hSlider_ReverbSize_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramFreestyle.m_rReverbSize = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_hSlider_ReverbDamping_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramFreestyle.m_rReverbDamping = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_hSlider_ReverbDensity_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramFreestyle.m_rReverbDensity = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_hSlider_ReverbBandWidth_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramFreestyle.m_rReverbBandwidth = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_hSlider_ReverbDecay_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramFreestyle.m_rReverbDecay = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_hSlider_ReverbPreDelay_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramFreestyle.m_rReverbPredelay = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_hSlider_ReverbEarlyMix_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramFreestyle.m_rReverbEarlyMix = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_hSlider_ReverbMix_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramFreestyle.m_rReverbMix = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_SingleButton_Equalizer_ButtonClickNotify(SingleButton objSender)
        {
            FrmEqualizer frmEqualizer = new FrmEqualizer();
            frmEqualizer.SetRealtimeParameters(m_paramBaseSystem, m_paramMusicMode, m_paramMovieMode, m_paramFreestyle, m_cpConfigProxy);
            if (m_paramFreestyle.m_bEqualizerEnabled == 0)
                frmEqualizer.SetParameters(m_paramFreestyle.m_rpEqualizerBands, false);
            else
                frmEqualizer.SetParameters(m_paramFreestyle.m_rpEqualizerBands, true);
            _ = (int)frmEqualizer.ShowDialog();
            m_paramFreestyle.m_bEqualizerEnabled = !frmEqualizer.GetEQEnabled() ? 0 : 1;
            if (frmEqualizer.GetParameter() != null)
                m_paramFreestyle.m_rpEqualizerBands = frmEqualizer.GetParameter();
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Freestyle_SingleButton_Compressor_ButtonClickNotify(SingleButton objSender)
        {
            FrmCompressor frmCompressor = new FrmCompressor
            {
                CompressorEnabled = m_paramFreestyle.m_bCompressorEnabled != 0,
                AutoKnee = m_paramFreestyle.m_bCompAutoKnee != 0,
                AutoAttack = m_paramFreestyle.m_bCompAutoAttack != 0,
                AutoRelease = m_paramFreestyle.m_bCompAutoRelease != 0,
                AutoGain = m_paramFreestyle.m_bCompAutoGain != 0,
                NoClip = m_paramFreestyle.m_bCompAutoMetaNoClipping != 0,
                Threshold = m_paramFreestyle.m_rCompThreshold,
                KneeWidth = m_paramFreestyle.m_rCompKneeWidth,
                Ratio = m_paramFreestyle.m_rCompRatio,
                AttackTime = m_paramFreestyle.m_rCompAttack,
                ReleaseTime = m_paramFreestyle.m_rCompRelease,
                KneeMult = m_paramFreestyle.m_rCompMetaKneeMult,
                CrestTime = m_paramFreestyle.m_rCompMetaCrest,
                AdaptTime = m_paramFreestyle.m_rCompMetaAdapt,
                MakeupGain = m_paramFreestyle.m_rCompGain
            };
            if (frmCompressor.ShowDialog() == DialogResult.Cancel)
                return;
            m_paramFreestyle.m_bCompressorEnabled = !frmCompressor.CompressorEnabled ? 0 : 1;
            m_paramFreestyle.m_bCompAutoKnee = !frmCompressor.AutoKnee ? 0 : 1;
            m_paramFreestyle.m_bCompAutoAttack = !frmCompressor.AutoAttack ? 0 : 1;
            m_paramFreestyle.m_bCompAutoRelease = !frmCompressor.AutoRelease ? 0 : 1;
            m_paramFreestyle.m_bCompAutoGain = !frmCompressor.AutoGain ? 0 : 1;
            m_paramFreestyle.m_bCompAutoMetaNoClipping = !frmCompressor.NoClip ? 0 : 1;
            m_paramFreestyle.m_rCompThreshold = frmCompressor.Threshold;
            m_paramFreestyle.m_rCompKneeWidth = frmCompressor.KneeWidth;
            m_paramFreestyle.m_rCompRatio = frmCompressor.Ratio;
            m_paramFreestyle.m_rCompAttack = frmCompressor.AttackTime;
            m_paramFreestyle.m_rCompRelease = frmCompressor.ReleaseTime;
            m_paramFreestyle.m_rCompMetaKneeMult = frmCompressor.KneeMult;
            m_paramFreestyle.m_rCompMetaCrest = frmCompressor.CrestTime;
            m_paramFreestyle.m_rCompMetaAdapt = frmCompressor.AdaptTime;
            m_paramFreestyle.m_rCompGain = frmCompressor.MakeupGain;
            m_cpConfigProxy.UpdateParameter(m_paramFreestyle);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_hSlider_PreVolume_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMovieMode.m_rPreVolume = fPercent;
            Movie_label_PreVolume.Text = GlobalMessages.PRE_VOLUME + " : " + (20.0 * Math.Log10((double)fPercent + 1E-06)).ToString("F02") + "dB";
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_hSlider_PostVolume_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMovieMode.m_rPostVolume = FloatToPostVolume(fPercent);
            Movie_label_PostVolume.Text = GlobalMessages.POST_VOLUME + " : " + (20.0 * Math.Log10((double)FloatToPostVolume(fPercent) + 1E-06)).ToString("F02") + "dB";
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_onOffSwitch_Convolver_SwitchChangeNotify(
          bool bSwitchedOn,
          OnOffSwitch objSender)
        {
            m_paramMovieMode.m_bConvolverEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_hSlider_ConvIRGain_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMovieMode.m_rConvolverIRGain = fPercent;
            Movie_label_ConvolverIRGain.Text = GlobalMessages.CONV_IR_GAIN + " : " + (20.0 * Math.Log10((double)fPercent + 1E-06)).ToString("F02") + "dB";
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_openFileBox_ConvIRS_FileChangeNotify(
          string szFilePathName,
          OpenFileBox objSender)
        {
            m_paramMovieMode.m_szConvolverIR = Parameters.WriteStringToArray260(szFilePathName);
            Movie_irShape_ConvIR.SetImpulseResponse(RuntimeUtils.ImpulseResponseUtils.EstimateImpulseResponseSample(szFilePathName, out int nChannelCount), nChannelCount);
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_onOffSwitch_Surround_SwitchChangeNotify(
          bool bSwitchedOn,
          OnOffSwitch objSender)
        {
            m_paramMovieMode.m_bSurroundEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_hSlider_Surround3D_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMovieMode.m_r3DSurroundStereo = FloatToSurround3D(fPercent);
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_hSlider_SurroundImage_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMovieMode.m_r3DSurroundImage = FloatToSurround3D(fPercent);
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_onOffSwitch_Bass_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender)
        {
            m_paramMovieMode.m_bViPERBassEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_hSlider_BassSpkSize_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMovieMode.m_nViPERBassSpkSize = FloatToBassSpeakerSize(fPercent);
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_hSlider_BassGain_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMovieMode.m_rViPERBassFactor = FloatToBassGain(fPercent);
            Movie_label_Bass_Gain.Text = GlobalMessages.BASS_GAIN + " : " + (20.0 * Math.Log10((double)FloatToBassGain(fPercent) + 1.0)).ToString("F02") + "dB";
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_onOffSwitch_Clarity_SwitchChangeNotify(
          bool bSwitchedOn,
          OnOffSwitch objSender)
        {
            m_paramMovieMode.m_bViPERClarityEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_hSlider_Clarity_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMovieMode.m_rViPERClarityFactor = FloatToClarity(fPercent);
            Movie_label_Clarity.Text = GlobalMessages.CLARITY + " : " + (20.0 * Math.Log10((double)FloatToClarity(fPercent) + 1.0)).ToString("F02") + "dB";
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_onOffSwitch_SmartVolume_SwitchChangeNotify(
          bool bSwitchedOn,
          OnOffSwitch objSender)
        {
            m_paramMovieMode.m_bSmartVolumeEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_hSlider_SmartVolumeRatio_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramMovieMode.m_rSVRatio = FloatToSVCS(fPercent);
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_hSlider_SmartVolumeMaxLevel_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramMovieMode.m_rSVMaxGain = FloatToSVMaxLevel(fPercent);
            Movie_label_SmartVolume_MaxLevel.Text = GlobalMessages.SMART_VOLUME_MAXLEVEL + " : " + FloatToSVMaxLevel(fPercent).ToString("F02") + "x";
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_hSlider_SmartVolumeLevel_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramMovieMode.m_rSVVolume = FloatToSVLevel(fPercent);
            Movie_label_SmartVolume_Level.Text = GlobalMessages.SMART_VOLUME_LEVEL + " : " + (20.0 * Math.Log10((double)FloatToSVLevel(fPercent))).ToString("F02") + "dB";
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_onOffSwitch_Reverb_SwitchChangeNotify(
          bool bSwitchedOn,
          OnOffSwitch objSender)
        {
            m_paramMovieMode.m_bReverbEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_SingleButton_ReverbPreset_ButtonClickNotify(SingleButton objSender)
        {
            FrmReverbPreset frmReverbPreset = new FrmReverbPreset
            {
                ReverbSize = m_paramMovieMode.m_rReverbSize,
                ReverbDamping = m_paramMovieMode.m_rReverbDamping,
                ReverbDensity = m_paramMovieMode.m_rReverbDensity,
                ReverbBandwidth = m_paramMovieMode.m_rReverbBandwidth,
                ReverbDecay = m_paramMovieMode.m_rReverbDecay,
                ReverbPredelay = m_paramMovieMode.m_rReverbPredelay,
                ReverbEarlyMix = m_paramMovieMode.m_rReverbEarlyMix,
                ReverbMix = m_paramMovieMode.m_rReverbMix
            };
            if (frmReverbPreset.ShowDialog() == DialogResult.Cancel)
                return;
            m_paramMovieMode.m_rReverbSize = frmReverbPreset.ReverbSize;
            m_paramMovieMode.m_rReverbDamping = frmReverbPreset.ReverbDamping;
            m_paramMovieMode.m_rReverbDensity = frmReverbPreset.ReverbDensity;
            m_paramMovieMode.m_rReverbBandwidth = frmReverbPreset.ReverbBandwidth;
            m_paramMovieMode.m_rReverbDecay = frmReverbPreset.ReverbDecay;
            m_paramMovieMode.m_rReverbPredelay = frmReverbPreset.ReverbPredelay;
            m_paramMovieMode.m_rReverbEarlyMix = frmReverbPreset.ReverbEarlyMix;
            m_paramMovieMode.m_rReverbMix = frmReverbPreset.ReverbMix;
            Movie_hSlider_ReverbSize.PositionFloat = m_paramMovieMode.m_rReverbSize;
            Movie_hSlider_ReverbDamping.PositionFloat = m_paramMovieMode.m_rReverbDamping;
            Movie_hSlider_ReverbDensity.PositionFloat = m_paramMovieMode.m_rReverbDensity;
            Movie_hSlider_ReverbBandWidth.PositionFloat = m_paramMovieMode.m_rReverbBandwidth;
            Movie_hSlider_ReverbDecay.PositionFloat = m_paramMovieMode.m_rReverbDecay;
            Movie_hSlider_ReverbPreDelay.PositionFloat = m_paramMovieMode.m_rReverbPredelay;
            Movie_hSlider_ReverbEarlyMix.PositionFloat = m_paramMovieMode.m_rReverbEarlyMix;
            Movie_hSlider_ReverbMix.PositionFloat = m_paramMovieMode.m_rReverbMix;
        }

        private void Movie_hSlider_ReverbSize_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMovieMode.m_rReverbSize = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_hSlider_ReverbDamping_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMovieMode.m_rReverbDamping = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_hSlider_ReverbDensity_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMovieMode.m_rReverbDensity = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_hSlider_ReverbBandWidth_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramMovieMode.m_rReverbBandwidth = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_hSlider_ReverbDecay_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMovieMode.m_rReverbDecay = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_hSlider_ReverbPreDelay_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramMovieMode.m_rReverbPredelay = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_hSlider_ReverbEarlyMix_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramMovieMode.m_rReverbEarlyMix = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_hSlider_ReverbMix_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMovieMode.m_rReverbMix = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_SingleButton_Equalizer_ButtonClickNotify(SingleButton objSender)
        {
            FrmEqualizer frmEqualizer = new FrmEqualizer();
            frmEqualizer.SetRealtimeParameters(m_paramBaseSystem, m_paramMusicMode, m_paramMovieMode, m_paramFreestyle, m_cpConfigProxy);
            if (m_paramMovieMode.m_bEqualizerEnabled == 0)
                frmEqualizer.SetParameters(m_paramMovieMode.m_rpEqualizerBands, false);
            else
                frmEqualizer.SetParameters(m_paramMovieMode.m_rpEqualizerBands, true);
            _ = (int)frmEqualizer.ShowDialog();
            m_paramMovieMode.m_bEqualizerEnabled = !frmEqualizer.GetEQEnabled() ? 0 : 1;
            if (frmEqualizer.GetParameter() != null)
                m_paramMovieMode.m_rpEqualizerBands = frmEqualizer.GetParameter();
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Movie_SingleButton_Compressor_ButtonClickNotify(SingleButton objSender)
        {
            FrmCompressorLite frmCompressorLite = new FrmCompressorLite
            {
                CompressorEnabled = m_paramMovieMode.m_bCompressorEnabled != 0,
                AutoKnee = m_paramMovieMode.m_bCompAutoKnee != 0,
                AutoAttack = m_paramMovieMode.m_bCompAutoAttack != 0,
                AutoRelease = m_paramMovieMode.m_bCompAutoRelease != 0,
                AutoGain = m_paramMovieMode.m_bCompAutoGain != 0,
                Threshold = m_paramMovieMode.m_rCompThreshold,
                KneeWidth = m_paramMovieMode.m_rCompKneeWidth,
                Ratio = m_paramMovieMode.m_rCompRatio,
                AttackTime = m_paramMovieMode.m_rCompAttack,
                ReleaseTime = m_paramMovieMode.m_rCompRelease,
                MakeupGain = m_paramMovieMode.m_rCompGain
            };
            if (frmCompressorLite.ShowDialog() == DialogResult.Cancel)
                return;
            m_paramMovieMode.m_bCompressorEnabled = !frmCompressorLite.CompressorEnabled ? 0 : 1;
            m_paramMovieMode.m_bCompAutoKnee = !frmCompressorLite.AutoKnee ? 0 : 1;
            m_paramMovieMode.m_bCompAutoAttack = !frmCompressorLite.AutoAttack ? 0 : 1;
            m_paramMovieMode.m_bCompAutoRelease = !frmCompressorLite.AutoRelease ? 0 : 1;
            m_paramMovieMode.m_bCompAutoGain = !frmCompressorLite.AutoGain ? 0 : 1;
            m_paramMovieMode.m_rCompThreshold = frmCompressorLite.Threshold;
            m_paramMovieMode.m_rCompKneeWidth = frmCompressorLite.KneeWidth;
            m_paramMovieMode.m_rCompRatio = frmCompressorLite.Ratio;
            m_paramMovieMode.m_rCompAttack = frmCompressorLite.AttackTime;
            m_paramMovieMode.m_rCompRelease = frmCompressorLite.ReleaseTime;
            m_paramMovieMode.m_rCompGain = frmCompressorLite.MakeupGain;
            m_cpConfigProxy.UpdateParameter(m_paramMovieMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_hSlider_PreVolume_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMusicMode.m_rPreVolume = fPercent;
            Music_label_PreVolume.Text = GlobalMessages.PRE_VOLUME + " : " + (20.0 * Math.Log10((double)fPercent + 1E-06)).ToString("F02") + "dB";
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_hSlider_PostVolume_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMusicMode.m_rPostVolume = FloatToPostVolume(fPercent);
            Music_label_PostVolume.Text = GlobalMessages.POST_VOLUME + " : " + (20.0 * Math.Log10((double)FloatToPostVolume(fPercent) + 1E-06)).ToString("F02") + "dB";
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_onOffSwitch_Convolver_SwitchChangeNotify(
          bool bSwitchedOn,
          OnOffSwitch objSender)
        {
            m_paramMusicMode.m_bConvolverEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_hSlider_ConvIRGain_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMusicMode.m_rConvolverIRGain = fPercent;
            Music_label_ConvolverIRGain.Text = GlobalMessages.CONV_IR_GAIN + " : " + (20.0 * Math.Log10((double)fPercent + 1E-06)).ToString("F02") + "dB";
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_openFileBox_ConvIRS_FileChangeNotify(
          string szFilePathName,
          OpenFileBox objSender)
        {
            m_paramMusicMode.m_szConvolverIR = Parameters.WriteStringToArray260(szFilePathName);
            Music_irShape_ConvIR.SetImpulseResponse(RuntimeUtils.ImpulseResponseUtils.EstimateImpulseResponseSample(szFilePathName, out int nChannelCount), nChannelCount);
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_onOffSwitch_Surround_SwitchChangeNotify(
          bool bSwitchedOn,
          OnOffSwitch objSender)
        {
            m_paramMusicMode.m_bSurroundEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_ButtonBox_SurroundRoomSize_ItemSelectedNotify(
          ButtonBox.Item itPrevItem,
          ButtonBox.Item itCurrItem,
          ButtonBox objSender)
        {
            if (itCurrItem == null || itCurrItem.Tag == null || !(itCurrItem.Tag is string tag))
                return;
            if (!int.TryParse(tag, out int result) || result < 0 || result > 4)
                return;
            m_paramMusicMode.m_nVHERoomSize = result;
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_onOffSwitch_Bass_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender)
        {
            m_paramMusicMode.m_bViPERBassEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_hSlider_BassSpkSize_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMusicMode.m_nViPERBassSpkSize = FloatToBassSpeakerSize(fPercent);
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_hSlider_BassGain_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMusicMode.m_rViPERBassFactor = FloatToBassGain(fPercent);
            Music_label_Bass_Gain.Text = GlobalMessages.BASS_GAIN + " : " + (20.0 * Math.Log10((double)FloatToBassGain(fPercent) + 1.0)).ToString("F02") + "dB";
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_onOffSwitch_Clarity_SwitchChangeNotify(
          bool bSwitchedOn,
          OnOffSwitch objSender)
        {
            m_paramMusicMode.m_bViPERClarityEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_ButtonBox_ClarityMode_ItemSelectedNotify(
          ButtonBox.Item itPrevItem,
          ButtonBox.Item itCurrItem,
          ButtonBox objSender)
        {
            if (itCurrItem == null || itCurrItem.Tag == null || !(itCurrItem.Tag is string tag))
                return;
            if (!int.TryParse(tag, out int result) || result < 0 || result > 2)
                return;
            m_paramMusicMode.m_nViPERClarityMode = result;
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_hSlider_Clarity_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMusicMode.m_rViPERClarityFactor = FloatToClarity(fPercent);
            Music_label_Clarity.Text = GlobalMessages.CLARITY + " : " + (20.0 * Math.Log10((double)FloatToClarity(fPercent) + 1.0)).ToString("F02") + "dB";
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_onOffSwitch_Cure_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender)
        {
            m_paramMusicMode.m_bCureEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_ButtonBox_CureLevel_ItemSelectedNotify(
          ButtonBox.Item itPrevItem,
          ButtonBox.Item itCurrItem,
          ButtonBox objSender)
        {
            if (itCurrItem == null || itCurrItem.Tag == null || !(itCurrItem.Tag is string tag))
                return;
            if (tag == 6226570U.ToString())
            {
                m_paramMusicMode.m_uiCureLevel = 6226570U;
                m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
                m_cpConfigProxy.SyncConfig();
            }
            else if (tag == 3932860U.ToString())
            {
                m_paramMusicMode.m_uiCureLevel = 3932860U;
                m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
                m_cpConfigProxy.SyncConfig();
            }
            else
            {
                if (!(tag == 2949820U.ToString()))
                    return;
                m_paramMusicMode.m_uiCureLevel = 2949820U;
                m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
                m_cpConfigProxy.SyncConfig();
            }
        }

        private void Music_onOffSwitch_Tube_SwitchChangeNotify(bool bSwitchedOn, OnOffSwitch objSender)
        {
            m_paramMusicMode.m_bTubeEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_onOffSwitch_Reverb_SwitchChangeNotify(
          bool bSwitchedOn,
          OnOffSwitch objSender)
        {
            m_paramMusicMode.m_bReverbEnabled = !bSwitchedOn ? 0 : 1;
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_SingleButton_ReverbPreset_ButtonClickNotify(SingleButton objSender)
        {
            FrmReverbPreset frmReverbPreset = new FrmReverbPreset
            {
                ReverbSize = m_paramMusicMode.m_rReverbSize,
                ReverbDamping = m_paramMusicMode.m_rReverbDamping,
                ReverbDensity = m_paramMusicMode.m_rReverbDensity,
                ReverbBandwidth = m_paramMusicMode.m_rReverbBandwidth,
                ReverbDecay = m_paramMusicMode.m_rReverbDecay,
                ReverbPredelay = m_paramMusicMode.m_rReverbPredelay,
                ReverbEarlyMix = m_paramMusicMode.m_rReverbEarlyMix,
                ReverbMix = m_paramMusicMode.m_rReverbMix
            };
            if (frmReverbPreset.ShowDialog() == DialogResult.Cancel)
                return;
            m_paramMusicMode.m_rReverbSize = frmReverbPreset.ReverbSize;
            m_paramMusicMode.m_rReverbDamping = frmReverbPreset.ReverbDamping;
            m_paramMusicMode.m_rReverbDensity = frmReverbPreset.ReverbDensity;
            m_paramMusicMode.m_rReverbBandwidth = frmReverbPreset.ReverbBandwidth;
            m_paramMusicMode.m_rReverbDecay = frmReverbPreset.ReverbDecay;
            m_paramMusicMode.m_rReverbPredelay = frmReverbPreset.ReverbPredelay;
            m_paramMusicMode.m_rReverbEarlyMix = frmReverbPreset.ReverbEarlyMix;
            m_paramMusicMode.m_rReverbMix = frmReverbPreset.ReverbMix;
            Music_hSlider_ReverbSize.PositionFloat = m_paramMusicMode.m_rReverbSize;
            Music_hSlider_ReverbDamping.PositionFloat = m_paramMusicMode.m_rReverbDamping;
            Music_hSlider_ReverbDensity.PositionFloat = m_paramMusicMode.m_rReverbDensity;
            Music_hSlider_ReverbBandWidth.PositionFloat = m_paramMusicMode.m_rReverbBandwidth;
            Music_hSlider_ReverbDecay.PositionFloat = m_paramMusicMode.m_rReverbDecay;
            Music_hSlider_ReverbPreDelay.PositionFloat = m_paramMusicMode.m_rReverbPredelay;
            Music_hSlider_ReverbEarlyMix.PositionFloat = m_paramMusicMode.m_rReverbEarlyMix;
            Music_hSlider_ReverbMix.PositionFloat = m_paramMusicMode.m_rReverbMix;
        }

        private void Music_hSlider_ReverbSize_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMusicMode.m_rReverbSize = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_hSlider_ReverbDamping_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMusicMode.m_rReverbDamping = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_hSlider_ReverbDensity_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMusicMode.m_rReverbDensity = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_hSlider_ReverbBandWidth_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramMusicMode.m_rReverbBandwidth = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_hSlider_ReverbDecay_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMusicMode.m_rReverbDecay = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_hSlider_ReverbPreDelay_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramMusicMode.m_rReverbPredelay = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_hSlider_ReverbEarlyMix_PositionChangeNotify(
          float fPercent,
          HSlider objSender)
        {
            m_paramMusicMode.m_rReverbEarlyMix = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_hSlider_ReverbMix_PositionChangeNotify(float fPercent, HSlider objSender)
        {
            m_paramMusicMode.m_rReverbMix = fPercent;
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_SingleButton_Equalizer_ButtonClickNotify(SingleButton objSender)
        {
            FrmEqualizer frmEqualizer = new FrmEqualizer();
            frmEqualizer.SetRealtimeParameters(m_paramBaseSystem, m_paramMusicMode, m_paramMovieMode, m_paramFreestyle, m_cpConfigProxy);
            if (m_paramMusicMode.m_bEqualizerEnabled == 0)
                frmEqualizer.SetParameters(m_paramMusicMode.m_rpEqualizerBands, false);
            else
                frmEqualizer.SetParameters(m_paramMusicMode.m_rpEqualizerBands, true);
            _ = (int)frmEqualizer.ShowDialog();
            m_paramMusicMode.m_bEqualizerEnabled = !frmEqualizer.GetEQEnabled() ? 0 : 1;
            if (frmEqualizer.GetParameter() != null)
                m_paramMusicMode.m_rpEqualizerBands = frmEqualizer.GetParameter();
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        private void Music_SingleButton_Compressor_ButtonClickNotify(SingleButton objSender)
        {
            FrmCompressorLite frmCompressorLite = new FrmCompressorLite
            {
                CompressorEnabled = m_paramMusicMode.m_bCompressorEnabled != 0,
                AutoKnee = m_paramMusicMode.m_bCompAutoKnee != 0,
                AutoAttack = m_paramMusicMode.m_bCompAutoAttack != 0,
                AutoRelease = m_paramMusicMode.m_bCompAutoRelease != 0,
                AutoGain = m_paramMusicMode.m_bCompAutoGain != 0,
                Threshold = m_paramMusicMode.m_rCompThreshold,
                KneeWidth = m_paramMusicMode.m_rCompKneeWidth,
                Ratio = m_paramMusicMode.m_rCompRatio,
                AttackTime = m_paramMusicMode.m_rCompAttack,
                ReleaseTime = m_paramMusicMode.m_rCompRelease,
                MakeupGain = m_paramMusicMode.m_rCompGain
            };
            if (frmCompressorLite.ShowDialog() == DialogResult.Cancel)
                return;
            m_paramMusicMode.m_bCompressorEnabled = !frmCompressorLite.CompressorEnabled ? 0 : 1;
            m_paramMusicMode.m_bCompAutoKnee = !frmCompressorLite.AutoKnee ? 0 : 1;
            m_paramMusicMode.m_bCompAutoAttack = !frmCompressorLite.AutoAttack ? 0 : 1;
            m_paramMusicMode.m_bCompAutoRelease = !frmCompressorLite.AutoRelease ? 0 : 1;
            m_paramMusicMode.m_bCompAutoGain = !frmCompressorLite.AutoGain ? 0 : 1;
            m_paramMusicMode.m_rCompThreshold = frmCompressorLite.Threshold;
            m_paramMusicMode.m_rCompKneeWidth = frmCompressorLite.KneeWidth;
            m_paramMusicMode.m_rCompRatio = frmCompressorLite.Ratio;
            m_paramMusicMode.m_rCompAttack = frmCompressorLite.AttackTime;
            m_paramMusicMode.m_rCompRelease = frmCompressorLite.ReleaseTime;
            m_paramMusicMode.m_rCompGain = frmCompressorLite.MakeupGain;
            m_cpConfigProxy.UpdateParameter(m_paramMusicMode);
            m_cpConfigProxy.SyncConfig();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(FrmMain));
            pictureBox_Logo = new PictureBox();
            label_MasterPower = new Label();
            menuStrip_Main = new MenuStrip();
            ToolStripMenuItem_Language = new ToolStripMenuItem();
            ToolStripMenuItem_Setting = new ToolStripMenuItem();
            ToolStripMenuItem_LatencySetting = new ToolStripMenuItem();
            ToolStripMenuItem_ChannelPan = new ToolStripMenuItem();
            ToolStripMenuItem_Virtualization = new ToolStripMenuItem();
            ToolStripMenuItem_ResetEffect = new ToolStripMenuItem();
            ToolStripMenuItem_Settings = new ToolStripMenuItem();
            ToolStripMenuItem_Help = new ToolStripMenuItem();
            ToolStripMenuItem_CheckUpdate = new ToolStripMenuItem();
            ToolStripMenuItem_AboutV4W = new ToolStripMenuItem();
            groupBox_Main = new GroupBox();
            panel_Freestyle = new Panel();
            Freestyle_groupBox_SmartVolume = new GroupBox();
            Freestyle_hSlider_SmartVolumeLevel = new HSlider();
            Freestyle_label_SmartVolume_Level = new Label();
            Freestyle_hSlider_SmartVolumeMaxLevel = new HSlider();
            Freestyle_label_SmartVolume_MaxLevel = new Label();
            Freestyle_hSlider_SmartVolumeRatio = new HSlider();
            Freestyle_label_SmartVolume_ControlStrength = new Label();
            Freestyle_onOffSwitch_SmartVolume = new OnOffSwitch();
            Freestyle_groupBox_3DSurround = new GroupBox();
            Freestyle_hSlider_SurroundImage = new HSlider();
            Freestyle_label_Surround_Image = new Label();
            Freestyle_hSlider_Surround3D = new HSlider();
            Freestyle_label_Surround_3D = new Label();
            Freestyle_onOffSwitch_Surround3D = new OnOffSwitch();
            Freestyle_SingleButton_Compressor = new SingleButton();
            Freestyle_SingleButton_Equalizer = new SingleButton();
            Freestyle_groupBox_Reverb = new GroupBox();
            Freestyle_SingleButton_ReverbPreset = new SingleButton();
            Freestyle_hSlider_ReverbMix = new HSlider();
            Freestyle_label_Reverb_Mix = new Label();
            Freestyle_hSlider_ReverbEarlyMix = new HSlider();
            Freestyle_label_Reverb_EarlyMix = new Label();
            Freestyle_hSlider_ReverbPreDelay = new HSlider();
            Freestyle_label_Reverb_PreDelay = new Label();
            Freestyle_hSlider_ReverbDecay = new HSlider();
            Freestyle_label_Reverb_Decay = new Label();
            Freestyle_hSlider_ReverbBandWidth = new HSlider();
            Freestyle_label_Reverb_BandWidth = new Label();
            Freestyle_hSlider_ReverbDensity = new HSlider();
            Freestyle_label_Reverb_Density = new Label();
            Freestyle_hSlider_ReverbDamping = new HSlider();
            Freestyle_label_Reverb_Damping = new Label();
            Freestyle_hSlider_ReverbSize = new HSlider();
            Freestyle_label_Reverb_Size = new Label();
            Freestyle_onOffSwitch_Reverb = new OnOffSwitch();
            Freestyle_groupBox_Cure = new GroupBox();
            Freestyle_ButtonBox_CureLevel = new ButtonBox();
            Freestyle_onOffSwitch_Cure = new OnOffSwitch();
            Freestyle_label_Tube = new Label();
            Freestyle_onOffSwitch_Tube = new OnOffSwitch();
            Freestyle_groupBox_Clarity = new GroupBox();
            Freestyle_ButtonBox_ClarityMode = new ButtonBox();
            Freestyle_hSlider_Clarity = new HSlider();
            Freestyle_label_Clarity = new Label();
            Freestyle_onOffSwitch_Clarity = new OnOffSwitch();
            Freestyle_groupBox_Bass = new GroupBox();
            Freestyle_ButtonBox_BassMode = new ButtonBox();
            Freestyle_hSlider_BassGain = new HSlider();
            Freestyle_label_Bass_Gain = new Label();
            Freestyle_hSlider_BassSpkSize = new HSlider();
            Freestyle_label_Bass_SpkSize = new Label();
            Freestyle_onOffSwitch_Bass = new OnOffSwitch();
            Freestyle_groupBox_VHESurround = new GroupBox();
            Freestyle_ButtonBox_SurroundVHERoomSize = new ButtonBox();
            Freestyle_onOffSwitch_SurroundVHE = new OnOffSwitch();
            Freestyle_groupBox_Convolver = new GroupBox();
            Freestyle_irShape_ConvIR = new IRShape();
            Freestyle_onOffSwitch_Convolver = new OnOffSwitch();
            Freestyle_hSlider_ConvIRGain = new HSlider();
            Freestyle_openFileBox_ConvIRS = new OpenFileBox();
            Freestyle_label_ConvolverIRGain = new Label();
            Freestyle_hSlider_PostVolume = new HSlider();
            Freestyle_label_PostVolume = new Label();
            Freestyle_hSlider_PreVolume = new HSlider();
            Freestyle_label_PreVolume = new Label();
            panel_MusicMode = new Panel();
            panel_MovieMode = new Panel();
            Movie_groupBox_SmartVolume = new GroupBox();
            Movie_hSlider_SmartVolumeLevel = new HSlider();
            Movie_label_SmartVolume_Level = new Label();
            Movie_hSlider_SmartVolumeMaxLevel = new HSlider();
            Movie_label_SmartVolume_MaxLevel = new Label();
            Movie_hSlider_SmartVolumeRatio = new HSlider();
            Movie_label_SmartVolume_ControlStrength = new Label();
            Movie_onOffSwitch_SmartVolume = new OnOffSwitch();
            Movie_SingleButton_Compressor = new SingleButton();
            Movie_SingleButton_Equalizer = new SingleButton();
            Movie_groupBox_Reverb = new GroupBox();
            Movie_SingleButton_ReverbPreset = new SingleButton();
            Movie_hSlider_ReverbMix = new HSlider();
            Movie_label_Reverb_Mix = new Label();
            Movie_hSlider_ReverbEarlyMix = new HSlider();
            Movie_label_Reverb_EarlyMix = new Label();
            Movie_hSlider_ReverbPreDelay = new HSlider();
            Movie_label_Reverb_PreDelay = new Label();
            Movie_hSlider_ReverbDecay = new HSlider();
            Movie_label_Reverb_Decay = new Label();
            Movie_hSlider_ReverbBandWidth = new HSlider();
            Movie_label_Reverb_BandWidth = new Label();
            Movie_hSlider_ReverbDensity = new HSlider();
            Movie_label_Reverb_Density = new Label();
            Movie_hSlider_ReverbDamping = new HSlider();
            Movie_label_Reverb_Damping = new Label();
            Movie_hSlider_ReverbSize = new HSlider();
            Movie_label_Reverb_Size = new Label();
            Movie_onOffSwitch_Reverb = new OnOffSwitch();
            Movie_groupBox_Clarity = new GroupBox();
            Movie_hSlider_Clarity = new HSlider();
            Movie_label_Clarity = new Label();
            Movie_onOffSwitch_Clarity = new OnOffSwitch();
            Movie_groupBox_Bass = new GroupBox();
            Movie_hSlider_BassGain = new HSlider();
            Movie_label_Bass_Gain = new Label();
            Movie_hSlider_BassSpkSize = new HSlider();
            Movie_label_Bass_SpkSize = new Label();
            Movie_onOffSwitch_Bass = new OnOffSwitch();
            Movie_groupBox_Surround = new GroupBox();
            Movie_hSlider_SurroundImage = new HSlider();
            Movie_label_Surround_Image = new Label();
            Movie_hSlider_Surround3D = new HSlider();
            Movie_label_Surround_3D = new Label();
            Movie_onOffSwitch_Surround = new OnOffSwitch();
            Movie_groupBox_Convolver = new GroupBox();
            Movie_irShape_ConvIR = new IRShape();
            Movie_onOffSwitch_Convolver = new OnOffSwitch();
            Movie_hSlider_ConvIRGain = new HSlider();
            Movie_openFileBox_ConvIRS = new OpenFileBox();
            Movie_label_ConvolverIRGain = new Label();
            Movie_hSlider_PostVolume = new HSlider();
            Movie_label_PostVolume = new Label();
            Movie_hSlider_PreVolume = new HSlider();
            Movie_label_PreVolume = new Label();
            Music_SingleButton_Compressor = new SingleButton();
            Music_SingleButton_Equalizer = new SingleButton();
            Music_groupBox_Reverb = new GroupBox();
            Music_SingleButton_ReverbPreset = new SingleButton();
            Music_hSlider_ReverbMix = new HSlider();
            Music_label_Reverb_Mix = new Label();
            Music_hSlider_ReverbEarlyMix = new HSlider();
            Music_label_Reverb_EarlyMix = new Label();
            Music_hSlider_ReverbPreDelay = new HSlider();
            Music_label_Reverb_PreDelay = new Label();
            Music_hSlider_ReverbDecay = new HSlider();
            Music_label_Reverb_Decay = new Label();
            Music_hSlider_ReverbBandWidth = new HSlider();
            Music_label_Reverb_BandWidth = new Label();
            Music_hSlider_ReverbDensity = new HSlider();
            Music_label_Reverb_Density = new Label();
            Music_hSlider_ReverbDamping = new HSlider();
            Music_label_Reverb_Damping = new Label();
            Music_hSlider_ReverbSize = new HSlider();
            Music_label_Reverb_Size = new Label();
            Music_onOffSwitch_Reverb = new OnOffSwitch();
            Music_groupBox_Cure = new GroupBox();
            Music_ButtonBox_CureLevel = new ButtonBox();
            Music_onOffSwitch_Cure = new OnOffSwitch();
            Music_label_Tube = new Label();
            Music_onOffSwitch_Tube = new OnOffSwitch();
            Music_groupBox_Clarity = new GroupBox();
            Music_ButtonBox_ClarityMode = new ButtonBox();
            Music_hSlider_Clarity = new HSlider();
            Music_label_Clarity = new Label();
            Music_onOffSwitch_Clarity = new OnOffSwitch();
            Music_groupBox_Bass = new GroupBox();
            Music_hSlider_BassGain = new HSlider();
            Music_label_Bass_Gain = new Label();
            Music_hSlider_BassSpkSize = new HSlider();
            Music_label_Bass_SpkSize = new Label();
            Music_onOffSwitch_Bass = new OnOffSwitch();
            Music_groupBox_Surround = new GroupBox();
            Music_ButtonBox_SurroundRoomSize = new ButtonBox();
            Music_onOffSwitch_Surround = new OnOffSwitch();
            Music_groupBox_Convolver = new GroupBox();
            Music_irShape_ConvIR = new IRShape();
            Music_onOffSwitch_Convolver = new OnOffSwitch();
            Music_hSlider_ConvIRGain = new HSlider();
            Music_openFileBox_ConvIRS = new OpenFileBox();
            Music_label_ConvolverIRGain = new Label();
            Music_hSlider_PostVolume = new HSlider();
            Music_label_PostVolume = new Label();
            Music_hSlider_PreVolume = new HSlider();
            Music_label_PreVolume = new Label();
            label_Copyright = new Label();
            notifyIcon_Main = new NotifyIcon(components);
            contextMenuStrip_TrayMenu = new ContextMenuStrip(components);
            SingleButton_SavePreset = new SingleButton();
            SingleButton_LoadPreset = new SingleButton();
            ButtonBox_Mode = new ButtonBox();
            onOffSwitch_Master = new OnOffSwitch();
            ((ISupportInitialize)pictureBox_Logo).BeginInit();
            menuStrip_Main.SuspendLayout();
            groupBox_Main.SuspendLayout();
            panel_Freestyle.SuspendLayout();
            Freestyle_groupBox_SmartVolume.SuspendLayout();
            Freestyle_groupBox_3DSurround.SuspendLayout();
            Freestyle_groupBox_Reverb.SuspendLayout();
            Freestyle_groupBox_Cure.SuspendLayout();
            Freestyle_groupBox_Clarity.SuspendLayout();
            Freestyle_groupBox_Bass.SuspendLayout();
            Freestyle_groupBox_VHESurround.SuspendLayout();
            Freestyle_groupBox_Convolver.SuspendLayout();
            panel_MusicMode.SuspendLayout();
            panel_MovieMode.SuspendLayout();
            Movie_groupBox_SmartVolume.SuspendLayout();
            Movie_groupBox_Reverb.SuspendLayout();
            Movie_groupBox_Clarity.SuspendLayout();
            Movie_groupBox_Bass.SuspendLayout();
            Movie_groupBox_Surround.SuspendLayout();
            Movie_groupBox_Convolver.SuspendLayout();
            Music_groupBox_Reverb.SuspendLayout();
            Music_groupBox_Cure.SuspendLayout();
            Music_groupBox_Clarity.SuspendLayout();
            Music_groupBox_Bass.SuspendLayout();
            Music_groupBox_Surround.SuspendLayout();
            Music_groupBox_Convolver.SuspendLayout();
            SuspendLayout();
            pictureBox_Logo.Image = Resources.Logo;
            pictureBox_Logo.Location = new Point(28, 69);
            pictureBox_Logo.Name = "pictureBox_Logo";
            pictureBox_Logo.Size = new Size(128, 128);
            pictureBox_Logo.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox_Logo.TabIndex = 0;
            pictureBox_Logo.TabStop = false;
            label_MasterPower.AutoSize = true;
            label_MasterPower.Location = new Point(48, 246);
            label_MasterPower.Name = "label_MasterPower";
            label_MasterPower.Size = new Size(83, 12);
            label_MasterPower.TabIndex = 1;
            label_MasterPower.Text = "$MASTER_POWER";
            menuStrip_Main.Items.AddRange(new ToolStripItem[3]
            {
         ToolStripMenuItem_Language,
         ToolStripMenuItem_Setting,
         ToolStripMenuItem_Help
            });
            menuStrip_Main.Location = new Point(0, 0);
            menuStrip_Main.Name = "menuStrip_Main";
            menuStrip_Main.Size = new Size(1042, 25);
            menuStrip_Main.TabIndex = 4;
            ToolStripMenuItem_Language.Name = "ToolStripMenuItem_Language";
            ToolStripMenuItem_Language.Size = new Size(136, 21);
            ToolStripMenuItem_Language.Text = "$MENU_LANGUAGE";
            ToolStripMenuItem_Setting.DropDownItems.AddRange(new ToolStripItem[5]
            {
         ToolStripMenuItem_LatencySetting,
         ToolStripMenuItem_ChannelPan,
         ToolStripMenuItem_Virtualization,
         ToolStripMenuItem_ResetEffect,
         ToolStripMenuItem_Settings
            });
            ToolStripMenuItem_Setting.Name = "ToolStripMenuItem_Setting";
            ToolStripMenuItem_Setting.Size = new Size(121, 21);
            ToolStripMenuItem_Setting.Text = "$MENU_SETTING";
            ToolStripMenuItem_LatencySetting.Name = "ToolStripMenuItem_LatencySetting";
            ToolStripMenuItem_LatencySetting.Size = new Size(192, 22);
            ToolStripMenuItem_LatencySetting.Text = "$LATENCY_SETTING";
            ToolStripMenuItem_LatencySetting.Click += new EventHandler(ToolStripMenuItem_LatencySetting_Click);
            ToolStripMenuItem_ChannelPan.Name = "ToolStripMenuItem_ChannelPan";
            ToolStripMenuItem_ChannelPan.Size = new Size(192, 22);
            ToolStripMenuItem_ChannelPan.Text = "$CHANNEL_PAN";
            ToolStripMenuItem_ChannelPan.Click += new EventHandler(ToolStripMenuItem_ChannelPan_Click);
            ToolStripMenuItem_Virtualization.Name = "ToolStripMenuItem_Virtualization";
            ToolStripMenuItem_Virtualization.Size = new Size(192, 22);
            ToolStripMenuItem_Virtualization.Text = "$VIRTUALIZATION";
            ToolStripMenuItem_Virtualization.Click += new EventHandler(ToolStripMenuItem_Virtualization_Click);
            ToolStripMenuItem_ResetEffect.Name = "ToolStripMenuItem_ResetEffect";
            ToolStripMenuItem_ResetEffect.Size = new Size(192, 22);
            ToolStripMenuItem_ResetEffect.Text = "$RESET_EFFECT";
            ToolStripMenuItem_ResetEffect.Click += new EventHandler(ToolStripMenuItem_ResetEffect_Click);
            ToolStripMenuItem_Settings.Name = "ToolStripMenuItem_Settings";
            ToolStripMenuItem_Settings.Size = new Size(192, 22);
            ToolStripMenuItem_Settings.Text = "$SETTINGS";
            ToolStripMenuItem_Settings.Click += new EventHandler(ToolStripMenuItem_Settings_Click);
            ToolStripMenuItem_Help.DropDownItems.AddRange(new ToolStripItem[2]
            {
         ToolStripMenuItem_CheckUpdate,
         ToolStripMenuItem_AboutV4W
            });
            ToolStripMenuItem_Help.Name = "ToolStripMenuItem_Help";
            ToolStripMenuItem_Help.Size = new Size(99, 21);
            ToolStripMenuItem_Help.Text = "$MENU_HELP";
            ToolStripMenuItem_CheckUpdate.Name = "ToolStripMenuItem_CheckUpdate";
            ToolStripMenuItem_CheckUpdate.Size = new Size(175, 22);
            ToolStripMenuItem_CheckUpdate.Text = "$CHECK_UPDATE";
            ToolStripMenuItem_CheckUpdate.Click += new EventHandler(ToolStripMenuItem_CheckUpdate_Click);
            ToolStripMenuItem_AboutV4W.Name = "ToolStripMenuItem_AboutV4W";
            ToolStripMenuItem_AboutV4W.Size = new Size(175, 22);
            ToolStripMenuItem_AboutV4W.Text = "$ABOUT";
            ToolStripMenuItem_AboutV4W.Click += new EventHandler(ToolStripMenuItem_AboutV4W_Click);
            groupBox_Main.Controls.Add(panel_Freestyle);
            groupBox_Main.Controls.Add(panel_MusicMode);
            groupBox_Main.Location = new Point(186, 28);
            groupBox_Main.Name = "groupBox_Main";
            groupBox_Main.Size = new Size(841, 572);
            groupBox_Main.TabIndex = 5;
            groupBox_Main.TabStop = false;
            panel_Freestyle.Controls.Add(Freestyle_groupBox_SmartVolume);
            panel_Freestyle.Controls.Add(Freestyle_groupBox_3DSurround);
            panel_Freestyle.Controls.Add(Freestyle_SingleButton_Compressor);
            panel_Freestyle.Controls.Add(Freestyle_SingleButton_Equalizer);
            panel_Freestyle.Controls.Add(Freestyle_groupBox_Reverb);
            panel_Freestyle.Controls.Add(Freestyle_groupBox_Cure);
            panel_Freestyle.Controls.Add(Freestyle_groupBox_Clarity);
            panel_Freestyle.Controls.Add(Freestyle_groupBox_Bass);
            panel_Freestyle.Controls.Add(Freestyle_groupBox_VHESurround);
            panel_Freestyle.Controls.Add(Freestyle_groupBox_Convolver);
            panel_Freestyle.Controls.Add(Freestyle_hSlider_PostVolume);
            panel_Freestyle.Controls.Add(Freestyle_label_PostVolume);
            panel_Freestyle.Controls.Add(Freestyle_hSlider_PreVolume);
            panel_Freestyle.Controls.Add(Freestyle_label_PreVolume);
            panel_Freestyle.Dock = DockStyle.Fill;
            panel_Freestyle.Location = new Point(3, 17);
            panel_Freestyle.Name = "panel_Freestyle";
            panel_Freestyle.Size = new Size(835, 552);
            panel_Freestyle.TabIndex = 10;
            Freestyle_groupBox_SmartVolume.Controls.Add(Freestyle_hSlider_SmartVolumeLevel);
            Freestyle_groupBox_SmartVolume.Controls.Add(Freestyle_label_SmartVolume_Level);
            Freestyle_groupBox_SmartVolume.Controls.Add(Freestyle_hSlider_SmartVolumeMaxLevel);
            Freestyle_groupBox_SmartVolume.Controls.Add(Freestyle_label_SmartVolume_MaxLevel);
            Freestyle_groupBox_SmartVolume.Controls.Add(Freestyle_hSlider_SmartVolumeRatio);
            Freestyle_groupBox_SmartVolume.Controls.Add(Freestyle_label_SmartVolume_ControlStrength);
            Freestyle_groupBox_SmartVolume.Controls.Add(Freestyle_onOffSwitch_SmartVolume);
            Freestyle_groupBox_SmartVolume.Location = new Point(216, 391);
            Freestyle_groupBox_SmartVolume.Name = "Freestyle_groupBox_SmartVolume";
            Freestyle_groupBox_SmartVolume.Size = new Size(384, 148);
            Freestyle_groupBox_SmartVolume.TabIndex = 23;
            Freestyle_groupBox_SmartVolume.TabStop = false;
            Freestyle_groupBox_SmartVolume.Text = "$SMART_VOLUME";
            Freestyle_hSlider_SmartVolumeLevel.BackColor = SystemColors.Control;
            Freestyle_hSlider_SmartVolumeLevel.Location = new Point(195, 85);
            Freestyle_hSlider_SmartVolumeLevel.MoveDelta = 1U;
            Freestyle_hSlider_SmartVolumeLevel.Name = "Freestyle_hSlider_SmartVolumeLevel";
            Freestyle_hSlider_SmartVolumeLevel.Position = 0U;
            Freestyle_hSlider_SmartVolumeLevel.PositionFloat = 0.0f;
            Freestyle_hSlider_SmartVolumeLevel.Size = new Size(174, 39);
            Freestyle_hSlider_SmartVolumeLevel.TabIndex = 23;
            Freestyle_hSlider_SmartVolumeLevel.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_SmartVolumeLevel_PositionChangeNotify);
            Freestyle_label_SmartVolume_Level.AutoSize = true;
            Freestyle_label_SmartVolume_Level.Location = new Point(214, 67);
            Freestyle_label_SmartVolume_Level.Name = "Freestyle_label_SmartVolume_Level";
            Freestyle_label_SmartVolume_Level.Size = new Size(155, 12);
            Freestyle_label_SmartVolume_Level.TabIndex = 22;
            Freestyle_label_SmartVolume_Level.Text = "$SMART_VOLUME_LEVEL : 0dB";
            Freestyle_hSlider_SmartVolumeMaxLevel.BackColor = SystemColors.Control;
            Freestyle_hSlider_SmartVolumeMaxLevel.Location = new Point(9, 115);
            Freestyle_hSlider_SmartVolumeMaxLevel.MoveDelta = 1U;
            Freestyle_hSlider_SmartVolumeMaxLevel.Name = "Freestyle_hSlider_SmartVolumeMaxLevel";
            Freestyle_hSlider_SmartVolumeMaxLevel.Position = 0U;
            Freestyle_hSlider_SmartVolumeMaxLevel.PositionFloat = 0.0f;
            Freestyle_hSlider_SmartVolumeMaxLevel.Size = new Size(161, 24);
            Freestyle_hSlider_SmartVolumeMaxLevel.TabIndex = 21;
            Freestyle_hSlider_SmartVolumeMaxLevel.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_SmartVolumeMaxLevel_PositionChangeNotify);
            Freestyle_label_SmartVolume_MaxLevel.AutoSize = true;
            Freestyle_label_SmartVolume_MaxLevel.Location = new Point(19, 100);
            Freestyle_label_SmartVolume_MaxLevel.Name = "Freestyle_label_SmartVolume_MaxLevel";
            Freestyle_label_SmartVolume_MaxLevel.Size = new Size(167, 12);
            Freestyle_label_SmartVolume_MaxLevel.TabIndex = 20;
            Freestyle_label_SmartVolume_MaxLevel.Text = "$SMART_VOLUME_MAXLEVEL : 1x";
            Freestyle_hSlider_SmartVolumeRatio.BackColor = SystemColors.Control;
            Freestyle_hSlider_SmartVolumeRatio.Location = new Point(9, 73);
            Freestyle_hSlider_SmartVolumeRatio.MoveDelta = 1U;
            Freestyle_hSlider_SmartVolumeRatio.Name = "Freestyle_hSlider_SmartVolumeRatio";
            Freestyle_hSlider_SmartVolumeRatio.Position = 0U;
            Freestyle_hSlider_SmartVolumeRatio.PositionFloat = 0.0f;
            Freestyle_hSlider_SmartVolumeRatio.Size = new Size(161, 24);
            Freestyle_hSlider_SmartVolumeRatio.TabIndex = 19;
            Freestyle_hSlider_SmartVolumeRatio.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_SmartVolumeRatio_PositionChangeNotify);
            Freestyle_label_SmartVolume_ControlStrength.AutoSize = true;
            Freestyle_label_SmartVolume_ControlStrength.Location = new Point(19, 58);
            Freestyle_label_SmartVolume_ControlStrength.Name = "Freestyle_label_SmartVolume_ControlStrength";
            Freestyle_label_SmartVolume_ControlStrength.Size = new Size(185, 12);
            Freestyle_label_SmartVolume_ControlStrength.TabIndex = 18;
            Freestyle_label_SmartVolume_ControlStrength.Text = "$SMART_VOLUME_CONTROL_STRENGTH";
            Freestyle_onOffSwitch_SmartVolume.BackColor = Color.Transparent;
            Freestyle_onOffSwitch_SmartVolume.Location = new Point(13, 23);
            Freestyle_onOffSwitch_SmartVolume.Name = "Freestyle_onOffSwitch_SmartVolume";
            Freestyle_onOffSwitch_SmartVolume.Size = new Size(49, 20);
            Freestyle_onOffSwitch_SmartVolume.SwitchedOn = false;
            Freestyle_onOffSwitch_SmartVolume.TabIndex = 17;
            Freestyle_onOffSwitch_SmartVolume.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Freestyle_onOffSwitch_SmartVolume_SwitchChangeNotify);
            Freestyle_groupBox_3DSurround.Controls.Add(Freestyle_hSlider_SurroundImage);
            Freestyle_groupBox_3DSurround.Controls.Add(Freestyle_label_Surround_Image);
            Freestyle_groupBox_3DSurround.Controls.Add(Freestyle_hSlider_Surround3D);
            Freestyle_groupBox_3DSurround.Controls.Add(Freestyle_label_Surround_3D);
            Freestyle_groupBox_3DSurround.Controls.Add(Freestyle_onOffSwitch_Surround3D);
            Freestyle_groupBox_3DSurround.Location = new Point(476, 6);
            Freestyle_groupBox_3DSurround.Name = "Freestyle_groupBox_3DSurround";
            Freestyle_groupBox_3DSurround.Size = new Size(121, 179);
            Freestyle_groupBox_3DSurround.TabIndex = 22;
            Freestyle_groupBox_3DSurround.TabStop = false;
            Freestyle_groupBox_3DSurround.Text = "$3D_SURROUND";
            Freestyle_hSlider_SurroundImage.BackColor = SystemColors.Control;
            Freestyle_hSlider_SurroundImage.Location = new Point(6, 126);
            Freestyle_hSlider_SurroundImage.MoveDelta = 1U;
            Freestyle_hSlider_SurroundImage.Name = "Freestyle_hSlider_SurroundImage";
            Freestyle_hSlider_SurroundImage.Position = 0U;
            Freestyle_hSlider_SurroundImage.PositionFloat = 0.0f;
            Freestyle_hSlider_SurroundImage.Size = new Size(110, 24);
            Freestyle_hSlider_SurroundImage.TabIndex = 25;
            Freestyle_hSlider_SurroundImage.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_SurroundImage_PositionChangeNotify);
            Freestyle_label_Surround_Image.AutoSize = true;
            Freestyle_label_Surround_Image.Location = new Point(16, 111);
            Freestyle_label_Surround_Image.Name = "Freestyle_label_Surround_Image";
            Freestyle_label_Surround_Image.Size = new Size(95, 12);
            Freestyle_label_Surround_Image.TabIndex = 24;
            Freestyle_label_Surround_Image.Text = "$SURROUND_IMAGE";
            Freestyle_hSlider_Surround3D.BackColor = SystemColors.Control;
            Freestyle_hSlider_Surround3D.Location = new Point(6, 84);
            Freestyle_hSlider_Surround3D.MoveDelta = 1U;
            Freestyle_hSlider_Surround3D.Name = "Freestyle_hSlider_Surround3D";
            Freestyle_hSlider_Surround3D.Position = 0U;
            Freestyle_hSlider_Surround3D.PositionFloat = 0.0f;
            Freestyle_hSlider_Surround3D.Size = new Size(110, 24);
            Freestyle_hSlider_Surround3D.TabIndex = 23;
            Freestyle_hSlider_Surround3D.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_Surround3D_PositionChangeNotify);
            Freestyle_label_Surround_3D.AutoSize = true;
            Freestyle_label_Surround_3D.Location = new Point(16, 69);
            Freestyle_label_Surround_3D.Name = "Freestyle_label_Surround_3D";
            Freestyle_label_Surround_3D.Size = new Size(77, 12);
            Freestyle_label_Surround_3D.TabIndex = 22;
            Freestyle_label_Surround_3D.Text = "$SURROUND_3D";
            Freestyle_onOffSwitch_Surround3D.BackColor = Color.Transparent;
            Freestyle_onOffSwitch_Surround3D.Location = new Point(13, 23);
            Freestyle_onOffSwitch_Surround3D.Name = "Freestyle_onOffSwitch_Surround3D";
            Freestyle_onOffSwitch_Surround3D.Size = new Size(49, 20);
            Freestyle_onOffSwitch_Surround3D.SwitchedOn = false;
            Freestyle_onOffSwitch_Surround3D.TabIndex = 6;
            Freestyle_onOffSwitch_Surround3D.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Freestyle_onOffSwitch_Surround3D_SwitchChangeNotify);
            Freestyle_SingleButton_Compressor.BackColor = SystemColors.Control;
            Freestyle_SingleButton_Compressor.ButtonText = "$COMPRESSOR_ADJUST";
            Freestyle_SingleButton_Compressor.Location = new Point(30, 500);
            Freestyle_SingleButton_Compressor.Name = "Freestyle_SingleButton_Compressor";
            Freestyle_SingleButton_Compressor.Size = new Size(174, 39);
            Freestyle_SingleButton_Compressor.TabIndex = 21;
            Freestyle_SingleButton_Compressor.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(Freestyle_SingleButton_Compressor_ButtonClickNotify);
            Freestyle_SingleButton_Equalizer.BackColor = SystemColors.Control;
            Freestyle_SingleButton_Equalizer.ButtonText = "$EQUALIZER_ADJUST";
            Freestyle_SingleButton_Equalizer.Location = new Point(30, 455);
            Freestyle_SingleButton_Equalizer.Name = "Freestyle_SingleButton_Equalizer";
            Freestyle_SingleButton_Equalizer.Size = new Size(174, 39);
            Freestyle_SingleButton_Equalizer.TabIndex = 20;
            Freestyle_SingleButton_Equalizer.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(Freestyle_SingleButton_Equalizer_ButtonClickNotify);
            Freestyle_groupBox_Reverb.Controls.Add(Freestyle_SingleButton_ReverbPreset);
            Freestyle_groupBox_Reverb.Controls.Add(Freestyle_hSlider_ReverbMix);
            Freestyle_groupBox_Reverb.Controls.Add(Freestyle_label_Reverb_Mix);
            Freestyle_groupBox_Reverb.Controls.Add(Freestyle_hSlider_ReverbEarlyMix);
            Freestyle_groupBox_Reverb.Controls.Add(Freestyle_label_Reverb_EarlyMix);
            Freestyle_groupBox_Reverb.Controls.Add(Freestyle_hSlider_ReverbPreDelay);
            Freestyle_groupBox_Reverb.Controls.Add(Freestyle_label_Reverb_PreDelay);
            Freestyle_groupBox_Reverb.Controls.Add(Freestyle_hSlider_ReverbDecay);
            Freestyle_groupBox_Reverb.Controls.Add(Freestyle_label_Reverb_Decay);
            Freestyle_groupBox_Reverb.Controls.Add(Freestyle_hSlider_ReverbBandWidth);
            Freestyle_groupBox_Reverb.Controls.Add(Freestyle_label_Reverb_BandWidth);
            Freestyle_groupBox_Reverb.Controls.Add(Freestyle_hSlider_ReverbDensity);
            Freestyle_groupBox_Reverb.Controls.Add(Freestyle_label_Reverb_Density);
            Freestyle_groupBox_Reverb.Controls.Add(Freestyle_hSlider_ReverbDamping);
            Freestyle_groupBox_Reverb.Controls.Add(Freestyle_label_Reverb_Damping);
            Freestyle_groupBox_Reverb.Controls.Add(Freestyle_hSlider_ReverbSize);
            Freestyle_groupBox_Reverb.Controls.Add(Freestyle_label_Reverb_Size);
            Freestyle_groupBox_Reverb.Controls.Add(Freestyle_onOffSwitch_Reverb);
            Freestyle_groupBox_Reverb.Location = new Point(606, 150);
            Freestyle_groupBox_Reverb.Name = "Freestyle_groupBox_Reverb";
            Freestyle_groupBox_Reverb.Size = new Size(208, 389);
            Freestyle_groupBox_Reverb.TabIndex = 19;
            Freestyle_groupBox_Reverb.TabStop = false;
            Freestyle_groupBox_Reverb.Text = "$REVERB";
            Freestyle_SingleButton_ReverbPreset.BackColor = SystemColors.Control;
            Freestyle_SingleButton_ReverbPreset.ButtonText = "$PRESET";
            Freestyle_SingleButton_ReverbPreset.Location = new Point(121, 14);
            Freestyle_SingleButton_ReverbPreset.Name = "Freestyle_SingleButton_ReverbPreset";
            Freestyle_SingleButton_ReverbPreset.Size = new Size(81, 29);
            Freestyle_SingleButton_ReverbPreset.TabIndex = 36;
            Freestyle_SingleButton_ReverbPreset.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(Freestyle_SingleButton_ReverbPreset_ButtonClickNotify);
            Freestyle_hSlider_ReverbMix.BackColor = SystemColors.Control;
            Freestyle_hSlider_ReverbMix.Location = new Point(24, 356);
            Freestyle_hSlider_ReverbMix.MoveDelta = 1U;
            Freestyle_hSlider_ReverbMix.Name = "Freestyle_hSlider_ReverbMix";
            Freestyle_hSlider_ReverbMix.Position = 0U;
            Freestyle_hSlider_ReverbMix.PositionFloat = 0.0f;
            Freestyle_hSlider_ReverbMix.Size = new Size(161, 24);
            Freestyle_hSlider_ReverbMix.TabIndex = 35;
            Freestyle_hSlider_ReverbMix.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_ReverbMix_PositionChangeNotify);
            Freestyle_label_Reverb_Mix.AutoSize = true;
            Freestyle_label_Reverb_Mix.Location = new Point(34, 341);
            Freestyle_label_Reverb_Mix.Name = "Freestyle_label_Reverb_Mix";
            Freestyle_label_Reverb_Mix.Size = new Size(71, 12);
            Freestyle_label_Reverb_Mix.TabIndex = 34;
            Freestyle_label_Reverb_Mix.Text = "$REVERB_MIX";
            Freestyle_hSlider_ReverbEarlyMix.BackColor = SystemColors.Control;
            Freestyle_hSlider_ReverbEarlyMix.Location = new Point(24, 314);
            Freestyle_hSlider_ReverbEarlyMix.MoveDelta = 1U;
            Freestyle_hSlider_ReverbEarlyMix.Name = "Freestyle_hSlider_ReverbEarlyMix";
            Freestyle_hSlider_ReverbEarlyMix.Position = 0U;
            Freestyle_hSlider_ReverbEarlyMix.PositionFloat = 0.0f;
            Freestyle_hSlider_ReverbEarlyMix.Size = new Size(161, 24);
            Freestyle_hSlider_ReverbEarlyMix.TabIndex = 33;
            Freestyle_hSlider_ReverbEarlyMix.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_ReverbEarlyMix_PositionChangeNotify);
            Freestyle_label_Reverb_EarlyMix.AutoSize = true;
            Freestyle_label_Reverb_EarlyMix.Location = new Point(34, 299);
            Freestyle_label_Reverb_EarlyMix.Name = "Freestyle_label_Reverb_EarlyMix";
            Freestyle_label_Reverb_EarlyMix.Size = new Size(101, 12);
            Freestyle_label_Reverb_EarlyMix.TabIndex = 32;
            Freestyle_label_Reverb_EarlyMix.Text = "$REVERB_EARLYMIX";
            Freestyle_hSlider_ReverbPreDelay.BackColor = SystemColors.Control;
            Freestyle_hSlider_ReverbPreDelay.Location = new Point(24, 272);
            Freestyle_hSlider_ReverbPreDelay.MoveDelta = 1U;
            Freestyle_hSlider_ReverbPreDelay.Name = "Freestyle_hSlider_ReverbPreDelay";
            Freestyle_hSlider_ReverbPreDelay.Position = 0U;
            Freestyle_hSlider_ReverbPreDelay.PositionFloat = 0.0f;
            Freestyle_hSlider_ReverbPreDelay.Size = new Size(161, 24);
            Freestyle_hSlider_ReverbPreDelay.TabIndex = 31;
            Freestyle_hSlider_ReverbPreDelay.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_ReverbPreDelay_PositionChangeNotify);
            Freestyle_label_Reverb_PreDelay.AutoSize = true;
            Freestyle_label_Reverb_PreDelay.Location = new Point(34, 257);
            Freestyle_label_Reverb_PreDelay.Name = "Freestyle_label_Reverb_PreDelay";
            Freestyle_label_Reverb_PreDelay.Size = new Size(101, 12);
            Freestyle_label_Reverb_PreDelay.TabIndex = 30;
            Freestyle_label_Reverb_PreDelay.Text = "$REVERB_PREDELAY";
            Freestyle_hSlider_ReverbDecay.BackColor = SystemColors.Control;
            Freestyle_hSlider_ReverbDecay.Location = new Point(24, 230);
            Freestyle_hSlider_ReverbDecay.MoveDelta = 1U;
            Freestyle_hSlider_ReverbDecay.Name = "Freestyle_hSlider_ReverbDecay";
            Freestyle_hSlider_ReverbDecay.Position = 0U;
            Freestyle_hSlider_ReverbDecay.PositionFloat = 0.0f;
            Freestyle_hSlider_ReverbDecay.Size = new Size(161, 24);
            Freestyle_hSlider_ReverbDecay.TabIndex = 29;
            Freestyle_hSlider_ReverbDecay.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_ReverbDecay_PositionChangeNotify);
            Freestyle_label_Reverb_Decay.AutoSize = true;
            Freestyle_label_Reverb_Decay.Location = new Point(34, 215);
            Freestyle_label_Reverb_Decay.Name = "Freestyle_label_Reverb_Decay";
            Freestyle_label_Reverb_Decay.Size = new Size(83, 12);
            Freestyle_label_Reverb_Decay.TabIndex = 28;
            Freestyle_label_Reverb_Decay.Text = "$REVERB_DECAY";
            Freestyle_hSlider_ReverbBandWidth.BackColor = SystemColors.Control;
            Freestyle_hSlider_ReverbBandWidth.Location = new Point(24, 188);
            Freestyle_hSlider_ReverbBandWidth.MoveDelta = 1U;
            Freestyle_hSlider_ReverbBandWidth.Name = "Freestyle_hSlider_ReverbBandWidth";
            Freestyle_hSlider_ReverbBandWidth.Position = 0U;
            Freestyle_hSlider_ReverbBandWidth.PositionFloat = 0.0f;
            Freestyle_hSlider_ReverbBandWidth.Size = new Size(161, 24);
            Freestyle_hSlider_ReverbBandWidth.TabIndex = 27;
            Freestyle_hSlider_ReverbBandWidth.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_ReverbBandWidth_PositionChangeNotify);
            Freestyle_label_Reverb_BandWidth.AutoSize = true;
            Freestyle_label_Reverb_BandWidth.Location = new Point(34, 173);
            Freestyle_label_Reverb_BandWidth.Name = "Freestyle_label_Reverb_BandWidth";
            Freestyle_label_Reverb_BandWidth.Size = new Size(107, 12);
            Freestyle_label_Reverb_BandWidth.TabIndex = 26;
            Freestyle_label_Reverb_BandWidth.Text = "$REVERB_BANDWIDTH";
            Freestyle_hSlider_ReverbDensity.BackColor = SystemColors.Control;
            Freestyle_hSlider_ReverbDensity.Location = new Point(24, 146);
            Freestyle_hSlider_ReverbDensity.MoveDelta = 1U;
            Freestyle_hSlider_ReverbDensity.Name = "Freestyle_hSlider_ReverbDensity";
            Freestyle_hSlider_ReverbDensity.Position = 0U;
            Freestyle_hSlider_ReverbDensity.PositionFloat = 0.0f;
            Freestyle_hSlider_ReverbDensity.Size = new Size(161, 24);
            Freestyle_hSlider_ReverbDensity.TabIndex = 25;
            Freestyle_hSlider_ReverbDensity.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_ReverbDensity_PositionChangeNotify);
            Freestyle_label_Reverb_Density.AutoSize = true;
            Freestyle_label_Reverb_Density.Location = new Point(34, 131);
            Freestyle_label_Reverb_Density.Name = "Freestyle_label_Reverb_Density";
            Freestyle_label_Reverb_Density.Size = new Size(95, 12);
            Freestyle_label_Reverb_Density.TabIndex = 24;
            Freestyle_label_Reverb_Density.Text = "$REVERB_DENSITY";
            Freestyle_hSlider_ReverbDamping.BackColor = SystemColors.Control;
            Freestyle_hSlider_ReverbDamping.Location = new Point(24, 104);
            Freestyle_hSlider_ReverbDamping.MoveDelta = 1U;
            Freestyle_hSlider_ReverbDamping.Name = "Freestyle_hSlider_ReverbDamping";
            Freestyle_hSlider_ReverbDamping.Position = 0U;
            Freestyle_hSlider_ReverbDamping.PositionFloat = 0.0f;
            Freestyle_hSlider_ReverbDamping.Size = new Size(161, 24);
            Freestyle_hSlider_ReverbDamping.TabIndex = 23;
            Freestyle_hSlider_ReverbDamping.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_ReverbDamping_PositionChangeNotify);
            Freestyle_label_Reverb_Damping.AutoSize = true;
            Freestyle_label_Reverb_Damping.Location = new Point(34, 89);
            Freestyle_label_Reverb_Damping.Name = "Freestyle_label_Reverb_Damping";
            Freestyle_label_Reverb_Damping.Size = new Size(95, 12);
            Freestyle_label_Reverb_Damping.TabIndex = 22;
            Freestyle_label_Reverb_Damping.Text = "$REVERB_DAMPING";
            Freestyle_hSlider_ReverbSize.BackColor = SystemColors.Control;
            Freestyle_hSlider_ReverbSize.Location = new Point(24, 64);
            Freestyle_hSlider_ReverbSize.MoveDelta = 1U;
            Freestyle_hSlider_ReverbSize.Name = "Freestyle_hSlider_ReverbSize";
            Freestyle_hSlider_ReverbSize.Position = 0U;
            Freestyle_hSlider_ReverbSize.PositionFloat = 0.0f;
            Freestyle_hSlider_ReverbSize.Size = new Size(161, 24);
            Freestyle_hSlider_ReverbSize.TabIndex = 21;
            Freestyle_hSlider_ReverbSize.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_ReverbSize_PositionChangeNotify);
            Freestyle_label_Reverb_Size.AutoSize = true;
            Freestyle_label_Reverb_Size.Location = new Point(34, 49);
            Freestyle_label_Reverb_Size.Name = "Freestyle_label_Reverb_Size";
            Freestyle_label_Reverb_Size.Size = new Size(77, 12);
            Freestyle_label_Reverb_Size.TabIndex = 20;
            Freestyle_label_Reverb_Size.Text = "$REVERB_SIZE";
            Freestyle_onOffSwitch_Reverb.BackColor = Color.Transparent;
            Freestyle_onOffSwitch_Reverb.Location = new Point(13, 23);
            Freestyle_onOffSwitch_Reverb.Name = "Freestyle_onOffSwitch_Reverb";
            Freestyle_onOffSwitch_Reverb.Size = new Size(49, 20);
            Freestyle_onOffSwitch_Reverb.SwitchedOn = false;
            Freestyle_onOffSwitch_Reverb.TabIndex = 7;
            Freestyle_onOffSwitch_Reverb.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Freestyle_onOffSwitch_Reverb_SwitchChangeNotify);
            Freestyle_groupBox_Cure.Controls.Add(Freestyle_ButtonBox_CureLevel);
            Freestyle_groupBox_Cure.Controls.Add(Freestyle_onOffSwitch_Cure);
            Freestyle_groupBox_Cure.Controls.Add(Freestyle_label_Tube);
            Freestyle_groupBox_Cure.Controls.Add(Freestyle_onOffSwitch_Tube);
            Freestyle_groupBox_Cure.Location = new Point(411, 214);
            Freestyle_groupBox_Cure.Name = "Freestyle_groupBox_Cure";
            Freestyle_groupBox_Cure.Size = new Size(189, 148);
            Freestyle_groupBox_Cure.TabIndex = 18;
            Freestyle_groupBox_Cure.TabStop = false;
            Freestyle_groupBox_Cure.Text = "$CURE";
            Freestyle_ButtonBox_CureLevel.BackColor = SystemColors.Control;
            Freestyle_ButtonBox_CureLevel.Location = new Point(68, 17);
            Freestyle_ButtonBox_CureLevel.Name = "Freestyle_ButtonBox_CureLevel";
            Freestyle_ButtonBox_CureLevel.Size = new Size(106, 70);
            Freestyle_ButtonBox_CureLevel.TabIndex = 18;
            Freestyle_ButtonBox_CureLevel.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(Freestyle_ButtonBox_CureLevel_ItemSelectedNotify);
            Freestyle_onOffSwitch_Cure.BackColor = Color.Transparent;
            Freestyle_onOffSwitch_Cure.Location = new Point(13, 23);
            Freestyle_onOffSwitch_Cure.Name = "Freestyle_onOffSwitch_Cure";
            Freestyle_onOffSwitch_Cure.Size = new Size(49, 20);
            Freestyle_onOffSwitch_Cure.SwitchedOn = false;
            Freestyle_onOffSwitch_Cure.TabIndex = 17;
            Freestyle_onOffSwitch_Cure.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Freestyle_onOffSwitch_Cure_SwitchChangeNotify);
            Freestyle_label_Tube.AutoSize = true;
            Freestyle_label_Tube.Location = new Point(11, 113);
            Freestyle_label_Tube.Name = "Freestyle_label_Tube";
            Freestyle_label_Tube.Size = new Size(35, 12);
            Freestyle_label_Tube.TabIndex = 14;
            Freestyle_label_Tube.Text = "$TUBE";
            Freestyle_onOffSwitch_Tube.BackColor = Color.Transparent;
            Freestyle_onOffSwitch_Tube.Location = new Point(121, 105);
            Freestyle_onOffSwitch_Tube.Name = "Freestyle_onOffSwitch_Tube";
            Freestyle_onOffSwitch_Tube.Size = new Size(53, 26);
            Freestyle_onOffSwitch_Tube.SwitchedOn = false;
            Freestyle_onOffSwitch_Tube.TabIndex = 15;
            Freestyle_onOffSwitch_Tube.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Freestyle_onOffSwitch_Tube_SwitchChangeNotify);
            Freestyle_groupBox_Clarity.Controls.Add(Freestyle_ButtonBox_ClarityMode);
            Freestyle_groupBox_Clarity.Controls.Add(Freestyle_hSlider_Clarity);
            Freestyle_groupBox_Clarity.Controls.Add(Freestyle_label_Clarity);
            Freestyle_groupBox_Clarity.Controls.Add(Freestyle_onOffSwitch_Clarity);
            Freestyle_groupBox_Clarity.Location = new Point(216, 214);
            Freestyle_groupBox_Clarity.Name = "Freestyle_groupBox_Clarity";
            Freestyle_groupBox_Clarity.Size = new Size(189, 148);
            Freestyle_groupBox_Clarity.TabIndex = 17;
            Freestyle_groupBox_Clarity.TabStop = false;
            Freestyle_groupBox_Clarity.Text = "$CLARITY";
            Freestyle_ButtonBox_ClarityMode.BackColor = SystemColors.Control;
            Freestyle_ButtonBox_ClarityMode.Location = new Point(68, 17);
            Freestyle_ButtonBox_ClarityMode.Name = "Freestyle_ButtonBox_ClarityMode";
            Freestyle_ButtonBox_ClarityMode.Size = new Size(106, 70);
            Freestyle_ButtonBox_ClarityMode.TabIndex = 18;
            Freestyle_ButtonBox_ClarityMode.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(Freestyle_ButtonBox_ClarityMode_ItemSelectedNotify);
            Freestyle_hSlider_Clarity.BackColor = SystemColors.Control;
            Freestyle_hSlider_Clarity.Location = new Point(13, 115);
            Freestyle_hSlider_Clarity.MoveDelta = 1U;
            Freestyle_hSlider_Clarity.Name = "Freestyle_hSlider_Clarity";
            Freestyle_hSlider_Clarity.Position = 0U;
            Freestyle_hSlider_Clarity.PositionFloat = 0.0f;
            Freestyle_hSlider_Clarity.Size = new Size(161, 24);
            Freestyle_hSlider_Clarity.TabIndex = 21;
            Freestyle_hSlider_Clarity.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_Clarity_PositionChangeNotify);
            Freestyle_label_Clarity.AutoSize = true;
            Freestyle_label_Clarity.Location = new Point(23, 100);
            Freestyle_label_Clarity.Name = "Freestyle_label_Clarity";
            Freestyle_label_Clarity.Size = new Size(89, 12);
            Freestyle_label_Clarity.TabIndex = 20;
            Freestyle_label_Clarity.Text = "$CLARITY : 0dB";
            Freestyle_onOffSwitch_Clarity.BackColor = Color.Transparent;
            Freestyle_onOffSwitch_Clarity.Location = new Point(13, 23);
            Freestyle_onOffSwitch_Clarity.Name = "Freestyle_onOffSwitch_Clarity";
            Freestyle_onOffSwitch_Clarity.Size = new Size(49, 20);
            Freestyle_onOffSwitch_Clarity.SwitchedOn = false;
            Freestyle_onOffSwitch_Clarity.TabIndex = 17;
            Freestyle_onOffSwitch_Clarity.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Freestyle_onOffSwitch_Clarity_SwitchChangeNotify);
            Freestyle_groupBox_Bass.Controls.Add(Freestyle_ButtonBox_BassMode);
            Freestyle_groupBox_Bass.Controls.Add(Freestyle_hSlider_BassGain);
            Freestyle_groupBox_Bass.Controls.Add(Freestyle_label_Bass_Gain);
            Freestyle_groupBox_Bass.Controls.Add(Freestyle_hSlider_BassSpkSize);
            Freestyle_groupBox_Bass.Controls.Add(Freestyle_label_Bass_SpkSize);
            Freestyle_groupBox_Bass.Controls.Add(Freestyle_onOffSwitch_Bass);
            Freestyle_groupBox_Bass.Location = new Point(21, 214);
            Freestyle_groupBox_Bass.Name = "Freestyle_groupBox_Bass";
            Freestyle_groupBox_Bass.Size = new Size(189, 223);
            Freestyle_groupBox_Bass.TabIndex = 16;
            Freestyle_groupBox_Bass.TabStop = false;
            Freestyle_groupBox_Bass.Text = "$BASS";
            Freestyle_ButtonBox_BassMode.BackColor = SystemColors.Control;
            Freestyle_ButtonBox_BassMode.Location = new Point(21, 150);
            Freestyle_ButtonBox_BassMode.Name = "Freestyle_ButtonBox_BassMode";
            Freestyle_ButtonBox_BassMode.Size = new Size(143, 61);
            Freestyle_ButtonBox_BassMode.TabIndex = 22;
            Freestyle_ButtonBox_BassMode.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(Freestyle_ButtonBox_BassMode_ItemSelectedNotify);
            Freestyle_hSlider_BassGain.BackColor = SystemColors.Control;
            Freestyle_hSlider_BassGain.Location = new Point(13, 115);
            Freestyle_hSlider_BassGain.MoveDelta = 1U;
            Freestyle_hSlider_BassGain.Name = "Freestyle_hSlider_BassGain";
            Freestyle_hSlider_BassGain.Position = 0U;
            Freestyle_hSlider_BassGain.PositionFloat = 0.0f;
            Freestyle_hSlider_BassGain.Size = new Size(161, 24);
            Freestyle_hSlider_BassGain.TabIndex = 21;
            Freestyle_hSlider_BassGain.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_BassGain_PositionChangeNotify);
            Freestyle_label_Bass_Gain.AutoSize = true;
            Freestyle_label_Bass_Gain.Location = new Point(23, 100);
            Freestyle_label_Bass_Gain.Name = "Freestyle_label_Bass_Gain";
            Freestyle_label_Bass_Gain.Size = new Size(101, 12);
            Freestyle_label_Bass_Gain.TabIndex = 20;
            Freestyle_label_Bass_Gain.Text = "$BASS_GAIN : 0dB";
            Freestyle_hSlider_BassSpkSize.BackColor = SystemColors.Control;
            Freestyle_hSlider_BassSpkSize.Location = new Point(13, 73);
            Freestyle_hSlider_BassSpkSize.MoveDelta = 1U;
            Freestyle_hSlider_BassSpkSize.Name = "Freestyle_hSlider_BassSpkSize";
            Freestyle_hSlider_BassSpkSize.Position = 0U;
            Freestyle_hSlider_BassSpkSize.PositionFloat = 0.0f;
            Freestyle_hSlider_BassSpkSize.Size = new Size(161, 24);
            Freestyle_hSlider_BassSpkSize.TabIndex = 19;
            Freestyle_hSlider_BassSpkSize.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_BassSpkSize_PositionChangeNotify);
            Freestyle_label_Bass_SpkSize.AutoSize = true;
            Freestyle_label_Bass_SpkSize.Location = new Point(23, 58);
            Freestyle_label_Bass_SpkSize.Name = "Freestyle_label_Bass_SpkSize";
            Freestyle_label_Bass_SpkSize.Size = new Size(83, 12);
            Freestyle_label_Bass_SpkSize.TabIndex = 18;
            Freestyle_label_Bass_SpkSize.Text = "$BASS_SPKSIZE";
            Freestyle_onOffSwitch_Bass.BackColor = Color.Transparent;
            Freestyle_onOffSwitch_Bass.Location = new Point(13, 23);
            Freestyle_onOffSwitch_Bass.Name = "Freestyle_onOffSwitch_Bass";
            Freestyle_onOffSwitch_Bass.Size = new Size(49, 20);
            Freestyle_onOffSwitch_Bass.SwitchedOn = false;
            Freestyle_onOffSwitch_Bass.TabIndex = 17;
            Freestyle_onOffSwitch_Bass.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Freestyle_onOffSwitch_Bass_SwitchChangeNotify);
            Freestyle_groupBox_VHESurround.Controls.Add(Freestyle_ButtonBox_SurroundVHERoomSize);
            Freestyle_groupBox_VHESurround.Controls.Add(Freestyle_onOffSwitch_SurroundVHE);
            Freestyle_groupBox_VHESurround.Location = new Point(606, 6);
            Freestyle_groupBox_VHESurround.Name = "Freestyle_groupBox_VHESurround";
            Freestyle_groupBox_VHESurround.Size = new Size(208, 138);
            Freestyle_groupBox_VHESurround.TabIndex = 13;
            Freestyle_groupBox_VHESurround.TabStop = false;
            Freestyle_groupBox_VHESurround.Text = "$VHE_SURROUND";
            Freestyle_ButtonBox_SurroundVHERoomSize.BackColor = SystemColors.Control;
            Freestyle_ButtonBox_SurroundVHERoomSize.Location = new Point(68, 23);
            Freestyle_ButtonBox_SurroundVHERoomSize.Name = "Freestyle_ButtonBox_SurroundVHERoomSize";
            Freestyle_ButtonBox_SurroundVHERoomSize.Size = new Size(sbyte.MaxValue, 101);
            Freestyle_ButtonBox_SurroundVHERoomSize.TabIndex = 7;
            Freestyle_ButtonBox_SurroundVHERoomSize.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(Freestyle_ButtonBox_SurroundVHERoomSize_ItemSelectedNotify);
            Freestyle_onOffSwitch_SurroundVHE.BackColor = Color.Transparent;
            Freestyle_onOffSwitch_SurroundVHE.Location = new Point(13, 23);
            Freestyle_onOffSwitch_SurroundVHE.Name = "Freestyle_onOffSwitch_SurroundVHE";
            Freestyle_onOffSwitch_SurroundVHE.Size = new Size(49, 20);
            Freestyle_onOffSwitch_SurroundVHE.SwitchedOn = false;
            Freestyle_onOffSwitch_SurroundVHE.TabIndex = 6;
            Freestyle_onOffSwitch_SurroundVHE.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Freestyle_onOffSwitch_SurroundVHE_SwitchChangeNotify);
            Freestyle_groupBox_Convolver.Controls.Add(Freestyle_irShape_ConvIR);
            Freestyle_groupBox_Convolver.Controls.Add(Freestyle_onOffSwitch_Convolver);
            Freestyle_groupBox_Convolver.Controls.Add(Freestyle_hSlider_ConvIRGain);
            Freestyle_groupBox_Convolver.Controls.Add(Freestyle_openFileBox_ConvIRS);
            Freestyle_groupBox_Convolver.Controls.Add(Freestyle_label_ConvolverIRGain);
            Freestyle_groupBox_Convolver.Location = new Point(235, 6);
            Freestyle_groupBox_Convolver.Name = "Freestyle_groupBox_Convolver";
            Freestyle_groupBox_Convolver.Size = new Size(235, 179);
            Freestyle_groupBox_Convolver.TabIndex = 12;
            Freestyle_groupBox_Convolver.TabStop = false;
            Freestyle_groupBox_Convolver.Text = "$CONVOLVER";
            Freestyle_irShape_ConvIR.Location = new Point(13, 61);
            Freestyle_irShape_ConvIR.Name = "Freestyle_irShape_ConvIR";
            Freestyle_irShape_ConvIR.ShapeBackColor = Color.White;
            Freestyle_irShape_ConvIR.ShapeForeColor = Color.Black;
            Freestyle_irShape_ConvIR.Size = new Size(209, 63);
            Freestyle_irShape_ConvIR.TabIndex = 8;
            Freestyle_onOffSwitch_Convolver.BackColor = Color.Transparent;
            Freestyle_onOffSwitch_Convolver.Location = new Point(13, 23);
            Freestyle_onOffSwitch_Convolver.Name = "Freestyle_onOffSwitch_Convolver";
            Freestyle_onOffSwitch_Convolver.Size = new Size(49, 20);
            Freestyle_onOffSwitch_Convolver.SwitchedOn = false;
            Freestyle_onOffSwitch_Convolver.TabIndex = 5;
            Freestyle_onOffSwitch_Convolver.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Freestyle_onOffSwitch_Convolver_SwitchChangeNotify);
            Freestyle_hSlider_ConvIRGain.BackColor = SystemColors.Control;
            Freestyle_hSlider_ConvIRGain.Location = new Point(85, 31);
            Freestyle_hSlider_ConvIRGain.MoveDelta = 1U;
            Freestyle_hSlider_ConvIRGain.Name = "Freestyle_hSlider_ConvIRGain";
            Freestyle_hSlider_ConvIRGain.Position = 0U;
            Freestyle_hSlider_ConvIRGain.PositionFloat = 0.0f;
            Freestyle_hSlider_ConvIRGain.Size = new Size(137, 24);
            Freestyle_hSlider_ConvIRGain.TabIndex = 7;
            Freestyle_hSlider_ConvIRGain.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_ConvIRGain_PositionChangeNotify);
            Freestyle_openFileBox_ConvIRS.BackColor = SystemColors.Control;
            Freestyle_openFileBox_ConvIRS.FilePathName = "";
            Freestyle_openFileBox_ConvIRS.Location = new Point(13, 136);
            Freestyle_openFileBox_ConvIRS.Name = "Freestyle_openFileBox_ConvIRS";
            Freestyle_openFileBox_ConvIRS.Size = new Size(209, 29);
            Freestyle_openFileBox_ConvIRS.TabIndex = 9;
            Freestyle_openFileBox_ConvIRS.FileChangeNotify += new OpenFileBox.FileChangeEventDelegate(Freestyle_openFileBox_ConvIRS_FileChangeNotify);
            Freestyle_label_ConvolverIRGain.AutoSize = true;
            Freestyle_label_ConvolverIRGain.Location = new Point(95, 16);
            Freestyle_label_ConvolverIRGain.Name = "Freestyle_label_ConvolverIRGain";
            Freestyle_label_ConvolverIRGain.Size = new Size(119, 12);
            Freestyle_label_ConvolverIRGain.TabIndex = 6;
            Freestyle_label_ConvolverIRGain.Text = "$CONV_IR_GAIN : 0dB";
            Freestyle_hSlider_PostVolume.BackColor = SystemColors.Control;
            Freestyle_hSlider_PostVolume.Location = new Point(21, 118);
            Freestyle_hSlider_PostVolume.MoveDelta = 1U;
            Freestyle_hSlider_PostVolume.Name = "Freestyle_hSlider_PostVolume";
            Freestyle_hSlider_PostVolume.Position = 0U;
            Freestyle_hSlider_PostVolume.PositionFloat = 0.0f;
            Freestyle_hSlider_PostVolume.Size = new Size(208, 39);
            Freestyle_hSlider_PostVolume.TabIndex = 3;
            Freestyle_hSlider_PostVolume.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_PostVolume_PositionChangeNotify);
            Freestyle_label_PostVolume.AutoSize = true;
            Freestyle_label_PostVolume.Location = new Point(40, 100);
            Freestyle_label_PostVolume.Name = "Freestyle_label_PostVolume";
            Freestyle_label_PostVolume.Size = new Size(113, 12);
            Freestyle_label_PostVolume.TabIndex = 2;
            Freestyle_label_PostVolume.Text = "$POST_VOLUME : 0dB";
            Freestyle_hSlider_PreVolume.BackColor = SystemColors.Control;
            Freestyle_hSlider_PreVolume.Location = new Point(21, 39);
            Freestyle_hSlider_PreVolume.MoveDelta = 1U;
            Freestyle_hSlider_PreVolume.Name = "Freestyle_hSlider_PreVolume";
            Freestyle_hSlider_PreVolume.Position = 0U;
            Freestyle_hSlider_PreVolume.PositionFloat = 0.0f;
            Freestyle_hSlider_PreVolume.Size = new Size(208, 39);
            Freestyle_hSlider_PreVolume.TabIndex = 1;
            Freestyle_hSlider_PreVolume.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Freestyle_hSlider_PreVolume_PositionChangeNotify);
            Freestyle_label_PreVolume.AutoSize = true;
            Freestyle_label_PreVolume.Location = new Point(40, 21);
            Freestyle_label_PreVolume.Name = "Freestyle_label_PreVolume";
            Freestyle_label_PreVolume.Size = new Size(107, 12);
            Freestyle_label_PreVolume.TabIndex = 0;
            Freestyle_label_PreVolume.Text = "$PRE_VOLUME : 0dB";
            panel_MusicMode.Controls.Add(panel_MovieMode);
            panel_MusicMode.Controls.Add(Music_SingleButton_Compressor);
            panel_MusicMode.Controls.Add(Music_SingleButton_Equalizer);
            panel_MusicMode.Controls.Add(Music_groupBox_Reverb);
            panel_MusicMode.Controls.Add(Music_groupBox_Cure);
            panel_MusicMode.Controls.Add(Music_groupBox_Clarity);
            panel_MusicMode.Controls.Add(Music_groupBox_Bass);
            panel_MusicMode.Controls.Add(Music_groupBox_Surround);
            panel_MusicMode.Controls.Add(Music_groupBox_Convolver);
            panel_MusicMode.Controls.Add(Music_hSlider_PostVolume);
            panel_MusicMode.Controls.Add(Music_label_PostVolume);
            panel_MusicMode.Controls.Add(Music_hSlider_PreVolume);
            panel_MusicMode.Controls.Add(Music_label_PreVolume);
            panel_MusicMode.Dock = DockStyle.Fill;
            panel_MusicMode.Location = new Point(3, 17);
            panel_MusicMode.Name = "panel_MusicMode";
            panel_MusicMode.Size = new Size(835, 552);
            panel_MusicMode.TabIndex = 0;
            panel_MovieMode.Controls.Add(Movie_groupBox_SmartVolume);
            panel_MovieMode.Controls.Add(Movie_SingleButton_Compressor);
            panel_MovieMode.Controls.Add(Movie_SingleButton_Equalizer);
            panel_MovieMode.Controls.Add(Movie_groupBox_Reverb);
            panel_MovieMode.Controls.Add(Movie_groupBox_Clarity);
            panel_MovieMode.Controls.Add(Movie_groupBox_Bass);
            panel_MovieMode.Controls.Add(Movie_groupBox_Surround);
            panel_MovieMode.Controls.Add(Movie_groupBox_Convolver);
            panel_MovieMode.Controls.Add(Movie_hSlider_PostVolume);
            panel_MovieMode.Controls.Add(Movie_label_PostVolume);
            panel_MovieMode.Controls.Add(Movie_hSlider_PreVolume);
            panel_MovieMode.Controls.Add(Movie_label_PreVolume);
            panel_MovieMode.Dock = DockStyle.Fill;
            panel_MovieMode.Location = new Point(0, 0);
            panel_MovieMode.Name = "panel_MovieMode";
            panel_MovieMode.Size = new Size(835, 552);
            panel_MovieMode.TabIndex = 9;
            Movie_groupBox_SmartVolume.Controls.Add(Movie_hSlider_SmartVolumeLevel);
            Movie_groupBox_SmartVolume.Controls.Add(Movie_label_SmartVolume_Level);
            Movie_groupBox_SmartVolume.Controls.Add(Movie_hSlider_SmartVolumeMaxLevel);
            Movie_groupBox_SmartVolume.Controls.Add(Movie_label_SmartVolume_MaxLevel);
            Movie_groupBox_SmartVolume.Controls.Add(Movie_hSlider_SmartVolumeRatio);
            Movie_groupBox_SmartVolume.Controls.Add(Movie_label_SmartVolume_ControlStrength);
            Movie_groupBox_SmartVolume.Controls.Add(Movie_onOffSwitch_SmartVolume);
            Movie_groupBox_SmartVolume.Location = new Point(21, 391);
            Movie_groupBox_SmartVolume.Name = "Movie_groupBox_SmartVolume";
            Movie_groupBox_SmartVolume.Size = new Size(579, 148);
            Movie_groupBox_SmartVolume.TabIndex = 22;
            Movie_groupBox_SmartVolume.TabStop = false;
            Movie_groupBox_SmartVolume.Text = "$SMART_VOLUME";
            Movie_hSlider_SmartVolumeLevel.BackColor = SystemColors.Control;
            Movie_hSlider_SmartVolumeLevel.Location = new Point(254, 78);
            Movie_hSlider_SmartVolumeLevel.MoveDelta = 1U;
            Movie_hSlider_SmartVolumeLevel.Name = "Movie_hSlider_SmartVolumeLevel";
            Movie_hSlider_SmartVolumeLevel.Position = 0U;
            Movie_hSlider_SmartVolumeLevel.PositionFloat = 0.0f;
            Movie_hSlider_SmartVolumeLevel.Size = new Size(319, 39);
            Movie_hSlider_SmartVolumeLevel.TabIndex = 23;
            Movie_hSlider_SmartVolumeLevel.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_SmartVolumeLevel_PositionChangeNotify);
            Movie_label_SmartVolume_Level.AutoSize = true;
            Movie_label_SmartVolume_Level.Location = new Point(273, 60);
            Movie_label_SmartVolume_Level.Name = "Movie_label_SmartVolume_Level";
            Movie_label_SmartVolume_Level.Size = new Size(155, 12);
            Movie_label_SmartVolume_Level.TabIndex = 22;
            Movie_label_SmartVolume_Level.Text = "$SMART_VOLUME_LEVEL : 0dB";
            Movie_hSlider_SmartVolumeMaxLevel.BackColor = SystemColors.Control;
            Movie_hSlider_SmartVolumeMaxLevel.Location = new Point(13, 115);
            Movie_hSlider_SmartVolumeMaxLevel.MoveDelta = 1U;
            Movie_hSlider_SmartVolumeMaxLevel.Name = "Movie_hSlider_SmartVolumeMaxLevel";
            Movie_hSlider_SmartVolumeMaxLevel.Position = 0U;
            Movie_hSlider_SmartVolumeMaxLevel.PositionFloat = 0.0f;
            Movie_hSlider_SmartVolumeMaxLevel.Size = new Size(161, 24);
            Movie_hSlider_SmartVolumeMaxLevel.TabIndex = 21;
            Movie_hSlider_SmartVolumeMaxLevel.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_SmartVolumeMaxLevel_PositionChangeNotify);
            Movie_label_SmartVolume_MaxLevel.AutoSize = true;
            Movie_label_SmartVolume_MaxLevel.Location = new Point(23, 100);
            Movie_label_SmartVolume_MaxLevel.Name = "Movie_label_SmartVolume_MaxLevel";
            Movie_label_SmartVolume_MaxLevel.Size = new Size(167, 12);
            Movie_label_SmartVolume_MaxLevel.TabIndex = 20;
            Movie_label_SmartVolume_MaxLevel.Text = "$SMART_VOLUME_MAXLEVEL : 1x";
            Movie_hSlider_SmartVolumeRatio.BackColor = SystemColors.Control;
            Movie_hSlider_SmartVolumeRatio.Location = new Point(13, 73);
            Movie_hSlider_SmartVolumeRatio.MoveDelta = 1U;
            Movie_hSlider_SmartVolumeRatio.Name = "Movie_hSlider_SmartVolumeRatio";
            Movie_hSlider_SmartVolumeRatio.Position = 0U;
            Movie_hSlider_SmartVolumeRatio.PositionFloat = 0.0f;
            Movie_hSlider_SmartVolumeRatio.Size = new Size(161, 24);
            Movie_hSlider_SmartVolumeRatio.TabIndex = 19;
            Movie_hSlider_SmartVolumeRatio.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_SmartVolumeRatio_PositionChangeNotify);
            Movie_label_SmartVolume_ControlStrength.AutoSize = true;
            Movie_label_SmartVolume_ControlStrength.Location = new Point(23, 58);
            Movie_label_SmartVolume_ControlStrength.Name = "Movie_label_SmartVolume_ControlStrength";
            Movie_label_SmartVolume_ControlStrength.Size = new Size(185, 12);
            Movie_label_SmartVolume_ControlStrength.TabIndex = 18;
            Movie_label_SmartVolume_ControlStrength.Text = "$SMART_VOLUME_CONTROL_STRENGTH";
            Movie_onOffSwitch_SmartVolume.BackColor = Color.Transparent;
            Movie_onOffSwitch_SmartVolume.Location = new Point(13, 23);
            Movie_onOffSwitch_SmartVolume.Name = "Movie_onOffSwitch_SmartVolume";
            Movie_onOffSwitch_SmartVolume.Size = new Size(49, 20);
            Movie_onOffSwitch_SmartVolume.SwitchedOn = false;
            Movie_onOffSwitch_SmartVolume.TabIndex = 17;
            Movie_onOffSwitch_SmartVolume.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Movie_onOffSwitch_SmartVolume_SwitchChangeNotify);
            Movie_SingleButton_Compressor.BackColor = SystemColors.Control;
            Movie_SingleButton_Compressor.ButtonText = "$COMPRESSOR_ADJUST";
            Movie_SingleButton_Compressor.Location = new Point(420, 301);
            Movie_SingleButton_Compressor.Name = "Movie_SingleButton_Compressor";
            Movie_SingleButton_Compressor.Size = new Size(174, 39);
            Movie_SingleButton_Compressor.TabIndex = 21;
            Movie_SingleButton_Compressor.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(Movie_SingleButton_Compressor_ButtonClickNotify);
            Movie_SingleButton_Equalizer.BackColor = SystemColors.Control;
            Movie_SingleButton_Equalizer.ButtonText = "$EQUALIZER_ADJUST";
            Movie_SingleButton_Equalizer.Location = new Point(420, 245);
            Movie_SingleButton_Equalizer.Name = "Movie_SingleButton_Equalizer";
            Movie_SingleButton_Equalizer.Size = new Size(174, 39);
            Movie_SingleButton_Equalizer.TabIndex = 20;
            Movie_SingleButton_Equalizer.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(Movie_SingleButton_Equalizer_ButtonClickNotify);
            Movie_groupBox_Reverb.Controls.Add(Movie_SingleButton_ReverbPreset);
            Movie_groupBox_Reverb.Controls.Add(Movie_hSlider_ReverbMix);
            Movie_groupBox_Reverb.Controls.Add(Movie_label_Reverb_Mix);
            Movie_groupBox_Reverb.Controls.Add(Movie_hSlider_ReverbEarlyMix);
            Movie_groupBox_Reverb.Controls.Add(Movie_label_Reverb_EarlyMix);
            Movie_groupBox_Reverb.Controls.Add(Movie_hSlider_ReverbPreDelay);
            Movie_groupBox_Reverb.Controls.Add(Movie_label_Reverb_PreDelay);
            Movie_groupBox_Reverb.Controls.Add(Movie_hSlider_ReverbDecay);
            Movie_groupBox_Reverb.Controls.Add(Movie_label_Reverb_Decay);
            Movie_groupBox_Reverb.Controls.Add(Movie_hSlider_ReverbBandWidth);
            Movie_groupBox_Reverb.Controls.Add(Movie_label_Reverb_BandWidth);
            Movie_groupBox_Reverb.Controls.Add(Movie_hSlider_ReverbDensity);
            Movie_groupBox_Reverb.Controls.Add(Movie_label_Reverb_Density);
            Movie_groupBox_Reverb.Controls.Add(Movie_hSlider_ReverbDamping);
            Movie_groupBox_Reverb.Controls.Add(Movie_label_Reverb_Damping);
            Movie_groupBox_Reverb.Controls.Add(Movie_hSlider_ReverbSize);
            Movie_groupBox_Reverb.Controls.Add(Movie_label_Reverb_Size);
            Movie_groupBox_Reverb.Controls.Add(Movie_onOffSwitch_Reverb);
            Movie_groupBox_Reverb.Location = new Point(606, 150);
            Movie_groupBox_Reverb.Name = "Movie_groupBox_Reverb";
            Movie_groupBox_Reverb.Size = new Size(208, 389);
            Movie_groupBox_Reverb.TabIndex = 19;
            Movie_groupBox_Reverb.TabStop = false;
            Movie_groupBox_Reverb.Text = "$REVERB";
            Movie_SingleButton_ReverbPreset.BackColor = SystemColors.Control;
            Movie_SingleButton_ReverbPreset.ButtonText = "$PRESET";
            Movie_SingleButton_ReverbPreset.Location = new Point(121, 14);
            Movie_SingleButton_ReverbPreset.Name = "Movie_SingleButton_ReverbPreset";
            Movie_SingleButton_ReverbPreset.Size = new Size(81, 29);
            Movie_SingleButton_ReverbPreset.TabIndex = 36;
            Movie_SingleButton_ReverbPreset.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(Movie_SingleButton_ReverbPreset_ButtonClickNotify);
            Movie_hSlider_ReverbMix.BackColor = SystemColors.Control;
            Movie_hSlider_ReverbMix.Location = new Point(24, 356);
            Movie_hSlider_ReverbMix.MoveDelta = 1U;
            Movie_hSlider_ReverbMix.Name = "Movie_hSlider_ReverbMix";
            Movie_hSlider_ReverbMix.Position = 0U;
            Movie_hSlider_ReverbMix.PositionFloat = 0.0f;
            Movie_hSlider_ReverbMix.Size = new Size(161, 24);
            Movie_hSlider_ReverbMix.TabIndex = 35;
            Movie_hSlider_ReverbMix.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_ReverbMix_PositionChangeNotify);
            Movie_label_Reverb_Mix.AutoSize = true;
            Movie_label_Reverb_Mix.Location = new Point(34, 341);
            Movie_label_Reverb_Mix.Name = "Movie_label_Reverb_Mix";
            Movie_label_Reverb_Mix.Size = new Size(71, 12);
            Movie_label_Reverb_Mix.TabIndex = 34;
            Movie_label_Reverb_Mix.Text = "$REVERB_MIX";
            Movie_hSlider_ReverbEarlyMix.BackColor = SystemColors.Control;
            Movie_hSlider_ReverbEarlyMix.Location = new Point(24, 314);
            Movie_hSlider_ReverbEarlyMix.MoveDelta = 1U;
            Movie_hSlider_ReverbEarlyMix.Name = "Movie_hSlider_ReverbEarlyMix";
            Movie_hSlider_ReverbEarlyMix.Position = 0U;
            Movie_hSlider_ReverbEarlyMix.PositionFloat = 0.0f;
            Movie_hSlider_ReverbEarlyMix.Size = new Size(161, 24);
            Movie_hSlider_ReverbEarlyMix.TabIndex = 33;
            Movie_hSlider_ReverbEarlyMix.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_ReverbEarlyMix_PositionChangeNotify);
            Movie_label_Reverb_EarlyMix.AutoSize = true;
            Movie_label_Reverb_EarlyMix.Location = new Point(34, 299);
            Movie_label_Reverb_EarlyMix.Name = "Movie_label_Reverb_EarlyMix";
            Movie_label_Reverb_EarlyMix.Size = new Size(101, 12);
            Movie_label_Reverb_EarlyMix.TabIndex = 32;
            Movie_label_Reverb_EarlyMix.Text = "$REVERB_EARLYMIX";
            Movie_hSlider_ReverbPreDelay.BackColor = SystemColors.Control;
            Movie_hSlider_ReverbPreDelay.Location = new Point(24, 272);
            Movie_hSlider_ReverbPreDelay.MoveDelta = 1U;
            Movie_hSlider_ReverbPreDelay.Name = "Movie_hSlider_ReverbPreDelay";
            Movie_hSlider_ReverbPreDelay.Position = 0U;
            Movie_hSlider_ReverbPreDelay.PositionFloat = 0.0f;
            Movie_hSlider_ReverbPreDelay.Size = new Size(161, 24);
            Movie_hSlider_ReverbPreDelay.TabIndex = 31;
            Movie_hSlider_ReverbPreDelay.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_ReverbPreDelay_PositionChangeNotify);
            Movie_label_Reverb_PreDelay.AutoSize = true;
            Movie_label_Reverb_PreDelay.Location = new Point(34, 257);
            Movie_label_Reverb_PreDelay.Name = "Movie_label_Reverb_PreDelay";
            Movie_label_Reverb_PreDelay.Size = new Size(101, 12);
            Movie_label_Reverb_PreDelay.TabIndex = 30;
            Movie_label_Reverb_PreDelay.Text = "$REVERB_PREDELAY";
            Movie_hSlider_ReverbDecay.BackColor = SystemColors.Control;
            Movie_hSlider_ReverbDecay.Location = new Point(24, 230);
            Movie_hSlider_ReverbDecay.MoveDelta = 1U;
            Movie_hSlider_ReverbDecay.Name = "Movie_hSlider_ReverbDecay";
            Movie_hSlider_ReverbDecay.Position = 0U;
            Movie_hSlider_ReverbDecay.PositionFloat = 0.0f;
            Movie_hSlider_ReverbDecay.Size = new Size(161, 24);
            Movie_hSlider_ReverbDecay.TabIndex = 29;
            Movie_hSlider_ReverbDecay.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_ReverbDecay_PositionChangeNotify);
            Movie_label_Reverb_Decay.AutoSize = true;
            Movie_label_Reverb_Decay.Location = new Point(34, 215);
            Movie_label_Reverb_Decay.Name = "Movie_label_Reverb_Decay";
            Movie_label_Reverb_Decay.Size = new Size(83, 12);
            Movie_label_Reverb_Decay.TabIndex = 28;
            Movie_label_Reverb_Decay.Text = "$REVERB_DECAY";
            Movie_hSlider_ReverbBandWidth.BackColor = SystemColors.Control;
            Movie_hSlider_ReverbBandWidth.Location = new Point(24, 188);
            Movie_hSlider_ReverbBandWidth.MoveDelta = 1U;
            Movie_hSlider_ReverbBandWidth.Name = "Movie_hSlider_ReverbBandWidth";
            Movie_hSlider_ReverbBandWidth.Position = 0U;
            Movie_hSlider_ReverbBandWidth.PositionFloat = 0.0f;
            Movie_hSlider_ReverbBandWidth.Size = new Size(161, 24);
            Movie_hSlider_ReverbBandWidth.TabIndex = 27;
            Movie_hSlider_ReverbBandWidth.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_ReverbBandWidth_PositionChangeNotify);
            Movie_label_Reverb_BandWidth.AutoSize = true;
            Movie_label_Reverb_BandWidth.Location = new Point(34, 173);
            Movie_label_Reverb_BandWidth.Name = "Movie_label_Reverb_BandWidth";
            Movie_label_Reverb_BandWidth.Size = new Size(107, 12);
            Movie_label_Reverb_BandWidth.TabIndex = 26;
            Movie_label_Reverb_BandWidth.Text = "$REVERB_BANDWIDTH";
            Movie_hSlider_ReverbDensity.BackColor = SystemColors.Control;
            Movie_hSlider_ReverbDensity.Location = new Point(24, 146);
            Movie_hSlider_ReverbDensity.MoveDelta = 1U;
            Movie_hSlider_ReverbDensity.Name = "Movie_hSlider_ReverbDensity";
            Movie_hSlider_ReverbDensity.Position = 0U;
            Movie_hSlider_ReverbDensity.PositionFloat = 0.0f;
            Movie_hSlider_ReverbDensity.Size = new Size(161, 24);
            Movie_hSlider_ReverbDensity.TabIndex = 25;
            Movie_hSlider_ReverbDensity.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_ReverbDensity_PositionChangeNotify);
            Movie_label_Reverb_Density.AutoSize = true;
            Movie_label_Reverb_Density.Location = new Point(34, 131);
            Movie_label_Reverb_Density.Name = "Movie_label_Reverb_Density";
            Movie_label_Reverb_Density.Size = new Size(95, 12);
            Movie_label_Reverb_Density.TabIndex = 24;
            Movie_label_Reverb_Density.Text = "$REVERB_DENSITY";
            Movie_hSlider_ReverbDamping.BackColor = SystemColors.Control;
            Movie_hSlider_ReverbDamping.Location = new Point(24, 104);
            Movie_hSlider_ReverbDamping.MoveDelta = 1U;
            Movie_hSlider_ReverbDamping.Name = "Movie_hSlider_ReverbDamping";
            Movie_hSlider_ReverbDamping.Position = 0U;
            Movie_hSlider_ReverbDamping.PositionFloat = 0.0f;
            Movie_hSlider_ReverbDamping.Size = new Size(161, 24);
            Movie_hSlider_ReverbDamping.TabIndex = 23;
            Movie_hSlider_ReverbDamping.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_ReverbDamping_PositionChangeNotify);
            Movie_label_Reverb_Damping.AutoSize = true;
            Movie_label_Reverb_Damping.Location = new Point(34, 89);
            Movie_label_Reverb_Damping.Name = "Movie_label_Reverb_Damping";
            Movie_label_Reverb_Damping.Size = new Size(95, 12);
            Movie_label_Reverb_Damping.TabIndex = 22;
            Movie_label_Reverb_Damping.Text = "$REVERB_DAMPING";
            Movie_hSlider_ReverbSize.BackColor = SystemColors.Control;
            Movie_hSlider_ReverbSize.Location = new Point(24, 64);
            Movie_hSlider_ReverbSize.MoveDelta = 1U;
            Movie_hSlider_ReverbSize.Name = "Movie_hSlider_ReverbSize";
            Movie_hSlider_ReverbSize.Position = 0U;
            Movie_hSlider_ReverbSize.PositionFloat = 0.0f;
            Movie_hSlider_ReverbSize.Size = new Size(161, 24);
            Movie_hSlider_ReverbSize.TabIndex = 21;
            Movie_hSlider_ReverbSize.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_ReverbSize_PositionChangeNotify);
            Movie_label_Reverb_Size.AutoSize = true;
            Movie_label_Reverb_Size.Location = new Point(34, 49);
            Movie_label_Reverb_Size.Name = "Movie_label_Reverb_Size";
            Movie_label_Reverb_Size.Size = new Size(77, 12);
            Movie_label_Reverb_Size.TabIndex = 20;
            Movie_label_Reverb_Size.Text = "$REVERB_SIZE";
            Movie_onOffSwitch_Reverb.BackColor = Color.Transparent;
            Movie_onOffSwitch_Reverb.Location = new Point(13, 23);
            Movie_onOffSwitch_Reverb.Name = "Movie_onOffSwitch_Reverb";
            Movie_onOffSwitch_Reverb.Size = new Size(49, 20);
            Movie_onOffSwitch_Reverb.SwitchedOn = false;
            Movie_onOffSwitch_Reverb.TabIndex = 7;
            Movie_onOffSwitch_Reverb.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Movie_onOffSwitch_Reverb_SwitchChangeNotify);
            Movie_groupBox_Clarity.Controls.Add(Movie_hSlider_Clarity);
            Movie_groupBox_Clarity.Controls.Add(Movie_label_Clarity);
            Movie_groupBox_Clarity.Controls.Add(Movie_onOffSwitch_Clarity);
            Movie_groupBox_Clarity.Location = new Point(216, 213);
            Movie_groupBox_Clarity.Name = "Movie_groupBox_Clarity";
            Movie_groupBox_Clarity.Size = new Size(189, 148);
            Movie_groupBox_Clarity.TabIndex = 17;
            Movie_groupBox_Clarity.TabStop = false;
            Movie_groupBox_Clarity.Text = "$CLARITY";
            Movie_hSlider_Clarity.BackColor = SystemColors.Control;
            Movie_hSlider_Clarity.Location = new Point(13, 93);
            Movie_hSlider_Clarity.MoveDelta = 1U;
            Movie_hSlider_Clarity.Name = "Movie_hSlider_Clarity";
            Movie_hSlider_Clarity.Position = 0U;
            Movie_hSlider_Clarity.PositionFloat = 0.0f;
            Movie_hSlider_Clarity.Size = new Size(161, 24);
            Movie_hSlider_Clarity.TabIndex = 21;
            Movie_hSlider_Clarity.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_Clarity_PositionChangeNotify);
            Movie_label_Clarity.AutoSize = true;
            Movie_label_Clarity.Location = new Point(23, 78);
            Movie_label_Clarity.Name = "Movie_label_Clarity";
            Movie_label_Clarity.Size = new Size(89, 12);
            Movie_label_Clarity.TabIndex = 20;
            Movie_label_Clarity.Text = "$CLARITY : 0dB";
            Movie_onOffSwitch_Clarity.BackColor = Color.Transparent;
            Movie_onOffSwitch_Clarity.Location = new Point(13, 23);
            Movie_onOffSwitch_Clarity.Name = "Movie_onOffSwitch_Clarity";
            Movie_onOffSwitch_Clarity.Size = new Size(49, 20);
            Movie_onOffSwitch_Clarity.SwitchedOn = false;
            Movie_onOffSwitch_Clarity.TabIndex = 17;
            Movie_onOffSwitch_Clarity.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Movie_onOffSwitch_Clarity_SwitchChangeNotify);
            Movie_groupBox_Bass.Controls.Add(Movie_hSlider_BassGain);
            Movie_groupBox_Bass.Controls.Add(Movie_label_Bass_Gain);
            Movie_groupBox_Bass.Controls.Add(Movie_hSlider_BassSpkSize);
            Movie_groupBox_Bass.Controls.Add(Movie_label_Bass_SpkSize);
            Movie_groupBox_Bass.Controls.Add(Movie_onOffSwitch_Bass);
            Movie_groupBox_Bass.Location = new Point(21, 213);
            Movie_groupBox_Bass.Name = "Movie_groupBox_Bass";
            Movie_groupBox_Bass.Size = new Size(189, 148);
            Movie_groupBox_Bass.TabIndex = 16;
            Movie_groupBox_Bass.TabStop = false;
            Movie_groupBox_Bass.Text = "$BASS";
            Movie_hSlider_BassGain.BackColor = SystemColors.Control;
            Movie_hSlider_BassGain.Location = new Point(13, 115);
            Movie_hSlider_BassGain.MoveDelta = 1U;
            Movie_hSlider_BassGain.Name = "Movie_hSlider_BassGain";
            Movie_hSlider_BassGain.Position = 0U;
            Movie_hSlider_BassGain.PositionFloat = 0.0f;
            Movie_hSlider_BassGain.Size = new Size(161, 24);
            Movie_hSlider_BassGain.TabIndex = 21;
            Movie_hSlider_BassGain.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_BassGain_PositionChangeNotify);
            Movie_label_Bass_Gain.AutoSize = true;
            Movie_label_Bass_Gain.Location = new Point(23, 100);
            Movie_label_Bass_Gain.Name = "Movie_label_Bass_Gain";
            Movie_label_Bass_Gain.Size = new Size(101, 12);
            Movie_label_Bass_Gain.TabIndex = 20;
            Movie_label_Bass_Gain.Text = "$BASS_GAIN : 0dB";
            Movie_hSlider_BassSpkSize.BackColor = SystemColors.Control;
            Movie_hSlider_BassSpkSize.Location = new Point(13, 73);
            Movie_hSlider_BassSpkSize.MoveDelta = 1U;
            Movie_hSlider_BassSpkSize.Name = "Movie_hSlider_BassSpkSize";
            Movie_hSlider_BassSpkSize.Position = 0U;
            Movie_hSlider_BassSpkSize.PositionFloat = 0.0f;
            Movie_hSlider_BassSpkSize.Size = new Size(161, 24);
            Movie_hSlider_BassSpkSize.TabIndex = 19;
            Movie_hSlider_BassSpkSize.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_BassSpkSize_PositionChangeNotify);
            Movie_label_Bass_SpkSize.AutoSize = true;
            Movie_label_Bass_SpkSize.Location = new Point(23, 58);
            Movie_label_Bass_SpkSize.Name = "Movie_label_Bass_SpkSize";
            Movie_label_Bass_SpkSize.Size = new Size(83, 12);
            Movie_label_Bass_SpkSize.TabIndex = 18;
            Movie_label_Bass_SpkSize.Text = "$BASS_SPKSIZE";
            Movie_onOffSwitch_Bass.BackColor = Color.Transparent;
            Movie_onOffSwitch_Bass.Location = new Point(13, 23);
            Movie_onOffSwitch_Bass.Name = "Movie_onOffSwitch_Bass";
            Movie_onOffSwitch_Bass.Size = new Size(49, 20);
            Movie_onOffSwitch_Bass.SwitchedOn = false;
            Movie_onOffSwitch_Bass.TabIndex = 17;
            Movie_onOffSwitch_Bass.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Movie_onOffSwitch_Bass_SwitchChangeNotify);
            Movie_groupBox_Surround.Controls.Add(Movie_hSlider_SurroundImage);
            Movie_groupBox_Surround.Controls.Add(Movie_label_Surround_Image);
            Movie_groupBox_Surround.Controls.Add(Movie_hSlider_Surround3D);
            Movie_groupBox_Surround.Controls.Add(Movie_label_Surround_3D);
            Movie_groupBox_Surround.Controls.Add(Movie_onOffSwitch_Surround);
            Movie_groupBox_Surround.Location = new Point(606, 6);
            Movie_groupBox_Surround.Name = "Movie_groupBox_Surround";
            Movie_groupBox_Surround.Size = new Size(208, 138);
            Movie_groupBox_Surround.TabIndex = 13;
            Movie_groupBox_Surround.TabStop = false;
            Movie_groupBox_Surround.Text = "$SURROUND";
            Movie_hSlider_SurroundImage.BackColor = SystemColors.Control;
            Movie_hSlider_SurroundImage.Location = new Point(24, 109);
            Movie_hSlider_SurroundImage.MoveDelta = 1U;
            Movie_hSlider_SurroundImage.Name = "Movie_hSlider_SurroundImage";
            Movie_hSlider_SurroundImage.Position = 0U;
            Movie_hSlider_SurroundImage.PositionFloat = 0.0f;
            Movie_hSlider_SurroundImage.Size = new Size(161, 24);
            Movie_hSlider_SurroundImage.TabIndex = 25;
            Movie_hSlider_SurroundImage.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_SurroundImage_PositionChangeNotify);
            Movie_label_Surround_Image.AutoSize = true;
            Movie_label_Surround_Image.Location = new Point(34, 94);
            Movie_label_Surround_Image.Name = "Movie_label_Surround_Image";
            Movie_label_Surround_Image.Size = new Size(95, 12);
            Movie_label_Surround_Image.TabIndex = 24;
            Movie_label_Surround_Image.Text = "$SURROUND_IMAGE";
            Movie_hSlider_Surround3D.BackColor = SystemColors.Control;
            Movie_hSlider_Surround3D.Location = new Point(24, 67);
            Movie_hSlider_Surround3D.MoveDelta = 1U;
            Movie_hSlider_Surround3D.Name = "Movie_hSlider_Surround3D";
            Movie_hSlider_Surround3D.Position = 0U;
            Movie_hSlider_Surround3D.PositionFloat = 0.0f;
            Movie_hSlider_Surround3D.Size = new Size(161, 24);
            Movie_hSlider_Surround3D.TabIndex = 23;
            Movie_hSlider_Surround3D.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_Surround3D_PositionChangeNotify);
            Movie_label_Surround_3D.AutoSize = true;
            Movie_label_Surround_3D.Location = new Point(34, 52);
            Movie_label_Surround_3D.Name = "Movie_label_Surround_3D";
            Movie_label_Surround_3D.Size = new Size(77, 12);
            Movie_label_Surround_3D.TabIndex = 22;
            Movie_label_Surround_3D.Text = "$SURROUND_3D";
            Movie_onOffSwitch_Surround.BackColor = Color.Transparent;
            Movie_onOffSwitch_Surround.Location = new Point(13, 23);
            Movie_onOffSwitch_Surround.Name = "Movie_onOffSwitch_Surround";
            Movie_onOffSwitch_Surround.Size = new Size(49, 20);
            Movie_onOffSwitch_Surround.SwitchedOn = false;
            Movie_onOffSwitch_Surround.TabIndex = 6;
            Movie_onOffSwitch_Surround.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Movie_onOffSwitch_Surround_SwitchChangeNotify);
            Movie_groupBox_Convolver.Controls.Add(Movie_irShape_ConvIR);
            Movie_groupBox_Convolver.Controls.Add(Movie_onOffSwitch_Convolver);
            Movie_groupBox_Convolver.Controls.Add(Movie_hSlider_ConvIRGain);
            Movie_groupBox_Convolver.Controls.Add(Movie_openFileBox_ConvIRS);
            Movie_groupBox_Convolver.Controls.Add(Movie_label_ConvolverIRGain);
            Movie_groupBox_Convolver.Location = new Point(312, 6);
            Movie_groupBox_Convolver.Name = "Movie_groupBox_Convolver";
            Movie_groupBox_Convolver.Size = new Size(288, 179);
            Movie_groupBox_Convolver.TabIndex = 12;
            Movie_groupBox_Convolver.TabStop = false;
            Movie_groupBox_Convolver.Text = "$CONVOLVER";
            Movie_irShape_ConvIR.Location = new Point(13, 61);
            Movie_irShape_ConvIR.Name = "Movie_irShape_ConvIR";
            Movie_irShape_ConvIR.ShapeBackColor = Color.White;
            Movie_irShape_ConvIR.ShapeForeColor = Color.Black;
            Movie_irShape_ConvIR.Size = new Size(260, 63);
            Movie_irShape_ConvIR.TabIndex = 8;
            Movie_onOffSwitch_Convolver.BackColor = Color.Transparent;
            Movie_onOffSwitch_Convolver.Location = new Point(13, 23);
            Movie_onOffSwitch_Convolver.Name = "Movie_onOffSwitch_Convolver";
            Movie_onOffSwitch_Convolver.Size = new Size(49, 20);
            Movie_onOffSwitch_Convolver.SwitchedOn = false;
            Movie_onOffSwitch_Convolver.TabIndex = 5;
            Movie_onOffSwitch_Convolver.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Movie_onOffSwitch_Convolver_SwitchChangeNotify);
            Movie_hSlider_ConvIRGain.BackColor = SystemColors.Control;
            Movie_hSlider_ConvIRGain.Location = new Point(85, 31);
            Movie_hSlider_ConvIRGain.MoveDelta = 1U;
            Movie_hSlider_ConvIRGain.Name = "Movie_hSlider_ConvIRGain";
            Movie_hSlider_ConvIRGain.Position = 0U;
            Movie_hSlider_ConvIRGain.PositionFloat = 0.0f;
            Movie_hSlider_ConvIRGain.Size = new Size(188, 24);
            Movie_hSlider_ConvIRGain.TabIndex = 7;
            Movie_hSlider_ConvIRGain.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_ConvIRGain_PositionChangeNotify);
            Movie_openFileBox_ConvIRS.BackColor = SystemColors.Control;
            Movie_openFileBox_ConvIRS.FilePathName = "";
            Movie_openFileBox_ConvIRS.Location = new Point(13, 136);
            Movie_openFileBox_ConvIRS.Name = "Movie_openFileBox_ConvIRS";
            Movie_openFileBox_ConvIRS.Size = new Size(260, 29);
            Movie_openFileBox_ConvIRS.TabIndex = 9;
            Movie_openFileBox_ConvIRS.FileChangeNotify += new OpenFileBox.FileChangeEventDelegate(Movie_openFileBox_ConvIRS_FileChangeNotify);
            Movie_label_ConvolverIRGain.AutoSize = true;
            Movie_label_ConvolverIRGain.Location = new Point(95, 16);
            Movie_label_ConvolverIRGain.Name = "Movie_label_ConvolverIRGain";
            Movie_label_ConvolverIRGain.Size = new Size(119, 12);
            Movie_label_ConvolverIRGain.TabIndex = 6;
            Movie_label_ConvolverIRGain.Text = "$CONV_IR_GAIN : 0dB";
            Movie_hSlider_PostVolume.BackColor = SystemColors.Control;
            Movie_hSlider_PostVolume.Location = new Point(21, 118);
            Movie_hSlider_PostVolume.MoveDelta = 1U;
            Movie_hSlider_PostVolume.Name = "Movie_hSlider_PostVolume";
            Movie_hSlider_PostVolume.Position = 0U;
            Movie_hSlider_PostVolume.PositionFloat = 0.0f;
            Movie_hSlider_PostVolume.Size = new Size(285, 39);
            Movie_hSlider_PostVolume.TabIndex = 3;
            Movie_hSlider_PostVolume.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_PostVolume_PositionChangeNotify);
            Movie_label_PostVolume.AutoSize = true;
            Movie_label_PostVolume.Location = new Point(40, 100);
            Movie_label_PostVolume.Name = "Movie_label_PostVolume";
            Movie_label_PostVolume.Size = new Size(113, 12);
            Movie_label_PostVolume.TabIndex = 2;
            Movie_label_PostVolume.Text = "$POST_VOLUME : 0dB";
            Movie_hSlider_PreVolume.BackColor = SystemColors.Control;
            Movie_hSlider_PreVolume.Location = new Point(21, 39);
            Movie_hSlider_PreVolume.MoveDelta = 1U;
            Movie_hSlider_PreVolume.Name = "Movie_hSlider_PreVolume";
            Movie_hSlider_PreVolume.Position = 0U;
            Movie_hSlider_PreVolume.PositionFloat = 0.0f;
            Movie_hSlider_PreVolume.Size = new Size(285, 39);
            Movie_hSlider_PreVolume.TabIndex = 1;
            Movie_hSlider_PreVolume.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Movie_hSlider_PreVolume_PositionChangeNotify);
            Movie_label_PreVolume.AutoSize = true;
            Movie_label_PreVolume.Location = new Point(40, 21);
            Movie_label_PreVolume.Name = "Movie_label_PreVolume";
            Movie_label_PreVolume.Size = new Size(107, 12);
            Movie_label_PreVolume.TabIndex = 0;
            Movie_label_PreVolume.Text = "$PRE_VOLUME : 0dB";
            Music_SingleButton_Compressor.BackColor = SystemColors.Control;
            Music_SingleButton_Compressor.ButtonText = "$COMPRESSOR_ADJUST";
            Music_SingleButton_Compressor.Location = new Point(216, 460);
            Music_SingleButton_Compressor.Name = "Music_SingleButton_Compressor";
            Music_SingleButton_Compressor.Size = new Size(174, 39);
            Music_SingleButton_Compressor.TabIndex = 21;
            Music_SingleButton_Compressor.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(Music_SingleButton_Compressor_ButtonClickNotify);
            Music_SingleButton_Equalizer.BackColor = SystemColors.Control;
            Music_SingleButton_Equalizer.ButtonText = "$EQUALIZER_ADJUST";
            Music_SingleButton_Equalizer.Location = new Point(216, 404);
            Music_SingleButton_Equalizer.Name = "Music_SingleButton_Equalizer";
            Music_SingleButton_Equalizer.Size = new Size(174, 39);
            Music_SingleButton_Equalizer.TabIndex = 20;
            Music_SingleButton_Equalizer.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(Music_SingleButton_Equalizer_ButtonClickNotify);
            Music_groupBox_Reverb.Controls.Add(Music_SingleButton_ReverbPreset);
            Music_groupBox_Reverb.Controls.Add(Music_hSlider_ReverbMix);
            Music_groupBox_Reverb.Controls.Add(Music_label_Reverb_Mix);
            Music_groupBox_Reverb.Controls.Add(Music_hSlider_ReverbEarlyMix);
            Music_groupBox_Reverb.Controls.Add(Music_label_Reverb_EarlyMix);
            Music_groupBox_Reverb.Controls.Add(Music_hSlider_ReverbPreDelay);
            Music_groupBox_Reverb.Controls.Add(Music_label_Reverb_PreDelay);
            Music_groupBox_Reverb.Controls.Add(Music_hSlider_ReverbDecay);
            Music_groupBox_Reverb.Controls.Add(Music_label_Reverb_Decay);
            Music_groupBox_Reverb.Controls.Add(Music_hSlider_ReverbBandWidth);
            Music_groupBox_Reverb.Controls.Add(Music_label_Reverb_BandWidth);
            Music_groupBox_Reverb.Controls.Add(Music_hSlider_ReverbDensity);
            Music_groupBox_Reverb.Controls.Add(Music_label_Reverb_Density);
            Music_groupBox_Reverb.Controls.Add(Music_hSlider_ReverbDamping);
            Music_groupBox_Reverb.Controls.Add(Music_label_Reverb_Damping);
            Music_groupBox_Reverb.Controls.Add(Music_hSlider_ReverbSize);
            Music_groupBox_Reverb.Controls.Add(Music_label_Reverb_Size);
            Music_groupBox_Reverb.Controls.Add(Music_onOffSwitch_Reverb);
            Music_groupBox_Reverb.Location = new Point(606, 150);
            Music_groupBox_Reverb.Name = "Music_groupBox_Reverb";
            Music_groupBox_Reverb.Size = new Size(208, 389);
            Music_groupBox_Reverb.TabIndex = 19;
            Music_groupBox_Reverb.TabStop = false;
            Music_groupBox_Reverb.Text = "$REVERB";
            Music_SingleButton_ReverbPreset.BackColor = SystemColors.Control;
            Music_SingleButton_ReverbPreset.ButtonText = "$PRESET";
            Music_SingleButton_ReverbPreset.Location = new Point(121, 14);
            Music_SingleButton_ReverbPreset.Name = "Music_SingleButton_ReverbPreset";
            Music_SingleButton_ReverbPreset.Size = new Size(81, 29);
            Music_SingleButton_ReverbPreset.TabIndex = 36;
            Music_SingleButton_ReverbPreset.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(Music_SingleButton_ReverbPreset_ButtonClickNotify);
            Music_hSlider_ReverbMix.BackColor = SystemColors.Control;
            Music_hSlider_ReverbMix.Location = new Point(24, 356);
            Music_hSlider_ReverbMix.MoveDelta = 1U;
            Music_hSlider_ReverbMix.Name = "Music_hSlider_ReverbMix";
            Music_hSlider_ReverbMix.Position = 0U;
            Music_hSlider_ReverbMix.PositionFloat = 0.0f;
            Music_hSlider_ReverbMix.Size = new Size(161, 24);
            Music_hSlider_ReverbMix.TabIndex = 35;
            Music_hSlider_ReverbMix.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Music_hSlider_ReverbMix_PositionChangeNotify);
            Music_label_Reverb_Mix.AutoSize = true;
            Music_label_Reverb_Mix.Location = new Point(34, 341);
            Music_label_Reverb_Mix.Name = "Music_label_Reverb_Mix";
            Music_label_Reverb_Mix.Size = new Size(71, 12);
            Music_label_Reverb_Mix.TabIndex = 34;
            Music_label_Reverb_Mix.Text = "$REVERB_MIX";
            Music_hSlider_ReverbEarlyMix.BackColor = SystemColors.Control;
            Music_hSlider_ReverbEarlyMix.Location = new Point(24, 314);
            Music_hSlider_ReverbEarlyMix.MoveDelta = 1U;
            Music_hSlider_ReverbEarlyMix.Name = "Music_hSlider_ReverbEarlyMix";
            Music_hSlider_ReverbEarlyMix.Position = 0U;
            Music_hSlider_ReverbEarlyMix.PositionFloat = 0.0f;
            Music_hSlider_ReverbEarlyMix.Size = new Size(161, 24);
            Music_hSlider_ReverbEarlyMix.TabIndex = 33;
            Music_hSlider_ReverbEarlyMix.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Music_hSlider_ReverbEarlyMix_PositionChangeNotify);
            Music_label_Reverb_EarlyMix.AutoSize = true;
            Music_label_Reverb_EarlyMix.Location = new Point(34, 299);
            Music_label_Reverb_EarlyMix.Name = "Music_label_Reverb_EarlyMix";
            Music_label_Reverb_EarlyMix.Size = new Size(101, 12);
            Music_label_Reverb_EarlyMix.TabIndex = 32;
            Music_label_Reverb_EarlyMix.Text = "$REVERB_EARLYMIX";
            Music_hSlider_ReverbPreDelay.BackColor = SystemColors.Control;
            Music_hSlider_ReverbPreDelay.Location = new Point(24, 272);
            Music_hSlider_ReverbPreDelay.MoveDelta = 1U;
            Music_hSlider_ReverbPreDelay.Name = "Music_hSlider_ReverbPreDelay";
            Music_hSlider_ReverbPreDelay.Position = 0U;
            Music_hSlider_ReverbPreDelay.PositionFloat = 0.0f;
            Music_hSlider_ReverbPreDelay.Size = new Size(161, 24);
            Music_hSlider_ReverbPreDelay.TabIndex = 31;
            Music_hSlider_ReverbPreDelay.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Music_hSlider_ReverbPreDelay_PositionChangeNotify);
            Music_label_Reverb_PreDelay.AutoSize = true;
            Music_label_Reverb_PreDelay.Location = new Point(34, 257);
            Music_label_Reverb_PreDelay.Name = "Music_label_Reverb_PreDelay";
            Music_label_Reverb_PreDelay.Size = new Size(101, 12);
            Music_label_Reverb_PreDelay.TabIndex = 30;
            Music_label_Reverb_PreDelay.Text = "$REVERB_PREDELAY";
            Music_hSlider_ReverbDecay.BackColor = SystemColors.Control;
            Music_hSlider_ReverbDecay.Location = new Point(24, 230);
            Music_hSlider_ReverbDecay.MoveDelta = 1U;
            Music_hSlider_ReverbDecay.Name = "Music_hSlider_ReverbDecay";
            Music_hSlider_ReverbDecay.Position = 0U;
            Music_hSlider_ReverbDecay.PositionFloat = 0.0f;
            Music_hSlider_ReverbDecay.Size = new Size(161, 24);
            Music_hSlider_ReverbDecay.TabIndex = 29;
            Music_hSlider_ReverbDecay.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Music_hSlider_ReverbDecay_PositionChangeNotify);
            Music_label_Reverb_Decay.AutoSize = true;
            Music_label_Reverb_Decay.Location = new Point(34, 215);
            Music_label_Reverb_Decay.Name = "Music_label_Reverb_Decay";
            Music_label_Reverb_Decay.Size = new Size(83, 12);
            Music_label_Reverb_Decay.TabIndex = 28;
            Music_label_Reverb_Decay.Text = "$REVERB_DECAY";
            Music_hSlider_ReverbBandWidth.BackColor = SystemColors.Control;
            Music_hSlider_ReverbBandWidth.Location = new Point(24, 188);
            Music_hSlider_ReverbBandWidth.MoveDelta = 1U;
            Music_hSlider_ReverbBandWidth.Name = "Music_hSlider_ReverbBandWidth";
            Music_hSlider_ReverbBandWidth.Position = 0U;
            Music_hSlider_ReverbBandWidth.PositionFloat = 0.0f;
            Music_hSlider_ReverbBandWidth.Size = new Size(161, 24);
            Music_hSlider_ReverbBandWidth.TabIndex = 27;
            Music_hSlider_ReverbBandWidth.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Music_hSlider_ReverbBandWidth_PositionChangeNotify);
            Music_label_Reverb_BandWidth.AutoSize = true;
            Music_label_Reverb_BandWidth.Location = new Point(34, 173);
            Music_label_Reverb_BandWidth.Name = "Music_label_Reverb_BandWidth";
            Music_label_Reverb_BandWidth.Size = new Size(107, 12);
            Music_label_Reverb_BandWidth.TabIndex = 26;
            Music_label_Reverb_BandWidth.Text = "$REVERB_BANDWIDTH";
            Music_hSlider_ReverbDensity.BackColor = SystemColors.Control;
            Music_hSlider_ReverbDensity.Location = new Point(24, 146);
            Music_hSlider_ReverbDensity.MoveDelta = 1U;
            Music_hSlider_ReverbDensity.Name = "Music_hSlider_ReverbDensity";
            Music_hSlider_ReverbDensity.Position = 0U;
            Music_hSlider_ReverbDensity.PositionFloat = 0.0f;
            Music_hSlider_ReverbDensity.Size = new Size(161, 24);
            Music_hSlider_ReverbDensity.TabIndex = 25;
            Music_hSlider_ReverbDensity.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Music_hSlider_ReverbDensity_PositionChangeNotify);
            Music_label_Reverb_Density.AutoSize = true;
            Music_label_Reverb_Density.Location = new Point(34, 131);
            Music_label_Reverb_Density.Name = "Music_label_Reverb_Density";
            Music_label_Reverb_Density.Size = new Size(95, 12);
            Music_label_Reverb_Density.TabIndex = 24;
            Music_label_Reverb_Density.Text = "$REVERB_DENSITY";
            Music_hSlider_ReverbDamping.BackColor = SystemColors.Control;
            Music_hSlider_ReverbDamping.Location = new Point(24, 104);
            Music_hSlider_ReverbDamping.MoveDelta = 1U;
            Music_hSlider_ReverbDamping.Name = "Music_hSlider_ReverbDamping";
            Music_hSlider_ReverbDamping.Position = 0U;
            Music_hSlider_ReverbDamping.PositionFloat = 0.0f;
            Music_hSlider_ReverbDamping.Size = new Size(161, 24);
            Music_hSlider_ReverbDamping.TabIndex = 23;
            Music_hSlider_ReverbDamping.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Music_hSlider_ReverbDamping_PositionChangeNotify);
            Music_label_Reverb_Damping.AutoSize = true;
            Music_label_Reverb_Damping.Location = new Point(34, 89);
            Music_label_Reverb_Damping.Name = "Music_label_Reverb_Damping";
            Music_label_Reverb_Damping.Size = new Size(95, 12);
            Music_label_Reverb_Damping.TabIndex = 22;
            Music_label_Reverb_Damping.Text = "$REVERB_DAMPING";
            Music_hSlider_ReverbSize.BackColor = SystemColors.Control;
            Music_hSlider_ReverbSize.Location = new Point(24, 64);
            Music_hSlider_ReverbSize.MoveDelta = 1U;
            Music_hSlider_ReverbSize.Name = "Music_hSlider_ReverbSize";
            Music_hSlider_ReverbSize.Position = 0U;
            Music_hSlider_ReverbSize.PositionFloat = 0.0f;
            Music_hSlider_ReverbSize.Size = new Size(161, 24);
            Music_hSlider_ReverbSize.TabIndex = 21;
            Music_hSlider_ReverbSize.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Music_hSlider_ReverbSize_PositionChangeNotify);
            Music_label_Reverb_Size.AutoSize = true;
            Music_label_Reverb_Size.Location = new Point(34, 49);
            Music_label_Reverb_Size.Name = "Music_label_Reverb_Size";
            Music_label_Reverb_Size.Size = new Size(77, 12);
            Music_label_Reverb_Size.TabIndex = 20;
            Music_label_Reverb_Size.Text = "$REVERB_SIZE";
            Music_onOffSwitch_Reverb.BackColor = Color.Transparent;
            Music_onOffSwitch_Reverb.Location = new Point(13, 23);
            Music_onOffSwitch_Reverb.Name = "Music_onOffSwitch_Reverb";
            Music_onOffSwitch_Reverb.Size = new Size(49, 20);
            Music_onOffSwitch_Reverb.SwitchedOn = false;
            Music_onOffSwitch_Reverb.TabIndex = 7;
            Music_onOffSwitch_Reverb.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Music_onOffSwitch_Reverb_SwitchChangeNotify);
            Music_groupBox_Cure.Controls.Add(Music_ButtonBox_CureLevel);
            Music_groupBox_Cure.Controls.Add(Music_onOffSwitch_Cure);
            Music_groupBox_Cure.Controls.Add(Music_label_Tube);
            Music_groupBox_Cure.Controls.Add(Music_onOffSwitch_Tube);
            Music_groupBox_Cure.Location = new Point(411, 206);
            Music_groupBox_Cure.Name = "Music_groupBox_Cure";
            Music_groupBox_Cure.Size = new Size(189, 148);
            Music_groupBox_Cure.TabIndex = 18;
            Music_groupBox_Cure.TabStop = false;
            Music_groupBox_Cure.Text = "$CURE";
            Music_ButtonBox_CureLevel.BackColor = SystemColors.Control;
            Music_ButtonBox_CureLevel.Location = new Point(68, 17);
            Music_ButtonBox_CureLevel.Name = "Music_ButtonBox_CureLevel";
            Music_ButtonBox_CureLevel.Size = new Size(106, 70);
            Music_ButtonBox_CureLevel.TabIndex = 18;
            Music_ButtonBox_CureLevel.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(Music_ButtonBox_CureLevel_ItemSelectedNotify);
            Music_onOffSwitch_Cure.BackColor = Color.Transparent;
            Music_onOffSwitch_Cure.Location = new Point(13, 23);
            Music_onOffSwitch_Cure.Name = "Music_onOffSwitch_Cure";
            Music_onOffSwitch_Cure.Size = new Size(49, 20);
            Music_onOffSwitch_Cure.SwitchedOn = false;
            Music_onOffSwitch_Cure.TabIndex = 17;
            Music_onOffSwitch_Cure.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Music_onOffSwitch_Cure_SwitchChangeNotify);
            Music_label_Tube.AutoSize = true;
            Music_label_Tube.Location = new Point(11, 112);
            Music_label_Tube.Name = "Music_label_Tube";
            Music_label_Tube.Size = new Size(35, 12);
            Music_label_Tube.TabIndex = 14;
            Music_label_Tube.Text = "$TUBE";
            Music_onOffSwitch_Tube.BackColor = Color.Transparent;
            Music_onOffSwitch_Tube.Location = new Point(121, 105);
            Music_onOffSwitch_Tube.Name = "Music_onOffSwitch_Tube";
            Music_onOffSwitch_Tube.Size = new Size(53, 26);
            Music_onOffSwitch_Tube.SwitchedOn = false;
            Music_onOffSwitch_Tube.TabIndex = 15;
            Music_onOffSwitch_Tube.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Music_onOffSwitch_Tube_SwitchChangeNotify);
            Music_groupBox_Clarity.Controls.Add(Music_ButtonBox_ClarityMode);
            Music_groupBox_Clarity.Controls.Add(Music_hSlider_Clarity);
            Music_groupBox_Clarity.Controls.Add(Music_label_Clarity);
            Music_groupBox_Clarity.Controls.Add(Music_onOffSwitch_Clarity);
            Music_groupBox_Clarity.Location = new Point(216, 206);
            Music_groupBox_Clarity.Name = "Music_groupBox_Clarity";
            Music_groupBox_Clarity.Size = new Size(189, 148);
            Music_groupBox_Clarity.TabIndex = 17;
            Music_groupBox_Clarity.TabStop = false;
            Music_groupBox_Clarity.Text = "$CLARITY";
            Music_ButtonBox_ClarityMode.BackColor = SystemColors.Control;
            Music_ButtonBox_ClarityMode.Location = new Point(68, 17);
            Music_ButtonBox_ClarityMode.Name = "Music_ButtonBox_ClarityMode";
            Music_ButtonBox_ClarityMode.Size = new Size(106, 70);
            Music_ButtonBox_ClarityMode.TabIndex = 18;
            Music_ButtonBox_ClarityMode.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(Music_ButtonBox_ClarityMode_ItemSelectedNotify);
            Music_hSlider_Clarity.BackColor = SystemColors.Control;
            Music_hSlider_Clarity.Location = new Point(13, 115);
            Music_hSlider_Clarity.MoveDelta = 1U;
            Music_hSlider_Clarity.Name = "Music_hSlider_Clarity";
            Music_hSlider_Clarity.Position = 0U;
            Music_hSlider_Clarity.PositionFloat = 0.0f;
            Music_hSlider_Clarity.Size = new Size(161, 24);
            Music_hSlider_Clarity.TabIndex = 21;
            Music_hSlider_Clarity.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Music_hSlider_Clarity_PositionChangeNotify);
            Music_label_Clarity.AutoSize = true;
            Music_label_Clarity.Location = new Point(23, 100);
            Music_label_Clarity.Name = "Music_label_Clarity";
            Music_label_Clarity.Size = new Size(89, 12);
            Music_label_Clarity.TabIndex = 20;
            Music_label_Clarity.Text = "$CLARITY : 0dB";
            Music_onOffSwitch_Clarity.BackColor = Color.Transparent;
            Music_onOffSwitch_Clarity.Location = new Point(13, 23);
            Music_onOffSwitch_Clarity.Name = "Music_onOffSwitch_Clarity";
            Music_onOffSwitch_Clarity.Size = new Size(49, 20);
            Music_onOffSwitch_Clarity.SwitchedOn = false;
            Music_onOffSwitch_Clarity.TabIndex = 17;
            Music_onOffSwitch_Clarity.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Music_onOffSwitch_Clarity_SwitchChangeNotify);
            Music_groupBox_Bass.Controls.Add(Music_hSlider_BassGain);
            Music_groupBox_Bass.Controls.Add(Music_label_Bass_Gain);
            Music_groupBox_Bass.Controls.Add(Music_hSlider_BassSpkSize);
            Music_groupBox_Bass.Controls.Add(Music_label_Bass_SpkSize);
            Music_groupBox_Bass.Controls.Add(Music_onOffSwitch_Bass);
            Music_groupBox_Bass.Location = new Point(21, 206);
            Music_groupBox_Bass.Name = "Music_groupBox_Bass";
            Music_groupBox_Bass.Size = new Size(189, 148);
            Music_groupBox_Bass.TabIndex = 16;
            Music_groupBox_Bass.TabStop = false;
            Music_groupBox_Bass.Text = "$BASS";
            Music_hSlider_BassGain.BackColor = SystemColors.Control;
            Music_hSlider_BassGain.Location = new Point(13, 115);
            Music_hSlider_BassGain.MoveDelta = 1U;
            Music_hSlider_BassGain.Name = "Music_hSlider_BassGain";
            Music_hSlider_BassGain.Position = 0U;
            Music_hSlider_BassGain.PositionFloat = 0.0f;
            Music_hSlider_BassGain.Size = new Size(161, 24);
            Music_hSlider_BassGain.TabIndex = 21;
            Music_hSlider_BassGain.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Music_hSlider_BassGain_PositionChangeNotify);
            Music_label_Bass_Gain.AutoSize = true;
            Music_label_Bass_Gain.Location = new Point(23, 100);
            Music_label_Bass_Gain.Name = "Music_label_Bass_Gain";
            Music_label_Bass_Gain.Size = new Size(101, 12);
            Music_label_Bass_Gain.TabIndex = 20;
            Music_label_Bass_Gain.Text = "$BASS_GAIN : 0dB";
            Music_hSlider_BassSpkSize.BackColor = SystemColors.Control;
            Music_hSlider_BassSpkSize.Location = new Point(13, 73);
            Music_hSlider_BassSpkSize.MoveDelta = 1U;
            Music_hSlider_BassSpkSize.Name = "Music_hSlider_BassSpkSize";
            Music_hSlider_BassSpkSize.Position = 0U;
            Music_hSlider_BassSpkSize.PositionFloat = 0.0f;
            Music_hSlider_BassSpkSize.Size = new Size(161, 24);
            Music_hSlider_BassSpkSize.TabIndex = 19;
            Music_hSlider_BassSpkSize.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Music_hSlider_BassSpkSize_PositionChangeNotify);
            Music_label_Bass_SpkSize.AutoSize = true;
            Music_label_Bass_SpkSize.Location = new Point(23, 58);
            Music_label_Bass_SpkSize.Name = "Music_label_Bass_SpkSize";
            Music_label_Bass_SpkSize.Size = new Size(83, 12);
            Music_label_Bass_SpkSize.TabIndex = 18;
            Music_label_Bass_SpkSize.Text = "$BASS_SPKSIZE";
            Music_onOffSwitch_Bass.BackColor = Color.Transparent;
            Music_onOffSwitch_Bass.Location = new Point(13, 23);
            Music_onOffSwitch_Bass.Name = "Music_onOffSwitch_Bass";
            Music_onOffSwitch_Bass.Size = new Size(49, 20);
            Music_onOffSwitch_Bass.SwitchedOn = false;
            Music_onOffSwitch_Bass.TabIndex = 17;
            Music_onOffSwitch_Bass.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Music_onOffSwitch_Bass_SwitchChangeNotify);
            Music_groupBox_Surround.Controls.Add(Music_ButtonBox_SurroundRoomSize);
            Music_groupBox_Surround.Controls.Add(Music_onOffSwitch_Surround);
            Music_groupBox_Surround.Location = new Point(606, 6);
            Music_groupBox_Surround.Name = "Music_groupBox_Surround";
            Music_groupBox_Surround.Size = new Size(208, 138);
            Music_groupBox_Surround.TabIndex = 13;
            Music_groupBox_Surround.TabStop = false;
            Music_groupBox_Surround.Text = "$SURROUND";
            Music_ButtonBox_SurroundRoomSize.BackColor = SystemColors.Control;
            Music_ButtonBox_SurroundRoomSize.Location = new Point(68, 23);
            Music_ButtonBox_SurroundRoomSize.Name = "Music_ButtonBox_SurroundRoomSize";
            Music_ButtonBox_SurroundRoomSize.Size = new Size(sbyte.MaxValue, 101);
            Music_ButtonBox_SurroundRoomSize.TabIndex = 7;
            Music_ButtonBox_SurroundRoomSize.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(Music_ButtonBox_SurroundRoomSize_ItemSelectedNotify);
            Music_onOffSwitch_Surround.BackColor = Color.Transparent;
            Music_onOffSwitch_Surround.Location = new Point(13, 23);
            Music_onOffSwitch_Surround.Name = "Music_onOffSwitch_Surround";
            Music_onOffSwitch_Surround.Size = new Size(49, 20);
            Music_onOffSwitch_Surround.SwitchedOn = false;
            Music_onOffSwitch_Surround.TabIndex = 6;
            Music_onOffSwitch_Surround.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Music_onOffSwitch_Surround_SwitchChangeNotify);
            Music_groupBox_Convolver.Controls.Add(Music_irShape_ConvIR);
            Music_groupBox_Convolver.Controls.Add(Music_onOffSwitch_Convolver);
            Music_groupBox_Convolver.Controls.Add(Music_hSlider_ConvIRGain);
            Music_groupBox_Convolver.Controls.Add(Music_openFileBox_ConvIRS);
            Music_groupBox_Convolver.Controls.Add(Music_label_ConvolverIRGain);
            Music_groupBox_Convolver.Location = new Point(312, 6);
            Music_groupBox_Convolver.Name = "Music_groupBox_Convolver";
            Music_groupBox_Convolver.Size = new Size(288, 179);
            Music_groupBox_Convolver.TabIndex = 12;
            Music_groupBox_Convolver.TabStop = false;
            Music_groupBox_Convolver.Text = "$CONVOLVER";
            Music_irShape_ConvIR.Location = new Point(13, 61);
            Music_irShape_ConvIR.Name = "Music_irShape_ConvIR";
            Music_irShape_ConvIR.ShapeBackColor = Color.White;
            Music_irShape_ConvIR.ShapeForeColor = Color.Black;
            Music_irShape_ConvIR.Size = new Size(260, 63);
            Music_irShape_ConvIR.TabIndex = 8;
            Music_onOffSwitch_Convolver.BackColor = Color.Transparent;
            Music_onOffSwitch_Convolver.Location = new Point(13, 23);
            Music_onOffSwitch_Convolver.Name = "Music_onOffSwitch_Convolver";
            Music_onOffSwitch_Convolver.Size = new Size(49, 20);
            Music_onOffSwitch_Convolver.SwitchedOn = false;
            Music_onOffSwitch_Convolver.TabIndex = 5;
            Music_onOffSwitch_Convolver.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(Music_onOffSwitch_Convolver_SwitchChangeNotify);
            Music_hSlider_ConvIRGain.BackColor = SystemColors.Control;
            Music_hSlider_ConvIRGain.Location = new Point(85, 31);
            Music_hSlider_ConvIRGain.MoveDelta = 1U;
            Music_hSlider_ConvIRGain.Name = "Music_hSlider_ConvIRGain";
            Music_hSlider_ConvIRGain.Position = 0U;
            Music_hSlider_ConvIRGain.PositionFloat = 0.0f;
            Music_hSlider_ConvIRGain.Size = new Size(188, 24);
            Music_hSlider_ConvIRGain.TabIndex = 7;
            Music_hSlider_ConvIRGain.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Music_hSlider_ConvIRGain_PositionChangeNotify);
            Music_openFileBox_ConvIRS.BackColor = SystemColors.Control;
            Music_openFileBox_ConvIRS.FilePathName = "";
            Music_openFileBox_ConvIRS.Location = new Point(13, 136);
            Music_openFileBox_ConvIRS.Name = "Music_openFileBox_ConvIRS";
            Music_openFileBox_ConvIRS.Size = new Size(260, 29);
            Music_openFileBox_ConvIRS.TabIndex = 9;
            Music_openFileBox_ConvIRS.FileChangeNotify += new OpenFileBox.FileChangeEventDelegate(Music_openFileBox_ConvIRS_FileChangeNotify);
            Music_label_ConvolverIRGain.AutoSize = true;
            Music_label_ConvolverIRGain.Location = new Point(95, 16);
            Music_label_ConvolverIRGain.Name = "Music_label_ConvolverIRGain";
            Music_label_ConvolverIRGain.Size = new Size(119, 12);
            Music_label_ConvolverIRGain.TabIndex = 6;
            Music_label_ConvolverIRGain.Text = "$CONV_IR_GAIN : 0dB";
            Music_hSlider_PostVolume.BackColor = SystemColors.Control;
            Music_hSlider_PostVolume.Location = new Point(21, 118);
            Music_hSlider_PostVolume.MoveDelta = 1U;
            Music_hSlider_PostVolume.Name = "Music_hSlider_PostVolume";
            Music_hSlider_PostVolume.Position = 0U;
            Music_hSlider_PostVolume.PositionFloat = 0.0f;
            Music_hSlider_PostVolume.Size = new Size(285, 39);
            Music_hSlider_PostVolume.TabIndex = 3;
            Music_hSlider_PostVolume.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Music_hSlider_PostVolume_PositionChangeNotify);
            Music_label_PostVolume.AutoSize = true;
            Music_label_PostVolume.Location = new Point(40, 100);
            Music_label_PostVolume.Name = "Music_label_PostVolume";
            Music_label_PostVolume.Size = new Size(113, 12);
            Music_label_PostVolume.TabIndex = 2;
            Music_label_PostVolume.Text = "$POST_VOLUME : 0dB";
            Music_hSlider_PreVolume.BackColor = SystemColors.Control;
            Music_hSlider_PreVolume.Location = new Point(21, 39);
            Music_hSlider_PreVolume.MoveDelta = 1U;
            Music_hSlider_PreVolume.Name = "Music_hSlider_PreVolume";
            Music_hSlider_PreVolume.Position = 0U;
            Music_hSlider_PreVolume.PositionFloat = 0.0f;
            Music_hSlider_PreVolume.Size = new Size(285, 39);
            Music_hSlider_PreVolume.TabIndex = 1;
            Music_hSlider_PreVolume.PositionChangeNotify += new HSlider.PositionChangeEventDelegate(Music_hSlider_PreVolume_PositionChangeNotify);
            Music_label_PreVolume.AutoSize = true;
            Music_label_PreVolume.Location = new Point(40, 21);
            Music_label_PreVolume.Name = "Music_label_PreVolume";
            Music_label_PreVolume.Size = new Size(107, 12);
            Music_label_PreVolume.TabIndex = 0;
            Music_label_PreVolume.Text = "$PRE_VOLUME : 0dB";
            label_Copyright.Location = new Point(472, 604);
            label_Copyright.Name = "label_Copyright";
            label_Copyright.Size = new Size(555, 23);
            label_Copyright.TabIndex = 6;
            label_Copyright.Text = "$COPYRIGHT";
            label_Copyright.TextAlign = ContentAlignment.MiddleRight;
            notifyIcon_Main.ContextMenuStrip = contextMenuStrip_TrayMenu;
            notifyIcon_Main.Icon = (Icon)componentResourceManager.GetObject("notifyIcon_Main.Icon");
            notifyIcon_Main.Text = "ViPER4Windows";
            notifyIcon_Main.MouseUp += new MouseEventHandler(NotifyIcon_Main_MouseUp);
            contextMenuStrip_TrayMenu.Name = "contextMenuStrip_TrayMenu";
            contextMenuStrip_TrayMenu.Size = new Size(61, 4);
            SingleButton_SavePreset.BackColor = SystemColors.Control;
            SingleButton_SavePreset.ButtonText = "$SAVE_PRESET";
            SingleButton_SavePreset.Location = new Point(37, 560);
            SingleButton_SavePreset.Name = "SingleButton_SavePreset";
            SingleButton_SavePreset.Size = new Size(112, 40);
            SingleButton_SavePreset.TabIndex = 8;
            SingleButton_SavePreset.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_SavePreset_ButtonClickNotify);
            SingleButton_LoadPreset.BackColor = SystemColors.Control;
            SingleButton_LoadPreset.ButtonText = "$LOAD_PRESET";
            SingleButton_LoadPreset.Location = new Point(37, 514);
            SingleButton_LoadPreset.Name = "SingleButton_LoadPreset";
            SingleButton_LoadPreset.Size = new Size(112, 40);
            SingleButton_LoadPreset.TabIndex = 7;
            SingleButton_LoadPreset.ButtonClickNotify += new SingleButton.ButtonClickEventDelegate(SingleButton_LoadPreset_ButtonClickNotify);
            ButtonBox_Mode.BackColor = SystemColors.Control;
            ButtonBox_Mode.Location = new Point(16, 312);
            ButtonBox_Mode.Name = "ButtonBox_Mode";
            ButtonBox_Mode.Size = new Size(152, 170);
            ButtonBox_Mode.TabIndex = 3;
            ButtonBox_Mode.ItemSelectedNotify += new ButtonBox.ItemSelectDelegate(ButtonBox_Mode_ItemSelectedNotify);
            onOffSwitch_Master.BackColor = Color.Transparent;
            onOffSwitch_Master.Location = new Point(50, 266);
            onOffSwitch_Master.Name = "onOffSwitch_Master";
            onOffSwitch_Master.Size = new Size(81, 28);
            onOffSwitch_Master.SwitchedOn = false;
            onOffSwitch_Master.TabIndex = 2;
            onOffSwitch_Master.SwitchChangeNotify += new OnOffSwitch.SwitchChangeEventDelegate(OnOffSwitch_Master_SwitchChangeNotify);
            AutoScaleDimensions = new SizeF(6f, 12f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1042, 633);
            Controls.Add(SingleButton_SavePreset);
            Controls.Add(SingleButton_LoadPreset);
            Controls.Add(label_Copyright);
            Controls.Add(groupBox_Main);
            Controls.Add(ButtonBox_Mode);
            Controls.Add(onOffSwitch_Master);
            Controls.Add(label_MasterPower);
            Controls.Add(pictureBox_Logo);
            Controls.Add(menuStrip_Main);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
            MainMenuStrip = menuStrip_Main;
            MaximizeBox = false;
            Name = nameof(FrmMain);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ViPER4Windows";
            FormClosing += new FormClosingEventHandler(FrmMain_FormClosing);
            Load += new EventHandler(FrmMain_Load);
            SizeChanged += new EventHandler(FrmMain_SizeChanged);
            ((ISupportInitialize)pictureBox_Logo).EndInit();
            menuStrip_Main.ResumeLayout(false);
            menuStrip_Main.PerformLayout();
            groupBox_Main.ResumeLayout(false);
            panel_Freestyle.ResumeLayout(false);
            panel_Freestyle.PerformLayout();
            Freestyle_groupBox_SmartVolume.ResumeLayout(false);
            Freestyle_groupBox_SmartVolume.PerformLayout();
            Freestyle_groupBox_3DSurround.ResumeLayout(false);
            Freestyle_groupBox_3DSurround.PerformLayout();
            Freestyle_groupBox_Reverb.ResumeLayout(false);
            Freestyle_groupBox_Reverb.PerformLayout();
            Freestyle_groupBox_Cure.ResumeLayout(false);
            Freestyle_groupBox_Cure.PerformLayout();
            Freestyle_groupBox_Clarity.ResumeLayout(false);
            Freestyle_groupBox_Clarity.PerformLayout();
            Freestyle_groupBox_Bass.ResumeLayout(false);
            Freestyle_groupBox_Bass.PerformLayout();
            Freestyle_groupBox_VHESurround.ResumeLayout(false);
            Freestyle_groupBox_Convolver.ResumeLayout(false);
            Freestyle_groupBox_Convolver.PerformLayout();
            panel_MusicMode.ResumeLayout(false);
            panel_MusicMode.PerformLayout();
            panel_MovieMode.ResumeLayout(false);
            panel_MovieMode.PerformLayout();
            Movie_groupBox_SmartVolume.ResumeLayout(false);
            Movie_groupBox_SmartVolume.PerformLayout();
            Movie_groupBox_Reverb.ResumeLayout(false);
            Movie_groupBox_Reverb.PerformLayout();
            Movie_groupBox_Clarity.ResumeLayout(false);
            Movie_groupBox_Clarity.PerformLayout();
            Movie_groupBox_Bass.ResumeLayout(false);
            Movie_groupBox_Bass.PerformLayout();
            Movie_groupBox_Surround.ResumeLayout(false);
            Movie_groupBox_Surround.PerformLayout();
            Movie_groupBox_Convolver.ResumeLayout(false);
            Movie_groupBox_Convolver.PerformLayout();
            Music_groupBox_Reverb.ResumeLayout(false);
            Music_groupBox_Reverb.PerformLayout();
            Music_groupBox_Cure.ResumeLayout(false);
            Music_groupBox_Cure.PerformLayout();
            Music_groupBox_Clarity.ResumeLayout(false);
            Music_groupBox_Clarity.PerformLayout();
            Music_groupBox_Bass.ResumeLayout(false);
            Music_groupBox_Bass.PerformLayout();
            Music_groupBox_Surround.ResumeLayout(false);
            Music_groupBox_Convolver.ResumeLayout(false);
            Music_groupBox_Convolver.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
