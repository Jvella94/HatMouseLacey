using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Objects;
using StardewValley.Quests;
using System.Collections.Generic;
using System.Linq;

namespace ichortower_HatMouseLacey
{
    internal class LCSaveMigrator
    {
        /*
         * Calls all the other migration functions.
         */
        public void MigrateOldSaveData()
        {
            MigrateCrueltyScore();
            MigrateHatsShown();
            HatJubilee();
            MigrateFriendshipData();
            MigrateSpouse();
            MigrateOldLacey();
            MigrateGiftedItems();
            MigrateSeenEvents();
            MigrateMail();
            MigrateDialogueEvents();
            MigrateQuests();
            MigrateSongsHeard();
        }

        public static string OldInternalName = "HatMouseLacey";
        public static Dictionary<string, string> OldEventMap = new(){
            {"236750200", $"{HML.EventPrefix}2Hearts"},
            {"236750400", $"{HML.EventPrefix}4Hearts"},
            {"236750600", $"{HML.EventPrefix}6Hearts"},
            {"236750800", $"{HML.EventPrefix}8Hearts"},
            {"236750801", $"{HML.EventPrefix}8Hearts"},
            {"236750802", $"{HML.EventPrefix}Apology"},
            {"236751001", $"{HML.EventPrefix}10Hearts"},
            {"236751400", $"{HML.EventPrefix}14Hearts"},
            {"236751401", $"{HML.EventPrefix}14Hearts_Postponed"},
        };
        public static (string eventId, string triggerId) TriggerTuple =
                ("236751000", $"{HML.TriggerActionPrefix}10Hearts");
        public static Dictionary<string, string> OldMailMap = new(){
            {"HatMouseLacey_ApologySummons", $"{HML.MailPrefix}ApologySummons"},
            {"HatMouseLacey_ApologyAccepted", $"{HML.MailPrefix}ApologyAccepted"},
            {"HatMouseLacey_HouseCall", $"{HML.MailPrefix}HouseCall"},
            {"HatMouseLacey_PicnicPostponed", $"{HML.MailPrefix}PicnicPostponed"},
            {"HatMouseLacey_HatReactions", $"{HML.MailPrefix}HatReactions"},
            {"HatMouseLacey_Introduction", $"{HML.LaceyInternalName}_Introduction"},
        };
        public static Dictionary<string, string> OldCTMap = new(){
            {"HatMouseLacey_FirstOfMay", $"{HML.CTPrefix}FirstOfMay"},
        };
        public static Dictionary<string, string> OldQuestMap = new(){
            {"236750210", $"{HML.QuestPrefix}HatReactions"},
            {"236750810", $"{HML.QuestPrefix}Apology"},
        };
        public static Dictionary<string, string> OldSongMap = new(){
            {"HML_Upbeat", $"{HML.MusicPrefix}FittingIn"},
            {"HML_Lonely", $"{HML.MusicPrefix}InALonelyPlace"},
            {"HML_Confession", $"{HML.MusicPrefix}FromAMousesHeart"},
        };

        private static Dictionary<string, List<string>> _JubileeIds = new();

        public void MigrateCrueltyScore()
        {
            // convert save data cruelty score to mod data
            if (Game1.IsMasterGame) {
                LCCrueltyScore cs = HML.ModHelper.Data
                        .ReadSaveData<LCCrueltyScore>("CrueltyScore");
                if (cs != null) {
                    Log.Trace("Migrating cruelty score from save data to mod data");
                    LCModData.SetCrueltyScore(Game1.player, cs.val);
                    HML.ModHelper.Data
                        .WriteSaveData<LCCrueltyScore>("CrueltyScore", null);
                }
            }
            // convert old mod data key to new one
            string oldkey = $"{OldInternalName}/CrueltyScore";
            string newkey = $"{HML.CPId}/CrueltyScore";
            if (Game1.player.modData.TryGetValue(oldkey, out string data)) {
                if (int.TryParse(data, out int num)) {
                    Log.Trace($"Migrating cruelty score '{oldkey}' -> '{newkey}'");
                    LCModData.SetCrueltyScore(Game1.player, num);
                }
                else {
                    Log.Warn($"Removing invalid old data '{oldkey}':'{data}'");
                }
                Game1.player.modData.Remove(oldkey);
            }
        }

        public void MigrateHatsShown()
        {
            // convert save data hats to mod data
            if (Game1.IsMasterGame) {
                LCHatsShown hs = HML.ModHelper.Data
                        .ReadSaveData<LCHatsShown>("HatsShown");
                if (hs != null) {
                    Log.Trace("Migrating hats shown from save data to mod data");
                    StardewValley.Objects.Hat hat = new();
                    foreach (int id in hs.ids) {
                        hat.load($"{id}");
                        LCModData.AddShownHat(Game1.player, $"SV|{hat.Name}");
                    }
                    HML.ModHelper.Data
                        .WriteSaveData<LCHatsShown>("HatsShown", null);
                }
            }
            // convert old mod data key to new one
            string oldkey = $"{OldInternalName}/HatsShown";
            string newkey = $"{HML.CPId}/HatsShown";
            if (Game1.player.modData.TryGetValue(oldkey, out string hats)) {
                Log.Trace($"Migrating hats shown '{oldkey}' -> '{newkey}'");
                Game1.player.modData[newkey] = hats;
                Game1.player.modData.Remove(oldkey);
                // this is just to cause LCModData to read the hat data
                LCModData.HatsShown(Game1.player);
            }
        }

