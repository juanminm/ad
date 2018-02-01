package org.institutoserpis.juanminm.gselling;

import java.math.BigDecimal;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.ForeignKey;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.Table;

@Entity(name = "product")
@Table(name="articulo")
public class Product {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private long id;

	@Column(name = "`nombre`")
	private String name;

	@Column(name = "`precio`")
	private BigDecimal price;

	@ManyToOne
	@JoinColumn(name = "categoria",
	foreignKey = @ForeignKey(name = "pedido_ibfk_1")
	)
	private Category category;

	@OneToMany(mappedBy = "product")
	private List<OrderLine> orderLines;

	public Product() {}

	public Product(String name, BigDecimal price, Category category) {
		this.name = name;
		this.price = price;
		this.category = category;
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

	public BigDecimal getPrice() {
		return price;
	}

	public void setPrice(BigDecimal price) {
		this.price = price;
	}

	public Category getCategory() {
		return category;
	}

	public void setCategory(Category category) {
		this.category = category;
	}

	public List<OrderLine> getOrderLines() {
		return orderLines;
	}

	public void setOrderLines(List<OrderLine> orderLines) {
		this.orderLines = orderLines;
	}

	public void add(OrderLine orderLine) {
		orderLines.add(orderLine);
		orderLine.setProduct(this);
	}

	@Override
	public String toString() {
		return String.format("[%s] %s %s (%s)", id, name, price,
				category);
	}
}
