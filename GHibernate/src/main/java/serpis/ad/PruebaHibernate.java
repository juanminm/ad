package serpis.ad;

import java.util.Date;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class PruebaHibernate {

	static EntityManagerFactory entityManagerFactory;

	public static void main(String[] args) {
		Logger.getLogger("org.hibernate").setLevel(Level.OFF);
		entityManagerFactory =
				Persistence.createEntityManagerFactory("serpis.ad.ghibernate");

		showAll();

		newCategoria();

		modify(1L);

		remove(2L);

		showAll();

		entityManagerFactory.close();
	}

	private static void newCategoria() {
		//TODO
		Categoria categoria = new Categoria();
		categoria.setNombre("nuevo" + new Date());
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		System.out.println("Craendo " + categoria);
		entityManager.persist(categoria);
		System.out.println("Creado " + categoria);
		entityManager.getTransaction().commit();
	}

	private static void modify(long id) {
		System.out.println("Modificando categoria " + id);
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		Categoria categoria = entityManager.find(Categoria.class, id);
		categoria.setNombre("Modificado " + new Date());
		entityManager.getTransaction().commit();
	}

	private static void remove(long id) {
		System.out.println("Modificando categoria " + id);
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		Categoria categoria = entityManager.getReference(Categoria.class, id);
		entityManager.remove(categoria);
		entityManager.getTransaction().commit();
	}

	private static void showAll() {
		EntityManager entityManager =
				entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		List<Categoria> categorias = entityManager
				.createQuery("from Categoria", Categoria.class).getResultList();
		for (Categoria categoria : categorias)
			System.out.println(categoria);
		entityManager.getTransaction().commit();
	}

}
