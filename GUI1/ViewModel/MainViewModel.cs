using GUI1.Extensions;
using GUI1.Model;
using KaiserMVVMCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using GUI1.ServicesFolder;

namespace GUI1.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private bool areStatsVisible = true;
        public bool AreStatsVisible { get => areStatsVisible; private set => base.Set(ref areStatsVisible, value); }

        private bool areAbilitiesVisible = false;
        public bool AreAbilitiesVisible { get => areAbilitiesVisible; private set => base.Set(ref areAbilitiesVisible, value); }

        private bool areMissionsVisible = false;
        public bool AreMissionsVisible { get => areMissionsVisible; private set => base.Set(ref areMissionsVisible, value); }


        private MapField currentMapField;
        public MapField CurrentMapField { get => currentMapField; private set => base.Set(ref currentMapField, value); }

        private string coordinates;
        public string Coordinates {get => coordinates; set => base.Set(ref coordinates, value); }

        public Player CurrentPlayer { get; private set; } = HttpServices.PlayerInfo;


        private List<Item> items;
        public List<Item> Items { get => items; private set => base.Set(ref items, value); }

        private List<CharacterAbility> abilities;
        public List<CharacterAbility> Abilities { get => abilities; private set => base.Set(ref abilities, value); }

        private List<MapField> mapFields;
        public List<MapField> MapFields { get => mapFields; private set => base.Set(ref mapFields, value); }


        private ObservableCollection<string> chatMessages = new();
        public ObservableCollection<string> ChatMessages { get => chatMessages; set => base.Set(ref chatMessages, value); }

        private string newChatMessage = string.Empty;
        public string NewChatMessage { get => this.newChatMessage; set => base.Set(ref this.newChatMessage, value); }

        public RelayCommand GoToStatsCommand { get; private set; }
        public RelayCommand GoToCharacterAbilitiesCommand { get; private set; }

        public RelayCommand MapGoNorthCommand { get; private set; }
        public RelayCommand MapGoEastCommand { get; private set; }
        public RelayCommand MapGoSouthCommand { get; private set; }
        public RelayCommand MapGoWestCommand { get; private set; }

        public RelayCommand FieldChatCommand { get; private set; }
        public RelayCommand ClanChatCommand { get; private set; }
        public RelayCommand AllChatCommand { get; private set; }


        private List<MapField> allMapFields;

        public MainViewModel()
        {
            this.CurrentPlayer = HttpServices.PlayerInfo;
            this.Items = PrepareItems();
            this.Abilities = PrepareAbilities();
            this.allMapFields = PrepareRandomMap();
            this.MapFields = CalculateMiniMap(this.CurrentPlayer.X, this.CurrentPlayer.Y);
            this.CurrentMapField = this.MapFields[12];

            this.GoToStatsCommand = new RelayCommand(this.GoToStatsCommandExecute);
            this.GoToCharacterAbilitiesCommand = new RelayCommand(this.GoToCharacterAbilitiesCommandExecute);

            this.MapGoNorthCommand = new RelayCommand(this.MapGoNorthCommandExecute);
            this.MapGoEastCommand = new RelayCommand(this.MapGoEastCommandExecute);
            this.MapGoSouthCommand = new RelayCommand(this.MapGoSouthCommandExecute);
            this.MapGoWestCommand = new RelayCommand(this.MapGoWestCommandExecute);

            this.FieldChatCommand = new RelayCommand(this.FieldChatCommandExecute);
            this.AllChatCommand = new RelayCommand(this.AllChatCommandExecute);
            this.ClanChatCommand = new RelayCommand(this.ClanChatCommandExecute);
        }

        private void FieldChatCommandExecute()
        {
            if (!string.IsNullOrWhiteSpace(this.NewChatMessage)) 
            {
                ChatService.PostFieldMessage(this.NewChatMessage);
                this.ChatMessages.Insert(0, $"{DateTime.Now.ToString()} jackLL: {this.NewChatMessage} [Field Chat]");
                this.NewChatMessage = string.Empty;

            }
        }
        private void ClanChatCommandExecute()
        {
            if (!string.IsNullOrWhiteSpace(this.NewChatMessage))
            {
                ChatService.PostClanMessage(this.NewChatMessage);
                this.ChatMessages.Insert(0, $"{DateTime.Now.ToString()} jackLL: {this.NewChatMessage} [Clan Chat]");
                this.NewChatMessage = string.Empty;

            }
        }
        private void AllChatCommandExecute()
        {
            if (!string.IsNullOrWhiteSpace(this.NewChatMessage))
            {
                ChatService.PostShoutMessage(this.NewChatMessage);
                this.ChatMessages.Insert(0, $"{DateTime.Now.ToString()} jackLL: {this.NewChatMessage} [All Chat]");
                this.NewChatMessage = string.Empty;

            }
        }

        private void MapGoNorthCommandExecute()
        {         
            this.MapFields = CalculateMiniMap(this.CurrentPlayer.X, this.CurrentPlayer.Y, "north");
            this.CurrentPlayer.Y = this.MapFields[12].Y;
            this.CurrentMapField = this.MapFields[12];
            this.CurrentMapField.Description = GetDescription(this.CurrentMapField.Filename);

        }

        private void MapGoEastCommandExecute()
        {
            this.MapFields = CalculateMiniMap(this.CurrentPlayer.X, this.CurrentPlayer.Y, "east");
            this.CurrentPlayer.X = this.MapFields[12].X;
            this.CurrentMapField = this.MapFields[12];
            this.CurrentMapField.Description = GetDescription(this.CurrentMapField.Filename);
        }

        private void MapGoSouthCommandExecute()
        {
            this.MapFields = CalculateMiniMap(this.CurrentPlayer.X, this.CurrentPlayer.Y, "south");
            this.CurrentPlayer.Y = this.MapFields[12].Y;
            this.CurrentMapField = this.MapFields[12];
            this.CurrentMapField.Description = GetDescription(this.CurrentMapField.Filename);
        }

        private void MapGoWestCommandExecute()
        {
            this.MapFields = CalculateMiniMap(this.CurrentPlayer.X, this.CurrentPlayer.Y, "west");
            this.CurrentPlayer.X = this.MapFields[12].X;
            this.CurrentMapField = this.MapFields[12];
            this.CurrentMapField.Description = GetDescription(this.CurrentMapField.Filename);
        }

        private void GoToStatsCommandExecute()
        {
            this.AreStatsVisible = true;
            this.AreAbilitiesVisible = false;
            this.AreMissionsVisible = false;
        }

        private void GoToCharacterAbilitiesCommandExecute()
        {
            this.AreStatsVisible = false;
            this.AreAbilitiesVisible = true;
            this.AreMissionsVisible = false;
        }

        private List<Item> PrepareItems()
        {
            return new List<Item>()
            {
                new Item() {Name = "Wand of fire", CurrentDurability = 100, MaxDurability = 100, Weight = 3},
                new Item() {Name = "Sword", CurrentDurability = 99, MaxDurability = 400, Weight = 54},
                new Item() {Name = "Boots of agility", CurrentDurability = 2, MaxDurability = 80, Weight = 18},
            };
        }

        private List<CharacterAbility> PrepareAbilities()
        {
            return new List<CharacterAbility>()
            {
                new CharacterAbility() {Name = "Gold mining", CurrentLevel = 14, MaxLevel = 30},
                new CharacterAbility() {Name = "Learning tachnique", CurrentLevel = 19, MaxLevel = 50},
                new CharacterAbility() {Name = "Hunting", CurrentLevel = 91, MaxLevel = 100},
            };
        }

        private List<MapField> CalculateMiniMap(int x, int y, string direction = "")
        {
            int newx = x;
            int newy = y; 
            if(direction == "north")
            {
                newy++;
            }
            else if(direction == "east")
            {
                newx++;
            }
            else if(direction== "south")
            {
                newy--;
            }
            else if(direction == "west")
            {
                newx--;
            }
            var newPos = this.allMapFields.SingleOrDefault(mf => mf.X == newx && mf.Y == newy);
            if(newPos != null)
            {
                if(newPos.Passable == true)
                {
                    x = newx;
                    y = newy;
                }
            }
            var l = new List<MapField>();
            for (var k = y + 2; k >= y - 2; k--)
            {
                for(var i = x - 2; i <= x + 2; i++)
                {
                    var field = this.allMapFields.SingleOrDefault(mf => mf.X == i && mf.Y == k);

                    if(field == null)
                    {
                        field = new MapField() { X = i, Y = k, Passable = false, Filename = "stone2" };                      
                    }
                    l.Add(field);
                }
            }
            return l;
        }

        private List<MapField> PrepareRandomMap()
        {
            var filenames = new string[] { "dirt1", "grass1", "grass2", "paving1"};
            var l = new List<MapField>();
            for (var y = 50; y < 70; y++)
            {
                for (var x = 5; x < 22; x++)
                {
                    l.Add(new MapField() { Filename = filenames.Random(), X = x, Y = y });
                }
            }
            return l;
        }

        private string GetDescription(string filename)
        {
            string ret = string.Empty;
            switch (filename) 
            {
                case "dirt1":
                    ret = "The road before you is muddy and hard to travel on. Twigs and leaves are all over " +
                        "the place and reduce your ability to properly see your path.";
                    break;
                case "grass1":
                case "grass2":
                    ret = "You are enthusiastically walking over lush, green grass and it feels good on your " +
                        "soles. The sun is shining, the birds are chirping merrily and you don't have a single worry " +
                        "in your life.";
                    break;
                case "paving1":
                    ret = "Finally, some proper fucking road.";
                    break;
                case "stone2":
                    ret = "You will propably break your neck, but there is helping in crossing these rocky plains.";
                    break;
            }
            return ret;
        }
    }
}
