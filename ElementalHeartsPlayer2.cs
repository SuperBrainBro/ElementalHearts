using System.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ElementalHearts
{
    public partial class ElementalHeartsPlayer2 : ElementalHeartsPlayer
    {
        public int CursedFlameLife;
        public int IchorLife;
        public int VoiditeLife;

        public int SoulofFraughtLife;
        public int SoulofThoughtLife;
        public int SoulofWroughtLife;

        public int AncientDirtLife;
        public int AncientStoneLife;
        public int HardenedRadioactiveSandLife;
        public int RadioactiveIceLife;
        public int RadioactiveSandLife;
        public int RadioactiveSandstoneLife;
        public int MegaLife;
        public int BestLife;

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
        public int CharredLife2;
        public int LifeofDespair;
        public int LifeoftheInfection;
        public int CrystallineLife;
        public int Pyralife;
        public int Lifethema;
        public int MoltenLife;
        public int AnDioLife;
        public int EtheriaLife;

        //Multiplayer Thing
        //public bool nonStopParty;

        public override void ResetEffects()
        {
            player.statLifeMax2 += CursedFlameLife * 1;
            player.statLifeMax2 += IchorLife * 1;
            player.statLifeMax2 += VoiditeLife * 1;

            player.statLifeMax2 += SoulofFraughtLife * 1;
            player.statLifeMax2 += SoulofThoughtLife * 1;
            player.statLifeMax2 += SoulofWroughtLife * 1;

            player.statLifeMax2 += AncientDirtLife * 1;

            player.statLifeMax2 += MegaLife * 2;
            player.statLifeMax2 += BestLife * 1;

            //Boss Hearts
            player.statLifeMax2 += EasterLife * 1;
            player.statLifeMax2 += LifeoPlenty * 1;
            player.statLifeMax2 += CursedLife * 1;
            player.statLifeMax2 += VenomLife * 1;
            player.statLifeMax2 += InfernoLife * 1;
            player.statLifeMax2 += ScourgeLife * 1;
            player.statLifeMax2 += LifeofHope * 1;
            player.statLifeMax2 += LifeoftheFrost * 1;
            player.statLifeMax2 += SacredLife * 1;
            player.statLifeMax2 += AqueousLife * 1;
            player.statLifeMax2 += DrakonianLife * 1;
            player.statLifeMax2 += FieryLife * 1;
            player.statLifeMax2 += CharredLife2 * 1;
            player.statLifeMax2 += LifeofDespair * 1;
            player.statLifeMax2 += LifeoftheInfection * 1;
            player.statLifeMax2 += CrystallineLife * 1;
            player.statLifeMax2 += Pyralife * 1;
            player.statLifeMax2 += Lifethema * 1;
            player.statLifeMax2 += MoltenLife * 1;
            player.statLifeMax2 += AnDioLife * 1;
            player.statLifeMax2 += EtheriaLife * 1;
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

            packet.Write(AncientDirtLife);
            packet.Write(MegaLife);
            packet.Write(BestLife);

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
            packet.Write(CharredLife2);
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

                {"AncientDirtLife", AncientDirtLife},
                {"MegaLife", MegaLife},
                {"BestLife", BestLife },

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
                {"CharredLife2", CharredLife2 },
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

            AncientDirtLife = tag.GetInt("AncientDirtLife");
            MegaLife = tag.GetInt("MegaLife");
            BestLife = tag.GetInt("BestLife");

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
            CharredLife2 = tag.GetInt("CharredLife2");
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
