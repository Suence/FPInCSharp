using LaYumba.Functional;
using OptionT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LaYumba.Functional.F;

namespace Option
{
    public struct None
    {
        internal static readonly None Default = new None();
    }

    public struct Some<T>
    {
        internal T Value { get; }
        internal Some(T value)
        {
            if (value == null)
                throw new ArgumentNullException();

            Value = value;
        }
    }

}

public static class Client
{
    public static Option<T> LookUp<K, T>(
        this IDictionary<K, T> dict, K key)
        => dict.TryGetValue(key, out T value)
           ? Some(value)
           : None;

    public static string Greet(Option<string> greetee)
        => greetee.Match(
            None: () => "Sorry, Who?",
            Some: name => $"Hello, {name}");
}

namespace OptionT
{
    public struct Option<T>
    {
        private readonly bool _isSome;
        [Newtonsoft.Json.JsonProperty]
        private readonly T _value;

        [Newtonsoft.Json.JsonConstructor]
        private Option(T value)
        {
            _isSome = true;
            _value = value;
        }

        public static implicit operator Option<T>(Option.None _)
            => new Option<T>();

        public static implicit operator Option<T>(Option.Some<T> some)
            => new Option<T>(some.Value);

        public static implicit operator Option<T>(T value)
            => value == null ? None : Some(value);

        public R Match<R>(Func<R> None, Func<T, R> Some)
            => _isSome ? Some(_value) : None();
    }

}



namespace LaYumba.Functional
{
    public static partial class F
    {
        public static Option.None None => Option.None.Default;
        public static Option.Some<T> Some<T>(T value)
            => new Option.Some<T>(value);
    }
}