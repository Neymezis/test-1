using System;

namespace Lab_3
{
    public class Singleton
    {
        private static Singleton _instance;
        private int _score = 0;
        
        private Singleton()
        {
            Console.WriteLine("Создан экземпляр");
        }
        
        public static Singleton Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }
        }
        
        public void AddPoints(int points)
        {
            _score += points;
            Console.WriteLine($"+{points} очков! Всего: {_score}");
        }
    }
    
    class Program
    {
        static void Main()
        {
      
            Singleton s1 = Singleton.Instance;
            Singleton s2 = Singleton.Instance;
            
            s1.AddPoints(10);
            s2.AddPoints(5);
        }
    }
} 
