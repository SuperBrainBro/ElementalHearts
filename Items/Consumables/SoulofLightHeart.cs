using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    internal class SoulofLightHeart : ConsumableHeartItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 4");
            DisplayName.SetDefault("Soul of Light Heart");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.Pink;
            item.value = 0;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().SoulofLightLife <
                   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool UseItem(Player player)
        {
            player.statLifeMax2 += 4;
            player.statLife += 4;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(4, true);
            }
            player.GetModPlayer<ElementalHeartsPlayer>().SoulofLightLife += 1;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofLight, 100); ;
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
