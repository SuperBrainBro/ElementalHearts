using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables.Bosses.CrossMod
{
    internal class BlazingHeart : CalamityCrossModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 15");
            DisplayName.SetDefault("Blazing Heart");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 6));
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
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().BlazingLife <
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
            player.GetModPlayer<ElementalHeartsPlayer>().BlazingLife += 1;
            return true;
        }
    }
}
