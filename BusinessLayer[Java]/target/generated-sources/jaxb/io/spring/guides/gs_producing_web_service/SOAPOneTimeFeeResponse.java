//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.3.2 
// See <a href="https://javaee.github.io/jaxb-v2/">https://javaee.github.io/jaxb-v2/</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2021.11.30 at 02:55:59 PM CET 
//


package io.spring.guides.gs_producing_web_service;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for anonymous complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="OneTimeFee" type="{http://spring.io/guides/gs-producing-web-service}OneTimeFee"/&gt;
 *         &lt;element name="OneTimeFeeList" type="{http://spring.io/guides/gs-producing-web-service}OneTimeFee" maxOccurs="unbounded"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "oneTimeFee",
    "oneTimeFeeList"
})
@XmlRootElement(name = "SOAPOneTimeFeeResponse")
public class SOAPOneTimeFeeResponse {

    @XmlElement(name = "OneTimeFee", required = true)
    protected OneTimeFee oneTimeFee;
    @XmlElement(name = "OneTimeFeeList", required = true)
    protected List<OneTimeFee> oneTimeFeeList;

    /**
     * Gets the value of the oneTimeFee property.
     * 
     * @return
     *     possible object is
     *     {@link OneTimeFee }
     *     
     */
    public OneTimeFee getOneTimeFee() {
        return oneTimeFee;
    }

    /**
     * Sets the value of the oneTimeFee property.
     * 
     * @param value
     *     allowed object is
     *     {@link OneTimeFee }
     *     
     */
    public void setOneTimeFee(OneTimeFee value) {
        this.oneTimeFee = value;
    }

    /**
     * Gets the value of the oneTimeFeeList property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the oneTimeFeeList property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getOneTimeFeeList().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link OneTimeFee }
     * 
     * 
     */
    public List<OneTimeFee> getOneTimeFeeList() {
        if (oneTimeFeeList == null) {
            oneTimeFeeList = new ArrayList<OneTimeFee>();
        }
        return this.oneTimeFeeList;
    }

}
