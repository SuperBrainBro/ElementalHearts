using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ElementalHearts
{
    [Label("Settings")]
    public class ElementalHeartsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("Elemental Hearts Setting")]
        [DefaultValue(true)]
        [ReloadRequired]
        [Label("Vanilla Changes")]
        public bool VanillaChangesConfig;
        [DefaultValue(1)]
        [ReloadRequired]
        [Label("Max Heart Consumption (Recomended to keep at 1)")]
        public int MaxElementalHeartConfig;
    }
}
