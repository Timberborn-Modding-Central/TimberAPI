using System;
using System.Collections.ObjectModel;
using Timberborn.CoreUI;
using Timberborn.EntityPanelSystem;
using Timberborn.EntitySystem;
using Timberborn.Localization;
using Timberborn.SelectionSystem;
using TimberbornAPI.UIBuilderSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberbornAPI.EntityLinkerSystem.UI
{
    public abstract class BaseLinkeeFragment<TLink, TLinker, TLinkee, TLinkViewFactory> : IEntityPanelFragment
        where TLinkee : MonoBehaviour, IRegisteredComponent, IEntityLinkee<TLink>
        where TLink : IEntityLink<TLinker, TLinkee>
        where TLinker : MonoBehaviour, IEntityLinker<TLink, TLinkee>
        where TLinkViewFactory : IBaseEntityLinkViewFactory
    {
        protected readonly UIBuilder _builder;
        protected VisualElement _root;
        protected TLinkee _entityLinkee;

        protected static string LinkContainerName = "LinkContainer";
        protected static string NewLinkButtonName = "NewLinkButton";

        protected VisualElement _linksContainer;

        protected TLinkViewFactory _entityLinkViewFactory;
        protected readonly SelectionManager _selectionManager;
        protected readonly ILoc _loc;

        public BaseLinkeeFragment(
            UIBuilder builder,
            TLinkViewFactory entityLinkViewFactory,
            SelectionManager selectionManager,
            ILoc loc)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _entityLinkViewFactory = entityLinkViewFactory;
            _selectionManager = selectionManager;
            _loc = loc;
        }

        public virtual VisualElement InitializeFragment()
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
                            .BuildAndInitialize();

            _linksContainer = _root.Q<VisualElement>(LinkContainerName);

            _root.ToggleDisplayStyle(false);
            return _root;
        }

        public virtual void ShowFragment(GameObject entity)
        {
            _entityLinkee = entity.GetComponent<TLinkee>();

            if (_entityLinkee != null)
            {
                AddAllLinkViews();
            }
        }

        public virtual void UpdateFragment()
        {
            if (_entityLinkee != null)
            {
                _root.ToggleDisplayStyle(true);
            }
            else
            {
                _root.ToggleDisplayStyle(false);
            }
        }

        public virtual void ClearFragment()
        {
            _entityLinkee = null;
            _root.ToggleDisplayStyle(false);
            RemoveAllLinkViews();
        }

        public virtual void AddAllLinkViews()
        {
            ReadOnlyCollection<TLink> links = (ReadOnlyCollection<TLink>)_entityLinkee.EntityLinks;
            for (int i = 0; i < links.Count; i++)
            {
                var link = links[i];
                var linkerGameObject = ((Component)link.Linker).gameObject;

                var prefab = linkerGameObject.GetComponent<LabeledPrefab>();
                var sprite = prefab.Image;

                var view = _entityLinkViewFactory.CreateForLinker(_loc.T(prefab.DisplayNameLocKey));

                var imageContainer = view.Q<VisualElement>("ImageContainer");
                var img = new Image();
                img.sprite = sprite;
                imageContainer.Add(img);

                var targetButton = view.Q<Button>("Target");
                targetButton.clicked += delegate
                {
                    _selectionManager.FocusOn(linkerGameObject);
                };
                view.Q<Button>("RemoveLinkButton").clicked += delegate
                {
                    link.Linker.RemoveLink(link);
                    ResetLinks();
                };

                _linksContainer.Add(view);
            }
        }

        public virtual void RemoveAllLinkViews()
        {
            _linksContainer.Clear();
        }

        public virtual void ResetLinks()
        {
            RemoveAllLinkViews();
            AddAllLinkViews();
            UpdateFragment();
        }
    }
}
