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

public class grpc : ModuleRules
{
    public grpc(ReadOnlyTargetRules Target) : base(Target)
    {
        PrivateIncludePaths.AddRange(
            new string[] {
            "grpc/Private",
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



        if (Target.Type == TargetRules.TargetType.Server)
        {
            if (Target.Platform == UnrealTargetPlatform.Linux)
            {
                string BaseDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(ModuleDirectory, "..", ".."));
                string SDKDirectory = System.IO.Path.Combine(BaseDirectory, "ThirdParty", Target.Platform.ToString());

                PublicDefinitions.Add("GPR_FORBID_UNREACHABLE_CODE=0");
                PublicDefinitions.Add("GOOGLE_PROTOBUF_NO_RTTI=0");

                SDKDirectory = System.IO.Path.Combine(SDKDirectory, "x64");
                PublicLibraryPaths.Add(SDKDirectory);
                PublicDefinitions.Add("UE_GRPC_WIN64=0");
            }
        }
        else if (Target.Type == TargetRules.TargetType.Editor ||
            Target.Type == TargetRules.TargetType.Client)
		{
            if (Target.Platform == UnrealTargetPlatform.Win64)
            {
                string BaseDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(ModuleDirectory, "..", ".."));
                string SDKDirectory = System.IO.Path.Combine(BaseDirectory, "ThirdParty", Target.Platform.ToString());

                PublicDefinitions.Add("GPR_FORBID_UNREACHABLE_CODE=0");
                PublicDefinitions.Add("GOOGLE_PROTOBUF_NO_RTTI=0");

                SDKDirectory = System.IO.Path.Combine(SDKDirectory, "x64");

                PublicLibraryPaths.Add(SDKDirectory);
                PublicDefinitions.Add("UE_GRPC_WIN64=1");
            }
        }
        else
        {
            PublicDefinitions.Add("UE_GRPC_WIN64=1");
        }
    }
}
