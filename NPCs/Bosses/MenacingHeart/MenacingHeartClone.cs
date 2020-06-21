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
        public float cloneTimeLeft;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Menacing Heart");
        }
        public override void SetDefaults()
        {
            npc.aiStyle = 0;
            npc.alpha = 128;
            npc.width = 0;
            npc.height = 0;
            npc.defense = -10;
            npc.lifeMax = 10;
            npc.HitSound = SoundID.Item35;
            npc.DeathSound = SoundID.Item25;
            npc.value = 100;
            npc.buffImmune[BuffID.Confused] = true;
            npc.knockBackResist = 0f;
            npc.noGravity = true;
            npc.noTileCollide = true;

            cloneTimeLeft = 420;
            base.SetDefaults();
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 0f;
            return base.DrawHealthBar(hbPosition, ref scale, ref position);
        }
        public override void AI()
        {
            //LIGHT (BEFORE EVERYTHING ELSE)
            Lighting.AddLight(npc.Center, new Vector3(1, 0, 0));

            npc.alpha = (int)(255 - (cloneTimeLeft));
            if (cloneTimeLeft < 0)
            {
                npc.active = false;
            } else
            {
                cloneTimeLeft -= 5;
            }
            base.AI();
        }
    }
}