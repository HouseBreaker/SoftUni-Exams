package p01_TinySporeBat;

import java.util.Scanner;

public class TinySporeBat {
	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		int health = 5800;
		int sporeBatCost = 30;
		int money = 0;
		while (true) {
			String command = in.nextLine();

			if (command.equals("Sporeggar")) {
				System.out.println("Health left: " + health);
				money -= sporeBatCost;
				if (money >= 0) {
					System.out.println("Bought the sporebat. Glowcaps left: " + (money));
				} else {
					System.out.printf("Safe in Sporeggar, but another %d Glowcaps needed.\n", Math.abs(money));
				}
				return;
			}

			for (int i = 0; i < command.length() - 1; i++) {
				char enemy = command.charAt(i);

				if (enemy != 'L') {
					health -= enemy;
				} else {
					health += 200;
				}


				if (health <= 0) {
					System.out.println("Died. Glowcaps: " + money);
					return;
				}
			}

			int capsCount = command.charAt(command.length() - 1) - '0';
			money += capsCount;
		}
	}
}
