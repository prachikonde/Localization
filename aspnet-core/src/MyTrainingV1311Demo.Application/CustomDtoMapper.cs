using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.DynamicEntityProperties;
using Abp.EntityHistory;
using Abp.Extensions;
using Abp.Localization;
using Abp.Notifications;
using Abp.Organizations;
using Abp.UI.Inputs;
using Abp.Webhooks;
using AutoMapper;
using MyTrainingV1311Demo.Auditing.Dto;
using MyTrainingV1311Demo.Authorization.Accounts.Dto;
using MyTrainingV1311Demo.Authorization.Delegation;
using MyTrainingV1311Demo.Authorization.Permissions.Dto;
using MyTrainingV1311Demo.Authorization.Roles;
using MyTrainingV1311Demo.Authorization.Roles.Dto;
using MyTrainingV1311Demo.Authorization.Users;
using MyTrainingV1311Demo.Authorization.Users.Delegation.Dto;
using MyTrainingV1311Demo.Authorization.Users.Dto;
using MyTrainingV1311Demo.Authorization.Users.Importing.Dto;
using MyTrainingV1311Demo.Authorization.Users.Profile.Dto;
using MyTrainingV1311Demo.Chat;
using MyTrainingV1311Demo.Chat.Dto;
using MyTrainingV1311Demo.Common.Dto;
using MyTrainingV1311Demo.DynamicEntityProperties.Dto;
using MyTrainingV1311Demo.Editions;
using MyTrainingV1311Demo.Editions.Dto;
using MyTrainingV1311Demo.Friendships;
using MyTrainingV1311Demo.Friendships.Cache;
using MyTrainingV1311Demo.Friendships.Dto;
using MyTrainingV1311Demo.Localization.Dto;
using MyTrainingV1311Demo.MultiTenancy;
using MyTrainingV1311Demo.MultiTenancy.Dto;
using MyTrainingV1311Demo.MultiTenancy.HostDashboard.Dto;
using MyTrainingV1311Demo.MultiTenancy.Payments;
using MyTrainingV1311Demo.MultiTenancy.Payments.Dto;
using MyTrainingV1311Demo.Notifications.Dto;
using MyTrainingV1311Demo.Organizations.Dto;
using MyTrainingV1311Demo.Sessions.Dto;
using MyTrainingV1311Demo.WebHooks.Dto;

