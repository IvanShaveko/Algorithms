using System.Collections.Generic;

namespace TuringMachine
{
    public static class TransitionTableGenerator
    {
        public static IEnumerable<Transition> AddToString() => new[]
        {
            new Transition(0, 'a', '*', HeadDirection.Right, 1),
            new Transition(0, 'b', 'b', HeadDirection.NoMove, State.Halt),
            new Transition(0, Head.Blank, Head.Blank, HeadDirection.NoMove, State.Halt),
            new Transition(1, 'a', 'a', HeadDirection.Right, 1),
            new Transition(1, 'b', 'b', HeadDirection.Right, 1),
            new Transition(1, '|', '|', HeadDirection.Right, 1),
            new Transition(1, Head.Blank, '|', HeadDirection.Left, 2),
            new Transition(2, '|', '|', HeadDirection.Left, 2),
            new Transition(2, 'b', 'b', HeadDirection.Left, 2),
            new Transition(2, 'a', 'a', HeadDirection.Left, 2),
            new Transition(2, '*', 'a', HeadDirection.Right, 0)
        };

        public static IEnumerable<Transition> PowerOfThree() => new[]
        {
            new Transition(0, '1', Head.Blank, HeadDirection.Right, 1),
            new Transition(1, '1', '1', HeadDirection.Left, 2), 
            new Transition(1, Head.Blank, Head.Blank, HeadDirection.NoMove, State.Halt), 
            new Transition(2, Head.Blank, '1', HeadDirection.NoMove, 3), 

            new Transition(3, '1', Head.Blank, HeadDirection.Right, 4),
            new Transition(3, Head.Blank, Head.Blank, HeadDirection.NoMove, State.Halt),
            new Transition(4, '1', '1', HeadDirection.Right, 4),
            new Transition(4, Head.Blank, Head.Blank, HeadDirection.Left, 5),
            new Transition(5, '1', Head.Blank, HeadDirection.Left, 6),
            new Transition(5, Head.Blank, Head.Blank, HeadDirection.Left, 7),
            new Transition(6, '1', Head.Blank, HeadDirection.Left, 8),
            new Transition(6, Head.Blank, Head.Blank, HeadDirection.Left, 7),
            new Transition(7, '1', Head.Blank, HeadDirection.Left, 7),
            new Transition(7, Head.Blank, '|', HeadDirection.Left, State.Halt),
            new Transition(8, '1', '1', HeadDirection.Left, 8),
            new Transition(8, Head.Blank, Head.Blank, HeadDirection.Right, 3)
        };
    }
}