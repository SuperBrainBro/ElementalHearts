using ElementalHearts.Items.Dev.Lite;
using ElementalHearts.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;

namespace ElementalHearts
{
	public class ElementalHeartsGlobalProjectile : GlobalProjectile
	{
		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			if (Main.player[projectile.owner].HeldItem.type == ItemType<BowLite>())
			{
				if (Main.rand.NextBool(6))
				{
					target.AddBuff(BuffID.Midas, 30);
				}
				else
				{
					if (Main.rand.NextBool(8))
					{
						target.AddBuff(BuffID.ShadowFlame, 30);
					}
				}
				if (Main.rand.NextBool(8))
				{
					if (Main.rand.NextBool(2))
					{
						//Only spawn Horizontal
						int NPCProjLite1 = Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(0, 10) / 2, ProjectileType<BulletLite>(), 20, 1.5f, Main.player[projectile.owner].whoAmI);
						int NPCProjLite2 = Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(10, 0) / 2, ProjectileType<BulletLite>(), 20, 1.5f, Main.player[projectile.owner].whoAmI);
						int NPCProjLite3 = Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(0, -10) / 2, ProjectileType<BulletLite>(), 20, 1.5f, Main.player[projectile.owner].whoAmI);
						int NPCProjLite4 = Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(-10, 0) / 2, ProjectileType<BulletLite>(), 20, 1.5f, Main.player[projectile.owner].whoAmI);
					}
					else if (Main.rand.NextBool(2))
					{
						//Only spawn Diagonal
						int NPCProjLite1 = Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(10, 10) / 2, ProjectileType<BulletLite>(), 20, 1.5f, Main.player[projectile.owner].whoAmI);
						int NPCProjLite2 = Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(10, -10) / 2, ProjectileType<BulletLite>(), 20, 1.5f, Main.player[projectile.owner].whoAmI);
						int NPCProjLite3 = Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(-10, 10) / 2, ProjectileType<BulletLite>(), 20, 1.5f, Main.player[projectile.owner].whoAmI);
						int NPCProjLite4 = Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(-10, -10) / 2, ProjectileType<BulletLite>(), 20, 1.5f, Main.player[projectile.owner].whoAmI);
					}
					else if (Main.rand.NextBool(4))
					{
						//Spawn both
						int NPCProjLite1 = Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(0, 10) / 2, ProjectileType<BulletLite>(), 20, 1.5f, Main.player[projectile.owner].whoAmI);
						int NPCProjLite2 = Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(10, 0) / 2, ProjectileType<BulletLite>(), 20, 1.5f, Main.player[projectile.owner].whoAmI);
						int NPCProjLite3 = Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(0, -10) / 2, ProjectileType<BulletLite>(), 20, 1.5f, Main.player[projectile.owner].whoAmI);
						int NPCProjLite4 = Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(-10, 0) / 2, ProjectileType<BulletLite>(), 20, 1.5f, Main.player[projectile.owner].whoAmI);
						int NPCProjLite5 = Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(10, 10) / 2, ProjectileType<BulletLite>(), 20, 1.5f, Main.player[projectile.owner].whoAmI);
						int NPCProjLite6 = Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(10, -10) / 2, ProjectileType<BulletLite>(), 20, 1.5f, Main.player[projectile.owner].whoAmI);
						int NPCProjLite7 = Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(-10, 10) / 2, ProjectileType<BulletLite>(), 20, 1.5f, Main.player[projectile.owner].whoAmI);
						int NPCProjLite8 = Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(-10, -10) / 2, ProjectileType<BulletLite>(), 20, 1.5f, Main.player[projectile.owner].whoAmI);
					}
				}
			}
		}
	}
}