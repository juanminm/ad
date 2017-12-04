package serpis.ad;

import java.math.BigDecimal;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Scanner;

public class Main {

	public enum Option {Salir, Nuevo, Modificar, Eliminar, Consultar, Listar};

	private static Scanner scan = new Scanner(System.in);

	public static void main(String[] args) throws SQLException {
		Connection connection = DriverManager.getConnection(
				"jdbc:mysql://localhost:3306/dbprueba?useSSL=false", "root",
				"sistemas");
		boolean isExit = false;

		while(!isExit) {
			Option option = showMenu(Option.class);

			Runnable runnable = null;
			if (option == Option.Salir) {
				isExit = true;
			} else if (option == Option.Nuevo) {
				runnable = () -> newProduct();
			} else if (option == Option.Modificar) {
				runnable = () -> modifyProduct();
			} else if (option == Option.Eliminar) {
				runnable = () -> deleteProduct();
			} else if (option == Option.Consultar) {
				runnable = () -> queryProduct();
			} else {
				runnable = () -> list(connection);
			}

			if (!isExit)
				runnable.run();
		}
		connection.close();

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

	private static void list(Connection connection) {
		System.out.println("Mostrando la tabla Articulo...");
		System.out.println();

		try (Statement stmt = connection.createStatement()) {
			ResultSet rs = stmt.executeQuery("SELECT * FROM `articulo`");

			String header = String.format(
					"%-8s | %-30s | %-10s | %s", "Nombre", "Artículo", "Precio",
					"Categoria");

			System.out.println(header);
			for (int i = 0; i < header.length(); i++)
				System.out.print("-");
			System.out.println();

			while (rs.next()) {
				long id = rs.getLong("id");
				String name = rs.getString("nombre");
				BigDecimal precio = rs.getBigDecimal("precio");
				long categoria = rs.getLong("categoria");

				System.out.printf("%-8d | %-30s | %10.2f | %s%n", id, name,
						precio, categoria);
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
