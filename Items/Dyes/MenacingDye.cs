using ElementalHearts.Items.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            byte dye = item.dye;
            item.CloneDefaults(ItemID.GelDye);
            item.dye = dye;
        }
        public override void DrawArmorColor(Player drawPlayer, float shadow, ref Color color, ref int glowMask, ref Color glowMaskColor)
        {
            color = new Color(255, 0, 0);
            glowMaskColor = new Color(255, 0, 0);
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
