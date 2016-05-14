package whipsaw.server.dao;

import java.net.URL;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.scheduling.annotation.Scheduled;

import com.fasterxml.jackson.databind.ObjectMapper;

import whipsaw.server.domain.CateringObject;

public class CateringDataRefresher {

	private final int REFRESH_RATE = 60000;
	
	private final String URL = "http://datatank.pxl.be/core/public/pxl/catering";
	
	@Autowired
	CateringData cateringdata;
	
	@Autowired
    whipsaw.server.messages.MessageTopics messageTopics;
	
	@Scheduled(fixedDelay=REFRESH_RATE)
	public void refresh() throws Exception{
		CateringObject[] cateringobjects = getCateringObjects();
		cateringdata.setCateringObjects(cateringobjects);
		//refreshMessages(cateringobjects);
	}
	
	private CateringObject[] getCateringObjects() throws Exception{
		ObjectMapper mapper = new ObjectMapper();
		CateringObject[] cateringobjects = mapper.readValue(new URL(URL), CateringObject[].class);
		return cateringobjects;
	}
	
	
	
}
