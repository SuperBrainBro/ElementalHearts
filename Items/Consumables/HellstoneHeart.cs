using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
	internal class HellstoneHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 8");
			DisplayName.SetDefault("Hellstone Heart");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = 2;
			item.value = 0;
		}

		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().HellstoneLife <
				   ElementalHeartsPlayer.maxHellstoneLife;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 8;
			player.statLife += 8;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(8, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().HellstoneLife += 1;
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(174, 100);;
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
