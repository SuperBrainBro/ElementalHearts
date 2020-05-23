using ElementalHearts.Items.Dev.CAT;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items
{
	public class BossBags : GlobalItem
	{
		public override void OpenVanillaBag(string context, Player player, int arg) {
			if (context == "bossBag" && Main.hardMode) {
				if (Main.rand.Next(20)) {
					player.QuickSpawnItem(ItemType<MaskOfCAT>(), Main.rand.Next(1, 1));
					player.QuickSpawnItem(ItemType<RobeOfCAT>(), Main.rand.Next(1, 1));
					player.QuickSpawnItem(ItemType<HeartOfCAT>(), Main.rand.Next(1, 1));
				}
			}
		}
	}
}