using System.IO;
using Akka.Actor;

namespace WinTail
{
    internal sealed class FileValidatorActor : UntypedActor
    {
        private readonly IActorRef _consoleWriterActor;
        private readonly IActorRef _tailCoordinatorActor;

        public FileValidatorActor(IActorRef consoleWriterActor, IActorRef tailCoordinatorActor)
        {
            _consoleWriterActor = consoleWriterActor;
            _tailCoordinatorActor = tailCoordinatorActor;
        }

        protected override void OnReceive(object message)
        {
            var command = message as string;
            if (string.IsNullOrEmpty(command))
            {
                // signal that the user needs to supply an input
                _consoleWriterActor.Tell(new Messages.NullInputError("No input received."));

                // tell sender to continue doing its thing
                // (whatever that may be, this actor doesn't care)
                Sender.Tell(new Messages.ContinueProcessing());
            }
            else
            {
                var valid = File.Exists(command);
                if (valid)
                {
                    // signal successful input
                    _consoleWriterActor.Tell(
                        new Messages.InputSuccess(string.Format("Starting processing for {0}", command)));

                    // start coordinator
                    _tailCoordinatorActor.Tell(new TailCoordinatorActor.StartTail(command, _consoleWriterActor));
                }
                else
                {
                    _consoleWriterActor.Tell(
                        new Messages.ValidationError("Invalid: input had odd number of characters."));

                    // tell sender to continue doing its thing
                    // (whatever that may be, this actor doesn't care)
                    Sender.Tell(new Messages.ContinueProcessing());
                }
            }
        }
    }
}