using System.Collections.Generic;
using System.Linq;
using testProject.Models;

namespace testProject.DataAccess
{
    public static class MessageDataAccess
    {
        public static void SaveMessage(Message message, ApplicationContext context)
        {
            context.Messages.Add(message);
            context.SaveChanges();
        }

        public static List<Message> GetAllMessage(ApplicationContext context)
        {
            return context.Messages.ToList();
        }
    }
}
