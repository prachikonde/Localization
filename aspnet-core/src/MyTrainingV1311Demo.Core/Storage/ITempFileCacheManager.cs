﻿using Abp.Dependency;

namespace MyTrainingV1311Demo.Storage
{
    public interface ITempFileCacheManager : ITransientDependency
    {
        void SetFile(string token, byte[] content);

        byte[] GetFile(string token);

        void SetFile(string token, TempFileInfo info);

        TempFileInfo GetFileInfo(string token);
    }
}