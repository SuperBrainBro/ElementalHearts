using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables.ThoriumMod
{
	internal class IllumiteHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 1");
			DisplayName.SetDefault("Illumite Heart");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			//item.rare = ItemRarityID.LightPurple;
			item.value = 0;
		}

		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().IllumiteLife <
				   ModContent.GetInstance<ElementalHeartsConfig>().MaxElementalHeartConfig;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 1;
			player.statLife += 1;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(1, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().IllumiteLife += 1;
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			Mod thoriumMod = ModLoader.GetMod("ThoriumMod");
			if (thoriumMod != null) {
				recipe.AddIngredient(thoriumMod.ItemType("IllumiteChunk"), 100); ;
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult(this, 1);
				recipe.AddRecipe();
			}
		}
	}
}
