using ElementalHearts.Items.Dev.CAT;
using System;
using System.Collections.Generic;
using System.Messaging;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.Graphics.Shaders;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria.UI;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Dev.CAT
{
	public class CatastrophicBeam : ModProjectile
	{
		public override void SetStaticDefaults() {
		}
		public override void SetDefaults() {
			projectile.height = 58;
			projectile.width = 48;
			projectile.CloneDefaults(ProjectileID.TerraBeam);
			projectile.scale = 1.15f;
			projectile.alpha = 255;
			aiType = ProjectileID.TerraBeam;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			if (Main.rand.NextBool(15)) {
            	target.AddBuff(BuffType<CATsCurse>(), 5 * 60);
			}
			if (Main.rand.NextBool(5)) {
            	target.AddBuff(69, 10 * 60);
			}
        }
		public override void AI() {
			if (Main.rand.NextBool(750)) {
				projectile.Kill();
			}
			if (Main.rand.NextBool(1)) {
				if (projectile.alpha >= 0) {
					Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<CatastrophicBeam_Dust>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				}
			}
		}
	}
}
