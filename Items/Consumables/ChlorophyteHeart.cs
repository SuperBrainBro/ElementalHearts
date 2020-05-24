using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
	internal class ChlorophyteHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 12");
			DisplayName.SetDefault("Chlorophyte Heart");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = ItemRarityID.Lime;
			item.value = 0;
		}

		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().ChlorophyteLife <
				   ElementalHeartsPlayer.maxChlorophyteLife;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 12;
			player.statLife += 12;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(12, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().ChlorophyteLife += 1;
			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ChlorophyteOre, 100);;
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
