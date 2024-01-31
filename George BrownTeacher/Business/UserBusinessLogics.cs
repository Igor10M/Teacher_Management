using George_BrownTeacher.Bac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace George_BrownTeacher.Business
{
    internal class UserBusinessLogic
    {
        public void AddUser(int userID, string jobTitle, string password)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var newUser = new User
                    {
                        UserID = userID,
                        JobTitle = jobTitle,
                        Password = password
                    };

                    context.Users.Add(newUser);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error adding user: {ex.Message}");
            }
        }

        public void EditUser(int userID, string jobTitle, string password)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var userToEdit = context.Users.FirstOrDefault(u => u.UserID == userID);

                    if (userToEdit != null)
                    {
                        userToEdit.JobTitle = jobTitle;
                        userToEdit.Password = password;

                        context.SaveChanges();
                    }
                    else
                    {
                        throw new ApplicationException("User not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error editing user: {ex.Message}");
            }
        }

        public void DeleteUser(int userID)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var userToDelete = context.Users.FirstOrDefault(u => u.UserID == userID);

                    if (userToDelete != null)
                    {
                        context.Users.Remove(userToDelete);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new ApplicationException("User not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error deleting user: {ex.Message}");
            }
        }
    }
}
