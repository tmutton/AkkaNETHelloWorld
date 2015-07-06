namespace HelloWorld
{
    using System;

    using Akka.Actor;

    public class OurActor : ReceiveActor
    {
        public OurActor()
        {
            // when we tell this actor something it will write our message to the console
            this.Receive<string>(x => Console.WriteLine(x));
        }
    }
}