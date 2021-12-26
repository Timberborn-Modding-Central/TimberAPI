using UnityEngine.Rendering;

namespace TimberbornAPI.UIBuilderSystem
{
    public static class TimberApiStyle
    {
        public static class Backgrounds
        {
            public static string BorderTransparent = "tba-border_transparent";
            public static string BorderNonTransparent = "tba-border_nontransparent";
            
            public static string Bg1 = "tba-bg-1";
            public static string Bg2 = "tba-bg-2";
            public static string Bg2Striped = "tba-bg-2-striped";
            public static string Bg3 = "tba-bg-3";
            public static string Bg4 = "tba-bg-4";
            public static string Bg5 = "tba-bg-5";
            public static string Bg6 = "tba-bg-6";
            public static string Bg6Striped = "tba-bg-6-striped";
            public static string Bg7 = "tba-bg-7";
            public static string BgInput = "tba-bg-input";
            public static string BgSquare1 = "tba-bg-square-1";
            public static string BgSquare2 = "tba-bg-square-2";
            public static string BgSquare3 = "tba-bg-square-3";
            public static string BgSquare4 = "tba-bg-square-4";
            public static string BgSquare5 = "tba-bg-square-5";
            public static string BgSquare6 = "tba-bg-square-6";
            public static string BgSquareLarge1 = "tba-bg-square-large-1";
            public static string BgSquareLarge2 = "tba-bg-square-large-2";
            public static string BgSquareLarge3 = "tba-bg-square-large-3";
            public static string BgSquareLarge4 = "tba-bg-square-large-4";
            public static string BgSquareLarge5 = "tba-bg-square-large-5";
            public static string BgSquareLarge6 = "tba-bg-square-large-6";
            
            
        }

        public static class Scales
        {
            public static string Scale2 = "tba-scale-2";

            public static string Scale3 = "tba-scale-3";

            public static string Scale4 = "tba-scale-4";

            public static string Scale5 = "tba-scale-5";

            public static string Scale6 = "tba-scale-6";

            public static string Scale7 = "tba-scale-7";

            public static string Scale8 = "tba-scale-8";

            public static string Scale9 = "tba-scale-9";
        }

        public static class Sounds
        {
            public static string Click = "tba-click";

            public static string Cancel = "tba-cancel";
        }

        public static class Buttons
        {
            public static class Normal
            {
                public static string ButtonGame = "tba-button-game";
                
                public static string NewGameCustom = "tba-custom";
                
                public static string NewGameEasy = "tba-easy";
                
                public static string NewGameNormal = "tba-normal";
                
                public static string NewGameHard = "tba-hard";
                
                public static string ArrowDownInverted = "tba-arrow-down-inverted";

                public static string ArrowDown = "tba-arrow-down";

                public static string ArrowLeftInverted = "tba-arrow-left-inverted";

                public static string ArrowLeft = "tba-arrow-left";

                public static string ArrowRightInverted = "tba-arrow-right-inverted";

                public static string ArrowRight = "tba-arrow-right";

                public static string ArrowUpInverted = "tba-arrow-up-inverted";

                public static string ArrowUp = "tba-arrow-up";

                public static string Button = "tba-button";

                public static string CheckboxOff = "tba-checkbox_off";

                public static string CheckboxOn = "tba-checkbox_on";

                public static string CheckmarkAlt = "tba-checkmark-alt";

                public static string CheckmarkInverted = "tba-checkmark-inverted";

                public static string Checkmark = "tba-checkmark";

                public static string CircleEmpty = "tba-circle-empty";

                public static string CircleOff = "tba-circle-off";

                public static string CircleOn = "tba-circle-on";

                public static string Close = "tba-close";

                public static string CrossInverted = "tba-cross-inverted";

                public static string Cross = "tba-cross";

                public static string CyclerLeftMain = "tba-cycler_left";

                public static string CyclerRightMain = "tba-cycler_right";

                public static string DownArrow = "tba-down_arrow";

                public static string EmptyAlt = "tba-empty-alt";

                public static string EmptyInverted = "tba-empty-inverted";

                public static string EmptyRed = "tba-empty-red";

                public static string Empty = "tba-empty";

                public static string LeftArrow = "tba-left_arrow";

                public static string MinusInverted = "tba-minus-inverted";

                public static string Minus = "tba-minus";

                public static string PlusInverted = "tba-plus-inverted";

                public static string Plus = "tba-plus";

