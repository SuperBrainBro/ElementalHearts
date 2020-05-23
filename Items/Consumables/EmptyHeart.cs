using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Consumables
{
	internal class EmptyHeart : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Permanently Resets All Pre-Hardmode Elemental Heart Stats");
			DisplayName.SetDefault("Heart Emptier");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.LifeFruit);
			item.rare = 0;
			item.value = 0;
		}

		//public override bool CanUseItem(Player player)
		//{
			//return player.statLifeMax >= 100 && player.GetModPlayer<ElementalHeartsPlayer>().StoneLife < 1;
		//}

		public override bool UseItem(Player player) {

			Main.NewText("Cleared Elemental Heart Stats!", Color.Orange);

			//Pre-Hardmode
			player.GetModPlayer<ElementalHeartsPlayer>().DirtLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().StoneLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().WoodLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().GraniteLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().MarbleLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().IceLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().GlassLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().SlimeLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().FossilLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().MushroomLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().HayLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().CactusLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().PumpkinLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().HoneyLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().AmethystLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().TopazLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().SapphireLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().EmeraldLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().RubyLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().DiamondLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().CopperLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().TinLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().IronLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().LeadLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().SilverLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().TungstenLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().GoldLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().PlatinumLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().MeteoriteLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().DemoniteLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().CrimtaneLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().ObsidianLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().HellstoneLife = 0;
			//Hardmode
			player.GetModPlayer<ElementalHeartsPlayer>().PearlstoneLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().RainbowLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().CobaltLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().PalladiumLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().MythrilLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().OrichalcumLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().AdamantiteLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().TitaniumLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().ChlorophyteLife = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().LuminiteLife = 0;
			//Dev Hearts
			player.GetModPlayer<ElementalHeartsPlayer>().HeartOfCAT = 0;
			player.GetModPlayer<ElementalHeartsPlayer>().CrystalLite = 0;

			player.statLifeMax2 = 0;


			return true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 100);;
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
