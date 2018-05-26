#pragma once


#include "Modules/ModuleManager.h"
#include "Delegates/DelegateCombinations.h"

class GRPC_API FgrpcModule : public IModuleInterface
{
public:
    /** IModuleInterface implementation */
    virtual void StartupModule() override;
    virtual void ShutdownModule() override;

};
