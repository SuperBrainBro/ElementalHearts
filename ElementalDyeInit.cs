using ElementalHearts.Items.Dyes;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace ElementalHearts
{
    public class ElementalHeartsDyeInit
    {
        public static void Load()
        {
            LoadDyes();
        }

        private static float DyeAtZero = 1 / 256;
        /// <summary>
        /// Loads dyes
        /// </summary>
        public static void LoadDyes()
        {
            Ref<Effect> pixelShaderRef = Main.PixelShaderRef;
            GameShaders.Armor.BindShader(ModContent.ItemType<MenacingDye>(), new ArmorShaderData(
                pixelShaderRef,
                "ArmorColored")).UseImage("Images/Misc/noise").UseColor(DyeAtZero * 200, DyeAtZero * 66, DyeAtZero * 107);
        }
    }
}