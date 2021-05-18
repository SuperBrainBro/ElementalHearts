using Terraria;
using Terraria.ModLoader;

namespace ElementalHearts.Projectiles.Bosses.CrystalGuardian
{
    public class CrystalFire : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Fire");
            Main.projFrames[projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            projectile.penetrate = -1;
            projectile.width = 22;
            projectile.height = 22;
            projectile.alpha = 0;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = false;
            projectile.timeLeft = 120;
        }
        public override void AI()
        {
            if (Main.rand.NextBool(2))
            {
                if (Main.rand.NextBool(2))
                {
                    projectile.velocity.X += 1.5f;
                }
                else
                {
                    projectile.velocity.X -= 1.5f;
                }
            }
            else
            {
                if (Main.rand.NextBool(2))
                {
                    projectile.velocity.Y += 1.5f;
                }
                else
                {
                    projectile.velocity.Y -= 1.5f;
                }
            }
            projectile.frameCounter++;
            if (projectile.frameCounter > 6)
            {
                projectile.frame++;
                projectile.frameCounter = 0;
                if (projectile.frame > 1)
                {
                    projectile.frame = 0;
                }
            }
        }
    }
}