## Unreleased
Fixed Timber API to work with gameversion 0.5.0.0

### Changes
- Updated gamelibs to 0.5.0.0
- Fixed PickObjectTool

## TimberAPI v0.6.1.0

### Changes
- Updated `LocalizationPatch` to allow overwriting localization keys from mods/base game
- Added `RequiredModDependencies` attribute to only use the configurator when specific mod keys are loaded

## TimberAPI v0.6.0.1

### Changes
- Updated `ExitToolGroup`, does not require most group types to disable them after closing
- Changed `SwitchToolGroupPatch` so it will trigger the `ExitToolGroup` and the original group
- Added `BuilderPriorityToolGroup`

## TimberAPI v0.6.0.0

### Changes
- Added sinle type specificaiton eg. `AssetSpecification.original.json`
- Added `AssetSpecification` with `IgnoreDirectoryPrefixes` to remove directory prefixes from the game
- Changed `ContainTools` prefix so that groups will be hidden when empty in/out devmode

## TimberAPI v0.5.5.8

### Changes
- Removed folktail tutorial, due to crash

## TimberAPI v0.5.5.7

### Changes
- Added IApiSpecificationService
- Fixed Demolish tool order

## TimberAPI v0.5.5.6

### Changes
- Fixed BuildingSpecifications
- Fixed dependency order in a correct way

## TimberAPI v0.5.5.5

### Changes

## TimberAPI v0.5.5.4
Big fixes for various problems.

### Changes
- Fixed missing ruins in MapEditor
- Fixed order changing on reload
- Added object specification generator cache
- Fixed colorized text @ihsoft
- Added conditional harmony patching

## TimberAPI v0.5.5.3

### Changes
- Fixed crash due ToolGroup missing FallbackGroup property

## TimberAPI v0.5.5.2

### Changes
- Updated generated bottom bar specifications
- Changed property `DevModeTool` to `DevMode`
- Made Icon property unique with cached icons

## TimberAPI v0.5.5.1

### Changes
- Converted Debug.Logs into TimberApi logs
- Fixed localization patch crash

## TimberAPI v0.5.5.0
The BottomBar rework. TimberApi will now provide a custom written bottom bar to make it more customizable with simple specifications.

### Changes
- Added ToolSystem
- Added ToolUiSystem
- Added ToolGroupSystem
- Added ToolGroupUiSystem
- Added BottomBarSystem
- Added BottomBarUiSystem
- Added `IObjectSpecificationGenerator` for object specifications
- Added HarmonyPatcherSystem
- Added `IEarlyLoadableSingleton`, `ILatePostLoadableSingleton`, `ILateLoadableSingleton`
- Added Property `Name` to `FileSpecification`
- Added `isOriginal` parameter to `GeneratedSpecification` constructor
- Renamed Golems to Bots
- Added `BepInEx.AssemblyPublicizer` to remove reflections

## TimberAPI v0.5.4.2
Automation fix

### Changes
- Changed GameImports import to use relative paths

## TimberAPI v0.5.4.1
Bug fixes.

### Changes
- Fixed PickObjectTool crashing the game

## TimberAPI v0.5.4.0
Updated

### Changes
- Updated for Timberborn 0.4.0.0

## TimberAPI v0.5.3.2

### Changes
- Fixed EntityLinker crashing the game if a mod using them was disabled 
- Fixed path shader
- Changed placeholder versioning logic for developing
- Fixed Timberborn ResourceLoader to work in main menu
- Added material to shader appliers
- Fixed config list merging with default values
- Added indentation to new config files

## TimberAPI v0.5.3.1
Hotfix

### Changes
- Changed console monitor shortcut to Backslash

## TimberAPI v0.5.3.0

### Changes
- Fixed to work with game version 0.3.4.3

### TimberAPI v0.5.0.0 - The Rework

TimberAPI has been fully reworked to have more flexibility on new features and control to the end user. Within this release we have removed the dependency of BepInEx but we are still compatible with it.

### Changes
- NEW: Loader system
- NEW: Bootstrap
- NEW: Mod loader
- NEW: In-game console
- NEW: Config system
- NEW: Compability checker
- NEW: Version system
- NEW: Shader fix
- NEW: Specification generation
- NEW: BuildingSpecification
- REWRITTEN: AssetSystem, ConfiguratorSystem, Logging and DependencyContainer
- MINOR CHANGES: Specification system, UI Builder, EntityLinker and localization files
- REMOVED: EventListener, Localization through code and Entity Action System

## 0.4.0
- NEW: Specifications
- NEW: Improved documentation at https://timberapi.com
- REMOVED: Object Registry, replaced with Specifications

## 0.3.0
- NEW: Dependency Container
- New: Entity Linker
- New: Object Registry
- IMPROVED: Dependency Registry
- INTERNAL IMPROVEMENT: Logging

## 0.1.0 Beta
- Last release before launch. Supports 5 features:
1. Dependency Injection
2. Event listening
3. UI Builder
4. Asset Injection
5. Labels and localization

## 0.1.0 Alpha
- First release
- Added two features:
1. Dependency Injection
2. Event Listening
