using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Projectiles.Bosses.MenacingHeart
{
	public class MenacingProjectile : ModProjectile
	{
		//public override void SetStaticDefaults()
		//{
			//ProjectileID.Sets.Homing[projectile.type] = true;
		//}

		public override void SetDefaults()
		{
			projectile.penetrate = -1;
			projectile.width = 44;
			projectile.height = 44;
			projectile.alpha =  0;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.timeLeft = 10;
		}
		public override void AI()
		{
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
			float distance = 400f;
			bool target = false;
			for (int k = 0; k < Main.maxPlayers; k++)
			{
				if (Main.player[k].active && !Main.player[k].dead)
				{
					Vector2 newMove = Main.player[k].Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance)
					{
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			if (target)
			{
				AdjustMagnitude(ref move);
				projectile.velocity = (10 * projectile.velocity + move) / 11f;
				AdjustMagnitude(ref projectile.velocity);
			}
			if (projectile.alpha == 0)
			{
				int dust1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Blood, projectile.velocity.X, projectile.velocity.Y, 0, Color.Red, 1);
				int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Blood, projectile.velocity.X, projectile.velocity.Y, 0, Color.Black, 1);
				int dust3 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Blood, projectile.velocity.X, projectile.velocity.Y, 0, Color.White, 1);
				Main.dust[dust1].velocity /= 2f;
				Main.dust[dust2].velocity /= 2f;
				Main.dust[dust3].velocity /= 2f;
			}
		}

		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > 6f)
			{
				vector *= 6f / magnitude;
			}
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Main.DiscoColor;
		}
	}
}