using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
	internal class CandyCaneHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 3");
			DisplayName.SetDefault("Candy Cane Heart");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = ItemRarityID.White;
			item.value = 0;
		}

		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().CandyCaneLife <
				   ElementalHeartsPlayer.maxCandyCaneLife;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 3;
			player.statLife += 3;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(3, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().CandyCaneLife += 3;
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CandyCaneBlock, 100);;
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GreenCandyCaneBlock, 100); ;
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Pumpkin, 5);
			recipe.AddIngredient(ItemID.Cactus, 5);
			recipe.AddIngredient(ItemID.Hay, 5);
			recipe.AddIngredient(ItemID.GlowingMushroom, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(ItemID.CandyCaneBlock, 20);
			recipe.AddRecipe();
		}
	}
}
