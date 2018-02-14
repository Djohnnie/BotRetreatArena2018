using com.terranovita.botretreat;
using System;

namespace Assets.Custom.Scripts.Domain
{
    public class Message : ICreatableFromJson<Message>
    {
        public String Content { get; set; }
        public String BotName { get; set; }

        public Message FromJson(JSONObject json)
        {
            Content = json.getStringValue("message");
            BotName = json.getStringValue("botName");
            
            return this;
        }
    }
}