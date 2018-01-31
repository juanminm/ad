package org.institutoserpis.juanminm.gventa;

import java.math.BigDecimal;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class VentaMain {

	private static EntityManagerFactory entityManagerFactory;

	public static void main(String[] args) {
		entityManagerFactory = Persistence.createEntityManagerFactory(
				"org.institutoserpis.juanminm.gventa"
		);
		showAll(Articulo.class);
		entityManagerFactory.close();
	}

	private static <T> void showAll(String sqlString, Class<T> itemClass) {
		EntityManager entityManager = entityManagerFactory
				.createEntityManager();
		entityManager.getTransaction().begin();
		List<T> items = entityManager.createQuery(sqlString, itemClass)
				.getResultList();
		for (Object item : items)
			System.out.println(item);
		entityManager.getTransaction().commit();
	}

	private static <T> void showAll(Class<T> itemClass) {
		String table = itemClass.getSimpleName().toLowerCase();
		showAll(String.format("from %s order by id", table), itemClass);
	}

	private static void newArticulo(String name, BigDecimal price,
			Categoria category) {
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		Articulo articulo = new Articulo();
		articulo.setNombre(name);
		articulo.setPrecio(price);
		articulo.setCategoria(category);
		entityManager.persist(articulo);
		entityManager.getTransaction().commit();
	}

}
