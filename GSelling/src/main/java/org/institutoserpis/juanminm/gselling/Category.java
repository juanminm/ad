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

@Entity(name = "category")
@Table(name="categoria")
public class Category {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private long id;

	@Column(name = "`nombre`")
	private String name;

    @OneToMany(mappedBy = "category")
    private List<Product> products = new ArrayList<>();

	public Category() {}

	public Category(String name) {
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

	public List<Product> getProducts() {
		return products;
	}

	public void setProducts(List<Product> products) {
		this.products = products;
	}

	public void add(Product product) {
		products.add(product);
		product.setCategory(this);
	}

	public void remove(Product product) {
		products.remove(product);
		product.setCategory(null);
	}

	@Override
	public String toString() {
		return String.format("[%s] %s", id, name);
	}
}