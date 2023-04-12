using System;
using TimberApi.EntityLinkerSystem;
using Timberborn.EntitySystem;
using Timberborn.Localization;
using Timberborn.SelectionSystem;
using Timberborn.ToolSystem;
using UnityEngine;
using UnityEngine.UIElements;
using TimberApi.ToolSystem;

namespace TimberAPIExample.Examples.EntityLinkerExample.UI
{
    /// <summary>
    /// Defines the button that does the actual linking
    /// </summary>
    public class StartLinkingButton
    {
        protected static readonly string StartLinkingTipLocKey = "Entitylink.StartLinkingTip";
        protected static readonly string StartLinkingTitleLocKey = "Entitylink.StartLinkingTitle";
        protected static readonly string StartLinkLocKey = "Entitylink.StartLink";

        protected readonly ILoc _loc;
        protected readonly PickObjectTool _pickObjectTool;
        protected readonly EntitySelectionService _entitySelectionService;
        protected readonly ToolManager _toolManager;
        protected Button _button;

        public StartLinkingButton(
            ILoc loc,
            PickObjectTool pickObjectTool,
            EntitySelectionService entitySelectionService,
            ToolManager toolManager)
        {
            _loc = loc;
            _pickObjectTool = pickObjectTool;
            _entitySelectionService = entitySelectionService;
            _toolManager = toolManager;
        }

        public virtual void Initialize<T>(VisualElement root,
                                       Func<EntityLinker> linkerProvider,
                                       Action createdLinkCallback)
            where T : MonoBehaviour, IRegisteredComponent
        {
            _button = root.Q<Button>("NewLinkButton");
            _button.clicked += delegate
            {
                StartLinkEntities<T>(linkerProvider(), createdLinkCallback);
            };
        }

        /// <summary>
        /// Fires up the object picker tool to select the linkee.-ö..
        /// Called when the button is pressed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="linker"></param>
        /// <param name="createdLinkCallback"></param>
        protected virtual void StartLinkEntities<T>(EntityLinker linker,
                                                    Action createdLinkCallback)
            where T : MonoBehaviour, IRegisteredComponent
        {
            _pickObjectTool.StartPicking<T>(
                _loc.T(StartLinkingTitleLocKey),
                _loc.T(StartLinkingTipLocKey),
                (GameObject gameobject) => ValidateLinkee(linker, gameobject),
                delegate (GameObject linkee)
                {
                    FinishLinkSelection(linker, linkee, createdLinkCallback);
                });
        }

        /// <summary>
        /// Validation logic for the linkee. Return empty string if valid.
        /// Used for example if the entities need to be connected with a path. 
        /// </summary>
        /// <param name="linker"></param>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        protected virtual string ValidateLinkee(
            EntityLinker linker,
            GameObject gameObject)
        {
            return "";
        }

        /// <summary>
        /// Creates a link between entities after the selection
        /// </summary>
        /// <param name="linker"></param>
        /// <param name="linkee"></param>
        /// <param name="createdLinkCallback"></param>
        protected virtual void FinishLinkSelection(
            EntityLinker linker,
            GameObject linkee,
            Action createdLinkCallback)
        {
            EntityLinker linkeeComponent = linkee.GetComponent<EntityLinker>();
            linker.CreateLink(linkeeComponent);
            createdLinkCallback();
        }

        /// <summary>
        /// Updates the label on the linking button
        /// </summary>
        /// <param name="currentLinks"></param>
        /// <param name="maxLinks"></param>
        public virtual void UpdateRemainingSlots(int currentLinks, int maxLinks)
        {
            _button.text = $"{_loc.T(StartLinkLocKey)} ({currentLinks}/{maxLinks})";
            _button.SetEnabled(currentLinks < maxLinks);
        }
    }
}
