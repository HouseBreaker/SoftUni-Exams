package p03_RubiksMatrix;

import java.util.Scanner;

public class RubiksMatrix {
	static int[][] matrix;
	static int rows, cols;

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		String[] inputTokens = in.nextLine().split(" ");

		rows = Integer.parseInt(inputTokens[0]);
		cols = Integer.parseInt(inputTokens[1]);

		int commandCount = Integer.parseInt(in.nextLine());

		matrix = new int[rows][cols];
		populateMatrix();

		for (int line = 0; line < commandCount; line++) {
			String command = in.nextLine();
			String[] tokens = command.split(" ");

			int rowOrColIndex = Integer.parseInt(tokens[0]);
			String direction = tokens[1];
			int count = Integer.parseInt(tokens[2]);

			switch (direction) {
				case "left":
					shiftLeft(rowOrColIndex, count);
					break;
				case "right":
					shiftRight(rowOrColIndex, count);
					break;
				case "up":
					shiftUp(rowOrColIndex, count);
					break;
				case "down":
					shiftDown(rowOrColIndex, count);
					break;
			}
		}

		int counter = 1;
		for (int row = 0; row < matrix.length; row++) {
			for (int col = 0; col < matrix[0].length; col++) {
				if (matrix[row][col] == counter) {
					System.out.println("No swap required");
				} else {
					int[] correctNumCoords = lookForNumberIndexes(counter);

					int rowToSwapWith = correctNumCoords[0];
					int colToSwapWith = correctNumCoords[1];

					swapNumsInMatrix(row, col, rowToSwapWith, colToSwapWith);
					System.out.printf("Swap (%d, %d) with (%d, %d)\n", row, col, rowToSwapWith, colToSwapWith);
				}

				counter++;
			}
		}
	}

	private static int[] lookForNumberIndexes(int num) {
		for (int row = 0; row < matrix.length; row++) {
			for (int col = 0; col < matrix[0].length; col++) {
				if (matrix[row][col] == num) {
					return new int[]{row, col};
				}
			}
		}
		return new int[]{Integer.MAX_VALUE, Integer.MAX_VALUE};
	}

	public static void swapNumsInMatrix(int row, int col, int destRow, int destCol) {
		int srcNum = matrix[row][col];
		int destNum = matrix[destRow][destCol];

		matrix[row][col] = destNum;
		matrix[destRow][destCol] = srcNum;
	}

	private static void shiftLeft(int rowToShift, int bigCount) {
		int count = bigCount % matrix[rowToShift].length;
		int[] matrixRow = matrix[rowToShift];

		matrixRow = shiftBack(matrixRow, count);
		matrix[rowToShift] = matrixRow.clone();
	}

	private static void shiftRight(int rowToShift, int bigCount) {
		int count = bigCount % matrix[rowToShift].length;
		int[] matrixRow = matrix[rowToShift];

		matrixRow = shiftForward(matrixRow, count);
		matrix[rowToShift] = matrixRow.clone();
	}

	private static void shiftDown(int colToShift, int bigCount) {
		int count = bigCount % matrix[colToShift].length;

		int[] matrixCol = new int[matrix.length];

		for (int i = 0; i < matrixCol.length; i++) {
			matrixCol[i] = matrix[i][colToShift];
		}

		matrixCol = shiftForward(matrixCol, count);

		for (int i = 0; i < matrixCol.length; i++) {
			matrix[i][colToShift] = matrixCol[i];
		}
	}

	private static void shiftUp(int colToShift, int bigCount) {
		int count = bigCount % matrix[colToShift].length;

		int[] matrixCol = new int[matrix.length];

		for (int i = 0; i < matrixCol.length; i++) {
			matrixCol[i] = matrix[i][colToShift];
		}

		matrixCol = shiftBack(matrixCol, count);

		for (int i = 0; i < matrixCol.length; i++) {
			matrix[i][colToShift] = matrixCol[i];
		}
	}

	private static int[] shiftForward(int[] arr, int count) {
		for (int i = 0; i < count; i++) {
			int[] tempArr = arr.clone();

			int lastElement = tempArr[arr.length - 1];

			for (int index = 0; index < tempArr.length - 1; index++) {
				tempArr[index + 1] = arr[index];
			}
			tempArr[0] = lastElement;
			arr = tempArr.clone();
		}
		return arr;
	}

	private static int[] shiftBack(int[] arr, int count) {
		for (int i = 0; i < count; i++) {
			int[] tempArr = arr.clone();

			int firstElement = tempArr[0];

			for (int index = tempArr.length - 2; index >= 0; index--) {
				tempArr[index] = arr[index + 1];
			}
			tempArr[tempArr.length - 1] = firstElement;
			arr = tempArr.clone();
		}
		return arr;
	}
	
	private static void populateMatrix() {
		int counter = 0;
		for (int row = 0; row < rows; row++) {
			for (int col = 0; col < cols; col++) {
				counter++;
				matrix[row][col] = counter;
			}
		}
	}
}
