﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    internal class PearlsandHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 5");
            DisplayName.SetDefault("Pearlsand Heart");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.LightRed;
            item.value = 0;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().PearlsandLife <
                   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool UseItem(Player player)
        {
            player.statLifeMax2 += 5;
            player.statLife += 5;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(5, true);
            }
            player.GetModPlayer<ElementalHeartsPlayer>().PearlsandLife += 1;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PearlsandBlock, 1000000);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
