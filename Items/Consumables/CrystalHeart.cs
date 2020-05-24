using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
	internal class CrystalHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 9");
			DisplayName.SetDefault("Crystal Heart");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = ItemRarityID.Blue;
			item.value = 0;
		}

		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().CrystalLife <
				   ElementalHeartsPlayer.maxCrystalLife;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 9;
			player.statLife += 9;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(9, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().CrystalLife += 1;
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrystalBlock, 100);;
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
