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
    public class LinkeeFragment<TLink, TLinker, TLinkee> : IEntityPanelFragment
        where TLinkee : MonoBehaviour, IRegisteredComponent, IEntityLinkee<TLink>
        where TLink : IEntityLink<TLinker, TLinkee>
        where TLinker : MonoBehaviour, IEntityLinker<TLink, TLinkee>
    {
        private readonly UIBuilder _builder;
        private VisualElement _root;
        //private Type _linkerComponentType;
        private TLinkee _entityLinkee;

        private static string LinkContainerName = "LinkContainer";
        private static string NewLinkButtonName = "NewLinkButton";

        private VisualElement _linksContainer;

        private EntityLinkViewFactory _entityLinkViewFactory;
        private readonly SelectionManager _selectionManager;
        private readonly ILoc _loc;

        public LinkeeFragment(
            UIBuilder builder,
            EntityLinkViewFactory entityLinkViewFactory,
            SelectionManager selectionManager,
            ILoc loc)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            _entityLinkViewFactory = entityLinkViewFactory;
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
                            .BuildAndInitialize();

            _linksContainer = _root.Q<VisualElement>(LinkContainerName);

            _root.ToggleDisplayStyle(false);
            return _root;
        }

        public void ShowFragment(GameObject entity)
        {
            _entityLinkee = entity.GetComponent<TLinkee>();

            if (_entityLinkee != null)
            {
                AddAllLinkViews();
            }
        }

        public void UpdateFragment()
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

        public void ClearFragment()
        {
            _entityLinkee = null;
            _root.ToggleDisplayStyle(false);
            RemoveAllLinkViews();
        }

        public void AddAllLinkViews()
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

        public void RemoveAllLinkViews()
        {
            _linksContainer.Clear();
        }

        public void ResetLinks()
        {
            RemoveAllLinkViews();
            AddAllLinkViews();
            UpdateFragment();
        }
    }
}
