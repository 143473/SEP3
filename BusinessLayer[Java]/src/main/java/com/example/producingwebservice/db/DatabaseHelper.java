package com.example.producingwebservice.db;

import org.postgresql.Driver;

import javax.xml.datatype.DatatypeConfigurationException;
import java.sql.*;
import java.util.LinkedList;
import java.util.List;

public class DatabaseHelper<T> {
	private String jdbcURL;
	private String username;
	private String password;
	
	public DatabaseHelper(String jdbcURL, String username, String password) {
		this.jdbcURL = jdbcURL;
		this.username = username;
		this.password = password;
		try {
			DriverManager.registerDriver(new Driver());
		} catch (SQLException e) {
			throw new RuntimeException("No JDBC driver", e);
		}
	}
	
	public DatabaseHelper(String jdbcURL) {
		this(jdbcURL, null, null);
	}
	
	protected Connection getConnection() throws SQLException {
		if (username == null) {
			return DriverManager.getConnection(jdbcURL);
		} else {
			return DriverManager.getConnection(jdbcURL, username, password);
		}
	}

	private PreparedStatement prepare(Connection connection, String sql, Object[] parameters) throws SQLException {
		PreparedStatement stat = connection.prepareStatement(sql);
		for(int i = 0; i < parameters.length; i++) {
			stat.setObject(i + 1, parameters[i]);
		}
		return stat;
	}

	public int executeUpdate(String sql, Object... parameters) {
		try (Connection connection = getConnection()) {
			PreparedStatement stat = prepare(connection, sql, parameters);
			return stat.executeUpdate();
		} catch (SQLException e) {
			throw new RuntimeException(e.getMessage(), e);
		}
	}
	
	public T mapSingle(DataMapper<T> mapper, String sql, Object... parameters) {
		try (Connection connection = getConnection()) {
			PreparedStatement stat = prepare(connection, sql, parameters);
			ResultSet rs = stat.executeQuery();
			if(rs.next()) {
				return mapper.create(rs);
			} else {
				return null;
			}
		} catch (SQLException | DatatypeConfigurationException e) {
			throw new RuntimeException(e.getMessage(), e);
		}
	}

	public List<T> map(DataMapper<T> mapper, String sql, Object... parameters) {
		try (Connection connection = getConnection()) {
			PreparedStatement stat = prepare(connection, sql, parameters);
			ResultSet rs = stat.executeQuery();
			LinkedList<T> allMessages = new LinkedList<>();
			while(rs.next()) {
				allMessages.add(mapper.create(rs));
			}

			return allMessages;
		} catch (SQLException | DatatypeConfigurationException e) {
			throw new RuntimeException(e.getMessage(), e);
		}
	}
}
