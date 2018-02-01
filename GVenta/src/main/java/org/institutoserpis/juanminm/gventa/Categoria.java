package org.institutoserpis.juanminm.gventa;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;

@Entity(name = "categoria")
public class Categoria {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	private long id;

	@Column(name = "`nombre`")
	private String nombre;

    @OneToMany(mappedBy = "categoria")
    private List<Articulo> articulos = new ArrayList<>();

	public Categoria() {}

	public Categoria(String nombre) {
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

	public List<Articulo> getArticulos() {
		return articulos;
	}

	public void setArticulos(List<Articulo> articulos) {
		this.articulos = articulos;
	}

	public void add(Articulo articulo) {
		articulos.add(articulo);
		articulo.setCategoria(this);
	}

	public void remove(Articulo articulo) {
		articulos.remove(articulo);
		articulo.setCategoria(null);
	}

	@Override
	public String toString() {
		return String.format("[%s] %s", id, nombre);
	}
}