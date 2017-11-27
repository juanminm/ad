package serpis.ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class PruebaMySql {

	public static void main(String[] args) throws SQLException {
		Connection connection = DriverManager.getConnection(
				"jdbc:mysql://localhost/dbprueba?useSSL=false", "root", "sistemas");
		
		try (
				Statement stmt = connection.createStatement();
				ResultSet rs = stmt.executeQuery("SELECT * FROM `categoria`"
						+ "ORDER BY `id`")
			) {
			while (rs.next()) {
				int c = rs.getMetaData().getColumnCount();
				
				for (int i = 1; i <= c; i++) {
					System.out.print(rs.getString(i));
					
					if (i != c)
						System.out.print(", ");
				}				
				
				System.out.println();
			}
		}
		
		connection.close();
		
		/*
		 * TODO
		 * 0. Salir.
		 * 1. Nuevo.
		 * 2. Modificar.
		 * 3. Eliminar.
		 * 4. Consultar.
		 * 5. Listar
		 * 
		 */
	}

}
