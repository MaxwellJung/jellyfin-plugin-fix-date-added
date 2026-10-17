using System;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;

namespace Jellyfin.Plugin.FixDateAdded;

public class Plugin : BasePlugin<BasePluginConfiguration> {
  public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer)
    : base(applicationPaths, xmlSerializer) {
  }

  public override string Name => "Fix Date Added";

  public override Guid Id => Guid.Parse("f5e69279-adee-4c33-b4a3-424f09e07ce4");
}
