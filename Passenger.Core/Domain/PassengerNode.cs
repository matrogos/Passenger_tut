namespace Passenger.Core.Domain
{
    public class PassengerNode
    { 
        public Node Node { get; protected set; }
        public Pasenger Pasenger { get; protected set; }

        private PassengerNode()
        {
            
        }

        private PassengerNode(Pasenger pasenger, Node node)
        {
            Pasenger = pasenger;
            Node = node;
        }

        public static PassengerNode Create(Pasenger pasenger, Node node)
            => new PassengerNode(pasenger, node);
    }
}