using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace ElementalHearts
{
    [Label("Settings")]
    public class ElementalHeartsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        /*[Header("Elemental Hearts Setting")]

        [Header("Vanilla Settings")]
        [DefaultValue(false)]
        [ReloadRequired]
        [Label("Retexture of Curse's")]
        public bool VanillaDebuffCurseRetexture;*/
    }
}
