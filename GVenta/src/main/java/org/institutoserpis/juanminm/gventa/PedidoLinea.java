package org.institutoserpis.juanminm.gventa;

import java.math.BigDecimal;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;

@Entity(name = "pedidolinea")
public class PedidoLinea {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private long id;

	@ManyToOne
	@JoinColumn(name = "pedido")
	private Pedido pedido;

	@ManyToOne
	@JoinColumn(name = "articulo")
	private Articulo articulo;

	@Column(name = "`precio`")
	private BigDecimal precio;

	@Column(name = "`unidades`")
	private BigDecimal unidades;

	@Column(name = "`importe`")
	private BigDecimal importe;

	public PedidoLinea() {

	}

	public PedidoLinea(Pedido pedido, Articulo articulo, BigDecimal precio,
			BigDecimal unidades, BigDecimal importe) {
		this.pedido = pedido;
		this.articulo = articulo;
		this.precio = precio;
		this.unidades = unidades;
		this.importe = importe;
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public Pedido getPedido() {
		return pedido;
	}

	public void setPedido(Pedido pedido) {
		this.pedido = pedido;
	}

	public Articulo getArticulo() {
		return articulo;
	}

	public void setArticulo(Articulo articulo) {
		this.articulo = articulo;
	}

	public BigDecimal getPrecio() {
		return precio;
	}

	public void setPrecio(BigDecimal precio) {
		this.precio = precio;
	}

	public BigDecimal getUnidades() {
		return unidades;
	}

	public void setUnidades(BigDecimal unidades) {
		this.unidades = unidades;
	}

	public BigDecimal getImporte() {
		return importe;
	}

	public void setImporte(BigDecimal importe) {
		this.importe = importe;
	}

	@Override
	public String toString() {
		return String.format("[%s] (%s) (%s) %s %s %s", id, pedido, articulo,
				precio, unidades, importe);
	}
}
