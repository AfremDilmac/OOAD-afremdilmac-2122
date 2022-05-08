using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfEscapeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Room currentRoom; // will become useful in later versions

        Room room1 = new Room("bedroom", "I seem to be in a medium sized bedroom. There is a locker to the left, a nice rug on the floor, and a bed to the right.");
        Room room2 = new Room("living", "I seem to be in a big sized living room. I can see a chair, a clock, a plant a floor mat and a door with a pincode to open the door ?");
        Room room3 = new Room("computer", "I seem to be in a little sized computer room. There is a computer to the left on a desktop with a chair next to it and a frame at the wall. There is a flag on the wall a radiator and 2 chairs one at the left side of the door and another one at the right side. ");
        //Define doors
        Door door1 = new Door("Living Door", "A locked door, i have to find a way to open this");
        Door door2 = new Door("Computer Door", "gives acces to the computer room");
        Door door3 = new Door("Null", "null");

        public MainWindow()
        {
            InitializeComponent();
            //define room
            string bedroomBg = room1.Background[0];
       
            //define items
            Item key1 = new Item("small silver key", "A small silver key, makes me think of one I had at highschool. ", true);
            Item key2 = new Item("large key", "A large key. Could this be my way out? ", true);
            Item locker = new Item("locker", "A locker. I wonder what's inside. ", false);
            locker.HiddenItem = key2;
            locker.IsLocked = true;
            locker.Key = key1;
            Item bed = new Item("bed", "Just a bed. I am not tired right now. ", false);
            bed.HiddenItem = key1;
            door1.Key = key2;
            Item stoel = new Item("stoel", "Just a chair, might well sit on it", false);
            Item poster = new Item("poster", "WOW It's a poster of JOHN CENA", true);

            Item carpet = new Item("carpet", "a carpet");
            Item sofa = new Item("sofa", "a sofa");
            Item computer = new Item("computer", "a computer");
            Item tv = new Item("tv", "a tv");
            Item schilderij = new Item("schilderij", "een schilderij");

            //setup bedroom
            room1.Items.Add(new Item("floor mat", "A bit ragged floor mat, but still one of themost popular designs. ", true));
            room1.Items.Add(bed);
            room1.Items.Add(locker);
            room1.Items.Add(stoel);
            room1.Items.Add(poster);
            room1.Doors.Add(door1);
            // setup living room
            room2.Items.Add(carpet);
            room2.Items.Add(sofa);
            room2.Doors.Add(door2);
            room2.Doors.Add(door3);

            // setup computer room
            room3.Items.Add(computer);
            room3.Items.Add(tv);
            room3.Items.Add(schilderij);
            room3.Doors.Add(door1);
            // start game
            currentRoom = room1;
            lblMessage.Content = "I am awake, but cannot remember who I am!? Must have been a hell of a party last night... ";
            txtRoomDesc.Text = currentRoom.Description;
            background.Source = new BitmapImage(new Uri(bedroomBg, UriKind.Relative));
            UpdateUI();
        }

        private void UpdateUI()
        {
            lstRoomItems.Items.Clear();
            foreach (Item itm in currentRoom.Items)
            {
                lstRoomItems.Items.Add(itm);
            }
            lstRoomDoors.Items.Clear();
            foreach (Door door in currentRoom.Doors)
            {
                lstRoomDoors.Items.Add(door);
            }
            txtRoomDesc.Text = currentRoom.Description;
        }
        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            // 1. find item to check
            Item roomItem = (Item)lstRoomItems.SelectedItem;
            // 2. is it locked?
            if (roomItem.IsLocked)
            {
                lblMessage.Content = $"{roomItem.Description}It is firmly locked. ";
                return;
            }
            // 3. does it contain a hidden item?
            Item foundItem = roomItem.HiddenItem;
            if (foundItem != null)
            {
                lblMessage.Content = $"Oh, look, I found a {foundItem.Name}.";
                lstMyItems.Items.Add(foundItem);
                roomItem.HiddenItem = null;
                return;
            }
            // 4. just another item; show description
            lblMessage.Content = roomItem.Description;
        }

        private void btnPickUp_Click(object sender, RoutedEventArgs e)
        {
            // 1. find selected item
            Item selItem = (Item)lstRoomItems.SelectedItem;
            if (selItem.IsPortable == false)
            {
                lblMessage.Content = $"You can't put {selItem.Name} in your picked up items. ";
                return;
            }
            // 2. add item to your items list
            lblMessage.Content = $"I just picked up the {selItem.Name}. ";
            lstMyItems.Items.Add(selItem);
            lstRoomItems.Items.Remove(selItem);
            currentRoom.Items.Remove(selItem);
        }

        private void btnUseOn_Click(object sender, RoutedEventArgs e)
        {
            // 1. find both items
            Item myItem = (Item)lstMyItems.SelectedItem;
            Item roomItem = (Item)lstRoomItems.SelectedItem;
            // 2. item doesn't fit
            if (roomItem.Key != myItem)
            {
                lblMessage.Content = RandomMessageGenerator.GetRandomMessage(RandomMessageGenerator.MessageType.Message0);
                return;
            }
            // 3. item fits; other item unlocked
            roomItem.IsLocked = false;
            roomItem.Key = null;
            lstMyItems.Items.Remove(myItem);
            lblMessage.Content = $"I just unlocked the {roomItem.Name}!";
        }

        private void lstMyItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnCheck.IsEnabled = lstRoomItems.SelectedValue != null; // room item selected
            btnPickUp.IsEnabled = lstRoomItems.SelectedValue != null; // room item selected
            btnUseOn.IsEnabled = lstRoomItems.SelectedValue != null && lstMyItems.SelectedValue != null; // room item and picked up item selected

        }

        private void LstItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnCheck.IsEnabled = lstRoomItems.SelectedValue != null; // room item selected
            btnPickUp.IsEnabled = lstRoomItems.SelectedValue != null; // room item selected
            btnUseOn.IsEnabled = lstRoomItems.SelectedValue != null && lstMyItems.SelectedValue != null; // room item and picked up item selected
            btnDrop.IsEnabled = lstMyItems.SelectedValue != null;
            btnOpenWith.IsEnabled = lstMyItems.SelectedValue != null && lstRoomDoors.SelectedValue != null; //picked up item selected
        }

        private void btnDrop_Click(object sender, RoutedEventArgs e)
        {
           // 1. find selected item
            Item selItem = (Item)lstMyItems.SelectedItem;
            // 2. add item to your items list
            lblMessage.Content = $"I just dropped the {selItem.Name} back to his place. ";
            lstRoomItems.Items.Add(selItem);
            lstMyItems.Items.Remove(selItem);
            currentRoom.Items.Remove(selItem);
        }

        private void btnOpenWith_Click(object sender, RoutedEventArgs e)
        {
            // 1. find both items
            Item Item = (Item)lstMyItems.SelectedItem;
            Door door = (Door)lstRoomDoors.SelectedItem;
            // 2. item doesn't fit
            if (door.Key != Item)
            {
                lblMessage.Content = RandomMessageGenerator.GetRandomMessage(RandomMessageGenerator.MessageType.Message0);
                return;
            }
            // 3. item fits; other item unlocked
            door.IsLocked = false;
            door.Key = null;
            lstMyItems.Items.Remove(Item);
            lblMessage.Content = $"I just unlocked the {door.Name}!";
            btnEnter.IsEnabled = true;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string livingRoomBg = room1.Background[1];
            string computerRoomBg = room1.Background[2];
            if (lstRoomDoors.SelectedIndex == 0 && currentRoom == room1)
            {
                currentRoom = room2;
                lblMessage.Content = "Just entered the living room";
                UpdateUI();
                background.Source = new BitmapImage(new Uri(livingRoomBg, UriKind.Relative));
                return;
            }
            if (lstRoomDoors.SelectedIndex == 0 && currentRoom == room2)
            {
                currentRoom = room3;
                lblMessage.Content = "Just entered the computer room";
                UpdateUI();
                background.Source = new BitmapImage(new Uri(computerRoomBg, UriKind.Relative));
                return;
            }
            if (lstRoomDoors.SelectedIndex == 1 && currentRoom == room2)
            {
                lblMessage.Content = "This door is closed i need a key";
                UpdateUI();
                return;
            }
            if (lstRoomDoors.SelectedIndex == 0 && currentRoom == room3)
            {
                currentRoom = room2;
                lblMessage.Content = "Just entered the living room";
                UpdateUI();
                background.Source = new BitmapImage(new Uri(computerRoomBg, UriKind.Relative));
                return;
            }

        }

    }
}
