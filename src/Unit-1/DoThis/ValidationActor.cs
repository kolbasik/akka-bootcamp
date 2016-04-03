using Akka.Actor;

namespace WinTail
{
    internal sealed class ValidationActor : UntypedActor
    {
        private readonly IActorRef _consoleWriterActor;

        public ValidationActor(IActorRef consoleWriterActor)
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
            }
            else
            {
                var valid = command.Length%2 == 0;
                if (valid)
                {
                    _consoleWriterActor.Tell(new Messages.InputSuccess("Thank you! Message was valid."));
                }
                else
                {
                    _consoleWriterActor.Tell(new Messages.ValidationError("Invalid: input had odd number of characters."));
                }
            }

            // tell sender to continue doing its thing
            // (whatever that may be, this actor doesn't care)
            Sender.Tell(new Messages.ContinueProcessing());
        }
    }
}