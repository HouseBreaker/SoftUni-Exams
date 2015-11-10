package p01_DragonSharp;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class DragonSharp {
	static Matcher commandParser;
	static boolean expressionEvaluates = true;

	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		int numberOfLines = Integer.parseInt(in.nextLine());

		String[] commands = new String[numberOfLines];

		for (int i = 0; i < numberOfLines; i++) {
			commands[i] = in.nextLine();
		}

		String caseOne = "if \\((?<first>\\d+)(?<condition>==|<|>)(?<second>\\d+)\\) loop (?<loopCount>\\d+) out \"(?<outStr>.*)\";";
		String caseTwo = "if \\((?<first>\\d+)(?<condition>==|<|>)(?<second>\\d+)\\) out \"(?<outStr>.*)\";";
		String caseThree = "else loop (?<loopCount>\\d+) out \"(?<outStr>.*)\";";
		String caseFour = "else out \"(?<outStr>.*)\";";
		
		for (int lineNumber = 0; lineNumber < commands.length; lineNumber++) {
			String command = commands[lineNumber];

			if (!command.matches(caseOne) && !command.matches(caseTwo)&& !command.matches(caseThree)&& !command.matches(caseFour)) {
				System.out.printf("Compile time error @ line %d", lineNumber + 1);
				System.out.println();
				return;
			}
		}
		for (int lineNumber = 0; lineNumber < commands.length; lineNumber++) {
			String command = commands[lineNumber];

			if (command.matches(caseOne)) {
				setMatcher(caseOne, command);

				int first = Integer.parseInt(commandParser.group("first"));
				int second = Integer.parseInt(commandParser.group("second"));

				String condition = commandParser.group("condition");

				if (expressionTrue(first, condition, second)) {

					int loopCount = Integer.parseInt(commandParser.group("loopCount"));
					String stringToOutput = commandParser.group("outStr");

					for (int i = 0; i < loopCount; i++) {
						System.out.println(stringToOutput);
					}
				}
			} else if (command.matches(caseTwo)) {
				setMatcher(caseTwo, command);
				int first = Integer.parseInt(commandParser.group("first"));
				int second = Integer.parseInt(commandParser.group("second"));

				String condition = commandParser.group("condition");

				if (expressionTrue(first, condition, second)) {
					String stringToOutput = commandParser.group("outStr");
					System.out.println(stringToOutput);
				}
			} else if (command.matches(caseThree)) {
				setMatcher(caseThree, command);

				if (lineNumber - 1 >= 0) {
					if (!expressionEvaluates) {
						int loopCount = Integer.parseInt(commandParser.group("loopCount"));
						for (int i = 0; i < loopCount; i++) {
							System.out.println(commandParser.group("outStr"));
						}
					}

				}
			} else if (command.matches(caseFour)) {
				setMatcher(caseFour, command);

				if (lineNumber - 1 >= 0) {
					if (!expressionEvaluates) {
						String stringToOutput = commandParser.group("outStr");
						System.out.println(stringToOutput);
					}
				}
			}
		}
	}

	static void setMatcher(String caseOne, String command) {
		commandParser = Pattern.compile(caseOne).matcher(command);
		commandParser.find();
	}

	static boolean expressionTrue(int first, String condition, int second) {
		switch (condition) {
			case ">":
				expressionEvaluates = first > second;
				return first > second;
			case "<":
				expressionEvaluates = first < second;
				return first < second;
			case "==":
				expressionEvaluates = first == second;
				return first == second;
		}
		return false;
	}
}
