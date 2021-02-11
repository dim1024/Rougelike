﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YetAnotherGenericRougelikeGame
{
    public class Generate
    {
        public static List<string> RegularLocations = new List<string>();
        public static List<string> ForestLocations = new List<string>();
        public static List<string> CaveLocations = new List<string>();
        public static List<string> MountainLocations = new List<string>();

        public static List<string> BushResources = new List<string>();
        public static List<string> FloorPlantResources = new List<string>();
        public static List<string> WaterPlantResources = new List<string>();

        public static List<string> FruitTreeResources = new List<string>();
        public static List<string> TreeResources = new List<string>();
        public static List<string> RareTreeResources = new List<string>();

        public static List<string> PassiveCreatures = new List<string>();
        public static List<string> LesserPrefixHostileCreatures = new List<string>();
        public static List<string> LesserNameHostileCreatures = new List<string>();
        public static List<string> PrefixHostileCreatures = new List<string>();
        public static List<string> NameHostileCreatures = new List<string>();
        public static List<string> SuffixHostileCreatures = new List<string>();
        public static List<string> GreaterPrefixHostileCreatures = new List<string>();
        public static List<string> GreaterNameHostileCreatures = new List<string>();
        public static List<string> GreaterSuffixHostileCreatures = new List<string>();

        public static void ClearResources() //Should be called before using ReloadResources()
        {
            RegularLocations.Clear();
            ForestLocations.Clear();
            CaveLocations.Clear();
            MountainLocations.Clear();
            BushResources.Clear();
            FloorPlantResources.Clear();
            WaterPlantResources.Clear();
            FruitTreeResources.Clear();
            TreeResources.Clear();
            ForestLocations.Clear();
            TreeResources.Clear();
            RareTreeResources.Clear();
            PassiveCreatures.Clear();
            LesserPrefixHostileCreatures.Clear();
            LesserNameHostileCreatures.Clear();
            PrefixHostileCreatures.Clear();
            NameHostileCreatures.Clear();
            SuffixHostileCreatures.Clear();
            GreaterPrefixHostileCreatures.Clear();
            GreaterNameHostileCreatures.Clear();
            GreaterSuffixHostileCreatures.Clear();
        }

        public static void ReloadResources() //Calling this function will reload all resources
        {
            Generate.RegularLocations.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/World/Locations/Regular/Regular"));
            Generate.ForestLocations.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/World/Locations/Regular/Forest"));
            Generate.CaveLocations.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/World/Locations/Regular/Caves"));
            Generate.MountainLocations.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/World/Locations/Regular/Mountain"));

            Generate.BushResources.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/World/Plants/Bushes"));
            Generate.FloorPlantResources.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/World/Plants/Floor"));
            Generate.WaterPlantResources.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/World/Plants/Waterplants"));

            Generate.FruitTreeResources.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/World/Trees/Fruit"));
            Generate.TreeResources.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/World/Trees/Regular"));
            Generate.RareTreeResources.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/World/Trees/Rare"));

            Generate.PassiveCreatures.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/Creatures/Passive/Land/Names"));
            Generate.LesserPrefixHostileCreatures.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/Creatures/Hostile/Lesser/Prefix"));
            Generate.LesserNameHostileCreatures.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/Creatures/Hostile/Lesser/Enemy"));
            Generate.PrefixHostileCreatures.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/Creatures/Hostile/Normal/Prefix"));
            Generate.NameHostileCreatures.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/Creatures/Hostile/Normal/Enemy"));
            //Generate.SuffixHostileCreatures.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/Creatures/Hostile/Normal/Suffix"));
            Generate.GreaterPrefixHostileCreatures.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/Creatures/Hostile/Greater/Prefix"));
            Generate.GreaterNameHostileCreatures.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/Creatures/Hostile/Greater/Enemy"));
            //Generate.GreaterSuffixHostileCreatures.AddRange(File.ReadAllLines(FileSystem.AppDataDirectory + "/Data/Resources/Creatures/Hostile/Greater/Suffix"));
        }

        public static string[] Terrain()
        {
            /*Heres how the terrain gen works:
             Random Number      Name            ID
             00-50              Normal          0
             51-80              Forrest         1
             81-90              Cave            2
             91-96              Mountain        3
             97-100             Unique (Not implemented yet)
            ID's are used to let the code understand what list is being picked from

            The code below basically gets a random number and then
            goes to the corresponding if, then it picks a random item
            in the corresponding list.*/

            Random rnd = new Random();
            int TerrainDecider = rnd.Next(0, 100);
            string[] output = { "", "", "" };

            if (TerrainDecider <= 50) //Normal terrain
            {
                output[0] = "0";
                output[1] = Convert.ToString(rnd.Next(0, Generate.RegularLocations.Count()));
                output[2] = Generate.RegularLocations[Convert.ToInt32(output[1])];
            }
            else if (TerrainDecider >= 51 && TerrainDecider <= 80)
            {
                output[0] = "1";
                output[1] = Convert.ToString(rnd.Next(0, Generate.ForestLocations.Count()));
                output[2] = Generate.ForestLocations[Convert.ToInt32(output[1])];
            }
            else if (TerrainDecider >= 81 && TerrainDecider <= 90)
            {
                output[0] = "2";
                output[1] = Convert.ToString(rnd.Next(0, Generate.CaveLocations.Count()));
                output[2] = Generate.CaveLocations[Convert.ToInt32(output[1])];
            }
            else if (TerrainDecider >= 91 && TerrainDecider <= 96)
            {
                output[0] = "3";
                output[1] = Convert.ToString(rnd.Next(0, Generate.MountainLocations.Count()));
                output[2] = Generate.MountainLocations[Convert.ToInt32(output[1])];
            }
            else if (TerrainDecider >= 96 && TerrainDecider <= 100) //should be changed for unique settlements
            {
                output[0] = "2";
                output[1] = Convert.ToString(rnd.Next(0, Generate.CaveLocations.Count()));
                output[2] = Generate.CaveLocations[Convert.ToInt32(output[1])];
            }
            return output;
        }

        public static string[] ResouceGenerate() //This generates a single resource ResourceDisplay() creates a full set of resources.
        {
            /* Heres how the resource gen works
            Random Value   Name               ID
            
            00-15     -    Bush               0
            16-30     -    Floor plants       1
            31-40     -    Waterplants        2
            41-60     -    Fruit Trees        3
            61-96     -    Regular Trees      4
            96-100    -    Rare               5
            ID's are used to let the code understand what list is being picked from

            The code below basically gets a random number and then
            goes to the corresponding if, then it picks a random item
            in the corresponding list.*/

            Random rnd = new Random();
            int ResourceDecider = rnd.Next(0, 100);
            string[] output = { "", "", "" };

            if (ResourceDecider <= 15)
            {
                output[0] = "0";
                output[1] = Convert.ToString(rnd.Next(0, Generate.BushResources.Count()));
                output[2] = "There is a " + Generate.BushResources[Convert.ToInt32(output[1])];
            }
            else if (ResourceDecider >= 16 && ResourceDecider <= 30)
            {
                output[0] = "1";
                output[1] = Convert.ToString(rnd.Next(0, Generate.FloorPlantResources.Count()));
                output[2] = "There is a " + Generate.FloorPlantResources[Convert.ToInt32(output[1])];
            }
            else if (ResourceDecider >= 31 && ResourceDecider <= 40)
            {
                output[0] = "2";
                output[1] = Convert.ToString(rnd.Next(0, Generate.WaterPlantResources.Count()));
                output[2] = "There is a " + Generate.WaterPlantResources[Convert.ToInt32(output[1])];
            }
            else if (ResourceDecider >= 41 && ResourceDecider <= 60)
            {
                output[0] = "3";
                output[1] = Convert.ToString(rnd.Next(0, Generate.FruitTreeResources.Count()));
                output[2] = "There is a " + Generate.FruitTreeResources[Convert.ToInt32(output[1])] + " tree";
            }
            else if (ResourceDecider >= 61 && ResourceDecider <= 96)
            {
                output[0] = "4";
                output[1] = Convert.ToString(rnd.Next(0, Generate.TreeResources.Count()));
                output[2] = "There is a " + Generate.TreeResources[Convert.ToInt32(output[1])] + " tree";
            }
            else if (ResourceDecider >= 97 && ResourceDecider <= 100)
            {
                output[0] = "4";
                output[1] = Convert.ToString(rnd.Next(0, Generate.TreeResources.Count()));
                output[2] = "There is a " + Generate.TreeResources[Convert.ToInt32(output[1])] + " tree";
            }
            return output;
        }

        public static string[] CreatureGenerate()
        {

            Random rnd = new Random();
            string[] output = { "", "", "-1" };
            output[0] = "0";
            output[1] = Generate.PassiveCreatures[rnd.Next(0, Generate.PassiveCreatures.Count())];
            return output;
        }

        public static string[] HostileGenerate()
        {
            /* Enemy Generation guide
            Suffix - 33% chance
            Prefix - 20% Chance

            The value of Suffix and Prefix decider are added to output[2] 
            this will be used in battle to enhance an enemys stats.

            TODO - Re add suffixes
             */
            Random rnd = new Random();
            string[] output = { "", "", "1" };
            output[0] = "1";

            if (rnd.Next(0, 2) == 0) //Prefix generation
            {
                int prefixdecider = rnd.Next(0, 2);
                output[2] = Convert.ToString(1 + prefixdecider);
                if (prefixdecider == 0) //Lesser prefix
                {
                    output[1] = Generate.LesserPrefixHostileCreatures[rnd.Next(0, Generate.LesserPrefixHostileCreatures.Count())] + " ";
                }
                else if (prefixdecider == 1) //Normal prefix
                {
                    output[1] = Generate.PrefixHostileCreatures[rnd.Next(0, Generate.PrefixHostileCreatures.Count())] + " ";
                }
                else if (prefixdecider == 2) //Greater prefix
                {
                    output[1] = Generate.NameHostileCreatures[rnd.Next(0, Generate.NameHostileCreatures.Count())] + " ";
                }
            }

            output[1] = output[1] + Generate.NameHostileCreatures[rnd.Next(0, Generate.NameHostileCreatures.Count())];

            if (rnd.Next(0, 4) == 10) //Suffix generation (Disabled until suffixes are added)
            {
                int suffixdecider = rnd.Next(0, 1);
                output[2] = Convert.ToString(Convert.ToInt32(output[2]) + suffixdecider);
                if (suffixdecider == 0) //Normal Suffix
                {
                    output[1] = output[1] + " " + Generate.SuffixHostileCreatures[rnd.Next(0, Generate.SuffixHostileCreatures.Count())];
                }
                else if (suffixdecider == 1) //Greater Suffix
                {
                    output[1] = output[1] + " " + Generate.GreaterSuffixHostileCreatures[rnd.Next(0, Generate.GreaterSuffixHostileCreatures.Count())];
                }
            }
            return output;
        }
    }
}
