using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod.Items.Misc;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables.ThoriumMod
{
    internal class OpalHeart : ThoriumCrossModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Permanently increases maximum life by 1");
            DisplayName.SetDefault("Opal Heart");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.LifeFruit);
            //item.rare = ItemRarityID.LightPurple;
            item.value = 0;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().OpalLife <
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
            player.GetModPlayer<ElementalHeartsPlayer>().OpalLife += 1;
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<Opal>(), 250000);
            recipe.AddIngredient(ItemID.StoneBlock, 750000);
            recipe.AddTile(TileID.Extractinator);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
