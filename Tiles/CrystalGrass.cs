using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ElementalHearts.Tiles
{
    public class CrystalGrass : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileLavaDeath[Type] = true;

            drop = ItemID.DirtBlock;
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
