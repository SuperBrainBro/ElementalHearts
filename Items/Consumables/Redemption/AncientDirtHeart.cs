using Redemption.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables.Redemption
{
    internal class AncientDirtHeart : LaugicalityCrossModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 1");
            DisplayName.SetDefault("Ancient Dirt Heart");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.Blue;
            item.value = 0;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer2>().AncientDirtLife <
                   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
        }

        public override bool UseItem(Player player)
        {
            player.statLifeMax2 += 1;
            player.statLife += 1;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(1, true);
            }
            player.GetModPlayer<ElementalHeartsPlayer2>().AncientDirtLife += 1;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<AncientDirt>(), 100);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
