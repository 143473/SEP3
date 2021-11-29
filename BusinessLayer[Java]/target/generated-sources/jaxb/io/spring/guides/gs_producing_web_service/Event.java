//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.3.2 
// See <a href="https://javaee.github.io/jaxb-v2/">https://javaee.github.io/jaxb-v2/</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2021.11.29 at 10:21:50 AM CET 
//


package io.spring.guides.gs_producing_web_service;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlSchemaType;
import javax.xml.bind.annotation.XmlType;
import javax.xml.datatype.XMLGregorianCalendar;


/**
 * <p>Java class for Event complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="Event"&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="id" type="{http://www.w3.org/2001/XMLSchema}int"/&gt;
 *         &lt;element name="name" type="{http://www.w3.org/2001/XMLSchema}string"/&gt;
 *         &lt;element name="startTime" type="{http://www.w3.org/2001/XMLSchema}dateTime"/&gt;
 *         &lt;element name="endTime" type="{http://www.w3.org/2001/XMLSchema}dateTime"/&gt;
 *         &lt;element name="addressStreetName" type="{http://www.w3.org/2001/XMLSchema}string"/&gt;
 *         &lt;element name="addressStreetNumber" type="{http://www.w3.org/2001/XMLSchema}string"/&gt;
 *         &lt;element name="addressApartmentNumber" type="{http://www.w3.org/2001/XMLSchema}string"/&gt;
 *         &lt;element name="maxNumberOfParticipants" type="{http://www.w3.org/2001/XMLSchema}int"/&gt;
 *         &lt;element name="numberOfParticipants" type="{http://www.w3.org/2001/XMLSchema}int"/&gt;
 *         &lt;element name="eventCategory" type="{http://www.w3.org/2001/XMLSchema}int"/&gt;
 *         &lt;element name="organizer" type="{http://www.w3.org/2001/XMLSchema}string"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "Event", propOrder = {
    "id",
    "name",
    "startTime",
    "endTime",
    "addressStreetName",
    "addressStreetNumber",
    "addressApartmentNumber",
    "maxNumberOfParticipants",
    "numberOfParticipants",
    "eventCategory",
    "organizer"
})
public class Event {

    protected int id;
    @XmlElement(required = true)
    protected String name;
    @XmlElement(required = true)
    @XmlSchemaType(name = "dateTime")
    protected XMLGregorianCalendar startTime;
    @XmlElement(required = true)
    @XmlSchemaType(name = "dateTime")
    protected XMLGregorianCalendar endTime;
    @XmlElement(required = true)
    protected String addressStreetName;
    @XmlElement(required = true)
    protected String addressStreetNumber;
    @XmlElement(required = true)
    protected String addressApartmentNumber;
    protected int maxNumberOfParticipants;
    protected int numberOfParticipants;
    protected int eventCategory;
    @XmlElement(required = true)
    protected String organizer;

    /**
     * Gets the value of the id property.
     * 
     */
    public int getId() {
        return id;
    }

    /**
     * Sets the value of the id property.
     * 
     */
    public void setId(int value) {
        this.id = value;
    }

    /**
     * Gets the value of the name property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getName() {
        return name;
    }

    /**
     * Sets the value of the name property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setName(String value) {
        this.name = value;
    }

    /**
     * Gets the value of the startTime property.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public XMLGregorianCalendar getStartTime() {
        return startTime;
    }

    /**
     * Sets the value of the startTime property.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setStartTime(XMLGregorianCalendar value) {
        this.startTime = value;
    }

    /**
     * Gets the value of the endTime property.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public XMLGregorianCalendar getEndTime() {
        return endTime;
    }

    /**
     * Sets the value of the endTime property.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setEndTime(XMLGregorianCalendar value) {
        this.endTime = value;
    }

    /**
     * Gets the value of the addressStreetName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getAddressStreetName() {
        return addressStreetName;
    }

    /**
     * Sets the value of the addressStreetName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAddressStreetName(String value) {
        this.addressStreetName = value;
    }

    /**
     * Gets the value of the addressStreetNumber property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getAddressStreetNumber() {
        return addressStreetNumber;
    }

    /**
     * Sets the value of the addressStreetNumber property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAddressStreetNumber(String value) {
        this.addressStreetNumber = value;
    }

    /**
     * Gets the value of the addressApartmentNumber property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getAddressApartmentNumber() {
        return addressApartmentNumber;
    }

    /**
     * Sets the value of the addressApartmentNumber property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAddressApartmentNumber(String value) {
        this.addressApartmentNumber = value;
    }

    /**
     * Gets the value of the maxNumberOfParticipants property.
     * 
     */
    public int getMaxNumberOfParticipants() {
        return maxNumberOfParticipants;
    }

    /**
     * Sets the value of the maxNumberOfParticipants property.
     * 
     */
    public void setMaxNumberOfParticipants(int value) {
        this.maxNumberOfParticipants = value;
    }

    /**
     * Gets the value of the numberOfParticipants property.
     * 
     */
    public int getNumberOfParticipants() {
        return numberOfParticipants;
    }

    /**
     * Sets the value of the numberOfParticipants property.
     * 
     */
    public void setNumberOfParticipants(int value) {
        this.numberOfParticipants = value;
    }

    /**
     * Gets the value of the eventCategory property.
     * 
     */
    public int getEventCategory() {
        return eventCategory;
    }

    /**
     * Sets the value of the eventCategory property.
     * 
     */
    public void setEventCategory(int value) {
        this.eventCategory = value;
    }

    /**
     * Gets the value of the organizer property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getOrganizer() {
        return organizer;
    }

    /**
     * Sets the value of the organizer property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOrganizer(String value) {
        this.organizer = value;
    }

}
