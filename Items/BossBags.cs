using ElementalHearts.Items.Dev.CAT;
using ElementalHearts.Items.Dev.Lite;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items
{
	public class BossBags : GlobalItem
	{
		public override void OpenVanillaBag(string context, Player player, int arg) {
			//Reroll for devs
			if (context == "bossBag") {
				if (player.name == "CAT") {
					if (Main.rand.NextBool(10))
					{
						player.QuickSpawnItem(ItemType<MaskOfCAT>(), Main.rand.Next(1, 1));
						player.QuickSpawnItem(ItemType<RobeOfCAT>(), Main.rand.Next(1, 1));
						player.QuickSpawnItem(ItemType<WingsOfCAT>(), Main.rand.Next(1, 1));
						if (Main.rand.NextBool(5)) {
							player.QuickSpawnItem(ItemType<CatastrophicEdge>(), Main.rand.Next(1, 1));
						} else if (Main.rand.NextBool(5)) {
							player.QuickSpawnItem(ItemType<CATsThrow>(), Main.rand.Next(1, 1));
						} else if (Main.rand.NextBool(5)) {
							player.QuickSpawnItem(ItemType<HeartOfCAT>(), Main.rand.Next(1, 1));
						} else if (Main.rand.NextBool(5)) {
							if (Main.rand.NextBool(2)) {
								player.QuickSpawnItem(ItemType<TyrantsTear>(), Main.rand.Next(1, 1));
							} else {
								player.QuickSpawnItem(ItemType<TyrantsTear2>(), Main.rand.Next(1, 1));
							}
						} else {
							player.QuickSpawnItem(ItemType<AstralStars>(), Main.rand.Next(1, 1));
						}
					}
				}
				if (player.name == "AstralCat") {
					if (Main.rand.NextBool(10))
					{
						player.QuickSpawnItem(ItemType<MaskOfCAT>(), Main.rand.Next(1, 1));
						player.QuickSpawnItem(ItemType<RobeOfCAT>(), Main.rand.Next(1, 1));
						player.QuickSpawnItem(ItemType<WingsOfCAT>(), Main.rand.Next(1, 1));
						if (Main.rand.NextBool(5)) {
							player.QuickSpawnItem(ItemType<CatastrophicEdge>(), Main.rand.Next(1, 1));
						} else if (Main.rand.NextBool(5)) {
							player.QuickSpawnItem(ItemType<CATsThrow>(), Main.rand.Next(1, 1));
						} else if (Main.rand.NextBool(5)) {
							player.QuickSpawnItem(ItemType<HeartOfCAT>(), Main.rand.Next(1, 1));
						} else if (Main.rand.NextBool(5)) {
							if (Main.rand.NextBool(2)) {
								player.QuickSpawnItem(ItemType<TyrantsTear>(), Main.rand.Next(1, 1));
							} else {
								player.QuickSpawnItem(ItemType<TyrantsTear2>(), Main.rand.Next(1, 1));
							}
						} else {
							player.QuickSpawnItem(ItemType<AstralStars>(), Main.rand.Next(1, 1));
						}
					}
				}
				if (player.name == "Lite")
				{
					if (Main.rand.NextBool(10))
					{
						player.QuickSpawnItem(ItemType<ChestLite>(), Main.rand.Next(1, 1));
						player.QuickSpawnItem(ItemType<MaskLite>(), Main.rand.Next(1, 1));
						player.QuickSpawnItem(ItemType<WingLite>(), Main.rand.Next(1, 1));
						player.QuickSpawnItem(ItemType<CrystalLite>(), Main.rand.Next(1, 1));
					}
				}
			}
			//Normal roll for normies
			if (context == "bossBag") {
				if (Main.rand.NextBool(20)) {
					player.QuickSpawnItem(ItemType<MaskOfCAT>(), Main.rand.Next(1, 1));
					player.QuickSpawnItem(ItemType<RobeOfCAT>(), Main.rand.Next(1, 1));
					player.QuickSpawnItem(ItemType<WingsOfCAT>(), Main.rand.Next(1, 1));
					if (Main.rand.NextBool(5)) {
						player.QuickSpawnItem(ItemType<CatastrophicEdge>(), Main.rand.Next(1, 1));
					} else if (Main.rand.NextBool(5)) {
						player.QuickSpawnItem(ItemType<CATsThrow>(), Main.rand.Next(1, 1));
					} else if (Main.rand.NextBool(5)) {
						player.QuickSpawnItem(ItemType<HeartOfCAT>(), Main.rand.Next(1, 1));
					} else if (Main.rand.NextBool(5)) {
						if (Main.rand.NextBool(2)) {
							player.QuickSpawnItem(ItemType<TyrantsTear>(), Main.rand.Next(1, 1));
						} else {
							player.QuickSpawnItem(ItemType<TyrantsTear2>(), Main.rand.Next(1, 1));
						}
					} else {
						player.QuickSpawnItem(ItemType<AstralStars>(), Main.rand.Next(1, 1));
					}
				}
				if (Main.rand.NextBool(20)) {
					player.QuickSpawnItem(ItemType<ChestLite>(), Main.rand.Next(1, 1));
					player.QuickSpawnItem(ItemType<MaskLite>(), Main.rand.Next(1, 1));
					player.QuickSpawnItem(ItemType<WingLite>(), Main.rand.Next(1, 1));
					player.QuickSpawnItem(ItemType<CrystalLite>(), Main.rand.Next(1, 1));
				}
			}
		}
	}
}