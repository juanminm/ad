package org.institutoserpis.juanminm.gselling;

import java.math.BigDecimal;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.Table;

@Entity(name = "orderline")
@Table(name="pedidolinea")
public class OrderLine {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private long id;

	@ManyToOne
	@JoinColumn(name = "pedido")
	private Order order;

	@ManyToOne
	@JoinColumn(name = "articulo")
	private Product product;

	@Column(name = "`precio`")
	private BigDecimal price;

	@Column(name = "`unidades`")
	private BigDecimal units;

	@Column(name = "`importe`")
	private BigDecimal amount;

	public OrderLine() {}

	public OrderLine(Order order, Product product, BigDecimal price,
			BigDecimal units, BigDecimal amount) {
		this.order = order;
		this.product = product;
		this.price = price;
		this.units = units;
		this.amount = amount;
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public Order getOrder() {
		return order;
	}

	public void setOrder(Order order) {
		this.order = order;
	}

	public Product getProduct() {
		return product;
	}

	public void setProduct(Product product) {
		this.product = product;
		price = product.getPrice();
		units = new BigDecimal(1);
		updateAmount();
	}

	public BigDecimal getPrice() {
		return price;
	}

	public void setPrice(BigDecimal price) {
		this.price = price;
		updateAmount();
	}

	public BigDecimal getUnits() {
		return units;
	}

	public void setUnits(BigDecimal units) {
		this.units = units;
		updateAmount();
	}

	public BigDecimal getAmount() {
		return amount;
	}

	public void setImporte(BigDecimal amount) {
		this.amount = amount;
	}

	public void updateAmount() {
		this.amount = price.multiply(units);
	}

	@Override
	public String toString() {
		return String.format("[%s] (%s) (%s) %s %s %s", id, order, product,
				price, units, amount);
	}
}
