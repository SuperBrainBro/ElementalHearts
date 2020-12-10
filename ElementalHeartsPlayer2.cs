using System.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ElementalHearts
{
    public class ElementalHeartsPlayer2 : ModPlayer
    {
        public int CursedFlameLife;
        public int IchorLife;
        public int VoiditeLife;

        public int SoulofFraughtLife;
        public int SoulofThoughtLife;
        public int SoulofWroughtLife;

        //Boss Hearts
        public int EasterLife;
        public int LifeoPlenty;
        public int CursedLife;
        public int VenomLife;
        public int InfernoLife;
        public int ScourgeLife;
        public int LifeofHope;
        public int LifeoftheFrost;
        public int SacredLife;
        public int AqueousLife;
        public int DrakonianLife;
        public int FieryLife;
        public int CharredLife;
        public int LifeofDespair;
        public int LifeoftheInfection;
        public int CrystallineLife;
        public int Pyralife;
        public int Lifethema;
        public int MoltenLife;
        public int AnDioLife;
        public int EtheriaLife;

        //Multiplayer Thing
        public bool nonStopParty;

        public override void ResetEffects()
        {
            player.statLifeMax2 += CursedFlameLife * 5;
            player.statLifeMax2 += IchorLife * 5;
            player.statLifeMax2 += VoiditeLife * 1;

            player.statLifeMax2 += SoulofFraughtLife * 5;
            player.statLifeMax2 += SoulofThoughtLife * 5;
            player.statLifeMax2 += SoulofWroughtLife * 5;

            //Boss Hearts
            player.statLifeMax2 += EasterLife * 5;
            player.statLifeMax2 += LifeoPlenty * 5;
            player.statLifeMax2 += CursedLife * 10;
            player.statLifeMax2 += VenomLife * 5;
            player.statLifeMax2 += InfernoLife * 5;
            player.statLifeMax2 += ScourgeLife * 10;
            player.statLifeMax2 += LifeofHope * 10;
            player.statLifeMax2 += LifeoftheFrost * 10;
            player.statLifeMax2 += SacredLife * 10;
            player.statLifeMax2 += AqueousLife * 10;
            player.statLifeMax2 += DrakonianLife * 15;
            player.statLifeMax2 += FieryLife * 15;
            player.statLifeMax2 += CharredLife * 15;
            player.statLifeMax2 += LifeofDespair * 15;
            player.statLifeMax2 += LifeoftheInfection * 15;
            player.statLifeMax2 += CrystallineLife * 15;
            player.statLifeMax2 += Pyralife * 5;
            player.statLifeMax2 += Lifethema * 5;
            player.statLifeMax2 += MoltenLife * 5;
            player.statLifeMax2 += AnDioLife * 5;
            player.statLifeMax2 += EtheriaLife * 10;
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

            packet.Write(CursedFlameLife);
            packet.Write(IchorLife);
            packet.Write(VoiditeLife);

            packet.Write(SoulofFraughtLife);
            packet.Write(SoulofThoughtLife);
            packet.Write(SoulofWroughtLife);

            //Boss Hearts
            packet.Write(EasterLife);
            packet.Write(LifeoPlenty);
            packet.Write(CursedLife);
            packet.Write(VenomLife);
            packet.Write(InfernoLife);
            packet.Write(ScourgeLife);
            packet.Write(LifeofHope);
            packet.Write(LifeoftheFrost);
            packet.Write(SacredLife);
            packet.Write(AqueousLife);
            packet.Write(DrakonianLife);
            packet.Write(FieryLife);
            packet.Write(CharredLife);
            packet.Write(LifeofDespair);
            packet.Write(LifeoftheInfection);
            packet.Write(CrystallineLife);
            packet.Write(Pyralife);
            packet.Write(Lifethema);
            packet.Write(MoltenLife);
            packet.Write(AnDioLife);
            packet.Write(EtheriaLife);

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

                {"CursedFlameLife", CursedFlameLife },
                {"IchorLife", IchorLife },
                {"VoiditeLife", VoiditeLife },

                {"SoulofFraughtLife", SoulofFraughtLife },
                {"SoulofThoughtLife", SoulofThoughtLife },
                {"SoulofWroughtLife", SoulofWroughtLife },

                //Boss Hearts
                {"EasterLife", EasterLife},
                {"LifeoPlenty", LifeoPlenty},
                {"CursedLife", CursedLife},
                {"VenomLife", VenomLife },
                {"InfernoLife", InfernoLife },
                {"ScourgeLife", ScourgeLife },
                {"LifeofHope", LifeofHope },
                {"LifeoftheFrost", LifeoftheFrost },
                {"SacredLife", SacredLife },
                {"AqueousLife", AqueousLife },
                {"DrakonianLife", DrakonianLife },
                {"FieryLife", FieryLife },
                {"CharredLife", CharredLife },
                {"LifeofDespair", LifeofDespair },
                {"LifeoftheInfection", LifeoftheInfection },
                {"CrystallineLife", CrystallineLife },
                {"Pyralife", Pyralife },
                {"Lifethema", Lifethema },
                {"MoltenLife", MoltenLife },
                {"AnDioLife", AnDioLife },
                {"EtheriaLife", EtheriaLife },

                //Other
                { "nonStopParty", nonStopParty},
            };
        }

        public override void Load(TagCompound tag)
        {
            CursedFlameLife = tag.GetInt("CursedFlameLife");
            IchorLife = tag.GetInt("IchorLife");
            VoiditeLife = tag.GetInt("VoiditeLife");

            SoulofFraughtLife = tag.GetInt("SoulofFraughtLife");
            SoulofThoughtLife = tag.GetInt("SoulofThoughtLife");
            SoulofWroughtLife = tag.GetInt("SoulofWroughtLife");

            //Boss Hearts
            EasterLife = tag.GetInt("EasterLife");
            LifeoPlenty = tag.GetInt("LifeoPlenty");
            CursedLife = tag.GetInt("CursedLife");
            VenomLife = tag.GetInt("VenomLife");
            InfernoLife = tag.GetInt("InfernoLife");
            ScourgeLife = tag.GetInt("ScourgeLife");
            LifeofHope = tag.GetInt("LifeofHope");
            LifeoftheFrost = tag.GetInt("LifeoftheFrost");
            SacredLife = tag.GetInt("SacredLife");
            AqueousLife = tag.GetInt("AqueousLife");
            DrakonianLife = tag.GetInt("DrakonianLife");
            FieryLife = tag.GetInt("FieryLife");
            CharredLife = tag.GetInt("CharredLife");
            LifeofDespair = tag.GetInt("LifeofDespair");
            LifeoftheInfection = tag.GetInt("LifeoftheInfection");
            CrystallineLife = tag.GetInt("CrystallineLife");
            Pyralife = tag.GetInt("Pyralife");
            Lifethema = tag.GetInt("Lifethema");
            MoltenLife = tag.GetInt("MoltenLife");
            AnDioLife = tag.GetInt("AnDioLife");
            EtheriaLife = tag.GetInt("EtheriaLife");

            nonStopParty = tag.GetBool("nonStopParty");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            reader.ReadInt32();
        }
    }
}
