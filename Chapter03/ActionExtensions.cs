using System;
using static Chapter03.F;
using Unit = System.ValueTuple;

namespace Chapter03
{
    public static partial class F
    {
        public static Unit Unit() => default(Unit);
    }
    public static class ActionExtensions
    {
        public static Func<Unit> ToFunc(this Action action)
            => () => { action(); return Unit(); };
    }
}
