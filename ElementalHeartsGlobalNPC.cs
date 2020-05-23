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
				shop.item[nextSlot].shopCustomPrice = 5000;
				nextSlot++;
			}
		}
	}
}