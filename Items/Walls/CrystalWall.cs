using Terraria.ID;
using Terraria.ModLoader;

namespace ElementalHearts.Items.Walls
{
    public class CrystalWalls : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Dirt Walls");
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
            item.createWall = mod.WallType("CrystalWall");
            item.autoReuse = true;
            item.value = 100;
        }
    }
}
