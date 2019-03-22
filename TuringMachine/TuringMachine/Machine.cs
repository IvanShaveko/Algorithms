using System;
using System.Collections.Generic;
using System.Linq;

namespace TuringMachine
{
    public class Machine
    {
        public Machine(int state, Head head, IEnumerable<Transition> transitionTable)
        {
            State = state;
            Head = head ?? throw new ArgumentNullException(nameof(head));
            TransitionTable = transitionTable ?? throw new ArgumentNullException(nameof(transitionTable));
        }

        public int State { get; }

        public Head Head { get; }

        public IEnumerable<Transition> TransitionTable { get; }

        public Machine Step()
        {
            if (State < 0) return this;

            return
                TransitionTable
                    .Where(t => t.InitialState == State && t.Read == Head.Read())
                    .Select(t => new Machine(t.NextState, Head.Write(t.Write).Move(t.HeadDirection), TransitionTable))
                    .First();
        }

        public string Run()
        {
            var machine = this;

            while (machine.State >= 0)
            {
                machine = machine.Step();
            }

            return new string(machine.Head.Tape.ToArray());
        }
    }
}