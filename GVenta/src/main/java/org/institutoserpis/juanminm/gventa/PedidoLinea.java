package org.institutoserpis.juanminm.gventa;

import java.math.BigDecimal;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.OneToOne;

@Entity(name = "pedidolinea")
public class PedidoLinea {
	@Id
	@GeneratedValue
	private long id;

	@OneToOne
	@JoinColumn(name = "pedido")
	private Pedido pedido;

	@OneToOne
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
}
