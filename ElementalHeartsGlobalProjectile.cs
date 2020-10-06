using ElementalHearts.Items.Dev.Lite;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts
{
    public class ElementalHeartsGlobalProjectile : GlobalProjectile
    {
        public override void Kill(Projectile projectile, int timeLeft)
        {
            if (Main.player[projectile.owner].HeldItem.type == ItemType<BowLite>())
            {
                if (Main.rand.NextBool(20))
                {
                    Projectile.NewProjectile(projectile.position, Main.player[projectile.owner].velocity, ProjectileID.GiantBee, 50, 0, Main.player[projectile.owner].whoAmI);
                }
            }
            base.Kill(projectile, timeLeft);
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (Main.player[projectile.owner].HeldItem.type == ItemType<BowLite>())
            {
                if (Main.rand.NextBool(8))
                {
                    target.AddBuff(BuffID.Midas, 30);
                }
                else
                {
                    if (Main.rand.NextBool(10))
                    {
                        target.AddBuff(BuffID.ShadowFlame, 30);
                    }
                }
                if (Main.rand.NextBool(8))
                {
                    if (Main.rand.NextBool(2))
                    {
                        //Only spawn Horizontal
                        Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(0, 10) / 2, ProjectileID.ChlorophyteBullet, 20 / 2, 1.5f, Main.player[projectile.owner].whoAmI);
                        Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(10, 0) / 2, ProjectileID.ChlorophyteBullet, 20 / 2, 1.5f, Main.player[projectile.owner].whoAmI);
                        Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(0, -10) / 2, ProjectileID.ChlorophyteBullet, 20 / 2, 1.5f, Main.player[projectile.owner].whoAmI);
                        Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(-10, 0) / 2, ProjectileID.ChlorophyteBullet, 20 / 2, 1.5f, Main.player[projectile.owner].whoAmI);
                    }
                    else if (Main.rand.NextBool(2))
                    {
                        //Only spawn Diagonal
                        Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(10, 10) / 2, ProjectileID.ChlorophyteBullet, 20 / 2, 1.5f, Main.player[projectile.owner].whoAmI);
                        Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(10, -10) / 2, ProjectileID.ChlorophyteBullet, 20 / 2, 1.5f, Main.player[projectile.owner].whoAmI);
                        Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(-10, 10) / 2, ProjectileID.ChlorophyteBullet, 20 / 2, 1.5f, Main.player[projectile.owner].whoAmI);
                        Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(-10, -10) / 2, ProjectileID.ChlorophyteBullet, 20 / 2, 1.5f, Main.player[projectile.owner].whoAmI);
                    }
                    else if (Main.rand.NextBool(4))
                    {
                        //Spawn both
                        Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(0, 10) / 2, ProjectileID.ChlorophyteBullet, 10 / 2, 1.5f, Main.player[projectile.owner].whoAmI);
                        Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(10, 0) / 2, ProjectileID.ChlorophyteBullet, 10 / 2, 1.5f, Main.player[projectile.owner].whoAmI);
                        Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(0, -10) / 2, ProjectileID.ChlorophyteBullet, 10 / 2, 1.5f, Main.player[projectile.owner].whoAmI);
                        Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(-10, 0) / 2, ProjectileID.ChlorophyteBullet, 10 / 2, 1.5f, Main.player[projectile.owner].whoAmI);
                        Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(10, 10) / 2, ProjectileID.ChlorophyteBullet, 10 / 2, 1.5f, Main.player[projectile.owner].whoAmI);
                        Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(10, -10) / 2, ProjectileID.ChlorophyteBullet, 10 / 2, 1.5f, Main.player[projectile.owner].whoAmI);
                        Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(-10, 10) / 2, ProjectileID.ChlorophyteBullet, 10 / 2, 1.5f, Main.player[projectile.owner].whoAmI);
                        Projectile.NewProjectile(Main.player[projectile.owner].position, new Vector2(-10, -10) / 2, ProjectileID.ChlorophyteBullet, 10 / 2, 1.5f, Main.player[projectile.owner].whoAmI);
                    }
                }
            }
        }
    }
}