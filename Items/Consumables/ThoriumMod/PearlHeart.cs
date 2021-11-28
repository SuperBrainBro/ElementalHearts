using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod.Items.Depths;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables.ThoriumMod
{
    internal class PearlHeart : ThoriumCrossModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 1");
            DisplayName.SetDefault("Pearl Heart");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            //item.rare = ItemRarityID.LightPurple;
            item.value = 0;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().PearlLife <
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
            player.GetModPlayer<ElementalHeartsPlayer>().PearlLife += 1;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Pearl>(), 25);
            recipe.AddIngredient(ItemID.StoneBlock, 75);
            recipe.AddTile(TileID.Extractinator);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
