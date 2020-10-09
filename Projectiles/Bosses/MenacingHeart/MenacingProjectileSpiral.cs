using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Projectiles.Bosses.MenacingHeart
{
    public class MenacingProjectileSpiral : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("A Menacing Projectile");
        }
        public override void SetDefaults()
        {
            //projectile.aiStyle = 0;
            projectile.penetrate = -1;
            projectile.width = 44;
            projectile.height = 44;
            projectile.alpha = 0;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.timeLeft = 500;
        }
        public override void AI()
        {
            //Face Toward Velocity
            projectile.rotation = projectile.velocity.ToRotation();
            //^Not Not Enabled Because It Does Not Work

            //Acceleration Effect
            projectile.velocity *= 1.02f;
            if (5 > Main.rand.Next(10))
            {
                projectile.velocity += new Vector2(1, 0);
            }
            else
            {
                projectile.velocity += new Vector2(-1, 0);
            }


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