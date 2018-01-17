package org.institutoserpis.juanminm.gventa;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.OneToMany;

@Entity(name = "cliente")
public class Cliente {
	@Id
	@GeneratedValue
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

	public String getNombre() {
		return nombre;
	}

	@Override
	public String toString() {
		return String.format("[%s] %s", id, nombre);
	}
}
