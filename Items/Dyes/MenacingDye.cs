using Terraria.ModLoader;
using Terraria.ID;
using ElementalHearts.Items.Tiles;
using Terraria;
using Microsoft.Xna.Framework;

namespace ElementalHearts.Items.Dyes
{
    public class MenacingDye : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 99;
            item.value = 10000;
            item.rare = ItemRarityID.Orange;
        }
        public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
        {
            color = new Color(Main.DiscoColor.R + 255, Main.DiscoColor.G, Main.DiscoColor.B);
            base.DrawArmorColor(drawPlayer, shadow, ref color, ref glowMask, ref glowMaskColor);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Menacing Dye");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.RedDye);
            recipe.AddIngredient(ModContent.ItemType<LifeOre>(), 5);
            recipe.AddTile(TileID.DyeVat);
            recipe.SetResult(this);
            recipe.AddRecipe();
            base.AddRecipes();
        }
    }
}
