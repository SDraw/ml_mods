﻿using System.Reflection;

[assembly: AssemblyTitle("VSFExtension")]
[assembly: AssemblyVersion("1.0.1")]
[assembly: AssemblyFileVersion("1.0.1")]

[assembly: MelonLoader.MelonInfo(typeof(ml_vsf.VsfExtension), "VSFExtension", "1.0.1", "SDraw", "https://github.com/SDraw/ml_mods")]
[assembly: MelonLoader.MelonGame("VRChat", "VRChat")]
[assembly: MelonLoader.MelonAdditionalDependencies("VRChatUtilityKit", "UIExpansionKit")]
[assembly: MelonLoader.MelonPlatform(MelonLoader.MelonPlatformAttribute.CompatiblePlatforms.WINDOWS_X64)]
[assembly: MelonLoader.MelonPlatformDomain(MelonLoader.MelonPlatformDomainAttribute.CompatibleDomains.IL2CPP)]