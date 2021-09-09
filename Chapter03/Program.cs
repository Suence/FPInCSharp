using Newtonsoft.Json;
using OptionT;
using System;

namespace Chapter03
{
    class Program
    {
        static void Main(string[] args)
        {
            Option<string> name = "Lucy";
            var json = JsonConvert.SerializeObject(name);
            Option<string> nameD = JsonConvert.DeserializeObject<Option<string>>(json);

        }
    }
}
