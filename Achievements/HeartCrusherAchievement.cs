using ElementalHearts.NPCs.Bosses.MenacingHeart;
using Terraria.Achievements;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommons.Achievements;

namespace ElementalHearts.Achievements
{
    public class HeartCrusherAchievement : ModAchievement
    {
        public HeartCrusherAchievement() : base("Heart Crusher", "Defeat the Menacing Heart",
            AchievementCategory.Slayer)
        { }

        public override void SetDefaults()
        {
            AddCompletionFlag();
            AddConditions(NPCKilledCondition.Create((short)ModContent.NPCType<MenacingHeart>()));
        }

        private Mod mod = ModLoader.GetMod("WebmilioCommons");
        public override bool Autoload { get => mod != null; protected set => mod = Mod; }
    }
}
