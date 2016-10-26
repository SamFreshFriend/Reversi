# Reversi

Dit is het Reversi practicum van Sam Beard (5995442) en Marien Raat (5947456).

### Algemeen

Wij hebben naast de eisen van de opdracht een aantal extra features toegevoegd
en optimalisaties toegevoegd, hieronder zullen we een deel hiervan beschrijven.

### Features
  * We hebben de mogelijkheid toegevoegd om 1 of beide spelers door een computer
    door een computer te vervangen. Hierdoor kan de gebruiker tegen de computer
    spelen of zelfs kijken hoe 2 computers tegen elkaar spelen.
    
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
    
    Nadat we dit hadden geimplementeerd werkte onze AI al best redelijk, het kon
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
    
  * Onze code heeft de mogelijkheid om op een arbritair veld van mijn minimaal
    3 bij 3 vakjes te werken, in plaats van alleen op een 6 bij 6 veld. Daarom
    hebben wij door middel van een ListBox in de UI de gebruiker de keuze
    gegeven tussen een aantal verschillende bord afmetingen.

Voorbeeld van Gameplay tegen computer:

![alt tag](https://raw.githubusercontent.com/SamFreshFriend/Reversi/master/CompVPlayer.gif)

Voorbeeld van Gameplay Computer tegen Computer:

![alt tag](https://raw.githubusercontent.com/SamFreshFriend/Reversi/master/CompVComp.gif)
