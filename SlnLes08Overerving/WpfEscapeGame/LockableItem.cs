using System;
using System.Collections.Generic;
using System.Text;

namespace WpfEscapeGame
{
    class LockableItem : Actor
    {
        public bool IsLocked { get; set; } = false;
        public Item Key { get; set; }
        public Item HiddenItem { get; set; }
        public LockableItem(string n, string ds) : base(n, ds) { }
    }
}
