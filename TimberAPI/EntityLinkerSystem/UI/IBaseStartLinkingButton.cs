using System;
using Timberborn.EntitySystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace TimberbornAPI.EntityLinkerSystem.UI
{
    public interface IBaseStartLinkingButton<TLinker, TLinkee, TLink>
        where TLinker : class, IEntityLinker<TLink, TLinkee>
        where TLinkee : MonoBehaviour, IRegisteredComponent
    {
        void Initialize(VisualElement root, Func<TLinker> linkerProvider, Action createdLinkCallback);
        void UpdateRemainingSlots(int currentLinks, int maxLinks);
    }
}