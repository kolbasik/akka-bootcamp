using System;
using Akka.Actor;

namespace WinTail
{
    internal sealed class ConsoleReaderActor : UntypedActor
    {
        public const string StartCommand = "start";
        public const string ExitCommand = "exit";

        private readonly IActorRef _validationActor;

        public ConsoleReaderActor(IActorRef validationActor)
        {
            _validationActor = validationActor;
        }

        protected override void OnReceive(object message)
        {
            if (string.Equals(message as string, StartCommand, StringComparison.OrdinalIgnoreCase))
            {
                PrintInstructions();
            }

            var command = Console.ReadLine();
            if (!string.IsNullOrEmpty(command) && string.Equals(command, ExitCommand, StringComparison.OrdinalIgnoreCase))
            {
                // if user typed ExitCommand, shut down the entire actor system (allows the process to exit)
                Context.System.Shutdown();
                return;
            }

            _validationActor.Tell(command);

        }

        private static void PrintInstructions()
        {
            Console.WriteLine("Write whatever you want into the console!");
            Console.WriteLine("Some entries will pass validation, and some won't...\n");
            Console.WriteLine("Type 'exit' to quit this application at any time.\n");
        }
    }
}