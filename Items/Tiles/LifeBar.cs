using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Tiles
{
    public class LifeBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Life Bar");
            string tooltip = @"Can be used to craft various ancient life things.";
            if (Main.hardMode) tooltip += "\n'Very similar to palladium...'";
            Tooltip.SetDefault(tooltip);
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Orange;
            item.width = 15;
            item.height = 12;
            item.maxStack = 999;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 10;
            item.useAnimation = 10;
            item.createTile = mod.TileType("LifeBarTile");
            item.autoReuse = true;
            item.value = 4000;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("LifeOre"), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