                public static string RightArrow = "tba-right_arrow";

                public static string SliderHolder = "tba-slider_holder";

                public static string UpArrow = "tba-up_arrow";

                public static string BugTracker = "tba-bug-tracker";

                public static string ClampDown = "tba-clamp-down";

                public static string ClampUp = "tba-clamp-up";

                public static string CyclerLeft = "tba-cycler-left";

                public static string CyclerRight = "tba-cycler-right";

                public static string LevelVisibilityReset = "tba-level-visibility-reset";

                public static string ResetButton = "tba-reset-button";

                public static string SpeedButton0 = "tba-speed-button-0";

                public static string SpeedButton1 = "tba-speed-button-1";

                public static string SpeedButton2 = "tba-speed-button-2";

                public static string SpeedButton3 = "tba-speed-button-3";
            }

            public static class Hover
            {
                public static string ButtonGameHover = "tba-button-game-hover";
                
                public static string NewGameCustomHover = "tba-custom-hover";
                
                public static string NewGameEasyHover = "tba-easy-hover";
                
                public static string NewGameNormalHover = "tba-normal-hover";
                
                public static string NewGameHardHover = "tba-hard-hover";
                
                public static string ArrowDownHover = "tba-arrow-down-hover";

                public static string ArrowLeftHover = "tba-arrow-left-hover";

                public static string ArrowRightHover = "tba-arrow-right-hover";

                public static string ArrowUpHover = "tba-arrow-up-hover";

                public static string ButtonHover = "tba-button-hover";

                public static string CheckboxOffHover = "tba-checkbox_off_hover";

                public static string CheckboxOnHover = "tba-checkbox_on_hover";

                public static string CheckmarkHover = "tba-checkmark-hover";

                public static string CircleEmptyHover = "tba-circle-empty-hover";

                public static string CircleHover = "tba-circle-hover";

                public static string CircleOffHover = "tba-circle-off-hover";

                public static string CircleOnHover = "tba-circle-on-hover";

                public static string CloseHover = "tba-close_hover";

                public static string CrossHover = "tba-cross-hover";

                public static string CyclerLeftMainHover = "tba-cycler_left_hover";

                public static string CyclerRightMainHover = "tba-cycler_right_hover";

                public static string DownArrowHover = "tba-down_arrow_hover";

                public static string EmptyHover = "tba-empty-hover";

                public static string EmptyRedHover = "tba-empty-red-hover";

                public static string LeftArrowHover = "tba-left_arrow_hover";

                public static string MinusHover = "tba-minus-hover";

                public static string PlusHover = "tba-plus-hover";

                public static string RightArrowHover = "tba-right_arrow_hover";

                public static string SliderHolderHover = "tba-slider_holder_hover";

                public static string UpArrowHover = "tba-up_arrow_hover";

                public static string BugTrackerHover = "tba-bug-tracker-hover";

                public static string ClampDownHover = "tba-clamp-down-hover";

                public static string ClampUpHover = "tba-clamp-up-hover";

                public static string CyclerLeftHover = "tba-cycler-left-hover";

                public static string CyclerRightHover = "tba-cycler-right-hover";

                public static string LevelVisibilityResetHover = "tba-level-visibility-reset-hover";

                public static string ResetButtonHover = "tba-reset-button-hover";

                public static string SpeedButton0Hover = "tba-speed-button-0-hover";

                public static string SpeedButton1Hover = "tba-speed-button-1-hover";

                public static string SpeedButton2Hover = "tba-speed-button-2-hover";

                public static string SpeedButton3Hover = "tba-speed-button-3-hover";
            }

            public static class Active
            {
                public static string ButtonGameActive = "tba-button-game-active";
                
                public static string NewGameCustomActive = "tba-custom-active";
                
                public static string NewGameEasyActive = "tba-easy-active";
                
                public static string NewGameNormalActive = "tba-normal-active";
                
                public static string NewGameHardActive = "tba-hard-active";
                
                public static string ArrowDownActive = "tba-arrow-down-active";

                public static string ArrowLeftActive = "tba-arrow-left-active";

                public static string ArrowRightActive = "tba-arrow-right-active";

                public static string ArrowUpActive = "tba-arrow-up-active";

                public static string CheckmarkActive = "tba-checkmark-active";

                public static string CircleEmptyActive = "tba-circle-empty-active";

                public static string CrossActive = "tba-cross-active";

                public static string EmptyActive = "tba-empty-active";

