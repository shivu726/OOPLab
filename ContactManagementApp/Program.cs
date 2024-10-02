using ContactManagementApp.Models;

namespace ContactManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (DbFirstDemoContext dbContext = new DbFirstDemoContext())
            {
                var editToContact = dbContext.Contacts.Find(1);

                if(editToContact !=null)
                {
                    editToContact.Name = "Shashi";
                    dbContext.Update(editToContact);
                    dbContext.SaveChanges();
                }
            }
        }

        private static void AddContact()
        {
            using (DbFirstDemoContext dbContext = new DbFirstDemoContext())
            {
                Contact contact = new Contact()
                {
                    Name = "Shivu",
                    City = "Bangalore",
                    Email = "shiv@gmail.com",
                    Mobile = "9000190001",
                    Country = "India"
                };

                dbContext.Add(contact);
                dbContext.SaveChanges();
            }
        }
    }
}
