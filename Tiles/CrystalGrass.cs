using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Tiles
{
    public class CrystalGrass : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = false;
            Main.tileLighted[Type] = false;
            Main.tileLavaDeath[Type] = true;

            drop = mod.ItemType("CrystalGrassItem");
            dustType = DustID.Dirt;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Crystal Grass");

            AddMapEntry(new Color(255, 44, 44));
            //minPick = 60; Needs higher than lead.
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
