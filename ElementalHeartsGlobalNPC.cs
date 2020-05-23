using ElementalHearts.Items.Consumables;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.NPCs
{
	public class ElementalHeartsGlobalNPC : GlobalNPC
	{
		public override void SetupShop(int type, Chest shop, ref int nextSlot) {
			if (type == NPCID.PartyGirl) {
				shop.item[nextSlot].SetDefaults(ItemType<BubbleHeart>());
				shop.item[nextSlot].shopCustomPrice = 5000;
				nextSlot++;
			}
		}
	}
}