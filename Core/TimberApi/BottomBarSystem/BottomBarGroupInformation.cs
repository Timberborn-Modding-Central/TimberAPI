namespace TimberApi.BottomBarSystem
{
    public class BottomBarGroupInformation
    {
        public int Section { get; }

        public BottomBarGroupInformation()
        {
            Section = 1;
        }

        public BottomBarGroupInformation(int section)
        {
            Section = section;
        }
    }
}