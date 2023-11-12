#define TGS_EXTERNAL_CONFIGURATION
#define TGS_DEFINE_AND_SET_GLOBAL(Name, Value) var/##Name = ##Value
#define TGS_READ_GLOBAL(Name) global.##Name
#define TGS_WRITE_GLOBAL(Name, Value) global.##Name = ##Value
#define TGS_PROTECT_DATUM(Path)
#define TGS_WORLD_ANNOUNCE(message) world << ##message
#define TGS_WARNING_LOG(message) world.log << "Warn: [##message]"
#define TGS_NOTIFY_ADMINS(event)
#define TGS_CLIENT_COUNT 0
#define TGS_DEBUG_LOG(message) world.log << "TGS DEBUG: [##message]"

#include "..\..\src\DMAPI\tgs.dm"
#include "..\..\src\DMAPI\tgs\includes.dm"
#include "test_setup.dm"
