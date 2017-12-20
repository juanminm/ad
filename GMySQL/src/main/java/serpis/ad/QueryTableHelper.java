package serpis.ad;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

public class QueryTableHelper {

	private static int getLongestString(String[][] data, int col) {
		int i = 0;
		int maxLength = 0;

		while (i < data.length) {
			if (data[i][col] != null && data[i][col].length() > maxLength)
				maxLength = data[i][col].length();
			i++;
		}
		return maxLength;
	}

	private static int[] getColSizes(String[][] data) {
		int i = 0;
		int j = 0;
		int[] colSize = new int[data.length];

		while (j < data[i].length) {
			colSize[j] = getLongestString(data, j);
			j++;
		}

		return colSize;
	}

	private static void fillQueryTable(ResultSet rs) throws SQLException {
		ArrayList<String[]> data = new ArrayList<>();
		String[][] rows;
		String[] colLabels;
		String format = "";
		String header = "";
		int[] colMaxSizes;
		int columnCount = rs.getMetaData().getColumnCount();

		colLabels = new String[columnCount];

		for (int i = 0; i < columnCount; i++)
			colLabels[i] = rs.getMetaData().getColumnLabel(i + 1);

		while (rs.next()) {
			String[] row = new String[columnCount];
			for (int i = 0; i < columnCount; i++)
				row[i] = rs.getString(i + 1) != null ? rs.getString(i + 1) : "";

			data.add(row);
		}

		rows = data.toArray(new String[data.size()][columnCount]);

		colMaxSizes = getColSizes(rows);

		for (int i = 0; i < colLabels.length; i++) {
			String tmp = "%-"
					+ (colMaxSizes[i] > colLabels[i].length() ? colMaxSizes[i]
							: colLabels[i].length())
					+ "s";

			if (i != colLabels.length - 1)
				tmp += " | ";
			else
				tmp += "%n";

			header += String.format(tmp, colLabels[i]);
			format += tmp;
		}
		System.out.print(header);

		for (int i = 0; i < header.length(); i++)
			System.out.print("-");
		System.out.println();

		for (Object[] column : rows)
			System.out.printf(format, column);

	}

	public static void showQueryTable(String selectSql) throws SQLException {
		Statement stmt = App.getConnection().createStatement();
		ResultSet rs = stmt.executeQuery(selectSql);

		fillQueryTable(rs);
	}
}
