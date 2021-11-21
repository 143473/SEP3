//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.3.2 
// See <a href="https://javaee.github.io/jaxb-v2/">https://javaee.github.io/jaxb-v2/</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2021.11.21 at 03:05:52 PM CET 
//


package io.spring.guides.gs_producing_web_service;

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
 *         &lt;element name="notification" type="{http://www.w3.org/2001/XMLSchema}string"/&gt;
 *         &lt;element name="game" type="{http://spring.io/guides/gs-producing-web-service}Game"/&gt;
 *         &lt;element name="gameList" type="{http://spring.io/guides/gs-producing-web-service}GameList"/&gt;
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
    "notification",
    "game",
    "gameList"
})
@XmlRootElement(name = "SOAPGameResponse")
public class SOAPGameResponse {

    @XmlElement(required = true)
    protected String notification;
    @XmlElement(required = true)
    protected Game game;
    @XmlElement(required = true)
    protected GameList gameList;

    /**
     * Gets the value of the notification property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getNotification() {
        return notification;
    }

    /**
     * Sets the value of the notification property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNotification(String value) {
        this.notification = value;
    }

    /**
     * Gets the value of the game property.
     * 
     * @return
     *     possible object is
     *     {@link Game }
     *     
     */
    public Game getGame() {
        return game;
    }

    /**
     * Sets the value of the game property.
     * 
     * @param value
     *     allowed object is
     *     {@link Game }
     *     
     */
    public void setGame(Game value) {
        this.game = value;
    }

    /**
     * Gets the value of the gameList property.
     * 
     * @return
     *     possible object is
     *     {@link GameList }
     *     
     */
    public GameList getGameList() {
        return gameList;
    }

    /**
     * Sets the value of the gameList property.
     * 
     * @param value
     *     allowed object is
     *     {@link GameList }
     *     
     */
    public void setGameList(GameList value) {
        this.gameList = value;
    }

}
