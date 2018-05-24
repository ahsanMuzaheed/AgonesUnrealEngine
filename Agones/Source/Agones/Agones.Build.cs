// AMAZON CONFIDENTIAL

/*
* All or portions of this file Copyright (c) Amazon.com, Inc. or its affiliates or
* its licensors.
*
* For complete copyright and license terms please see the LICENSE at the root of this
* distribution (the "License"). All use of this software is governed by the License,
* or, if provided, by the license below or the license accompanying this file. Do not
* remove or modify any license notices. This file is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
*
*/

using UnrealBuildTool;

public class Agones : ModuleRules
{
    public Agones(ReadOnlyTargetRules Target) : base(Target)
    {
        PrivateIncludePaths.AddRange(
            new string[] {
            "Agones/Private",
            }
            );


        PublicDependencyModuleNames.AddRange(
            new string[]
            {
            "Core",
            "Projects"
            }
            );


        PrivateDependencyModuleNames.AddRange(
            new string[]
            {
            }
            );


        DynamicallyLoadedModuleNames.AddRange(
            new string[]
            {
            }
            );

        string BaseDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(ModuleDirectory, "..", ".."));
        string SDKDirectory = System.IO.Path.Combine(BaseDirectory, "ThirdParty", Target.Platform.ToString());

        PublicDefinitions.Add("GPR_FORBID_UNREACHABLE_CODE=0");
        PublicDefinitions.Add("GOOGLE_PROTOBUF_NO_RTTI=0");
        PublicDefinitions.Add("PLATFORM_EXCEPTIONS_DISABLED=1");
        
        if (Target.Type == TargetRules.TargetType.Server)
        {
            if (Target.Platform == UnrealTargetPlatform.Linux)
            {
                PublicDefinitions.Add("WITH_AGONES=1");
                SDKDirectory = System.IO.Path.Combine(SDKDirectory, "x64");
                string SDKLib = System.IO.Path.Combine(SDKDirectory, "libagonessdk.so");
                
                PublicLibraryPaths.Add(SDKDirectory);
                //PublicLibraryPaths.Add("../../ThirdParty/Linux/x64");
                //PublicAdditionalLibraries.Add("../../ThirdParty/Linux/x64/libagonessdk.a");
                //PublicAdditionalLibraries.Add("../../ThirdParty/Linux/x64/libgrpc.a");
                //PublicAdditionalLibraries.Add("../../ThirdParty/Linux/x64/libprotobuf.a");
                PublicAdditionalLibraries.Add(SDKLib);    
                // RuntimeDependencies.Add(SDKLib);
            }
        }
        else
        {
            PublicDefinitions.Add("WITH_AGONES=0");
        }
    }
}
