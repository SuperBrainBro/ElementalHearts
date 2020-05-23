using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Dev.Lite
{
	internal class CrystalLite : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently increases maximum life by 20"
							+ "\n'Great for impersonating devs!'");
			DisplayName.SetDefault("Crystal Lite");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = ItemRarityID.Cyan;
			item.value = 0;
		}

		public override bool CanUseItem(Player player) {
			return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().CrystalLite <
				   ElementalHeartsPlayer.maxCrystalLite;
		}

		public override bool UseItem(Player player) {
			player.statLifeMax2 += 20;
			player.statLife += 20;
			if (Main.myPlayer == player.whoAmI) {
				player.HealEffect(20, true);
			}
			player.GetModPlayer<ElementalHeartsPlayer>().CrystalLite += 1;
			return true;
		}
	}
}
