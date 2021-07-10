using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    internal class HeartofDiscord : ConsumableHeartItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 6");
            DisplayName.SetDefault("Heart of Discord");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.Lime;
            item.value = 0;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().LifeofDiscord <
                   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool UseItem(Player player)
        {
            player.statLifeMax2 += 6;
            player.statLife += 6;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(6, true);
            }
            player.GetModPlayer<ElementalHeartsPlayer>().LifeofDiscord += 1;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteOre, 100); ;
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
