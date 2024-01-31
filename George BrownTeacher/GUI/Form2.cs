using George_BrownTeacher.Bac;
using George_BrownTeacher.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace George_BrownTeacher.GUI
{
    public partial class Form2 : Form
    {
        private UserBusinessLogic userLogic;
        private TeacherBusinessLogic teacherLogic;
        private CourseBusinessLogic courseLogic;
        private AssignmentBusinessLogic assignmentLogic;

        public Form2()
        {
            InitializeComponent();
            userLogic = new UserBusinessLogic();
            teacherLogic = new TeacherBusinessLogic();
            courseLogic = new CourseBusinessLogic();
            assignmentLogic = new AssignmentBusinessLogic();
            ListCourse();
            ListCourseAssign();
            ListTeacher();
            ListUser();
        }
        private void ListUser()
        {
            using (var context = new TeacherCourseDBEntities())
            {
                var listUser = context.Users.Select(ep => new
                {
                    ep.UserID,
                    ep.Password,
                    ep.JobTitle
                }).ToList();

                dataGridViewUser.DataSource = listUser;
            }
        }
        private void ListTeacher()
        {
            using (var context = new TeacherCourseDBEntities())
            {
                var listTeacher = context.Teachers.Select(ep => new
                {
                    ep.TeacherId,
                    ep.FirstName,
                    ep.LastName,
                    ep.Email
                }).ToList();

                dataGridViewTeacher.DataSource = listTeacher;
            }
        }
        private void ListCourse()
        {
            using (var context = new TeacherCourseDBEntities())
            {
                var listCourse = context.Courses.Select(ep => new
                {
                    ep.CourseNumber,
                    ep.CourseTitle,
                    ep.Credits
                }).ToList();

                dataGridViewCourse.DataSource = listCourse;
            }
        }
        private void ListCourseAssign()
        {
            using (var context = new TeacherCourseDBEntities())
            {
                var listCourseAssign = context.TeacherCourses.Select(ep => new
                {
                    ep.RegistrationId,
                    ep.TeacherId,
                    ep.CourseNumber
                }).ToList();

                dataGridViewCourseAssign.DataSource = listCourseAssign;
            }
        }

        private void AddUserBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int userID = int.Parse(UserIDtextBox.Text);
                string jobTitle = JobIdtextBox.Text;
                string password = PassTextBox.Text;

                userLogic.AddUser(userID, jobTitle, password);

                ListUser(); // Refresh user list
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditUserBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int userID = int.Parse(UserIDtextBox.Text);
                string jobTitle = JobIdtextBox.Text;
                string password = PassTextBox.Text;

                userLogic.EditUser(userID, jobTitle, password);

                ListUser(); // Refresh user list
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteUserBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int userID = int.Parse(UserIDtextBox.Text);

                userLogic.DeleteUser(userID);

                ListUser(); // Refresh user list
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddTeacherBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int teacherID = int.Parse(TeacherIDtextBox.Text);
                string firstName = FnametextBox.Text;
                string lastName = LnametextBox.Text;
                string email = EmailtextBox.Text;

                teacherLogic.AddTeacher(teacherID, firstName, lastName, email);

                ListTeacher(); // Refresh teacher list
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditTeacherBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int teacherID = int.Parse(TeacherIDtextBox.Text);
                string firstName = FnametextBox.Text;
                string lastName = LnametextBox.Text;
                string email = EmailtextBox.Text;

                teacherLogic.EditTeacher(teacherID, firstName, lastName, email);

                ListTeacher(); // Refresh teacher list
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteTeacherBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int teacherID = int.Parse(TeacherIDtextBox.Text);

                teacherLogic.DeleteTeacher(teacherID);

                ListTeacher(); // Refresh teacher list
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddCourseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string courseNumber = CourseNumTextBox.Text;
                string courseTitle = CourseTitleTextBox.Text;
                int credits = Convert.ToInt32(CreditTextBox.Text);

                courseLogic.AddCourse(courseNumber, courseTitle, credits);

                ListCourse(); // Refresh course list
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditCourseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string courseNumber = CourseNumTextBox.Text;
                string courseTitle = CourseTitleTextBox.Text;
                int credits = int.Parse(CreditTextBox.Text);

                courseLogic.EditCourse(courseNumber, courseTitle, credits);

                ListCourse(); // Refresh course list
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteCourseBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string courseNumber = CourseNumTextBox.Text;

                courseLogic.DeleteCourse(courseNumber);

                ListCourse(); // Refresh course list
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AssignTeacherBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int registrationId = Convert.ToInt32(RegisIdTextBox.Text);
                int teacherId = Convert.ToInt32(teacherIdtxt.Text);
                string courseNumber = CorseNumbertxt.Text;

                assignmentLogic.AssignTeacherToCourse(registrationId, teacherId, courseNumber);

                ListCourseAssign(); // Refresh assignment list
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditAssignBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int registrationId = Convert.ToInt32(RegisIdTextBox.Text);
                int teacherId = Convert.ToInt32(teacherIdtxt.Text);
                string courseNumber = CorseNumbertxt.Text;

                assignmentLogic.EditAssignment(registrationId, teacherId, courseNumber);

                ListCourseAssign(); // Refresh assignment list
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteAssignBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int registrationId = int.Parse(RegisIdTextBox.Text);

                assignmentLogic.DeleteAssignment(registrationId);

                ListCourseAssign(); // Refresh assignment list
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
