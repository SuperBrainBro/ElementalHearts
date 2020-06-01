using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using ElementalHearts.Projectiles.Bosses.MenacingHeart;
using System;

namespace ElementalHearts.NPCs.Bosses.MenacingHeart
{
    [AutoloadBossHead]
    public class MenacingHeart : ModNPC
    {
        public float bossPhaseHealth;

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
            npc.aiStyle = 0;
            npc.damage = 50;
            npc.defense = 16;
            npc.lifeMax = 18000;
            npc.HitSound = SoundID.Item35;
            npc.DeathSound = SoundID.Item25;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/MenacingHeartBossMusic");
            musicPriority = MusicPriority.BossHigh;
            npc.value = 100000;
            npc.buffImmune[BuffID.Confused] = true;
            npc.knockBackResist = 0f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.npcSlots = 5f;
            npc.boss = true;
            npc.netAlways = true;

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
                npc.lifeRegen = 100;
            }
            if (BP2)
            {
                npc.lifeRegen = 250;
            }
            if (BP3)
            {
                npc.lifeRegen = 500;
            }
            if (BP4)
            {
                npc.lifeRegen = 1000;
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
        public override void AI()
        {
            //Check If Player Is Dead
            if (Main.ActivePlayersCount == 0)
            {
                npc.color = Color.Silver;

                if (bossLeaveBool == false)
                {
                    npc.velocity = new Vector2(0, 10);
                    bossLeaveBool = true;
                }
                npc.velocity *= 2;
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
                    npc.scale = 0.8f;

                    //Phase Change Projectiles
                    if (P1P == false)
                    {
                        Projectile.NewProjectile(npc.Center, new Vector2(0, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 0), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(0, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 0), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

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
                    npc.scale = 1f;

                    //Phase Change Projectiles
                    if (P2P == false)
                    {
                        Projectile.NewProjectile(npc.Center, new Vector2(0, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 0), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(0, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 0), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

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
                    npc.scale = 1.2f;

                    //Phase Change Projectiles
                    if (P3P == false)
                    {
                        Projectile.NewProjectile(npc.Center, new Vector2(0, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 0), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(0, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 0), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

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
                    npc.scale = 1.4f;

                    //Phase Change Projectiles
                    if (P4P == false)
                    {
                        Projectile.NewProjectile(npc.Center, new Vector2(0, 4), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(4, 4), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(4, 0), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(4, -4), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(0, -4), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-4, -4), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-4, 0), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-4, 4), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

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
                if (P1 >= 200)
                {
                    npc.TargetClosest(true);

                    //This generates a random tp Center.
                    float tpPosRand1;
                    tpPosRand1 = Main.rand.NextFloat(8);

                    if (tpPosRand1 > 6)
                    {
                        npc.Center = Main.player[npc.target].Center + new Vector2(200, 0);

                        //Facing Left Projectiles
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 0), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

                        //Gravity Projectiles
                        if (Main.rand.NextBool(2))
                        {
                            GravityProjectiles(1);
                        }
                        else
                        {
                            GravityProjectiles(2);
                        }
                    }
                    else if (tpPosRand1 > 4)
                    {
                        npc.Center = Main.player[npc.target].Center + new Vector2(0, 200);

                        //Facing Up Projectiles
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(0, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

                        //No Gravity Projectiles
                    }
                    else if (tpPosRand1 > 2)
                    {
                        npc.Center = Main.player[npc.target].Center + new Vector2(-200, 0);

                        //Facing Right Projectiles
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 0), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

                        //Gravity Projectiles
                        if (Main.rand.NextBool(2))
                        {
                            GravityProjectiles(1);
                        }
                        else
                        {
                            GravityProjectiles(2);
                        }
                    }
                    else if (tpPosRand1 > 0)
                    {
                        npc.Center = Main.player[npc.target].Center + new Vector2(0, -200);

                        //Facing Down Projectiles
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(0, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

                        //Gravity Projectiles
                        if (Main.rand.NextBool(2))
                        {
                            GravityProjectiles(1);
                        }
                        else
                        {
                            GravityProjectiles(2);
                        }
                    }

                    P1 = 0;
                }
                else
                //Phase 2.
                if (P2 >= 175)
                {
                    npc.TargetClosest(true);

                    //This generates a random tp position.
                    float tpPosRand2;
                    tpPosRand2 = Main.rand.NextFloat(8);

                    if (tpPosRand2 > 6)
                    {
                        npc.Center = Main.player[npc.target].Center + new Vector2(200, 0);

                        //Facing Left Projectiles
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 0), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

                        //Gravity Projectiles
                        GravityProjectiles(2);
                    }
                    else if (tpPosRand2 > 4)
                    {
                        npc.Center = Main.player[npc.target].Center + new Vector2(0, 200);

                        //Facing Up Projectiles
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(0, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

                        //No Gravity Projectiles
                    }
                    else if (tpPosRand2 > 2)
                    {
                        npc.Center = Main.player[npc.target].Center + new Vector2(-200, 0);

                        //Facing Right Projectiles
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 0), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

                        //Gravity Projectiles
                        GravityProjectiles(2);
                    }
                    else if (tpPosRand2 > 0)
                    {
                        npc.Center = Main.player[npc.target].Center + new Vector2(0, -200);

                        //Facing Down Projectiles
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(0, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

                        //Gravity Projectiles
                        GravityProjectiles(2);
                    }

                    P2 = 0;
                }
                else
                //Phase 3.
                if (P3 >= 125)
                {
                    npc.TargetClosest(true);

                    //This generates a random tp position.
                    float tpPosRand3;
                    tpPosRand3 = Main.rand.NextFloat(8);

                    if (tpPosRand3 > 6)
                    {
                        npc.Center = Main.player[npc.target].Center + new Vector2(200, 0);

                        //Facing Left Projectiles
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 0), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

                        //Gravity Projectiles
                        if (Main.rand.NextBool(2))
                        {
                            GravityProjectiles(2);
                        }
                        else
                        {
                            GravityProjectiles(3);
                        }
                    }
                    else if (tpPosRand3 > 4)
                    {
                        npc.Center = Main.player[npc.target].Center + new Vector2(0, 200);

                        //Facing Up Projectiles
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(0, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

                        //No Gravity Projectiles
                    }
                    else if (tpPosRand3 > 2)
                    {
                        npc.Center = Main.player[npc.target].Center + new Vector2(-200, 0);

                        //Facing Right Projectiles
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 0), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

                        //Gravity Projectiles
                        if (Main.rand.NextBool(2))
                        {
                            GravityProjectiles(2);
                        }
                        else
                        {
                            GravityProjectiles(3);
                        }
                    }
                    else if (tpPosRand3 > 0)
                    {
                        npc.Center = Main.player[npc.target].Center + new Vector2(0, -200);

                        //Facing Down Projectiles
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(0, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

                        //Gravity Projectiles
                        if (Main.rand.NextBool(2))
                        {
                            GravityProjectiles(2);
                        }
                        else
                        {
                            GravityProjectiles(3);
                        }
                    }

                    P3 = 0;
                }
                else
                //Phase 4.
                if (P4 >= 75)
                {
                    npc.TargetClosest(true);

                    //This generates a random tp Center.
                    float tpPosRand4;
                    tpPosRand4 = Main.rand.NextFloat(8);

                    if (tpPosRand4 > 6)
                    {
                        npc.Center = Main.player[npc.target].Center + new Vector2(200, 0);

                        //Facing Left Projectiles
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 0), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

                        //Gravity Projectiles
                        GravityProjectiles(3);
                    }
                    else if (tpPosRand4 > 4)
                    {
                        npc.Center = Main.player[npc.target].Center + new Vector2(0, 200);

                        //Facing Up Projectiles
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(0, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

                        //No Gravity Projectiles
                    }
                    else if (tpPosRand4 > 2)
                    {
                        npc.Center = Main.player[npc.target].Center + new Vector2(-200, 0);

                        //Facing Right Projectiles
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 0), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(3, -3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

                        //Gravity Projectiles
                        GravityProjectiles(3);
                    }
                    else if (tpPosRand4 > 0)
                    {
                        npc.Center = Main.player[npc.target].Center + new Vector2(0, -200);

                        //Facing Down Projectiles
                        Projectile.NewProjectile(npc.Center, new Vector2(3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(0, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);
                        Projectile.NewProjectile(npc.Center, new Vector2(-3, 3), ProjectileType<MenacingProjectile>(), 50, 1f, Main.myPlayer);

                        //Gravity Projectiles
                        GravityProjectiles(3);
                    }

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

                    float degrees = 10f;
                    Vector2 direction = -Vector2.UnitY;

                    float distanceX = Main.player[npc.target].Center.X + Main.player[npc.target].velocity.X - npc.Center.X;
                    int sign = (distanceX > 0).ToDirectionInt();
                    float tilt = 20 * Math.Min(1f, Math.Abs(distanceX) / 600);

                    direction = direction.RotatedBy(MathHelper.ToRadians(sign * tilt));
                    direction = direction.RotatedBy(-MathHelper.ToRadians(-degrees / 2 + degrees * amount / 2));
                    int damage = (int)(npc.damage / (Main.damageMultiplier * 2 * 4));
                    for (int i = 0; i < amount; i++)
                    {
                        Projectile.NewProjectile(npc.Top, direction * 10f, ModContent.ProjectileType<SmallMenacingProjectile>(), damage, 0f, Main.myPlayer);
                        direction = direction.RotatedBy(MathHelper.ToRadians(degrees));
                    }

                }
            }
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
            base.BossLoot(ref name, ref potionType);
        }
    }
}