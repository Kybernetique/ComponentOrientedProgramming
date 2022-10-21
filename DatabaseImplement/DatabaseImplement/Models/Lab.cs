using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.DatabaseImplement.Models
{
    // По лабораторной хранить следующую
    // информацию: тема лабораторной, ФИО студентов, последних сдавших
    // лабораторную(не более 6), дисциплина(список значений), вопросы
    // при приеме лабораторной(примерно 50-250 символов).
    public class Lab
    {
        public int Id { get; set; }

        [Required]
        public string Topic { get; set; }

        [Required]
        public string StudentOne { get; set; }

        [Required]
        public string StudentTwo { get; set; }

        [Required]
        public string StudentThree { get; set; }

        [Required]
        public string StudentFour { get; set; }

        [Required]
        public string StudentFive { get; set; }

        [Required]
        public string StudentSix { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Questions { get; set; }
    }
}
