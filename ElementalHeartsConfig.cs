using System;
using System.Collections.Generic;
using System.ComponentModel;
using ElementalHearts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace ElementalHearts
{
    [Label("Settings")]
    public class ElementalHeartsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("Elemental Hearts Setting")]
        [DefaultValue(1)]      
        [ReloadRequired]
        [Label("Max Heart Consumption")]
        public int MaxElementalHeartConfig;
    }
}
