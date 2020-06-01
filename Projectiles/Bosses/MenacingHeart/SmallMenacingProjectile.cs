using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Projectiles.Bosses.MenacingHeart
{
    public class SmallMenacingProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("A Menacing Projectiles");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Fireball);
            projectile.width = 14;
            projectile.height = 14;
            projectile.scale = 1.5f;
            projectile.timeLeft = 250;
            projectile.penetrate = -1;
        }

        public override void AI()
        {
            projectile.velocity.Y += Main.expertMode ? 0.015f : 0.01f;

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