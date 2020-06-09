using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables.CalamityMod
{
	internal class ScoriaHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 1");
			DisplayName.SetDefault("Scoria Heart");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			//item.rare = ItemRarityID.LightPurple;
			item.value = 0;
		}

		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().ScoriaLife <
				   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 1;
			player.statLife += 1;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(1, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().ScoriaLife += 1;
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod calamityMod = ModLoader.GetMod("CalamityMod");
			if (calamityMod != null) {
				recipe.AddIngredient(calamityMod.ItemType("ChaoticOre"), 100); ;
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult(this, 1);
				recipe.AddRecipe();
			}
		}
	}
}
