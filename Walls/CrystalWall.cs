using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Walls
{
	public class CrystalWall : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = true;
			Main.wallLight[Type] = true;
			dustType = DustID.CrystalPulse2;
			AddMapEntry(new Color(150, 150, 150));
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = .1f;
			g = 0f;
			b = 0f;
		}
	}
}
 