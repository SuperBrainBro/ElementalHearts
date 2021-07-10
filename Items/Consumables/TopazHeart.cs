using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    internal class TopazHeart : ConsumableHeartItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 3");
            DisplayName.SetDefault("Topaz Heart");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.Green;
            item.value = 0;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().TopazLife <
                   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool UseItem(Player player)
        {
            player.statLifeMax2 += 3;
            player.statLife += 3;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(3, true);
            }
            player.GetModPlayer<ElementalHeartsPlayer>().TopazLife += 1;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Topaz, 25);
            recipe.AddIngredient(ItemID.StoneBlock, 75);
            recipe.AddTile(TileID.Extractinator);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
