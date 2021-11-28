﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
    internal class MechanicalHeart : ConsumableHeartItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 10");
            DisplayName.SetDefault("Mechanical Heart");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = -12;
            item.value = 0;
            item.expert = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().MechanicalLife <
                   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool UseItem(Player player)
        {
            player.statLifeMax2 += 10;
            player.statLife += 10;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(10, true);
            }
            player.GetModPlayer<ElementalHeartsPlayer>().MechanicalLife += 1;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<MechanicalCrystalPiece1>());
            recipe.AddIngredient(ItemType<MechanicalCrystalPiece2>());
            recipe.AddIngredient(ItemType<MechanicalCrystalPiece3>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
