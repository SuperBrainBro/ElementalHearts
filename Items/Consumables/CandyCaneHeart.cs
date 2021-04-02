using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    internal class CandyCaneHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 2");
            DisplayName.SetDefault("Candy Cane Heart");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.Blue;
            item.value = 0;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().CandyCaneLife <
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
            player.GetModPlayer<ElementalHeartsPlayer>().CandyCaneLife += 1;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CandyCaneBlock, 100); ;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.GreenCandyCaneBlock, 100); ;
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Pumpkin, 5);
            recipe.AddIngredient(ItemID.Cactus, 5);
            recipe.AddIngredient(ItemID.Hay, 5);
            recipe.AddIngredient(ItemID.GlowingMushroom, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(ItemID.CandyCaneBlock, 20);
            recipe.AddRecipe();
        }
    }
}
