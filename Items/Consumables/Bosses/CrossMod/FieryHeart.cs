using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables.Bosses.CrossMod
{
    internal class FieryHeart : ElementsAwokenCrossModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 15");
            DisplayName.SetDefault("Fiery Heart");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.Expert;
            item.value = 0;
            item.expert = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().FieryLife <
                   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool UseItem(Player player)
        {
            player.statLifeMax2 += 15;
            player.statLife += 15;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(15, true);
            }
            player.GetModPlayer<ElementalHeartsPlayer>().FieryLife += 1;
            return true;
        }
    }
}
