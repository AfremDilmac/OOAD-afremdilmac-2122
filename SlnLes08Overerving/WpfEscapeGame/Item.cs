using System;
using System.Collections.Generic;
using System.Text;

namespace WpfEscapeGame
{
    class Item : LockableItem
    {
        public bool IsPortable { get; set; } = true;
        public Item(string n, string ds) : base(n, ds) { }
        public Item(string n, string ds, bool port) : base(n, ds) { IsPortable = port; }
    }
}
