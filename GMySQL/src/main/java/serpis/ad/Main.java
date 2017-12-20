package serpis.ad;

import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.Scanner;

public class Main {

	public enum Option {EXIT, INSERT, UPDATE, DELETE, QUERY, LIST};

	private static Scanner scan = new Scanner(System.in);

	public static void main(String[] args) throws SQLException {
		App.setConnection(DriverManager.getConnection(
				"jdbc:mysql://localhost:3306/dbprueba?useSSL=false", "root",
				"sistemas"));
		boolean isExit = false;

		while(!isExit) {
			Option option = showMenu(Option.class);

			Runnable runnable = null;
			if (option == Option.EXIT) {
				isExit = true;
			} else if (option == Option.INSERT) {
				runnable = () -> newProduct();
			} else if (option == Option.UPDATE) {
				runnable = () -> modifyProduct();
			} else if (option == Option.DELETE) {
				runnable = () -> deleteProduct();
			} else if (option == Option.QUERY) {
				runnable = () -> queryProduct();
			} else {
				runnable = () -> {
					try {
						listProducts();
					} catch (SQLException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
				};
			}

			if (!isExit)
				runnable.run();
		}

		App.closeConnection();

	}

	private static void newProduct() {
		//TODO To implement
	}

	private static void modifyProduct() {
		//TODO To implement
	}

	private static void deleteProduct() {
		//TODO To implement
	}

	private static void queryProduct() {
		//TODO To implement
	}

	private static void listProducts() throws SQLException {
		System.out.println("Mostrando la tabla Articulo...");
		QueryTableHelper.showQueryTable("SELECT * FROM `articulo`");


		System.out.println();
		System.out.println("Pulse ENTER para continuar");
		scan.nextLine();
	}

	private static <T extends Enum<T>> T showMenu(Class<T> enumType) {
		T[] constants = enumType.getEnumConstants();
		for (int i = 0; i < constants.length; i++)
			System.out.printf("%s - %s%n", i, constants[i]);
		String options = String.format("^[0-%s]$", constants.length - 1);

		while (true) {
			System.out.print("Escoge una opción: ");
			String line = scan.nextLine();
			if (line.matches(options))
				return constants[Integer.parseInt(line)];
			System.out.println("Opción invalida.");
		}
	}
}
