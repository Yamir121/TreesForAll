# TreesForAll: VR Awareness Campaign

### Interpetatie Opdracht

De kracht van VR gebruiken / optimaliseren door het in te zetten voor een awareness campagne over de bebossingsprojecten waar Trees for All aan bijdraagt.

**Het doel**
spelers ervaren de uitdagingen en successen in het bebossen van een gebied.
Om een doelgerichte, effectieve applied game te ontwikkelen waarin de doelgroep centraal staan binnen de opgestelde kaders en vereisten, is het van belang om een context scheppen. 

**TreesForAll**
Doel vanuit Trees for All: gedachte meegeven dat opnieuw bebossen van bestaande gebieden complexer is dan simpelweg bomen planten. 
Zo is het bijvoorbeeld belangrijk om inheemse soorten te gebruiken en nauwkeurig een nieuw ecosysteem op te zetten, verschillende problemen vereisen een andere aanpak. Bebossing is essensieel voor de toekomst van de planteet. Bossen groeien niet vanzelf weer aan, ook al doet de natuur zijn werk. 

    “Een gezond bos vraagt om de juiste bomen op de juiste plek, goede voorbereiding van de bodem én aanpassing aan klimaatverandering.” 
*– Website Trees for All*

# Concept

### "Build Your Own Forest"
    * Te spelen op o.a. NS-stations (denk aan pop-up Utrecht Centraal), festivals, of openbare ruimtes
    * VR-ervaring van max. 5 minuten per speler
    * De speler krijgt een realistische uitdaging en het doel om een klein stuk grond opnieuw te bebossen.
    * Resultaat deelbaar op social media voor bredere impact

### Gameplay
Doel voor de speler: herbebos een gebied zo goed mogelijk.

Stappenplan voor de speler:
1.	De speler krijgt 5 minuten de tijd om een bos te planten.
Hierin is het de uitdaging om de juiste zaden te kiezen die helpen bij het oplossen van de ecologische uitdaging. Alle spelers starten met een gebied in de wereld, bodemtype, beginwaardes en een op te lossen probleem in dat gebied.

![alt text][StartBYOF]
[StartBYOF]: images/StartBYOF_Alt.gif "Gif showing the start of the game"

2.	Spelers interacteren met de game door hun hand te openen of sluiten. Zo kunnen spelers zaden pakken, planten, de gieter pakken én planten verwijderen. Op basis van de uitdaging: slechte bodem, zaadgebrek, klimaatverandering, etc., hebben verschillen planten de voorkeur. Zo kan de speler bodembedekkers, zaaddragende struiken, klimaatbestendige bomen, inheemse bomen en meer planten. Een tipsysteem in combinatie met realtime effect van de keuzes in de vorm van 3 statusbalken in het user-interface, geeft de speler inzicht in voortgang.

![alt text][InteractionsBYOF]
[InteractionsBYOF]: images/InteractionsBYOF_Alt.gif "Gif showing the interactions and gameplay"

3.	De speler krijgt een inzicht op hoe hij / zij het heeft gedaan, op basis van biodiversiteit, grondkwaliteit en CO2-opslag capaciteit.
Aan het eind krijgt de speler een score op basis van de 3 statusbalken en efficiëntie. Ongeacht de score zijn spelers creatief bezig geweest met een ecologische uitdaging en hebben ze een uniek eigen bos gemaakt. De score én de spelers zelf gemaakte bos kunnen gedeeld worden op social media om delen te stimuleren.

# Huidige staat
De core systemen zijn geimplementeerd en getest: Interacties, gameplay loop, grid systeem, planten, de gieter, de groei mechanic, UI en HUD en meer. Hiermee wordt de speler uitgedaagd om op een 5x5 grid bomen, zaaddragende struiken en grondbedekkers te planten die allemaal invloed hebben op het ecosysteem en daarmee de herbebossing. 
![alt text][orthoview]
[orthoview]: images/orthographic-view.png "Orthographic view of game"

Ieder systeem is gebouwd om uitbereidbaar te zijn en om te anticiperen op toekomstige keuzes. Zo zijn game variabelen zoals grid grootte en level lengte allemaal aanpasbaar.
Daarnaast is de content makkelijk uitbereidbaar, zonder de code te beinvloeden, door middel van scriptable objects. Zo anticipeer ik op dat ik of een andere programmeur in staat is om met gemak het prototype verder uit te werken.

**Volgende stappen**
Als ik door zou ontwikkelen zou ik het volgende verder uitwerken:
* Kleine fixes, zoals HUD en startscherm altijd in front renderer door custom UI shader.
* Effect van planten op de ecologische waardes.
* Een hele hoop locaties, challenges, plants en grondtypes toevoegen. Ideeën zijn: Zuid Amerika, delen van afrika, daar de inheemse soorten van, challenges zoals boskappingen door landbouw, meerdere klimaatveranderingscenario's, planten die meerdere gridspaces opnemen etc. 
* Mogelijkheid voor planten om dood te gaan door het maken van de verkeerde samenstellingen op basis van de challenge.
* tips systeem om spelers te helpen bij het terugkomen op negatieve gevolgen.
* Berekenen van een highscore op basis van de spelers keuzes en de ecologische waardes.
* End-state, het resetten van het level en het starten van een nieuwe.
* Diversions toevoegen waardoor spelers, bij de bosbrand grond bijvoorbeeld, dode bomen moeten verwijderen, of eerst de te droge grond goed moeten bewateren.
* Custom editor waarmee content (planten, locaties, grondtypes etc.) makkelijk gebouwd kan worden, doordat benodigde elementen gecreërd worden in code.

### Gemaakte keuzes
* Om rekening te houden met de context en doelgroep (non-gamers in openbare ruimte) heb ik de focus gelegd op intiutiviteit van controls. Hierom koos ik ervoor om controllers én handtracking te ondersteunen en grijpen de enige input actie te maken.
* Om de drempel voor VR te verlagen voor een groot deel van de samenleving heb ik ervoor gekozen om de omgeving van de VR game, passthrough te maken. Mensen voelen zich zo sneller op hun gemak, en voelen zich minder bekeken. 
* Ik heb nummer 5 uit de opdracht op een andere manier geimplementeerd. De speler kan alle soorten zaden planten. De keuzes van de speler hebben wel invloed op het ecosysteem en daarmee op de eindscore. Door de spelers niets te verbieden zal de speler zelf negatieve gevolgen kunnen ervaren wat leidt tot een leerervaring (learning experience).
* Ik heb nummer 6 uitgebereid. Planten kunnen tussen de 2 en 5 groeistadia hebben afhankelijk van de plantsoort. De type grond beinvloed de groeisnelheid, afhankelijk van de grondkwaliteit. Watergeven geeft een tijdelijk boost in groei voor planten en planten gaan alleen dood als de ecologische waardes ongunstig zijn voor de groei doordat speler de verkeerde keuzes maakt. Ook dit heb ik gedaan om spelers zelf realistische negatieve gevolgen te laten ervaren van hun acties.

# Technische uitwerking

### Lijst aan gebruikte assets
* Synty Polygon Pack: https://syntystore.com/collections/polygon
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
