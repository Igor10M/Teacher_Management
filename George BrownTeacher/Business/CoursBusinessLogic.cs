using George_BrownTeacher.Bac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace George_BrownTeacher.Business
{
    public class CourseBusinessLogic
    {
        public void AddCourse(string courseNumber, string courseTitle, int credits)
        {
            using (var context = new TeacherCourseDBEntities())
            {
                var newCourse = new Cours
                {
                    CourseNumber = courseNumber,
                    CourseTitle = courseTitle,
                    Credits = credits
                };

                context.Courses.Add(newCourse);
                context.SaveChanges();
            }
        }

        public void EditCourse(string courseNumber, string courseTitle, int credits)
        {
            using (var context = new TeacherCourseDBEntities())
            {
                var courseToEdit = context.Courses.FirstOrDefault(c => c.CourseNumber == courseNumber);

                if (courseToEdit != null)
                {
                    courseToEdit.CourseTitle = courseTitle;
                    courseToEdit.Credits = credits;

                    context.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("Course not found.");
                }
            }
        }

        public void DeleteCourse(string courseNumber)
        {
            using (var context = new TeacherCourseDBEntities())
            {
                var courseToDelete = context.Courses.FirstOrDefault(c => c.CourseNumber == courseNumber);

                if (courseToDelete != null)
                {
                    context.Courses.Remove(courseToDelete);
                    context.SaveChanges();
                }
                else
                {
                    throw new InvalidOperationException("Course not found.");
                }
            }
        }
    }
}

