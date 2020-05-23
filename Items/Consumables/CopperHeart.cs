using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
	internal class CopperHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 3");
			DisplayName.SetDefault("Copper Heart");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = ItemRarityID.White;
			item.value = 0;
		}

		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().CopperLife <
				   ElementalHeartsPlayer.maxCopperLife;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 3;
			player.statLife += 3;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(3, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().CopperLife += 1;
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CopperOre, 100);;
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<TinHeart>());
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