                public static string MinusActive = "tba-minus-active";

                public static string PlusActive = "tba-plus-active";

                public static string BugTrackerActive = "tba-bug-tracker-active";

                public static string ClampDownActive = "tba-clamp-down-active";

                public static string ClampUpActive = "tba-clamp-up-active";

                public static string ResetButtonActive = "tba-reset-button-active";

                public static string SpeedButton0Active = "tba-speed-button-0-active";

                public static string SpeedButton1Active = "tba-speed-button-1-active";

                public static string SpeedButton2Active = "tba-speed-button-2-active";

                public static string SpeedButton3Active = "tba-speed-button-3-active";
            }

            public static class Checked
            {
                public static class Normal
                {
                    public static string ArrowDownInvertedChecked = "tba-arrow-down-inverted-checked";

                    public static string ArrowDownChecked = "tba-arrow-down-checked";

                    public static string ArrowLeftInvertedChecked = "tba-arrow-left-inverted-checked";

                    public static string ArrowLeftChecked = "tba-arrow-left-checked";

                    public static string ArrowRightInvertedChecked = "tba-arrow-right-inverted-checked";

                    public static string ArrowRightChecked = "tba-arrow-right-checked";

                    public static string ArrowUpInvertedChecked = "tba-arrow-up-inverted-checked";

                    public static string ArrowUpChecked = "tba-arrow-up-checked";

                    public static string ButtonChecked = "tba-button-checked";

                    public static string CheckboxOffChecked = "tba-checkbox_off-checked";

                    public static string CheckboxOnChecked = "tba-checkbox_on-checked";

                    public static string CheckmarkAltChecked = "tba-checkmark-alt-checked";

                    public static string CheckmarkInvertedChecked = "tba-checkmark-inverted-checked";

                    public static string CheckmarkChecked = "tba-checkmark-checked";

                    public static string CircleEmptyChecked = "tba-circle-empty-checked";

                    public static string CircleOffChecked = "tba-circle-off-checked";

                    public static string CircleOnChecked = "tba-circle-on-checked";

                    public static string CloseChecked = "tba-close-checked";

                    public static string CrossInvertedChecked = "tba-cross-inverted-checked";

                    public static string CrossChecked = "tba-cross-checked";

                    public static string CyclerLeftCheckedMain = "tba-cycler_left-checked";

                    public static string CyclerRightCheckedMain = "tba-cycler_right-checked";

                    public static string DownArrowChecked = "tba-down_arrow-checked";

                    public static string EmptyAltChecked = "tba-empty-alt-checked";

                    public static string EmptyInvertedChecked = "tba-empty-inverted-checked";

                    public static string EmptyRedChecked = "tba-empty-red-checked";

                    public static string EmptyChecked = "tba-empty-checked";

                    public static string LeftArrowChecked = "tba-left_arrow-checked";

                    public static string MinusInvertedChecked = "tba-minus-inverted-checked";

                    public static string MinusChecked = "tba-minus-checked";

                    public static string PlusInvertedChecked = "tba-plus-inverted-checked";

                    public static string PlusChecked = "tba-plus-checked";

                    public static string RightArrowChecked = "tba-right_arrow-checked";

                    public static string SliderHolderChecked = "tba-slider_holder-checked";

                    public static string UpArrowChecked = "tba-up_arrow-checked";

                    public static string BugTrackerChecked = "tba-bug-tracker-checked";

                    public static string ClampDownChecked = "tba-clamp-down-checked";

                    public static string ClampUpChecked = "tba-clamp-up-checked";

                    public static string CyclerLeftChecked = "tba-cycler-left-checked";

                    public static string CyclerRightChecked = "tba-cycler-right-checked";

                    public static string LevelVisibilityResetChecked = "tba-level-visibility-reset-checked";

                    public static string ResetButtonChecked = "tba-reset-button-checked";

                    public static string SpeedButton0Checked = "tba-speed-button-0-checked";

                    public static string SpeedButton1Checked = "tba-speed-button-1-checked";

                    public static string SpeedButton2Checked = "tba-speed-button-2-checked";

                    public static string SpeedButton3Checked = "tba-speed-button-3-checked";
                }

                public static class Hover
                {
                    public static string ArrowDownHoverChecked = "tba-arrow-down-hover-checked";

                    public static string ArrowLeftHoverChecked = "tba-arrow-left-hover-checked";

                    public static string ArrowRightHoverChecked = "tba-arrow-right-hover-checked";

