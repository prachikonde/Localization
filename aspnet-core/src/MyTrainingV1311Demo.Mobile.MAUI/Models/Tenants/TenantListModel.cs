﻿using Abp.AutoMapper;
using MyTrainingV1311Demo.MultiTenancy.Dto;

namespace MyTrainingV1311Demo.Mobile.MAUI.Models.Tenants
{
    [AutoMapFrom(typeof(TenantListDto))]
    [AutoMapTo(typeof(TenantEditDto), typeof(CreateTenantInput))]
    public class TenantListModel : TenantListDto
    {
 
    }
}
