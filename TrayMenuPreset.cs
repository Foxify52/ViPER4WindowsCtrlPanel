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
            get => m_szPresetName;
            set => m_szPresetName = value;
        }

        public int PresetMode
        {
            get => m_nPresetMode;
            set => m_nPresetMode = value;
        }

        public string PresetFile
        {
            get => m_szPresetFile;
            set => m_szPresetFile = value;
        }

        public string PresetFileShort
        {
            get
            {
                if (string.IsNullOrEmpty(m_szPresetFile))
                    return "";
                int num = m_szPresetFile.LastIndexOf("\\");
                return num <= 0 ? "" : m_szPresetFile.Substring(num + 1, m_szPresetFile.Length - num - 1);
            }
        }

        public TrayMenuPreset(string szName, int nMode, string szFile)
        {
            m_szPresetName = szName;
            m_nPresetMode = nMode;
            m_szPresetFile = szFile;
        }

        public bool Valid()
        {
            return m_nPresetMode == 0 || m_nPresetMode == 1 || m_nPresetMode == 2;
        }

        public bool PresetLoadable()
        {
            return !string.IsNullOrEmpty(m_szPresetFile) && File.Exists(m_szPresetFile);
        }

        public TrayMenuPreset Clone()
        {
            return new TrayMenuPreset(m_szPresetName, m_nPresetMode, m_szPresetFile);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(TrayMenuPreset))
                return false;
            TrayMenuPreset trayMenuPreset = obj as TrayMenuPreset;
            return trayMenuPreset.PresetName == m_szPresetName && trayMenuPreset.PresetMode == m_nPresetMode && trayMenuPreset.PresetFile == m_szPresetFile;
        }

        public override int GetHashCode()
        {
            if (!Valid())
                return 0;
            int num = 0;
            byte[] bytes1 = Encoding.Default.GetBytes(m_szPresetFile);
            byte[] bytes2 = Encoding.Default.GetBytes(m_szPresetName);
            if (bytes1 != null)
            {
                for (int index = 0; index < bytes1.Length; ++index)
                    num += bytes1[index];
                num <<= m_nPresetMode;
            }
            if (bytes2 != null)
            {
                for (int index = 0; index < bytes2.Length; ++index)
                    num += bytes2[index];
                num >>= m_nPresetMode;
            }
            return (num + m_nPresetMode) * (m_nPresetMode + 1);
        }

        public override string ToString()
        {
            return m_szPresetName;
        }
    }
}
