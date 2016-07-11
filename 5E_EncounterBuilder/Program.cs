//Brandon DeLano
//7/10/2016
//Quick and dirty Dnd 5E Adventure generator.  
//Designed to reduce the amount of time it takes me to randomly generate adventures according to the DMG.
//Not intended for sale or profit, just fun.
using System;
using System.Collections.Generic;


namespace _5E_EncounterBuilder
{
    public class Program
    {
        
        //private static string output = "";
        private enum Difficulty
        {
            Easy,
            Medium,
            Hard,
            Deadly
        }

        #region Look-up Tables
        private static string[] _dungeonGoals = new string[] 
        {
            "Stop the dungeon's monstrous inhabitants from raiding the surface world",
            "Foil a villain's evil scheme",
            "Destroy a magical threat inside the dungeon",
            "Acquire treasure",
            "Find a particular item for a specific purpose",
            "Retrieve a stolen item hidden in the dungeon",
            "Find information needed for a special purpose",
            "Rescue a captive",
            "Discover the fate of a previous adventuring party",
            "Find an NPC who disappeared in the area",
            "Slay a dragon or other challenging monster",
            "Discover the nature and origin of a strange location or phenomenon",
            "Pursue fleeing foes taking refuge in the dungeon",
            "Escape from captivity in the dungeon",
            "Clear a ruin so it can be rebuilt and reoccupied",
            "Discover why a  villain is interested in the dungeon",
            "Win a bet or complete a rite of passage by surviving in the dungeon for a certain amount of time",
            "Parley with a villain in the dungeon",
            "Hide from a threat outside the dungeon",
            "Destroy a mysterious device in the dungeon"
        };

        private static string[] _wildernessGoals = new string[]
        {
            "Locate a dungeon or other site of interest",
            "Assess the scope of a natural or unnatural disaster",
            "Escort an NPC to a destination",
            "Arrive at a destination without being seen by the villain's forces",
            "Stop monsters from raiding caravans and farms",
            "Establish trade with a distant town",
            "Protect a caravan traveling to a dinstant town",
            "Map a new land",
            "Find a place to establish a colony",
            "Find a natural resource",
            "Hunt a specific monster",
            "Return home from a distant place",
            "Obtain information from a reclusive hermit",
            "Find an object that was lost in the wilds",
            "Discover the fate of a missing group of explorers",
            "Pursue fleeing foes",
            "Assess the size of an approaching army",
            "Escape the reign of a tyrant",
            "Protect a wilderness site from attackers"
        };

        private static string[] _otherWildernessGoals = new string[]
        {
            "Seize control of a fortified location such as a Fortress, town, or ship",
            "Defend a location from attackers",
            "Retrieve an object from inside a secure location in a settlement",
            "Retrieve an object from a caravan",
            "Salvage an object or goods from a lost vessel or caravan",
            "Break a prisoner out of a jail or prison camp",
            "Escape from a jail or prison camp",
            "Successfully travel through an obstacle course to gain recognition or reward",
            "Infiltrate a fortified location",
            "Find the source of strange occurrences in a haunted house or other locations",
            "Interfere with the operation of a business",
            "Rescue a character, monster, or object from a natural or unnatural disaster"
        };

        private static string[] _adventureVillians = new string[]
        {
            "Beast or monstrosity with no particular agenda",
            "Aberration bent on corruption or domination",
            "Fiend bent on corruption or domination",
            "Dragon bent on domination and plunder",
            "Giant bent on plunder",
            "Undead with any agenda",
            "Undead with any agenda",
            "Fey with a mysterious goal",
            "Humanoid cultist",
            "Humanoid cultist",
            "Humanoid conqueror",
            "Humanoid conqueror",
            "Humanoid seeking revenge",
            "Humanoid schemer seeking to rule",
            "Humanoid schemer seeking to rule",
            "Humanoid criminal mastermind",
            "Humanoid raider or ravager",
            "Humanoid raider or ravager",
            "Humanoid under a curse",
            "Misguided humanoid zealot"
        };

