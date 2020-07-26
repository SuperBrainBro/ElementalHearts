using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Projectiles.Friendly
{
    public class SeekingFriendlyMenacingProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.Homing[projectile.type] = true;
        }
        public override void SetDefaults()
        {
            projectile.width = 44;
            projectile.height = 44;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 600;
            projectile.scale = .25f;
        }

        public override void AI()
        {


            Vector2 move = Vector2.Zero;
            float distance = 400f;
            bool target = false;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    Vector2 newMove = Main.npc[k].Center - projectile.Center;
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

            //Gravity         
            projectile.velocity.Y += projectile.ai[0];

            //Face Toward Velocity
            projectile.rotation = projectile.velocity.ToRotation();
            //^Not Not Enabled Because It Does Not Work

            //Acceleration Effect
            projectile.velocity *= 1.003f;

            //Dust
            if (Main.rand.NextBool(2))
            {
                if (Main.rand.NextBool(2))
                {
                    int dust1 = Dust.NewDust(projectile.Center, 1, 1, DustID.Blood, projectile.velocity.X, projectile.velocity.Y, 0, Main.DiscoColor, 1);
                    Main.dust[dust1].velocity /= 2f;
                }
                if (Main.rand.NextBool(2))
                {
                    int dust2 = Dust.NewDust(projectile.Center, 1, 1, DustID.Blood, projectile.velocity.X, projectile.velocity.Y, 0, Color.Black, 1);
                    Main.dust[dust2].velocity /= 2f;

                }
                if (Main.rand.NextBool(2))
                {
                    int dust3 = Dust.NewDust(projectile.Center, 1, 1, DustID.Blood, projectile.velocity.X, projectile.velocity.Y, 0, Color.White, 1);
                    Main.dust[dust3].velocity /= 2f;
                }
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

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                projectile.Kill();
            }
            else
            {
                projectile.ai[0] += 0.1f;
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                projectile.velocity *= 0.69f;
                Main.PlaySound(SoundID.Item35, projectile.position);
            }
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(projectile.Center + projectile.velocity, 1, 1, DustID.Blood, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
            Main.PlaySound(SoundID.Item25, projectile.position);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int healAmount = damage / (10 + (int)Main.rand.NextFloat(4));
            healAmount /= 1 + (int)Main.rand.NextFloat(4);
            Main.player[projectile.owner].HealEffect(healAmount, true);
            Main.player[projectile.owner].statLife += healAmount;
            projectile.Kill();        
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return Main.DiscoColor;
        }
    }
}