using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    internal class TitaniumHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 7");
            DisplayName.SetDefault("Titanium Heart");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.LightPurple;
            item.value = 0;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().TitaniumLife <
                   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool UseItem(Player player)
        {
            player.statLifeMax2 += 7;
            player.statLife += 7;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(7, true);
            }
            player.GetModPlayer<ElementalHeartsPlayer>().TitaniumLife += 1;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumOre, 1000000); ;
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
