using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ElementalHearts.NPCs.Bosses.RewardSpirit
{
    public class RSpiritBro : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Revenge Spirit");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.dontTakeDamageFromHostiles = true;
            npc.dontTakeDamage = true;
            npc.lifeMax = 1;
            npc.defense = 10;
            npc.damage = 120;
            npc.width = mod.GetTexture(Texture.Replace("ElementalHearts/", "")).Width;
            npc.height = mod.GetTexture(Texture.Replace("ElementalHearts/", "")).Height / Main.npcFrameCount[npc.type];
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.netAlways = true;
        }

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
