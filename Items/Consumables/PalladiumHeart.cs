using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
	internal class PalladiumHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 9");
			DisplayName.SetDefault("Palladium Heart");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = 3;
			item.value = 0;
		}

		public override bool CanUseItem(Player player)
		{
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().PalladiumLife < 1;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 9;
			player.statLife += 9;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(9, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().PalladiumLife += 1;
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(1104, 100);;
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
