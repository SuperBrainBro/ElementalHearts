using Terraria;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Dev.CAT
{
    // Ethereal Flames is an example of a buff that causes constant loss of life.
    // See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
    public class CATsCurse : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Starbreaker's Curse");
            Description.SetDefault("You are cursed by Starbreaker's Curse");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<ElementalHeartsPlayer>().curseCATsCurse = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<ElementalHeartsGlobalNPC>().curseCATsCurse = true;
        }
    }
}
