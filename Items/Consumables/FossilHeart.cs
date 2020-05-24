using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
	internal class FossilHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 2");
			DisplayName.SetDefault("Fossil Heart");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = ItemRarityID.White;
			item.value = 0;
		}

		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().FossilLife <
				   ElementalHeartsPlayer.maxFossilLife;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 2;
			player.statLife += 2;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(2, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().FossilLife += 1;
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DesertFossil, 100); ;
			recipe.AddTile(TileID.Extractinator);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
