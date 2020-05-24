using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
	internal class DemonHeartMK2Heart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 6");
			DisplayName.SetDefault("Demon Heart MK2");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = ItemRarityID.White;
			item.value = 0;
		}

		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().DemonHeartMK2Life <
				   ElementalHeartsPlayer.maxDemonHeartMK2Life;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 6;
			player.statLife += 6;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(6, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().DemonHeartMK2Life += 1;
			return true;
		}
	}
}
