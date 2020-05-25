using ElementalHearts.Items.Dev.CAT;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ElementalHearts.Items.Dev.CAT
{
	public class AstralStars : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Astral Stars");
			Tooltip.SetDefault("Summons Stars from sky!"
							+ "\n'Great for impersonating devs!'");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.Starfury);
			item.shootSpeed *= 0.75f;
			item.summon = true;
			item.damage = 45;
			item.rare = 9;
			item.autoReuse = true;
			item.melee = false;
			item.ranged = false;
			item.magic = false;
			item.thrown = false;
			item.noMelee = true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			if (Main.rand.NextBool(2)) {
				type = ProjectileType<DreamerStarSmall>();
				if (player.statManaMax >= 1) {
					player.statManaMax -= 2;
				} else {
					player.statLifeMax -= 2;
				}
			} else if (Main.rand.NextBool(4)) {
				type = ProjectileType<DreamerStarMedium>();
				if (player.statManaMax >= 3) {
					player.statManaMax -= 4;
				} else {
					player.statLifeMax -= 4;
				}
			} else if (Main.rand.NextBool(6)) {
				type = ProjectileType<DreamerStarLarge>();
				if (player.statManaMax >= 7) {
					player.statManaMax -= 8;
				} else {
					player.statLifeMax -= 8;
				}
			} else if (Main.rand.NextBool(8)) {
				type = ProjectileType<DreamerStarMega2>();
				if (player.statManaMax >= 15) {
					player.statManaMax -= 16;
				} else {
					player.statLifeMax -= 16;
				}
			} else if (Main.rand.NextBool(10)) {
				type = ProjectileType<DreamerStarUltra>();
				if (player.statManaMax >= 31) {
					player.statManaMax -= 32;
				} else {
					player.statLifeMax -= 32;
				}
			}
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
	}
}