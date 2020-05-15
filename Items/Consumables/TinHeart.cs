using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
	internal class TinHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 3");
			DisplayName.SetDefault("Tin Heart");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = 0;
			item.value = 0;
		}

		public override bool CanUseItem(Player player)
		{
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().TinLife < 1;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 3;
			player.statLife += 3;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(3, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().TinLife += 1;
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TinOre, 100);;
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<CopperHeart>());
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
