using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory.DatabaseLayer.Context;
using Factory.DatabaseLayer.Models;
namespace Factory.Services
{
    public class UserServices
    {
        public readonly OnlineAuctionDbContext dbContext;
        public UserServices(OnlineAuctionDbContext dbContext)
        {
          this.dbContext = dbContext;
        }  
        public  List<User> GetAllUser()
        {
            return dbContext.Users.ToList();
        }
        public User GetUser(int id)
        {
            User temp = dbContext.Users.FirstOrDefault(x => x.UserId == id);
            if (temp==null)
            {
                return null;
            }
            else
            {
                return temp;
            }
            
        }
        public void AddUser(User user)
        {
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
        }

        public void UpdateUser(User user, int id)
        {
            var userTemp = dbContext.Users.FirstOrDefault(u => u.UserId == id);

            if (userTemp != null)
            {
                // Update properties
                userTemp.Name = user.Name;
                userTemp.Email = user.Email;
                userTemp.Reviews = user.Reviews;
                userTemp.Status = user.Status;
                userTemp.PhoneNumber = user.PhoneNumber;

                // Save changes to the database
                dbContext.SaveChanges();
            }
            else
            {
                // Handle the case where the user is not found
                throw new Exception($"User with ID {id} not found.");
            }
        }

        public void DeleteUser(int id)
        { 
            var userToDelete = dbContext.Users.FirstOrDefault(u => u.UserId == id);

            if (userToDelete != null)
            {
                // Mark the user for deletion
                dbContext.Users.Remove(userToDelete);

                // Apply the changes to the database
                dbContext.SaveChanges();
            }
            else
            {
                // Handle case where the user doesn't exist
                throw new Exception($"User with ID {id} not found.");
            }
        }

    }
}
