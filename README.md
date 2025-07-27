# TreesForAll: VR Awareness Campaign

Om een totaalbeeld te geven van mijn vaardigheden heb ik deze opdracht beschouwd als het ontwerpen en ontwikkelen van een toegepaste VR oplossing, net zoals dat voor projecten voor KLM en NS zou gelden.

Om deze reden heb wat context erom heen geschept waarbinnen ik de applied game kon ontwikkelen. Zo heb ik Trees for All als stakeholder genomen en algemeen publiek (dus niet-gamers) als doelgroep.

**Mijn doel:**
Het maken van een reforestation awareness applied game voor Trees for All, binnen de kaders van deze assessment.

**Oplossing:**
Gebruikmaken van VR voor een awareness campagne over de bebossingsprojecten waar Trees for All aan bijdraagt. Het opnieuw bebossen van bestaande gebieden is complexer dan simpelweg bomen planten. Zo is het belangrijk om inheemse soorten te gebruiken en nauwkeurig een nieuw ecosysteem op te zetten en vereisen verschillende problemen een andere aanpak.

Deze complexiteit in combinatie met het bewustzijn dat bossen niet vanzelf weer aangroeien, ookal doet de natuur zijn werk, is een belangrijk besef volgens de website van Trees for All. Niet elke boom overleeft. Een gezond bos vraagt om de juiste bomen op de juiste plek, goede voorbereiding van de bodem én aanpassing aan klimaatverandering.

# Concept

### Build Your Own Forest

    * Te spelen op o.a. NS-stations (denk aan pop-up Utrecht Centraal), festivals, of openbare ruimtes
    * VR-ervaring van max. 5 minuten per speler
    * De speler krijgt een realistische uitdaging en het doel om een klein stuk grond opnieuw te bebossen.
    * Resultaat deelbaar op social media voor bredere impact

### Gameplay
De speler start met een casus: gebied in de wereld, bodemtype, beginwaardes en één van drie ecologische problemen. Binnen vijf minuten moet hij een bos planten door slim te planten, water te geven en verstoringen op te ruimen.

Op basis van het ecologische probleem: slechte bodem, zaadgebrek of klimaatverandering, hebben verschillen planten de voorkeur. Zo kan de speler bodembedekkers, zaaddragende struiken, klimaatbestendige bomen, inheemse bomen en meer planten. Een tipsysteem in combinatie met realtime effect van de keuzes in de vorm van 3 statusbalken in het user-interface, geeft de speler inzicht in voortgang.

Aan het eind krijgt de speler een score op basis van de 3 statusbalken en efficiëntie. Ongeacht de score zijn spelers creatief bezig geweest met een ecologische uitdaging en hebben ze een uniek eigen bos gemaakt. De score én de spelers zelf gemaakte bos kunnen gedeeld worden op social media om delen te stimuleren.

# Technische uitwerking

### Lijst aan gebruikte assets

### Functionele vereisten
1. De game moet een pop-up systeem hebben waarin verschillende schermen weergegeven kunnen worden.

2. De game moet verschillende levels bevatten met hierin:
    * Een locatie (geografisch)
    * Een bodemtype
    * Startwaardes van de drie statusbalken: bodemkwaliteit, biodiversiteit, CO₂-opslag
    * Eén van drie probleemstellingen (gedegradeerde bodem, zaadgebrek, klimaatverandering)

2. De game moet een timer systeem hebben welke gestart kan worden door het gameplay systeem.

3. Spelers moeten de volgende acties kunnen uitvoeren:
    * Selecteren uit de zadenselectie
    * Planten van zaden (bomen, struiken, bodembedekkers)
    * Water geven aan planten
    * Verwijderen van ongewenste planten of dode vegetatie, invasieve soorten

4. De game moet een beplanting selectie hebben voor de speler om te selecteren:
    * Inheemse bomen (diverse types)
    * Klimaatrobuuste exoten (laag invasief)
    * Zuidelijke varianten
    * Zaaddragende struiken
    * Grassen en bodembedekkers

5. De game mag een tipsysteem hebben die suggesties doet als speler vast zit.

6. Drie statusbalken moeten op een HUD dynamisch reageren op speleracties.

7. Score systeem die berekend op basis van:
    * Verbetering van statusbalk waardes
    * Efficiëntie van zaadgebruik

8. De game mag een optie bieden om het bos te delen met social media.

- De game moet levels kunnen inladen, interrupten en resetten, nieuw level inladen
- de game moet een popup scherm kunnen weergeven
- de game moet UI input buttons kunnen verwerken
- de game moet een level kunnen starten met een distraction
- de game moet distractions kunnen definiëren
- de game moet levels kunnen definiëren
- een level moet een timer hebben
- de game moet een endstate hebben
- de game moet een score bijhouden obv seeds spent
- de speler moet fysiek kunnen bewegen in roomscale
- de speler moet een place actie kunnen uitvoeren
- de speler moet een remove actie kunnen uitvoeren
- de speler moet een select actie kunnen uitvoeren
- de speler moet een grab actie kunnen uitvoeren
- de game moet een grid managen
- de speler moet een water actie kunnen uitvoeren
- de game moet een plantable selection hebben
- een level moet een challenge bevatten
- de game moet level variables kunnen managen
- de game moet een hud met timer en de level variables managen

### Niet-functionele vereisten

1. De VR-ervaring moet volledig speelbaar zijn binnen 5 minuten.

2. Het systeem moet toegankelijk en intuïtief zijn voor gebruikers zonder ecologische voorkennis.

3. De visuele stijl is sfeervol, zacht en speels. Maakt gebruik van aarde tonen en groen om een biologische uitstraling te hebben.

4. De ervaring moet geschikt zijn voor gebruik op openbare locaties (zoals NS-stations), met vloeiende doorstroom en lage instapdrempel.

5. Feedback en uitleg moeten compact, visueel en in begrijpelijke taal zijn (geen vakjargon).

6. De game moet offline speelbaar zijn, met optionele online functionaliteit voor het delen van resultaten.

7. De game moet met minimaal 90 fps draaien op alle momenten.