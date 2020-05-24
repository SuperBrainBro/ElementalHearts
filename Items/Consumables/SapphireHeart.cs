using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
	internal class SapphireHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 3");
			DisplayName.SetDefault("Sapphire Heart");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = 0;
			item.value = 0;
		}

		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().SapphireLife <
				   ElementalHeartsPlayer.maxSapphireLife;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 3;
			player.statLife += 3;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(3, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().SapphireLife += 1;
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(177, 100);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
