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
    public class StartLinkingButton<TLinker, TLinkee, TLink>
        where TLinkee : MonoBehaviour, IRegisteredComponent
        //where TLinkee : MonoBehaviour
        where TLinker : class, IEntityLinker<TLink, TLinkee>
    {
        private static readonly string StartLinkingTipLocKey = "Entitylink.StartLinkingTip";
        private static readonly string StartLinkingTitleLocKey = "Entitylink.StartLinkingTitle";
        private static readonly string StartLinkLocKey = "Entitylink.StartLink";

        private readonly ILoc _loc;
        private readonly PickObjectTool _pickObjectTool;
        private readonly SelectionManager _selectionManager;
        private readonly ToolManager _toolManager;
        private Button _button;

        public StartLinkingButton(ILoc loc,
                                  PickObjectTool pickObjectTool,
                                  SelectionManager selectionManager,
                                  ToolManager toolManager)
        {
            _loc = loc;
            _pickObjectTool = pickObjectTool;
            _selectionManager = selectionManager;
            _toolManager = toolManager;
        }

        public void Initialize(VisualElement root,
                               Func<TLinker> linkerProvider,
                               Action createdLinkCallback)
        {
            _button = root.Q<Button>("NewLinkButton");
            _button.clicked += delegate
            {
                StartLinkEntities(linkerProvider(), createdLinkCallback);
            };
        }

        private void StartLinkEntities(TLinker linker,
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

        private string ValidateLinkee(TLinker linker,
                                      GameObject gameObject)
        {
            //IEntityLinkee linkeeComponent = gameObject.GetComponent<IEntityLinkee>();
            return "";
        }

        private void FinishLinkSelection(
            TLinker linker,
            GameObject linkee,
            Action createdLinkCallback)
        {
            TLinkee linkeeComponent = linkee.GetComponent<TLinkee>();
            linker.CreateLink(linkeeComponent);
            createdLinkCallback();
        }
        public void UpdateRemainingSlots(int currentLinks, int maxLinks)
        {
            _button.text = $"{_loc.T(StartLinkLocKey)} ({currentLinks}/{maxLinks})";
            _button.SetEnabled(currentLinks < maxLinks);
        }
    }
}