        public void HatJubilee()
        {
            if (_JubileeIds.Count == 0) {
                _JubileeIds = HML.ModHelper.Data.ReadJsonFile
                        <Dictionary<string, List<string>>>("data/hats-by-version.json");
            }
            foreach (var entry in _JubileeIds) {
                string version = entry.Key;
                string modDataKey = $"{HML.CPId}/Jubilee{version.Replace(".","")}";
                if (Game1.player.modData.TryGetValue(modDataKey, out string have)) {
                    continue;
                }
                List<string> toForget = entry.Value;
                Log.Trace($"Hat jubilee ({version})! Forgetting hat reactions " +
                        "introduced in this version.");
                foreach (string hat in toForget) {
                    LCModData.RemoveShownHat(Game1.player, hat);
                }
                Game1.player.modData[modDataKey] = "true";
            }
        }

        public void MigrateFriendshipData()
        {
            var ships = Game1.player.friendshipData;
            if (ships.TryGetValue(OldInternalName, out var friendship)) {
                Log.Trace("Migrating friendship data " +
                        $"'{OldInternalName}' -> '{HML.LaceyInternalName}'");
                ships[HML.LaceyInternalName] = friendship;
                ships.Remove(OldInternalName);
            }
        }

        public void MigrateSpouse()
        {
            if (Game1.player.spouse == OldInternalName) {
                Game1.player.spouse = HML.LaceyInternalName;
            }
        }

        public void MigrateOldLacey()
        {
            foreach (var loc in SaveGame.loaded.locations) {
                foreach (var npc in loc.characters) {
                    if (npc.Name == OldInternalName) {
                        Log.Trace($"Replacing the old Lacey in '{loc.Name}'");
                        npc.Name = HML.LaceyInternalName;
                        npc.reloadData();
                    }
                }
            }
        }

        public void MigrateGiftedItems()
        {
            var gifts = Game1.player.giftedItems;
            if (gifts.TryGetValue(OldInternalName, out var items)) {
                Log.Trace("Migrating gifted item data " +
                        $"'{OldInternalName}' -> '{HML.LaceyInternalName}'");
                gifts[HML.LaceyInternalName] = items;
                gifts.Remove(OldInternalName);
            }
        }

        public void MigrateSeenEvents()
        {
            foreach (var entry in OldEventMap) {
                if (Game1.player.eventsSeen.Remove(entry.Key)) {
                    Log.Trace($"Migrating seen event '{entry.Key}' -> '{entry.Value}'");
                    Game1.player.eventsSeen.Add(entry.Value);
                }
            }
            // special case for the event that's now a trigger action
            if (Game1.player.eventsSeen.Remove(TriggerTuple.eventId)) {
                Log.Trace($"Migrating event '{TriggerTuple.eventId}' " +
                        $"to trigger '{TriggerTuple.triggerId}'");
                Game1.player.triggerActionsRun.Add(TriggerTuple.triggerId);
            }
        }

        public void MigrateMail()
        {
            foreach (var entry in OldMailMap) {
                if (Game1.player.mailReceived.Remove(entry.Key)) {
                    Log.Trace($"Migrating received mail '{entry.Key}' -> '{entry.Value}'");
                    Game1.player.mailReceived.Add(entry.Value);
                }
                else if (Game1.player.mailForTomorrow.Remove(entry.Key)) {
                    Log.Trace($"Migrating mail for tomorrow '{entry.Key}' -> '{entry.Value}'");
                    Game1.player.mailForTomorrow.Add(entry.Value);
                }
                // mailbox is a List and not a HashSet so the check differs
                else if (Game1.player.mailbox.Contains(entry.Key)) {
                    Log.Trace($"Migrating mailbox '{entry.Key}' -> '{entry.Value}'");
                    Game1.player.mailbox.Remove(entry.Key);
                    Game1.player.mailbox.Add(entry.Value);
                }
            }
        }

        public void MigrateDialogueEvents()
        {
            var dict = Game1.player.activeDialogueEvents;
            foreach (var entry in OldCTMap) {
                if (dict.ContainsKey(entry.Key)) {
                    Log.Trace($"Migrating active CT '{entry.Key}' -> '{entry.Value}'");
                    dict.Add(entry.Value, dict[entry.Key]);
                    dict.Remove(entry.Key);
                }
            }
        }

        public void MigrateQuests()
        {
            for (int i = Game1.player.questLog.Count - 1; i >= 0; --i) {
                var quest = Game1.player.questLog[i];
                // delivery quests don't have an id. HasId/isValidId are
                // protected, so null-check it directly (for now?)
                // (ContainsKey barfs if arg is null)
                if (quest.id.Value != null && OldQuestMap.ContainsKey(quest.id.Value)) {
                    string newId = OldQuestMap[quest.id.Value];
                    Log.Trace($"Migrating quest '{quest.id.Value}' -> '{newId}'");
                    Game1.player.questLog.RemoveAt(i);
                    Game1.player.questLog.Add(Quest.getQuestFromId(newId));
                }
            }
        }

        public void MigrateSongsHeard()
        {
            foreach (var entry in OldSongMap) {
                if (Game1.player.songsHeard.Remove(entry.Key)) {
                    Log.Trace($"Migrating heard song '{entry.Key}' -> '{entry.Value}'");
                    Game1.player.songsHeard.Add(entry.Value);
                }
            }
        }

    }
}
