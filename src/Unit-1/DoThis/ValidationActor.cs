using System.IO;
using Akka.Actor;

namespace WinTail
{
    internal sealed class FileValidatorActor : UntypedActor
    {
        private readonly IActorRef _consoleWriterActor;

        public FileValidatorActor(IActorRef consoleWriterActor)
        {
            _consoleWriterActor = consoleWriterActor;
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
                    Context.ActorSelection("akka://MyActorSystem/user/tailCoordinatorActor")
                        .Tell(new TailCoordinatorActor.StartTail(command, _consoleWriterActor));
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