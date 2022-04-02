using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Timberborn.CoreUI;
using Timberborn.EntityPanelSystem;
using Timberborn.EntitySystem;
using Timberborn.Localization;
using Timberborn.SelectionSystem;
using TimberbornAPI.UIBuilderSystem;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberbornAPI.EntityLinkerSystem.UI
{
    public class LinkerFragment<TLinkerGameType, TLinker, TLinkee, TLink> : IEntityPanelFragment
        where TLinkerGameType : Component
        where TLinkee : MonoBehaviour, IRegisteredComponent
        where TLink : IEntityLink<TLinker, TLinkee>
        where TLinker : class, IEntityLinker<TLink, TLinkee>
    {
        private readonly UIBuilder _builder;
        private VisualElement _root;
        private TLinker _entityLinker;

        private static string LinkContainerName = "LinkContainer";
        private static string NewLinkButtonName = "NewLinkButton";

        private VisualElement _linksContainer;

        private StartLinkingButton<TLinker, TLinkee, TLink> _startLinkButton;

        private EntityLinkViewFactory _entityLinkViewFactory;
        private readonly SelectionManager _selectionManager;
        private readonly ILoc _loc;

        public LinkerFragment(
            UIBuilder builder,
            EntityLinkViewFactory entityLinkViewFactory,
            StartLinkingButton<TLinker, TLinkee, TLink> startLinkButton,
            SelectionManager selectionManager,
            ILoc loc)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _entityLinkViewFactory = entityLinkViewFactory;
            _startLinkButton = startLinkButton;
            _selectionManager = selectionManager;
            _loc = loc;
        }

        public VisualElement InitializeFragment()
        {
            _root = _builder.CreateFragmentBuilder()
                            .ModifyWrapper(builder => builder.SetFlexDirection(FlexDirection.Row)
                                                             .SetFlexWrap(Wrap.Wrap)
                                                             .SetJustifyContent(Justify.Center))
                            .AddComponent(
                                _builder.CreateComponentBuilder()
                                        .CreateVisualElement()
                                        .SetName(LinkContainerName)
                                        .BuildAndInitialize())
                            .AddComponent(
                                _builder.CreateComponentBuilder()
                                        .CreateButton()
                                        .AddClass("entity-fragment__button")
                                        .AddClass("entity-fragment__button--green")
                                        .SetName(NewLinkButtonName)
                                        .SetColor(new StyleColor(new Color(0.8f, 0.8f, 0.8f, 1f)))
                                        .SetFontSize(new Length(13, Pixel))
                                        .SetFontStyle(FontStyle.Normal)
                                        .SetHeight(new Length(29, Pixel))
                                        .SetWidth(new Length(290, Pixel))
                                        .Build())
                            .BuildAndInitialize();

            _linksContainer = _root.Q<VisualElement>(LinkContainerName);

            _startLinkButton.Initialize(_root, () => _entityLinker, delegate
            {
                RemoveAllLinkViews();
                //ShowFragment(_entityLinker);
            });

            _root.ToggleDisplayStyle(false);
            return _root;
        }

        public void ShowFragment(GameObject entity)
        {
            _entityLinker = entity.GetComponent<TLinker>();

            if(_entityLinker != null)
            {
                AddAllLinkViews();
            }
        }

        public void UpdateFragment()
        {
            if (_entityLinker != null)
            {
                _root.ToggleDisplayStyle(true);
            }
            else
            {
                _root.ToggleDisplayStyle(false);
            }
        }

        public void ClearFragment()
        {
            _entityLinker = null;
            _root.ToggleDisplayStyle(false);
            RemoveAllLinkViews();
        }

        public void RemoveAllLinkViews()
        {
            _linksContainer.Clear();
        }

        public void AddAllLinkViews()
        {
            ReadOnlyCollection<TLink> links = (ReadOnlyCollection<TLink>)_entityLinker.EntityLinks;
            for(int i = 0; i < links.Count; i++)
            {
                var link = links[i];
                var linkeeGameObject = (link.Linkee).gameObject;

                var prefab = linkeeGameObject.GetComponent<LabeledPrefab>();
                var sprite = prefab.Image;

                var view = _entityLinkViewFactory.CreateForLinker(_loc.T(prefab.DisplayNameLocKey));

                var imageContainer = view.Q<VisualElement>("ImageContainer");
                var img = new Image();
                img.sprite = sprite;
                imageContainer.Add(img);

                var targetButton = view.Q<Button>("Target");
                targetButton.clicked += delegate
                {
                    _selectionManager.FocusOn(linkeeGameObject);
                };
                view.Q<Button>("RemoveLinkButton").clicked += delegate
                {
                    link.Linker.RemoveLink(link);
                    ResetLinks();
                };

                _linksContainer.Add(view);
            }

            _startLinkButton.UpdateRemainingSlots(links.Count, _entityLinker.MaxLinks);
        }

        public void ResetLinks()
        {
            RemoveAllLinkViews();
            AddAllLinkViews();
            UpdateFragment();
        }
    }
}
