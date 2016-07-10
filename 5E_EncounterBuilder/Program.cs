using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5E_EncounterBuilder
{
    public class Program
    {
        private const int d2 = 2;
        private const int d4 = 4;
        private const int d6 = 6;
        private const int d8 = 8;
        private const int d10 = 10;
        private const int d12 = 12;
        private const int d20 = 20;
        private static string output = "";
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
            "Arrival of a circus"
        };

        public static void Main(string[] args)
        {
            //roll 1d2
            int result = Roll(1, d2);
            if(result % 2 == 0)
            {
                output += "Location: ";
                Location();
            }
            output += "Event: ";
            Event();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numDice"></param>
        /// <param name="numSides"></param>
        /// <returns></returns>
        public static int Roll(int numDice, int numSides)
        {
            Random dieRoll = new Random();
            //Roll between 1 and the number of sides on the dice
            int result = dieRoll.Next(1, numSides); 
            return result;
        }
        
        public static void Location()
        {
            int result = Roll(1, d2);
            
        }

        public static void LocationGoals(int locationType)
        {
            //Dungeon
            if(locationType == 1)
            {
                output += "Dungeon\nGoal: ";
                output += DungeonGoals();
                output += "\n\n";
            }

        }

        public static string DungeonGoals()
        {
            int result = Roll(1, d20);

            return _dungeonGoals[result];
        }

        public static string WildernessGoals()
        {
            //TODO: Remember that a 20 roll will force a d12 roll for Other Goals
            return "";
        }
        

        public static void Event()
        {

        }
    }
}

