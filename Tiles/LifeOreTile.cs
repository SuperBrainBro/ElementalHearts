using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace ElementalHearts.Tiles
{
    public class LifeOreTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileLavaDeath[Type] = true;

            drop = mod.ItemType("LifeOre");
            dustType = DustID.Confetti;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Life Ore");

            AddMapEntry(new Color(255, 44, 44), name);
            //minPick = 60; Needs higher than lead.
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 255;
            g = 50;
            b = 50;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
