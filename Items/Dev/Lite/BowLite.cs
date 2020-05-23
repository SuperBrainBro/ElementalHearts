using ElementalHearts.Items.Dev.CAT;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace ElementalHearts.Items.Dev.Lite
{
	public class BowLite : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Tsunami);
			item.damage = 20;
			item.crit = 3;
			item.knockBack = 1.5f;
			item.rare = ItemRarityID.Cyan;
		}
	}
}
