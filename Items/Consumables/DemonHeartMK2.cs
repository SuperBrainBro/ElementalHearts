using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
	internal class DemonHeartMK2 : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 10");
			DisplayName.SetDefault("Demon Heart MK2");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = -12;
			item.value = 0;
			item.expert = true;
		}

		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().DemonHeartMK2Life <
				   player.GetModPlayer<ElementalHeartsPlayer>().ElementalHeartMax;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 10;
			player.statLife += 10;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(10, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().DemonHeartMK2Life += 1;
			return true;
		}
	}
}
