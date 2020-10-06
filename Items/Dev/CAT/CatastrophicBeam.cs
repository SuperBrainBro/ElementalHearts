using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Dev.CAT
{
    public class CatastrophicBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.TerraBeam);
            projectile.width = 28;
            projectile.height = 44;
            projectile.tileCollide = false;
            projectile.timeLeft = 10 * 60;
            projectile.damage = ModContent.GetInstance<CatastrophicEdge>().item.damage;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.NextBool(15))
            {
                target.AddBuff(BuffType<CATsCurse>(), 5 * 60);
            }
            if (Main.rand.NextBool(5))
            {
                target.AddBuff(69, 10 * 60);
            }
        }
        /*public override void AI()
        {
            //Projectile.NewProjectile(new Vector2(projectile.oldPosition.X, projectile.oldPosition.Y), new Vector2(0, 0), ProjectileType<CatastrophicBeamOLD>(), 0, 0f, Main.myPlayer);
            if (projectile.type == 115)
            {
                float local = projectile.ai[0];
                local = local + 1f;
                if ((double)projectile.ai[0] < 30.0)
                    projectile.velocity = projectile.velocity * 1.125f;
            }
            if (projectile.type == 115 && (double)projectile.localAI[1] < 5.0)
            {
                projectile.localAI[1] = 5f;
                for (int index1 = 5; index1 < 25; ++index1)
                {
                    int index2 = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X * (30f / (float)index1) * 80f, projectile.position.Y - projectile.velocity.Y * (30f / (float)index1) * 80f), 8, 8, 27, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, new Color(190, 52, 153), 0.9f);
                    Dust dust1 = Main.dust[index2];
                    dust1.velocity = dust1.velocity * 0.25f;
                    Dust dust2 = Main.dust[index2];
                    dust2.velocity = dust2.velocity - projectile.velocity * 5f;
                }
            }
            if ((double)projectile.localAI[1] > 7.0 && projectile.type == 173)
            {
                int Type;
                switch (Main.rand.Next(3))
                {
                    case 0:
                        Type = 15;
                        break;
                    case 1:
                        Type = 57;
                        break;
                    default:
                        Type = 58;
                        break;
                }
                int index = Dust.NewDust(new Vector2((float)((double)projectile.position.X - (double)projectile.velocity.X * 4.0 + 2.0), (float)((double)projectile.position.Y + 2.0 - (double)projectile.velocity.Y * 4.0)), 8, 8, Type, 0.0f, 0.0f, 100, new Color(190, 52, 153), 1.25f);
                Dust dust = Main.dust[index];
                dust.velocity = dust.velocity * 0.1f;
            }
            if ((double)projectile.localAI[1] > 7.0 && projectile.type == ModContent.ProjectileType<CatastrophicBeam>())
            {
                int index1 = Dust.NewDust(new Vector2((float)((double)projectile.position.X - (double)projectile.velocity.X * 4.0 + 2.0), (float)((double)projectile.position.Y + 2.0 - (double)projectile.velocity.Y * 4.0)), 8, 8, 107, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, new Color(190, 52, 153), 1.25f);
                Dust dust1 = Main.dust[index1];
                dust1.velocity = dust1.velocity * -0.25f;
                int index2 = Dust.NewDust(new Vector2((float)((double)projectile.position.X - (double)projectile.velocity.X * 4.0 + 2.0), (float)((double)projectile.position.Y + 2.0 - (double)projectile.velocity.Y * 4.0)), 8, 8, 107, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, new Color(190, 52, 153), 1.25f);
                Dust dust2 = Main.dust[index2];
                dust2.velocity = dust2.velocity * -0.25f;
                Dust dust3 = Main.dust[index2];
                dust3.position = dust3.position - projectile.velocity * 0.5f;
            }
            if ((double)projectile.localAI[1] < 15.0)
            {
                float local = projectile.localAI[1];
                local = local + 1f;
            }
            else
            {
                if (projectile.type == 114 || projectile.type == 115)
                {
                    int index = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 4f), 8, 8, 27, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, new Color(190, 52, 153), 0.6f);
                    Dust dust = Main.dust[index];
                    dust.velocity = dust.velocity * -0.25f;
                }
                else if (projectile.type == 116)
                {
                    int index = Dust.NewDust(new Vector2((float)((double)projectile.position.X - (double)projectile.velocity.X * 5.0 + 2.0), (float)((double)projectile.position.Y + 2.0 - (double)projectile.velocity.Y * 5.0)), 8, 8, 64, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, new Color(190, 52, 153), 1.5f);
                    Dust dust = Main.dust[index];
                    dust.velocity = dust.velocity * -0.25f;
                    Main.dust[index].noGravity = true;
                }
                if ((double)projectile.localAI[0] == 0.0)
                {
                    projectile.scale = projectile.scale - 0.02f;
                    projectile.alpha = projectile.alpha + 30;
                    if (projectile.alpha >= 250)
                    {
                        projectile.alpha = (int)byte.MaxValue;
                        projectile.localAI[0] = 1f;
                    }
                }
                else if ((double)projectile.localAI[0] == 1.0)
                {
                    projectile.scale = projectile.scale + 0.02f;
                    projectile.alpha = projectile.alpha - 30;
                    if (projectile.alpha <= 0)
                    {
                        projectile.alpha = 0;
                        projectile.localAI[0] = 0.0f;
                    }
                }
            }
            if ((double)projectile.ai[1] == 0.0)
            {
                projectile.ai[1] = 1f;
                if (projectile.type == ModContent.ProjectileType<CatastrophicBeam>())
                    Main.PlaySound(SoundID.Item60, projectile.position);
                else
                    Main.PlaySound(SoundID.Item8, projectile.position);
            }
            if (projectile.type == 157)
            {
                projectile.rotation = projectile.rotation + (float)projectile.direction * 0.4f;
                projectile.spriteDirection = projectile.direction;
            }
            else
                projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 0.785f;
            if ((double)projectile.velocity.Y <= 16.0)
                return;
            projectile.velocity.Y = 16f;

        }*/
    }
}