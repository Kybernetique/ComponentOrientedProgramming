using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Components.AntonovComponents.HelperModels
{
    public class ImagesParameters
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
        /// Массив изображений
        /// </summary>
        public string[] ArrayImages { get; set; }
    }
}
