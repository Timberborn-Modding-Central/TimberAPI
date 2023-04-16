using System;
using System.Collections.Generic;
using System.Linq;
using Timberborn.Common;
using Timberborn.CoreUI;
using Timberborn.EntitySystem;
using Timberborn.InputSystem;
using Timberborn.SelectionSystem;
using Timberborn.ToolSystem;
using UnityEngine;

namespace TimberApi.ToolSystem
{
    public class PickObjectTool : Tool, IInputProcessor
    {
        private static readonly string CursorKey = "PickObjectCursor";

        private readonly HashSet<GameObject> _allCandidates = new();

        private readonly Colors _colors;

        private readonly CursorService _cursorService;

        private readonly EntityComponentRegistry _entityComponentRegistry;

        private readonly Highlighter _highlighter;
        
        private readonly InputService _inputService;

        private readonly SelectableObjectRaycaster _selectableObjectRaycaster;

        private readonly ToolManager _toolManager;

        private Action<GameObject> _callback = null!;

        private ToolDescription _toolDescription = null!;

        private Func<GameObject, string> _validateCandidate = null!;

        private string _warning = "";

        public PickObjectTool(InputService inputService, ToolManager toolManager, Highlighter highlighter, Colors colors, EntityComponentRegistry entityComponentRegistry, CursorService cursorService,
            SelectableObjectRaycaster selectableObjectRaycaster)
        {
            _inputService = inputService;
            _toolManager = toolManager;
            _highlighter = highlighter;
            _colors = colors;
            _entityComponentRegistry = entityComponentRegistry;
            _cursorService = cursorService;
            _selectableObjectRaycaster = selectableObjectRaycaster;
        }

        public bool ProcessInput()
        {
            HighlightCandidates();
            if(_selectableObjectRaycaster.TryHitSelectableObject(out var hitObject) && _allCandidates.Contains(hitObject))
            {
                _highlighter.HighlightSecondary(hitObject, _colors.EntitySelection);
                _warning = _validateCandidate(hitObject);
                if(_inputService is { SelectionStart: true, MouseOverUI: false })
                {
                    _toolManager.SwitchToDefaultTool();
                    _callback(hitObject);
                    return true;
                }
            }

            _warning = "";
            return false;
        }

        public override void Enter()
        {
            _inputService.AddInputProcessor(this);
            _cursorService.SetCursor(CursorKey);
        }

        public override void Exit()
        {
            _inputService.RemoveInputProcessor(this);
            _highlighter.UnhighlightAllSecondary();
            _cursorService.ResetCursor();
        }

        public override ToolDescription Description()
        {
            return _toolDescription;
        }

        public override string WarningText()
        {
            return _warning;
        }

        public void StartPicking<T>(string title, string description, Func<GameObject, string> validateCandidate, Action<GameObject> callback) where T : MonoBehaviour, IRegisteredComponent
        {
            _toolDescription = CreateDescription(title, description);
            _validateCandidate = validateCandidate;
            _callback = callback;
            _allCandidates.Clear();
            IEnumerable<GameObject> values = from component in _entityComponentRegistry.GetEnabled<T>() select component.gameObject;
            _allCandidates.AddRange(values);
            _toolManager.SwitchTool(this);
        }

        private void HighlightCandidates()
        {
            _highlighter.UnhighlightAllSecondary();
            foreach (var allCandidate in _allCandidates)
            {
                var color = _validateCandidate(allCandidate) == "" ? _colors.BuildablePreview : _colors.UnbuildablePreview;
                _highlighter.HighlightSecondary(allCandidate, color);
            }
        }

        private static ToolDescription CreateDescription(string title, string description)
        {
            var builder = new ToolDescription.Builder(title);
            builder.AddSection(description);
            return builder.Build();
        }
    }
}