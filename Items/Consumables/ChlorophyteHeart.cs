using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    internal class ChlorophyteHeart : ConsumableHeartItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 8");
            DisplayName.SetDefault("Chlorophyte Heart");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.Lime;
            item.value = 0;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().ChlorophyteLife <
                   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool UseItem(Player player)
        {
            player.statLifeMax2 += 8;
            player.statLife += 8;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(8, true);
            }
            player.GetModPlayer<ElementalHeartsPlayer>().ChlorophyteLife += 1;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ChlorophyteOre, 100); ;
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
