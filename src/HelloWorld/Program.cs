namespace HelloWorld
{
    using System;

    using Akka.Actor;

    class Program
    {
        static void Main(string[] args)
        {
            // create a new actor system (a container for actors)
            var system = ActorSystem.Create("MySystem");

            // create actor and get a reference to it.
            var actor = system.ActorOf<OurActor>();

            // create a message to send to the actor
            const string MessageToSendToActor = "Hello World!";

            // send our message to the actor
            actor.Tell(MessageToSendToActor);

            Console.ReadLine(); // keep console alive
        }
    }
}
