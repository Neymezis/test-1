using System;
namespace Lab_3
{
    public interface IButton
    {
        void Paint();
    }
    public class WindowsButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Создана кнопка в стиле Windows");
        }
    }
    public class MacButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Создана кнопка в стиле Mac");
        }
    }
    public interface ICheckbox
    {
        void Paint();
    }
    public class WindowsCheckbox : ICheckbox
    {
        public void Paint()
        {
            Console.WriteLine("Создан чекбокс в стиле Windows");
        }
    }
    public class MacCheckbox : ICheckbox
    {
        public void Paint()
        {
            Console.WriteLine("Создан чекбокс в стиле Mac");
        }
    }
    public interface IGUIFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }
    public class WindowsFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new WindowsCheckbox();
        }
    }
    public class MacFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new MacButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new MacCheckbox();
        }
    }
    public class Application
    {
        private IButton _button;
        private ICheckbox _checkbox;
        public Application(IGUIFactory factory)
        {
            _button = factory.CreateButton();
            _checkbox = factory.CreateCheckbox();
        }
        public void Paint()
        {
            _button.Paint();
            _checkbox.Paint();
            Console.WriteLine();
        }
    }

}
class Program
{
    static void Main()
    {
        Application app1 = new Application(new WindowsFactory());
        app1.Paint();

        Application app2 = new Application(new MacFactory());
        app2.Paint();
    }
}