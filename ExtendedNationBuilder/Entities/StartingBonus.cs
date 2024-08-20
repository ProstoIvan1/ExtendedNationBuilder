using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedNationBuilder.Entities
{
    public record StartingBonus : IEntity
    {
        public StartingBonus(string id, string name)
        {
            this.id = id.ClearId();
            Name = name;
        }

        private string id;
        public string Id
        {
            get => "TECHAGE1-STARTUPBONUS-" + id;
        }
        public string Name { get; }

        public override string ToString() => Name;
    }

    public static class AllStartingBonuses
    {
        public static StartingBonus[] Get { get; } =
        [
            new StartingBonus("RANDOM", "Random"),
            new StartingBonus("WARBAND", "Age I: Warband Unit"),
            new StartingBonus("ARCHER", "Age I: Archer Unit"),
            new StartingBonus("SCOUT", "Age I: Scout Unit"),
            new StartingBonus("SMILODON", "Age I: Smilodon Unit"),
            new StartingBonus("WHEATFARMER", "Age I: Wheat Cultivator Unit"),
            new StartingBonus("WARFARE", "Age I: + Warfare XP"),
            new StartingBonus("EXPLORATION", "Age I: + Exploration XP"),
            new StartingBonus("IMPROVEMENT", "Age I: + Improvement Points"),
            new StartingBonus("INNOVATION", "Age I: + Innovation"),
            new StartingBonus("PROSPECTOR_MARBLE", "Age II: Marble Prospector Unit"),
            new StartingBonus("HORTICULTURIST", "Age II: Horticulturist Unit"),
            new StartingBonus("ANIMALCULTURIST", "Age II: Animal Cultivator Unit"),
            new StartingBonus("ENGINEERING", "Age II: + Engineering XP"),
            new StartingBonus("DIPLOMACY", "Age II: + Diplomacy XP"),
            new StartingBonus("ARTS", "Age III: + Arts XP"),
            new StartingBonus("CAPITAL_CULTURE", "Homeland: + Culture"),
            new StartingBonus("STARTING_VASSAL_PROSPERITY", "Settled Vassals: + Prosperity"),
            new StartingBonus("CAPITAL_FOOD", "Regional: + Food"),
            new StartingBonus("CAPITAL_PRODUCTION", "Regional: + Production"),
            new StartingBonus("CAPITAL_INFLUENCE", "Regional: + Influence"),
            new StartingBonus("CAPITAL_UNREST", "Regional: + Unrest Suppression"),
            new StartingBonus("CAPITAL_WEALTH", "Regional: + Wealth"),
            new StartingBonus("CHEAPER_SETTLERS", "Discounted: Settlers"),
            new StartingBonus("CHEAPER_ENVOYS", "Discounted: Envoys"),
            new StartingBonus("CHEAPER_PIONEER", "Discounted: Pioneers"),
            new StartingBonus("CHEAPER_CLAIMTERRITORY", "Discounted: \"Claim Territory\""),
            new StartingBonus("CHEAPER_RUSH_COST", "Discounted: Rush Production"),
            new StartingBonus("FASTER_SCOUTS", "+Movement: Scouts"),
            new StartingBonus("FASTER_NONCOMBATANTS", "+Movement: Non-Combatants"),
            new StartingBonus("FASTER_NAVY", "+Movement: Naval Units"),
            new StartingBonus("IMPROVED_LEADER_TACTICS", "+Tactics: Leader Units"),
        ];

        public static StartingBonus GetRandom()
        {
            Random random = new Random();
            int i = random.Next(Get.Length);
            return Get[i];
        }

        public static StartingBonus GetValue(string id)
        {
            foreach(var bonus in Get)
            {
                if(bonus.Id == id) return bonus;
            }

            throw new Exception("Not found");
        }
    }
}
