using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Logics.ViewModels
{
    public class LabViewModel
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [DisplayName("Тема")]
        public string Topic { get; set; }

        [DisplayName("Студент #1")]
        public string StudentOne { get; set; }

        [DisplayName("Студент #2")]
        public string StudentTwo { get; set; }

        [DisplayName("Студент #3")]
        public string StudentThree { get; set; }

        [DisplayName("Студент #4")]
        public string StudentFour { get; set; }

        [DisplayName("Студент #5")]
        public string StudentFive { get; set; }

        [DisplayName("Студент #6")]
        public string StudentSix { get; set; }

        [DisplayName("Дисциплина")]
        public string Subject { get; set; }

        [DisplayName("Вопросы")]
        public string Questions { get; set; }
    }
}
