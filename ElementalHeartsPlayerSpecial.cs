using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ElementalHearts
{
    public class ElementalHeartsPlayerSpecial : ModPlayer
    {
        public int LifeofSlaughter;
        public int bossesDownedAmount = 0;
        public bool heartCatched = false;

        public bool nonStopParty;

        public override void ResetEffects()
        {
            player.statLifeMax2 += LifeofSlaughter * 10;
        }

        public override void clientClone(ModPlayer clientClone)
        {
            ElementalHeartsPlayer clone = clientClone as ElementalHeartsPlayer;
            clone.nonStopParty = nonStopParty;
        }

        public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
        {
            ModPacket packet = mod.GetPacket();
            packet.Write((byte)player.whoAmI);

            packet.Write(LifeofSlaughter);
            packet.Write(bossesDownedAmount);

            packet.Write(nonStopParty);
            packet.Send(toWho, fromWho);
        }
        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            ElementalHeartsPlayer clone = clientPlayer as ElementalHeartsPlayer;
            if (clone.nonStopParty != nonStopParty)
            {
                var packet = mod.GetPacket();
                packet.Write((byte)player.whoAmI);
                packet.Write(nonStopParty);
                packet.Send();
            }
        }

        public override TagCompound Save()
        {
            return new TagCompound {

                {"LifeofSlaughter", LifeofSlaughter },

                { "bossesDownedAmount", bossesDownedAmount },
                { "nonStopParty", nonStopParty },
            };
        }

        public override void Load(TagCompound tag)
        {
            LifeofSlaughter = tag.GetInt("LifeofSlaughter");

            bossesDownedAmount = tag.GetInt("bossesDownedAmount");
            nonStopParty = tag.GetBool("nonStopParty");
        }
    }
}