        private static string[] _adventureAllies = new string[]
        {
            "Skilled adventurer",
            "Inexperienced adventurer",
            "Enthusiastic commoner",
            "Soldier",
            "Priest",
            "Sage",
            "Revenge seeker",
            "Raving lunatic",
            "Celestial ally",
            "Fey ally",
            "Disguised monster",
            "Villain posing as ally"
        };

        private static string[] _adventurePatrons = new string[]
        {
            "Retired adventurer",
            "Retired adventurer",
            "Local ruler",
            "Local ruler",
            "Military officer",
            "Military officer",
            "Temple Official",
            "Temple Official",
            "Sage",
            "Sage",
            "Respected elder",
            "Respected elder",
            "Deity or celestial",
            "Mysterious fey",
            "Old friend",
            "Former teacher",
            "Parent or family member",
            "Desperate commoner",
            "Embattled Merchant",
            "Villain posing as patron"
        };

        private static string[] _adventureIntroduction = new string[]
        {
            "While traveling in the wilderness, the characters fall into a sinkhole that opens beneath their feet, dropping them into the adventure location",
            "While traveling in the wilderness, the characters notice the entrance to the adventure location",
            "While traveling on a road, the characters are attacked by monsters that flee into the nearby adventure location",
            "The adventureers find a map on a dead body.  In addition to the map setting up the adventure, this adventure's villain wants the map",
            "A mysterious magic item or cruel villain teleports the characters to the adventure location",
            "A stranger approaches the characters in a tavern and urges them toward the adventure location",
            "A town or village needs volunteers to go to the adventure location",
            "An NPC the characters care about needs them to go to the adventure location",
            "An NPC the characters respect asks them to go to the adventure location",
            "One night, the characters all dream about entering the adventuring location",
            "A ghost appears and terrorizes a village.  Research reveals that it can be put rest only by entering the adventure location"
        };

        private static string[] _adventureClimax = new string[]
        {
            "The adventurers confront the main villain and a group of minions in a bloody battle to the finish",
            "The adventurers chase the villain while dodging ostacles designed to thwart them, leading to a final confrontation in our outside the villain's refuge",
            "The actions of the adventurers or the villain result in a cataclysmic event thta the adventurers must escape",
            "The adventurers race to the site where the villain is bringing a master plan to its conclusion, arriving just as that plan is about to be completed",
            "The villain and two or three lieutenants perform separate rites in a large rom.  The adventurers must disrupt all the rites at the same time",
            "An ally betrays the adventurers as they're about to achieve their goal.  (Use this climax carefully and sparingly!)",
            "A portal opens to another plane of existence.  Creatures on the other side spill out, forcing the adventurers to close the portal and deal with the villain at the same time",
            "Traps, hazards, or animated objects turn against the adventurers while the main villain attacks",
            "The dungeon begins to collapse while the adventurers face the main villain, who attempts to escape in the chaos",
            "A threat more powerful than the adventurers appears, destroys the main villain, and then turns its attention on the characters",
            "The adventurers must choose whether to pursue the fleeing main villain or save an NPC they care about/a group of innocents",
            "The adventurers must discover the main villain's secret weakness before they can hope to defeat that villain"
        };

        private static string[] _eventVillainActions = new string[]
        {
            "Big event",
            "Crime spree",
            "Growing corruption",
            "One and done",
            "Serial crimes",
            "Step by Step"
        };

        private static string[] _eventGoals = new string[]
        {
            "Bring the villain to justice",
            "Clear the name of an innocent NPC",
            "Protect or hide an NPC",
            "Protect an object",
            "Discover the nature and origin of a strange phenomenon that might be the villain's doing",
            "Find a wanted fugitive",
            "Overthrow a tyrant",
            "Uncover a conspiracy to overthrow a ruler",
            "Negotiate peace between enemy nations or feuding parties",
            "Secure aid from a ruler or council",
            "Help a villain find redemption",
            "Parley with a villain",
            "Smuggle weapons to rebel forces",
            "Stop a band of smugglers",
            "Gather intelligence on an enemy force",
            "Win a tournament",
            "Determine the villain's identity",
            "Locate a stolen item",
            "Make sure a wedding goes off without a hitch",
            "Track down and return an object that was stolen during the event"
        };

