using ElementalHearts.NPCs.Bosses.MenacingHeart;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Tiles
{
    public class MenacingLookingStatue : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Menacing Statue");
            AddMapEntry(new Color(215, 15, 15), name);
            dustType = 11;
            disableSmartCursor = true;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 48, ItemType<MenacingLookingStatueItem>());
        }

        public override void HitWire(int i, int j)
        {
            // Find the coordinates of top left tile square through math
            int y = j - Main.tile[i, j].frameY / 18;
            int x = i - Main.tile[i, j].frameX / 18;

            Wiring.SkipWire(x, y);
            Wiring.SkipWire(x, y + 1);
            Wiring.SkipWire(x, y + 2);
            Wiring.SkipWire(x + 1, y);
            Wiring.SkipWire(x + 1, y + 1);
            Wiring.SkipWire(x + 1, y + 2);

            // We add 16 to x to spawn right between the 2 tiles. We also want to right on the ground in the y direction.
            int spawnX = x * 16 + 16;
            int spawnY = (y + 3) * 16;

            // If you want to make an NPC spawning statue, see below.
            //int npcIndex = -1;
            // 30 is the time before it can be used again. NPC.MechSpawn checks nearby for other spawns to prevent too many spawns. 3 in immediate vicinity, 6 nearby, 10 in world.
            if (Wiring.CheckMech(x, y, 30) && NPC.MechSpawn((float)spawnX, (float)spawnY, NPCType<MenacingHeart>()))
            {
                //npcIndex = 
                NPC.NewNPC(spawnX, spawnY - 120, NPCType<MenacingHeart>());
            }
            //if (npcIndex >= 0)
            //{
            // Main.npc[npcIndex].value = 0f;
            // Main.npc[npcIndex].npcSlots = 0f;
            // Prevents Loot if NPCID.Sets.NoEarlymodeLootWhenSpawnedFromStatue and !Main.HardMode or NPCID.Sets.StatueSpawnedDropRarity != -1 and NextFloat() >= NPCID.Sets.StatueSpawnedDropRarity or killed by traps.
            // Prevents CatchNPC
            // Main.npc[npcIndex].SpawnedFromStatue = true;
            //}
        }
    }

    public class MenacingLookingStatueItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Menacing Looking Statue");
            Tooltip.SetDefault("Summons a... creature?");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ArmorStatue);
            item.createTile = TileType<MenacingLookingStatue>();
            item.placeStyle = 0;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeCrystal, 5);
            recipe.AddIngredient(ItemID.StoneBlock, 100);
            recipe.AddIngredient(ItemID.VilePowder, 25);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeCrystal, 5);
            recipe.AddIngredient(ItemID.StoneBlock, 100);
            recipe.AddIngredient(ItemID.ViciousPowder, 25);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            base.AddRecipes();
        }
    }

    public class MenacingStatueModWorld : ModWorld
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ResetIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Reset"));
            if (ResetIndex != -1)
            {
                tasks.Insert(ResetIndex + 1, new PassLegacy("Example Mod Statue Setup", delegate (GenerationProgress progress)
                {
                    progress.Message = "Adding ExampleMod Statue";

                    // Not necessary, just a precaution.
                    if (WorldGen.statueList.Any(point => point.X == TileType<MenacingLookingStatue>()))
                    {
                        return;
                    }
                    // Make space in the statueList array, and then add a Point16 of (TileID, PlaceStyle)
                    Array.Resize(ref WorldGen.statueList, WorldGen.statueList.Length + 1);
                    for (int i = WorldGen.statueList.Length - 1; i < WorldGen.statueList.Length; i++)
                    {
                        WorldGen.statueList[i] = new Point16(TileType<MenacingLookingStatue>(), 0);
                        // Do this if you want the statue to spawn with wire and pressure plate
                        // WorldGen.StatuesWithTraps.Add(i);
                    }
                }));
            }
        }
    }
}
