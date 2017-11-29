package serpis.ad;

import java.math.BigDecimal;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Scanner;

public class PruebaMySql {

	public static void main(String[] args) throws SQLException {
		Connection connection = DriverManager.getConnection(
				"jdbc:mysql://localhost:3306/dbprueba?useSSL=false", "root",
				"sistemas");
		boolean isExit = false;

		while (!isExit) {
			Scanner scan = new Scanner(System.in);
			int option;

			System.out.println("0. Salir");
			System.out.println("1. Nuevo");
			System.out.println("2. Modificar");
			System.out.println("3. Eliminar");
			System.out.println("4. Consultar");
			System.out.println("5. Listar");
			System.out.println();
			System.out.print("Escoge una opción: ");

			option = scan.nextInt();
			scan.nextLine();
			System.out.println();

			switch (option) {
				case 0:
					isExit = true;
					break;
				case 1:
					// TODO Nuevo
					break;
				case 2:
					// TODO Modificar
					break;
				case 3:
					// TODO Eliminar
					break;
				case 4:
					// TODO Consultar
					break;
				case 5:
					System.out.println("Mostrando la tabla Articulo...");
					System.out.println();
					try (Statement stmt = connection.createStatement()) {
						ResultSet rs = stmt.executeQuery("SELECT * FROM "
								+ "`articulo`");

						String header = String.format(
								"%-8s | %-30s | %-10s | %s", "Nombre",
								"Artículo", "Precio", "Categoria");

						System.out.println(header);
						for (int i = 0; i < header.length(); i++)
							System.out.print("-");
						System.out.println();

						while (rs.next()) {
							long id = rs.getLong("id");
							String name = rs.getString("nombre");
							BigDecimal precio = rs.getBigDecimal("precio");
							long categoria = rs.getLong("categoria");

							System.out.printf("%-8d | %-30s | %10.2f | %s%n",
									id, name, precio, categoria);
						}
					}
					System.out.println();
					System.out.println("Pulse ENTER para continuar");
					scan.nextLine();
					break;
				default:
					break;
			}
			
			scan.close();
		}

		connection.close();
	}

}
