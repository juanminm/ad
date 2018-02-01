package org.institutoserpis.juanminm.gselling;

import java.math.BigDecimal;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class SellingMain {

	private static EntityManagerFactory entityManagerFactory;

	public static void main(String[] args) {
		entityManagerFactory = Persistence.createEntityManagerFactory(
				"org.institutoserpis.juanminm.gselling"
		);
		showAll(Product.class);
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

	private static void newProduct(
			String name, BigDecimal price, long categoryId
	) {
		EntityManager entityManager = entityManagerFactory
				.createEntityManager();
		Category category = entityManager
				.getReference(Category.class, categoryId);
		entityManager.getTransaction().begin();
		Product product = new Product();
		product.setName(name);
		product.setPrice(price);
		category.add(product);
		entityManager.persist(product);
		entityManager.getTransaction().commit();
	}

}
