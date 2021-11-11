# TimberAPI
Upcoming API to enable easier Timberborn modding

*Currently has the following features:*
1. Bind your code to Timberborn to allow Dependency Injection. Supports InGame, MainMenu, and MapEditor
2. Listen to any event. Extend the Listener class and use `[OnEvent]`
3. Add labels to localization

Wiki (with general Timberborn modding info too!
[Wiki Link](https://github.com/Timberborn-Modding-Central/TimberAPI/wiki)

*To use this API, add this BepInEx annotation:*
`[BepInDependency("com.timberapi.timberapi")]`

## Dependency Injection:
1. Create a configurator and bind your class:
```
public class ExampleConfigurator : IConfigurator {
    public void Configure(IContainerDefinition containerDefinition) {
        containerDefinition.Bind<ExampleListener>().AsSingleton();
    }
}
```
2. Register it with the game
```
TimberAPI.Dependencies.AddConfigurator(new ExampleConfigurator());
```

## Event Listening
1. Extend the TimberAPI Listener class, which will automatically hook the eventbus
2. Listen to an event with `[OnEvent`
```
public class ExampleListener : Listener {
    [OnEvent]
    public void OnDroughtStarted(DroughtStartedEvent droughtStartedEvent) {...}
```
3. Register your class with the game through a configurator (see Dependency Injection)

## Localization Labels 
1. Add a label
```
TimberAPI.Localization.AddLabel("ExampleMod.ToolGroups.ExampleToolGroup", "Example Label");
```

## UIBuilder
1. Inject UIBuilder into a configurated class
2. Build any visual element with the timberborn components
```c#
public UIBuilderFragmentExample(IUIBuilder builder)
{
    builder.CreateComponentBuilder()
        .AddButton("First Button", name: "firstButton")
        ...
        .Build();
}
```


See [ExamplePlugin](https://github.com/Timberborn-Modding-Central/TimberAPI/blob/main/TimberAPIExample/TimberApiExamplePlugin.cs) for more examples