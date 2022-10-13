using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Components.AntonovComponents.HelperModels
{
    /// <summary>
    /// Класс-модель параметров компонента с таблицей
    /// </summary>
    public class TablePdfParameters<T>
    {
        /// <summary>
        /// Абсолютный путь папки, в которой будет создан pdf документ
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Заголовок в документе
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Список данных для таблицы
        /// </summary>
        public List<T> DataList { get; set; }
        /// <summary>
        /// Список ячеек первого столбца шапки
        /// </summary>
        public List<CellPdfTable> CellsFirstColumn { get; set; }
        /// <summary>
        /// Размер текста заголовка
        /// </summary>
        public int TitleTextSize { get; set; } = 12;
        /// <summary>
        /// Размер текста содержания
        /// </summary>
        public int ContentTextSize { get; set; } = 9;
    }
}
