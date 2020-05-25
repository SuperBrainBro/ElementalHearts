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
            base.SetDefaults();
        }
        public override void AI()
        {

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