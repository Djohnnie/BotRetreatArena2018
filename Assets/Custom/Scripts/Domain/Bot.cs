using System;

namespace com.terranovita.botretreat
{
    public class Bot : ICreatableFromJson<Bot>
    {

        public String Id { get; set; }

        public String Name { get; set; }

        //public string Color { get; set; }

        public Position Location { get; set; }

        public Orientation Orientation { get; set; }

        public Health PhysicalHealth { get; set; }

        public Health MentalHealth { get; set; }

        public Health Stamina { get; set; }

        public LastAction LastAction { get; set; }

        public Position LastAttackLocation { get; set; }

        public Bot FromJson(JSONObject json)
        {
            Id = json.getStringValue("id");
            Name = json.getStringValue("name");
            Location = new Position
            {
                X = json.getIntValue("locationX"),
                Y = json.getIntValue("locationY"),
            };
            Orientation = json.getEnumValue<Orientation>("orientation");
            PhysicalHealth = new Health
            {
                Maximum = json.getIntValue("maximumPhysicalHealth"),
                Current = json.getIntValue("currentPhysicalHealth"),
                Drain = json.getIntValue("physicalHealthDrain"),
            };
            MentalHealth = new Health
            {
                Maximum = json.getIntValue("maximumMentalHealth"),
                Current = json.getIntValue("currentMentalHealth"),
                Drain = json.getIntValue("mentalHealthDrain"),
            };
            Stamina = new Health
            {
                Maximum = json.getIntValue("maximumStamina"),
                Current = json.getIntValue("currentStamina"),
                Drain = json.getIntValue("staminaDrain"),
            };

            if (json.GetField("stats") != null && json.GetField("stats").GetField("hp") != null)
            {
                PhysicalHealth = new Health();
                PhysicalHealth.Current = (int)json.GetField("stats").GetField("hp").n;
                PhysicalHealth.Maximum = (int)json.GetField("stats").GetField("maxHp").n;
            }


            LastAction = json.getEnumValue<LastAction>("lastAction");
            LastAttackLocation = new Position
            {
                X = json.getIntValue("lastAttackLocationX"),
                Y = json.getIntValue("lastAttackLocationY"),
            };
            return this;
        }
    }
}
