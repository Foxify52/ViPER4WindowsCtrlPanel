using System.Collections.Generic;
using System.IO;

namespace ViPER4WindowsBin.Utils
{
  internal class FolderExplorer
  {
    private void InternalListFiles(string szFolder, List<string> lsResult)
    {
      try
      {
        lsResult.AddRange((IEnumerable<string>) Directory.GetFiles(szFolder));
        foreach (string directory in Directory.GetDirectories(szFolder))
          this.InternalListFiles(directory, lsResult);
      }
      catch
      {
      }
    }

    public string[] ListFiles(string szFolder)
    {
      if (szFolder == null)
        return new string[0];
      if (!Directory.Exists(szFolder))
        return new string[0];
      List<string> lsResult = new List<string>();
      this.InternalListFiles(szFolder, lsResult);
      return lsResult.ToArray();
    }
  }
}
