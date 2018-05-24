#pragma once


#include "Modules/ModuleManager.h"
#include "sdk.h"
#include "Delegates/DelegateCombinations.h"

class AGONES_API FAgonesModule : public IModuleInterface
{
	static agones::SDK* AgonesSDK;
public:
	static agones::SDK* Get();
    /** IModuleInterface implementation */
    virtual void StartupModule() override;
    virtual void ShutdownModule() override;

};