                    public static string ArrowUpHoverChecked = "tba-arrow-up-hover-checked";

                    public static string ButtonHoverChecked = "tba-button-hover-checked";

                    public static string CheckboxOffHoverChecked = "tba-checkbox_off_hover-checked";

                    public static string CheckboxOnHoverChecked = "tba-checkbox_on_hover-checked";

                    public static string CheckmarkHoverChecked = "tba-checkmark-hover-checked";

                    public static string CircleEmptyHoverChecked = "tba-circle-empty-hover-checked";

                    public static string CircleHoverChecked = "tba-circle-hover-checked";

                    public static string CircleOffHoverChecked = "tba-circle-off-hover-checked";

                    public static string CircleOnHoverChecked = "tba-circle-on-hover-checked";

                    public static string CloseHoverChecked = "tba-close_hover-checked";

                    public static string CrossHoverChecked = "tba-cross-hover-checked";

                    public static string CyclerLeftHoverMainChecked = "tba-cycler_left_hover-checked";

                    public static string CyclerRightMainHoverChecked = "tba-cycler_right_hover-checked";

                    public static string DownArrowHoverChecked = "tba-down_arrow_hover-checked";

                    public static string EmptyHoverChecked = "tba-empty-hover-checked";

                    public static string EmptyRedHoverChecked = "tba-empty-red-hover-checked";

                    public static string LeftArrowHoverChecked = "tba-left_arrow_hover-checked";

                    public static string MinusHoverChecked = "tba-minus-hover-checked";

                    public static string PlusHoverChecked = "tba-plus-hover-checked";

                    public static string RightArrowHoverChecked = "tba-right_arrow_hover-checked";

                    public static string SliderHolderHoverChecked = "tba-slider_holder_hover-checked";

                    public static string UpArrowHoverChecked = "tba-up_arrow_hover-checked";

                    public static string BugTrackerHoverChecked = "tba-bug-tracker-hover-checked";

                    public static string ClampDownHoverChecked = "tba-clamp-down-hover-checked";

                    public static string ClampUpHoverChecked = "tba-clamp-up-hover-checked";

                    public static string CyclerLeftHoverChecked = "tba-cycler-left-hover-checked";

                    public static string CyclerRightHoverChecked = "tba-cycler-right-hover-checked";

                    public static string LevelVisibilityResetHoverChecked = "tba-level-visibility-reset-hover-checked";

                    public static string ResetButtonHoverChecked = "tba-reset-button-hover-checked";

                    public static string SpeedButton0HoverChecked = "tba-speed-button-0-hover-checked";

                    public static string SpeedButton1HoverChecked = "tba-speed-button-1-hover-checked";

                    public static string SpeedButton2HoverChecked = "tba-speed-button-2-hover-checked";

                    public static string SpeedButton3HoverChecked = "tba-speed-button-3-hover-checked";
                }

                public static class Active
                {
                    public static string ArrowDownActiveChecked = "tba-arrow-down-active-checked";

                    public static string ArrowLeftActiveChecked = "tba-arrow-left-active-checked";

                    public static string ArrowRightActiveChecked = "tba-arrow-right-active-checked";

                    public static string ArrowUpActiveChecked = "tba-arrow-up-active-checked";

                    public static string CheckmarkActiveChecked = "tba-checkmark-active-checked";

                    public static string CircleEmptyActiveChecked = "tba-circle-empty-active-checked";

                    public static string CrossActiveChecked = "tba-cross-active-checked";

                    public static string EmptyActiveChecked = "tba-empty-active-checked";

                    public static string MinusActiveChecked = "tba-minus-active-checked";

                    public static string PlusActiveChecked = "tba-plus-active-checked";

                    public static string BugTrackerActiveChecked = "tba-bug-tracker-active-checked";

                    public static string ClampDownActiveChecked = "tba-clamp-down-active-checked";

                    public static string ClampUpActiveChecked = "tba-clamp-up-active-checked";

                    public static string ResetButtonActiveChecked = "tba-reset-button-active-checked";

                    public static string SpeedButton0ActiveChecked = "tba-speed-button-0-active-checked";

                    public static string SpeedButton1ActiveChecked = "tba-speed-button-1-active-checked";

                    public static string SpeedButton2ActiveChecked = "tba-speed-button-2-active-checked";

                    public static string SpeedButton3ActiveChecked = "tba-speed-button-3-active-checked";
                }
            }
        }
    }
}