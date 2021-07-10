using Terraria.ModLoader;

namespace ElementalHearts.Items
{
    public abstract class CalamityCrossModItem : ConsumableHeartItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }
    }
    public abstract class ConfectionCrossModItem : ConsumableHeartItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("TheConfectionRebirth") != null;
        }
    }
    public abstract class ConsolariaCrossModItem : ConsumableHeartItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("Consolaria") != null;
        }
    }
    public abstract class ThoriumCrossModItem : ConsumableHeartItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
    }
    public abstract class FargoSoulsCrossModItem : ConsumableHeartItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("FargowiltasSouls") != null;
        }
    }
    public abstract class ElementsAwokenCrossModItem : ConsumableHeartItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ElementsAwoken") != null;
        }
    }
    public abstract class LaugicalityCrossModItem : ConsumableHeartItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("Laugicality") != null;
        }
    }
    public abstract class AncientsAwakaenedCrossModItem : ConsumableHeartItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("AAMod") != null;
        }
    }
}
