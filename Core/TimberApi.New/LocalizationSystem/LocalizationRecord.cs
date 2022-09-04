using LINQtoCSV;

namespace TimberApi.Internal.LocalizationSystem
{
    /// <summary>
    /// Timberborn code Timberborn.Localization.LocalizationRecord
    /// </summary>
public class LocalizationRecord
    {
        [CsvColumn(Name = "ID")]
        public string Id { get; set; }

        [CsvColumn(Name = "Text")]
        public string Text { get; set; }

        [CsvColumn(Name = "Comment")]
        public string Comment { get; set; }

        public bool IsWip { get; set; }
    }
}