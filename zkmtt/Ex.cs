using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedConsole;
using KMT;

namespace zkmtt
{
    class BoolValue
    {
        public bool Value { set; get; }

        public BoolValue()
        {
            Value = false;
        }
        public BoolValue(bool value)
        {
            Value = value;
        }
    }
    class StringValue
    {
        public string Value { set; get; }

        public StringValue()
        {
            Value = "";
        }
        public StringValue(string value)
        {
            Value = value;
        }
        public StringValue(string format, object arg0)
        {
            Value = String.Format(format, arg0);
        }
        public StringValue(string format, params object[] args)
        {
            Value = String.Format(format, args);
        }
        public StringValue(string format, object arg0, object arg1)
        {
            Value = String.Format(format, arg0, arg1);
        }
        public StringValue(string format, object arg0, object arg1, object arg2)
        {
            Value = String.Format(format, arg0, arg1, arg2);
        }
    }

    class StringAndList
    {
        public string Str { get;}
        public List<string> Arr { get;}

        public string Str_Simple { get {
                return Str.ToLower();
            } }

        public StringAndList(string str, List<string> arr)
        {
            Str = str;
            Arr = arr;
        }
    }

    class Ex
    {
        public Dictionary<KmtGameMode, StringAndList> DictGameMode =
            new Dictionary<KmtGameMode, StringAndList>();
        public Dictionary<KmtCourse, StringAndList> DictCourse =
            new Dictionary<KmtCourse, StringAndList>();
        public Dictionary<KmtCharacter, StringAndList> DictCharacter =
            new Dictionary<KmtCharacter, StringAndList>();
        public Dictionary<KmtVehicle, StringAndList> DictVehicle =
            new Dictionary<KmtVehicle, StringAndList>();
        public Dictionary<KmtEngineClass, StringAndList> DictEngineClass =
            new Dictionary<KmtEngineClass, StringAndList>();
        public Dictionary<KmtCameraMode, StringAndList> DictCameraMode =
            new Dictionary<KmtCameraMode, StringAndList>();

        private void Add_GameMode(KmtGameMode key, string output, params string[] input)
        {
            List<string> llist = new List<string>();
            foreach (string item in input)
            {
                llist.Add(item.ToLower());
            }
            DictGameMode.Add(key, new StringAndList(output, llist));
        }
        private void Add_Course(KmtCourse key, string output, params string[] input)
        {
            List<string> llist = new List<string>();
            foreach (string item in input)
            {
                llist.Add(item.ToLower());
            }
            DictCourse.Add(key, new StringAndList(output, llist));
        }
        private void Add_Character(KmtCharacter key, string output, params string[] input)
        {
            List<string> llist = new List<string>();
            foreach (string item in input)
            {
                llist.Add(item.ToLower());
            }
            DictCharacter.Add(key, new StringAndList(output, llist));
        }
        private void Add_Vehicle(KmtVehicle key, string output, params string[] input)
        {
            List<string> llist = new List<string>();
            foreach (string item in input)
            {
                llist.Add(item.ToLower());
            }
            DictVehicle.Add(key, new StringAndList(output, llist));
        }
        private void Add_EngineClass(KmtEngineClass key, string output, params string[] input)
        {
            List<string> llist = new List<string>();
            foreach (string item in input)
            {
                llist.Add(item.ToLower());
            }
            DictEngineClass.Add(key, new StringAndList(output, llist));
        }
        private void Add_CameraMode(KmtCameraMode key, string output, params string[] input)
        {
            List<string> llist = new List<string>();
            foreach (string item in input)
            {
                llist.Add(item.ToLower());
            }
            DictCameraMode.Add(key, new StringAndList(output, llist));
        }

