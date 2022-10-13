using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Components.AntonovComponents.HelperModels
{
    /// <summary>
    /// Класс-модель ячейки шапки в таблице
    /// </summary>
    public class CellPdfTable
    {
        /// <summary>
        /// Текст в ячейке
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Название свойства, из по которому будут браться значения из данных (для необъединенных ячеек)
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// Ширина одной ячейки
        /// </summary>
        public string ColumnWidth { get; set; } = "1cm";
        /// <summary>
        /// Количество занимаемых ячеек в таблице ( > 1 для указания объединения ячеек)
        /// </summary>
        public int CountCells { get; set; } = 1;
    }
}
