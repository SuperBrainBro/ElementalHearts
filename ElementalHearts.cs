using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Dyes;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;

namespace ElementalHearts
{
	public class ElementalHearts : Mod
	{
		//Curse's
		public static Texture2D Buff_20;
		public static Texture2D Buff_22;
		public static Texture2D Buff_23;
		public static Texture2D Buff_24;
		public static Texture2D Buff_30;
		public static Texture2D Buff_31;
		public static Texture2D Buff_32;
		public static Texture2D Buff_33;
		public static Texture2D Buff_35;
		public static Texture2D Buff_36;
		public static Texture2D Buff_39;
		public static Texture2D Buff_44;
		public static Texture2D Buff_46;
		public static Texture2D Buff_47;
		public static Texture2D Buff_69;
		public static Texture2D Buff_70;
		public static Texture2D Buff_80;

		public override void Load()
		{
			if(!Main.dedServ)
			{
				//Curse's
				if(ModContent.GetInstance<Config>().VanillaDebuffCurseRetexture)
				{
					Buff_20 = Main.buffTexture[20];
					Main.buffTexture[20] = GetTexture("Vanilla/Buff_20");
					Buff_22 = Main.buffTexture[22];
					Main.buffTexture[22] = GetTexture("Vanilla/Buff_22");
					Buff_23 = Main.buffTexture[23];
					Main.buffTexture[23] = GetTexture("Vanilla/Buff_23");
					Buff_24 = Main.buffTexture[24];
					Main.buffTexture[24] = GetTexture("Vanilla/Buff_24");
					Buff_30 = Main.buffTexture[30];
					Main.buffTexture[30] = GetTexture("Vanilla/Buff_30");
					Buff_31 = Main.buffTexture[31];
					Main.buffTexture[31] = GetTexture("Vanilla/Buff_31");
					Buff_32 = Main.buffTexture[32];
					Main.buffTexture[32] = GetTexture("Vanilla/Buff_32");
					Buff_33 = Main.buffTexture[33];
					Main.buffTexture[33] = GetTexture("Vanilla/Buff_33");
					Buff_35 = Main.buffTexture[35];
					Main.buffTexture[35] = GetTexture("Vanilla/Buff_35");
					Buff_36 = Main.buffTexture[36];
					Main.buffTexture[36] = GetTexture("Vanilla/Buff_36");
					Buff_39 = Main.buffTexture[39];
					Main.buffTexture[39] = GetTexture("Vanilla/Buff_39");
					Buff_44 = Main.buffTexture[44];
					Main.buffTexture[44] = GetTexture("Vanilla/Buff_44");
					Buff_46 = Main.buffTexture[46];
					Main.buffTexture[46] = GetTexture("Vanilla/Buff_46");
					Buff_47 = Main.buffTexture[47];
					Main.buffTexture[47] = GetTexture("Vanilla/Buff_47");
					Buff_69 = Main.buffTexture[69];
					Main.buffTexture[69] = GetTexture("Vanilla/Buff_69");
					Buff_70 = Main.buffTexture[70];
					Main.buffTexture[70] = GetTexture("Vanilla/Buff_70");
					Buff_80 = Main.buffTexture[80];
					Main.buffTexture[80] = GetTexture("Vanilla/Buff_80");
				}
			}
		}
	}
}