package whipsaw.server.domain;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonProperty;

@JsonIgnoreProperties(ignoreUnknown = true)
@Entity
@Table(name = "caterings")
public class CateringObject {
	@JsonProperty
	@Id
	@Column(name = "ID")
	private int id;
	
	@JsonProperty
	@Column(name = "Title")
	private String title;
	
	@JsonProperty
	@Column(name = "Datum")
	private String datum;
	
	@JsonProperty
	@Column(name = "Voorgerecht")
	private String voorgerecht;
	
	@JsonProperty
	@Column(name = "HoofdGerecht")
	private String hoofdgerecht;
	
	@JsonProperty
	@Column(name = "NaGerecht")
	private String nagerecht;
	
	@JsonProperty
	@Column(name = "WeekSoep")
	private String weeksoep;
	
	@JsonProperty
	@Column(name = "MaaltijdSoepEnBrood")
	private String maaltijdsoepenbrood;
	
	@JsonProperty
	@Column(name = "Veggie")
	private String veggie;
	
	@JsonProperty
	@Column(name = "Aanrader")
	private String aanrader;
	
	@JsonProperty
	@Column(name = "PastaVanDeDag")
	private String pastavandedag;
	
	@JsonProperty
	@Column(name = "Suggestie")
	private String suggestie;
	
	@JsonProperty
	@Column(name = "Locatie")
	private String locatie;
	
	@JsonProperty
	@Column(name = "HealthFood")
	private String healthfood;
	
	@JsonProperty
	@Column(name = "SnackVanDeDag")
	private String snackvandedag;
	
	public CateringObject(int id, String title, String datum, String voorgerecht, String hoofdgerecht, String nagerecht, String weeksoep, String maaltijdsoepenbrood, String veggie, String aanrader, String pastavandedag, String suggestie, String locatie, String healthfood, String snackvandedag){
		this.id = id;
		this.title = title;
		this.datum = datum;
		this.voorgerecht = voorgerecht;
		this.hoofdgerecht = hoofdgerecht;
		this.nagerecht = nagerecht;
		this.weeksoep = weeksoep;
		this.maaltijdsoepenbrood = maaltijdsoepenbrood;
		this.veggie = veggie;
		this.aanrader = aanrader;
		this.pastavandedag = pastavandedag;
		this.suggestie = suggestie;
		this.locatie = locatie;
		this.healthfood = healthfood;
		this.snackvandedag = snackvandedag;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public String getDatum() {
		return datum;
	}

	public void setDatum(String datum) {
		this.datum = datum;
	}

	public String getVoorgerecht() {
		return voorgerecht;
	}

	public void setVoorgerecht(String voorgerecht) {
		this.voorgerecht = voorgerecht;
	}

	public String getHoofdgerecht() {
		return hoofdgerecht;
	}

	public void setHoofdgerecht(String hoofdgerecht) {
		this.hoofdgerecht = hoofdgerecht;
	}

	public String getNagerecht() {
		return nagerecht;
	}

	public void setNagerecht(String nagerecht) {
		this.nagerecht = nagerecht;
	}

	public String getWeeksoep() {
		return weeksoep;
	}

	public void setWeeksoep(String weeksoep) {
		this.weeksoep = weeksoep;
	}

	public String getMaaltijdsoepenbrood() {
		return maaltijdsoepenbrood;
	}

	public void setMaaltijdsoepenbrood(String maaltijdsoepenbrood) {
		this.maaltijdsoepenbrood = maaltijdsoepenbrood;
	}

	public String getVeggie() {
		return veggie;
	}

	public void setVeggie(String veggie) {
		this.veggie = veggie;
	}

	public String getAanrader() {
		return aanrader;
	}

	public void setAanrader(String aanrader) {
		this.aanrader = aanrader;
	}

	public String getPastavandedag() {
		return pastavandedag;
	}

	public void setPastavandedag(String pastavandedag) {
		this.pastavandedag = pastavandedag;
	}

	public String getSuggestie() {
		return suggestie;
	}

	public void setSuggestie(String suggestie) {
		this.suggestie = suggestie;
	}

	public String getLocatie() {
		return locatie;
	}

	public void setLocatie(String locatie) {
		this.locatie = locatie;
	}

	public String getHealthfood() {
		return healthfood;
	}

	public void setHealthfood(String healthfood) {
		this.healthfood = healthfood;
	}

	public String getSnackvandedag() {
		return snackvandedag;
	}

	public void setSnackvandedag(String snackvandedag) {
		this.snackvandedag = snackvandedag;
	}
	
	
}
