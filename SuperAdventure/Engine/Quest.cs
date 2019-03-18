﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Quest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RewardExperiencePoints { get; set; }
        public int RewardGold { get; set; }
        public Item RewardItem { get; set; }

        public List<QuestCompletionItem> QuestCompletionItems { set; get; }

        public Quest(int id, string name, string description, int rewardexperiencepoints, int rewardGold)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.RewardExperiencePoints = rewardexperiencepoints;
            this.RewardGold = rewardGold;

            this.QuestCompletionItems = new List<QuestCompletionItem>();
        }
    }
}