using ElementalHearts.Items.Dev.CAT;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Dev.CAT
{
	public class BowLite : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Great for impersonating devs!'");
			DisplayName.SetDefault("CAT's Throw");

			// These are all related to gamepad controls and don't seem to affect anything else
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.width = 24;
			item.height = 24;
			item.useAnimation = 20;
			item.useTime = 20;
			item.shootSpeed = 16f;
			item.knockBack = 5.5f;
			item.damage = 80;
			item.rare = ItemRarityID.Cyan;

			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;

			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<CATsThrow_Projectile>();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
			if (Main.rand.NextBool(23)) {
            	target.AddBuff(BuffType<CATsCurse>(), 8 * 60);
			}
		}
	}
}
