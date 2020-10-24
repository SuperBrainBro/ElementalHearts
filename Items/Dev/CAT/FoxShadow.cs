using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Dev.CAT
{
    public class FoxShadow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fox Shadow");
            Main.projFrames[projectile.type] = 3;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            projectile.height = 64;
            projectile.width = 46;
            projectile.damage = 120;
            projectile.netImportant = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.minionSlots = 0f;
            projectile.timeLeft = 18000;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.timeLeft *= 5;
            projectile.minion = true;
            Main.projFrames[projectile.type] = 3;
            base.SetDefaults();
        }

        public override void AI()
        {
            projectile.position.Y = Main.player[projectile.owner].position.Y + 16f;
            bool flag = projectile.type == mod.ProjectileType("FoxShadow");
            Player player = Main.player[base.projectile.owner];
            ElementalHeartsPlayer elementalHeartsPlayer = new ElementalHeartsPlayer();
            if (!elementalHeartsPlayer.shadowFox)
            {
                projectile.active = false;
                return;
            }
            if (flag)
            {
                if (Main.player[projectile.owner].dead)
                {
                    elementalHeartsPlayer.shadowFoxB = false;
                }
                if (elementalHeartsPlayer.shadowFoxB)
                {
                    base.projectile.timeLeft = 2;
                }
            }
            //projectile.position = new Vector2(Main.player[projectile.owner].position.X, Main.player[projectile.owner].position.Y + 32);
            projectile.spriteDirection = Main.player[projectile.owner].direction;
            if (NPC.downedSlimeKing)
            {
                projectile.damage = 10;
            }
            else if (NPC.downedBoss1)
            {
                projectile.damage = 20;
            }
            else if (NPC.downedBoss2)
            {
                projectile.damage = 30;
            }
            else if (NPC.downedBoss3)
            {
                projectile.damage = 40;
            }
            else if (NPC.downedQueenBee)
            {
                projectile.damage = 50;
            }
            else if (Main.hardMode)
            {
                projectile.damage = 60;
            }
            else if (NPC.downedMechBossAny)
            {
                projectile.damage = 70;
            }
            else if (NPC.downedPlantBoss)
            {
                projectile.damage = 80;
            }
            else if (NPC.downedGolemBoss)
            {
                projectile.damage = 90;
            }
            else if (NPC.downedAncientCultist)
            {
                projectile.damage = 100;
            }
            else if (NPC.downedTowers)
            {
                projectile.damage = 110;
            }
            else if (NPC.downedMoonlord)
            {
                projectile.damage = 120;
            }
            else
            {
                projectile.damage = 0;
            }

            if (++projectile.frameCounter >= 4)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 3)
                {
                    projectile.frame = 0;
                }
            }
            base.AI();

            /*this.dust--;
            if (this.dust >= 0)
            {
                int num = 50;
                for (int i = 0; i < num; i++)
                {
                    int num2 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y + 16f), base.projectile.width, base.projectile.height - 16, 235, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num2].velocity *= 2f;
                    Main.dust[num2].scale *= 1.15f;
                }
            }
            float num3 = (float)Main.rand.Next(90, 111) * 0.01f;
            num3 *= Main.essScale;
            Lighting.AddLight(base.projectile.Center, 1f * num3, 0f * num3, 0.15f * num3);
            base.projectile.rotation = base.projectile.velocity.X * 0.04f;
            if ((double)Math.Abs(base.projectile.velocity.X) > 0.2)
            {
                base.projectile.spriteDirection = -base.projectile.direction;
            }
            float num4 = 700f;
            float num5 = 2000f;
            float num6 = 3000f;
            float num7 = 150f;
            float num8 = 0.05f;
            for (int j = 0; j < 1000; j++)
            {
                bool flag2 = Main.projectile[j].type == base.mod.ProjectileType("FoxShadow");
                if (j != base.projectile.whoAmI && Main.projectile[j].active && Main.projectile[j].owner == base.projectile.owner && flag2 && Math.Abs(base.projectile.position.X - Main.projectile[j].position.X) + Math.Abs(base.projectile.position.Y - Main.projectile[j].position.Y) < (float)base.projectile.width)
                {
                    if (base.projectile.position.X < Main.projectile[j].position.X)
                    {
                        base.projectile.velocity.X = base.projectile.velocity.X - num8;
                    }
                    else
                    {
                        base.projectile.velocity.X = base.projectile.velocity.X + num8;
                    }
                    if (base.projectile.position.Y < Main.projectile[j].position.Y)
                    {
                        base.projectile.velocity.Y = base.projectile.velocity.Y - num8;
                    }
                    else
                    {
                        base.projectile.velocity.Y = base.projectile.velocity.Y + num8;
                    }
                }
            }
            bool flag3 = false;
            if (base.projectile.ai[0] == 2f)
            {
                base.projectile.ai[1] += 1f;
                base.projectile.extraUpdates = 1;
                if (base.projectile.ai[1] > 40f)
                {
                    base.projectile.ai[1] = 1f;
                    base.projectile.ai[0] = 0f;
                    base.projectile.extraUpdates = 0;
                    base.projectile.numUpdates = 0;
                    base.projectile.netUpdate = true;
                }
                else
                {
                    flag3 = true;
                }
            }
            if (flag3)
            {
                return;
            }
            Vector2 vector = base.projectile.position;
            bool flag4 = false;
            if (base.projectile.ai[0] != 1f)
            {
                base.projectile.tileCollide = false;
            }
            if (base.projectile.tileCollide && WorldGen.SolidTile(Framing.GetTileSafely((int)base.projectile.Center.X / 16, (int)base.projectile.Center.Y / 16)))
            {
                base.projectile.tileCollide = false;
            }
            for (int k = 0; k < 200; k++)
            {
                NPC npc = Main.npc[k];
                if (npc.CanBeChasedBy(base.projectile, false))
                {
                    float num9 = Vector2.Distance(npc.Center, base.projectile.Center);
                    if (((Vector2.Distance(base.projectile.Center, vector) > num9 && num9 < num4) || !flag4) && Collision.CanHitLine(base.projectile.position, base.projectile.width, base.projectile.height, npc.position, npc.width, npc.height))
                    {
                        num4 = num9;
                        vector = npc.Center;
                        flag4 = true;
                    }
                }
            }
            float num10 = num5;
            if (flag4)
            {
                num10 = num6;
            }
            if (Vector2.Distance(player.Center, base.projectile.Center) > num10)
            {
                base.projectile.ai[0] = 1f;
                base.projectile.tileCollide = false;
                base.projectile.netUpdate = true;
            }
            if (flag4 && base.projectile.ai[0] == 0f)
            {
                Vector2 vector2 = vector - base.projectile.Center;
                float num11 = vector2.Length();
                vector2.Normalize();
                if (num11 > 200f)
                {
                    float scaleFactor = 16f;
                    vector2 *= scaleFactor;
                    base.projectile.velocity = (base.projectile.velocity * 40f + vector2) / 41f;
                }
                else
                {
                    float num12 = 4f;
                    vector2 *= -num12;
                    base.projectile.velocity = (base.projectile.velocity * 40f + vector2) / 41f;
                }
            }
            else
            {
                bool flag5 = false;
                if (!flag5)
                {
                    flag5 = (base.projectile.ai[0] == 1f);
                }
                float num13 = 5f;
                if (flag5)
                {
                    num13 = 12f;
                }
                Vector2 center = base.projectile.Center;
                Vector2 vector3 = player.Center - center + new Vector2(0f, -30f);
                float num14 = vector3.Length();
                if (num14 > 200f && num13 < 6.5f)
                {
                    num13 = 6.5f;
                }
                if (num14 < num7 && flag5 && !Collision.SolidCollision(base.projectile.position, base.projectile.width, base.projectile.height))
                {
                    base.projectile.ai[0] = 0f;
                    base.projectile.netUpdate = true;
                }
                if (num14 > 2000f)
                {
                    base.projectile.position.X = Main.player[base.projectile.owner].Center.X - (float)(base.projectile.width / 2);
                    base.projectile.position.Y = Main.player[base.projectile.owner].Center.Y - (float)(base.projectile.height / 2);
                    base.projectile.netUpdate = true;
                }
                if (num14 > 70f)
                {
                    vector3.Normalize();
                    vector3 *= num13;
                    base.projectile.velocity = (base.projectile.velocity * 40f + vector3) / 41f;
                }
                else if (base.projectile.velocity.X == 0f && base.projectile.velocity.Y == 0f)
                {
                    base.projectile.velocity.X = -0.2f;
                    base.projectile.velocity.Y = -0.1f;
                }
            }
            if (base.projectile.ai[1] > 0f)
            {
                base.projectile.ai[1] += (float)Main.rand.Next(1, 4);
            }
            if (base.projectile.ai[1] > 80f)
            {
                base.projectile.ai[1] = 0f;
                base.projectile.netUpdate = true;
            }
            if (base.projectile.ai[0] == 0f)
            {
                float scaleFactor2 = 24f;
                int type = ProjectileID.ChlorophyteBullet;
                if (flag4 && base.projectile.ai[1] == 0f)
                {
                    base.projectile.ai[1] += 1f;
                    if (Main.myPlayer == base.projectile.owner && Collision.CanHitLine(base.projectile.position, base.projectile.width, base.projectile.height, vector, 0, 0))
                    {
                        Vector2 value = vector - base.projectile.Center;
                        value.Normalize();
                        value *= scaleFactor2;
                        int num15 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, value.X, value.Y, type, 10000, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num15].timeLeft = 300;
                        base.projectile.netUpdate = true;
                    }
                }
            }*/
        }

        public int dust = 3;
        public override Color? GetAlpha(Color lightColor) => new Color(0, 116, Main.DiscoB);
    }

    public class FoxShadowB : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Fox Shadow");
            Description.SetDefault("Shadow of the Developer will protect you, player.");
            Main.buffNoTimeDisplay[base.Type] = true;
            Main.buffNoSave[base.Type] = true;
        }


        public override void Update(Player player, ref int buffIndex)
        {
            ElementalHeartsPlayer modPlayer = player.GetModPlayer<ElementalHeartsPlayer>();
            if (player.ownedProjectileCounts[mod.ProjectileType("FoxShadow")] > 0)
            {
                modPlayer.shadowFoxB = true;
            }
            if (!modPlayer.shadowFoxB)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
                return;
            }
            player.buffTime[buffIndex] = 18000;
        }
    }
}