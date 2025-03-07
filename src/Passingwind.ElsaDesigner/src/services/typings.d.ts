﻿/**
 * Generate from url: https://localhost:44345/swagger/v1/swagger.json
 * It is recommended not to modify the document
 * Total count: 219
 **/
import * as Enum from "./enums";

declare namespace API {
    /**
     * *TODO*
     **/
    type AbpLoginResult = {
        result: Enum.LoginResultType;
        description?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type AbpLoginResult1 = {
        result: Enum.LoginResultType1;
        description?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type AccountResult = {
        enableLocalLogin?: boolean | undefined;
        externalProviders?: ExternalProvider[] | undefined;
    };

    /**
     * *TODO*
     **/
    type ActionApiDescriptionModel = {
        uniqueName?: string | undefined;
        name?: string | undefined;
        httpMethod?: string | undefined;
        url?: string | undefined;
        supportedVersions?: string[] | undefined;
        parametersOnMethod?: MethodParameterApiDescriptionModel[] | undefined;
        parameters?: ParameterApiDescriptionModel[] | undefined;
        returnValue: ReturnValueApiDescriptionModel;
        allowAnonymous?: boolean | undefined;
        implementFrom?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type Activity = {
        activityId: string;
        type?: string | undefined;
        name?: string | undefined;
        displayName?: string | undefined;
        description?: string | undefined;
        persistWorkflow?: boolean | undefined;
        loadWorkflowContext?: boolean | undefined;
        saveWorkflowContext?: boolean | undefined;
        attributes?: any | undefined;
        properties?: ActivityDefinitionProperty[] | undefined;
        propertyStorageProviders?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type ActivityConnection = {
        sourceId: string;
        targetId: string;
        outcome?: string | undefined;
        attributes?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type ActivityConnectionCreate = {
        sourceId: string;
        targetId: string;
        outcome?: string | undefined;
        attributes?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type ActivityCreateOrUpdate = {
        activityId: string;
        type: string;
        name: string;
        displayName?: string | undefined;
        description?: string | undefined;
        persistWorkflow?: boolean | undefined;
        loadWorkflowContext?: boolean | undefined;
        saveWorkflowContext?: boolean | undefined;
        attributes?: any | undefined;
        properties?: ActivityDefinitionProperty[] | undefined;
        propertyStorageProviders?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type ActivityDefinitionProperty = {
        name?: string | undefined;
        syntax?: string | undefined;
        expressions?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type ActivityInputDescriptor = {
        name?: string | undefined;
        type?: any | undefined;
        uiHint?: string | undefined;
        label?: string | undefined;
        hint?: string | undefined;
        options?: any | undefined;
        category?: string | undefined;
        order: number;
        defaultValue?: any | undefined;
        defaultSyntax?: string | undefined;
        supportedSyntaxes?: string[] | undefined;
        isReadOnly?: boolean | undefined;
        isBrowsable?: boolean | undefined;
        isDesignerCritical?: boolean | undefined;
        defaultWorkflowStorageProvider?: string | undefined;
        disableWorkflowProviderSelection?: boolean | undefined;
        considerValuesAsOutcomes?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type ActivityOutputDescriptor = {
        name?: string | undefined;
        type?: any | undefined;
        hint?: string | undefined;
        isBrowsable?: boolean | undefined;
        defaultWorkflowStorageProvider?: string | undefined;
        disableWorkflowProviderSelection?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type ActivityTypeDescriptor = {
        type?: string | undefined;
        displayName?: string | undefined;
        description?: string | undefined;
        category?: string | undefined;
        traits: Enum.ActivityTraits;
        outcomes?: string[] | undefined;
        inputProperties?: ActivityInputDescriptor[] | undefined;
        outputProperties?: ActivityOutputDescriptor[] | undefined;
        customAttributes?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type ActivityTypeDescriptorListResult = {
        items?: ActivityTypeDescriptor[] | undefined;
        categories?: string[] | undefined;
    };

    /**
     * *TODO*
     **/
    type ApiKey = {
        id: string;
        creationTime: string;
        creatorId?: string | undefined;
        lastModificationTime?: string | undefined;
        lastModifierId?: string | undefined;
        name?: string | undefined;
        expirationTime?: string | undefined;
        secret?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type ApiKeyCreateOrUpdate = {
        name: string;
        expirationTime?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type ApiKeyPagedResult = {
        items?: ApiKey[] | undefined;
        totalCount: number;
    };

    /**
     * *TODO*
     **/
    type ApplicationApiDescriptionModel = {
        modules?: Record<any, ModuleApiDescriptionModel> | undefined;
        types?: Record<any, TypeApiDescriptionModel> | undefined;
    };

    /**
     * *TODO*
     **/
    type ApplicationAuthConfiguration = {
        grantedPolicies?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type ApplicationConfiguration = {
        localization: ApplicationLocalizationConfiguration;
        auth: ApplicationAuthConfiguration;
        setting: ApplicationSettingConfiguration;
        currentUser: CurrentUser;
        features: ApplicationFeatureConfiguration;
        globalFeatures: ApplicationGlobalFeatureConfiguration;
        multiTenancy: MultiTenancyInfo;
        currentTenant: CurrentTenant;
        timing: Timing;
        clock: Clock;
        objectExtensions: ObjectExtensions;
        extraProperties?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type ApplicationFeatureConfiguration = {
        values?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type ApplicationGlobalFeatureConfiguration = {
        enabledFeatures?: string[] | undefined;
    };

    /**
     * *TODO*
     **/
    type ApplicationLocalization = {
        resources?: Record<any, ApplicationLocalizationResource> | undefined;
    };

    /**
     * *TODO*
     **/
    type ApplicationLocalizationConfiguration = {
        values?: any | undefined;
        resources?: Record<any, ApplicationLocalizationResource> | undefined;
        languages?: LanguageInfo[] | undefined;
        currentCulture: CurrentCulture;
        defaultResourceName?: string | undefined;
        languagesMap?: any | undefined;
        languageFilesMap?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type ApplicationLocalizationResource = {
        texts?: any | undefined;
        baseResources?: string[] | undefined;
    };

    /**
     * *TODO*
     **/
    type ApplicationSettingConfiguration = {
        values?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type Assembly = {
        definedTypes?: any[] | undefined;
        exportedTypes?: any[] | undefined;
        codeBase?: string | undefined;
        entryPoint?: any | undefined;
        fullName?: string | undefined;
        imageRuntimeVersion?: string | undefined;
        isDynamic?: boolean | undefined;
        location?: string | undefined;
        reflectionOnly?: boolean | undefined;
        isCollectible?: boolean | undefined;
        isFullyTrusted?: boolean | undefined;
        customAttributes?: any[] | undefined;
        escapedCodeBase?: string | undefined;
        manifestModule?: any | undefined;
        modules?: any[] | undefined;
        globalAssemblyCache?: boolean | undefined;
        hostContext: number;
        securityRuleSet: Enum.SecurityRuleSet;
    };

    /**
     * *TODO*
     **/
    type ChangePasswordInput = {
        currentPassword?: string | undefined;
        newPassword: string;
    };

    /**
     * *TODO*
     **/
    type CleanupSettings = {
        enabled?: boolean | undefined;
        keepDays: number;
        scopeAll?: boolean | undefined;
        scopes?: number[] | undefined;
    };

    /**
     * *TODO*
     **/
    type Clock = {
        kind?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type ConstructorInfo = {
        name?: string | undefined;
        declaringType?: any | undefined;
        reflectedType?: any | undefined;
        module?: any | undefined;
        customAttributes?: any[] | undefined;
        isCollectible?: boolean | undefined;
        metadataToken: number;
        attributes: Enum.MethodAttributes;
        methodImplementationFlags: Enum.MethodImplAttributes;
        callingConvention: Enum.CallingConventions;
        isAbstract?: boolean | undefined;
        isConstructor?: boolean | undefined;
        isFinal?: boolean | undefined;
        isHideBySig?: boolean | undefined;
        isSpecialName?: boolean | undefined;
        isStatic?: boolean | undefined;
        isVirtual?: boolean | undefined;
        isAssembly?: boolean | undefined;
        isFamily?: boolean | undefined;
        isFamilyAndAssembly?: boolean | undefined;
        isFamilyOrAssembly?: boolean | undefined;
        isPrivate?: boolean | undefined;
        isPublic?: boolean | undefined;
        isConstructedGenericMethod?: boolean | undefined;
        isGenericMethod?: boolean | undefined;
        isGenericMethodDefinition?: boolean | undefined;
        containsGenericParameters?: boolean | undefined;
        methodHandle?: any | undefined;
        isSecurityCritical?: boolean | undefined;
        isSecuritySafeCritical?: boolean | undefined;
        isSecurityTransparent?: boolean | undefined;
        memberType: Enum.MemberTypes;
    };

    /**
     * *TODO*
     **/
    type ControllerApiDescriptionModel = {
        controllerName?: string | undefined;
        controllerGroupName?: string | undefined;
        isRemoteService?: boolean | undefined;
        isIntegrationService?: boolean | undefined;
        apiVersion?: string | undefined;
        type?: string | undefined;
        interfaces?: ControllerInterfaceApiDescriptionModel[] | undefined;
        actions?: Record<any, ActionApiDescriptionModel> | undefined;
    };

    /**
     * *TODO*
     **/
    type ControllerInterfaceApiDescriptionModel = {
        type?: string | undefined;
        name?: string | undefined;
        methods?: InterfaceMethodApiDescriptionModel[] | undefined;
    };

    /**
     * *TODO*
     **/
    type CurrentCulture = {
        displayName?: string | undefined;
        englishName?: string | undefined;
        threeLetterIsoLanguageName?: string | undefined;
        twoLetterIsoLanguageName?: string | undefined;
        isRightToLeft?: boolean | undefined;
        cultureName?: string | undefined;
        name?: string | undefined;
        nativeName?: string | undefined;
        dateTimeFormat: DateTimeFormat;
    };

    /**
     * *TODO*
     **/
    type CurrentTenant = {
        id?: string | undefined;
        name?: string | undefined;
        isAvailable?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type CurrentUser = {
        isAuthenticated?: boolean | undefined;
        id?: string | undefined;
        tenantId?: string | undefined;
        impersonatorUserId?: string | undefined;
        impersonatorTenantId?: string | undefined;
        impersonatorUserName?: string | undefined;
        impersonatorTenantName?: string | undefined;
        userName?: string | undefined;
        name?: string | undefined;
        surName?: string | undefined;
        email?: string | undefined;
        emailVerified?: boolean | undefined;
        phoneNumber?: string | undefined;
        phoneNumberVerified?: boolean | undefined;
        roles?: string[] | undefined;
    };

    /**
     * *TODO*
     **/
    type CustomAttributeData = {
        attributeType?: any | undefined;
        constructor?: any | undefined;
        constructorArguments?: any[] | undefined;
        namedArguments?: any[] | undefined;
    };

    /**
     * *TODO*
     **/
    type CustomAttributeNamedArgument = {
        memberInfo?: any | undefined;
        typedValue?: any | undefined;
        memberName?: string | undefined;
        isField?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type CustomAttributeTypedArgument = {
        argumentType?: any | undefined;
        value?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type DateTimeFormat = {
        calendarAlgorithmType?: string | undefined;
        dateTimeFormatLong?: string | undefined;
        shortDatePattern?: string | undefined;
        fullDateTimePattern?: string | undefined;
        dateSeparator?: string | undefined;
        shortTimePattern?: string | undefined;
        longTimePattern?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type EmailSettings = {
        smtpHost?: string | undefined;
        smtpPort: number;
        smtpUserName?: string | undefined;
        smtpPassword?: string | undefined;
        smtpDomain?: string | undefined;
        smtpEnableSsl?: boolean | undefined;
        smtpUseDefaultCredentials?: boolean | undefined;
        defaultFromAddress?: string | undefined;
        defaultFromDisplayName?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type EntityExtension = {
        properties?: Record<any, ExtensionProperty> | undefined;
        configuration?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type EventInfo = {
        name?: string | undefined;
        declaringType?: any | undefined;
        reflectedType?: any | undefined;
        module?: any | undefined;
        customAttributes?: any[] | undefined;
        isCollectible?: boolean | undefined;
        metadataToken: number;
        memberType: Enum.MemberTypes;
        attributes: Enum.EventAttributes;
        isSpecialName?: boolean | undefined;
        addMethod?: any | undefined;
        removeMethod?: any | undefined;
        raiseMethod?: any | undefined;
        isMulticast?: boolean | undefined;
        eventHandlerType?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type ExtensionEnum = {
        fields?: ExtensionEnumField[] | undefined;
        localizationResource?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type ExtensionEnumField = {
        name?: string | undefined;
        value?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type ExtensionProperty = {
        type?: string | undefined;
        typeSimple?: string | undefined;
        displayName: LocalizableString;
        api: ExtensionPropertyApi;
        ui: ExtensionPropertyUi;
        attributes?: ExtensionPropertyAttribute[] | undefined;
        configuration?: any | undefined;
        defaultValue?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type ExtensionPropertyApi = {
        onGet: ExtensionPropertyApiGet;
        onCreate: ExtensionPropertyApiCreate;
        onUpdate: ExtensionPropertyApiUpdate;
    };

    /**
     * *TODO*
     **/
    type ExtensionPropertyApiCreate = {
        isAvailable?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type ExtensionPropertyApiGet = {
        isAvailable?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type ExtensionPropertyApiUpdate = {
        isAvailable?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type ExtensionPropertyAttribute = {
        typeSimple?: string | undefined;
        config?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type ExtensionPropertyUi = {
        onTable: ExtensionPropertyUiTable;
        onCreateForm: ExtensionPropertyUiForm;
        onEditForm: ExtensionPropertyUiForm;
        lookup: ExtensionPropertyUiLookup;
    };

    /**
     * *TODO*
     **/
    type ExtensionPropertyUiForm = {
        isVisible?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type ExtensionPropertyUiLookup = {
        url?: string | undefined;
        resultListPropertyName?: string | undefined;
        displayPropertyName?: string | undefined;
        valuePropertyName?: string | undefined;
        filterParamName?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type ExtensionPropertyUiTable = {
        isVisible?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type ExternalProvider = {
        displayName?: string | undefined;
        authenticationScheme?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type FieldInfo = {
        name?: string | undefined;
        declaringType?: any | undefined;
        reflectedType?: any | undefined;
        module?: any | undefined;
        customAttributes?: any[] | undefined;
        isCollectible?: boolean | undefined;
        metadataToken: number;
        memberType: Enum.MemberTypes;
        attributes: Enum.FieldAttributes;
        fieldType?: any | undefined;
        isInitOnly?: boolean | undefined;
        isLiteral?: boolean | undefined;
        isNotSerialized?: boolean | undefined;
        isPinvokeImpl?: boolean | undefined;
        isSpecialName?: boolean | undefined;
        isStatic?: boolean | undefined;
        isAssembly?: boolean | undefined;
        isFamily?: boolean | undefined;
        isFamilyAndAssembly?: boolean | undefined;
        isFamilyOrAssembly?: boolean | undefined;
        isPrivate?: boolean | undefined;
        isPublic?: boolean | undefined;
        isSecurityCritical?: boolean | undefined;
        isSecuritySafeCritical?: boolean | undefined;
        isSecurityTransparent?: boolean | undefined;
        fieldHandle?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type FindTenantResult = {
        success?: boolean | undefined;
        tenantId?: string | undefined;
        name?: string | undefined;
        isActive?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type GetPermissionListResult = {
        entityDisplayName?: string | undefined;
        groups?: PermissionGroup[] | undefined;
    };

    /**
     * *TODO*
     **/
    type GlobalCode = {
        extraProperties?: any | undefined;
        id: string;
        creationTime: string;
        creatorId?: string | undefined;
        lastModificationTime?: string | undefined;
        lastModifierId?: string | undefined;
        name?: string | undefined;
        description?: string | undefined;
        language: Enum.GlobalCodeLanguage;
        type: Enum.GlobalCodeType;
        latestVersion: number;
        publishedVersion: number;
        tenantId?: string | undefined;
        content?: string | undefined;
        languageDescription?: string | undefined;
        typeDescription?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type GlobalCodeCreateOrUpdate = {
        extraProperties?: any | undefined;
        name: string;
        description?: string | undefined;
        language: Enum.GlobalCodeLanguage;
        type: Enum.GlobalCodeType;
        publish?: boolean | undefined;
        content?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type GlobalCodePagedResult = {
        items?: GlobalCode[] | undefined;
        totalCount: number;
    };

    /**
     * *TODO*
     **/
    type GlobalVariable = {
        id: string;
        creationTime: string;
        creatorId?: string | undefined;
        lastModificationTime?: string | undefined;
        lastModifierId?: string | undefined;
        key?: string | undefined;
        value?: string | undefined;
        isSecret?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type GlobalVariableCreateOrUpdate = {
        key: string;
        value?: string | undefined;
        isSecret?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type GlobalVariablePagedResult = {
        items?: GlobalVariable[] | undefined;
        totalCount: number;
    };

    /**
     * *TODO*
     **/
    type IanaTimeZone = {
        timeZoneName?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type ICustomAttributeProvider = {
    };

    /**
     * *TODO*
     **/
    type IdentityRole = {
        extraProperties?: any | undefined;
        id: string;
        name?: string | undefined;
        isDefault?: boolean | undefined;
        isStatic?: boolean | undefined;
        isPublic?: boolean | undefined;
        concurrencyStamp?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type IdentityRoleCreate = {
        extraProperties?: any | undefined;
        name: string;
        isDefault?: boolean | undefined;
        isPublic?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type IdentityRoleListResult = {
        items?: IdentityRole[] | undefined;
    };

    /**
     * *TODO*
     **/
    type IdentityRolePagedResult = {
        items?: IdentityRole[] | undefined;
        totalCount: number;
    };

    /**
     * *TODO*
     **/
    type IdentityRoleUpdate = {
        extraProperties?: any | undefined;
        name: string;
        isDefault?: boolean | undefined;
        isPublic?: boolean | undefined;
        concurrencyStamp?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type IdentityUser = {
        extraProperties?: any | undefined;
        id: string;
        creationTime: string;
        creatorId?: string | undefined;
        lastModificationTime?: string | undefined;
        lastModifierId?: string | undefined;
        isDeleted?: boolean | undefined;
        deleterId?: string | undefined;
        deletionTime?: string | undefined;
        tenantId?: string | undefined;
        userName?: string | undefined;
        name?: string | undefined;
        surname?: string | undefined;
        email?: string | undefined;
        emailConfirmed?: boolean | undefined;
        phoneNumber?: string | undefined;
        phoneNumberConfirmed?: boolean | undefined;
        isActive?: boolean | undefined;
        lockoutEnabled?: boolean | undefined;
        accessFailedCount: number;
        lockoutEnd?: string | undefined;
        concurrencyStamp?: string | undefined;
        entityVersion: number;
        lastPasswordChangeTime?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type IdentityUserCreate = {
        extraProperties?: any | undefined;
        userName: string;
        name?: string | undefined;
        surname?: string | undefined;
        email: string;
        phoneNumber?: string | undefined;
        isActive?: boolean | undefined;
        lockoutEnabled?: boolean | undefined;
        roleNames?: string[] | undefined;
        password: string;
    };

    /**
     * *TODO*
     **/
    type IdentityUserListResult = {
        items?: IdentityUser[] | undefined;
    };

    /**
     * *TODO*
     **/
    type IdentityUserPagedResult = {
        items?: IdentityUser[] | undefined;
        totalCount: number;
    };

    /**
     * *TODO*
     **/
    type IdentityUserUpdate = {
        extraProperties?: any | undefined;
        userName: string;
        name?: string | undefined;
        surname?: string | undefined;
        email: string;
        phoneNumber?: string | undefined;
        isActive?: boolean | undefined;
        lockoutEnabled?: boolean | undefined;
        roleNames?: string[] | undefined;
        password?: string | undefined;
        concurrencyStamp?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type IdentityUserUpdateRoles = {
        roleNames: string[];
    };

    /**
     * *TODO*
     **/
    type Int32ListResult = {
        items?: number[] | undefined;
    };

    /**
     * *TODO*
     **/
    type InterfaceMethodApiDescriptionModel = {
        name?: string | undefined;
        parametersOnMethod?: MethodParameterApiDescriptionModel[] | undefined;
        returnValue: ReturnValueApiDescriptionModel;
    };

    /**
     * *TODO*
     **/
    type IntPtr = {
    };

    /**
     * *TODO*
     **/
    type LanguageInfo = {
        cultureName?: string | undefined;
        uiCultureName?: string | undefined;
        displayName?: string | undefined;
        twoLetterISOLanguageName?: string | undefined;
        flagIcon?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type LocalizableString = {
        name?: string | undefined;
        resource?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type MemberInfo = {
        memberType: Enum.MemberTypes;
        name?: string | undefined;
        declaringType?: any | undefined;
        reflectedType?: any | undefined;
        module?: any | undefined;
        customAttributes?: any[] | undefined;
        isCollectible?: boolean | undefined;
        metadataToken: number;
    };

    /**
     * *TODO*
     **/
    type MethodBase = {
        memberType: Enum.MemberTypes;
        name?: string | undefined;
        declaringType?: any | undefined;
        reflectedType?: any | undefined;
        module?: any | undefined;
        customAttributes?: any[] | undefined;
        isCollectible?: boolean | undefined;
        metadataToken: number;
        attributes: Enum.MethodAttributes;
        methodImplementationFlags: Enum.MethodImplAttributes;
        callingConvention: Enum.CallingConventions;
        isAbstract?: boolean | undefined;
        isConstructor?: boolean | undefined;
        isFinal?: boolean | undefined;
        isHideBySig?: boolean | undefined;
        isSpecialName?: boolean | undefined;
        isStatic?: boolean | undefined;
        isVirtual?: boolean | undefined;
        isAssembly?: boolean | undefined;
        isFamily?: boolean | undefined;
        isFamilyAndAssembly?: boolean | undefined;
        isFamilyOrAssembly?: boolean | undefined;
        isPrivate?: boolean | undefined;
        isPublic?: boolean | undefined;
        isConstructedGenericMethod?: boolean | undefined;
        isGenericMethod?: boolean | undefined;
        isGenericMethodDefinition?: boolean | undefined;
        containsGenericParameters?: boolean | undefined;
        methodHandle?: any | undefined;
        isSecurityCritical?: boolean | undefined;
        isSecuritySafeCritical?: boolean | undefined;
        isSecurityTransparent?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type MethodInfo = {
        name?: string | undefined;
        declaringType?: any | undefined;
        reflectedType?: any | undefined;
        module?: any | undefined;
        customAttributes?: any[] | undefined;
        isCollectible?: boolean | undefined;
        metadataToken: number;
        attributes: Enum.MethodAttributes;
        methodImplementationFlags: Enum.MethodImplAttributes;
        callingConvention: Enum.CallingConventions;
        isAbstract?: boolean | undefined;
        isConstructor?: boolean | undefined;
        isFinal?: boolean | undefined;
        isHideBySig?: boolean | undefined;
        isSpecialName?: boolean | undefined;
        isStatic?: boolean | undefined;
        isVirtual?: boolean | undefined;
        isAssembly?: boolean | undefined;
        isFamily?: boolean | undefined;
        isFamilyAndAssembly?: boolean | undefined;
        isFamilyOrAssembly?: boolean | undefined;
        isPrivate?: boolean | undefined;
        isPublic?: boolean | undefined;
        isConstructedGenericMethod?: boolean | undefined;
        isGenericMethod?: boolean | undefined;
        isGenericMethodDefinition?: boolean | undefined;
        containsGenericParameters?: boolean | undefined;
        methodHandle?: any | undefined;
        isSecurityCritical?: boolean | undefined;
        isSecuritySafeCritical?: boolean | undefined;
        isSecurityTransparent?: boolean | undefined;
        memberType: Enum.MemberTypes;
        returnParameter?: any | undefined;
        returnType?: any | undefined;
        returnTypeCustomAttributes?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type MethodParameterApiDescriptionModel = {
        name?: string | undefined;
        typeAsString?: string | undefined;
        type?: string | undefined;
        typeSimple?: string | undefined;
        isOptional?: boolean | undefined;
        defaultValue?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type Module = {
        assembly?: any | undefined;
        fullyQualifiedName?: string | undefined;
        name?: string | undefined;
        mdStreamVersion: number;
        moduleVersionId: string;
        scopeName?: string | undefined;
        moduleHandle?: any | undefined;
        customAttributes?: any[] | undefined;
        metadataToken: number;
    };

    /**
     * *TODO*
     **/
    type ModuleApiDescriptionModel = {
        rootPath?: string | undefined;
        remoteServiceName?: string | undefined;
        controllers?: Record<any, ControllerApiDescriptionModel> | undefined;
    };

    /**
     * *TODO*
     **/
    type ModuleExtension = {
        entities?: Record<any, EntityExtension> | undefined;
        configuration?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type ModuleHandle = {
        mdStreamVersion: number;
    };

    /**
     * *TODO*
     **/
    type MonacoSignatureParameter = {
        label?: string | undefined;
        documentation?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type MonacoSignatures = {
        label?: string | undefined;
        documentation?: string | undefined;
        parameters?: MonacoSignatureParameter[] | undefined;
    };

    /**
     * *TODO*
     **/
    type MultiTenancyInfo = {
        isEnabled?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type NameValue = {
        name?: string | undefined;
        value?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type OAuth2Settings = {
        enabled?: boolean | undefined;
        displayName?: string | undefined;
        authority?: string | undefined;
        metadataAddress?: string | undefined;
        clientId?: string | undefined;
        clientSecret?: string | undefined;
        scope?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type OAuth2SettingUpdate = {
        enabled?: boolean | undefined;
        displayName: string;
        authority: string;
        metadataAddress: string;
        clientId: string;
        clientSecret?: string | undefined;
        scope?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type ObjectExtensions = {
        modules?: Record<any, ModuleExtension> | undefined;
        enums?: Record<any, ExtensionEnum> | undefined;
    };

    /**
     * *TODO*
     **/
    type ParameterApiDescriptionModel = {
        nameOnMethod?: string | undefined;
        name?: string | undefined;
        jsonName?: string | undefined;
        type?: string | undefined;
        typeSimple?: string | undefined;
        isOptional?: boolean | undefined;
        defaultValue?: any | undefined;
        constraintTypes?: string[] | undefined;
        bindingSourceId?: string | undefined;
        descriptorName?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type ParameterInfo = {
        attributes: Enum.ParameterAttributes;
        member?: any | undefined;
        name?: string | undefined;
        parameterType?: any | undefined;
        position: number;
        isIn?: boolean | undefined;
        isLcid?: boolean | undefined;
        isOptional?: boolean | undefined;
        isOut?: boolean | undefined;
        isRetval?: boolean | undefined;
        defaultValue?: any | undefined;
        rawDefaultValue?: any | undefined;
        hasDefaultValue?: boolean | undefined;
        customAttributes?: any[] | undefined;
        metadataToken: number;
    };

    /**
     * *TODO*
     **/
    type PermissionGrantInfo = {
        name?: string | undefined;
        displayName?: string | undefined;
        parentName?: string | undefined;
        isGranted?: boolean | undefined;
        allowedProviders?: string[] | undefined;
        grantedProviders?: ProviderInfo[] | undefined;
    };

    /**
     * *TODO*
     **/
    type PermissionGroup = {
        name?: string | undefined;
        displayName?: string | undefined;
        displayNameKey?: string | undefined;
        displayNameResource?: string | undefined;
        permissions?: PermissionGrantInfo[] | undefined;
    };

    /**
     * *TODO*
     **/
    type Profile = {
        extraProperties?: any | undefined;
        userName?: string | undefined;
        email?: string | undefined;
        name?: string | undefined;
        surname?: string | undefined;
        phoneNumber?: string | undefined;
        isExternal?: boolean | undefined;
        hasPassword?: boolean | undefined;
        concurrencyStamp?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type PropertyApiDescriptionModel = {
        name?: string | undefined;
        jsonName?: string | undefined;
        type?: string | undefined;
        typeSimple?: string | undefined;
        isRequired?: boolean | undefined;
        minLength?: number | undefined;
        maxLength?: number | undefined;
        minimum?: string | undefined;
        maximum?: string | undefined;
        regex?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type PropertyInfo = {
        name?: string | undefined;
        declaringType?: any | undefined;
        reflectedType?: any | undefined;
        module?: any | undefined;
        customAttributes?: any[] | undefined;
        isCollectible?: boolean | undefined;
        metadataToken: number;
        memberType: Enum.MemberTypes;
        propertyType?: any | undefined;
        attributes: Enum.PropertyAttributes;
        isSpecialName?: boolean | undefined;
        canRead?: boolean | undefined;
        canWrite?: boolean | undefined;
        getMethod?: any | undefined;
        setMethod?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type ProviderInfo = {
        providerName?: string | undefined;
        providerKey?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type Register = {
        extraProperties?: any | undefined;
        userName: string;
        emailAddress: string;
        password: string;
        appName: string;
    };

    /**
     * *TODO*
     **/
    type RemoteServiceErrorInfo = {
        code?: string | undefined;
        message?: string | undefined;
        details?: string | undefined;
        data?: any | undefined;
        validationErrors?: RemoteServiceValidationErrorInfo[] | undefined;
    };

    /**
     * *TODO*
     **/
    type RemoteServiceErrorResponse = {
        error: RemoteServiceErrorInfo;
    };

    /**
     * *TODO*
     **/
    type RemoteServiceValidationErrorInfo = {
        message?: string | undefined;
        members?: string[] | undefined;
    };

    /**
     * *TODO*
     **/
    type ResetPassword = {
        userId: string;
        resetToken: string;
        password: string;
    };

    /**
     * *TODO*
     **/
    type ReturnValueApiDescriptionModel = {
        type?: string | undefined;
        typeSimple?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type RuntimeFieldHandle = {
        value?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type RuntimeMethodHandle = {
        value?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type RuntimeSelectListContext = {
        providerTypeName: string;
        context?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type RuntimeSelectListResult = {
        isFlagsEnum?: boolean | undefined;
        items?: SelectListItem[] | undefined;
    };

    /**
     * *TODO*
     **/
    type RuntimeTypeHandle = {
        value?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type SelectListItem = {
        text?: string | undefined;
        value?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type SendPasswordResetCode = {
        email: string;
        appName: string;
        returnUrl?: string | undefined;
        returnUrlHash?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type SendTestEmailInput = {
        senderEmailAddress: string;
        targetEmailAddress: string;
        subject: string;
        body?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type SimpleExceptionModel = {
        type?: any | undefined;
        message?: string | undefined;
        stackTrace?: string | undefined;
        data?: any | undefined;
        innerException: SimpleExceptionModel;
    };

    /**
     * *TODO*
     **/
    type StringListResult = {
        items?: string[] | undefined;
    };

    /**
     * *TODO*
     **/
    type StructLayoutAttribute = {
        typeId?: any | undefined;
        value: Enum.LayoutKind;
    };

    /**
     * *TODO*
     **/
    type TimeSpan = {
        ticks: number;
        days: number;
        hours: number;
        milliseconds: number;
        microseconds: number;
        nanoseconds: number;
        minutes: number;
        seconds: number;
        totalDays: number;
        totalHours: number;
        totalMilliseconds: number;
        totalMicroseconds: number;
        totalNanoseconds: number;
        totalMinutes: number;
        totalSeconds: number;
    };

    /**
     * *TODO*
     **/
    type TimeZone = {
        iana: IanaTimeZone;
        windows: WindowsTimeZone;
    };

    /**
     * *TODO*
     **/
    type Timing = {
        timeZone: TimeZone;
    };

    /**
     * *TODO*
     **/
    type Type = {
        name?: string | undefined;
        customAttributes?: any[] | undefined;
        isCollectible?: boolean | undefined;
        metadataToken: number;
        isInterface?: boolean | undefined;
        memberType: Enum.MemberTypes;
        namespace?: string | undefined;
        assemblyQualifiedName?: string | undefined;
        fullName?: string | undefined;
        assembly?: any | undefined;
        module?: any | undefined;
        isNested?: boolean | undefined;
        declaringType?: any | undefined;
        declaringMethod?: any | undefined;
        reflectedType?: any | undefined;
        underlyingSystemType?: any | undefined;
        isTypeDefinition?: boolean | undefined;
        isArray?: boolean | undefined;
        isByRef?: boolean | undefined;
        isPointer?: boolean | undefined;
        isConstructedGenericType?: boolean | undefined;
        isGenericParameter?: boolean | undefined;
        isGenericTypeParameter?: boolean | undefined;
        isGenericMethodParameter?: boolean | undefined;
        isGenericType?: boolean | undefined;
        isGenericTypeDefinition?: boolean | undefined;
        isSZArray?: boolean | undefined;
        isVariableBoundArray?: boolean | undefined;
        isByRefLike?: boolean | undefined;
        isFunctionPointer?: boolean | undefined;
        isUnmanagedFunctionPointer?: boolean | undefined;
        hasElementType?: boolean | undefined;
        genericTypeArguments?: any[] | undefined;
        genericParameterPosition: number;
        genericParameterAttributes: Enum.GenericParameterAttributes;
        attributes: Enum.TypeAttributes;
        isAbstract?: boolean | undefined;
        isImport?: boolean | undefined;
        isSealed?: boolean | undefined;
        isSpecialName?: boolean | undefined;
        isClass?: boolean | undefined;
        isNestedAssembly?: boolean | undefined;
        isNestedFamANDAssem?: boolean | undefined;
        isNestedFamily?: boolean | undefined;
        isNestedFamORAssem?: boolean | undefined;
        isNestedPrivate?: boolean | undefined;
        isNestedPublic?: boolean | undefined;
        isNotPublic?: boolean | undefined;
        isPublic?: boolean | undefined;
        isAutoLayout?: boolean | undefined;
        isExplicitLayout?: boolean | undefined;
        isLayoutSequential?: boolean | undefined;
        isAnsiClass?: boolean | undefined;
        isAutoClass?: boolean | undefined;
        isUnicodeClass?: boolean | undefined;
        isCOMObject?: boolean | undefined;
        isContextful?: boolean | undefined;
        isEnum?: boolean | undefined;
        isMarshalByRef?: boolean | undefined;
        isPrimitive?: boolean | undefined;
        isValueType?: boolean | undefined;
        isSignatureType?: boolean | undefined;
        isSecurityCritical?: boolean | undefined;
        isSecuritySafeCritical?: boolean | undefined;
        isSecurityTransparent?: boolean | undefined;
        structLayoutAttribute?: any | undefined;
        typeInitializer?: any | undefined;
        typeHandle?: any | undefined;
        guid: string;
        baseType?: any | undefined;
        isSerializable?: boolean | undefined;
        containsGenericParameters?: boolean | undefined;
        isVisible?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type TypeApiDescriptionModel = {
        baseType?: string | undefined;
        isEnum?: boolean | undefined;
        enumNames?: string[] | undefined;
        enumValues?: any[] | undefined;
        genericArguments?: string[] | undefined;
        properties?: PropertyApiDescriptionModel[] | undefined;
    };

    /**
     * *TODO*
     **/
    type TypeInfo = {
        name?: string | undefined;
        customAttributes?: any[] | undefined;
        isCollectible?: boolean | undefined;
        metadataToken: number;
        isInterface?: boolean | undefined;
        memberType: Enum.MemberTypes;
        namespace?: string | undefined;
        assemblyQualifiedName?: string | undefined;
        fullName?: string | undefined;
        assembly?: any | undefined;
        module?: any | undefined;
        isNested?: boolean | undefined;
        declaringType?: any | undefined;
        declaringMethod?: any | undefined;
        reflectedType?: any | undefined;
        underlyingSystemType?: any | undefined;
        isTypeDefinition?: boolean | undefined;
        isArray?: boolean | undefined;
        isByRef?: boolean | undefined;
        isPointer?: boolean | undefined;
        isConstructedGenericType?: boolean | undefined;
        isGenericParameter?: boolean | undefined;
        isGenericTypeParameter?: boolean | undefined;
        isGenericMethodParameter?: boolean | undefined;
        isGenericType?: boolean | undefined;
        isGenericTypeDefinition?: boolean | undefined;
        isSZArray?: boolean | undefined;
        isVariableBoundArray?: boolean | undefined;
        isByRefLike?: boolean | undefined;
        isFunctionPointer?: boolean | undefined;
        isUnmanagedFunctionPointer?: boolean | undefined;
        hasElementType?: boolean | undefined;
        genericTypeArguments?: any[] | undefined;
        genericParameterPosition: number;
        genericParameterAttributes: Enum.GenericParameterAttributes;
        attributes: Enum.TypeAttributes;
        isAbstract?: boolean | undefined;
        isImport?: boolean | undefined;
        isSealed?: boolean | undefined;
        isSpecialName?: boolean | undefined;
        isClass?: boolean | undefined;
        isNestedAssembly?: boolean | undefined;
        isNestedFamANDAssem?: boolean | undefined;
        isNestedFamily?: boolean | undefined;
        isNestedFamORAssem?: boolean | undefined;
        isNestedPrivate?: boolean | undefined;
        isNestedPublic?: boolean | undefined;
        isNotPublic?: boolean | undefined;
        isPublic?: boolean | undefined;
        isAutoLayout?: boolean | undefined;
        isExplicitLayout?: boolean | undefined;
        isLayoutSequential?: boolean | undefined;
        isAnsiClass?: boolean | undefined;
        isAutoClass?: boolean | undefined;
        isUnicodeClass?: boolean | undefined;
        isCOMObject?: boolean | undefined;
        isContextful?: boolean | undefined;
        isEnum?: boolean | undefined;
        isMarshalByRef?: boolean | undefined;
        isPrimitive?: boolean | undefined;
        isValueType?: boolean | undefined;
        isSignatureType?: boolean | undefined;
        isSecurityCritical?: boolean | undefined;
        isSecuritySafeCritical?: boolean | undefined;
        isSecurityTransparent?: boolean | undefined;
        structLayoutAttribute?: any | undefined;
        typeInitializer?: any | undefined;
        typeHandle?: any | undefined;
        guid: string;
        baseType?: any | undefined;
        isSerializable?: boolean | undefined;
        containsGenericParameters?: boolean | undefined;
        isVisible?: boolean | undefined;
        genericTypeParameters?: any[] | undefined;
        declaredConstructors?: any[] | undefined;
        declaredEvents?: any[] | undefined;
        declaredFields?: any[] | undefined;
        declaredMembers?: any[] | undefined;
        declaredMethods?: any[] | undefined;
        declaredNestedTypes?: any[] | undefined;
        declaredProperties?: any[] | undefined;
        implementedInterfaces?: any[] | undefined;
    };

    /**
     * *TODO*
     **/
    type UpdateEmailSettings = {
        smtpHost?: string | undefined;
        smtpPort: number;
        smtpUserName?: string | undefined;
        smtpPassword?: string | undefined;
        smtpDomain?: string | undefined;
        smtpEnableSsl?: boolean | undefined;
        smtpUseDefaultCredentials?: boolean | undefined;
        defaultFromAddress: string;
        defaultFromDisplayName: string;
    };

    /**
     * *TODO*
     **/
    type UpdatePermission = {
        name?: string | undefined;
        isGranted?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type UpdatePermissions = {
        permissions?: UpdatePermission[] | undefined;
    };

    /**
     * *TODO*
     **/
    type UpdateProfile = {
        extraProperties?: any | undefined;
        userName?: string | undefined;
        email?: string | undefined;
        name?: string | undefined;
        surname?: string | undefined;
        phoneNumber?: string | undefined;
        concurrencyStamp?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type UserData = {
        id: string;
        tenantId?: string | undefined;
        userName?: string | undefined;
        name?: string | undefined;
        surname?: string | undefined;
        isActive?: boolean | undefined;
        email?: string | undefined;
        emailConfirmed?: boolean | undefined;
        phoneNumber?: string | undefined;
        phoneNumberConfirmed?: boolean | undefined;
        extraProperties?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type UserDataListResult = {
        items?: UserData[] | undefined;
    };

    /**
     * *TODO*
     **/
    type UserLoginInfo = {
        userNameOrEmailAddress: string;
        password: string;
        rememberMe?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type VerifyPasswordResetTokenInput = {
        userId: string;
        resetToken: string;
    };

    /**
     * *TODO*
     **/
    type WindowsTimeZone = {
        timeZoneId?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowContextOptions = {
        contextType?: any | undefined;
        contextFidelity: Enum.WorkflowContextFidelity;
    };

    /**
     * *TODO*
     **/
    type WorkflowCSharpEditorCodeAnalysis = {
        id?: string | undefined;
        message?: string | undefined;
        offsetFrom: number;
        offsetTo: number;
        severity: Enum.WorkflowCSharpEditorCodeAnalysisSeverity;
        severityNumeric: number;
    };

    /**
     * *TODO*
     **/
    type WorkflowCSharpEditorCompletionItem = {
        suggestion?: string | undefined;
        description?: string | undefined;
        symbolKind?: string | undefined;
        itemKind: Enum.WorkflowCSharpEditorCompletionItemKind;
    };

    /**
     * *TODO*
     **/
    type WorkflowDefinition = {
        id: string;
        creationTime: string;
        creatorId?: string | undefined;
        lastModificationTime?: string | undefined;
        lastModifierId?: string | undefined;
        name?: string | undefined;
        displayName?: string | undefined;
        description?: string | undefined;
        latestVersion: number;
        publishedVersion?: number | undefined;
        isSingleton?: boolean | undefined;
        deleteCompletedInstances?: boolean | undefined;
        channel?: string | undefined;
        tag?: string | undefined;
        groupId?: string | undefined;
        groupName?: string | undefined;
        persistenceBehavior: Enum.WorkflowPersistenceBehavior;
        contextOptions: WorkflowContextOptions;
        customAttributes?: any | undefined;
        variables?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowDefinitionAddOwnerRequest = {
        userId: string;
    };

    /**
     * *TODO*
     **/
    type WorkflowDefinitionBasic = {
        id: string;
        creationTime: string;
        creatorId?: string | undefined;
        lastModificationTime?: string | undefined;
        lastModifierId?: string | undefined;
        name?: string | undefined;
        displayName?: string | undefined;
        description?: string | undefined;
        latestVersion: number;
        publishedVersion?: number | undefined;
        isSingleton?: boolean | undefined;
        deleteCompletedInstances?: boolean | undefined;
        channel?: string | undefined;
        tag?: string | undefined;
        groupId?: string | undefined;
        groupName?: string | undefined;
        persistenceBehavior: Enum.WorkflowPersistenceBehavior;
    };

    /**
     * *TODO*
     **/
    type WorkflowDefinitionBasicListResult = {
        items?: WorkflowDefinitionBasic[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowDefinitionBasicPagedResult = {
        items?: WorkflowDefinitionBasic[] | undefined;
        totalCount: number;
    };

    /**
     * *TODO*
     **/
    type WorkflowDefinitionCreateOrUpdate = {
        name: string;
        displayName?: string | undefined;
        description?: string | undefined;
        isSingleton?: boolean | undefined;
        deleteCompletedInstances?: boolean | undefined;
        channel?: string | undefined;
        tag?: string | undefined;
        groupId?: string | undefined;
        persistenceBehavior: Enum.WorkflowPersistenceBehavior;
        contextOptions: WorkflowContextOptions;
        variables?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowDefinitionDispatchRequest = {
        activityId?: string | undefined;
        correlationId?: string | undefined;
        contextId?: string | undefined;
        input?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowDefinitionDispatchResult = {
        workflowInstanceId: string;
    };

    /**
     * *TODO*
     **/
    type WorkflowDefinitionExecuteRequest = {
        activityId?: string | undefined;
        correlationId?: string | undefined;
        contextId?: string | undefined;
        input?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowDefinitionExportRequest = {
        ids?: string[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowDefinitionIamResult = {
        owners?: IdentityUser[] | undefined;
        teams?: WorkflowTeamBasic[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowDefinitionImportRequest = {
        file: any;
        overwrite?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowDefinitionImportResult = {
        totalCount: number;
        successCount: number;
        failedCount: number;
        results?: WorkflowImportResult[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowDefinitionRevertRequest = {
        version: number;
    };

    /**
     * *TODO*
     **/
    type WorkflowDefinitionVersion = {
        id: string;
        creationTime: string;
        creatorId?: string | undefined;
        lastModificationTime?: string | undefined;
        lastModifierId?: string | undefined;
        definition: WorkflowDefinition;
        version: number;
        isLatest?: boolean | undefined;
        isPublished?: boolean | undefined;
        activities?: Activity[] | undefined;
        connections?: ActivityConnection[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowDefinitionVersionCreateOrUpdate = {
        definition: WorkflowDefinitionCreateOrUpdate;
        activities?: ActivityCreateOrUpdate[] | undefined;
        connections?: ActivityConnectionCreate[] | undefined;
        isPublished?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowDefinitionVersionListItem = {
        id: string;
        creationTime: string;
        creatorId?: string | undefined;
        lastModificationTime?: string | undefined;
        lastModifierId?: string | undefined;
        version: number;
        isLatest?: boolean | undefined;
        isPublished?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowDefinitionVersionListItemPagedResult = {
        items?: WorkflowDefinitionVersionListItem[] | undefined;
        totalCount: number;
    };

    /**
     * *TODO*
     **/
    type WorkflowDesignerCSharpLanguageAnalysisRequest = {
        id: string;
        text?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowDesignerCSharpLanguageAnalysisResult = {
        items?: WorkflowCSharpEditorCodeAnalysis[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowDesignerCSharpLanguageCompletionProviderRequest = {
        id: string;
        text?: string | undefined;
        position: number;
    };

    /**
     * *TODO*
     **/
    type WorkflowDesignerCSharpLanguageCompletionProviderResult = {
        items?: WorkflowCSharpEditorCompletionItem[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowDesignerCSharpLanguageFormatterRequest = {
        id: string;
        text?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowDesignerCSharpLanguageFormatterResult = {
        success?: boolean | undefined;
        code?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowDesignerCSharpLanguageHoverProviderRequest = {
        id: string;
        text?: string | undefined;
        position: number;
    };

    /**
     * *TODO*
     **/
    type WorkflowDesignerCSharpLanguageHoverProviderResult = {
        information?: string | undefined;
        offsetFrom: number;
        offsetTo: number;
    };

    /**
     * *TODO*
     **/
    type WorkflowDesignerCSharpLanguageSignatureProviderRequest = {
        id: string;
        text?: string | undefined;
        position: number;
    };

    /**
     * *TODO*
     **/
    type WorkflowDesignerCSharpLanguageSignatureProviderResult = {
        signatures?: MonacoSignatures[] | undefined;
        activeParameter: number;
        activeSignature: number;
    };

    /**
     * *TODO*
     **/
    type WorkflowExecutionLog = {
        id: string;
        creationTime: string;
        creatorId?: string | undefined;
        workflowInstanceId: string;
        activityId: string;
        activityType?: string | undefined;
        timestamp: string;
        eventName?: string | undefined;
        message?: string | undefined;
        source?: string | undefined;
        data?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowExecutionLogListResult = {
        items?: WorkflowExecutionLog[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowExecutionLogPagedResult = {
        items?: WorkflowExecutionLog[] | undefined;
        totalCount: number;
    };

    /**
     * *TODO*
     **/
    type WorkflowGroup = {
        extraProperties?: any | undefined;
        id: string;
        creationTime: string;
        creatorId?: string | undefined;
        lastModificationTime?: string | undefined;
        lastModifierId?: string | undefined;
        name?: string | undefined;
        description?: string | undefined;
        tenantId?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowGroupCreateOrUpdate = {
        extraProperties?: any | undefined;
        name: string;
        description?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowGroupListResult = {
        items?: WorkflowGroup[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowGroupPagedResult = {
        items?: WorkflowGroup[] | undefined;
        totalCount: number;
    };

    /**
     * *TODO*
     **/
    type WorkflowImportResult = {
        fileName?: string | undefined;
        hasError?: boolean | undefined;
        errorMessage?: string | undefined;
        workflow: WorkflowDefinitionBasic;
    };

    /**
     * *TODO*
     **/
    type WorkflowInput = {
        input?: any | undefined;
        storageProviderName?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowInputReference = {
        providerName?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstance = {
        id: string;
        creationTime: string;
        creatorId?: string | undefined;
        lastModificationTime?: string | undefined;
        lastModifierId?: string | undefined;
        workflowDefinitionId: string;
        workflowDefinitionVersionId: string;
        name?: string | undefined;
        version: number;
        workflowStatus: Enum.WorkflowInstanceStatus;
        correlationId?: string | undefined;
        contextType?: string | undefined;
        contextId?: string | undefined;
        groupId?: string | undefined;
        lastExecutedTime?: string | undefined;
        finishedTime?: string | undefined;
        cancelledTime?: string | undefined;
        faultedTime?: string | undefined;
        finishedDuration: TimeSpan;
        lastExecutedActivityId?: string | undefined;
        input: WorkflowInputReference;
        output: WorkflowOutputReference;
        currentActivity: WorkflowInstanceScheduledActivity;
        faults?: WorkflowInstanceFaultBasic[] | undefined;
        variables?: any | undefined;
        metadata?: any | undefined;
        scheduledActivities?: WorkflowInstanceScheduledActivity[] | undefined;
        blockingActivities?: WorkflowInstanceBlockingActivity[] | undefined;
        activityScopes?: WorkflowInstanceActivityScope[] | undefined;
        activityData?: WorkflowInstanceActivityData[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceActivityData = {
        activityId: string;
        data?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceActivityScope = {
        activityId: string;
        variables?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceBasic = {
        id: string;
        creationTime: string;
        creatorId?: string | undefined;
        lastModificationTime?: string | undefined;
        lastModifierId?: string | undefined;
        workflowDefinitionId: string;
        workflowDefinitionVersionId: string;
        name?: string | undefined;
        version: number;
        workflowStatus: Enum.WorkflowInstanceStatus;
        correlationId?: string | undefined;
        contextType?: string | undefined;
        contextId?: string | undefined;
        groupId?: string | undefined;
        lastExecutedTime?: string | undefined;
        finishedTime?: string | undefined;
        cancelledTime?: string | undefined;
        faultedTime?: string | undefined;
        finishedDuration: TimeSpan;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceBasicPagedResult = {
        items?: WorkflowInstanceBasic[] | undefined;
        totalCount: number;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceBatchActionRequest = {
        ids?: string[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceBlockingActivity = {
        activityId: string;
        activityType?: string | undefined;
        tag?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceDateCountStatistic = {
        date: string;
        finishedCount: number;
        failedCount: number;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceDateCountStatisticsResult = {
        items?: WorkflowInstanceDateCountStatistic[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceDispatchRequest = {
        activityId?: string | undefined;
        input: WorkflowInput;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceExecuteRequest = {
        activityId?: string | undefined;
        input: WorkflowInput;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceExecutionLogSummary = {
        activities?: WorkflowInstanceExecutionLogSummaryActivity[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceExecutionLogSummaryActivity = {
        activityId: string;
        activityType?: string | undefined;
        isExecuting?: boolean | undefined;
        isExecuted?: boolean | undefined;
        isFaulted?: boolean | undefined;
        executedCount: number;
        startTime: string;
        endTime: string;
        duration: number;
        outcomes?: string[] | undefined;
        stateData?: any | undefined;
        journalData?: any | undefined;
        message?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceFault = {
        id: string;
        creationTime: string;
        creatorId?: string | undefined;
        workflowInstanceId: string;
        faultedActivityId?: string | undefined;
        resuming?: boolean | undefined;
        activityInput?: any | undefined;
        message?: string | undefined;
        exception: SimpleExceptionModel;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceFaultBasic = {
        faultedActivityId?: string | undefined;
        resuming?: boolean | undefined;
        activityInput?: any | undefined;
        message?: string | undefined;
        exception: SimpleExceptionModel;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceFaultListResult = {
        items?: WorkflowInstanceFault[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceFaultPagedResult = {
        items?: WorkflowInstanceFault[] | undefined;
        totalCount: number;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceRetryRequest = {
        runImmediately?: boolean | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceScheduledActivity = {
        activityId: string;
        input?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowInstanceStatusCountStatisticsResult = {
        all: number;
        running: number;
        finished: number;
        faulted: number;
        suspended: number;
    };

    /**
     * *TODO*
     **/
    type WorkflowOutputReference = {
        providerName?: string | undefined;
        activityId?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowProviderDescriptor = {
        name?: string | undefined;
        type?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowProviderDescriptorListResult = {
        items?: WorkflowProviderDescriptor[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowSignalDispatchRequest = {
        workflowInstanceId?: string | undefined;
        correlationId?: string | undefined;
        input?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowSignalDispatchResult = {
        startedWorkflows?: WorkflowSignalResult[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowSignalExecuteRequest = {
        workflowInstanceId?: string | undefined;
        correlationId?: string | undefined;
        input?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowSignalExecuteResult = {
        startedWorkflows?: WorkflowSignalResult[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowSignalResult = {
        workflowInstanceId: string;
        activityId?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowStorageProviderInfo = {
        name?: string | undefined;
        displayName?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowStorageProviderInfoListResult = {
        items?: WorkflowStorageProviderInfo[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowTeam = {
        id: string;
        creationTime: string;
        creatorId?: string | undefined;
        lastModificationTime?: string | undefined;
        lastModifierId?: string | undefined;
        name?: string | undefined;
        description?: string | undefined;
        userIds?: string[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowTeamBasic = {
        id: string;
        creationTime: string;
        creatorId?: string | undefined;
        lastModificationTime?: string | undefined;
        lastModifierId?: string | undefined;
        name?: string | undefined;
        description?: string | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowTeamBasicPagedResult = {
        items?: WorkflowTeamBasic[] | undefined;
        totalCount: number;
    };

    /**
     * *TODO*
     **/
    type WorkflowTeamCreateOrUpdate = {
        name: string;
        description?: string | undefined;
        userIds?: string[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowTeamRoleScope = {
        roleName?: string | undefined;
        values?: WorkflowTeamRoleScopeValue[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowTeamRoleScopeCreateOrUpdate = {
        roleName: string;
        items?: WorkflowTeamRoleScopeValue[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowTeamRoleScopeListResult = {
        items?: WorkflowTeamRoleScope[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowTeamRoleScopeValue = {
        providerName: string;
        providerValue: string;
    };

    /**
     * *TODO*
     **/
    type WorkflowTeamUserUpdateRequest = {
        userIds?: string[] | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowVariables = {
        variables?: any | undefined;
    };

    /**
     * *TODO*
     **/
    type WorkflowVariableUpdate = {
        variables?: any | undefined;
    };


}
