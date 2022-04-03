using System;
using System.Collections.Generic;
using System.Text;
using Timberborn.EntitySystem;
using Timberborn.Localization;
using Timberborn.PickObjectToolSystem;
using Timberborn.SelectionSystem;
using Timberborn.ToolSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberbornAPI.EntityLinkerSystem.UI
{
    public abstract class BaseStartLinkingButton<TLinker, TLinkee, TLink> : IBaseStartLinkingButton<TLinker, TLinkee, TLink> 
        where TLinkee : MonoBehaviour, IRegisteredComponent
        where TLinker : class, IEntityLinker<TLink, TLinkee>
    {
        protected static readonly string StartLinkingTipLocKey = "Entitylink.StartLinkingTip";
        protected static readonly string StartLinkingTitleLocKey = "Entitylink.StartLinkingTitle";
        protected static readonly string StartLinkLocKey = "Entitylink.StartLink";

        protected readonly ILoc _loc;
        protected readonly PickObjectTool _pickObjectTool;
        protected readonly SelectionManager _selectionManager;
        protected readonly ToolManager _toolManager;
        protected Button _button;

        public BaseStartLinkingButton(ILoc loc,
                                  PickObjectTool pickObjectTool,
                                  SelectionManager selectionManager,
                                  ToolManager toolManager)
        {
            _loc = loc;
            _pickObjectTool = pickObjectTool;
            _selectionManager = selectionManager;
            _toolManager = toolManager;
        }

        public virtual void Initialize(VisualElement root,
                               Func<TLinker> linkerProvider,
                               Action createdLinkCallback)
        {
            _button = root.Q<Button>("NewLinkButton");
            _button.clicked += delegate
            {
                StartLinkEntities(linkerProvider(), createdLinkCallback);
            };
        }

        protected virtual void StartLinkEntities(TLinker linker,
                                       Action createdLinkCallback)
        {
            Console.WriteLine($"started picking: {typeof(TLinkee)}");
            _pickObjectTool.StartPicking<TLinkee>(
                _loc.T(StartLinkingTitleLocKey),
                _loc.T(StartLinkingTipLocKey),
                (GameObject gameobject) => ValidateLinkee(linker, gameobject),
                delegate (GameObject linkee)
                {
                    FinishLinkSelection(linker, linkee, createdLinkCallback);
                });
        }

        protected virtual string ValidateLinkee(TLinker linker,
                                      GameObject gameObject)
        {
            //IEntityLinkee linkeeComponent = gameObject.GetComponent<IEntityLinkee>();
            return "";
        }

        protected virtual void FinishLinkSelection(
            TLinker linker,
            GameObject linkee,
            Action createdLinkCallback)
        {
            TLinkee linkeeComponent = linkee.GetComponent<TLinkee>();
            linker.CreateLink(linkeeComponent);
            createdLinkCallback();
        }
        public virtual void UpdateRemainingSlots(int currentLinks, int maxLinks)
        {
            _button.text = $"{_loc.T(StartLinkLocKey)} ({currentLinks}/{maxLinks})";
            _button.SetEnabled(currentLinks < maxLinks);
        }
    }
}
