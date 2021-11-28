﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    internal class PinkIceHeart : ConsumableHeartItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 5");
            DisplayName.SetDefault("Pink Ice Heart");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.LightRed;
            item.value = 0;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().PinkIceLife <
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
            player.GetModPlayer<ElementalHeartsPlayer>().PinkIceLife += 1;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.PinkIceBlock, 100); ;
            recipe.AddTile(TileID.IceMachine);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
