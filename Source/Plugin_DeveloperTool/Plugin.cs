﻿using System.ComponentModel.Composition;
using PluginFramework;

namespace Plugin_DeveloperTool
{
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [Export(typeof(IPlugin))]
    public class Plugin : IFormPlugin
    {
        private object _userControl;
        private PluginInfo _pluginInfo;
        private IPluginSetting _pluginSetting;
		[Import(typeof(IHost))]
        private IHost _host;

        public Plugin()
        {
            _pluginInfo = new PluginInfo();
            _pluginSetting = new PluginSetting();
        }

        public IPluginInfo PluginInfo
        {
            get { return _pluginInfo; }
        }

        public IPluginSetting PluginSetting
        {
            get { return _pluginSetting; }
        }

        public object Load(PluginParameter data)
        {
            return _userControl = new DeveloperTool(_host, data);
        }

        public void Dispose()
        {
	        _userControl = null;
        }
    }
}
