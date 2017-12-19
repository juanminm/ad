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
				runnable = () -> listProducts(connection);
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

	private static void listProducts(Connection connection) {
		System.out.println("Mostrando la tabla Articulo...");
		System.out.println();

		try (Statement stmt = connection.createStatement()) {
			ResultSet rs = stmt.executeQuery("SELECT * FROM `articulo`");
			Articulo articulo = new Articulo();

			String header = String.format(
					"%-8s | %-30s | %-10s | %s", "Nombre", "Artículo", "Precio",
					"Categoria");

			System.out.println(header);
			for (int i = 0; i < header.length(); i++)
				System.out.print("-");
			System.out.println();

			while (rs.next()) {
				articulo.setId(rs.getLong("id"));
				articulo.setNombre(rs.getString("nombre"));
				articulo.setPrecio(rs.getBigDecimal("precio"));
				articulo.setCategoria(rs.getLong("categoria"));

				System.out.printf("%-8d | %-30s | %10.2f | %s%n",
						articulo.getId(), articulo.getNombre(),
						articulo.getPrecio(), articulo.getCategoria());
			}
		} catch (SQLException e) {
			e.printStackTrace();
		}

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
