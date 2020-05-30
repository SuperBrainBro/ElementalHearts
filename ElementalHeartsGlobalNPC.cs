using ElementalHearts.Items.Consumables;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts
{
	public class ElementalHeartsGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		
		public bool curseCATsCurse;

		public override void ResetEffects(NPC npc) {
			curseCATsCurse = false;
		}
		public override void NPCLoot(NPC npc)
		{
			//Brain Of Cthulu Expert Drop
			if (npc.type == NPCID.BrainofCthulhu && Main.expertMode)
			{
				Item.NewItem(npc.getRect(), ItemType<BrainHeart>());
			}

			//Eater Of Worlds Expert Drop
			int HC = NPC.CountNPCS(NPCID.EaterofWorldsHead);
			int BC = NPC.CountNPCS(NPCID.EaterofWorldsBody);
			int TC = NPC.CountNPCS(NPCID.EaterofWorldsTail);
			if (HC == 0 && BC == 0 && TC == 1 && Main.expertMode) //incase the tail is the last thing killed
			{
				Item.NewItem(npc.getRect(), ItemType<WormHeart>());
			}
			if (HC == 0 && BC == 1 && TC == 0 && Main.expertMode) //incase the Body is the last thing killed
			{
				Item.NewItem(npc.getRect(), ItemType<WormHeart>());
			}
			if (HC == 1 && BC == 0 && TC == 0 && Main.expertMode) //incase the Head is the last thing killed
			{
				Item.NewItem(npc.getRect(), ItemType<WormHeart>());
			}

			//Wall Of Flesh Expert Drop
			if (npc.type == NPCID.WallofFlesh && Main.expertMode)
			{
				Item.NewItem(npc.getRect(), ItemType<DemonHeartMK2>());
			}

			//Mechanical Pieces
			int TS = NPC.CountNPCS(NPCID.Spazmatism);
			int TR = NPC.CountNPCS(NPCID.Retinazer);
			if (TS == 0 && TR == 1 && Main.expertMode) //incase Retinazer is the last thing killed
			{
				Item.NewItem(npc.getRect(), ItemType<MechanicalCrystalPiece1>());
			}
			if (TS == 1 && TR == 0 && Main.expertMode) //incase Spazmatism is the last thing killed
			{
				Item.NewItem(npc.getRect(), ItemType<MechanicalCrystalPiece1>());
			}

			if (npc.type == NPCID.TheDestroyer && Main.expertMode)
			{
				Item.NewItem(npc.getRect(), ItemType<MechanicalCrystalPiece2>());
			}

			if (npc.type == NPCID.SkeletronPrime && Main.expertMode)
			{
				Item.NewItem(npc.getRect(), ItemType<MechanicalCrystalPiece3>());
			}
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage) {
			if (curseCATsCurse) {
				if (npc.lifeRegen > 0) {
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 128;
				if (damage < 24) {
					damage = 24;
				}
			}
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot) {
			if (type == NPCID.PartyGirl) {
				shop.item[nextSlot].SetDefaults(ItemType<BubbleHeart>());
				shop.item[nextSlot].shopCustomPrice = 20000;
				nextSlot++;
			}
			if (type == NPCID.Merchant)
			{
				shop.item[nextSlot].SetDefaults(ItemType<EmptyHeart>());
				shop.item[nextSlot].shopCustomPrice = 10000;
				nextSlot++;
			}
			if (type == NPCID.Steampunker)
			{
				shop.item[nextSlot].SetDefaults(ItemType<CogHeart>());
				shop.item[nextSlot].shopCustomPrice = 70000;
				nextSlot++;
			}
		}
	}
}