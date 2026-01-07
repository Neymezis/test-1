using System;
namespace Lab_4
{
    public interface IDatabase
    {
        void Query(string sql);
    }

    public class RealDatabase : IDatabase
    {
        public void Query(string sql)
        {
            Console.WriteLine($"Выполняю запрос: {sql}");
        }
    }

    public class DatabaseProxy : IDatabase
    {
        private RealDatabase realDatabase;
        private bool hasAccess;

        public DatabaseProxy(bool hasAccess)
        {
            this.realDatabase = new RealDatabase();
            this.hasAccess = hasAccess;
        }

        public void Query(string sql)
        {
            if (hasAccess)
            {
                realDatabase.Query(sql);
            }
            else
            {
                Console.WriteLine("Доступ запрещен. Запрос не может быть выполнен.");
            }
        }
    }
}
class Program
{
    static void Main()
    {
        IDatabase userDb = new DatabaseProxy(false);
        IDatabase adminDb = new DatabaseProxy(true);

        userDb.Query("SELECT * FROM users");
        adminDb.Query("SELECT * FROM users");
    }
}
