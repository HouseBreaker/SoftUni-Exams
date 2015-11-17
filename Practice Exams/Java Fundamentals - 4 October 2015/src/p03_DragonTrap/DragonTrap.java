package p03_DragonTrap;

import java.util.Arrays;
import java.util.Scanner;

public class DragonTrap {
	static Scanner in = new Scanner(System.in);
	static int n = Integer.parseInt(in.nextLine());
	static char[][] matrix = new char[n][n];

	public static void main(String[] args) {
		inputMatrix();

		// todo: rotate matrix
		while (true) {
			String command = in.nextLine();
			if (command.equals("End"))
				break;

			processCommand(command);
		}

		printMatrix();
		// todo: print symbols changed
	}
	
	static void processCommand(String command) {
		int[] tokens = Arrays.stream(command.split("[^-\\d]+"))
				.mapToInt(Integer::parseInt)
				.toArray();

		int row = tokens[1];
		int col = tokens[2];
		int radius = tokens[3];
		int rotations = tokens[4] % n;
		
		// todo: finish rotation
	}
	
	static void inputMatrix() {
		for (int row = 0; row < n; row++) {
			String currentRow = in.nextLine();
			for (int col = 0; col < n; col++) {
				matrix[row][col] = currentRow.charAt(col);
			}
		}
	}

	static void printMatrix() {
		for (int row = 0; row < n; row++) {
			for (int col = 0; col < n; col++) {
				System.out.print(matrix[row][col]);
			}
			System.out.println();
		}
	}
}
