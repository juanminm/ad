package org.institutoserpis.juanminm.gselling;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;

@Entity(name = "client")
@Table(name="cliente")
public class Client {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private long id;

	@Column(name = "`nombre`")
	private String name;

	@OneToMany(mappedBy = "client")
	private List<Order> orders = new ArrayList<>();

	public Client() {}

	public Client(String name) {
		this.name = name;
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public List<Order> getOrders() {
		return orders;
	}

	public void setOrders(List<Order> orders) {
		this.orders = orders;
	}

	public void add(Order order) {
		orders.add(order);
		order.setClient(this);
	}

	public void remove(Order order) {
		orders.remove(order);
		order.setClient(null);
	}

	@Override
	public String toString() {
		return String.format("[%s] %s", id, name);
	}
}
