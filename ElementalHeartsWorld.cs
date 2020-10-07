using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;
using ElementalHearts.Tiles;

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

        public override void PostWorldGen()
        {
            //Generation
            for (int i = 0; i < Main.maxTilesX / 600; i++)       //900 is how many biomes. the bigger is the number = less biomes
            {
                int X = WorldGen.genRand.Next(1, Main.maxTilesX - 100);
                int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer - 750, Main.maxTilesY - 100);
                int TileType = TileID.PinkSlimeBlock;     //this is the tile u want to use for the biome , if u want to use a vanilla tile then its int TileType = 56; 56 is obsidian block

                WorldGen.TileRunner(X, Y, 100, WorldGen.genRand.Next(50, 100), TileType, false, 0f, 0f, true, true);  //350 is how big is the biome     100, 200 this changes how random it looks.

                int Xo = X + Main.rand.Next(-240, 240);
                int Yo = Y + Main.rand.Next(-240, 240);
                if (Main.tile[Xo, Yo].type == TileID.RedBrick)   //this is the tile where the ore will spawn
                
                WorldGen.TileRunner(Xo, Yo, WorldGen.genRand.Next(5, 10), WorldGen.genRand.Next(5, 10), TileType<LifeOreTile>(), false, 0f, 0f, false, true);  //   5, 10 is how big is the ore veins.
            }
        }
    }
}