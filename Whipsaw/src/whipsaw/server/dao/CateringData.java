package whipsaw.server.dao;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import org.hibernate.Session;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import com.mysql.fabric.xmlrpc.Client;

import whipsaw.server.domain.CateringObject;

@Repository
public class CateringData {
	
	@PersistenceContext
	EntityManager em;
	
	@Transactional
	public synchronized void setCateringObjects(CateringObject[] cateringobjects){
		
	}
	
	@Transactional
	public List<CateringObject> getAllCaterings() {
        Session ses = em.getEntityManagerFactory().createEntityManager().unwrap(Session.class);
        @SuppressWarnings("unchecked")
		List<CateringObject> objs = ses.createCriteria(CateringObject.class).list();
        ses.close();
        return objs;
    }
	
	
}
