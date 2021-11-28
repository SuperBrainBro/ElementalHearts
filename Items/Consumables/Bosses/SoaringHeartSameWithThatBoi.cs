using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables.Bosses
{
    internal class SoaringHeartSameWithThatBoi : ConsumableHeartItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 10");
            DisplayName.SetDefault("Soaring Heart");
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
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().SoaringLife <
                   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool UseItem(Player player)
        {
            player.statLifeMax2 += 10;
            player.statLife += 10;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(10, true);
            }
            player.GetModPlayer<ElementalHeartsPlayer>().SoaringLife += 1;
            return true;
        }
    }
}
