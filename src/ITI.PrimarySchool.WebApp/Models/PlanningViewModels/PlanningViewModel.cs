using System;

namespace ITI.PrimarySchool.WebApp.Models.TeacherViewModels
{
    public class PlanningViewModel
    {
        public int PlanningId { get; set; }

        public DateTime Date { get; set; }

        public int TeacherId { get; set; }

        public string TeacherName { get; set; }
    }
}
