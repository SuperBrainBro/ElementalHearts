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
		public override void PostSetupContent() {
			// Showcases mod support with Boss Checklist without referencing the mod
			Mod bossChecklist = ModLoader.GetMod("BossChecklist");
			if (bossChecklist != null) {
				bossChecklist.Call("AddBoss", 5f, ModContent.NPCType<NPCs.Bosses.MenacingHeart.MenacingHeart>(), this, "Menacing Heart", (Func<bool>)(() => ElementalHeartsWorld.downedMenacingHeart), ModContent.ItemType<Tiles.MenacingLookingStatueItem>(),
				new List<int>() { 2493 /*Mask*/, 2489 /*Trophy; Change it later; I set default items for base*/ },
				new List<int>() { ModContent.ItemType<Items.Boss.MenacingLookingHeartBag>(), ModContent.ItemType<Items.Accessories.MenacingLookingPendant>(), ModContent.ItemType<Items.Weapons.MenacingLifeStaff>() },
				"Find and activate a [i:" + ItemType("Tiles.MenacingLookingStatueItem") + "]", "", "ElementalHearts/NPCs/Bosses/MenacingHeart/MenacingHeartClone");
			}
		}
	}
}