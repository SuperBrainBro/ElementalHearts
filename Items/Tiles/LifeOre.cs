using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Tiles
{
    public class LifeOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Life Ore");
            Tooltip.SetDefault("Can be used to craft various life crystal related items.");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Orange;
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 10;
            item.useAnimation = 10;
            item.createTile = mod.TileType("LifeOreTile");
            item.autoReuse = true;
            item.value = 10000;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.LifeCrystal, 1);
            recipe.AddRecipe();
        }
    }
}
