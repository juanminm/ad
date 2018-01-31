package org.institutoserpis.juanminm.gventa;

import java.math.BigDecimal;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.ForeignKey;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;

@Entity(name = "articulo")
public class Articulo {
	@Id
	@GeneratedValue
	private long id;

	@Column(name = "`nombre`")
	private String nombre;

	@Column(name = "`precio`")
	private BigDecimal precio;

	@ManyToOne
	@JoinColumn(name = "categoria",
	foreignKey = @ForeignKey(name = "pedido_ibfk_1")
	)
	private Categoria categoria;

	public Articulo() {
	}

	public Articulo(String nombre, BigDecimal precio, Categoria categoria) {
		this.nombre = nombre;
		this.precio = precio;
		this.categoria = categoria;
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

	public BigDecimal getPrecio() {
		return precio;
	}

	public void setPrecio(BigDecimal precio) {
		this.precio = precio;
	}

	public Categoria getCategoria() {
		return categoria;
	}

	public void setCategoria(Categoria categoria) {
		this.categoria = categoria;
	}

	@Override
	public String toString() {
		return String.format("[%s] %s %s (%s)", id, nombre, precio,
				categoria);
	}
}
