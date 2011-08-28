using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gr1d.Api.Agent;
using Gr1d.Api.Skill;
using Gr1d.Api.Deck;

[assembly: CLSCompliant(true)]
namespace MyAgents {
    [CLSCompliant(true)]
    public class MyRobot : IEngineer1 {
        IDeck _deck;
        public void Initialise(Gr1d.Api.Deck.IDeck deck) {
            _deck = deck;
            _deck.Trace("Ready for work", TraceType.Information);
        }

        public void OnArrived(IAgentInfo arriver, IAgentUpdateInfo agentUpdate) {
        }

        public void OnAttacked(IAgentInfo attacker, IAgentUpdateInfo agentUpdate) {
        }

        public void Tick(IAgentUpdateInfo agentUpdate) {
            if (agentUpdate.Node.IsClaimable) {
                var result = this.Claim(agentUpdate.Node);
                _deck.Trace(result.Message, TraceType.Information);
            } else {
                var result = this.Move(agentUpdate.Node.Exits.First().Value);
                _deck.Trace(result.Message, TraceType.Information);
            }
        }
    }
}
