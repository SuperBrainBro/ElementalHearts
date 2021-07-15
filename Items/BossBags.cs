using System.Collections.Generic;
using ElementalHearts.Items.Dev.AppleInTheSky;
using ElementalHearts.Items.Dev.CAT;
using ElementalHearts.Items.Dev.Lite;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items
{
    public class BossBags : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;

        private void DevSetToDrop(string type, Player player)
        {
            switch (type)
            {
                case "Lite":
                    player.QuickSpawnItem(ItemType<LegLite>());
                    player.QuickSpawnItem(ItemType<ChestLite>());
                    player.QuickSpawnItem(ItemType<MaskLite>());
                    player.QuickSpawnItem(ItemType<WingLite>());
                    break;

                case "Fox":
                    //player.QuickSpawnItem(ItemType<MaskOfCAT>());
                    //player.QuickSpawnItem(ItemType<RobeOfCAT>());
                    //player.QuickSpawnItem(ItemType<WingsOfCAT>());
                    break;

                case "Apple":
                    player.QuickSpawnItem(ItemType<EvenFlameWings>());
                    break;
            }
        }

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag")
            {
                if (Main.rand.NextBool(100))
                {
                    //DevSetToDrop("Fox", player);
                }
                if (Main.rand.NextBool(100))
                {
                    DevSetToDrop("Lite", player);
                }
                if (Main.rand.NextBool(100))
                {
                    DevSetToDrop("Apple", player);
                }
            }
        }

        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.LifeCrystal)
            {
                item.consumable = true;
            }
        }

        public override bool CanUseItem(Item item, Player player)
        {
            if (item.type == ItemID.LifeCrystal && GetInstance<ElementalHeartsConfig>().VanillaChangesConfig)
            {
                return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().Life <
                       GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
            }
            return base.CanUseItem(item, player);
        }

        public override bool UseItem(Item item, Player player)
        {
            if (item.type == ItemID.LifeCrystal && GetInstance<ElementalHeartsConfig>().VanillaChangesConfig)
            {
                player.statLifeMax2 += 1;
                player.statLife += 1;
                if (Main.myPlayer == player.whoAmI)
                {
                    player.HealEffect(1, true);
                }
                player.GetModPlayer<ElementalHeartsPlayer>().Life += 1;
                return true;
            }
            return base.UseItem(item, player);
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemID.LifeCrystal && GetInstance<ElementalHeartsConfig>().VanillaChangesConfig)
            {
                tooltips.RemoveAt(2);
                tooltips.Insert(2, new TooltipLine(mod, "Elemental Hearts: Life Crystal Tooltip",
                    Language.GetTextValue("Mods.ElementalHearts.ItemNewTooltip.LifeCrystal")));
            }
        }
    }
}