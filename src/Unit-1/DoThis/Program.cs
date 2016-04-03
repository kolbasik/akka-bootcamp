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

            Props consoleWriterProps = Props.Create<ConsoleWriterActor>();
            IActorRef consoleWriterActor = myActorSystem.ActorOf(consoleWriterProps, "consoleWriterActor");

            Props validationActorProps = Props.Create(() => new ValidationActor(consoleWriterActor));
            IActorRef validationActor = myActorSystem.ActorOf(validationActorProps, "validationActor");

            Props consoleReaderProps = Props.Create<ConsoleReaderActor>(validationActor);
            IActorRef consoleReaderActor = myActorSystem.ActorOf(consoleReaderProps, "consoleReaderActor");

            // tell console reader to begin
            consoleReaderActor.Tell(ConsoleReaderActor.StartCommand);

            // blocks the main thread from exiting until the actor system is shut down
            myActorSystem.AwaitTermination();
        }
    }
}