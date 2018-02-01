package org.institutoserpis.juanminm.gselling;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.persistence.CascadeType;
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

@Entity(name = "order")
@Table(name="pedido")
public class Order {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private long id;

	@ManyToOne
	@JoinColumn(name = "cliente",
	foreignKey = @ForeignKey(name = "pedido_ibfk_1")
	)
	private Client client;

	@Column(name = "`fecha`")
	private Calendar date = Calendar.getInstance();

	@Column(name = "`importe`")
	private BigDecimal totalAmount;

    @OneToMany(mappedBy = "order", cascade=CascadeType.ALL,
    		orphanRemoval=true)
    private List<OrderLine> orderLines = new ArrayList<>();

	public Order() {
	}

	public Order(Client client, Calendar date, BigDecimal totalAmount) {
		this.client = client;
		this.date = date;
		this.totalAmount = totalAmount;
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public Client getClient() {
		return client;
	}

	public void setClient(Client client) {
		this.client = client;
	}

	public Calendar getDate() {
		return date;
	}

	public void setDate(Date date) {
		this.date.setTime(date);
	}

	public BigDecimal getTotalAmount() {
		return totalAmount;
	}

	public void setTotalAmount(BigDecimal totalAmount) {
		this.totalAmount = totalAmount;
	}

	public void updateTotalAmount() {
		totalAmount = new BigDecimal(0);

		for (OrderLine pedidoLinea : orderLines)
			totalAmount.add(pedidoLinea.getAmount());
	}

	public OrderLine[] getOrderLines() {
		return orderLines.toArray(new OrderLine[orderLines.size()]);
	}

	public void setOrderLines(List<OrderLine> orderLines) {
		this.orderLines = orderLines;
	}

	public void add(OrderLine orderLine) {
		orderLines.add(orderLine);
		orderLine.setOrder(this);
	}

	public void remove(OrderLine orderLine) {
		orderLines.remove(orderLine);
		orderLine.setOrder(null);
	}

	@Override
	public String toString() {
		return String.format(
				"[%s] %s %s ($s)",
				id,
				date.getTime().toString(),
				totalAmount,
				client.toString()
		);
	}

}
