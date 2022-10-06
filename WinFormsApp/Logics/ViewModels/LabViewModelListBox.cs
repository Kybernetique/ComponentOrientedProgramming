using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Logics.ViewModels
{
    // Выводить в
    // виде списка(дисциплина, идентификатор, тема лабораторной,
    // вопросы при приеме лабораторной)
    public class LabViewModelListBox
    {
        [DisplayName("Дисциплина")]
        public string Subject { get; set; }

        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [DisplayName("Тема")]
        public string Topic { get; set; }

        [DisplayName("Вопросы")]
        public string Questions { get; set; }
    }
}
