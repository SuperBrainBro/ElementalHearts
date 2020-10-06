﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    internal class IronHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 2");
            DisplayName.SetDefault("Iron Heart");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.Blue;
            item.value = 0;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().IronLife <
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
            player.GetModPlayer<ElementalHeartsPlayer>().IronLife += 1;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronOre, 100); ;
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
