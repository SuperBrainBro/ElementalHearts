using IL.Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Tiles
{
    public class LifeOreTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileStone[Type] = true;



            drop = mod.ItemType("LifeOre");

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Life Ore");

            AddMapEntry(new Color(255, 44, 44), name);
            minPick = 60;
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = .9f;
            g = .2f;
            b = .2f;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
