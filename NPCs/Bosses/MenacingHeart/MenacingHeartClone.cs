using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using ElementalHearts.Projectiles.Bosses.MenacingHeart;
using System;
using Microsoft.Xna.Framework.Audio;

namespace ElementalHearts.NPCs.Bosses.MenacingHeart
{
    public class MenacingHeartClone : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Menacing Heart");
        }
        public override void SetDefaults()
        {
            npc.aiStyle = 0;
            npc.alpha = 128;
            npc.width = 128;
            npc.height = 128;
            npc.damage = 50;
            npc.defense = 0;
            npc.lifeMax = 1000;
            npc.HitSound = SoundID.Item35;
            npc.DeathSound = SoundID.Item25;
            npc.value = 100000;
            npc.buffImmune[BuffID.Confused] = true;
            npc.knockBackResist = 1f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.timeLeft = 100;
            base.SetDefaults();
        }
    }
}