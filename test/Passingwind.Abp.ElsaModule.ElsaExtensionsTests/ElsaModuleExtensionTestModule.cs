﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Passingwind.Abp.ElsaModule;

[DependsOn(
    typeof(ElsaModuleExtensionModule),
    typeof(ElsaModuleDomainTestModule)
    )]
public class ElsaModuleExtensionTestModule : AbpModule
{
}
