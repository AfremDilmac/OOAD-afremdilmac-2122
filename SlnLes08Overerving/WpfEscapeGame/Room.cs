using System;
using System.Collections.Generic;
using System.Text;

namespace WpfEscapeGame
{
    class Room : Actor
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Door> Doors { get; set; } = new List<Door>();
        public string[] Background { get; } = { "/ss-bedroom.png", "/ss-living.png", "/ss-computer.png" };
        public Room(string n, string ds) : base(n, ds) { }
    }
}
