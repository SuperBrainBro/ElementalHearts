using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
namespace ElementalHearts.NPCs.Bosses.MenacingHeart
{
    [AutoloadBossHead]
    public class MenacingHeart : ModNPC
    {
        public override void SetDefaults()
        {
            npc.width = 128;
            npc.height = 128;
            npc.aiStyle = 0;
            npc.damage = 200;
            npc.defense = 24;
            npc.lifeMax = 16000;
            npc.HitSound = SoundID.Item35;
            npc.DeathSound = SoundID.Item25;
            npc.value = 100000;
            npc.buffImmune[BuffID.Confused] = true;
            npc.knockBackResist = 0f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.npcSlots = 20f;
            npc.boss = true;
            npc.netAlways = true;
            base.SetDefaults();
        }
        public override void AI()
        {
            //This float, bossPhaseHealth, is the amount of health divided by 4. Since there are 4 phases, there are 4 equal amounts. (See below code for example)
             float bossPhaseHealth;
            bossPhaseHealth = npc.lifeMax / 4;
            
            if (npc.life > bossPhaseHealth * 3)
            {
                //Set phase to 1.
                npc.ai[0] = 1;
            }
            else if (npc.life > bossPhaseHealth * 2)
            {
                //Set phase to 2.
                npc.ai[0] = 2;
            }
            else if (npc.life > bossPhaseHealth * 1)
            {
                //Set phase to 3.
                npc.ai[0] = 3;
            }
            else if (npc.life > bossPhaseHealth * 0)
            {
                //Set phase to 4.
                npc.ai[0] = 4;
            }

            //npc.ai[0] is the current phase. So the below code, checks for if it is phase 1. If it is in phase 1, then npc.ai[1] goes up (which is the timer for phase 10
            if (npc.ai[0] == 1)
            {
                npc.ai[1]++;
            }
            else if (npc.ai[0] == 2)
            {
                npc.ai[2]++;
            }
            else if (npc.ai[0] == 3)
            {
                npc.ai[3]++;
            }
            else if (npc.ai[0] == 4)
            {
                npc.ai[4]++;
            }

            //This is the phase code, the one below, is the phase 1 code.
            if (npc.ai[1] >= 20)
            {
                npc.TargetClosest(true);

                npc.position = Main.player[npc.target].position + new Vector2(100, 0);
                npc.ai[1] = 0;
            }

            //Phase 2.
            if (npc.ai[1] >= 15)
            {
                npc.TargetClosest(true);

                npc.position = Main.player[npc.target].position + new Vector2(100, 0);
                npc.ai[1] = 0;
            }

            //Phase 3.
            if (npc.ai[1] >= 10)
            {
                npc.TargetClosest(true);

                npc.position = Main.player[npc.target].position + new Vector2(100, 0);
                npc.ai[1] = 0;
            }

            //Phase 4.
            if (npc.ai[1] >= 5)
            {
                npc.TargetClosest(true);

                npc.position = Main.player[npc.target].position + new Vector2(100, 0);
                npc.ai[1] = 0;
            }
            base.AI();
        }

        public override void HitEffect(int hitDirection, double damage)
        {

            base.HitEffect(hitDirection, damage);
        }
        public override void FindFrame(int frameHeight)
        {

            base.FindFrame(frameHeight);
        }
        public override void BossLoot(ref string name, ref int potionType)
        {

            base.BossLoot(ref name, ref potionType);
        }
    }
}