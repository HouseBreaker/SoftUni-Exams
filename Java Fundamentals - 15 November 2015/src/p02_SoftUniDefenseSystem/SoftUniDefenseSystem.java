package p02_SoftUniDefenseSystem;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class SoftUniDefenseSystem {
	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		final Pattern pattern =
				Pattern.compile("(?<name>[A-Z][a-z]+).+(?<drink>[A-Z][a-z]*[A-Z]).+[^\\d](?<quantity>\\d+)L");
		double totalLiters = 0;

		while (true) {
			String input = in.nextLine();

			if (input.equals("OK KoftiShans"))
				break;

			Matcher drinkFinder = pattern.matcher(input);

			while (drinkFinder.find()) {
				String guestName = drinkFinder.group("name");
				String drink = drinkFinder.group("drink").toLowerCase();
				int liters = Integer.parseInt(drinkFinder.group("quantity"));

				System.out.printf("%s brought %d liters of %s!\n", guestName, liters, drink);
				totalLiters += liters * 0.001;
			}
		}
		System.out.printf("%.3f softuni liters", totalLiters);
	}
}
