# TimberAPI
Upcoming API to enable easier Timberborn modding

*Currently has two features:*
1. Bind your code to Timberborn to allow Dependency Injection. Supports InGame, MainMenu, and MapEditor
2. Listen to any event. Extend the Listener class and use `[OnEvent]`

Wiki Coming Soon (with general Timberborn modding info too!
[Wiki Link](https://github.com/Timberborn-Modding-Central/TimberAPI/wiki)

*To use this API, add this BepInEx annotation:*
`[BepInDependency("com.timberapi.timberapi")]`

*Dependency Injection:*
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

*Event Listening*
1. Extend the TimberAPI Listener class, which will automatically hook the eventbus
2. Listen to an event wit `[OnEvent`
```
public class ExampleListener : Listener {
    [OnEvent]
    public void OnDroughtStarted(DroughtStartedEvent droughtStartedEvent) {...}
```
3. Register your class with the game through a configurator (see Dependency Injection)

See [ExamplePlugin](https://github.com/Timberborn-Modding-Central/TimberAPI/blob/main/TimberAPIExample/TimberApiExamplePlugin.cs) for more examples
