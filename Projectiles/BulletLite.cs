using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Projectiles
{
	//ported from my tAPI mod because I'm lazy
	public class BulletLite : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.ChlorophyteBullet);
			projectile.alpha = 255;
			//projectile.penetrate = 2;
		}

		public override void PostAI()
		{
			base.PostAI();
			int dust1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, (int)projectile.velocity.X, (int)projectile.velocity.Y, projectile.alpha, 255, Color.White, 1);
			int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, (int)-projectile.velocity.X, (int)-projectile.velocity.Y, projectile.alpha, 255, Color.Black, 1);

			

		}
	}
}