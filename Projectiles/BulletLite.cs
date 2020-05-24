using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Projectiles
{
	public class BulletLite : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			ProjectileID.Sets.Homing[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.width = 4;
			projectile.height = 4;
			//projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.light = 0.5f;
			projectile.alpha = 255;
			projectile.extraUpdates = 2;
			projectile.scale = 1.2f;
			projectile.timeLeft = 600;
			projectile.ranged = true;
		}
		/*
		public override void AI()
		{
			projectile.AI();
			
			// Optional: if the projectile should fade in, fade it in:
			if (projectile.alpha > 0)
				projectile.alpha -= 15;
			if (projectile.alpha < 0)
				projectile.alpha = 0;
			// Set the rotation to face the current trajectory:
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			// Or, this version is easier to read:
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
			// Cap downward velocity, in case you add gravity to this projectile
			//if (projectile.velocity.Y > 16f)
			//projectile.velocity.Y = 16f;

			if (projectile.alpha < 170)
			{
				for (int num73 = 0; num73 < 10; num73++)
				{
					float x2 = projectile.position.X - projectile.velocity.X / 10f * (float)num73;
					float y2 = projectile.position.Y - projectile.velocity.Y / 10f * (float)num73;
					int num74 = Dust.NewDust(new Vector2(x2, y2), 1, 1, 75);
					Main.dust[num74].alpha = projectile.alpha;
					Main.dust[num74].position.X = x2;
					Main.dust[num74].position.Y = y2;
					Main.dust[num74].velocity *= 0f;
					Main.dust[num74].noGravity = true;
				}
			}
			float num75 = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y);
			float num76 = projectile.localAI[0];
			if (num76 == 0f)
			{
				projectile.localAI[0] = num75;
				num76 = num75;
			}
			if (projectile.alpha > 0)
			{
				projectile.alpha -= 25;
			}
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
			float num77 = projectile.position.X;
			float num78 = projectile.position.Y;
			float num79 = 300f;
			bool flag4 = false;
			int num81 = 0;
			if (projectile.ai[1] == 0f)
			{
				for (int num82 = 0; num82 < 200; num82++)
				{
					if (Main.npc[num82].CanBeChasedBy(this) && (projectile.ai[1] == 0f || projectile.ai[1] == (float)(num82 + 1)))
					{
						float num83 = Main.npc[num82].position.X + (float)(Main.npc[num82].width / 2);
						float num84 = Main.npc[num82].position.Y + (float)(Main.npc[num82].height / 2);
						float num85 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num83) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num84);
						if (num85 < num79 && Collision.CanHit(new Vector2(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2)), 1, 1, Main.npc[num82].position, Main.npc[num82].width, Main.npc[num82].height))
						{
							num79 = num85;
							num77 = num83;
							num78 = num84;
							flag4 = true;
							num81 = num82;
						}
					}
				}
				if (flag4)
				{
					projectile.ai[1] = num81 + 1;
				}
				flag4 = false;
			}
			if (projectile.ai[1] > 0f)
			{
				int num86 = (int)(projectile.ai[1] - 1f);
				if (Main.npc[num86].active && Main.npc[num86].CanBeChasedBy(this, ignoreDontTakeDamage: true) && !Main.npc[num86].dontTakeDamage)
				{
					float num87 = Main.npc[num86].position.X + (float)(Main.npc[num86].width / 2);
					float num88 = Main.npc[num86].position.Y + (float)(Main.npc[num86].height / 2);
					if (Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num87) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num88) < 1000f)
					{
						flag4 = true;
						num77 = Main.npc[num86].position.X + (float)(Main.npc[num86].width / 2);
						num78 = Main.npc[num86].position.Y + (float)(Main.npc[num86].height / 2);
					}
				}
				else
				{
					projectile.ai[1] = 0f;
				}
			}
			if (!projectile.friendly)
			{
				flag4 = false;
			}
			if (flag4)
			{
				float num224 = num76;
				Vector2 vector16 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				float num91 = num77 - vector16.X;
				float num93 = num78 - vector16.Y;
				float num95 = (float)Math.Sqrt(num91 * num91 + num93 * num93);
				num95 = num224 / num95;
				num91 *= num95;
				num93 *= num95;
				int num96 = 8;
				projectile.velocity.X = (projectile.velocity.X * (float)(num96 - 1) + num91) / (float)num96;
				projectile.velocity.Y = (projectile.velocity.Y * (float)(num96 - 1) + num93) / (float)num96;
			}
			//Dust
			int dust1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, (int)projectile.velocity.X, (int)projectile.velocity.Y, projectile.alpha, 255, Color.White, 1);
			int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, (int)-projectile.velocity.X, (int)-projectile.velocity.Y, projectile.alpha, 255, Color.Black, 1);		
		}
		*/
	}
}