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
    public abstract class ConsolariaCrossModItem : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("Consolaria") != null;
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
    public abstract class ElementsAwokenCrossModItem : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ElementsAwoken") != null;
        }
    }
    public abstract class LaugicalityCrossModItem : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("Laugicality") != null;
        }
    }
    public abstract class RedemptionCrossModItem : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("Redemption") != null;
        }
    }
}
