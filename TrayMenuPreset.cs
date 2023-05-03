using System.IO;
using System.Text;

namespace ViPER4WindowsBin
{
  public class TrayMenuPreset
  {
    private string m_szPresetName = "";
    private int m_nPresetMode;
    private string m_szPresetFile = "";

    public string PresetName
    {
      get => this.m_szPresetName;
      set => this.m_szPresetName = value;
    }

    public int PresetMode
    {
      get => this.m_nPresetMode;
      set => this.m_nPresetMode = value;
    }

    public string PresetFile
    {
      get => this.m_szPresetFile;
      set => this.m_szPresetFile = value;
    }

    public string PresetFileShort
    {
      get
      {
        if (string.IsNullOrEmpty(this.m_szPresetFile))
          return "";
        int num = this.m_szPresetFile.LastIndexOf("\\");
        return num <= 0 ? "" : this.m_szPresetFile.Substring(num + 1, this.m_szPresetFile.Length - num - 1);
      }
    }

    public TrayMenuPreset(string szName, int nMode, string szFile)
    {
      this.m_szPresetName = szName;
      this.m_nPresetMode = nMode;
      this.m_szPresetFile = szFile;
    }

    public bool Valid() => this.m_nPresetMode == 0 || this.m_nPresetMode == 1 || this.m_nPresetMode == 2;

    public bool PresetLoadable() => !string.IsNullOrEmpty(this.m_szPresetFile) && File.Exists(this.m_szPresetFile);

    public TrayMenuPreset Clone() => new TrayMenuPreset(this.m_szPresetName, this.m_nPresetMode, this.m_szPresetFile);

    public override bool Equals(object obj)
    {
      if (obj == null || obj.GetType() != typeof (TrayMenuPreset))
        return false;
      TrayMenuPreset trayMenuPreset = obj as TrayMenuPreset;
      return trayMenuPreset.PresetName == this.m_szPresetName && trayMenuPreset.PresetMode == this.m_nPresetMode && trayMenuPreset.PresetFile == this.m_szPresetFile;
    }

    public override int GetHashCode()
    {
      if (!this.Valid())
        return 0;
      int num = 0;
      byte[] bytes1 = Encoding.Default.GetBytes(this.m_szPresetFile);
      byte[] bytes2 = Encoding.Default.GetBytes(this.m_szPresetName);
      if (bytes1 != null)
      {
        for (int index = 0; index < bytes1.Length; ++index)
          num += (int) bytes1[index];
        num <<= this.m_nPresetMode;
      }
      if (bytes2 != null)
      {
        for (int index = 0; index < bytes2.Length; ++index)
          num += (int) bytes2[index];
        num >>= this.m_nPresetMode;
      }
      return (num + this.m_nPresetMode) * (this.m_nPresetMode + 1);
    }

    public override string ToString() => this.m_szPresetName;
  }
}
