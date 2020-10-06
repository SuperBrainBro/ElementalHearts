using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ElementalHearts
{
    public class ElementalHeartsWorld : ModWorld
    {
        public static bool downedMenacingHeart;

        public override void Initialize()
        {
            downedMenacingHeart = false;
        }

        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedMenacingHeart)
            {
                downed.Add("menacingHeart");
            }

            return new TagCompound
            {
                ["downed"] = downed
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedMenacingHeart = downed.Contains("menacingHeart");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedMenacingHeart = flags[0];
            }
            else
            {
                mod.Logger.WarnFormat("ElementalHearts: Unknown loadVersion: {0}", loadVersion);
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = downedMenacingHeart;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedMenacingHeart = flags[0];

        }
    }
}