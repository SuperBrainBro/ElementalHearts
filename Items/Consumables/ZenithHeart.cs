using ElementalHearts.Items.Consumables.Bosses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Consumables
{
    internal class ZenithHeart : ConsumableHeartItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 10");
            DisplayName.SetDefault("Zenith Heart");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            item.rare = ItemRarityID.Red;
            item.value = 0;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().ZenithLife <
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
            player.GetModPlayer<ElementalHeartsPlayer>().ZenithLife += 1;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CopperHeart>());
            recipe.AddIngredient(ModContent.ItemType<CandyCaneHeart>());
            recipe.AddIngredient(ModContent.ItemType<EnchantedHeart>());
            recipe.AddIngredient(ModContent.ItemType<HoneyHeart>());
            recipe.AddIngredient(ModContent.ItemType<SunplateHeart>());
            recipe.AddIngredient(ModContent.ItemType<ChlorophyteHeart>());
            recipe.AddIngredient(ModContent.ItemType<HorsemansHeart>());
            recipe.AddIngredient(ModContent.ItemType<XenoHeart>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