        private static string[] _eventFraming = new string[]
        {
            "Anniversary of a monarch's reign",
            "Anniversary of an important event",
            "Arena event",
            "Arrival of a caravan or ship",
            "Arrival of a circus",
            "Arrival of an important NPC",
            "Arrival of marching modrons",
            "Artistic performance",
            "Athletic event",
            "Birth of a child",
            "Birthday of an important NPC",
            "Civic festival",
            "Comet appearance",
            "Commemoration of a past tragedy",
            "Consecration of a new temple",
            "Consecration",
            "Council meeting",
            "Equinox or solstice",
            "Execution",
            "Fertility festival",
            "Full moon",
            "Funeral",
            "Graduation of cadets or wizards",
            "Harvest festival",
            "Holy day",
            "Investiture of a knight or other noble",
            "Lunar eclipse",
            "Midsummer festival",
            "Midwinter festival",
            "Migration of monsters",
            "Monarch's ball",
            "New moon",
            "New year",
            "Pardoning of a prisoner",
            "Planar conjunction",
            "Planetary alignment",
            "Priestly investiture",
            "Procession of ghosts",
            "Remembrance for soldiers lost in war",
            "Royal address or proclamation",
            "Royal audience day",
            "Signing of a treaty",
            "Solar eclipse",
            "Tournament",
            "Trial",
            "Violent uprising",
            "Wedding or wedding anniversary"
        };

        private static string[] _moralQuandries = new string[]
        {
            "Ally quandary",
            "Friend quandary",
            "Honor quandary",
            "Rescue quandary",
            "Respect quandary"
        };

        private static string[] _twists = new string[]
        {
            "The adventurers are racing against other creatures with the same or opposite goal",
            "The adventurers become responsible for the safety of a noncombatant NPC",
            "The adventurers are prohibited from killing the villain, but the villain has no compunctions about killing them",
            "The adventurers have a time limit",
            "The adventurers have received flase or extraneous information",
            "Completing an adventure goal fulfills a prophecy or prevents the fulfillment of a prophecy",
            "The adventurers have two different goals, but they can complete only one",
            "Completing the goal secretly helps the villain",
            "The adventurers must cooperate with a known enemy to achieve the goal",
            "The adventurers are under magical compulsion to complete their goal"
        };

        private static string[] _sideQuests = new string[]
        {
            "Find a specific item rumored to be in the area",
            "Retrieve a stolen item in the villain's possession",
            "Recieve information from an NPC in the area",
            "Rescue a captive",
            "Discover the fate of a missing NPC",
            "Slay a specific monster",
            "Discover the nature and origin of a strange phenomenon in the area",
            "Secure the aid of a character or creature in the room"
        };
        #endregion

