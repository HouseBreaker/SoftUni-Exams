package p02_WeirdScript;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class WeirdScript {
	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);

		int keyNumber = Integer.parseInt(in.nextLine());
		keyNumber = keyNumber - 1;

		int charCode = keyNumber % 26;

		char keyChar = (keyNumber / 26) % 2 == 0
				? (char) ('a' + charCode)
				: Character.toUpperCase((char) ('a' + charCode));

		String key = "" + keyChar + keyChar;

		StringBuilder text = new StringBuilder();
		while(true){
			String line = in.nextLine();
			if (line.equals("End")){
				break;
			}
			text.append(line);
		}

		String message = text.toString();
		Matcher matcher= Pattern.compile(key + "(.*?)" + key).matcher(message);

		while (matcher.find()) {
			if (matcher.group(1).length() > 0) {
				System.out.println(matcher.group(1));
			}
		}
	}
}
