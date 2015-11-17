package p04_LogParser;

import sun.reflect.generics.tree.Tree;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class LogParser {
	public static void main(String[] args) {
		Scanner in = new Scanner(System.in);
		Map<String, TreeMap<String, ArrayList<String>>> database = new TreeMap<>();
		final String pat = "\\{\"Project\": \\[\"(?<project>.+)\"], \"Type\": \\[\"(?<type>Critical|Warning)\"\\], \"Message\": \\[\"(?<message>.+)\"\\]}";

		while (true) {
			String input = in.nextLine();
			if (input.equals("END"))
				break;

			Matcher mat = Pattern.compile(pat).matcher(input);
			mat.find();

			String name = mat.group("project");
			String type = mat.group("type");
			String message = mat.group("message");

			if (!database.containsKey(name)) {
				database.put(name, new TreeMap<>());
			}

			if (!database.get(name).containsKey(type)) {
				database.get(name).put(type, new ArrayList<>());
			}

			database.get(name).get(type).add(message);
		}

		Comparator<Map<String, TreeMap<String, ArrayList<String>>>> c =

		database.entrySet().stream()
				.sorted(c);

	}
}
