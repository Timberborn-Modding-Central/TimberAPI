using System;
using System.Collections.Generic;
using System.Text;
using TimberbornAPI.Common;
using TimberbornAPI.UIBuilderSystem;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberbornAPI.EntityLinkerSystem.UI
{
    public abstract class BaseEntityLinkViewFactory : IBaseEntityLinkViewFactory
    {
        protected readonly UIBuilder _builder;
        public BaseEntityLinkViewFactory(
            UIBuilder builder)
        {
            _builder = builder;
        }

        public virtual VisualElement CreateForLinker(string buttonLabelText)
        {
            var root = Create(buttonLabelText);

            return root;
        }

        public virtual VisualElement CreateForLinkee(string buttonLabelText)
        {
            var root = Create(buttonLabelText);

            return root;
        }

        protected virtual VisualElement Create(string buttonLabelText)
        {
            var rootBuilder =
                _builder.CreateComponentBuilder()
                        .CreateVisualElement()
                        .AddComponent(
                            _builder.CreateComponentBuilder()
                                    .CreateButton()
                                    .SetName("Target")
                                    .AddClass("entity-fragment__button")
                                    .AddClass("entity-fragment__button--green")
                                    .SetColor(new StyleColor(new Color(0.8f, 0.8f, 0.8f, 1f)))
                                    .SetFontSize(new Length(14, Pixel))
                                    .SetFontStyle(FontStyle.Normal)
                                    .SetHeight(new Length(30, Pixel))
                                    .SetWidth(new Length(290, Pixel))
                                    .SetPadding(new Padding(0, 0, 0, 0))
                                    .SetMargin(new Margin(new Length(2, Pixel), 0, new Length(2, Pixel), 0))
                                    .AddComponent(
                                        _builder.CreateComponentBuilder()
                                                .CreateVisualElement()
                                                .SetFlexWrap(Wrap.Wrap)
                                                .SetFlexDirection(FlexDirection.Row)
                                                .SetJustifyContent(Justify.SpaceBetween)
                                                .AddComponent(
                                                    _builder.CreateComponentBuilder()
                                                            .CreateVisualElement()
                                                            .SetFlexWrap(Wrap.Wrap)
                                                            .SetFlexDirection(FlexDirection.Row)
                                                            .SetJustifyContent(Justify.FlexStart)
                                                            .AddComponent(
                                                                _builder.CreateComponentBuilder()
                                                                        .CreateVisualElement()
                                                                        .SetName("ImageContainer")
                                                                        .SetWidth(new Length(28, Pixel))
                                                                        .SetHeight(new Length(28, Pixel))
                                                                        .SetMargin(new Margin(new Length(1, Pixel), 0, 0, new Length(6, Pixel)))
                                                                        .Build())
                                                            .AddPreset(factory => factory.Labels()
                                                                                        .GameTextBig(text: buttonLabelText,
                                                                                                     builder: builder => builder.SetWidth(new Length(180, Pixel))
                                                                                                                                .SetStyle(
                                                                                                                                    style =>
                                                                                                                                    {
                                                                                                                                        style.unityTextAlign = TextAnchor.MiddleLeft;
                                                                                                                                        style.paddingLeft = new Length(3, Pixel);
                                                                                                                                    })))
                                                            .Build())
                                                .AddComponent(
                                                    _builder.CreateComponentBuilder()
                                                            .CreateButton()
                                                            .AddClass("unity-text-element")
                                                            .AddClass("unity-button")
                                                            .AddClass("entity-panel__button")
                                                            .AddClass("entity-panel__button--red")
                                                            .AddClass("distribution-route__icon-wrapper")
                                                            .SetName("RemoveLinkButton")
                                                            .SetMargin(new Margin(new Length(1, Pixel), new Length(2, Pixel), 0, 0))
                                                            .AddComponent(_builder.CreateComponentBuilder()
                                                                                .CreateVisualElement()
                                                                                .AddClass("entity-panel__button")
                                                                                .AddClass("delete-building__icon")
                                                                                .Build())
                                                            .Build())
                                                .Build())
                                    .Build());



            var root = rootBuilder.BuildAndInitialize();

            return root;
        }

    }
}
