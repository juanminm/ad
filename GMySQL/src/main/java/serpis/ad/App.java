package serpis.ad;

import java.sql.Connection;
import java.sql.SQLException;

public class App {

	private static Connection connection;

	public static Connection getConnection() {
		return connection;
	}

	public static void setConnection(Connection connection) {
		App.connection = connection;
	}

	public static void closeConnection() throws SQLException {
		App.connection.close();
	}
}
