using Terraria.ModLoader;

namespace ElementalHearts.Items
{
    public abstract class CalamityCrossModItem : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }
    }
    public abstract class ThoriumCrossModItem : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
    }
    public abstract class FargoSoulsCrossModItem : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("FargowiltasSouls") != null;
        }
    }
}
