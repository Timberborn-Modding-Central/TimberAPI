using System.Reflection;
using TimberbornAPI.UIBuilderSystem;
using TimberbornAPI.UIBuilderSystem.ElementSystem;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel.Previews
{
    public class ButtonPreview : IUIBuilderPreview
    {
        private readonly UIBuilder _uiBuilder;

        public ButtonPreview(UIBuilder uiBuilder)
        {
            _uiBuilder = uiBuilder;
        }

        public string GetPreviewKey()
        {
            return "buttons";
        }

        public string GetPreviewName()
        {
            return "Buttons";
        }
        
        public VisualElement GetPreview()
        {
            VisualElementBuilder root = _uiBuilder.CreateComponentBuilder().CreateVisualElement();

            root.AddPreset(factory => factory.Labels().DefaultHeader(text: "Buttons", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddComponent(builder =>
            {
                builder.SetFlexDirection(FlexDirection.Row).SetFlexWrap(Wrap.Wrap).SetJustifyContent(Justify.SpaceAround);
                builder.AddPreset(factory => factory.Buttons().Button(text: "I am a button", width: new Length(150, Pixel)));
                builder.AddPreset(factory => factory.Buttons().Close());
                builder.AddPreset(factory => factory.Buttons().Minus());
                builder.AddPreset(factory => factory.Buttons().MinusInverted());
                builder.AddPreset(factory => factory.Buttons().Plus());
                builder.AddPreset(factory => factory.Buttons().PlusInverted());
                builder.AddPreset(factory => factory.Buttons().CircleEmpty());
                builder.AddPreset(factory => factory.Buttons().ClampDown());
                builder.AddPreset(factory => factory.Buttons().ClampUp());
                builder.AddPreset(factory => factory.Buttons().BugTracker());
                builder.AddPreset(factory => factory.Buttons().LevelVisibilityReset());
                builder.AddPreset(factory => factory.Buttons().SliderHolder());
                builder.AddPreset(factory => factory.Buttons().ResetButton());
            });
            
            root.AddPreset(factory => factory.Labels().DefaultHeader(text: "Arrow buttons", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddComponent(builder =>
            {
                builder.SetFlexDirection(FlexDirection.Row).SetFlexWrap(Wrap.Wrap).SetJustifyContent(Justify.SpaceAround);
                builder.AddPreset(factory => factory.Buttons().ArrowUp());
                builder.AddPreset(factory => factory.Buttons().ArrowDown());
                builder.AddPreset(factory => factory.Buttons().ArrowLeft());
                builder.AddPreset(factory => factory.Buttons().ArrowRight());
                builder.AddPreset(factory => factory.Buttons().ArrowUpInverted());
                builder.AddPreset(factory => factory.Buttons().ArrowDownInverted());
                builder.AddPreset(factory => factory.Buttons().ArrowLeftInverted());
                builder.AddPreset(factory => factory.Buttons().ArrowRightInverted());
                builder.AddPreset(factory => factory.Buttons().UpArrow());
                builder.AddPreset(factory => factory.Buttons().DownArrow());
                builder.AddPreset(factory => factory.Buttons().LeftArrow());
                builder.AddPreset(factory => factory.Buttons().RightArrow());
            });
            
            root.AddPreset(factory => factory.Labels().DefaultHeader(text: "Cycler buttons", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddComponent(builder =>
            {
                builder.SetFlexDirection(FlexDirection.Row).SetFlexWrap(Wrap.Wrap).SetJustifyContent(Justify.SpaceAround);
                builder.AddPreset(factory => factory.Buttons().CyclerLeft());
                builder.AddPreset(factory => factory.Buttons().CyclerRight());
                builder.AddPreset(factory => factory.Buttons().CyclerLeftMain());
                builder.AddPreset(factory => factory.Buttons().CyclerRightMain());
            });
            
            root.AddPreset(factory => factory.Labels().DefaultHeader(text: "Speed control buttons", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            root.AddComponent(builder =>
            {
                builder.SetFlexDirection(FlexDirection.Row).SetFlexWrap(Wrap.Wrap).SetJustifyContent(Justify.SpaceAround);
                builder.AddPreset(factory => factory.Buttons().SpeedButton0());
                builder.AddPreset(factory => factory.Buttons().SpeedButton1());
                builder.AddPreset(factory => factory.Buttons().SpeedButton2());
                builder.AddPreset(factory => factory.Buttons().SpeedButton3());
            });

            root.AddPreset(factory => factory.Labels().DefaultHeader(text: "Nine sliced buttons", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; })));
            root.AddPreset(factory => factory.Labels().GameTextSmall(text: "These buttons can be used with any height & width without transformation", builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
            
            FieldInfo[] scales = typeof(TimberApiStyle.Scales).GetFields(BindingFlags.Static | BindingFlags.Public);

            foreach (FieldInfo scale in scales)
            {
                root.AddPreset(factory => factory.Labels().DefaultBig(text: scale.Name, builder: builder => builder.SetStyle(style => { style.alignSelf = Align.Center; style.marginBottom = new Length(10, Pixel); })));
                root.AddComponent(builder =>
                {
                    builder.SetFlexDirection(FlexDirection.Row).SetFlexWrap(Wrap.Wrap).SetJustifyContent(Justify.SpaceAround);
                    builder.AddPreset(factory => factory.Buttons().ButtonGame(text: "I am a button", scale: scale.GetValue(null).ToString()));
                    builder.AddPreset(factory => factory.Buttons().NewGameCustom(text: "I am a button", scale: scale.GetValue(null).ToString()));
                    builder.AddPreset(factory => factory.Buttons().NewGameEasy(text: "I am a button", scale: scale.GetValue(null).ToString()));
                    builder.AddPreset(factory => factory.Buttons().NewGameNormal(text: "I am a button", scale: scale.GetValue(null).ToString()));
                    builder.AddPreset(factory => factory.Buttons().NewGameHard(text: "I am a button", scale: scale.GetValue(null).ToString()));
                });
            }

            
            return root.Build();
        }
    }
}