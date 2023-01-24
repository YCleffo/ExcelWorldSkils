using ExcelWorldSkils.Model;
using ExcelWorldSkils.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelWorldSkils.ViewModel
{
    public class StudentViewModel
    {
        static Core db = new Core();
        public static bool AddStudent(string firstName, string lastName, string patronomicName,int idProf, int idFormTime, int idYear, int idGroup)
        {
            Students newStudent = new Students()
            {
                FiestName = firstName,
                LastName = lastName,
                PatronomicName = patronomicName,
                IdProfession = idProf,
                IdFormTime = idFormTime,
                IdYearAdd = idYear,
                IdGroup = idGroup
            };

            db.context.Students.Add(newStudent);
            if (db.context.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
