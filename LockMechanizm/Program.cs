using System;

namespace LockMechanizm
{
    internal class Program
    {
        delegate void AsyncThreadMaker();
        static void Main(string[] args)
        {
            string res = "";
            while (true) { 
            Console.WriteLine("Please Select");
            Console.WriteLine("Get Instanse Without Lock (Wrong) (1) ");
            Console.WriteLine("Get Instanse With Lock (2)");
             res=  Console.ReadLine();
                if (res=="1"|| res == "2") 
                    break;

            }
            if (res=="1")
                ShowWithoutLock();
            if (res == "2")
                ShowWithLock();
            Console.ReadLine();
        }

        static void ShowWithoutLock() {
            AsyncThreadMaker func=() => {
                SingletonEntityWithoutLock e =  SingletonEntityWithoutLock.GetInstance;
            };

            for (int i = 0; i < 30; i++)
            {
                func.BeginInvoke(new AsyncCallback((x) => { }), new object());
            }
            



        }

        static void ShowWithLock()
        {
            AsyncThreadMaker func = () => {
                SingletonEntity e = SingletonEntity.GetInstance;
            };

            for (int i = 0; i < 30; i++)
            {
                func.BeginInvoke(new AsyncCallback((x) => { }), new object());
            }


        }
    }


    public class SingletonEntity {
        static private SingletonEntity entity;

        static object LockFlag = new object();

        static public SingletonEntity GetInstance
        {
            get
            {
                lock (LockFlag) {
                    if (entity == null) { 
                        entity = new SingletonEntity();
                        Console.WriteLine("Object is Generated");
                    }
                        Console.WriteLine("Existing Object Rotated");
                }
                return entity;
            }
        
        }

    }


    public class SingletonEntityWithoutLock
    {
        static private SingletonEntityWithoutLock entity;

        static public SingletonEntityWithoutLock GetInstance
        {
            get
            {
                    if (entity == null)
                    {
                        entity = new SingletonEntityWithoutLock();
                        Console.WriteLine("Object is Generated");
                    } else 
                        Console.WriteLine("Existing Object Rotated");
                
                return entity;
            }

        }

    }

}
