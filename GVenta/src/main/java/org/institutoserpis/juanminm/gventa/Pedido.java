package org.institutoserpis.juanminm.gventa;

import java.math.BigDecimal;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.ManyToOne;

@Entity(name = "pedido")
public class Pedido {
	@Id
	@GeneratedValue
	private long id;

	@ManyToOne
	private Cliente cliente;

	@Column(name = "`fecha`")
	private String fecha;

	@Column(name = "`importe`")
	private BigDecimal importe;

	public Pedido() {
	}

	public Pedido(Cliente cliente, String fecha, BigDecimal importe) {
		this.cliente = cliente;
		this.fecha = fecha;
		this.importe = importe;
	}

	public long getId() {
		return id;
	}

	public Cliente getCliente() {
		return cliente;
	}

	public String getFecha() {
		return fecha;
	}

	public BigDecimal getImporte() {
		return importe;
	}



}