using George_BrownTeacher.Bac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace George_BrownTeacher.Business
{
    public class UserAuthentication
    {
        public bool AuthenticateUser(string userID, string password)
        {
            try
            {
                using (var context = new TeacherCourseDBEntities())
                {
                    var selectUserQuery = from user in context.Users
                                          where user.UserID.ToString() == userID &&
                                                user.Password == password
                                          select user;
                    return selectUserQuery.Any();
                }
            }
            catch (Exception ex)
            {
                // Handle exception or log it
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
