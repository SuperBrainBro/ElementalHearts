using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.NPCs.Bosses.MenacingHeart
{
	//ported from my tAPI mod because I'm lazy
	public class MenacingProjectile : ModProjectile
	{
		//public override void SetStaticDefaults()
		//{
			//ProjectileID.Sets.Homing[projectile.type] = true;
		//}

		public override void SetDefaults()
		{
			//projectile.aiStyle = 24;
			projectile.width = 44;
			projectile.height = 44;
			projectile.alpha =  0;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			
			//projectile.ranged = true;
		}
		public override void AI()
		{
			projectile.position += projectile.velocity;
			projectile.velocity *= 1.15f;
			base.AI();
		}
		public override void PostAI()
		{
			int dust1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Blood, projectile.velocity.X, projectile.velocity.Y, 0, Color.Red, 1);
			int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Blood, projectile.velocity.X, projectile.velocity.Y, 0, Color.Black, 1);
			int dust3 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Blood, projectile.velocity.X, projectile.velocity.Y, 0, Color.White, 1);
			Main.dust[dust1].velocity /= 2f;
			Main.dust[dust2].velocity /= 2f;
			Main.dust[dust3].velocity /= 2f;
			base.PostAI();
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Main.DiscoColor;
		}
	}
}