package serpis.ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.Scanner;

public class PruebaMySql {

	public static void main(String[] args) throws SQLException {
		Connection connection = DriverManager.getConnection(
				"jdbc:mysql://localhost/dbprueba?useSSL=false", "root",
				"sistemas");
		boolean isExit = false;
		
		while(!isExit) {
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
			
			switch (option) {
				case 0:
					isExit = true; 
					break;
				case 1:
					//TODO Nuevo
					break;
				case 2:
					//TODO Modificar
					break;
				case 3:
					//TODO Eliminar
					break;
				case 4:
					//TODO Consultar
					break;
				case 5:
					//TODO Listar
					break;
				default:
					break;
			}
			
			scan.close();
		}
		
		connection.close();
	}

}
