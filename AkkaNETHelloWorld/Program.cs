using System;

namespace AkkaNETHelloWorld
{
    using Akka.Actor;

    class Program
    {
        static void Main(string[] args)
        {
            // create a new actor system (a container for actors)
            var system = ActorSystem.Create("MySystem");

            // create actor and get a reference to it.
            var actor = system.ActorOf<OurActor>();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Type your message to send to the X actor.");
            Console.ResetColor();

            var userInput = Console.ReadLine();

            // send a message to the actor
            actor.Tell(new MessageToReturn(userInput));

            Console.ReadLine();
        }
    }

    public class OurActor : ReceiveActor
    {
        // This is our actor class
        // How this operates is we create an instance of the class as an actor. 
        // The constuctor establishes the Receive method from ReceiveActor.
        // We then trigger the Tell event and pass in an instance of MessageToReturn.
        // OurActor Receive method is then triggered - in this case it writes the message to the console.

        public OurActor()
        {
            Receive<MessageToReturn>(
                x =>
                    {
                        Console.WriteLine(x.Message);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("We passed the input to the actor and we got something back ^");
                        Console.ResetColor();
                    });
        }
    }

    public class MessageToReturn
    {
        public string Message { get; private set; }

        public MessageToReturn(string message)
        {
            // To make this interesting we are transforming the string to uppercase.
            Message = message.ToUpper();
        }
    }
}