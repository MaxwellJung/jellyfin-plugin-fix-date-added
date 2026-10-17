using System;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;

namespace Jellyfin.Plugin.FixDateAdded;

/// <summary>Fix Date Added plugin entry point.</summary>
public class Plugin : BasePlugin<BasePluginConfiguration>
{
    /// <summary>Initializes a new instance of the <see cref="Plugin"/> class.</summary>
    /// <param name="applicationPaths">App paths.</param>
    /// <param name="xmlSerializer">XML serializer.</param>
    public Plugin(IApplicationPaths applicationPaths, IXmlSerializer xmlSerializer)
        : base(applicationPaths, xmlSerializer)
    {
    }

    /// <inheritdoc />
    public override string Name => "Fix Date Added";

    /// <inheritdoc />
    public override Guid Id => Guid.Parse("f5e69279-adee-4c33-b4a3-424f09e07ce4");
}
