#include "Agones.h"
#include "CoreMinimal.h"
#include "Modules/ModuleManager.h"
#include "Interfaces/IPluginManager.h"

agones::SDK* FAgonesModule::AgonesSDK = nullptr;

agones::SDK* FAgonesModule::Get()
{
	if (AgonesSDK == nullptr)
	{
		AgonesSDK = new agones::SDK();
	}
	return AgonesSDK;
}
void FAgonesModule::StartupModule()
{

}
void FAgonesModule::ShutdownModule()
{
	//if (AgonesSDK)
	//{
	//	//if we didn't called it by now it is last chance.
	//	AgonesSDK->Shutdown();
	//	delete AgonesSDK;
	//	AgonesSDK = nullptr;
	//}
}


IMPLEMENT_MODULE(FAgonesModule, Agones)
