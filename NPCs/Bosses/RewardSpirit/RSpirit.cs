using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ElementalHearts.NPCs.Bosses.RewardSpirit
{
    public class RSpirit : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reward Spirit");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 256000;
            npc.defense = 10;
            npc.damage = 120;
            npc.width = mod.GetTexture(Texture.Replace("ElementalHearts/", "")).Width;
            npc.height = mod.GetTexture(Texture.Replace("ElementalHearts/", "")).Height / Main.npcFrameCount[npc.type];
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.boss = true;
            npc.knockBackResist = 0f;
            npc.netAlways = true;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.6);
            npc.damage = (int)(npc.damage * 0.8);
        }

        string userName = Environment.UserName;
        public override void AI()
        {
            npc.TargetClosest();
            npc.direction = npc.spriteDirection = npc.position.X < Main.player[npc.target].position.X ? 1 : -1;

            Dust dust;
            Vector2 position = npc.position;
            dust = Main.dust[Dust.NewDust(position, npc.width, npc.height, 191, 0f, 0f, 130, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;
            dust.noLight = true;
            dust.fadeIn = 1.5f;

            if (npc.ai[0] == 0f) AI1();
            else if (npc.ai[0] == 1f) AI2();
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }

        private void AI1()
        {
            Player player = Main.player[npc.target];
            float firepos;
            float firepos2;
            firepos = (player.Center.X > npc.Center.X) ? 300 : -300;
            firepos2 = 0;
            MoveToPoint(player.Center - new Vector2(firepos, firepos2));

            switch (npc.ai[1])
            {
                case 0.0f:
                    if (Main.rand.NextBool(40))
                    {
                        npc.ai[1] = 500.0f;
                    }
                    break;
                case 500.0f:
                    ++npc.ai[3];
                    firepos = 0;
                    firepos2 = -60;
                    if (npc.ai[3] == 10.0f)
                    {
                        Main.NewText("<Reward Spirit> I'm not even trying to win... You know why, " + userName + "?", Color.Lerp(Color.Goldenrod, Color.Red, 0.5f));
                    }
                    else if (npc.ai[3] > 10.0f && npc.ai[3] < 320.0f)
                    {
                        Projectile.NewProjectile(npc.position + new Vector2(Main.rand.Next(-720, 720), -720), npc.velocity,
                        ModContent.ProjectileType<RSpiritMana>(), npc.damage / 6, 0f);
                    }
                    else if (npc.ai[3] == 320.0f)
                    {
                        Main.NewText("<Reward Spirit> Because every time you come back or start all over again.", Color.Lerp(Color.Goldenrod, Color.Red, 0.5f));
                    }
                    else if (npc.ai[3] > 320.0f && npc.ai[3] < 620.0f)
                    {
                        Projectile.NewProjectile(npc.position + new Vector2(Main.rand.Next(-720, 720), -720), npc.velocity,
                        ModContent.ProjectileType<RSpiritMana>(), npc.damage / 4, 0f);
                        int num = Projectile.NewProjectile(npc.position + new Vector2(Main.rand.Next(-720, 720), 720), npc.velocity,
                        ModContent.ProjectileType<RSpiritMana>(), npc.damage / 4, 0f);
                        Main.projectile[num].ai[1] = 1.0f;
                    }
                    else if (npc.ai[3] == 620.0f)
                    {
                        Main.NewText("<Reward Spirit> What kind of evil spirits are you?!", Color.Lerp(Color.Goldenrod, Color.Red, 0.5f));
                    }
                    else if (npc.ai[3] == 720.0f)
                    {
                        Main.NewText("<Reward Spirit> You should have been dead already!", Color.Lerp(Color.Goldenrod, Color.Red, 0.25f));
                        npc.ai[0] = 1.0f;
                        npc.ai[1] = 0.0f;
                        npc.ai[3] = 0.0f;
                        if (player.statLife < player.statLifeMax2)
                        {
                            CombatText.NewText(npc.getRect(), Color.ForestGreen, "Your HP has been completely restored.", true);
                            player.statLife = player.statLifeMax2;
                        }
                    }
                    if (player.Distance(npc.position) > 800f)
                    {
                        npc.position = player.Center - new Vector2(firepos, firepos2);
                    }
                    MoveToPoint(npc.Center);
                    break;
            }
        }
        private void AI2()
        {
            Player player = Main.player[npc.target];
            float firepos;
            float firepos2;
            firepos = (player.Center.X > npc.Center.X) ? 300 : -300;
            firepos2 = 0;
            MoveToPoint(player.Center - new Vector2(firepos, firepos2));

            switch (npc.ai[1])
            {
                case 0f:
                    npc.ai[3]++;
                    if (npc.ai[3] == 10.0f)
                    {
                        Main.NewText("<Reward Spirit> ...", Color.Goldenrod);
                    }
                    else if (npc.ai[3] == 20.0f)
                    {
                        Main.NewText("<Reward Spirit> B-brother?", Color.Goldenrod);
                    }
                    else if (npc.ai[3] == 80.0f)
                    {
                        Main.NewText("<Reward Spirit> ... Okay.", Color.Lerp(Color.Goldenrod, Color.Blue, 0.25f));
                        NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<RSpiritBro>());
                    }
                    else if (npc.ai[3] == 120.0f)
                    {
                        Main.NewText("<Reward Spirit> Okay brother, let's teach this idiot how to play correctly!", Color.Goldenrod);
                    }
                    else if (npc.ai[3] == 160.0f)
                    {
                        Main.NewText("<Revenge Spirit> ok", Color.AliceBlue);
                        npc.ai[1] = 1.0f;
                        npc.ai[3] = 0.0f;
                    }
                    break;
                case 1f:
                    break;
            }
        }

        public void MoveToPoint(Vector2 point)
        {
            float moveSpeed = 20f;
            float velMultiplier = 1f;
            Vector2 dist = point - npc.Center;
            float length = dist == Vector2.Zero ? 0f : dist.Length();
            if (length < moveSpeed)
            {
                velMultiplier = MathHelper.Lerp(0f, 1f, length / moveSpeed);
            }
            if (length < 200f)
            {
                moveSpeed *= 0.5f;
            }
            if (length < 100f)
            {
                moveSpeed *= 0.5f;
            }
            if (length < 50f)
            {
                moveSpeed *= 0.5f;
            }
            if (length < 10f)
            {
                moveSpeed *= 0.01f;
            }
            npc.velocity = length == 0f ? Vector2.Zero : Vector2.Normalize(dist);
            npc.velocity *= moveSpeed;
            npc.velocity *= velMultiplier;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            if (npc.frameCounter < 5)
            {
                npc.frame.Y = 0 * frameHeight;
            }
            else if (npc.frameCounter < 10)
            {
                npc.frame.Y = 1 * frameHeight;
            }
            else if (npc.frameCounter < 15)
            {
                npc.frame.Y = 2 * frameHeight;
            }
            else if (npc.frameCounter < 20)
            {
                npc.frame.Y = 3 * frameHeight;
            }
            else
            {
                npc.frameCounter = 0;
            }
        }
    }
}
