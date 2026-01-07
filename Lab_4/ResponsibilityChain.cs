using System;
namespace Lab_4
{
    public enum RequestType
    {
        TypeA,
        TypeB
    }
    public class Request
    {
        private RequestType type;

        public Request(RequestType type)
        {
            this.type = type;
        }

        public RequestType GetType()
        {
            return type;
        }
    }
    public interface IHandler
    {
        void HandleRequest(Request request);
        void SetNextHandler(IHandler nextHandler);
    }
    public class ConcreteHandlerA : IHandler
    {
        private IHandler nextHandler;

        public void HandleRequest(Request request)
        {
            if (request.GetType() == RequestType.TypeA)
            {
                Console.WriteLine("ConcreteHandlerA обработал запрос");
            }
            else if (nextHandler != null)
            {
                nextHandler.HandleRequest(request);
            }
        }

        public void SetNextHandler(IHandler nextHandler)
        {
            this.nextHandler = nextHandler;
        }
    }
    public class ConcreteHandlerB : IHandler
    {
        private IHandler nextHandler;

        public void HandleRequest(Request request)
        {
            if (request.GetType() == RequestType.TypeB)
            {
                Console.WriteLine("ConcreteHandlerB обработал запрос");
            }
            else if (nextHandler != null)
            {
                nextHandler.HandleRequest(request);
            }
        }
        public void SetNextHandler(IHandler nextHandler)
        {
            this.nextHandler = nextHandler;
        }
    }
}
class Program
{
    static void Main()
    {
        IHandler handlerA = new ConcreteHandlerA();
        IHandler handlerB = new ConcreteHandlerB();

        handlerA.SetNextHandler(handlerB);

        Request requestA = new Request(RequestType.TypeA);
        Request requestB = new Request(RequestType.TypeB);

        handlerA.HandleRequest(requestA); 
        handlerA.HandleRequest(requestB); 
    }
}
