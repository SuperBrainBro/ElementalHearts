using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
	internal class DemoniteHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 7");
			DisplayName.SetDefault("Demonite Heart");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = 1;
			item.value = 0;
		}

		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().DemoniteLife <
				   ElementalHeartsPlayer.maxDemoniteLife;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 7;
			player.statLife += 7;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(7, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().DemoniteLife += 1;
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(56, 100);;
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
