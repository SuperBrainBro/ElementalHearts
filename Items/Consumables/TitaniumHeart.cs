using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
	internal class TitaniumHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 11");
			DisplayName.SetDefault("Titanium Heart");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = 3;
			item.value = 0;
		}

		public override bool CanUseItem(Player player)
		{
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().TitaniumLife < 1;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 11;
			player.statLife += 11;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(11, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().TitaniumLife += 1;
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(1106, 100);;
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
