using System;
using Akka.Actor;

namespace WinTail
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // initialize MyActorSystem
            var myActorSystem = ActorSystem.Create("MyActorSystem");

            // time to make your first actors!
            // make consoleWriterActor using these props: Props.Create(() => new ConsoleWriterActor())
            // make consoleReaderActor using these props: Props.Create(() => new ConsoleReaderActor(consoleWriterActor))

            var consoleWriterActor = myActorSystem.ActorOf(Props.Create(() =>
                new ConsoleWriterActor()));
            var consoleReaderActor = myActorSystem.ActorOf(Props.Create(() =>
                new ConsoleReaderActor(consoleWriterActor)));

            // tell console reader to begin
            consoleReaderActor.Tell(ConsoleReaderActor.StartCommand);

            // blocks the main thread from exiting until the actor system is shut down
            myActorSystem.AwaitTermination();
        }

        
    }
}