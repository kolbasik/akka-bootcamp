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

            var consoleWriterProps = Props.Create<ConsoleWriterActor>();
            var consoleWriterActor = myActorSystem.ActorOf(consoleWriterProps, "consoleWriterActor");

            var tailCoordinatorProps = Props.Create(() => new TailCoordinatorActor());
            var tailCoordinatorActor = myActorSystem.ActorOf(tailCoordinatorProps, "tailCoordinatorActor");

            var validationActorProps =
                Props.Create(() => new FileValidatorActor(consoleWriterActor, tailCoordinatorActor));
            var validationActor = myActorSystem.ActorOf(validationActorProps, "validationActor");

            var consoleReaderProps = Props.Create<ConsoleReaderActor>(validationActor);
            var consoleReaderActor = myActorSystem.ActorOf(consoleReaderProps, "consoleReaderActor");

            // tell console reader to begin
            consoleReaderActor.Tell(ConsoleReaderActor.StartCommand);

            // blocks the main thread from exiting until the actor system is shut down
            myActorSystem.AwaitTermination();
        }
    }
}