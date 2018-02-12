using System;
using System.Collections.Generic;
using System.Linq;

namespace Passenger.Core.Domain
{
    public class DailyRoute
    {
        private ISet<PassengerNode> _passengerNodes = new HashSet<PassengerNode>();
        public Guid Id { get; protected set; }
        public Route Route { get; protected set; }
        public IEnumerable<PassengerNode> PassengerNodes { get; protected set; }

        protected DailyRoute()
        {
            Id = Guid.NewGuid();
        }
        public void AddPassengerNode(Pasenger pasenger, Node node)
        {
            var passengerNode = GetPassengerNode(pasenger);
            if (passengerNode != null)
            {
                throw new InvalidOperationException("Passenger has a node");
            }
            _passengerNodes.Add(PassengerNode.Create(pasenger, node));
        }

         public void RemovePassengerNode(Pasenger pasenger)
        {
            var passengerNode = GetPassengerNode(pasenger);
            if (passengerNode == null)
            {
                throw new InvalidOperationException("Passenger does not have a node");
            }
            _passengerNodes.Remove(passengerNode);
        }

        private PassengerNode GetPassengerNode(Pasenger pasenger)
        {
            return  _passengerNodes.SingleOrDefault(p=> p.Pasenger.UserId == pasenger.UserId);
        }
    }
}