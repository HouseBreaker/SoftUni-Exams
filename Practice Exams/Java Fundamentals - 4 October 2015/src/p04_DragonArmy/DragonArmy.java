package p04_DragonArmy;

import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.TreeSet;

public class DragonArmy {
	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		LinkedHashMap<String, TreeSet<Dragon>> dragons = new LinkedHashMap<>();

		int numberOfLines = Integer.parseInt(in.nextLine());

		String[] dragonsInput = new String[numberOfLines];

		for (int i = 0; i < numberOfLines; i++) {
			dragonsInput[i] = in.nextLine();
		}

		for (String dragonInput : dragonsInput) {
			String dragonStats[] = dragonInput.split(" ");

			String type = dragonStats[0];
			String name = dragonStats[1];
			String damage = dragonStats[2];
			String health = dragonStats[3];
			String armor = dragonStats[4];

			Dragon tempDragon = new Dragon(name, health, damage, armor);

			if (!dragons.containsKey(type)) {
				dragons.put(type, new TreeSet<>());
			}

			dragons.get(type).remove(tempDragon);
			dragons.get(type).add(tempDragon);
		}

		for (String type : dragons.keySet()) {
			double averageHealth = 0, averageDamage = 0, averageArmor = 0;

			for (Dragon dragon : dragons.get(type)) {
				averageDamage += dragon.damage;
				averageHealth += dragon.health;
				averageArmor += dragon.armor;
			}

			int count = dragons.get(type).size();

			averageDamage /= count;
			averageHealth /= count;
			averageArmor /= count;

			System.out.printf("%s::(%.2f/%.2f/%.2f)\n", type, averageDamage, averageHealth, averageArmor);

			for (Dragon dragon : dragons.get(type)) {
				System.out.printf("-%s -> damage: %d, health: %d, armor: %d\n", dragon.name, dragon.damage, dragon.health, dragon.armor);
			}
		}
	}
}

class Dragon implements Comparable {
	String name;
	int health = 250, damage = 45, armor = 10;

	public Dragon(String name, String health, String damage, String armor) {
		this.name = name;
		if (!health.equals("null"))
			this.health = Integer.parseInt(health);
		if (!damage.equals("null"))
			this.damage = Integer.parseInt(damage);
		if (!armor.equals("null"))
			this.armor = Integer.parseInt(armor);
	}
	
	@Override
	public boolean equals(Object obj) {
		final Dragon other = (Dragon) obj;
		return this.name.equals(other.name);
	}

	@Override
	public int compareTo(Object obj) {
		final Dragon other = (Dragon) obj;
		return this.name.compareTo(other.name);
	}
}