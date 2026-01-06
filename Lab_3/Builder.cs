using System;
namespace Lab_3
{
    public class Pizza
    {
        public string Dough { get; set; }
        public string Sauce { get; set; }
        public string Topping { get; set; }

        public override string ToString()
        {
            return $"Пицца: тесто='{Dough}', соус='{Sauce}', начинка='{Topping}'";
        }
    }
    public interface IPizzaBuilder
    {
        void BuildDough();
        void BuildSauce();
        void BuildTopping();
        Pizza GetResult();
    }
    public class HawaiianPizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza;

        public HawaiianPizzaBuilder()
        {
            _pizza = new Pizza();
        }
        public void BuildDough()
        {
            _pizza.Dough = "тонкое";
        }
        public void BuildSauce()
        {
            _pizza.Sauce = "томатный";
        }
        public void BuildTopping()
        {
            _pizza.Topping = "ветчина + ананасы";
        }
        public Pizza GetResult()
        {
            return _pizza;
        }
    }

    public class PizzaDirector
    {
        private IPizzaBuilder _builder;

        public PizzaDirector(IPizzaBuilder builder)
        {
            _builder = builder;
        }

        public void ConstructPizza()
        {
            _builder.BuildDough();
            _builder.BuildSauce();
            _builder.BuildTopping();
        }
    }

}
class Program
{
    static void Main()
    {
        IPizzaBuilder builder = new HawaiianPizzaBuilder();

        PizzaDirector director = new PizzaDirector(builder);
        director.ConstructPizza();

        Pizza pizza = builder.GetResult();

        Console.WriteLine("Создана пицца:");
        Console.WriteLine(pizza);
    }
}