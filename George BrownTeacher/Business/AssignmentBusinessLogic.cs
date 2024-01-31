using George_BrownTeacher.Bac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace George_BrownTeacher.Business
{
    public class AssignmentBusinessLogic
    {
        private readonly TeacherCourseDBEntities dbContext;

        public AssignmentBusinessLogic()
        {
            dbContext = new TeacherCourseDBEntities();
        }

        public void AssignTeacherToCourse(int registrationId, int teacherId, string courseNumber)
        {
            var existingAssignment = dbContext.TeacherCourses.FirstOrDefault(tc => tc.RegistrationId == registrationId);
            if (existingAssignment != null)
            {
                throw new InvalidOperationException("Registration ID already exists.");
            }

            var newAssignment = new TeacherCours
            {
                RegistrationId = registrationId,
                TeacherId = teacherId,
                CourseNumber = courseNumber
            };

            dbContext.TeacherCourses.Add(newAssignment);
            dbContext.SaveChanges();
        }

        public void EditAssignment(int registrationId, int teacherId, string courseNumber)
        {
            var assignment = dbContext.TeacherCourses.FirstOrDefault(tc => tc.RegistrationId == registrationId);

            if (assignment != null)
            {
                assignment.TeacherId = teacherId;
                assignment.CourseNumber = courseNumber;

                dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Assignment not found.");
            }
        }

        public void DeleteAssignment(int registrationId)
        {
            var assignment = dbContext.TeacherCourses.FirstOrDefault(tc => tc.RegistrationId == registrationId);

            if (assignment != null)
            {
                dbContext.TeacherCourses.Remove(assignment);
                dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Assignment not found.");
            }
        }
    }
}

