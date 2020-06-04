using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Projectiles.Friendly
{
	public class FriendlyMenacingProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("A Menacing Projectile");
		}
		public override void SetDefaults()
		{
			//projectile.aiStyle = 0;
			projectile.penetrate = 0;
			projectile.width = 44;
			projectile.height = 44;
			projectile.alpha =  0;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.tileCollide = true;
			projectile.ignoreWater = false;
			projectile.scale = .5f;
		}
		public override void AI()
		{
			//Face Toward Velocity
			projectile.rotation = projectile.velocity.ToRotation();
			//^Not Not Enabled Because It Does Not Work

			//Acceleration Effect
			projectile.velocity *= 1.001f;

			//Dust
			int dust1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Blood, projectile.velocity.X, projectile.velocity.Y, 0, Main.DiscoColor, 1);
			int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Blood, projectile.velocity.X, projectile.velocity.Y, 0, Color.Black, 1);
			int dust3 = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Blood, projectile.velocity.X, projectile.velocity.Y, 0, Color.White, 1);
			Main.dust[dust1].velocity /= 2f;
			Main.dust[dust2].velocity /= 2f;
			Main.dust[dust3].velocity /= 2f;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return Main.DiscoColor;
		}
	}
}