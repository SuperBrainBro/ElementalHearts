using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.NPCs.Bosses.SteamHeart
{
    class SteamGear : ModNPC
    {
        public override string Texture => "ElementalHearts/NPCs/Bosses/SteamHeart/SteamHeart";
        public int MAX_LIFE = 20000;
        public int MAX_DAMAGE = 80;
        public override void SetDefaults()
        {
            npc.aiStyle = 0;
            npc.width = 132;
            npc.height = 132;
            npc.lifeMax = MAX_LIFE;
            npc.damage = MAX_DAMAGE;
            npc.defense = 50;
            npc.HitSound = SoundID.Item35;
            npc.DeathSound = SoundID.Item25;
            npc.buffImmune[BuffID.Confused] = true;
            npc.knockBackResist = 0f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.npcSlots = 5f;
            npc.netAlways = true;
            npc.timeLeft = 0;
            npc.scale = 0.5f;
            base.SetDefaults();
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = MAX_LIFE;
            npc.damage = MAX_DAMAGE;
        }
    }
}
