using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using ElementalHearts.Projectiles.Bosses.MenacingHeart;
using System;
using System.IO;
using ElementalHearts.Items.Boss;
using Terraria.Audio;
using ElementalHearts.Items.Weapons;

namespace ElementalHearts.NPCs.Bosses.MenacingHeart
{
    [AutoloadBossHead]
    public class MenacingHeart : ModNPC
    {
        public float bossPhaseHealth;

        public float timeLeftTillDespawn;

        public float P1;
        public float P2;
        public float P3;
        public float P4;

        public bool P1P;
        public bool P2P;
        public bool P3P;
        public bool P4P;

        public bool BP1;
        public bool BP2;
        public bool BP3;
        public bool BP4;

        public bool bossLeaveBool;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Menacing Heart");
            Main.npcFrameCount[npc.type] = 14; // make sure to set this for your modnpcs.
        }
        public override void SetDefaults()
        {
            npc.aiStyle = 0;
            npc.width = 128;
            npc.height = 128;
            npc.damage = 69;
            npc.defense = 16;
            npc.lifeMax = 16000;
            npc.HitSound = SoundID.Item35;
            npc.DeathSound = SoundID.Item25;
            music = mod.GetSoundSlot(Terraria.ModLoader.SoundType.Music, "Sounds/Music/MenacingHeartBossMusic");
            musicPriority = MusicPriority.BossLow;
            npc.value = 100000;
            npc.buffImmune[BuffID.Confused] = true;
            npc.knockBackResist = 0f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.npcSlots = 5f;
            npc.boss = true;
            npc.netAlways = true;
            npc.timeLeft = 0;

            bossPhaseHealth = npc.lifeMax / 4;
            base.SetDefaults();
        }
        public override bool CheckDead()
        {
            Main.NewText("<Menacing.Heart69$> You have weakened me. I will come back though, if you ever need me.", Color.White);
            return base.CheckDead();
        }
        public override void UpdateLifeRegen(ref int damage)
        {
            if (BP1)
            {
                npc.lifeRegen = 50 / 3;

            }
            else if (BP2)
            {
                npc.lifeRegen = 125 / 4;

            }
            else if (BP3)
            {
                npc.lifeRegen = 250 / 5;

            }
            else if (BP4)
            {
                npc.lifeRegen = 500 / 6;

            }
            base.UpdateLifeRegen(ref damage);
        }
        public override void DrawEffects(ref Color drawColor)
        {
            if (BP4)
            {
                drawColor = Main.DiscoColor;
            }
            base.DrawEffects(ref drawColor);
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.625f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.6f);
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
        public override void AI()
        {
            //LIGHT (BEFORE EVERYTHING ELSE)
            Lighting.AddLight(npc.Center, new Vector3(1, 0, 0));

            //Check If Player Is Dead
            if (!AnyPlayerAlive)
            {
                npc.color = Color.Gray;

                if (bossLeaveBool == false)
                {
                    npc.velocity = new Vector2(0, -0.5f);
                    bossLeaveBool = true;
                }
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Sandstorm, 0, 5, 0, Main.DiscoColor, 2);
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Sandstorm, 0, 5, 0, Color.Red, 1);
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Sandstorm, 0, 5, 0, Color.Black, 1);
                Dust.NewDust(npc.position, npc.width, npc.height, DustID.Sandstorm, 0, 5, 0, Color.White, 1);

                npc.velocity *= 1.04f;

                if (timeLeftTillDespawn > 30)
                {
                    npc.active = false;
                }
                else
                {
                    timeLeftTillDespawn += .1f;
                }
            }
            else
            {
                if (npc.life > bossPhaseHealth * 3)
                {
                    //Set phase to 1.
                    npc.ai[0] = 1;
                    BP1 = true;
                    BP2 = false;
                    BP3 = false;
                    BP4 = false;

                    //Scale
                    npc.scale = 0.8f;
                    npc.width = 103;
                    npc.height = 103;

                    //Phase Change Projectiles
                    if (Main.netMode != NetmodeID.MultiplayerClient && P1P == false)
                    {
                        Projectile.NewProjectile(npc.Center, new Vector2(0, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(0, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                        Main.PlaySound(new LegacySoundStyle(SoundID.ForceRoar, 0), npc.Center);
                        P1P = true;
                    }
                }
                else if (npc.life > bossPhaseHealth * 2)
                {
                    //Set phase to 2.
                    npc.ai[0] = 2;
                    BP1 = false;
                    BP2 = true;
                    BP3 = false;
                    BP4 = false;

                    //Scale
                    npc.scale = 1f;
                    npc.width = 128;
                    npc.height = 128;

                    //Phase Change Projectiles
                    if (Main.netMode != NetmodeID.MultiplayerClient && P2P == false)
                    {
                        Projectile.NewProjectile(npc.Center, new Vector2(0, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(0, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                        Main.PlaySound(new LegacySoundStyle(SoundID.ForceRoar, 0), npc.Center);
                        P2P = true;
                    }
                }
                else if (npc.life > bossPhaseHealth * 1)
                {
                    //Set phase to 3.
                    npc.ai[0] = 3;
                    BP1 = false;
                    BP2 = false;
                    BP3 = true;
                    BP4 = false;

                    //Scale
                    npc.scale = 1.2f;
                    npc.width = 154;
                    npc.height = 154;

                    //Phase Change Projectiles
                    if (Main.netMode != NetmodeID.MultiplayerClient && P3P == false)
                    {
                        Projectile.NewProjectile(npc.Center, new Vector2(0, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(0, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                        Main.PlaySound(new LegacySoundStyle(SoundID.ForceRoar, 0), npc.Center);
                        P3P = true;
                    }
                }
                else if (npc.life > bossPhaseHealth * 0)
                {
                    //Set phase to 4.
                    npc.ai[0] = 4;
                    BP1 = false;
                    BP2 = false;
                    BP3 = false;
                    BP4 = true;

                    //Scale
                    npc.scale = 1.4f;
                    npc.width = 180;
                    npc.height = 180;

                    //Phase Change Projectiles
                    if (Main.netMode != NetmodeID.MultiplayerClient && P4P == false)
                    {
                        Projectile.NewProjectile(npc.Center, new Vector2(0, 4), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(4, 4), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(4, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(4, -4), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(0, -4), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-4, -4), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-4, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-4, 4), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                        Main.PlaySound(new LegacySoundStyle(SoundID.ForceRoar, 0), npc.Center);
                        P4P = true;
                    }
                }

                //npc.ai[0] is the current phase. So the below code, checks for if it is phase 1. If it is in phase 1, then npc.ai[1] goes up (which is the timer for phase 10
                if (npc.ai[0] == 1)
                {
                    P1++;
                }
                else if (npc.ai[0] == 2)
                {
                    P2++;
                }
                else if (npc.ai[0] == 3)
                {
                    P3++;
                }
                else if (npc.ai[0] == 4)
                {
                    P4++;
                }

                //This is the phase code, the one below, is the phase 1 code.
                if (Main.netMode != NetmodeID.MultiplayerClient && P1 >= 200)
                {
                    npc.TargetClosest(true);

                    //This generates a random tp Center.
                    float tpPosRand1;
                    tpPosRand1 = Main.rand.NextFloat(8);

                    if (tpPosRand1 > 6)
                    {
                        Main.NewText("Sent Particle");

                        if (P1 >= 300)
                        {
                            npc.Center = Main.player[npc.target].Center + new Vector2(175, 0);

                            //Facing Left Projectiles
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                            //Gravity Projectiles
                            if (Main.rand.NextBool(2))
                            {
                                GravityProjectiles(1);
                            }
                            else
                            {
                                GravityProjectiles(2);
                            }

                            //Clone 1
                            if (Main.rand.NextBool(3))
                            {
                                NPC.NewNPC(50 + (int)Main.player[npc.target].Center.X + -175, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, 50 + (int)Main.player[npc.target].Center.Y + 175, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, -50 + (int)Main.player[npc.target].Center.Y + -175, NPCType<MenacingHeartClone>());
                            }
                        }
                    }
                    else if (tpPosRand1 > 4)
                    {
                        Main.NewText("Sent Particle");

                        if (P1 >= 300)
                        {
                            npc.Center = Main.player[npc.target].Center + new Vector2(0, 175);

                            //Facing Up Projectiles
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(0, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                            //No Gravity Projectiles

                            //Clone 2
                            if (Main.rand.NextBool(2))
                            {
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, -50 + (int)Main.player[npc.target].Center.Y + -175, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(50 + (int)Main.player[npc.target].Center.X + 175, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(-50 + (int)Main.player[npc.target].Center.X + -175, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                            }
                        }
                    }
                    else if (tpPosRand1 > 2)
                    {
                        Main.NewText("Sent Particle");

                        if (P1 >= 300)
                        {
                            npc.Center = Main.player[npc.target].Center + new Vector2(-175, 0);

                            //Facing Right Projectiles
                            Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                            //Gravity Projectiles
                            if (Main.rand.NextBool(2))
                            {
                                GravityProjectiles(1);
                            }
                            else
                            {
                                GravityProjectiles(2);
                            }

                            //Clone 3
                            if (Main.rand.NextBool(3))
                            {
                                NPC.NewNPC(50 + (int)Main.player[npc.target].Center.X + 175, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, -50 + (int)Main.player[npc.target].Center.Y + -175, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, 50 + (int)Main.player[npc.target].Center.Y + 175, NPCType<MenacingHeartClone>());
                            }
                        }
                    }
                    else if (tpPosRand1 > 0)
                    {
                        Main.NewText("Sent Particle");

                        if (P1 >= 300)
                        {
                            npc.Center = Main.player[npc.target].Center + new Vector2(0, -175);

                            //Facing Down Projectiles
                            Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(0, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                            //Gravity Projectiles
                            if (Main.rand.NextBool(2))
                            {
                                GravityProjectiles(1);
                            }
                            else
                            {
                                GravityProjectiles(2);
                            }

                            //Clone 4
                            if (Main.rand.NextBool(4))
                            {
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, 50 + (int)Main.player[npc.target].Center.Y + 175, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(-50 + (int)Main.player[npc.target].Center.X + -175, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(50 + (int)Main.player[npc.target].Center.X + 175, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                            }
                        }
                    }
                    SpawnHealHearts(4);
                    P1 = 0;
                }
                else

                //Phase 2.
                if (Main.netMode != NetmodeID.MultiplayerClient && P2 >= 175)
                {
                    npc.TargetClosest(true);

                    //This generates a random tp position.
                    float tpPosRand2;
                    tpPosRand2 = Main.rand.NextFloat(8);

                    if (tpPosRand2 > 6)
                    {
                        Main.NewText("Sent Particle");

                        if (P2 >= 300)
                        {
                            npc.Center = Main.player[npc.target].Center + new Vector2(200, 0);

                            //Facing Left Projectiles
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                            //Gravity Projectiles
                            GravityProjectiles(2);

                            //Clone 1
                            if (Main.rand.NextBool(3))
                            {
                                NPC.NewNPC(-50 + (int)Main.player[npc.target].Center.X + -200, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, 50 + (int)Main.player[npc.target].Center.Y + 200, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, -50 + (int)Main.player[npc.target].Center.Y + -200, NPCType<MenacingHeartClone>());
                            }
                        }
                    }
                    else if (tpPosRand2 > 4)
                    {
                        Main.NewText("Sent Particle");

                        if (P2 >= 300)
                        {
                            npc.Center = Main.player[npc.target].Center + new Vector2(0, 200);

                            //Facing Up Projectiles
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(0, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                            //No Gravity Projectiles

                            //Clone 2
                            if (Main.rand.NextBool(2))
                            {
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, -50 + (int)Main.player[npc.target].Center.Y + -200, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(50 + (int)Main.player[npc.target].Center.X + 200, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(-50 + (int)Main.player[npc.target].Center.X + -200, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                            }
                        }
                    }
                    else if (tpPosRand2 > 2)
                    {
                        Main.NewText("Sent Particle");

                        if (P2 >= 300)
                        {
                            npc.Center = Main.player[npc.target].Center + new Vector2(-200, 0);

                            //Facing Right Projectiles
                            Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                            //Gravity Projectiles
                            GravityProjectiles(2);

                            //Clone 3
                            if (Main.rand.NextBool(3))
                            {
                                NPC.NewNPC(50 + (int)Main.player[npc.target].Center.X + 200, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, -50 + (int)Main.player[npc.target].Center.Y + -200, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, 50 + (int)Main.player[npc.target].Center.Y + 200, NPCType<MenacingHeartClone>());
                            }
                        }
                    }
                    else if (tpPosRand2 > 0)
                    {
                        Main.NewText("Sent Particle");

                        if (P2 >= 300)
                        {
                            npc.Center = Main.player[npc.target].Center + new Vector2(0, -200);

                            //Facing Down Projectiles
                            Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(0, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                            //Gravity Projectiles
                            GravityProjectiles(2);

                            //Clone 4
                            if (Main.rand.NextBool(4))
                            {
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, 50 + (int)Main.player[npc.target].Center.Y + 200, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(-50 + (int)Main.player[npc.target].Center.X + -200, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(50 + (int)Main.player[npc.target].Center.X + 200, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                            }
                        }
                    }
                    SpawnHealHearts(4);
                    P2 = 0;
                }
                else
                //Phase 3.
                if (Main.netMode != NetmodeID.MultiplayerClient && P3 >= 125)
                {
                    npc.TargetClosest(true);

                    //This generates a random tp position.
                    float tpPosRand3;
                    tpPosRand3 = Main.rand.NextFloat(8);

                    if (tpPosRand3 > 6)
                    {
                        Main.NewText("Sent Particle");

                        if (P3 >= 300)
                        {
                            npc.Center = Main.player[npc.target].Center + new Vector2(225, 0);

                            //Facing Left Projectiles
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                            //Gravity Projectiles
                            if (Main.rand.NextBool(2))
                            {
                                GravityProjectiles(2);
                            }
                            else
                            {
                                GravityProjectiles(3);
                            }

                            //Clone 1
                            if (Main.rand.NextBool(3))
                            {
                                NPC.NewNPC(-50 + (int)Main.player[npc.target].Center.X + -200, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, 50 + (int)Main.player[npc.target].Center.Y + 200, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, -50 + (int)Main.player[npc.target].Center.Y + -200, NPCType<MenacingHeartClone>());
                            }
                        }
                    }
                    else if (tpPosRand3 > 4)
                    {
                        Main.NewText("Sent Particle");

                        if (P3 >= 300)
                        {
                            npc.Center = Main.player[npc.target].Center + new Vector2(0, 225);

                            //Facing Up Projectiles
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(0, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                            //No Gravity Projectiles

                            //Clone 2
                            if (Main.rand.NextBool(2))
                            {
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, -50 + (int)Main.player[npc.target].Center.Y + -225, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(50 + (int)Main.player[npc.target].Center.X + 225, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(-50 + (int)Main.player[npc.target].Center.X + -225, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                            }
                        }
                    }
                    else if (tpPosRand3 > 2)
                    {
                        Main.NewText("Sent Particle");

                        if (P3 >= 300)
                        {
                            npc.Center = Main.player[npc.target].Center + new Vector2(-225, 0);

                            //Facing Right Projectiles
                            Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                            //Gravity Projectiles
                            if (Main.rand.NextBool(2))
                            {
                                GravityProjectiles(2);
                            }
                            else
                            {
                                GravityProjectiles(3);
                            }

                            //Clone 3
                            if (Main.rand.NextBool(3))
                            {
                                NPC.NewNPC(50 + (int)Main.player[npc.target].Center.X + 225, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, -50 + (int)Main.player[npc.target].Center.Y + -225, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, 50 + (int)Main.player[npc.target].Center.Y + 225, NPCType<MenacingHeartClone>());
                            }
                        }
                    }
                    else if (tpPosRand3 > 0)
                    {
                        Main.NewText("Sent Particle");

                        if (P3 >= 300)
                        {
                            npc.Center = Main.player[npc.target].Center + new Vector2(0, -225);

                            //Facing Down Projectiles
                            Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(0, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                            //Gravity Projectiles
                            if (Main.rand.NextBool(2))
                            {
                                GravityProjectiles(2);
                            }
                            else
                            {
                                GravityProjectiles(3);
                            }

                            //Clone 4
                            if (Main.rand.NextBool(4))
                            {
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, 50 + (int)Main.player[npc.target].Center.Y + 225, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(-50 + (int)Main.player[npc.target].Center.X + -225, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(50 + (int)Main.player[npc.target].Center.X + 225, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                            }
                        }
                    }
                    SpawnHealHearts(3);
                    P3 = 0;
                }
                else
                //Phase 4.
                if (Main.netMode != NetmodeID.MultiplayerClient && P4 >= 75)
                {
                    npc.TargetClosest(true);

                    //This generates a random tp Center.
                    float tpPosRand4;
                    tpPosRand4 = Main.rand.NextFloat(8);

                    if (tpPosRand4 > 6)
                    {
                        Main.NewText("Sent Particle");

                        if (P4 >= 300)
                        {
                            npc.Center = Main.player[npc.target].Center + new Vector2(250, 0);

                            //Facing Left Projectiles
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                            //Gravity Projectiles
                            GravityProjectiles(4);

                            //Clone 1
                            if (Main.rand.NextBool(4))
                            {
                                NPC.NewNPC(-50 + (int)Main.player[npc.target].Center.X + -250, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, 50 + (int)Main.player[npc.target].Center.Y + 250, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, -50 + (int)Main.player[npc.target].Center.Y + -250, NPCType<MenacingHeartClone>());
                            }
                        }
                    }
                    else if (tpPosRand4 > 4)
                    {
                        Main.NewText("Sent Particle");
                        if (P4 >= 300)
                        {
                            npc.Center = Main.player[npc.target].Center + new Vector2(0, 250);

                            //Facing Up Projectiles
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(0, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                            //No Gravity Projectiles

                            //Clone 2
                            if (Main.rand.NextBool(3))
                            {
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, -50 + (int)Main.player[npc.target].Center.Y + -225, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(50 + (int)Main.player[npc.target].Center.X + 225, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(-50 + (int)Main.player[npc.target].Center.X + -225, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                            }
                        }
                    }
                    else if (tpPosRand4 > 2)
                    {
                        Main.NewText("Sent Particle");

                        if (P4 >= 300)
                        {
                            npc.Center = Main.player[npc.target].Center + new Vector2(-250, 0);

                            //Facing Right Projectiles
                            Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(3, 0), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                            //Gravity Projectiles
                            GravityProjectiles(4);

                            //Clone 3
                            if (Main.rand.NextBool(4))
                            {
                                NPC.NewNPC(50 + (int)Main.player[npc.target].Center.X + 250, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, -50 + (int)Main.player[npc.target].Center.Y + -250, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, 50 + (int)Main.player[npc.target].Center.Y + 250, NPCType<MenacingHeartClone>());
                            }
                        }
                    }
                    else if (tpPosRand4 > 0)
                    {
                        Main.NewText("Sent Particle");

                        if (P4 >= 300)
                        {
                            npc.Center = Main.player[npc.target].Center + new Vector2(0, -250);

                            //Facing Down Projectiles
                            Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(0, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);
                            Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50 * 2, 1f, Main.myPlayer);

                            //Gravity Projectiles
                            GravityProjectiles(4);

                            //Clone 4
                            if (Main.rand.NextBool(5))
                            {
                                NPC.NewNPC(0 + (int)Main.player[npc.target].Center.X + 0, 50 + (int)Main.player[npc.target].Center.Y + 250, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(-50 + (int)Main.player[npc.target].Center.X + -250, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                                NPC.NewNPC(50 + (int)Main.player[npc.target].Center.X + 250, 0 + (int)Main.player[npc.target].Center.Y + 0, NPCType<MenacingHeartClone>());
                            }
                        }
                    }
                    SpawnHealHearts(3);
                    P4 = 0;
                }
            }
            base.AI();
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood, npc.velocity.X, npc.velocity.Y, 0, Color.DarkRed, 2);
            base.HitEffect(hitDirection, damage);
        }

        // Our texture is 32x32 with 2 pixels of padding vertically, so 34 is the vertical spacing.  These are for my benefit and the numbers could easily be used directly in the code below, but this is how I keep code organized.
        private const int Frame_P1 = 0;
        private const int Frame_P2 = 1;
        private const int Frame_P3 = 2;

        // Phase 4 has 11 frames
        private const int Frame_P4_1 = 3;
        private const int Frame_P4_2 = 4;
        private const int Frame_P4_3 = 5;
        private const int Frame_P4_4 = 6;
        private const int Frame_P4_5 = 7;
        private const int Frame_P4_6 = 8;
        private const int Frame_P4_7 = 9;
        private const int Frame_P4_8 = 10;
        private const int Frame_P4_9 = 11;
        private const int Frame_P4_10 = 12;
        private const int Frame_P4_11 = 13;
        public override void FindFrame(int frameHeight)
        {
            // This makes the sprite flip horizontally in conjunction with the npc.direction.
            //npc.spriteDirection = npc.direction;

            // For the most part, our animation matches up with our states.
            if (BP1 == true)
            {
                // npc.frame.Y is the goto way of changing animation frames. npc.frame starts from the top left corner in pixel coordinates, so keep that in mind.
                npc.frame.Y = Frame_P1 * frameHeight;
            }
            else if (BP2 == true)
            {
                npc.frame.Y = Frame_P2 * frameHeight;
            }
            else if (BP3 == true)
            {
                npc.frame.Y = Frame_P3 * frameHeight;
            }
            else if (BP4 == true)
            {
                // Here we have 3 frames that we want to cycle through.
                npc.frameCounter++;
                if (npc.frameCounter < 5)
                {
                    npc.frame.Y = Frame_P4_1 * frameHeight;
                }
                else if (npc.frameCounter < 10)
                {
                    npc.frame.Y = Frame_P4_2 * frameHeight;
                }
                else if (npc.frameCounter < 15)
                {
                    npc.frame.Y = Frame_P4_3 * frameHeight;
                }
                else if (npc.frameCounter < 20)
                {
                    npc.frame.Y = Frame_P4_4 * frameHeight;
                }
                else if (npc.frameCounter < 25)
                {
                    npc.frame.Y = Frame_P4_5 * frameHeight;
                }
                else if (npc.frameCounter < 30)
                {
                    npc.frame.Y = Frame_P4_6 * frameHeight;
                }
                else if (npc.frameCounter < 35)
                {
                    npc.frame.Y = Frame_P4_7 * frameHeight;
                }
                else if (npc.frameCounter < 40)
                {
                    npc.frame.Y = Frame_P4_8 * frameHeight;
                }
                else if (npc.frameCounter < 45)
                {
                    npc.frame.Y = Frame_P4_9 * frameHeight;
                }
                else if (npc.frameCounter < 50)
                {
                    npc.frame.Y = Frame_P4_10 * frameHeight;
                }
                else if (npc.frameCounter < 55)
                {
                    npc.frame.Y = Frame_P4_11 * frameHeight;
                }
                else
                {
                    npc.frameCounter = 0;
                }
            }
            base.FindFrame(frameHeight);
        }
        public void GravityProjectiles(int randChance)
        {
            if (Main.rand.NextBool(randChance))
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    int amount = Math.Min((int)(2f * npc.lifeMax / npc.life), 10);

                    if (Main.expertMode)
                    {
                        amount += 2;
                    }

                    float degrees = 9f;
                    Vector2 direction = -Vector2.UnitY;

                    float distanceX = Main.player[npc.target].Center.X + Main.player[npc.target].velocity.X - npc.Center.X;
                    int sign = (distanceX > 0).ToDirectionInt();
                    float tilt = 20 * Math.Min(1f, Math.Abs(distanceX) / 600);

                    direction = direction.RotatedBy(MathHelper.ToRadians(sign * tilt));
                    direction = direction.RotatedBy(-MathHelper.ToRadians(-degrees / 2 + degrees * amount / 2));
                    int damage = (int)(npc.damage / (Main.damageMultiplier * 2 * 4));
                    damage *= 10;
                    for (int i = 0; i < amount; i++)
                    {
                        Projectile.NewProjectile(npc.Top, direction * 10f, ModContent.ProjectileType<SmallMenacingProjectile>(), damage, 0f, Main.myPlayer);
                        direction = direction.RotatedBy(MathHelper.ToRadians(degrees));
                    }

                }
            }
            else if (Main.rand.NextBool(randChance * 2))
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    int amount = Math.Min((int)(2f * npc.lifeMax / npc.life), 10);

                    if (Main.expertMode)
                    {
                        amount += 4;
                    }
                    else
                    {
                        amount += 2;
                    }

                    float degrees = 9f;
                    Vector2 direction = -Vector2.UnitY;

                    float distanceX = Main.player[npc.target].Center.X + Main.player[npc.target].velocity.X - npc.Center.X;
                    int sign = (distanceX > 0).ToDirectionInt();
                    float tilt = 20 * Math.Min(1f, Math.Abs(distanceX) / 600);

                    direction = direction.RotatedBy(MathHelper.ToRadians(sign * tilt));
                    direction = direction.RotatedBy(-MathHelper.ToRadians(-degrees / 2 + degrees * amount / 2));
                    int damage = (int)(npc.damage / (Main.damageMultiplier * 2 * 4));
                    damage *= 10;
                    for (int i = 0; i < amount; i++)
                    {
                        Projectile.NewProjectile(npc.Top, direction * 10f, ModContent.ProjectileType<SmallMenacingProjectile>(), damage, 0f, Main.myPlayer);
                        direction = direction.RotatedBy(MathHelper.ToRadians(degrees));
                    }

                }
            }
        }

        public void SpawnHealHearts(int chance)
        {
            if (Main.rand.NextBool(chance * 2))
            {
                Item.NewItem(npc.position, ItemID.Heart);
                if (Main.rand.NextBool(chance))
                {
                    Item.NewItem(npc.position, ItemID.Heart);
                    if (Main.rand.NextBool(chance * 2))
                    {
                        Item.NewItem(npc.position, ItemID.Heart);
                    }
                }
            }
            else if (Main.rand.NextBool(chance * 4))
            {
                Item.NewItem(npc.position, ItemID.Heart);
                if (Main.rand.NextBool(chance))
                {
                    Item.NewItem(npc.position, ItemID.Heart);
                    if (Main.rand.NextBool(chance * 2))
                    {
                        Item.NewItem(npc.position, ItemID.Heart);
                    }
                }
                if (Main.rand.NextBool(chance))
                {
                    Item.NewItem(npc.position, ItemID.Heart);
                    if (Main.rand.NextBool(chance * 2))
                    {
                        Item.NewItem(npc.position, ItemID.Heart);
                    }
                }
            }
            else if (Main.rand.NextBool(chance * 8))
            {
                Item.NewItem(npc.position, ItemID.Heart);
                if (Main.rand.NextBool(chance))
                {
                    Item.NewItem(npc.position, ItemID.Heart);
                    if (Main.rand.NextBool(chance * 2))
                    {
                        Item.NewItem(npc.position, ItemID.Heart);
                    }
                }
                if (Main.rand.NextBool(chance))
                {
                    Item.NewItem(npc.position, ItemID.Heart);
                    if (Main.rand.NextBool(chance * 2))
                    {
                        Item.NewItem(npc.position, ItemID.Heart);
                    }
                }
                if (Main.rand.NextBool(chance))
                {
                    Item.NewItem(npc.position, ItemID.Heart);
                    if (Main.rand.NextBool(chance * 2))
                    {
                        Item.NewItem(npc.position, ItemID.Heart);
                    }
                }
            }
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            //Phase
            writer.Write(P1);
            writer.Write(P2);
            writer.Write(P3);
            writer.Write(P4);

            //Phase Attack
            writer.Write(P1P);
            writer.Write(P2P);
            writer.Write(P3P);
            writer.Write(P4P);

            //Phase Bool
            writer.Write(BP1);
            writer.Write(BP2);
            writer.Write(BP3);
            writer.Write(BP4);
        }
        public override void ReceiveExtraAI(BinaryReader reader)
        {
            //Phase
            P1 = reader.ReadInt32();
            P2 = reader.ReadInt32();
            P3 = reader.ReadInt32();
            P4 = reader.ReadInt32();

            //Phase Attack
            P1P = reader.ReadBoolean();
            P2P = reader.ReadBoolean();
            P3P = reader.ReadBoolean();
            P4P = reader.ReadBoolean();

            //Phase Bool
            BP1 = reader.ReadBoolean();
            BP2 = reader.ReadBoolean();
            BP3 = reader.ReadBoolean();
            BP4 = reader.ReadBoolean();
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
            int choice = Main.rand.Next(10);
            if (choice == 0)
            {
                //Item.NewItem(npc.getRect(), ItemType<Trophy>());
            }
            if (Main.expertMode)
            {
                Item.NewItem(npc.getRect(), ItemType<MenacingLookingHeartBag>());
            }
            else
            {
                choice = Main.rand.Next(7);
                if (choice == 0)
                {
                    //Item.NewItem(npc.getRect(), ItemType<Mask>());
                }
                Item.NewItem(npc.getRect(), ItemType<MenacingLifeStaff>());
            }
            if (!ElementalHeartsWorld.downedMenacingHeart)
            {
                ElementalHeartsWorld.downedMenacingHeart = true;
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
                }
            }
            base.BossLoot(ref name, ref potionType);
        }
        public static bool AnyPlayerAlive
        {
            get
            {
                Player p;
                if (Main.netMode == NetmodeID.SinglePlayer)
                {
                    p = Main.LocalPlayer;
                    return p.active && !(p.dead || p.ghost);
                }
                for (int i = 0; i < Main.player.Length; i++)
                {
                    p = Main.player[i];
                    if (p.active && !p.dead)
                        return true;
                }
                return false;
            }
        }
    }
}