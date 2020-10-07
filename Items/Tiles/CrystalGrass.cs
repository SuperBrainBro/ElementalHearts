using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Tiles
{
    public class CrystalGrassItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Grass");
        }
        public override void SetDefaults()
        {
            item.width = 8;
            item.height = 8;
            item.maxStack = 999;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 10;
            item.useAnimation = 10;
            item.createTile = mod.TileType("CrystalGrass");
            item.autoReuse = true;
            item.value = 100;
        }
    }
}