        private void Add_GameMode(KmtGameMode key, string output)
        {
            DictGameMode.Add(key, new StringAndList(output, null));
        }
        private void Add_Course(KmtCourse key, string output)
        {
            DictCourse.Add(key, new StringAndList(output, null));
        }
        private void Add_Character(KmtCharacter key, string output)
        {
            DictCharacter.Add(key, new StringAndList(output, null));
        }
        private void Add_Vehicle(KmtVehicle key, string output)
        {
            DictVehicle.Add(key, new StringAndList(output, null));
        }
        private void Add_EngineClass(KmtEngineClass key, string output)
        {
            DictEngineClass.Add(key, new StringAndList(output, null));
        }
        private void Add_CameraMode(KmtCameraMode key, string output)
        {
            DictCameraMode.Add(key, new StringAndList(output, null));
        }

        public Ex()
        {
            Add_GameMode(KmtGameMode.Miniturbo, "Miniturbo");
            Add_GameMode(KmtGameMode.LapRun01, "LapRun01");
            Add_GameMode(KmtGameMode.LapRun02, "LapRun02");
            Add_GameMode(KmtGameMode.Drift, "Drift");
            Add_GameMode(KmtGameMode.ItemBox, "ItemBox");
            Add_GameMode(KmtGameMode.EnemyDown01, "EnemyDown01");
            Add_GameMode(KmtGameMode.EnemyDown02, "EnemyDown02");
            Add_GameMode(KmtGameMode.EnemyDown03, "EnemyDown03");
            Add_GameMode(KmtGameMode.CoinGet01, "CoinGet01");
            Add_GameMode(KmtGameMode.ToGate01, "ToGate01");
            Add_GameMode(KmtGameMode.RocketStart, "RocketStart");
            Add_GameMode(KmtGameMode.ItemHit, "ItemHit");
            Add_GameMode(KmtGameMode.Wheelie, "Wheelie");
            Add_GameMode(KmtGameMode.Slipstream, "Slipstream");

            Add_Course(KmtCourse.MarioCircuit, "Mario Circuit", "mariocircuit");
            Add_Course(KmtCourse.MooMooMeadows, "Moo Moo Meadows", "moomoomeadows");
            Add_Course(KmtCourse.MushroomGorge, "Mushroom Gorge", "mushroomgorge");
            Add_Course(KmtCourse.GrumbleVolcano, "Grumble Volcano", "grumblevolcano");
            Add_Course(KmtCourse.ToadsFactory, "Toad's Factory", "toad'sfactory", "toadsfactory", "toads factory");
            Add_Course(KmtCourse.CoconutMall, "Coconut Mall", "coconutmall");
            Add_Course(KmtCourse.DKSummit, "DK Summit", "dksummit");
            Add_Course(KmtCourse.WariosGoldMine, "Wario's Gold Mine", "wario'sgoldmine", "wariosgoldmine", "warios goldmine");
            Add_Course(KmtCourse.LuigiCircuit, "Luigi Circuit", "luigicircuit");
            Add_Course(KmtCourse.DaisyCircuit, "Daisy Circuit", "daisycircuit");
            Add_Course(KmtCourse.MoonviewHighway, "Moonview Highway", "moonviewhighway");
            Add_Course(KmtCourse.MapleTreeway, "Maple Treeway", "mapletreeway");
            Add_Course(KmtCourse.BowsersCastle, "Bowser's Castle", "bowser'scastle", "bowserscastle", "bowsers castle");
            Add_Course(KmtCourse.RainbowRoad, "Rainbow Road", "rainbowroad");
            Add_Course(KmtCourse.DryDryRuins, "Dry Dry Ruins", "drydryruins");
            Add_Course(KmtCourse.KoopaCape, "Koopa Cape", "koopacape");
            Add_Course(KmtCourse.GCNPeachBeach, "GCN Peach Beach", "gcnpeachbeach");
            Add_Course(KmtCourse.GCNMarioCircuit, "GCN Mario Circuit", "gcnmariocircuit");
            Add_Course(KmtCourse.GCNWaluigiStadium, "GCN Waluigi Stadium", "gcnwaluigistadium");
            Add_Course(KmtCourse.GCNDKMountain, "GCN DK Mountain", "gcndkmountain");
            Add_Course(KmtCourse.DSYoshiFalls, "DS Yoshi Falls", "dsyoshifalls");
            Add_Course(KmtCourse.DSDesertHills, "DS Desert Hills", "dsdeserthills");
            Add_Course(KmtCourse.DSPeachGardens, "DS Peach Gardens", "dspeachgardens");
            Add_Course(KmtCourse.DSDelfinoSquare, "DS Delfino Square", "dsdelfinosquare");
            Add_Course(KmtCourse.SNESMarioCircuit3, "SNES Mario Circuit 3", "snesmariocircuit3");
            Add_Course(KmtCourse.SNESGhostValley2, "SNES Ghost Valley 2", "snesghostvalley2");
            Add_Course(KmtCourse.N64MarioRaceway, "N64 Mario Raceway", "n64marioraceway");
            Add_Course(KmtCourse.N64SherbetLand, "N64 Sherbet Land", "n64sherbetland");
            Add_Course(KmtCourse.N64BowsersCastle, "N64 Bowser's Castle", "n64bowser'scastle", "n64bowserscastle", "n64 bowsers castle");
            Add_Course(KmtCourse.N64DKJungleParkway, "N64 DK Jungle Parkway", "n64dkjungleparkway");
            Add_Course(KmtCourse.GBABowserCastle3, "GBA Bowser Castle 3", "gbabowsercastle3");
            Add_Course(KmtCourse.GBAShyGuyBeach, "GBA Shy Guy Beach", "gbashyguybeach");
            Add_Course(KmtCourse.DelfinoPier, "Delfino Pier", "delfinopier");
            Add_Course(KmtCourse.BlockPlaza, "Block Plaza", "blockplaza");
            Add_Course(KmtCourse.ChainChompWheel, "Chain Chomp Wheel", "chainchompwheel");
            Add_Course(KmtCourse.FunkyStadium, "Funky Stadium", "funkystadium");
            Add_Course(KmtCourse.ThwompDesert, "Thwomp Desert", "thwompdesert");
            Add_Course(KmtCourse.GCNCookieLand, "GCN Cookie Land", "gcncookieland");
            Add_Course(KmtCourse.DSTwilightHouse, "DS Twilight House", "dstwilighthouse");
            Add_Course(KmtCourse.SNESBattleCourse4, "SNES Battle Course 4", "snesbattlecourse4");
            Add_Course(KmtCourse.GBABattleCourse3, "GBA Battle Course 3", "gbabattlecourse3");
            Add_Course(KmtCourse.N64Skyscraper, "N64 Skyscraper", "n64skyscraper");
            Add_Course(KmtCourse.GalaxyColosseum, "Galaxy Colosseum", "galaxycolosseum");
            Add_Course(KmtCourse.winingrun_demo, "winingrun_demo");
            Add_Course(KmtCourse.loser_demo, "loser_demo");
            Add_Course(KmtCourse.draw_demo, "draw_demo");
            Add_Course(KmtCourse.ending_demo, "ending_demo");

            Add_Character(KmtCharacter.Mario, "Mario");
            Add_Character(KmtCharacter.BabyPeach, "Baby Peach", "babypeach");
            Add_Character(KmtCharacter.Waluigi, "Waluigi");
            Add_Character(KmtCharacter.Bowser, "Bowser");
            Add_Character(KmtCharacter.BabyDaisy, "Baby Daisy", "BabyDaisy");
            Add_Character(KmtCharacter.DryBones, "Dry Bones", "DryBones");
            Add_Character(KmtCharacter.BabyMario, "Baby Mario", "BabyMario");
            Add_Character(KmtCharacter.Luigi, "Luigi");
            Add_Character(KmtCharacter.Toad, "Toad");
            Add_Character(KmtCharacter.DonkeyKong, "Donkey Kong", "DonkeyKong");
            Add_Character(KmtCharacter.Yoshi, "Yoshi");
            Add_Character(KmtCharacter.Wario, "Wario");
            Add_Character(KmtCharacter.BabyLuigi, "Baby Luigi", "BabyLuigi");
            Add_Character(KmtCharacter.Toadette, "Toadette");
            Add_Character(KmtCharacter.Koopa, "Koopa Troopa", "KoopaTroopa");
            Add_Character(KmtCharacter.Daisy, "Daisy");
            Add_Character(KmtCharacter.Peach, "Peach");
            Add_Character(KmtCharacter.Birdo, "Birdo");
            Add_Character(KmtCharacter.DiddyKong, "Diddy Kong", "DiddyKong");
            Add_Character(KmtCharacter.KingBoo, "King Boo", "KingBoo");
            Add_Character(KmtCharacter.BowserJr, "Bowser Jr.", "Bowser Jr", "BowserJr.", "BowserJr");
            Add_Character(KmtCharacter.DryBowser, "Dry Bowser", "DryBowser");
            Add_Character(KmtCharacter.FunkyKong, "Funky Kong", "FunkyKong");
            Add_Character(KmtCharacter.Rosalina, "Rosalina");
            Add_Character(KmtCharacter.SMiiAM, "SMiiAM");
            Add_Character(KmtCharacter.SMiiAF, "SMiiAF");
            Add_Character(KmtCharacter.SMiiBM, "SMiiBM");
            Add_Character(KmtCharacter.SMiiBF, "SMiiBF");
            Add_Character(KmtCharacter.SMiiCM, "SMiiCM");
            Add_Character(KmtCharacter.SMiiCF, "SMiiCF");
            Add_Character(KmtCharacter.MMiiAM, "MMiiAM");
            Add_Character(KmtCharacter.MMiiAF, "MMiiAF");
            Add_Character(KmtCharacter.MMiiBM, "MMiiBM");
            Add_Character(KmtCharacter.MMiiBF, "MMiiBF");
            Add_Character(KmtCharacter.MMiiCM, "MMiiCM");
            Add_Character(KmtCharacter.MMiiCF, "MMiiCF");
            Add_Character(KmtCharacter.LMiiAM, "LMiiAM");
            Add_Character(KmtCharacter.LMiiAF, "LMiiAF");
            Add_Character(KmtCharacter.LMiiBM, "LMiiBM");
            Add_Character(KmtCharacter.LMiiBF, "LMiiBF");
            Add_Character(KmtCharacter.LMiiCM, "LMiiCM");
            Add_Character(KmtCharacter.LMiiCF, "LMiiCF");
            Add_Character(KmtCharacter.MMii, "MMii");
            Add_Character(KmtCharacter.SMii, "SMii");
            Add_Character(KmtCharacter.LMii, "LMii");

            Add_Vehicle(KmtVehicle.StandardKartS, "Standard Kart S", "StandardKartS");
            Add_Vehicle(KmtVehicle.StandardKartM, "Standard Kart M", "StandardKartM");
            Add_Vehicle(KmtVehicle.StandardKartL, "Standard Kart L", "StandardKartL");
            Add_Vehicle(KmtVehicle.BoosterSeat, "Booster Seat", "BoosterSeat");
            Add_Vehicle(KmtVehicle.ClassicDragster, "Classic Dragster", "ClassicDragster");
            Add_Vehicle(KmtVehicle.Offroader, "Offroader");
            Add_Vehicle(KmtVehicle.MiniBeast, "Mini Beast", "MiniBeast");
            Add_Vehicle(KmtVehicle.WildWing, "Wild Wing", "WildWing");
            Add_Vehicle(KmtVehicle.FlameFlyer, "Flame Flyer", "FlameFlyer");
            Add_Vehicle(KmtVehicle.CheepCharger, "Cheep Charger", "CheepCharger");
            Add_Vehicle(KmtVehicle.SuperBlooper, "Super Blooper", "SuperBlooper");
            Add_Vehicle(KmtVehicle.PiranhaProwler, "Piranha Prowler", "PiranhaProwler");
            Add_Vehicle(KmtVehicle.TinyTitan, "Tiny Titan", "TinyTitan");
            Add_Vehicle(KmtVehicle.Daytripper, "Daytripper");
            Add_Vehicle(KmtVehicle.Jetsetter, "Jetsetter");
            Add_Vehicle(KmtVehicle.BlueFalcon, "Blue Falcon", "BlueFalcon");
            Add_Vehicle(KmtVehicle.Sprinter, "Sprinter");
            Add_Vehicle(KmtVehicle.Honeycoupe, "Honeycoupe");
            Add_Vehicle(KmtVehicle.StandardBikeS, "Standard Bike S", "StandardBikeS");
            Add_Vehicle(KmtVehicle.StandardBikeM, "Standard Bike M", "StandardBikeM");
            Add_Vehicle(KmtVehicle.StandardBikeL, "Standard Bike L", "StandardBikeL");
            Add_Vehicle(KmtVehicle.BulletBike, "Bullet Bike", "BulletBike");
            Add_Vehicle(KmtVehicle.MachBike, "Mach Bike", "MachBike");
            Add_Vehicle(KmtVehicle.FlameRunner, "Flame Runner", "FlameRunner");
            Add_Vehicle(KmtVehicle.BitBike, "Bit Bike", "BitBike");
            Add_Vehicle(KmtVehicle.Sugarscoot, "Sugarscoot");
            Add_Vehicle(KmtVehicle.WarioBike, "Wario Bike", "WarioBike");
            Add_Vehicle(KmtVehicle.Quacker, "Quacker");
            Add_Vehicle(KmtVehicle.ZipZip, "Zip Zip", "ZipZip");
            Add_Vehicle(KmtVehicle.ShootingStar, "Shooting Star", "ShootingStar");
            Add_Vehicle(KmtVehicle.Magikruiser, "Magikruiser");
            Add_Vehicle(KmtVehicle.Sneakster, "Sneakster");
            Add_Vehicle(KmtVehicle.Spear, "Spear");
            Add_Vehicle(KmtVehicle.JetBubble, "Jet Bubble", "JetBubble");
            Add_Vehicle(KmtVehicle.DolphinDasher, "Dolphin Dasher", "DolphinDasher");
            Add_Vehicle(KmtVehicle.Phantom, "Phantom");

            Add_EngineClass(KmtEngineClass.e50cc, "50cc", "50");
            Add_EngineClass(KmtEngineClass.e100cc, "100cc", "100");
            Add_EngineClass(KmtEngineClass.e150cc, "150cc", "150");
            Add_EngineClass(KmtEngineClass.Battle, "Battle");

            Add_CameraMode(KmtCameraMode.Default, "Default");
            Add_CameraMode(KmtCameraMode.FromAbove, "From Above", "FromAbove");
        }

