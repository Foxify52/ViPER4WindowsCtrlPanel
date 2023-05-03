using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ViPER4WindowsBin.Properties
{
  [DebuggerNonUserCode]
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) ViPER4WindowsBin.Properties.Resources.resourceMan, (object) null))
          ViPER4WindowsBin.Properties.Resources.resourceMan = new ResourceManager("ViPER4WindowsBin.Properties.Resources", typeof (ViPER4WindowsBin.Properties.Resources).Assembly);
        return ViPER4WindowsBin.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => ViPER4WindowsBin.Properties.Resources.resourceCulture;
      set => ViPER4WindowsBin.Properties.Resources.resourceCulture = value;
    }

    internal static Icon Icons => (Icon) ViPER4WindowsBin.Properties.Resources.ResourceManager.GetObject(nameof (Icons), ViPER4WindowsBin.Properties.Resources.resourceCulture);

    internal static Bitmap Logo => (Bitmap) ViPER4WindowsBin.Properties.Resources.ResourceManager.GetObject(nameof (Logo), ViPER4WindowsBin.Properties.Resources.resourceCulture);
  }
}
