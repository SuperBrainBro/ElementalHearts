using ElementalHearts.Items.Accessories;
using ElementalHearts.Items.Consumables.Bosses;
using ElementalHearts.Items.Weapons;
using ElementalHearts.NPCs.Bosses.MenacingHeart;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Boss
{
    public class MenacingLookingHeartBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.consumable = true;
            item.width = 24;
            item.height = 24;
            item.rare = ItemRarityID.Expert;
            item.expert = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void OpenBossBag(Player player)
        {
            if (Main.hardMode)
            {
                player.TryGettingDevArmor();
            }
            if (Main.rand.NextBool(7))
            {
                //player.QuickSpawnItem(ItemType<AbominationMask>());
            }
            player.QuickSpawnItem(ItemType<MenacingLookingPendant>());
            player.QuickSpawnItem(ItemType<MenacingHeartItem>());
            if (Main.rand.NextBool(3))
            {
                player.QuickSpawnItem(ItemType<MenacingLifeStaff>());
            }
            else if (Main.rand.NextBool(3))
            {
                player.QuickSpawnItem(ItemType<MenacingLifeBlade>());
            }
            else
            {
                player.QuickSpawnItem(ItemType<MenacingHeartKeeper>());
            }
        }

        public override int BossBagNPC => NPCType<MenacingHeart>();
    }
}