using LINQtoCSV;

namespace TimberApi.New.LocalizationSystem
{
    /// <summary>
    ///     Timberborn code Timberborn.Localization.LocalizationRecord
    /// </summary>
    internal class LocalizationRecord
    {
        [CsvColumn(Name = "ID")]
        public string Id { get; set; } = null!;

        [CsvColumn(Name = "Text")]
        public string Text { get; set; } = null!;

        [CsvColumn(Name = "Comment")]
        public string Comment { get; set; } = null!;

        public bool IsWip { get; set; }
    }
}