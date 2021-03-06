﻿using System;
using com.terranovita.botretreat;

namespace Assets.Custom.Scripts.Domain
{
    public class TopTeam : ICreatableFromJson<TopTeam>
    {
        public String TeamName { get; set; }
        public Int32 NumberOfKills { get; set; }
        public TimeSpan AverageBotLife { get; set; }

        public TopTeam FromJson(JSONObject json)
        {
            TeamName = json.getStringValue("teamName");
            NumberOfKills = json.getIntValue("numberOfKills");
            AverageBotLife = json.getTimeSpanValue("averageBotLife");
            return this;
        }
    }
}