namespace MyTrainingV1311Demo
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //Inputs
            configuration.CreateMap<CheckboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<SingleLineStringInputType, FeatureInputTypeDto>();
            configuration.CreateMap<ComboboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<IInputType, FeatureInputTypeDto>()
                .Include<CheckboxInputType, FeatureInputTypeDto>()
                .Include<SingleLineStringInputType, FeatureInputTypeDto>()
                .Include<ComboboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<StaticLocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>();
            configuration.CreateMap<ILocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>()
                .Include<StaticLocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>();
            configuration.CreateMap<LocalizableComboboxItem, LocalizableComboboxItemDto>();
            configuration.CreateMap<ILocalizableComboboxItem, LocalizableComboboxItemDto>()
                .Include<LocalizableComboboxItem, LocalizableComboboxItemDto>();

            //Chat
            configuration.CreateMap<ChatMessage, ChatMessageDto>();
            configuration.CreateMap<ChatMessage, ChatMessageExportDto>();

            //Feature
            configuration.CreateMap<FlatFeatureSelectDto, Feature>().ReverseMap();
            configuration.CreateMap<Feature, FlatFeatureDto>();

            //Role
            configuration.CreateMap<RoleEditDto, Role>().ReverseMap();
            configuration.CreateMap<Role, RoleListDto>();
            configuration.CreateMap<UserRole, UserListRoleDto>();

            

            //Edition
            configuration.CreateMap<EditionEditDto, SubscribableEdition>().ReverseMap();
            configuration.CreateMap<EditionCreateDto, SubscribableEdition>();
            configuration.CreateMap<EditionSelectDto, SubscribableEdition>().ReverseMap();
            configuration.CreateMap<SubscribableEdition, EditionInfoDto>();

            configuration.CreateMap<Edition, EditionInfoDto>().Include<SubscribableEdition, EditionInfoDto>();

            configuration.CreateMap<SubscribableEdition, EditionListDto>();
            configuration.CreateMap<Edition, EditionEditDto>();
            configuration.CreateMap<Edition, SubscribableEdition>();
            configuration.CreateMap<Edition, EditionSelectDto>();


            //Payment
            configuration.CreateMap<SubscriptionPaymentDto, SubscriptionPayment>()
                .ReverseMap()
                .ForMember(dto=> dto.TotalAmount, options=> options.MapFrom(e=> e.GetTotalAmount()));
            configuration.CreateMap<SubscriptionPaymentProductDto, SubscriptionPaymentProduct>().ReverseMap();
            configuration.CreateMap<SubscriptionPaymentListDto, SubscriptionPayment>().ReverseMap();
            configuration.CreateMap<SubscriptionPayment, SubscriptionPaymentInfoDto>();

            //Permission
            configuration.CreateMap<Permission, FlatPermissionDto>();
            configuration.CreateMap<Permission, FlatPermissionWithLevelDto>();

            //Language
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageEditDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageListDto>();
            configuration.CreateMap<NotificationDefinition, NotificationSubscriptionWithDisplayNameDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageEditDto>()
                .ForMember(ldto => ldto.IsEnabled, options => options.MapFrom(l => !l.IsDisabled));

            //Tenant
            configuration.CreateMap<Tenant, RecentTenant>();
            configuration.CreateMap<Tenant, TenantLoginInfoDto>();
            configuration.CreateMap<Tenant, TenantListDto>();
            configuration.CreateMap<TenantEditDto, Tenant>().ReverseMap();
            configuration.CreateMap<CurrentTenantInfoDto, Tenant>().ReverseMap();

            //User
            configuration.CreateMap<User, UserEditDto>()
                .ForMember(dto => dto.Password, options => options.Ignore())
                .ReverseMap()
                .ForMember(user => user.Password, options => options.Ignore());
            configuration.CreateMap<User, UserLoginInfoDto>();
            configuration.CreateMap<User, UserListDto>();
            configuration.CreateMap<User, ChatUserDto>();
            configuration.CreateMap<User, OrganizationUnitUserListDto>();
            configuration.CreateMap<Role, OrganizationUnitRoleListDto>();
            configuration.CreateMap<CurrentUserProfileEditDto, User>().ReverseMap();
            configuration.CreateMap<UserLoginAttemptDto, UserLoginAttempt>().ReverseMap();
            configuration.CreateMap<ImportUserDto, User>();
            configuration.CreateMap<User, FindUsersOutputDto>();
            configuration.CreateMap<User, FindOrganizationUnitUsersOutputDto>();

            //AuditLog
            configuration.CreateMap<AuditLog, AuditLogListDto>();
            configuration.CreateMap<EntityChange, EntityChangeListDto>();
            configuration.CreateMap<EntityPropertyChange, EntityPropertyChangeDto>();

            //Friendship
            configuration.CreateMap<Friendship, FriendDto>();
            configuration.CreateMap<FriendCacheItem, FriendDto>();

            //OrganizationUnit
            configuration.CreateMap<OrganizationUnit, OrganizationUnitDto>();

            //Webhooks
            configuration.CreateMap<WebhookSubscription, GetAllSubscriptionsOutput>();
            configuration.CreateMap<WebhookSendAttempt, GetAllSendAttemptsOutput>()
                .ForMember(webhookSendAttemptListDto => webhookSendAttemptListDto.WebhookName,
                    options => options.MapFrom(l => l.WebhookEvent.WebhookName))
                .ForMember(webhookSendAttemptListDto => webhookSendAttemptListDto.Data,
                    options => options.MapFrom(l => l.WebhookEvent.Data));

            configuration.CreateMap<WebhookSendAttempt, GetAllSendAttemptsOfWebhookEventOutput>();

            configuration.CreateMap<DynamicProperty, DynamicPropertyDto>().ReverseMap();
            configuration.CreateMap<DynamicPropertyValue, DynamicPropertyValueDto>().ReverseMap();
            configuration.CreateMap<DynamicEntityProperty, DynamicEntityPropertyDto>()
                .ForMember(dto => dto.DynamicPropertyName,
                    options => options.MapFrom(entity => entity.DynamicProperty.DisplayName.IsNullOrEmpty() ? entity.DynamicProperty.PropertyName : entity.DynamicProperty.DisplayName));
            configuration.CreateMap<DynamicEntityPropertyDto, DynamicEntityProperty>();

            configuration.CreateMap<DynamicEntityPropertyValue, DynamicEntityPropertyValueDto>().ReverseMap();
            
            //User Delegations
            configuration.CreateMap<CreateUserDelegationDto, UserDelegation>();

            /* ADD YOUR OWN CUSTOM AUTOMAPPER MAPPINGS HERE */
        }
    }
}
