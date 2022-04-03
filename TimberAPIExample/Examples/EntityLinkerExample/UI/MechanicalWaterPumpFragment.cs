using System.Globalization;
using System.Linq;
using Timberborn.AssetSystem;
using Timberborn.Localization;
using Timberborn.SelectionSystem;
using Timberborn.Warehouses;
using Timberborn.WaterBuildings;
using TimberbornAPI.Common;
using TimberbornAPI.EntityLinkerSystem.UI;
using TimberbornAPI.UIBuilderSystem;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.Length.Unit;

namespace TimberAPIExample.Examples.EntityLinkerExample.UI
{
    /// <summary>
    /// This class represent a custom Fragment that is added to the Mechanical Water Pumps UI.
    /// This has some custom implementations of base methods because we have a label and slider
    /// added, which can't be done in base class
    /// </summary>
    public class MechanicalWaterPumpFragment : BaseLinkerFragment<WaterMover, MechanicalWaterPumpBehaviour, WarehouseBehaviour, MechanicalWaterPumpWarehouseLink, LinkViewFactory, StartLinkingButton>
    {
        private static readonly string _berriesLabelLocKey = "Entitylink.Berries";
        private static readonly string _berriesLabelName = "BerriesLabel";
        private static readonly string _berriesSliderName = "BerriesSlider";

        private readonly IResourceAssetLoader _resourceAssetLoader;

        public MechanicalWaterPumpFragment(UIBuilder builder, 
                                           LinkViewFactory entityLinkViewFactory, 
                                           StartLinkingButton startLinkButton, 
                                           SelectionManager selectionManager, 
                                           ILoc loc,
                                           IResourceAssetLoader resourceAssetLoader) 
            : base(builder, entityLinkViewFactory, startLinkButton, selectionManager, loc)
        {
            _resourceAssetLoader = resourceAssetLoader;
        }

        /// <summary>
        /// Initial stuff to do when the fragment is shown
        /// </summary>
        /// <param name="entity"></param>
        public override void ShowFragment(GameObject entity)
        {
            base.ShowFragment(entity);

            var settingContainers = _linksContainer.Query<VisualElement>()
                                                   .Where(x => x.name != null &&
                                                               x.name.Contains("ViewSettingContainer"))
                                                   .Build()
                                                   .ToList();

            // For every link the water pump has, add a label and slider
            // which allows to control the berry threshold
            for (int i = 0; i < settingContainers.Count; i++)
            {
                var link = _entityLinker.EntityLinks.ElementAt(i);
                var warehouse = link.Linkee.GetComponent<Stockpile>();
                var settingContainer = settingContainers[i];
                var settingElement = SlidenInt(i, warehouse.Inventory.Capacity, 0);
                settingContainer.Add(settingElement);

                // Also set the slider value to the loaded threshold value
                var slider = settingElement.Q<SliderInt>();
                slider.SetValueWithoutNotify(link.BerryTreshold);
            }
        }

        /// <summary>
        /// Update the text on custom label
        /// </summary>
        public override void UpdateFragment()
        {
            base.UpdateFragment();

            if((bool)_entityLinker)
            {
                for(int i = 0; i < _entityLinker.EntityLinks.Count; i++)
                {
                    var label = _linksContainer.Q<Label>($"{_berriesLabelName}{i}");
                    var slider = _linksContainer.Q<SliderInt>($"{_berriesSliderName}{i}");

                    label.text = $"{_loc.T(_berriesLabelLocKey)}{slider.value.ToString(CultureInfo.InvariantCulture)}";
                }
            }
        }

        /// <summary>
        /// Helper method that creates a label and slider for a link
        /// </summary>
        /// <param name="index"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        private VisualElement SlidenInt(int index, int max, int min = 0)
        {
            // Build the label and slider
            var element = _builder.CreateComponentBuilder()
                                  .CreateVisualElement()
                                  .AddPreset(
                                      factory => factory.Labels()
                                                        .GameTextBig(name: $"{_berriesLabelName}{index}",
                                                                     locKey: _berriesLabelLocKey,
                                                                     builder:
                                                                      builder => builder.SetStyle(
                                                                          style => style.alignSelf = Align.Center)))
                                  .AddPreset(
                                      factory => factory.Sliders()
                                                        .SliderIntCircle(min,
                                                                         max,
                                                                         name: $"{_berriesSliderName}{index}",
                                                                         builder:
                                                                             builder => builder.SetStyle(
                                                                                 style => style.flexGrow = 1f)
                                                                                               .SetPadding(new Padding(new Length(21, Pixel), 0))
                                                                                               .ModifyTracker(
                                                                                                   element => element.style.backgroundImage = new StyleBackground(_resourceAssetLoader.Load<Sprite>("Ui/Images/Buttons/Slider_bar")))))
                                  .BuildAndInitialize();

            // Add a callback to the slidet when value is changed
            var berrySlider = element.Q<SliderInt>($"{_berriesSliderName}{index}");
            berrySlider.RegisterValueChangedCallback((@event) => ChangeBerrySlider(@event, berrySlider));

            return element;
        }

        /// <summary>
        /// Helper method that updates the slider value and stores the value in a Link instance
        /// </summary>
        /// <param name="changeEvent"></param>
        /// <param name="slider"></param>
        private void ChangeBerrySlider(ChangeEvent<int> changeEvent,
                                       SliderInt slider)
        {
            slider.SetValueWithoutNotify(changeEvent.newValue);
            int index = int.Parse(slider.name.Substring(slider.name.Length-1));
            _entityLinker.EntityLinks.ElementAt(index).BerryTreshold = changeEvent.newValue;
        }

    }
}
