using System;
using System.Collections.Generic;
using System.Text;

namespace WpfEscapeGame
{
    class Door : LockableItem
    {
        public Room ToRoom { get; set; }
        public Door(string n, string ds) : base(n, ds) { }
    }
}
