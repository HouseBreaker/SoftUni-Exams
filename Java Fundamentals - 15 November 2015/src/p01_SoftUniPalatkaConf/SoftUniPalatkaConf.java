package p01_SoftUniPalatkaConf;

import java.util.Scanner;

public class SoftUniPalatkaConf {
	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		int attendees = Integer.parseInt(in.nextLine());
		int inputLines = Integer.parseInt(in.nextLine());

		int totalSpots = 0, totalFood = 0;

		for (int line = 0; line < inputLines; line++) {
			String[] tokens;
			tokens = in.nextLine().split(" ");

			String tentsFoodRooms = tokens[0];
			int quantity = Integer.parseInt(tokens[1]);
			String type = tokens[2];

			switch (tentsFoodRooms) {
				case "tents":
					switch (type) {
						case "normal":
							totalSpots += 2 * quantity;
							break;
						case "firstClass":
							totalSpots += 3 * quantity;
							break;
					}
					break;

				case "rooms":
					switch (type) {
						case "single":
							totalSpots += quantity;
							break;
						case "double":
							totalSpots += 2 * quantity;
							break;
						case "triple":
							totalSpots += 3 * quantity;
							break;
					}
					break;

				case "food":
					switch (type) {
						case "musaka":
							totalFood += 2 * quantity;
							break;
						case "zakuska":
							break;
					}
					break;
			}
		}

		totalSpots -= attendees;
		totalFood -= attendees;

		if (totalSpots >= 0) {
			System.out.println("Everyone is happy and sleeping well. Beds left: " + totalSpots);
		} else {
			System.out.println("Some people are freezing cold. Beds needed: " + Math.abs(totalSpots));
		}

		if (totalFood >= 0) {
			System.out.println("Nobody left hungry. Meals left: " + totalFood);
		}
		else{
			System.out.println("People are starving. Meals needed: " + Math.abs(totalFood));
		}
	}
}
