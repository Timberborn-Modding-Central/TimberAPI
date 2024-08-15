using System;
using System.Collections.Generic;
using Timberborn.BaseComponentSystem;
using Timberborn.CoreUI;
using Timberborn.EntitySystem;
using Timberborn.InputSystem;
using Timberborn.SelectionSystem;
using Timberborn.ToolSystem;
using UnityEngine;

namespace TimberApi.EntityLinkerSystem
{
    // TODO: This class has commented code regarding custom cursor from PickObjectTool
    //       In the future the code can be uncommented, when the old cursor for the tool is recovered.
    public class PickObjectTool : Tool, IInputProcessor
    {
        //private static readonly string CursorKey = "PickObjectCursor";
        
        private readonly InputService _inputService;
        
        private readonly ToolManager _toolManager;
        
        private readonly Highlighter _highlighter;
        
        private readonly Colors _colors;
        
        private readonly EntityComponentRegistry _entityComponentRegistry;
        
        //private readonly CursorService _cursorService;
        
        private readonly SelectableObjectRaycaster _selectableObjectRaycaster;
        
        private ToolDescription _toolDescription = null!;
        
        private string _warning = "";
        
        private readonly Dictionary<GameObject, BaseComponent> _allCandidates = new();
        
        private Func<GameObject, string> _validateCandidate = null!;
        
        private Action<GameObject> _callback = null!;

        public PickObjectTool(InputService inputService, ToolManager toolManager, Highlighter highlighter, Colors colors, EntityComponentRegistry entityComponentRegistry, CursorService cursorService, SelectableObjectRaycaster selectableObjectRaycaster)
        {
            _inputService = inputService;
            _toolManager = toolManager;
            _highlighter = highlighter;
            _colors = colors;
            _entityComponentRegistry = entityComponentRegistry;
            //_cursorService = cursorService;
            _selectableObjectRaycaster = selectableObjectRaycaster;
        }

        public override void Enter()
        {
            _inputService.AddInputProcessor(this);
            //_cursorService.SetCursor(CursorKey);
        }

        public override void Exit()
        {
            _inputService.RemoveInputProcessor(this);
            _highlighter.UnhighlightAllSecondary();
            //_cursorService.ResetCursor();
        }

        public override ToolDescription Description()
        {
            return _toolDescription;
        }

        public override string WarningText()
        {
            return _warning;
        }

        public void StartPicking<T>(string title, string description, Func<GameObject, string> validateCandidate, Action<GameObject> callback) where T : BaseComponent, IRegisteredComponent
        {
            _toolDescription = CreateDescription(title, description);
            _validateCandidate = validateCandidate;
            _callback = callback;
            _allCandidates.Clear();
            
            foreach (var component in _entityComponentRegistry.GetEnabled<T>())
            {
                _allCandidates.Add(component.GameObjectFast, component);
            }
            _toolManager.SwitchTool(this);
        } 
        
        public bool ProcessInput()
        {
            HighlightCandidates();
            if (_selectableObjectRaycaster.TryHitSelectableObject(out var hitObject) && _allCandidates.ContainsKey(hitObject.GameObjectFast))
            {
                _highlighter.HighlightSecondary(hitObject, _colors.EntitySelection);
                _warning = _validateCandidate(hitObject.GameObjectFast);
                if (_inputService is { MainMouseButtonDown: true, MouseOverUI: false })
                {
                    _toolManager.SwitchToDefaultTool();
                    _callback(hitObject.GameObjectFast);
                    return true;
                }
            }
            _warning = "";
            return false;
        }

        private void HighlightCandidates()
        {
            _highlighter.UnhighlightAllSecondary();
            foreach (var allCandidate in _allCandidates)
            {
                var color = _validateCandidate(allCandidate.Key) == "" ? _colors.BuildablePreview : _colors.UnbuildablePreview; _highlighter.HighlightSecondary(allCandidate.Value, color);
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
