using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
	internal class StoneHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 1");
			DisplayName.SetDefault("Stone Heart");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = ItemRarityID.White;
			item.value = 0;
		}

		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().StoneLife <
				   player.GetModPlayer<ElementalHeartsPlayer>().ElementalHeartMax;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 1;
			player.statLife += 1;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(1, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().StoneLife += 1;
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 100);;
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
