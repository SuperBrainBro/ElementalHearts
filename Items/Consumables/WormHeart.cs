using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
	internal class WormHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 5");
			DisplayName.SetDefault("Worm Heart");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = -12;
			item.value = 0;
			item.expert = true;
		}

		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().WormLife <
				   player.GetModPlayer<ElementalHeartsPlayer>().ElementalHeartMax;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 5;
			player.statLife += 5;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(5, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().WormLife += 1;
			return true;
		}
	}
}
