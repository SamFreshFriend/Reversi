# Reversi

Dit is het Reversi practicum van Sam Beard (5995442) en Marien Raat (5947456).

### Algemeen

Voor onze tweede opdracht voor het vak Imperatief Programmeren was het de 
opdracht om het bordspel Reversi na te maken. Wij hebben zo goed mogelijk aan 
de eisen van de opdracht voldaan en ook extra features en optimalisaties 
toegevoegd, zoals onder andere een AI waar tegen te spelen valt.

### Features
  * We hebben de mogelijkheid toegevoegd om 1 of beide spelers door een computer
    te vervangen. Hierdoor kan de gebruiker tegen de computer spelen of zelfs
    kijken hoe 2 computers tegen elkaar spelen.

    Om dit mogelijk te maken hebben wij een AI voor het spel Reversi geschreven.
    Onze AI zoekt 6 zetten 'diep' naar de beste zet met het [MiniMax
    algoritme](https://en.wikipedia.org/wiki/Minimax). Om te bepalen hoe goed
    een zet is als de AI de maximale diepte heeft bereikt hebben we een methode
    gemaakt die een bord een score geeft, hoe hoger deze score is, hoe beter het
    bord voor de AI is. Deze methode (AILogic.getBoardScore) maakt gebruik van
    een veld waarop voor elke positie waar een steen kan liggen een score is
    gegeven, die aangeeft hoe goed het is om daar een steen te hebben. In de
    hoeken is die score bijvoorbeeld het hoogst, omdat die niet meer afgepakt
    kunnen worden en zijn de plekken net om de hoeken heen het laagst, omdat
    daar een steen plaatsen vaak ertoe lijdt dat de tegenstander de hoek krijgt.
    De AILogic.getBoardScore methode geeft de punten van alle plekken waar de
    AI een steen heeft min de punten van alle plekken waar zijn tegenstander een
    steen heeft.

    Behalve wanneer de maximale diepte is bereikt moet er nog op een ander een
    moment een score van een bord berekend worden, namelijk als het game over is
    tijdens het zoeken. In dat geval kan namelijk niet dieper worden gezocht (er
    zijn namelijk geen nieuwe moves meer mogelijk). In plaats van dan ook gewoon
    de AILogic.getBoardScore methode te gebruiken, gebruiken we dan een andere
    score, waarbij de positie van de stenen niet meer wordt meegerekent, aan het
    eind maakt het immers niet uit waar de stenen liggen, als je er maar het
    meest hebt.

  * Onze code heeft de mogelijkheid om op een arbritair veld van mijn minimaal
    3 bij 3 vakjes te werken, in plaats van alleen op een 6 bij 6 veld. Daarom
    hebben wij door middel van een ListBox in de UI de gebruiker de keuze
    gegeven tussen een aantal verschillende veldgroottes

  * We hebben de UI extra mooi gemaakt, door middel van een mooie achtergronden
    voor het scherm en het veld, gekleurde teksten en de vertrouwde Windows
    Vista 'Start'-knop in plaats van een saaie knop waar 'start' op staat.

  * De gebruiker kan het scherm naar zijn behoefte 'resizen', waarbij het veld
    steeds van grootte veranderd om het form te vullen.

### Optimalisaties
  * Nadat we de AI hadden geimplementeerd werkte deze al best redelijk, het kon
    echter maar 3 zetten diep zoeken, voordat het te lang duurde om de beste zet
    te vinden. Hierdoor was het iets te makkelijk om onze AI te verslaan. Omdat
    de tijd om het te berekenen exponentieel toeneemt hoe dieper de AI zoekt,
    zouden simpele optimalisaties niet veel zoden aan de dijk zetten. Dus hebben
    we besloten [alpha-beta
    pruning](https://en.wikipedia.org/wiki/Alpha%E2%80%93beta_pruning) toe te
    voegen aan onze AI. Dit zorgt ervoor dat zetten die toch al niet meer het
    beste kunnen worden niet verder onderzocht worden. Omdat dit dieper ook
    exponentieel meer tijd bespaart, zorgt dit er wel voor dat de AI een stuk
    dieper kan zoeken. Na deze optimalisatie kon de AI zonder veel tijd te
    gebruiken 6 diep zoeken, in plaats van 3 diep. Dit heeft er voor gezocht
    dat de AI een stuk beter is en een goede tegenstander is voor de gebruiker.

  * Onze methode die checked of een zet legaal is, bewaart een lijst van
    richtingen waarin er stenen vervangen zullen worden en onze methode om een
    zet door te voeren gebruikt deze lijst om de stenen te vervangen. Zo wordt
    minder werk dubbel gedaan.

### Gameplay

Om een spel te starten dient er op de (windows Vista) start knop gedrukt worden
waarna vervolgens een nieuw spel aangemaakt wordt, het is ook mogelijk een
andere veldgrootte te selecteren in de combobox en de player mode (Computer of
user ) kan worden gekozen met de checkboxes aan de linker kant van de UI.

In computer versus player modus begint de speler en zal de computer automatisch
'antwoord' geven door middel van een zet.

_Voorbeeld van Gameplay tegen computer:_

![alt tag](https://raw.githubusercontent.com/SamFreshFriend/Reversi/master/CompVPlayer.gif)

In computer versus computer modus dient er na op de Vista knop geklikt te hebben
ook nog op de 'Start/ Stop' knop gedrukt worden. Dit start het proces wat de
Gameplay simuleert. Bij het drukken op de stop knop wordt de simulatie
gepauzeerd en het veld geupdate. De simulatie kan vervolgd worden door de 'Start/
Stop' knop weder in te drukken.

_Voorbeeld van Gameplay Computer tegen Computer:_

![alt tag](https://raw.githubusercontent.com/SamFreshFriend/Reversi/master/CompVComp.gif)
