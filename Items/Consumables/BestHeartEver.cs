using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    internal class BestHeartEver : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 1");
            DisplayName.SetDefault("Rainbow Menacing Lunar Ancient Fleshy Celestial Royal Wormy Volatile Fishark with Googly Eyes and Brains of the Hives and Plants Idol Iron Heart with Solar Power MK2 +");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.Orange;
            item.value = 0;
            item.value = Item.sellPrice(copper: 1);
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer2>().BestLife <
                   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool UseItem(Player player)
        {
            player.statLifeMax2 += 2;
            player.statLife += 2;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(2, true);
            }
            player.GetModPlayer<ElementalHeartsPlayer2>().BestLife += 1;
            return true;
        }
    }
}
