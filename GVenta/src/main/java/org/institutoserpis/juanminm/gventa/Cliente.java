package org.institutoserpis.juanminm.gventa;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;

@Entity(name = "cliente")
public class Cliente {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private long id;

	@Column(name = "`nombre`")
	private String nombre;

	@OneToMany(mappedBy = "cliente")
	private List<Pedido> pedidos = new ArrayList<>();

	public Cliente() {}

	public Cliente(String nombre) {
		this.nombre = nombre;
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getNombre() {
		return nombre;
	}

	public void setNombre(String nombre) {
		this.nombre = nombre;
	}

	public List<Pedido> getPedidos() {
		return pedidos;
	}

	public void setPedidos(List<Pedido> pedidos) {
		this.pedidos = pedidos;
	}

	public void add(Pedido pedido) {
		pedidos.add(pedido);
		pedido.setCliente(this);
	}

	public void remove(Pedido pedido) {
		pedidos.remove(pedido);
		pedido.setCliente(null);
	}

	@Override
	public String toString() {
		return String.format("[%s] %s", id, nombre);
	}
}
