using George_BrownTeacher.Bac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace George_BrownTeacher.Business
{
    internal class TeacherBusinessLogic
    {
        public void AddTeacher(int teacherID, string firstName, string lastName, string email)
        {
            using (var context = new TeacherCourseDBEntities())
            {
                var newTeacher = new Teacher
                {
                    TeacherId = teacherID,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email
                };

                context.Teachers.Add(newTeacher);
                context.SaveChanges();
            }
        }

        public void EditTeacher(int teacherID, string firstName, string lastName, string email)
        {
            using (var context = new TeacherCourseDBEntities())
            {
                var teacherToEdit = context.Teachers.FirstOrDefault(t => t.TeacherId == teacherID);

                if (teacherToEdit != null)
                {
                    teacherToEdit.FirstName = firstName;
                    teacherToEdit.LastName = lastName;
                    teacherToEdit.Email = email;

                    context.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("Teacher not found.");
                }
            }
        }

        public void DeleteTeacher(int teacherID)
        {
            using (var context = new TeacherCourseDBEntities())
            {
                var teacherToDelete = context.Teachers.FirstOrDefault(t => t.TeacherId == teacherID);

                if (teacherToDelete != null)
                {
                    context.Teachers.Remove(teacherToDelete);
                    context.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("Teacher not found.");
                }
            }
        }
    }
}
