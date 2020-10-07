using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ElementalHearts.Tiles
{
    public class CrystalGrassPink : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = false;
            Main.tileLavaDeath[Type] = true;

            drop = mod.ItemType("CrystalGrassPinkItem");
            dustType = DustID.Dirt;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Crystal Grass Pink");

            AddMapEntry(new Color(255, 144, 144));
            //minPick = 60; Needs higher than lead.
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
