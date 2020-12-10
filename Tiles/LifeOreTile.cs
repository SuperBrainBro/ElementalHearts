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
            Main.tileBlockLight[Type] = true;
            minPick = 45;
            Main.tileLighted[Type] = true;

            dustType = DustID.PinkCrystalShard;
            drop = mod.ItemType("LifeOre");

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Life Ore");

            AddMapEntry(new Color(255, 50, 50), name);
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

        public override bool KillSound(int i, int j)
        {
            Main.PlaySound(SoundID.Item, i * 16, j * 16, 27);
            return false;
        }

    }
}
