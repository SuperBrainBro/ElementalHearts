using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    internal class LuminiteHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 9");
            DisplayName.SetDefault("Luminite Heart");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.Red;
            item.value = 0;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().LuminiteLife <
                   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool UseItem(Player player)
        {
            player.statLifeMax2 += 9;
            player.statLife += 9;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(9, true);
            }
            player.GetModPlayer<ElementalHeartsPlayer>().LuminiteLife += 1;
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarOre, 1000000);
            recipe.AddIngredient(ItemID.FragmentVortex, 100000);
            recipe.AddIngredient(ItemID.FragmentNebula, 100000);
            recipe.AddIngredient(ItemID.FragmentSolar, 100000);
            recipe.AddIngredient(ItemID.FragmentStardust, 100000);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
