using System.Runtime.InteropServices;

//namespace FactoryPattern
//{


//    public interface INotificationSystem
//    {
//        void Message();
//    }
//    public class SMS : INotificationSystem
//    {
//        public void Message()
//        {
//            Console.WriteLine("Notification form SMS");
//        }
//    }

//    public class Email : INotificationSystem
//    {
//        public void Message()
//        {
//            Console.WriteLine("Notification from Email");
//        }
//    }

//    public class PushMessage : INotificationSystem
//    {
//        public void Message()
//        {
//            Console.WriteLine("Notification from PushMessage");
//        }
//    }

//    public class NotificationFactory
//    {
//        public INotificationSystem CreateNotification(string s)
//        {
//            switch (s.ToLower())
//            {
//                case "sms":
//                    return new SMS();
//                case "email":
//                    return new Email();
//                case "pushmessage":
//                    return new PushMessage();

//                default:
//                    throw new ArgumentException("Invalid notification type", nameof(s));
//            }
//        }
//    }
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            NotificationFactory Notify = new NotificationFactory();
//            INotificationSystem SMSNotification = Notify.CreateNotification("SMS");
//            SMSNotification.Message();

//            INotificationSystem EmailNotification = Notify.CreateNotification("Email");
//            EmailNotification.Message();

//            INotificationSystem PushNotification = Notify.CreateNotification("Pushmessage");
//            PushNotification.Message();

//        }
//    }
//}

using System.Collections.Generic;
using System.Collections;
using System;
using System.Linq;
using System.Reflection;

namespace FactoryPattern
{


    public interface INotificationSystem
    {
        void Message();
    }
    public class SMS : INotificationSystem
    {
        public void Message()
        {
            Console.WriteLine("Notification form SMS");
        }
    }

    public class Email : INotificationSystem
    {
        public void Message()
        {
            Console.WriteLine("Notification from Email");
        }
    }

    public class PushMessage : INotificationSystem
    {
        public void Message()
        {
            Console.WriteLine("Notification from PushMessage");
        }
    }

    public class NotificationFactory
    {
        private Dictionary<string, Type> ListOfNotifiers = new Dictionary<string, Type>();

        public NotificationFactory()
        {
            RegisterNotification("SMS", typeof(SMS));
            RegisterNotification("Email", typeof (Email));
            RegisterNotification("PushMessage", typeof(PushMessage));
        }

	public void RegisterNotification(string notifier, Type type)
        {
            if (!ListOfNotifiers.ContainsKey(notifier))
            {
                ListOfNotifiers.Add(notifier,type);
            }

            else
            {
                Console.WriteLine("Already Exists");
            }
        }


        public INotificationSystem CreateNotification(string s)
        {
            if (ListOfNotifiers.ContainsKey(s))
            {
                Type type = ListOfNotifiers[s];
                return (INotificationSystem)Activator.CreateInstance(type);
            }

            else
            {
                throw new ArgumentException($"{s} is not registered");
            }
        }
    }

    class Custom : INotificationSystem
    {
        public void Message()
        {
            Console.WriteLine("Notification from Custom");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            NotificationFactory Notify = new NotificationFactory();
            INotificationSystem SMSNotification = Notify.CreateNotification("SMS");
            SMSNotification.Message();

            INotificationSystem EmailNotification = Notify.CreateNotification("Email");
            EmailNotification.Message();

            INotificationSystem PushNotification = Notify.CreateNotification("PushMessage");
            PushNotification.Message();

            Notify.RegisterNotification("Custom", typeof(Custom));

        INotificationSystem Custom = Notify.CreateNotification("Custom");
            Custom.Message();

        }
    }
}
