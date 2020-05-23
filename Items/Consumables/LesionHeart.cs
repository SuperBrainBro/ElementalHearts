using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
	internal class LesionHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 6");
			DisplayName.SetDefault("Lesion Heart");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = ItemRarityID.White;
			item.value = 0;
		}

		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().LesionLife <
				   ElementalHeartsPlayer.maxLesionLife;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 6;
			player.statLife += 6;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(6, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().LesionLife += 1;
			return true;
		}

		/*I remove recipe because 1.4 still not out (on tModLoader) :P
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LesionBlock, 100); ;
			recipe.AddTile(TileID.LesionCloningVat);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}*/
	}
}
