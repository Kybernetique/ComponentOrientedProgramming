using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.Logics.ViewModels
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

        [DisplayName("Студент 1")]
        public string StudentOne { get; set; }

        [DisplayName("Студент 2")]
        public string StudentTwo { get; set; }

        [DisplayName("Студент 3")]
        public string StudentThree { get; set; }

        [DisplayName("Студент 4")]
        public string StudentFour { get; set; }

        [DisplayName("Студент 5")]
        public string StudentFive { get; set; }

        [DisplayName("Студент 6")]
        public string StudentSix { get; set; }
    }
}
