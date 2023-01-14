## Unreleased

### Changes
- Fixed EntityLinker crashing the game if a mod using them was disabled 
- Fixed path shader
- Changed placeholder versioning logic for developing
- Fixed Timberborn ResourceLoader to work in main menu
- Added material to shader appliers

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
