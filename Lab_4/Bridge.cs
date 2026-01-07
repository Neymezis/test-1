using System;
namespace Lab_4
{
    public interface IDevice
    {
        void Print(string data);
    }
    public class Monitor : IDevice
    {
        public void Print(string data)
        {
            Console.WriteLine($"Выводим на монитор: {data}");
        }
    }
    public class Printer : IDevice
    {
        public void Print(string data)
        {
            Console.WriteLine($"Печатаем на бумаге: {data}");
        }
    }
    public abstract class Output
    {
        protected IDevice device;

        public Output(IDevice device)
        {
            this.device = device;
        }

        public abstract void Render(string data);
    }
    public class TextOutput : Output
    {
        public TextOutput(IDevice device) : base(device) { }

        public override void Render(string data)
        {
            device.Print($"Текст: {data}");
        }
    }
    public class ImageOutput : Output
    {
        public ImageOutput(IDevice device) : base(device) { }

        public override void Render(string data)
        {
            device.Print($"Изображение: [Данные: {data}]");
        }
    }
}
class Program
{
    static void Main()
    {
        IDevice monitor = new Monitor();
        IDevice printer = new Printer();

        Console.WriteLine("1. Текст на мониторе:");
        Output textOnMonitor = new TextOutput(monitor);
        textOnMonitor.Render("Привет, мир!");

        Console.WriteLine("\n2. Текст на принтере:");
        Output textOnPrinter = new TextOutput(printer);
        textOnPrinter.Render("Привет, мир!");

        Console.WriteLine("\n3. Изображение на мониторе:");
        Output imageOnMonitor = new ImageOutput(monitor);
        imageOnMonitor.Render("101010101");

        Console.WriteLine("\n4. Изображение на принтере:");
        Output imageOnPrinter = new ImageOutput(printer);
        imageOnPrinter.Render("111000111");
    }
}