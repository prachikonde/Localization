﻿using Abp.Dependency;
using Castle.Core.Logging;

namespace MyTrainingV1311Demo.Configuration
{
    /* This service is replaced in Web layer */
    public class DefaultAppConfigurationWriter : IAppConfigurationWriter, ISingletonDependency
    {
        public ILogger Logger { get; set; }

        public DefaultAppConfigurationWriter()
        {
            Logger = NullLogger.Instance;
        }

        public void Write(string key, string value)
        {
            Logger.Warn("Write is not implemented!");
        }
    }
}
