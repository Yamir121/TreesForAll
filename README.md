# TreesForAll: VR Awareness Campaign

### Interpetatie Opdracht:
De kracht van VR gebruiken / optimaliseren door het in te zetten voor een awareness campagne over de bebossingsprojecten waar Trees for All aan bijdraagt.

**Het doel:**
spelers ervaren de uitdagingen en successen in het bebossen van een gebied.
Om een doelgerichte, effectieve applied game te ontwikkelen waarin de doelgroep centraal staan binnen de opgestelde kaders en vereisten, is het van belang om een context scheppen. 

**TreesForAll:**
Doel vanuit Trees for All: gedachte meegeven dat opnieuw bebossen van bestaande gebieden is complexer dan simpelweg bomen planten. 
Zo is het bijvoorbeeld belangrijk om inheemse soorten te gebruiken en nauwkeurig een nieuw ecosysteem op te zetten, verschillende problemen vereisen een andere aanpak, bossen groeien niet vanzelf weer aan, ook al doet de natuur zijn werk. 
-
    _“Een gezond bos vraagt om de juiste bomen op de juiste plek, goede voorbereiding van de bodem én aanpassing aan klimaatverandering.” 
    – website Trees for All_

# Concept

### "Build Your Own Forest"
* Te spelen op o.a. NS-stations (denk aan pop-up Utrecht Centraal), festivals, of openbare ruimtes
* VR-ervaring van max. 5 minuten per speler
* De speler krijgt een realistische uitdaging en het doel om een klein stuk grond opnieuw te bebossen.
* Resultaat deelbaar op social media voor bredere impact

### Gameplay
Doel voor de speler: herbebos een gebied zo goed mogelijk.

Stappenplan voor de speler:
1.	De speler krijgt 5 minuten de tijd om een bos te planten
Hierin is het de uitdaging om slim te planten en verstoringen op te ruimen. Alle spelers starten met een gebied in de wereld, bodemtype, beginwaardes en één van drie ecologische problemen.
2.	De speler krijgt de mogelijkheid om dit bos uit te breiden en ontstane ecologische problemen op te lossen
Op basis van het ecologische probleem: slechte bodem, zaadgebrek of klimaatverandering, hebben verschillen planten de voorkeur. Zo kan de speler bodembedekkers, zaaddragende struiken, klimaatbestendige bomen, inheemse bomen en meer planten. 
Een tipsysteem in combinatie met realtime effect van de keuzes in de vorm van 3 statusbalken in het user-interface, geeft de speler inzicht in voortgang.
3.	De speler krijgt een inzicht op hoe hij / zij het heeft gedaan, op basis van biodiversiteit, grondkwaliteit en CO2-opslag capaciteit.
Aan het eind krijgt de speler een score op basis van de 3 statusbalken en efficiëntie. Ongeacht de score zijn spelers creatief bezig geweest met een ecologische uitdaging en hebben ze een uniek eigen bos gemaakt. De score én de spelers zelf gemaakte bos kunnen gedeeld worden op social media om delen te stimuleren.

# Technische uitwerking

### Lijst aan gebruikte assets
* Synty Polygon Pack
* https://www.freepik.com/free-vector/wooden-frames-buttons-with-jungle-leaves_133568965.htm
* https://sketchfab.com/3d-models/watering-can-ffb0d644238b4c679658aa0ee46ac6da

### Lijst van ontwikkeltools en plugins
    * Unity 6000.1.1f1
    * Meta SDK 77.0.0
    * OpenXR plugin 1.14.3
    * Odin Inspector 3.3.1.13

### Functionele vereisten
1. De game moet een pop-up / user-interface systeem hebben waarin verschillende schermen weergegeven kunnen worden en een button input verwerkt kan worden.

2. De game moet verschillende levels bevatten met hierin:
    * Een locatie (geografisch)
    * Een bodemtype (gebaseerd op geografische locatie)
    * Startwaardes van de drie statusbalken: bodemkwaliteit, biodiversiteit, CO₂-opslag (gebaseerd op de probleemstelling)
    * Eén van drie probleemstellingen (gedegradeerde bodem, zaadgebrek, klimaatverandering)

3. De game moet levels inladen, interrupten, resetten, en nieuwe inladen.

4. De game moet een gameplay systeem hebben die levels kan starten en eindigen, realtime waardes bijhoudt en events kan triggeren.

5. De game moet een grid-systeem hebben waarin planten gemanaged worden.

6. De game moet een timer systeem hebben welke gestart kan worden door het gameplay systeem.

7. Spelers moeten de volgende acties kunnen uitvoeren met hierbij zichbare signifiers en feedback:
    * Selecteren uit de zadenselectie
    * Planten van zaden (bomen, struiken, bodembedekkers)
    * Water geven aan planten
    * Verwijderen van ongewenste planten of dode vegetatie, invasieve soorten

8. De game moet een beplanting selectie hebben voor de speler om te selecteren:
    * Inheemse bomen (diverse types)
    * Klimaatrobuuste exoten (laag invasief)
    * Zuidelijke varianten
    * Zaaddragende struiken
    * Grassen en bodembedekkers

9. Drie statusbalken moeten op een HUD dynamisch reageren op speleracties.

10. Score systeem die berekend op basis van:
    * Verbetering van statusbalk waardes
    * Efficiëntie van zaadgebruik

11. De game mag een tipsysteem hebben die suggesties doet als speler vast zit.

12. De game mag een diversion systeem krijgen waar levels een extra taak / uitdaging toegewezen kunnen krijgen.

13. De game mag een optie bieden om de gecreeërde bebossing te delen op social media.

### Niet-functionele vereisten

1. De VR-ervaring moet volledig speelbaar zijn binnen 5 minuten.

2. Het systeem moet toegankelijk en intuïtief zijn voor gebruikers zonder gaming ervaring of ecologische voorkennis.

3. De visuele stijl is sfeervol, toegankelijk en speels. Maakt gebruik van aarde-tonen en groen, met een biologische uitstraling.

4. De ervaring moet geschikt zijn voor gebruik op openbare locaties (zoals NS-stations), met vloeiende doorstroom en lage instapdrempel.

5. Feedback en uitleg moeten compact, visueel en in begrijpelijke taal zijn (geen vakjargon).

6. De game moet offline speelbaar zijn, met optionele online functionaliteit voor het delen van resultaten.

7. De game moet met minimaal 90 fps draaien op alle momenten.

8. de speler moet fysiek kunnen bewegen in VR roomscale setup.
