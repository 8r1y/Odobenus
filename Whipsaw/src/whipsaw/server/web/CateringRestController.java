package whipsaw.server.web;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import whipsaw.server.dao.CateringData;
import whipsaw.server.domain.CateringObject;

@RestController
@RequestMapping("/catering")
public class CateringRestController {
	
	@Autowired
	private CateringData cateringdata;
	
	@Secured({"ROLE_CLIENT_APP"})
	@RequestMapping(method = RequestMethod.GET, produces = "application/json")
	public List<CateringObject> getCatering(){
		return cateringdata.getAllCaterings();
	}
}