        public static void Main(string[] args)
        {
            string output = "";
            //roll 1d2
            int result = Roll(1, 3);
            result = 0;
            Console.WriteLine(result);
            if(result == 0)
            {
                output += "Location: ";
                output += DetermineLocationValues();
            }
            else
            {
                output += "Event: ";
                Event();
            }

            System.Console.WriteLine(output);
            

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numDice"></param>
        /// <param name="numSides"></param>
        /// <returns></returns>
        public static int Roll(int numDice, int numSides)
        {
            List<int> rollList = new List<int>();
            Random dieRoll = new Random();

            for (int i = 0; i < numDice; i++)
            {
                rollList.Add(dieRoll.Next(numSides));
            }

            int result = 0;

            for (int i = 0; i < rollList.Count; i++)
            {
                result += rollList[i];
            }
           
            return result;
        }
        
        #region Locations
        /// <summary>
        /// 
        /// </summary>
        public static string DetermineLocationValues()
        {
            string output = "";
            //roll 1d2
            int result = Roll(1, 2);
            output += SetLocationGoals(result);
            output += "Villains: ";
            output += DetermineVillains();
            output += "Allies: ";
            output += DetermineAllies();
            output += "Adventure Patrons: ";
            output += DeterminePatrons();
            output += "\nAdventure Introduction: \n\n";
            output += GetAdventureIntroduction();
            output += "\nAdventure Climax: \n";
            output += GetAdventureClimax();

            int defaultDifficulty = 4;
            int defaultEncounters = 6;
            int defaultMaxEncounters = 15;
            Console.WriteLine("Enter Max Encounters (" + defaultEncounters + " is default, " + defaultMaxEncounters + " is maximum).  Press Enter to take the default\n");
            string sMaxEncounters = Console.ReadLine().Trim();
            Console.WriteLine("Enter Max difficulty (1 = Easy, 2 = Medium, 3 = Hard, 4 = Deadly.  " + defaultDifficulty + " is default).  Press Enter to take the default\n");
            string sMaxDifficulty = Console.ReadLine().Trim();

            int iMaxEncounters = 1;
            int iMaxDifficulty = 1;

            //This is stupid and ugly and I don't like it. 
            //TODO: Make this less stupid and ugly
            if (sMaxEncounters == "")
            {
                //do nothing, as this is the default
            }
            else if (Convert.ToInt32(sMaxEncounters) > 15)
            {
                iMaxEncounters = 15;
            }
            else if (Convert.ToInt32(sMaxEncounters) < 1)
            {
                iMaxEncounters = 1;
            }
            else
            {
                iMaxEncounters = Convert.ToInt32(sMaxEncounters);
            }

            //This is stupid and ugly and I don't like it. 
            //TODO: Make this less stupid and ugly
            if (sMaxDifficulty == "")
            {
                iMaxEncounters = defaultEncounters;
            }
            else if(Convert.ToInt32(sMaxDifficulty) > 4)
            {
                iMaxDifficulty = 4;
            }
            else if (Convert.ToInt32(sMaxDifficulty) < 1)
            {
                iMaxDifficulty = 1;
            }
            else
            {
                iMaxDifficulty = Convert.ToInt32(sMaxDifficulty);
            }

            output += GetEncounterInformation(iMaxEncounters, iMaxDifficulty);
            return output;


            /*
            //
            // Encounters
            //
            Console.WriteLine("Enter Max Encounters (6 is default, 15 is maximum).  Press Enter to take the default\n");
            string sMaxEncounters = Console.ReadLine().Trim();

            int minEncounters = 1, maxEncounters = 15;                                    // Min/Max valid range
            int dEncounters = 6;                                                          // defaults
            int iEncounters = 0;                                                          // user selection

            if (!Int32.TryParse(sMaxEncounters, out iEncounters))                         // parse user input selections
              iEncounters = dEncounters;

            iEncounters = Math.Max(minEncounters, Math.Min(maxEncounters, iEncounters));  // clamp user input to min/max valid values


            //
            // Difficulty
            //
            Console.WriteLine("Enter Max difficulty (1 = Easy, 2 = Medium, 3 = Hard, 4 = Deadly.  Deadly is default).  Press Enter to take the default\n");
            string sMaxDifficulty = Console.ReadLine().Trim();

            int minDifficulty = 1, maxDifficulty =  4;                                    // Min/Max valid range
            int dDifficulty = 4;                                                          // defaults
            int iDifficulty = 0;                                                          // user selection

            if (!Int32.TryParse(sMaxDifficulty, out iDifficulty))                         // parse user input selections
              iDifficulty = dDifficulty;

            iDifficulty = Math.Max(minDifficulty, Math.Min(maxDifficulty, iDifficulty));  // clamp user input to min/max valid values


            output.AppendLine(GetEncounterInformation(iEncounters, iDifficulty));
            return output.ToString();










    */
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationType"></param>
        public static string SetLocationGoals(int locationType)
        {
            string output = "";
            //Dungeon
            if(locationType == 0)
            {
                output += "Dungeon\nGoal: ";
                output += SetDungeonGoals();
                output += "\n\n";

            }
            else
            {
                output += "Wilderness\nGoal: ";
                output += SetWildernessGoals();
                output += "\n\n";
            }

            return output;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string SetDungeonGoals()
        {
            int result = Roll(1, _dungeonGoals.Length - 1);

            return _dungeonGoals[result];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string SetWildernessGoals()
        {
            int result = Roll(1, _wildernessGoals.Length - 1);
            if(result == 19)
            {
                result = Roll(1, _otherWildernessGoals.Length - 1);
                return _otherWildernessGoals[result];
            }
            return _wildernessGoals[result];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string DetermineVillains()
        {
            int result = Roll(1, _adventureVillians.Length - 1);
            return _adventureVillians[result] + "\n";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string DetermineAllies()
        {
            int result = Roll(1, _adventureAllies.Length - 1);
            return _adventureAllies[result] + "\n";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string DeterminePatrons()
        {
            int result = Roll(1, _adventurePatrons.Length);
            return _adventurePatrons[result] + "\n";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetAdventureIntroduction()
        {
            int result = Roll(1, _adventureIntroduction.Length - 1);
            return _adventureIntroduction[result] + "\n";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetAdventureClimax()
        {
            int result = Roll(1, _adventureClimax.Length);
            return _adventureClimax[result];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxEncounters"></param>
        /// <param name="maxDifficulty"></param>
        /// <returns></returns>
        public static string GetEncounterInformation(int maxEncounters, int maxDifficulty)
        {
            Random rand = new Random();
            int numEncounters = rand.Next(1, maxEncounters);
            List<int> encounterList = new List<int>();

            if (numEncounters == 0)
            {
                numEncounters = 1;
            }
            
            for (int i = 0; i < numEncounters; i++)
            {
                encounterList.Add(rand.Next(1, maxDifficulty));
            }

            string encounters = "\nNumber of encounters: " + numEncounters.ToString();
            encounters += "\nEncounter difficulty:";

            foreach(int e in encounterList)
            {
                switch(e)
                {
                    case 1:
                        encounters += "\n\tEasy";
                        break;
                    case 2:
                        encounters += "\n\tMedium";
                        break;
                    case 3:
                        encounters += "\n\tHard";
                        break;
                    case 4:
                        encounters += "\n\tDeadly";
                        break;
                }
            }
            encounters += "\n";
            return encounters;
        }
        #endregion

        #region Event
        public static string Event()
        {
            string output = "";
            //roll 1d2
            int result = Roll(1, 2);
            output += SetVillainActions();
            output += "\nGoals:\n";
            output += SetEventGoals();
            output += "\nEvent Framing\n";
            output += EventFraming();
            //output += SetLocationGoals(result);
            //output += "Villains: ";
            //output += DetermineVillains();
            //output += "Allies: ";
            //output += DetermineAllies();
            //output += "Adventure Patrons: ";
            //output += DeterminePatrons();
            //output += "\nAdventure Introduction: \n\n";
            //output += GetAdventureIntroduction();
            //output += "\nAdventure Climax: \n";
            //output += GetAdventureClimax();

            return "";
        }

        public static string EventFraming()
        {
            Random rand = new Random();
            int result = Roll(1, _eventFraming.Length);
            if(result == 50)
            {
                rand.Next(0, _eventFraming.Length - 1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string SetEventGoals()
        {
            int result = Roll(1, _eventGoals.Length);
            return _eventGoals[result];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string SetVillainActions()
        {
            int result = Roll(1, _eventVillainActions.Length);

            return _eventVillainActions[result];
        }
        #endregion

    }
}

