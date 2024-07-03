﻿using System.Collections.Generic;
using System.Linq;

namespace MyTrainingV1311Demo.Exporting;

public static class EntityExportHelper
{
    public static List<string> GetEntityColumnNames<TEntity>()
    {
        var properties = typeof(TEntity).GetProperties();
        
        var columns = properties.Select(p => p.Name).ToList();
            
        return columns;
    }
}