        public string GameMode(KmtGameMode x)
        {
            if (DictGameMode.ContainsKey(x)) return DictGameMode[x].Str;
            return "0x"+((ushort)x).ToString("x4");
        }
        public string Course(KmtCourse x)
        {
            if (DictCourse.ContainsKey(x)) return DictCourse[x].Str;
            return "0x" + ((byte)x).ToString("x2");
        }
        public string Character(KmtCharacter x)
        {
            if (DictCharacter.ContainsKey(x)) return DictCharacter[x].Str;
            return "0x" + ((byte)x).ToString("x2");
        }
        public string Vehicle(KmtVehicle x)
        {
            if (DictVehicle.ContainsKey(x)) return DictVehicle[x].Str;
            return "0x" + ((byte)x).ToString("x2");
        }
        public string EngineClass(KmtEngineClass x)
        {
            if (DictEngineClass.ContainsKey(x)) return DictEngineClass[x].Str;
            return "0x" + ((byte)x).ToString("x2");
        }
        public string CameraMode(KmtCameraMode x)
        {
            if (DictCameraMode.ContainsKey(x)) return DictCameraMode[x].Str;
            return "0x" + ((ushort)x).ToString("x4");
        }

        public static StringValue ExceptionMessage(Exception ex)
        {
            string message = ex.Message;
            if (ex.StackTrace != null)
            {
                message = ex.StackTrace + "\n" + message;
            }
            return new StringValue(message);
        }
    }
}
