using System.Collections.Generic;
using System.IO;
using ElementalHearts.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts
{
    public class ElementalHeartsWorld : ModWorld
    {
        public static bool downedMenacingHeart;
		public static int lifeCrystalTiles;

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

        public override void ResetNearbyTileEffects()
        {
            lifeCrystalTiles = 0;
            base.ResetNearbyTileEffects();
        }

		public override void TileCountsAvailable(int[] tileCounts)
		{
			lifeCrystalTiles = tileCounts[TileType<CrystalGrass>()] + tileCounts[TileType<CrystalGrassPink>()];
		}



		//World Gen

		public static int CrystalTiles = 0;
		public float grassType;
		private static List<Point> BiomeCenters;

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{
			BiomeCenters = new List<Point>();

			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex == -1)
			{
				// Shinies pass removed by some other mod.
				return;
			}
			tasks.Insert(ShiniesIndex + 1, new PassLegacy("ElementalHeartsBiomeGen", delegate (GenerationProgress progress)
			{
				progress.Message = "Polishing life crystals";
				// 4200 1200
				// 8400 2400
				// 3 in small
				// 6 large
				for (int i = 0; i < (int)Main.maxTilesX / 500; i++)
				{
					int Xvalue = WorldGen.genRand.Next(50, Main.maxTilesX - 700);
					int Yvalue = WorldGen.genRand.Next((int)WorldGen.rockLayer - 200, Main.maxTilesY - 700);
					int XvalueHigh = Xvalue + 800;
					int YvalueHigh = Yvalue + 800;
					int XvalueMid = Xvalue + 400;
					int YvalueMid = Yvalue + 400;

					grassType += Main.rand.NextFloat(-50, 50);
                    if (grassType >= 0)
					{
						WorldGen.TileRunner(XvalueMid, YvalueMid, (double)WorldGen.genRand.Next(60, 70), 1, TileType<CrystalGrass>(), false, 0f, 0f, true, true); //c = x, d = y
					}
					else if (grassType <= 0)
					{
						WorldGen.TileRunner(XvalueMid, YvalueMid, (double)WorldGen.genRand.Next(60, 70), 1, TileType<CrystalGrassPink>(), false, 0f, 0f, true, true); 
					}
					int x;
					int y;
					int maxTries = 100000;
					int tries = 0;
					int successes = 0;

					WorldGen.digTunnel(Xvalue + 400, Yvalue + 400, 0, 0, WorldGen.genRand.Next(15, 18), WorldGen.genRand.Next(14, 17), false);
					while (tries < maxTries && successes < 20)
					{
						x = Xvalue + WorldGen.genRand.Next(300, 300);
						y = Yvalue + WorldGen.genRand.Next(300, 300);
						
						if (WorldGen.PlaceChest(x, y, TileID.Heart, false, 2) != -1)
						{
							successes++;
						}
						
						tries++;
					}
					for (int Blocks = 0; Blocks < 3000; Blocks++)
					{
						int Xore = XvalueMid + Main.rand.Next(-150, 150);
						int Yore = YvalueMid + Main.rand.Next(-150, 150);
						if (Main.rand.NextBool())
						{
							if (Main.rand.NextBool())
							{
								if (Main.tile[Xore, Yore].type == TileType<CrystalGrass>() || Main.tile[Xore, Yore].type == TileType<CrystalGrassPink>()) // A = x, B = y.
								{
									WorldGen.TileRunner(Xore, Yore, WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(3, 18), TileID.Stone, false, 0f, 0f, false, true);
								}
							}
						}
						if (Main.rand.NextBool())
						{
							if (Main.rand.NextBool())
							{
								if (Main.tile[Xore, Yore].type == TileType<CrystalGrassPink>()) // A = x, B = y.
								{
									WorldGen.TileRunner(Xore, Yore, WorldGen.genRand.Next(6, 16), WorldGen.genRand.Next(6, 16), TileType<CrystalGrass>(), false, 0f, 0f, false, true);
								}
							}
							else
							{
								if (Main.tile[Xore, Yore].type == TileType<CrystalGrass>()) // A = x, B = y.
								{
									WorldGen.TileRunner(Xore, Yore, WorldGen.genRand.Next(6, 16), WorldGen.genRand.Next(6, 16), TileType<CrystalGrassPink>(), false, 0f, 0f, false, true);
								}
							}
						}
						else if (Main.rand.NextBool())
						{
							if (Main.rand.NextBool())
							{
								if (Main.tile[Xore, Yore].type == TileType<CrystalGrass>() || Main.tile[Xore, Yore].type == TileType<CrystalGrassPink>()) // A = x, B = y.
								{
									WorldGen.TileRunner(Xore, Yore, WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(3, 8), TileID.Mud, false, 0f, 0f, false, true);
								}
							}
						}
						else if (Main.rand.NextBool())
						{
							if (Main.rand.NextBool())
							{
								if (Main.tile[Xore, Yore].type == TileType<CrystalGrass>() || Main.tile[Xore, Yore].type == TileType<CrystalGrassPink>()) // A = x, B = y.
								{
									WorldGen.TileRunner(Xore, Yore, WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(3, 8), TileID.Sand, false, 0f, 0f, false, true);
								}
							}
						}
					}
					for (int Crystal = 0; Crystal < 20000; Crystal++)
					{
						int E = XvalueMid + Main.rand.Next(-150, 300);
						int F = YvalueMid + Main.rand.Next(-150, 300);
						Tile tilePre = Framing.GetTileSafely(E, F);
						if (tilePre.type == TileType<CrystalGrass>() || tilePre.type == TileType<CrystalGrassPink>() || tilePre.type == TileType<LifeOreTile>())
						{
							int Ep = E + (int)Main.rand.NextFloat(-1, 1);
							int Fp = F + (int)Main.rand.NextFloat(-1, 1);
							Tile tile = Framing.GetTileSafely(Ep, Fp);
							if (!tile.active())
							{
								WorldGen.PlaceTile(Ep, Fp, TileType<AncientCrystalTile>());
							}
						}
					}
					for (int Ore = 0; Ore < 1000; Ore++)
					{
						int Xore = XvalueMid + Main.rand.Next(-150, 300);
						int Yore = YvalueMid + Main.rand.Next(-150, 300);
						if (Main.tile[Xore, Yore].type == TileType<CrystalGrass>() || Main.tile[Xore, Yore].type == TileType<CrystalGrassPink>()) // A = x, B = y.
						{
							WorldGen.TileRunner(Xore, Yore, WorldGen.genRand.Next(3, 12), WorldGen.genRand.Next(3, 12), TileType<LifeOreTile>(), false, 0f, 0f, false, true);
						}
					}

					BiomeCenters.Add(new Point(XvalueMid, YvalueMid));
				}
			}));
		}
    }
}