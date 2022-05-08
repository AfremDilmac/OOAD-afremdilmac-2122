using System;
using System.Collections.Generic;
using System.Text;

namespace WpfEscapeGame
{
    abstract class Actor
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Actor(string n, string ds)
        {
            Name = n;
            Description = ds;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
